using System;
using UnityEngine;

namespace Cinemachine
{
	[Serializable]
	public class CinemachineImpulseDefinition
	{
		public enum RepeatMode
		{
			Stretch = 0,
			Loop = 1
		}

		private class SignalSource : ISignalSource6D
		{
			private CinemachineImpulseDefinition m_Def;

			private Vector3 m_Velocity;

			private float m_StartTimeOffset;

			public float SignalDuration => 0f;

			public SignalSource(CinemachineImpulseDefinition def, Vector3 velocity)
			{
			}

			public void GetSignal(float timeSinceSignalStart, out Vector3 pos, out Quaternion rot)
			{
				pos = default(Vector3);
				rot = default(Quaternion);
			}
		}

		[CinemachineImpulseChannelProperty]
		public int m_ImpulseChannel;

		public SignalSourceAsset m_RawSignal;

		public float m_AmplitudeGain;

		public float m_FrequencyGain;

		public RepeatMode m_RepeatMode;

		public bool m_Randomize;

		[CinemachineImpulseEnvelopeProperty]
		public CinemachineImpulseManager.EnvelopeDefinition m_TimeEnvelope;

		public float m_ImpactRadius;

		public CinemachineImpulseManager.ImpulseEvent.DirectionMode m_DirectionMode;

		public CinemachineImpulseManager.ImpulseEvent.DissipationMode m_DissipationMode;

		public float m_DissipationDistance;

		public float m_PropagationSpeed;

		public void OnValidate()
		{
		}

		public void CreateEvent(Vector3 position, Vector3 velocity)
		{
		}

		public CinemachineImpulseManager.ImpulseEvent CreateAndReturnEvent(Vector3 position, Vector3 velocity)
		{
			return null;
		}
	}
}
