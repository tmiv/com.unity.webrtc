#include "pch.h"
#include "PeerConnectionStatsCollectorCallback.h"
#include "PeerConnectionObject.h"

namespace WebRTC
{
    PeerConnectionStatsCollectorCallback* PeerConnectionStatsCollectorCallback::Create(PeerConnectionObject* connection)
    {
        return new rtc::RefCountedObject<PeerConnectionStatsCollectorCallback>(connection);
    }
    void PeerConnectionStatsCollectorCallback::OnStatsDelivered(const rtc::scoped_refptr<const webrtc::RTCStatsReport>& report)
    {
        if (nullptr == m_collectStatsCallback) {
            return;
        }
        m_collectStatsCallback(m_owner, report.get());
    }
}
