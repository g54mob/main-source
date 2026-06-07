using System;
using System.Linq;
using UnityEngine;

public class TrainCarExplosion : MonoBehaviour
{
	public float DERAIL_FORCE_THRESHOLD = 100000f;

	public Transform positionDebug;

	public float forceDebug;

	public float radiusDebug;

	public float upwardsModifierDebug;

	private const float EXPLOSION_DAMAGE_MODIFIER = 500f;

	[InspectorButton("CreateExplosionDebug", true, true)]
	public bool debugExplosion;

	public static event Action<Vector3, float> PlayerInExplosion;

	public void CreateExplosionDebug()
	{
		CreateExplosion(forceDebug, positionDebug.position, radiusDebug, upwardsModifierDebug, DERAIL_FORCE_THRESHOLD);
	}

	public static void CreateExplosion(float force, Vector3 explosionPosition, float radius, float upwardsForceModifier, float derailThreshold)
	{
		ApplyExplosionForceToTrains(force, explosionPosition, radius, upwardsForceModifier, derailThreshold);
		ApplyExplosionForceToPlayer(explosionPosition, radius);
	}

	private static void ApplyExplosionForceToTrains(float force, Vector3 explosionPosition, float radius, float upwardsForceModifier, float derailThreshold)
	{
		foreach (TrainCar item in (from col in Physics.OverlapSphere(explosionPosition, radius, LayerMask.GetMask("Train_Big_Collider"))
			select col.GetComponentInParent<TrainCar>() into n
			where n != null
			select n).Distinct().ToList())
		{
			Vector3 vector = item.transform.position - explosionPosition;
			float magnitude = vector.magnitude;
			float num = (1f - magnitude / radius) * force;
			item.stress.EnableStress(set: true);
			TrainCarCollisions trainCarCollisions = item.TrainCarCollisions;
			if (trainCarCollisions != null)
			{
				trainCarCollisions.ApplyExplosionForceAndDamage(num * 500f, vector.normalized);
			}
			if (num > derailThreshold)
			{
				item.DerailAllBogies("Explosion", suppressDerailSound: true);
			}
			item.rb.AddExplosionForce(force, explosionPosition, radius, upwardsForceModifier);
			item.rb.AddTorque(UnityEngine.Random.insideUnitSphere * num * 0.5f);
		}
	}

	private static void ApplyExplosionForceToPlayer(Vector3 explosionPosition, float radius)
	{
		Vector3 arg = PlayerManager.PlayerTransform.position - explosionPosition;
		float magnitude = arg.magnitude;
		if (!(magnitude > radius))
		{
			arg.Normalize();
			float arg2 = 1f - magnitude / radius;
			TrainCarExplosion.PlayerInExplosion?.Invoke(arg, arg2);
		}
	}

	public static void UpdateModelToExploded(TrainCar trainCar)
	{
		if (!(trainCar == null))
		{
			if (trainCar.PaintExterior != null)
			{
				trainCar.PaintExterior.enabled = false;
			}
			if (trainCar.PaintInterior != null)
			{
				trainCar.PaintInterior.enabled = false;
			}
			bool isExploded = trainCar.isExploded;
			trainCar.GetComponent<ExplosionModelHandler>()?.HandleExplosionModelChange();
			trainCar.GetComponent<CargoModelController>()?.CargoExplosion();
			trainCar.isExploded = true;
			if (!isExploded)
			{
				trainCar.RefreshLoadedPrefabsExplodedState();
			}
		}
	}

	public static void RevertModelToUnexploded(TrainCar trainCar)
	{
		if (!(trainCar == null))
		{
			bool isExploded = trainCar.isExploded;
			trainCar.GetComponent<ExplosionModelHandler>()?.RevertToUnexplodedModel();
			trainCar.isExploded = false;
			if (isExploded)
			{
				trainCar.RefreshLoadedPrefabsExplodedState();
			}
			if (trainCar.PaintExterior != null)
			{
				trainCar.PaintExterior.enabled = true;
			}
			if (trainCar.PaintInterior != null)
			{
				trainCar.PaintInterior.enabled = true;
			}
		}
	}
}
