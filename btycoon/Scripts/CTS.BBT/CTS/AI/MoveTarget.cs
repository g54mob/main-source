using System;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Pooling;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS.AI
{
	public class MoveTarget : CTSBehaviour, IPoolable, IPoolCallbackReceiver
	{
		[Inject(false)]
		private SphereCollider _collider;

		[Inject(false)]
		private PathLocker _locker;

		private static readonly NamedLayerMask PhysicsMask = new NamedLayerMask("Customer", "Worker", "InterractionZone");

		private static readonly Resource<MoveTarget> MoveTargetPrefab = new Resource<MoveTarget>("pfb_MoveTarget");

		[field: SerializeField]
		public AgentPath.EDestinationType DestinationType { get; set; }

		[field: SerializeField]
		public float maxDistance { get; set; } = 1f;

		public Agent User { get; private set; }

		public Vector3 Position => base.transform.position;

		public Quaternion Rotation => base.transform.rotation;

		public bool IsPathable
		{
			get
			{
				if (!(_locker == null))
				{
					return _locker.IsPathable;
				}
				return true;
			}
		}

		public PoolGuid PoolingGuid { get; private set; }

		public static Func<MoveTarget, bool> Available { get; } = (MoveTarget target) => !target.User && target.IsPathable;

		PoolGuid IPoolable.PoolGuid
		{
			get
			{
				return PoolingGuid;
			}
			set
			{
				PoolingGuid = value;
			}
		}

		public void SetUser(Agent user)
		{
			if (!(User == user))
			{
				User = user;
			}
		}

		public bool IsAvailable(Agent agent)
		{
			if ((bool)User && User != agent)
			{
				return false;
			}
			Collider[] array = PhysicsAllocation.Get(4);
			bool flag = agent.Selection.Collider.enabled;
			agent.Selection.Collider.enabled = false;
			int num = _collider.OverlapNonAlloc(array, PhysicsMask, QueryTriggerInteraction.Collide);
			agent.Selection.Collider.enabled = flag;
			if (num <= 0)
			{
				return true;
			}
			for (int i = 0; i < num; i++)
			{
				if (array[i].TryGetComponent<MoveTarget>(out var component))
				{
					if ((bool)component.User)
					{
						return false;
					}
					continue;
				}
				return false;
			}
			return true;
		}

		public static bool IsPositionAvailable(Vector3 pos)
		{
			Collider[] array = PhysicsAllocation.Get(4);
			int num = Physics.OverlapSphereNonAlloc(pos, 0.2f, array, PhysicsMask, QueryTriggerInteraction.Collide);
			if (num <= 0)
			{
				return true;
			}
			for (int i = 0; i < num; i++)
			{
				if (array[i].TryGetComponent<MoveTarget>(out var component))
				{
					if ((bool)component.User)
					{
						return false;
					}
					continue;
				}
				return false;
			}
			return true;
		}

		public static MoveTarget CreateNew(Vector3 p_position, Quaternion p_rotation, AgentPath.EDestinationType p_destinationType)
		{
			MoveTarget moveTarget = Pooler.Pull(MoveTargetPrefab.Value, active: true);
			moveTarget.transform.SetPositionAndRotation(p_position, p_rotation);
			moveTarget.transform.SetParent(null);
			moveTarget.DestinationType = p_destinationType;
			return moveTarget;
		}

		public static MoveTarget CreateNew(Transform p_transform, AgentPath.EDestinationType p_destinationType)
		{
			MoveTarget moveTarget = CreateNew(p_transform.position, p_transform.rotation, p_destinationType);
			moveTarget.transform.SetParent(p_transform);
			return moveTarget;
		}

		public static void Clear(ref MoveTarget moveTarget)
		{
			if ((bool)moveTarget && !CTSSceneManager.BeingDestroyed)
			{
				Pooler.Push(moveTarget);
				moveTarget.DestinationType = AgentPath.EDestinationType.Simple;
				moveTarget.maxDistance = 1f;
				moveTarget.transform.SetParent(null);
				moveTarget = null;
			}
		}

		void IPoolCallbackReceiver.OnPulled()
		{
		}

		void IPoolCallbackReceiver.OnPushed()
		{
			User = null;
		}
	}
}
