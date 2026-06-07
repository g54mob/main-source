using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	[Serializable]
	public class ShotSystemLook : TShotSystem
	{
		public static readonly int ID = "ShotSystemLook".GetHashCode();

		protected static readonly Vector3 GIZMO_SIZE_CUBE = Vector3.one * 0.1f;

		[SerializeField]
		private bool m_IsActive = true;

		[SerializeField]
		private PropertyGetGameObject m_LookTarget = GetGameObjectPlayer.Create();

		[SerializeField]
		private PropertyGetDirection m_LookOffset = GetDirectionVector3Zero.Create();

		public override int Id => ID;

		public bool IsActive
		{
			get
			{
				return m_IsActive;
			}
			set
			{
				m_IsActive = value;
			}
		}

		public GameObject Target
		{
			set
			{
				m_LookTarget = GetGameObjectInstance.Create(value);
			}
		}

		public Vector3 Offset
		{
			set
			{
				m_LookOffset = GetDirectionLocalValue.CreateSelf(value);
			}
		}

		public ShotSystemLook()
		{
		}

		public ShotSystemLook(PropertyGetGameObject target, PropertyGetDirection offset)
			: this()
		{
			m_LookTarget = target;
			m_LookOffset = offset;
		}

		public Transform GetLookTarget(IShotType shotType)
		{
			if (!m_IsActive)
			{
				return null;
			}
			GameObject gameObject = m_LookTarget.Get(shotType.ShotCamera);
			if (!(gameObject != null))
			{
				return null;
			}
			return gameObject.transform;
		}

		public Vector3 GetLookPosition(IShotType shotType)
		{
			Transform lookTarget = GetLookTarget(shotType);
			if (!(lookTarget != null))
			{
				return default(Vector3);
			}
			return lookTarget.position + GetLookOffset(shotType);
		}

		public override void OnUpdate(TShotType shotType)
		{
			base.OnUpdate(shotType);
			if (m_IsActive)
			{
				Transform lookTarget = GetLookTarget(shotType);
				if (!(lookTarget == null) && !(lookTarget == shotType.ShotCamera.transform))
				{
					Vector3 forward = GetLookPosition(shotType) - shotType.Position;
					shotType.Rotation = Quaternion.LookRotation(forward);
				}
			}
		}

		public override void OnDrawGizmosSelected(TShotType shotType, Transform transform)
		{
			base.OnDrawGizmosSelected(shotType, transform);
			DoDrawGizmos(shotType, TShotSystem.GIZMOS_COLOR_ACTIVE);
		}

		private Vector3 GetLookOffset(IShotType shotType)
		{
			Transform lookTarget = GetLookTarget(shotType);
			if (!(lookTarget != null))
			{
				return default(Vector3);
			}
			return m_LookOffset.Get(lookTarget);
		}

		private void DoDrawGizmos(TShotType shotType, Color color)
		{
			if (!Application.isPlaying)
			{
				return;
			}
			Gizmos.color = color;
			if (m_IsActive)
			{
				Transform lookTarget = GetLookTarget(shotType);
				if (!(lookTarget == null) && !(lookTarget.position == shotType.Position))
				{
					Vector3 lookPosition = GetLookPosition(shotType);
					Gizmos.DrawWireCube(lookPosition, GIZMO_SIZE_CUBE);
					Gizmos.DrawLine(shotType.Position, lookPosition);
				}
			}
		}
	}
}
