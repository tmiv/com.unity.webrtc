#pragma once
#include "WebRTCPlugin.h"

namespace WebRTC
{
    class PeerConnectionObject;
    using DelegateCollectStats = void(*)(PeerConnectionObject*, const webrtc::RTCStatsReport*);
    class PeerConnectionStatsCollectorCallback : public webrtc::RTCStatsCollectorCallback
    {
    public:
        PeerConnectionStatsCollectorCallback(const PeerConnectionStatsCollectorCallback&) = delete;
        PeerConnectionStatsCollectorCallback& operator=(const PeerConnectionStatsCollectorCallback&) = delete;
        static PeerConnectionStatsCollectorCallback* Create(PeerConnectionObject* connection);
        void SetCallback(DelegateCollectStats callback) { m_collectStatsCallback = callback; }
        void OnStatsDelivered(const rtc::scoped_refptr<const webrtc::RTCStatsReport>& report) override;
    protected:
        explicit PeerConnectionStatsCollectorCallback(PeerConnectionObject* owner) { m_owner = owner; }
        ~PeerConnectionStatsCollectorCallback() override = default;
    private:
        DelegateCollectStats m_collectStatsCallback = nullptr;
        PeerConnectionObject* m_owner = nullptr;
    };
}
