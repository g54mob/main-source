using Pug.Conversion;
using Unity.Collections;
using UnityEngine;

public class RoamingStateConverter : SingleAuthoringComponentConverter<RoamingStateAuthoring>
{
	protected override void Convert(RoamingStateAuthoring authoring)
	{
		FixedList32Bytes<ObjectID> cantHitSpecificObjects = default(FixedList32Bytes<ObjectID>);
		if (authoring.cantHitSpecificObjects.Count > cantHitSpecificObjects.Capacity)
		{
			Debug.LogError("RoamingStateAuthoring.cantHitSpecificObjects has more elements than supported FixedList32Bytes capacity.", authoring.gameObject);
		}
		foreach (ObjectID cantHitSpecificObject in authoring.cantHitSpecificObjects)
		{
			cantHitSpecificObjects.Add(cantHitSpecificObject);
		}
		AddComponentData(new RoamingStateCD
		{
			tileDamageRadius = authoring.tileDamageRadius,
			distanceInfrontToDamageTiles = authoring.distanceInfrontToDamageTiles,
			cantHitSpecificObjects = cantHitSpecificObjects
		});
	}
}
