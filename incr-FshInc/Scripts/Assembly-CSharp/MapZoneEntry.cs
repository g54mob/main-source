using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class MapZoneEntry
{
	public string name;

	public Button mapButton;

	public ZoneData zoneData;

	[Header("Map Visuals")]
	[Tooltip("The Image component on the map button that shows the zone icon.")]
	public Image mapIconImage;

	[Tooltip("The Text component on the map button that shows the unlock price.")]
	public TMP_Text priceText;

	[Tooltip("Optional: A lock icon object to show only when locked.")]
	public GameObject lockedIconObject;

	public TMP_Text pondNameText;
}
