using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "doorpair_data", menuName = "Database/Decor/Door Pair Preset")]
public class DoorPairPreset : ScriptableObjectIDSystem
{
	public enum WallSectionClass
	{
		wall = 0,
		window = 1,
		windowLarge = 2,
		entrance = 3,
		ventUpper = 4,
		ventLower = 5,
		ventTop = 6
	}

	[Header("Model Options")]
	[Tooltip("The wall model of the parent wall")]
	public List<GameObject> parentWallsLong;

	[Tooltip("The wall model of the child wall")]
	public List<GameObject> childWallsLong;

	[Space(7f)]
	[Tooltip("Short walls: There should be 3 here - left, middle and right")]
	public List<GameObject> parentWallsShort;

	[Tooltip("Short walls: There should be 3 here - left, middle and right")]
	public List<GameObject> childWallsShort;

	[Space(7f)]
	[Tooltip("The corner model. Always on the outside walls.")]
	public List<GameObject> corners;

	[Tooltip("The corner model for outside facing exterior walls (overrides above)")]
	public List<GameObject> quoins;

	[Space(7f)]
	[Tooltip("If true, the game will use optimization to replaces walls of 3x rows with a larger section")]
	public bool optimizeSections;

	[Tooltip("If true, user is able to place this in the editor")]
	public bool appearInEditor;

	[Tooltip("If true, this section can support lightswitches or other wall props")]
	public bool supportsWallProps;

	[Tooltip("If true, the game will continue to draw building corners around this")]
	public bool isFence;

	public bool divider;

	public bool dividerLeft;

	public bool dividerRight;

	[Tooltip("Door object")]
	[Header("Door Options")]
	public bool canFeatureDoor;

	[Tooltip("Door offset position")]
	public Vector3 doorOffset;

	[Header("Procedural Overrides")]
	[Tooltip("The class of this wall section. When a procedural address is generated, it may override this with another more appropriate model with the same class.")]
	public WallSectionClass sectionClass;

	[Tooltip("If true then this will force this section to ignore raycasts when generating room culling.")]
	public bool ignoreCullingRaycasts;

	[Tooltip("Override with this if the floor height is above 0")]
	public DoorPairPreset raisedFloorOverride;

	[Header("Material Override")]
	public MaterialGroupPreset materialOverride;

	[Tooltip("Override map graphics with this")]
	[Header("Map Overrides")]
	public List<Texture2D> mapOverride;

	[Header("Duct Overrides")]
	public bool overrideWallNormal;

	[EnableIf("overrideWallNormal")]
	public DoorPairPreset wallNormalOverrride;

	[Space(5f)]
	public bool overrideDuctLower;

	[EnableIf("overrideDuctLower")]
	public DoorPairPreset ductLowerOverrride;

	[Space(5f)]
	public bool overrideDuctUpper;

	[EnableIf("overrideDuctUpper")]
	public DoorPairPreset ductUpperOverrride;

	[Button(null, EButtonEnableMode.Always)]
	public void UpdateIDs()
	{
	}
}
