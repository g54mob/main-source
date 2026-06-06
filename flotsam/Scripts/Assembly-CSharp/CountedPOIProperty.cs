using System;
using UnityEngine;

[Serializable]
public class CountedPOIProperty
{
	[Tooltip("Amount of the item property.")]
	public int Amount;

	[Tooltip("Item property to keep count of.")]
	public PointOfInterestProperties POIProperties;
}
