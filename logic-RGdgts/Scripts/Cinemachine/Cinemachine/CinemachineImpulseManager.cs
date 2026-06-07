using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cinemachine
{
	public class CinemachineImpulseManager
	{
		[Serializable]
		public struct EnvelopeDefinition
		{
			public AnimationCurve m_AttackShape;

			public AnimationCurve m_DecayShape;

			public float m_AttackTime;

			public float m_SustainTime;

			public float m_DecayTime;

			public bool m_ScaleWithImpact;

			public bool m_HoldForever;

			public float Duration => 0f;

			public static EnvelopeDefinition Default()
			{
				return default(EnvelopeDefinition);
			}

			public float GetValueAt(float offset)
			{
				return 0f;
			}

			public void ChangeStopTime(float offset, bool forceNoDecay)
			{
			}

			public void Clear()
			{
			}

			public void Validate()
			{
			}
		}

		public class ImpulseEvent
		{
			public enum DirectionMode
			{
				Fixed = 0,
				RotateTowardSource = 1
			}

			public enum DissipationMode
			{
				LinearDecay = 0,
				SoftDecay = 1,
				ExponentialDecay = 2
			}

			public float m_StartTime;

			public EnvelopeDefinition m_Envelope;

			public ISignalSource6D m_SignalSource;

			public Vector3 m_Position;

			public float m_Radius;

			public DirectionMode m_DirectionMode;

			public int m_Channel;

			public DissipationMode m_DissipationMode;

			public float m_DissipationDistance;

			public float m_PropagationSpeed;

			public bool Expired => false;

			public void Cancel(float time, bool forceNoDecay)
			{
			}

			public float DistanceDecay(float distance)
			{
				return 0f;
			}

			public bool GetDecayedSignal(Vector3 listenerPosition, bool use2D, out Vector3 pos, out Quaternion rot)
			{
				pos = default(Vector3);
				rot = default(Quaternion);
				return false;
			}

			public void Clear()
			{
			}

			internal ImpulseEvent()
			{
			}
		}

		private static CinemachineImpulseManager sInstance;

		private const float Epsilon = 0.0001f;

		private List<ImpulseEvent> m_ExpiredEvents;

		private List<ImpulseEvent> m_ActiveEvents;

		public static CinemachineImpulseManager Instance => null;

		public bool IgnoreTimeScale { get; set; }

		public float CurrentTime => 0f;

		private CinemachineImpulseManager()
		{
		}

		[RuntimeInitializeOnLoadMethod]
		private static void InitializeModule()
		{
		}

		public bool GetImpulseAt(Vector3 listenerLocation, bool distance2D, int channelMask, out Vector3 pos, out Quaternion rot)
		{
			pos = default(Vector3);
			rot = default(Quaternion);
			return false;
		}

		public ImpulseEvent NewImpulseEvent()
		{
			return null;
		}

		public void AddImpulseEvent(ImpulseEvent e)
		{
		}

		public void Clear()
		{
		}
	}
}
