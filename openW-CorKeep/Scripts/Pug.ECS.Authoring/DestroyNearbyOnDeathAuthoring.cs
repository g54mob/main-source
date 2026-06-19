using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DestroyNearbyOnDeathAuthoring : MonoBehaviour
{
	public float radius;

	[FormerlySerializedAs("Values")]
	public List<ObjectID> objectsToDestroy;

	public bool killAnyTemporaryEnemy;

	public bool destroyEntitiesWithDontDestroyOnZeroHealthCD;
}
