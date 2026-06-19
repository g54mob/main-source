using I2.Loc;
using UnityEngine;

[CreateAssetMenu(fileName = "RoomCustomizationObject", menuName = "Build/RoomCustomizationObject", order = 1)]
public class RoomCustomizationObject : ScriptableObject
{
	public ulong ID;

	public bool canBeUnlocked = true;

	public Vector3 footprint;

	public Vector3 centerOffset;

	public bool startUnlocked;

	public ItemSet associatedItemSet;

	public LocalizedString nameKey;

	public LocalizedString descKey;

	public CustomizationType objectType;

	public Sprite icon;

	public bool updateObjectRotationForIcon = true;

	public GameObject prefabObject;

	public Color associatedColor = Color.white;

	public CollisionType collisionType;

	public bool tiling = true;

	public bool shadowsEnabled = true;

	public bool useMatForCeiling;

	public bool useTrimMatForPenFrame;

	public bool useColorForCeiling = true;

	public bool useSecondaryMatForCeiling;

	public PhysicMaterial customPhysicsMaterial;

	public Material associatedMaterial;

	public Material associatedSecondaryMaterial;

	public Material associatedTrimMaterial;

	public string GetName()
	{
		return nameKey;
	}

	public string GetDescription()
	{
		return descKey;
	}
}
