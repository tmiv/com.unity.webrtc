#pragma once
#include "WebRTCPlugin.h"

namespace WebRTC
{
    class SetSessionDescriptionObserver : public webrtc::SetSessionDescriptionObserver
    {
    public:
        static rtc::scoped_refptr<SetSessionDescriptionObserver> Create(PeerConnectionObject* connection);
        void RegisterDelegateOnSuccess(DelegateSetSessionDescSuccess onSuccess);
        void RegisterDelegateOnFailure(DelegateSetSessionDescFailure onFailure);

        void OnSuccess() override;
        void OnFailure(const std::string& error) override;
    protected:
        explicit SetSessionDescriptionObserver(PeerConnectionObject * connection);
        ~SetSessionDescriptionObserver() = default;
    private:
        PeerConnectionObject* m_connection;
        DelegateSetSessionDescSuccess m_delegateSuccess;
        DelegateSetSessionDescFailure m_delegateFailure;
    };
}
