using Pug.Conversion;
using UnityEngine;

public class OccupiableConverter : SingleAuthoringComponentConverter<OccupiableAuthoring>
{
	protected override void Convert(OccupiableAuthoring occupiableAuthoring)
	{
		if (occupiableAuthoring.occupiableSlots.Count != 1)
		{
			Debug.LogError("Non supported number of occupiable slots in: " + occupiableAuthoring.gameObject.name);
			return;
		}
		OccupiableAuthoring.OccupiableSlot occupiableSlot = occupiableAuthoring.occupiableSlots[0];
		AddComponentData(new OccupiableCD
		{
			occupyOffsetForward = occupiableSlot.offsetForward,
			occupyOffsetRight = occupiableSlot.offsetRight,
			occupyOffsetBack = occupiableSlot.offsetBack,
			occupyOffsetLeft = occupiableSlot.offsetLeft
		});
	}
}
