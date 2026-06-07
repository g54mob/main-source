using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	[Serializable]
	public class ShotSystemZoom : TShotSystem
	{
		public static readonly int ID = "ShotSystemZoom".GetHashCode();

		[SerializeField]
		[Range(0f, 1f)]
		private float m_TargetZoom = 1f;

		[SerializeField]
		private float m_MinDistance = 0.5f;

		[SerializeField]
		private float m_SmoothTime = 0.1f;

		[SerializeField]
		private InputPropertyValueVector2 m_InputZoom = InputValueVector2Scroll.Create();

		[SerializeField]
		private PropertyGetDecimal m_Sensitivity = GetDecimalConstantPointOne.Create;

		[NonSerialized]
		private float m_Velocity;

		public override int Id => ID;

		public float SmoothTime
		{
			get
			{
				return m_SmoothTime;
			}
			set
			{
				m_SmoothTime = value;
			}
		}

		public float Level { get; set; }

		public float MinDistance
		{
			get
			{
				return m_MinDistance;
			}
			set
			{
				m_MinDistance = value;
			}
		}

		public override void OnAwake(TShotType shotType)
		{
			base.OnAwake(shotType);
			m_InputZoom.OnStartup();
			Level = 1f;
		}

		public override void OnDestroy(TShotType shotType)
		{
			base.OnDestroy(shotType);
			m_InputZoom.OnDispose();
		}

		public override void OnUpdate(TShotType shotType)
		{
			base.OnUpdate(shotType);
			m_InputZoom.OnUpdate();
			float deltaTime = shotType.ShotCamera.TimeMode.DeltaTime;
			if (shotType.IsActive)
			{
				float num = (float)m_Sensitivity.Get(shotType.Args);
				float num2 = (0f - m_InputZoom.Read().y) * num;
				m_TargetZoom = Mathf.Clamp01(m_TargetZoom + num2);
			}
			Level = ((deltaTime > float.Epsilon) ? Mathf.SmoothDamp(Level, m_TargetZoom, ref m_Velocity, m_SmoothTime, float.PositiveInfinity, deltaTime) : Level);
		}
	}
}
