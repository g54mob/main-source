using Aggro.Core;
using Aggro.Core.Networking;
using Unity.Mathematics;
using UnityEngine;

public class Pollen : NetworkEntityBehaviourBase
{
	[Min(0f)]
	public float pollenRadius = 4f;

	[Min(0f)]
	public float forceDrag = 1f;

	[Header("Wander")]
	[Min(0f)]
	public float wanderSpeed = 1f;

	[Min(0f)]
	public float wanderMaxRadius = 8f;

	[Min(0f)]
	public float wanderCircleAhead = 4f;

	[Min(0f)]
	public float wanderCircleRadius = 2f;

	private Vector3 _serverRootPos;

	private Vector3 _serverWanderDir;

	private Vector3 _serverForceVelocity;

	protected override void OnEntityStart()
	{
		if (base.isServer)
		{
			Vector3 position = base.entity.transform.position;
			position.y = 0f;
			base.entity.transform.position = position;
			_serverRootPos = position;
			_serverWanderDir = GetRandom().NextFloat3Direction();
			_serverWanderDir.y = 0f;
			_serverWanderDir.Normalize();
		}
	}

	protected override void OnUpdateSimulation()
	{
		if (base.isServer)
		{
			Vector3 position = base.entity.transform.position;
			Vector3 vector = position + _serverWanderDir * wanderCircleAhead;
			Vector3 vector2 = vector - _serverRootPos;
			float num = wanderMaxRadius - wanderCircleRadius;
			if (vector2.sqrMagnitude > num * num)
			{
				vector = _serverRootPos + vector2.normalized * num;
			}
			Unity.Mathematics.Random random = GetRandom();
			Vector3 vector3 = vector + new Vector3(random.NextFloat(-1f, 1f), 0f, random.NextFloat(-1f, 1f)).normalized * wanderCircleRadius;
			_serverWanderDir = (vector3 - position).normalized;
			Vector3 position2 = base.entity.transform.position;
			position2 += _serverWanderDir * (wanderSpeed * (1f / 60f));
			position2 += _serverForceVelocity * (1f / 60f);
			position2.y = 0f;
			base.entity.transform.position = position2;
			_serverForceVelocity = PhysicsUtil.ApplyDrag(_serverForceVelocity, forceDrag);
		}
	}

	public void AddForce(Vector3 force)
	{
		_serverForceVelocity += PhysicsUtil.GetForceVelocity(force, 1f, ForceMode.Force);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.matrix = Matrix4x4.Scale(new Vector3(1f, 0f, 1f));
		if (!Application.isPlaying)
		{
			Gizmos.color = Color.cyan;
			Gizmos.DrawWireSphere(base.transform.position, wanderMaxRadius);
			Gizmos.color = Color.blue;
			Gizmos.DrawWireSphere(base.transform.position + Vector3.right * wanderCircleAhead, wanderCircleRadius);
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(base.transform.position, pollenRadius);
		}
		else if (GameUtil.isReady && base.isServer)
		{
			Gizmos.color = Color.cyan;
			Gizmos.DrawWireSphere(_serverRootPos, wanderMaxRadius);
			Gizmos.color = Color.blue;
			Gizmos.DrawWireSphere(base.transform.position + _serverWanderDir * wanderCircleAhead, wanderCircleRadius);
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(base.transform.position, pollenRadius);
		}
	}

	public override bool Weaved()
	{
		return true;
	}
}
