#include "pch.h"
#include "SetSessionDescriptionObserver.h"
#include "PeerConnectionObject.h"

namespace WebRTC
{
    rtc::scoped_refptr<SetSessionDescriptionObserver> SetSessionDescriptionObserver::Create(PeerConnectionObject* connection)
    {
        return new rtc::RefCountedObject<SetSessionDescriptionObserver>(connection);
    }

    SetSessionDescriptionObserver::SetSessionDescriptionObserver(PeerConnectionObject* connection)
    {
        m_connection = connection;
    }

    void SetSessionDescriptionObserver::RegisterDelegateOnSuccess(DelegateSetSessionDescSuccess onSuccess)
    {
        m_delegateSuccess = onSuccess;
	}

    void SetSessionDescriptionObserver::RegisterDelegateOnFailure(DelegateSetSessionDescFailure onFailure)
    {
        m_delegateFailure = onFailure;
    }

    void SetSessionDescriptionObserver::OnSuccess()
    {
        m_delegateSuccess(m_connection);
    }

    void SetSessionDescriptionObserver::OnFailure(const std::string& error)
    {
        m_delegateFailure(m_connection);
    }
}
