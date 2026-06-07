using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	[Serializable]
	public class ShotSystemAnchor : TShotSystem
	{
		public static readonly int ID = "ShotSystemAnchor".GetHashCode();

		[SerializeField]
		private PropertyGetGameObject m_Target = GetGameObjectPlayer.Create();

		[SerializeField]
		private PropertyGetDirection m_Offset = GetDirectionLocalValue.CreateTarget();

		[SerializeField]
		private PropertyGetDirection m_Distance = GetDirectionLocalValue.CreateTarget(new Vector3(0f, 0f, -3f));

		public override int Id => ID;

		public GameObject Target
		{
			set
			{
				m_Target = GetGameObjectInstance.Create(value);
			}
		}

		public Vector3 Offset
		{
			set
			{
				m_Offset = GetDirectionLocalValue.CreateTarget(value);
			}
		}

		public Vector3 Distance
		{
			set
			{
				m_Distance = GetDirectionLocalValue.CreateTarget(value);
			}
		}

		public override void OnUpdate(TShotType shotType)
		{
			base.OnUpdate(shotType);
			Vector3 targetPosition = GetTargetPosition(shotType);
			Vector3 anchorPosition = GetAnchorPosition(shotType);
			Vector3 forward = targetPosition - anchorPosition;
			shotType.Position = anchorPosition;
			shotType.Rotation = Quaternion.LookRotation(forward);
		}

		public Transform GetTargetTransform(IShotType shotType)
		{
			GameObject gameObject = m_Target.Get(shotType.ShotCamera);
			if (!(gameObject != null))
			{
				return null;
			}
			return gameObject.transform;
		}

		public Vector3 GetTargetPosition(IShotType shotType)
		{
			Transform targetTransform = GetTargetTransform(shotType);
			Vector3 vector = ((targetTransform != null) ? m_Offset.Get(targetTransform) : shotType.ShotCamera.transform.TransformPoint(Vector3.forward));
			if (!(targetTransform != null))
			{
				return default(Vector3);
			}
			return targetTransform.position + vector;
		}

		private Vector3 GetAnchorPosition(TShotType shotType)
		{
			Transform targetTransform = GetTargetTransform(shotType);
			if (targetTransform == null)
			{
				return shotType.Position;
			}
			Vector3 vector = m_Distance.Get(shotType.Args);
			return targetTransform.transform.position + vector;
		}

		public override void OnDrawGizmosSelected(TShotType shotType, Transform transform)
		{
			base.OnDrawGizmosSelected(shotType, transform);
			DoDrawGizmos(shotType, TShotSystem.GIZMOS_COLOR_ACTIVE);
		}

		private void DoDrawGizmos(TShotType shotType, Color color)
		{
			if (Application.isPlaying)
			{
				Gizmos.color = color;
				Vector3 targetPosition = GetTargetPosition(shotType);
				Gizmos.DrawLine(GetAnchorPosition(shotType), targetPosition);
			}
		}
	}
}
