using UnityEngine;

[CreateAssetMenu(fileName = "residence_data", menuName = "Database/Residence Preset")]
public class ResidencePreset : SoCustomComparison
{
	[Header("Settings")]
	[Tooltip("Are NPCs allowed to live here?")]
	public bool habitable;

	[Tooltip("Is this residence automatically put up for sale?")]
	public bool enableForSale;

	[Tooltip("Furnish this room even if uninhabited")]
	public bool furnitureIfUnihabited;

	[Tooltip("Is this a hotel room that the player can go to when they rent a room?")]
	public bool isHotelRoom;
}
