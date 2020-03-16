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

    public class RTCStats
    {
        private IntPtr self;
        private string rawData;

        public string type;
        public string id;
        public ulong timestamp;

        internal RTCStats(IntPtr ptr)
        {
            self = ptr;

            StringBuilder buf = new StringBuilder(255);
            NativeMethods.StatsGetJson(self, buf);
            rawData = buf.ToString();

            JsonUtility.FromJsonOverwrite(rawData, this);
        }

        public string GetJson()
        {
            return rawData;
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

        /*
        RTCStatsReport[] Parse(string json)
        {
            string prefix = "{\"list\":";
            string suffix = "}";

            int size = json.Length + prefix.Length + suffix.Length;
            StringBuilder sb = new StringBuilder(size);
            sb.Append(prefix).Append(json).Append(suffix);
            Debug.Log(sb.ToString());
            return JsonUtility.FromJson<RTCStatsReportList>(sb.ToString()).list;
        }
        */
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
