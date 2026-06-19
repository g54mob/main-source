using System.Collections.Generic;
using Aggro.Core;
using Aggro.Core.Networking;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class NavAreaManager : AggroManagerBase<NavAreaManager>
{
	private struct BoxFixComp : IEntityStruct, IEntityTyped
	{
		public Timer timer;

		public bool verified;
	}

	[Header("Box Fix")]
	[Min(0f)]
	public float boxFixWaitDuration = 3f;

	[Min(0f)]
	public float boxFixDistanceCheck = 2.75f;

	public GameObject poofVFX;

	private const float VELOCITY_SPEED_SQR = 0.010000001f;

	private const float POSITION_DIST_SQR = 0.010000001f;

	private bool _debugFixed;

	private Vector3 _debugPos;

	private Quaternion _debugRot;

	private static List<Entity> _entities = new List<Entity>();

	public Vector3 debugFixPos => _debugPos;

	protected override void OnUpdateSimulation()
	{
		if (!base.isServer)
		{
			return;
		}
		_entities.Clear();
		base.entityManager.GetAllEntitiesWith<Grabbable>(_entities);
		for (int i = 0; i < _entities.Count; i++)
		{
			Entity entity = _entities[i];
			if (!entity.TryGetStruct<EntityContextComp>(out var comp) || comp.roomType != RoomType.Warehouse)
			{
				continue;
			}
			BoxFixComp comp2;
			if (entity.rigidbody.velocity.sqrMagnitude >= 0.010000001f || entity.rigidbody.isKinematic || entity.GetObject<Grabbable>().isInStackAndNotBase || entity.GetObject<BoxProps>().serverIsSafe)
			{
				entity.TryGetStruct<BoxFixComp>(out comp2);
				comp2.verified = false;
				comp2.timer.SetTimer(boxFixWaitDuration);
			}
			else
			{
				if (!entity.TryGetStruct<BoxFixComp>(out comp2))
				{
					comp2.timer.SetTimer(boxFixWaitDuration);
				}
				if (!comp2.verified)
				{
					comp2.timer.DecrementTimer();
					if (comp2.timer.IsFinished())
					{
						comp2.verified = true;
						Vector3 position = entity.transform.position;
						_ = entity.transform.rotation.eulerAngles;
						if (!NavMesh.SamplePosition(position, out var hit, boxFixDistanceCheck * 10f, -1))
						{
							_debugFixed = true;
							_debugPos = position;
							_debugRot = entity.transform.rotation;
							EntityUtil.Destroy(entity);
							continue;
						}
						bool flag = Physics.Raycast(position, Vector3.down, position.y + 1f, 2049);
						if (!flag)
						{
							Vector3 vector = position;
							vector.y = 0f;
							Vector3 position2 = hit.position;
							position2.y = 0f;
							flag = math.distancesq(vector, position2) >= 0.010000001f;
						}
						if (flag && math.distancesq(hit.position, position) > boxFixDistanceCheck * boxFixDistanceCheck)
						{
							_debugFixed = true;
							_debugPos = position;
							_debugRot = entity.transform.rotation;
							entity.GetObject<Grabbable>().ServerFixStack(hit.position + Vector3.up * 0.5f, entity.transform.rotation);
							NetworkAggroManagerBase<VFXManager>.instance.Play(poofVFX, position);
							NetworkAggroManagerBase<VFXManager>.instance.Play(poofVFX, hit.position);
						}
					}
				}
			}
			entity.SetOrAddStruct(comp2);
		}
	}

	private void OnDrawGizmos()
	{
		if (_debugFixed)
		{
			Gizmos.matrix = Matrix4x4.TRS(_debugPos, _debugRot, Vector3.one);
			Gizmos.color = Color.red;
			Gizmos.DrawCube(Vector3.zero, Vector3.one);
		}
	}
}
