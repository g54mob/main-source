using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	[Serializable]
	public class ShotSystemTrack : TShotSystem
	{
		public static readonly int ID = "ShotSystemTrack".GetHashCode();

		[SerializeField]
		private PropertyGetGameObject m_Target = GetGameObjectPlayer.Create();

		[SerializeField]
		private PropertyGetDirection m_Offset = GetDirectionVector3Zero.Create();

		[SerializeField]
		private Bezier m_Track = new Bezier(new Vector3(0f, 0f, -2f), new Vector3(0f, 0f, 2f), new Vector3(-2f, 0f, 1f), new Vector3(-2f, 0f, -1f));

		[SerializeField]
		private Segment m_RelativeTo = new Segment(new Vector3(0f, -2f, -3f), new Vector3(0f, -2f, 3f));

		public override int Id => ID;

		public override void OnUpdate(TShotType shotType)
		{
			base.OnUpdate(shotType);
			Vector3 target = GetTarget(shotType);
			Vector3 vector = shotType.ShotCamera.transform.TransformPoint(m_RelativeTo.PointA);
			Vector3 vector2 = shotType.ShotCamera.transform.TransformPoint(m_RelativeTo.PointB);
			Vector3 vector3 = target - vector;
			Vector3 vector4 = vector2 - vector;
			Vector3 lhs = Vector3.Project(vector3, vector4);
			float num = Mathf.Sign(Vector3.Dot(lhs, vector4));
			float t = lhs.magnitude / vector4.magnitude * num;
			Vector3 position = m_Track.Get(t);
			shotType.Position = shotType.ShotCamera.transform.TransformPoint(position);
		}

		private Vector3 GetTarget(TShotType shotType)
		{
			GameObject gameObject = m_Target.Get(shotType.ShotCamera);
			Vector3 obj = ((gameObject != null) ? gameObject.transform.position : Vector3.zero);
			Vector3 vector = ((gameObject != null) ? m_Offset.Get(gameObject) : Vector3.zero);
			return obj + vector;
		}

		public override void OnDrawGizmosSelected(TShotType shotType, Transform transform)
		{
			base.OnDrawGizmosSelected(shotType, transform);
			DoDrawGizmos(shotType, TShotSystem.GIZMOS_COLOR_ACTIVE);
		}

		private void DoDrawGizmos(TShotType shotType, Color color)
		{
			Gizmos.color = color;
			m_RelativeTo.DrawGizmos(shotType.ShotCamera.transform);
			m_Track.DrawGizmos(shotType.ShotCamera.transform);
		}
	}
}
