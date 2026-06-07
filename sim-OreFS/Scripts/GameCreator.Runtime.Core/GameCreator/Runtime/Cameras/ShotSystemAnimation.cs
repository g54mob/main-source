using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	[Serializable]
	public class ShotSystemAnimation : TShotSystem
	{
		public static readonly int ID = "ShotSystemAnimation".GetHashCode();

		[SerializeField]
		private float m_Duration = 3f;

		[SerializeField]
		private Easing.Type m_Easing = Easing.Type.QuadInOut;

		[SerializeField]
		private Bezier m_Path = new Bezier(new Vector3(0f, 0f, -2f), new Vector3(0f, 0f, 2f), new Vector3(-2f, 0f, 1f), new Vector3(-2f, 0f, -1f));

		private float m_StartTime;

		public override int Id => ID;

		public float Duration
		{
			get
			{
				return m_Duration;
			}
			set
			{
				m_Duration = value;
			}
		}

		public override void OnEnable(TShotType shotType, TCamera camera)
		{
			base.OnEnable(shotType, camera);
			m_StartTime = shotType.ShotCamera.TimeMode.Time;
		}

		public override void OnUpdate(TShotType shotType)
		{
			base.OnUpdate(shotType);
			float num = shotType.ShotCamera.TimeMode.Time - m_StartTime;
			float ease = Easing.GetEase(m_Easing, 0f, 1f, num / m_Duration);
			Vector3 position = m_Path.Get(ease);
			shotType.Position = shotType.ShotCamera.transform.TransformPoint(position);
		}

		public override void OnDrawGizmosSelected(TShotType shotType, Transform transform)
		{
			base.OnDrawGizmosSelected(shotType, transform);
			DoDrawGizmos(shotType, TShotSystem.GIZMOS_COLOR_ACTIVE, transform);
		}

		private void DoDrawGizmos(TShotType shotType, Color color, Transform transform)
		{
			Gizmos.color = color;
			m_Path.DrawGizmos(transform);
		}
	}
}
