using System;
using UnityEngine;

namespace Cinemachine
{
	[Serializable]
	public struct AxisState
	{
		public enum SpeedMode
		{
			MaxSpeed = 0,
			InputValueGain = 1
		}

		public interface IInputAxisProvider
		{
			float GetAxisValue(int axis);
		}

		[Serializable]
		public struct Recentering
		{
			public bool m_enabled;

			public float m_WaitTime;

			public float m_RecenteringTime;

			private float mLastAxisInputTime;

			private float mRecenteringVelocity;

			[SerializeField]
			[HideInInspector]
			private int m_LegacyHeadingDefinition;

			[SerializeField]
			[HideInInspector]
			private int m_LegacyVelocityFilterStrength;

			public Recentering(bool enabled, float waitTime, float recenteringTime)
			{
				m_enabled = false;
				m_WaitTime = 0f;
				m_RecenteringTime = 0f;
				mLastAxisInputTime = 0f;
				mRecenteringVelocity = 0f;
				m_LegacyHeadingDefinition = 0;
				m_LegacyVelocityFilterStrength = 0;
			}

			public void Validate()
			{
			}

			public void CopyStateFrom(ref Recentering other)
			{
			}

			public void CancelRecentering()
			{
			}

			public void RecenterNow()
			{
			}

			public void DoRecentering(ref AxisState axis, float deltaTime, float recenterTarget)
			{
			}

			internal bool LegacyUpgrade(ref int heading, ref int velocityFilter)
			{
				return false;
			}
		}

		[NoSaveDuringPlay]
		public float Value;

		public SpeedMode m_SpeedMode;

		public float m_MaxSpeed;

		public float m_AccelTime;

		public float m_DecelTime;

		public string m_InputAxisName;

		[NoSaveDuringPlay]
		public float m_InputAxisValue;

		public bool m_InvertInput;

		public float m_MinValue;

		public float m_MaxValue;

		public bool m_Wrap;

		public Recentering m_Recentering;

		private float m_CurrentSpeed;

		private float m_LastUpdateTime;

		private int m_LastUpdateFrame;

		private const float Epsilon = 0.0001f;

		private IInputAxisProvider m_InputAxisProvider;

		private int m_InputAxisIndex;

		public bool HasInputProvider => false;

		public bool ValueRangeLocked { get; set; }

		public bool HasRecentering { get; set; }

		public AxisState(float minValue, float maxValue, bool wrap, bool rangeLocked, float maxSpeed, float accelTime, float decelTime, string name, bool invert)
		{
			Value = 0f;
			m_SpeedMode = default(SpeedMode);
			m_MaxSpeed = 0f;
			m_AccelTime = 0f;
			m_DecelTime = 0f;
			m_InputAxisName = null;
			m_InputAxisValue = 0f;
			m_InvertInput = false;
			m_MinValue = 0f;
			m_MaxValue = 0f;
			m_Wrap = false;
			m_Recentering = default(Recentering);
			m_CurrentSpeed = 0f;
			m_LastUpdateTime = 0f;
			m_LastUpdateFrame = 0;
			m_InputAxisProvider = null;
			m_InputAxisIndex = 0;
			ValueRangeLocked = false;
			HasRecentering = false;
		}

		public void Validate()
		{
		}

		public void Reset()
		{
		}

		public void SetInputAxisProvider(int axis, IInputAxisProvider provider)
		{
		}

		public bool Update(float deltaTime)
		{
			return false;
		}

		private float ClampValue(float v)
		{
			return 0f;
		}

		private bool MaxSpeedUpdate(float input, float deltaTime)
		{
			return false;
		}

		private float GetMaxSpeed()
		{
			return 0f;
		}
	}
}
