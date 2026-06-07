using System;
using UnityEngine;

namespace AK.Wwise
{
	[Serializable]
	public class Event : BaseType
	{
		public WwiseEventReference WwiseObjectReference;

		private uint m_playingId;

		public uint PlayingId => 0u;

		public override WwiseObjectReference ObjectReference
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override WwiseObjectType WwiseObjectType => default(WwiseObjectType);

		private void VerifyPlayingID(uint playingId)
		{
		}

		public uint Post(GameObject gameObject)
		{
			return 0u;
		}

		public uint Post(GameObject gameObject, CallbackFlags flags, AkCallbackManager.EventCallback callback, object cookie = null)
		{
			return 0u;
		}

		public uint Post(GameObject gameObject, uint flags, AkCallbackManager.EventCallback callback, object cookie = null)
		{
			return 0u;
		}

		public uint Post(ulong gameObjectId)
		{
			return 0u;
		}

		public void Stop(GameObject gameObject, int transitionDuration = 0, AkCurveInterpolation curveInterpolation = AkCurveInterpolation.AkCurveInterpolation_Linear)
		{
		}

		public void ExecuteAction(GameObject gameObject, AkActionOnEventType actionOnEventType, int transitionDuration, AkCurveInterpolation curveInterpolation)
		{
		}

		public void PostMIDI(GameObject gameObject, AkMIDIPostArray array)
		{
		}

		public void PostMIDI(GameObject gameObject, AkMIDIPostArray array, int count)
		{
		}

		public void StopMIDI(GameObject gameObject)
		{
		}

		public void StopMIDI()
		{
		}
	}
}
