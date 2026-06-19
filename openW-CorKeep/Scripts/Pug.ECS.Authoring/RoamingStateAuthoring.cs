using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(RoamingPathAuthoring))]
public class RoamingStateAuthoring : MonoBehaviour
{
	public float tileDamageRadius;

	public float distanceInfrontToDamageTiles;

	public List<ObjectID> cantHitSpecificObjects;
}
