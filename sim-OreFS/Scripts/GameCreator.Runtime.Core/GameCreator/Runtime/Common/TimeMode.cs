using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public struct TimeMode
	{
		public enum UpdateMode
		{
			GameTime = 0,
			UnscaledTime = 1
		}

		[SerializeField]
		private UpdateMode m_UpdateTime;

		public UpdateMode UpdateTime => m_UpdateTime;

		public float Time
		{
			get
			{
				if (m_UpdateTime != UpdateMode.GameTime)
				{
					return UnityEngine.Time.unscaledTime;
				}
				return UnityEngine.Time.time;
			}
		}

		public float DeltaTime
		{
			get
			{
				if (m_UpdateTime != UpdateMode.GameTime)
				{
					return UnityEngine.Time.unscaledDeltaTime;
				}
				return UnityEngine.Time.deltaTime;
			}
		}

		public float FixedTime
		{
			get
			{
				if (m_UpdateTime != UpdateMode.GameTime)
				{
					return UnityEngine.Time.fixedUnscaledTime;
				}
				return UnityEngine.Time.fixedTime;
			}
		}

		public float FixedDeltaTime
		{
			get
			{
				if (m_UpdateTime != UpdateMode.GameTime)
				{
					return UnityEngine.Time.fixedUnscaledDeltaTime;
				}
				return UnityEngine.Time.fixedDeltaTime;
			}
		}

		public float TimeScale
		{
			get
			{
				if (m_UpdateTime != UpdateMode.GameTime)
				{
					return 1f;
				}
				return UnityEngine.Time.timeScale;
			}
		}

		public int Frame => UnityEngine.Time.frameCount;

		public int RenderedFrame => UnityEngine.Time.renderedFrameCount;

		public double TimeAsDouble
		{
			get
			{
				if (m_UpdateTime != UpdateMode.GameTime)
				{
					return UnityEngine.Time.unscaledTimeAsDouble;
				}
				return UnityEngine.Time.timeAsDouble;
			}
		}

		public double FixedTimeAsDouble
		{
			get
			{
				if (m_UpdateTime != UpdateMode.GameTime)
				{
					return UnityEngine.Time.fixedUnscaledTimeAsDouble;
				}
				return UnityEngine.Time.fixedTimeAsDouble;
			}
		}

		public TimeMode(UpdateMode mode)
		{
			m_UpdateTime = mode;
		}
	}
}
