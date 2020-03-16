using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

namespace Unity.WebRTC
{

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class AsyncOperationBase : CustomYieldInstruction
    {
        public RTCError Error { get; internal set; }

        public bool IsError { get; internal set; }
        public bool IsDone { get; internal set; }

        public override bool keepWaiting
        {
            get
            {
                if (IsDone)
                {
                    Debug.Log("IsDone");
                    return false;
                }
                return true;
            }
        }

        internal void Done()
        {
            IsDone = true;
        }
    }

    public class RTCSessionDescriptionAsyncOperation : AsyncOperationBase
    {
        public RTCSessionDescription Desc { get; internal set; }
    }

    public class RTCSetSessionDescriptionAsyncOperation : AsyncOperationBase
    {
        internal RTCSetSessionDescriptionAsyncOperation(RTCPeerConnection connection)
        {
            connection.OnSetSessionDescriptionSuccess = () =>
            {
                IsError = false;
                this.Done();
            };
            connection.OnSetSessionDescriptionFailure = () =>
            {
                IsError = true;
                this.Done();
            };
        }
    }

    /*
    public enum RTCStatsType
    {
        transport,
        track
    }*/

    internal static class IntPtrExtension
    {
        internal static string AsString(this IntPtr ptr)
        {
            return Marshal.PtrToStringAnsi(ptr);
        }
    }

    internal class RTCStatsMember
    {
        private IntPtr self;
        internal RTCStatsMember(IntPtr ptr)
        {
            self = ptr;
        }

        internal string GetName()
        {
            return NativeMethods.StatsMemberGetName(self).AsString();
        }

        internal string AsString()
        {
            return NativeMethods.StatsMemberGetString(self).AsString();
        }

        internal ulong AsUnsignedLong()
        {
            return NativeMethods.StatsMemberGetUnsignedLong(self);
        }

    }

    public class RTCStats
    {
        private IntPtr self;
        private Dictionary<string, RTCStatsMember> m_members;

        public string Type
        {
            get { return NativeMethods.StatsGetType(self).AsString(); }
        }

        public string Id
        {
            get  { return NativeMethods.StatsGetId(self).AsString(); }
        }

        public long Timestamp
        {
            get { return NativeMethods.StatsGetTimestamp(self); }
        }

        public object this[string key]
        {
            get
            {
                RTCStatsMember value = null;
                if (m_members.TryGetValue(key, out value))
                {
                    return value;
                }
                throw new KeyNotFoundException(key);
            }
        }

        internal RTCStats(IntPtr ptr)
        {
            self = ptr;
            int length = 0;
            RTCStatsMember[] array = GetMembers();
            m_members = new Dictionary<string, RTCStatsMember>();
            foreach (var member in array)
            {
                m_members.Add(member.GetName(), member);
            }
        }

        internal RTCStatsMember[] GetMembers()
        {
            int length = 0;
            IntPtr buf = NativeMethods.StatsGetMembers(self, ref length);
            var array = new IntPtr[length];
            Marshal.Copy(buf, array, 0, length);
            Marshal.FreeCoTaskMem(buf);

            RTCStatsMember[] members = new RTCStatsMember[length];
            for (int i = 0; i < length; i++)
            {
                members[i] = new RTCStatsMember(array[i]);
            }
            return members;
        }

        public string ToJson()
        {
            return NativeMethods.StatsGetJson(self).AsString();
        }
    }

    public class RTCStatsReport
    {
        private IntPtr self;
        private RTCStats[] m_listStats;

        internal RTCStatsReport(IntPtr ptr)
        {
            self = ptr;
            int length = 0;
            IntPtr buf = NativeMethods.StatsReportGetList(self, ref length);

            var array = new IntPtr[length];
            Marshal.Copy(buf, array, 0, length);
            Marshal.FreeCoTaskMem(buf);

            m_listStats = new RTCStats[length];
            for (int i = 0; i < length; i++)
            {
                m_listStats[i] = new RTCStats(array[i]);
            }
        }

        public IEnumerable<RTCStats> GetEnumerator()
        {
            return m_listStats.AsEnumerable();
        }
    }

    public class RTCStatsReportAsyncOperation : AsyncOperationBase
    {
        public RTCStatsReport Value { get; private set; }

        internal RTCStatsReportAsyncOperation(RTCPeerConnection connection)
        {
            WebRTC.Context.PeerConnectionGetStats(connection.self);

            connection.OnStatsDelivered = ptr =>
            {
                Value = new RTCStatsReport(ptr);
                IsError = false;
                this.Done();
            };
        }
    }


    public class RTCIceCandidateRequestAsyncOperation : CustomYieldInstruction
    {
        public bool isError { get; private set;  }
        public RTCError error { get; private set; }
        public bool isDone { get; private set;  }

        public override bool keepWaiting
        {
            get
            {
                return isDone;
            }
        }

        public void Done()
        {
            isDone = true;
        }
    }

    public class RTCAsyncOperation : CustomYieldInstruction
    {
        public bool isError { get; private set; }
        public RTCError error { get; private set; }
        public bool isDone { get; private set; }

        public override bool keepWaiting
        {
            get
            {
                return isDone;
            }
        }

        public void Done()
        {
            isDone = true;
        }
    }
}
