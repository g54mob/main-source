using Aggro.Core;
using Aggro.Core.Networking;
using Unity.Mathematics;
using UnityEngine;

public class RadialForce : NetworkEntityBehaviourBase
{
	public enum ForceType
	{
		Inwards = 0,
		Outwards = 1
	}

	public ForceType forceType;

	[Min(0f)]
	public float forceAmount = 20f;

	[Min(0f)]
	public float radius = 5f;

	public EasingFunction.Ease forceEase = EasingFunction.Ease.EaseOutQuad;

	public bool destroyNearbyBoxes = true;

	[Min(0f)]
	public float destroyDistance = 1f;

	private static Collider[] _colliders = new Collider[128];

	private bool showDestroyDistance
	{
		get
		{
			if (forceType == ForceType.Inwards)
			{
				return destroyNearbyBoxes;
			}
			return false;
		}
	}

	protected override void OnUpdateSimulationEarly()
	{
		if (GameUtil.TryGetLocalPlayer(out var player) && player.TryGetObject<PlayerEffects>(out var obj))
		{
			Vector3 position = player.transform.position;
			Vector3 position2 = base.entity.transform.position;
			if (math.distancesq(position, position2) < radius * radius)
			{
				float num = math.distance(position, position2);
				float num2 = EasingFunction.Evaluate(forceEase, forceAmount, 0f, math.saturate(num / radius));
				Vector3 vector = forceType switch
				{
					ForceType.Inwards => position2 - position, 
					ForceType.Outwards => position - position2, 
					_ => throw new InvalidEnumException(), 
				};
				vector /= num;
				obj.AddForce(vector * num2);
			}
		}
	}

	protected override void OnUpdateSimulation()
	{
		Vector3 position = base.entity.transform.position;
		int num = Physics.OverlapSphereNonAlloc(position, radius, _colliders, 16384);
		switch (forceType)
		{
		case ForceType.Inwards:
		{
			for (int j = 0; j < num; j++)
			{
				if (!_colliders[j].TryGetEntity(out var entity2) || !(entity2 != base.entity))
				{
					continue;
				}
				Vector3 position2 = entity2.transform.position;
				if (destroyNearbyBoxes && math.distancesq(position, position2) <= destroyDistance * destroyDistance)
				{
					if (base.isServer && !EntityUtil.IsMarkedForDeath(entity2))
					{
						EntityUtil.Destroy(entity2);
					}
					continue;
				}
				Vector3 vector2 = position - position2;
				float magnitude2 = vector2.magnitude;
				vector2 /= magnitude2;
				float num3 = EasingFunction.Evaluate(forceEase, forceAmount, 0f, math.saturate(magnitude2 / radius));
				entity2.rigidbody.AddForce(vector2 * num3, ForceMode.Force);
				if (base.isServer)
				{
					if (entity2.TryGetObject<BoxWander>(out var obj3))
					{
						obj3.ServerStopWander();
					}
					if (entity2.TryGetObject<BoxCharge>(out var obj4))
					{
						obj4.ServerStopCharging();
					}
				}
			}
			break;
		}
		case ForceType.Outwards:
		{
			for (int i = 0; i < num; i++)
			{
				if (!_colliders[i].TryGetEntity(out var entity) || !(entity != base.entity))
				{
					continue;
				}
				Vector3 vector = entity.transform.position - position;
				float magnitude = vector.magnitude;
				vector /= magnitude;
				float num2 = EasingFunction.Evaluate(forceEase, forceAmount, 0f, math.saturate(magnitude / radius));
				entity.rigidbody.AddForce(vector * num2, ForceMode.Force);
				if (base.isServer)
				{
					if (entity.TryGetObject<BoxWander>(out var obj))
					{
						obj.ServerStopWander();
					}
					if (entity.TryGetObject<BoxCharge>(out var obj2))
					{
						obj2.ServerStopCharging();
					}
				}
			}
			break;
		}
		default:
			throw new InvalidEnumException();
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(base.transform.position, radius);
	}

	public override bool Weaved()
	{
		return true;
	}
}
