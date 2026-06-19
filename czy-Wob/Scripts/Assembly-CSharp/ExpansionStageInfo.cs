using System;
using UnityEngine;

[Serializable]
public class ExpansionStageInfo
{
	public GameObject mainObject;

	public Transform expansionTransform;

	public Transform newNestTargetTransform;

	public Transform newBedroomTargetTransform;

	public Transform newRitualTargetTransform;

	public GameObject colliderToTurnOff;

	public GameObject wallGeometry;

	public GameObject floorCeilingCollisions;

	public int additionalCapacity;

	public bool finalExpansionForRoom;
}
