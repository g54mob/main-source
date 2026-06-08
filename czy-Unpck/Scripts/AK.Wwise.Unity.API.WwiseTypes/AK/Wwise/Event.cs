using System;
using UnityEngine;

namespace AK.Wwise
{
	[Serializable]
	public class Event : BaseType
	{
		public WwiseEventReference WwiseObjectReference;

		private uint m_playingId;

		public uint PlayingId => m_playingId;

		public override WwiseObjectReference ObjectReference
		{
			get
			{
				return WwiseObjectReference;
			}
			set
			{
				WwiseObjectReference = value as WwiseEventReference;
			}
		}

		public override WwiseObjectType WwiseObjectType => WwiseObjectType.Event;

		private void VerifyPlayingID(uint playingId)
		{
		}

		public uint Post(GameObject gameObject)
		{
			if (!IsValid())
			{
				return 0u;
			}
			m_playingId = AkSoundEngine.PostEvent(base.Id, gameObject);
			VerifyPlayingID(m_playingId);
			return m_playingId;
		}

		public uint Post(GameObject gameObject, CallbackFlags flags, AkCallbackManager.EventCallback callback, object cookie = null)
		{
			if (!IsValid())
			{
				return 0u;
			}
			m_playingId = AkSoundEngine.PostEvent(base.Id, gameObject, flags.value, callback, cookie);
			VerifyPlayingID(m_playingId);
			return m_playingId;
		}

		public uint Post(GameObject gameObject, uint flags, AkCallbackManager.EventCallback callback, object cookie = null)
		{
			if (!IsValid())
			{
				return 0u;
			}
			m_playingId = AkSoundEngine.PostEvent(base.Id, gameObject, flags, callback, cookie);
			VerifyPlayingID(m_playingId);
			return m_playingId;
		}

		public void Stop(GameObject gameObject, int transitionDuration = 0, AkCurveInterpolation curveInterpolation = AkCurveInterpolation.AkCurveInterpolation_Linear)
		{
			ExecuteAction(gameObject, AkActionOnEventType.AkActionOnEventType_Stop, transitionDuration, curveInterpolation);
		}

		public void ExecuteAction(GameObject gameObject, AkActionOnEventType actionOnEventType, int transitionDuration, AkCurveInterpolation curveInterpolation)
		{
			if (IsValid())
			{
				AKRESULT result = AkSoundEngine.ExecuteActionOnEvent(base.Id, actionOnEventType, gameObject, transitionDuration, curveInterpolation);
				Verify(result);
			}
		}

		public void PostMIDI(GameObject gameObject, AkMIDIPostArray array)
		{
			if (IsValid())
			{
				array.PostOnEvent(base.Id, gameObject);
			}
		}

		public void PostMIDI(GameObject gameObject, AkMIDIPostArray array, int count)
		{
			if (IsValid())
			{
				array.PostOnEvent(base.Id, gameObject, count);
			}
		}

		public void StopMIDI(GameObject gameObject)
		{
			if (IsValid())
			{
				AkSoundEngine.StopMIDIOnEvent(base.Id, gameObject);
			}
		}

		public void StopMIDI()
		{
			if (IsValid())
			{
				AkSoundEngine.StopMIDIOnEvent(base.Id);
			}
		}
	}
}
