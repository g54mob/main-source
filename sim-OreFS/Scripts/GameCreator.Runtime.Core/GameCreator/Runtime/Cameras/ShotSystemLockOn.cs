using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	[Serializable]
	public class ShotSystemLockOn : TShotSystem
	{
		public static readonly int ID = "ShotSystemLockOn".GetHashCode();

		[SerializeField]
		private PropertyGetGameObject m_Anchor = GetGameObjectPlayer.Create();

		[SerializeField]
		private PropertyGetDirection m_AnchorOffset = GetDirectionLocalValue.CreateSelf(new Vector3(0f, 0.25f, -1f));

		[SerializeField]
		private PropertyGetDecimal m_Distance = GetDecimalDecimal.Create(5f);

		[NonSerialized]
		private Vector3 m_AnchorPosition = Vector3.zero;

		[NonSerialized]
		private float m_Radius;

		public override int Id => ID;

		public GameObject Anchor
		{
			set
			{
				m_Anchor = GetGameObjectInstance.Create(value);
			}
		}

		public Vector3 Offset
		{
			set
			{
				m_AnchorOffset = GetDirectionLocalValue.CreateSelf(value);
			}
		}

		public float Distance
		{
			set
			{
				m_Distance = GetDecimalDecimal.Create(value);
			}
		}

		public Transform GetAnchorTarget(TShotType shotType)
		{
			GameObject gameObject = m_Anchor.Get(shotType.Args);
			if (!(gameObject != null))
			{
				return null;
			}
			return gameObject.transform;
		}

		public void SyncWithZoom(Args args, ShotSystemZoom zoom)
		{
			float num = (float)m_Distance.Get(args);
			float num2 = Mathf.Max(0f, num - zoom.MinDistance);
			m_Radius = zoom.MinDistance + num2 * zoom.Level;
		}

		public override void OnUpdate(TShotType shotType)
		{
			base.OnUpdate(shotType);
			Vector3 targetPosition = GetTargetPosition(shotType as TShotTypeLook);
			Vector3 anchorPosition = GetAnchorPosition(shotType);
			Vector3 anchorOffset = GetAnchorOffset(shotType);
			Vector3 vector = anchorPosition - (targetPosition - anchorPosition).normalized * m_Radius;
			m_AnchorPosition = anchorPosition + anchorOffset;
			shotType.Position = vector + anchorOffset;
		}

		public override void OnDrawGizmosSelected(TShotType shotType, Transform transform)
		{
			base.OnDrawGizmosSelected(shotType, transform);
			DoDrawGizmos(shotType as TShotTypeLook, TShotSystem.GIZMOS_COLOR_ACTIVE);
		}

		private float GetRotationDamp(float current, float target, ref float velocity, float smoothTime, float deltaTime)
		{
			if (deltaTime <= float.Epsilon)
			{
				return current;
			}
			return Mathf.SmoothDampAngle(current, target, ref velocity, smoothTime, float.PositiveInfinity, deltaTime);
		}

		private Vector3 GetTargetPosition(TShotTypeLook shotType)
		{
			return shotType.Look.GetLookPosition(shotType);
		}

		private Vector3 GetAnchorPosition(TShotType shotType)
		{
			Transform transform = m_Anchor.Get<Transform>(shotType.Args);
			if (!(transform != null))
			{
				return m_AnchorPosition;
			}
			return transform.position;
		}

		private Vector3 GetAnchorOffset(TShotType shotType)
		{
			return m_AnchorOffset.Get(shotType.Args);
		}

		private void DoDrawGizmos(TShotTypeLook shotType, Color color)
		{
			if (Application.isPlaying)
			{
				Gizmos.color = color;
				Vector3 targetPosition = GetTargetPosition(shotType);
				Vector3 anchorPosition = GetAnchorPosition(shotType);
				Gizmos.DrawSphere(targetPosition, 0.05f);
				Gizmos.DrawSphere(anchorPosition, 0.1f);
				Gizmos.DrawLine(targetPosition, anchorPosition);
				Gizmos.DrawLine(anchorPosition, shotType.Position);
			}
		}
	}
}
