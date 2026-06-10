using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "roomtype_data", menuName = "Database/Room Type Preset")]
public class RoomTypePreset : SoCustomComparison
{
	[Header("Contents")]
	public RoomConfiguration forceConfiguration;

	[Tooltip("Chance this has of being included")]
	[Range(0f, 1f)]
	[Header("Size Settings")]
	public float chance;

	[Tooltip("The address has to be this big for this rooom to be included")]
	[Range(0f, 90f)]
	public int minimumAddressSize;

	[Tooltip("Maximum number of these room types per addresses")]
	[Range(1f, 10f)]
	public int maximumRoomTypesPerAddress;

	[Space(7f)]
	[Tooltip("The priority given to this room: Higher priority rooms will override size variables of others.")]
	[Range(0f, 10f)]
	public int cyclePriority;

	[Header("Room Shape Settings")]
	[Tooltip("The room at it's smallest must be able to fit this shape inside it.")]
	public Vector2 minimumRoomAreaShape;

	[Tooltip("The room at it's largest can feature this shape.")]
	public Vector2 maximumRoomAreaShape;

	[Tooltip("All nodes in the room must tesselate with this shape.")]
	public Vector2 tesselationShape;

	[Header("Room Placement Weighting")]
	[Range(-3f, 3f)]
	public int floorSpaceWeight;

	[Range(-3f, 3f)]
	public int exteriorWallWeight;

	[Range(-3f, 3f)]
	public int exteriorWindowWeight;

	[Range(-3f, 3f)]
	public int entranceWeight;

	[Tooltip("This must adjoin one of these rooms. If none adjoin all.")]
	[ReorderableList]
	[Header("Adjoining Rules")]
	public List<RoomTypePreset> mustAdjoinRooms;

	[Tooltip("Should I feature doors from this preset or the bordering preset? Choose the highest priority")]
	[Range(0f, 10f)]
	public int doorPriority;

	[Tooltip("Chance of doorway not featuring a door")]
	[Range(0f, 1f)]
	public float chanceOfNoDoor;

	[Tooltip("Maximum number of doors")]
	public int maxDoors;

	public bool forceNoDoors;

	[Tooltip("Doors will use the 'highest' privacy setting between the 2 rooms")]
	public NewDoor.DoorSetting doorSetting;

	[Tooltip("Entrances to this room can be replaced by a divider if there are 2 or more adjoining walls")]
	public bool allowRoomDividers;

	[EnableIf("allowRoomDividers")]
	public int maxDividers;

	[ReorderableList]
	[Tooltip("Only allow room dividers from these room types:")]
	public List<RoomTypePreset> onlyAllowDividersAdjoining;

	[Header("Special Rules")]
	[Tooltip("If true the address entrance is allowed to open into this room")]
	public bool allowMainAddressEntrance;

	[Tooltip("If true the address entrance is allowed to open into this room")]
	public bool allowSecondaryAddressEntrance;

	[Tooltip("If both are present, prefer main entrance. Doubles entrance ranking score, so make sure it is >0")]
	public bool preferMainAddressEntrance;

	[Tooltip("If true this must be connected to an entrance, either by the entrance opening into it or otherwise through a created hallway. This will also skip the doorway creation process for this room.")]
	public bool mustConnectWithEntrance;

	[Tooltip("If true this room can be overriden with no penalty")]
	public bool overridable;

	[Range(0f, 10f)]
	[Tooltip("This room can be overwritten rooms with priority up to this value")]
	public int overwriteWithPriorityUpTo;

	[ReorderableList]
	[Tooltip("Also block overrides from these room types")]
	public List<RoomTypePreset> blockOverridesFromType;

	[Tooltip("If  the block list above is active then it makes sense to limit this room to only being overwritten once, so rooms outside of this block list can't then overwrite this node again.")]
	public int overwriteLimit;

	[Tooltip("If true this room will exapnd into null space after all rooms are assigned, regardness of shape settings above.")]
	public bool expandIntoNull;

	[Tooltip("Limitations to null room expansion: Will only choose to expand if there are this many or more adjacent tiles")]
	public int expandIntoNullAdjacencyMinimum;

	[Tooltip("If true this will share common features with adjacent rooms of the same type (such as light switches and ceiling light styles")]
	public bool shareFeaturesWithCommonAdjacent;

	[Tooltip("If true corridor ends can be integrated into this room (eg ends of hallways etc)")]
	public bool allowCorridorReplacement;

	[Header("Floor Settings Override")]
	public bool overrideFloorHeight;

	[EnableIf("overrideFloorHeight")]
	public int floorHeight;

	[Header("Debug")]
	public RoomConfiguration copyFrom;
}
