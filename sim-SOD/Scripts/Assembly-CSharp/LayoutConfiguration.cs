using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "layoutconfig_data", menuName = "Database/Decor/Layout Configuration")]
public class LayoutConfiguration : SoCustomComparison
{
	[Header("Zoning")]
	public bool assignPurpose;

	[DisableIf("assignPurpose")]
	public AddressPreset addressPreset;

	[Space(7f)]
	public bool publicFacing;

	public bool isOutside;

	public bool isLobby;

	[Header("Room Configuration")]
	public List<RoomTypePreset> roomLayout;

	[Tooltip("This room may require an internal hallway to connect far rooms")]
	public bool requiresHallway;

	public RoomConfiguration hallway;

	[Tooltip("How far away a room is from the entrance to place a hallway (nodes).")]
	public int hallwayDistanceThreshold;

	[Tooltip("Use the building's default design style")]
	public bool useBuildingDesignStyle;

	[Header("Interface")]
	public bool overrideEvidencePhotoSettings;

	[EnableIf("overrideEvidencePhotoSettings")]
	public Vector3 relativeCamPhotoPos;

	[EnableIf("overrideEvidencePhotoSettings")]
	public Vector3 relativeCamPhotoEuler;

	[Header("Doorways")]
	public List<DoorPairPreset> doorwaysNormal;

	public List<DoorPairPreset> doorwaysFlat;

	public List<DoorPairPreset> roomDividersLeft;

	public List<DoorPairPreset> roomDividersCentre;

	public List<DoorPairPreset> roomDividersRight;
}
