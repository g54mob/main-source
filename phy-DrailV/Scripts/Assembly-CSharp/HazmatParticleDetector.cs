using System.Collections.Generic;
using DV.Utils;
using UnityEngine;

public class HazmatParticleDetector : MonoBehaviour
{
	public List<ParticleCollisionEvent> particleCollisionEvents = new List<ParticleCollisionEvent>();

	private Dictionary<GameObject, ICargoLeak> leakData = new Dictionary<GameObject, ICargoLeak>();

	private void OnParticleCollision(GameObject other)
	{
		if (!leakData.ContainsKey(other))
		{
			ICargoLeak componentInParent = other.GetComponentInParent<ICargoLeak>();
			leakData.Add(other, componentInParent);
		}
		if (other.GetComponent<ParticleSystem>().GetCollisionEvents(base.gameObject, particleCollisionEvents) > 0)
		{
			Vector3 intersection = particleCollisionEvents[0].intersection;
			SingletonBehaviour<HazmatTileManager>.Instance.UpdateTileLiquidToBeAddedDictionary(intersection, leakData[other].LeakDelta(), leakData[other].GetCargoType());
		}
	}
}
