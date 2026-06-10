using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class MaterialsController : MonoBehaviour
{
	[Serializable]
	public class MaterialDebug
	{
		public string name;

		public Toolbox.MaterialKey key;

		public Material mat;
	}

	[Serializable]
	public struct FootprintMaterialKey
	{
		public int type;

		public float strength;

		public float blood;

		public bool Equals(FootprintMaterialKey other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static bool operator ==(FootprintMaterialKey c1, FootprintMaterialKey c2)
		{
			return false;
		}

		public static bool operator !=(FootprintMaterialKey c1, FootprintMaterialKey c2)
		{
			return false;
		}
	}

	[Header("Materials Library")]
	public Dictionary<Toolbox.MaterialKey, Material> commonMaterialsLibrary;

	public Dictionary<Toolbox.MaterialKey, List<Material>> uniqueMaterialsLibrary;

	public Dictionary<FootprintMaterialKey, Material> footprintMaterialLibrary;

	[ReadOnly]
	[Space(5f)]
	[InfoBox("How many total materials have been created through this material library system", EInfoBoxType.Normal)]
	public int materialCount;

	[ReadOnly]
	[InfoBox("How many material instances have been 'saved' from new instantiation afresh because of the dictionary", EInfoBoxType.Normal)]
	[Space(5f)]
	public int materialInstancesAvertedByCommonDictionary;

	[ReadOnly]
	[Space(5f)]
	[InfoBox("How many non-instances can be used (ie direct use of the base material)", EInfoBoxType.Normal)]
	public int useOfBaseMaterials;

	[Space(5f)]
	[ReadOnly]
	[InfoBox("How many material instances are created by lights? (On/off instanced of materials assigned to lights)", EInfoBoxType.Normal)]
	public int lightMaterialInstances;

	[ReadOnly]
	[Space(5f)]
	public int footprintMaterials;

	[Space(5f)]
	[ReadOnly]
	[InfoBox("How many material instances have been 'saved' from new instantiation afresh because of the dictionary", EInfoBoxType.Normal)]
	public int footprintInstancesAvertedByDictionary;

	[Header("Footprint Settings")]
	public Material footprintMaterialShoe;

	public Material footprintMaterialBoot;

	public Material footprintMaterialHeel;

	public Color dirtColour;

	public Color bloodColour;

	[Space(7f)]
	public List<MaterialDebug> commonMaterialsDebug;

	public List<MaterialDebug> uniqueMaterialsDebug;

	private static MaterialsController _instance;

	private static readonly string MATERIAL_NO_MAT_COLOUR_KEY;

	private static readonly string MATERIAL_RAIN_WINDOW_GLASS_KEY;

	private static readonly string MATERIAL_BASE_COLOR_KEY;

	private static readonly string MATERIAL_COLOR1_KEY;

	private static readonly string MATERIAL_COLOR2_KEY;

	private static readonly string MATERIAL_COLOR3_KEY;

	private static readonly string MATERIAL_GRUB_AMOUNT_KEY;

	public static MaterialsController Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public Material SetMaterialGroup(GameObject model, MaterialGroupPreset preset, Toolbox.MaterialKey key, bool forceUniqueInstance = false, MeshRenderer renderer = null)
	{
		return null;
	}

	public Material ApplyMaterialKey(GameObject model, Toolbox.MaterialKey key)
	{
		return null;
	}

	public Material ApplyMaterialKey(MeshRenderer renderer, Toolbox.MaterialKey key)
	{
		return null;
	}

	public Material GetMaterialFromKey(Toolbox.MaterialKey key)
	{
		return null;
	}

	public Toolbox.MaterialKey GenerateMaterialKey(MaterialGroupPreset.MaterialVariation variation, ColourSchemePreset scheme, NewRoom room, bool useGrubiness, NewBuilding building = null)
	{
		return null;
	}

	public void ApplyMaterial(GameObject model, Material mat)
	{
	}

	public void ApplyMaterial(MeshRenderer renderer, Material mat)
	{
	}

	public Color GetColourFromScheme(ColourSchemePreset scheme, MaterialGroupPreset.MaterialColour colourType, NewRoom room, NewBuilding building = null)
	{
		return default(Color);
	}

	public Material GetFootprintMaterial(FootprintController fc)
	{
		return null;
	}

	[Button(null, EButtonEnableMode.Always)]
	public void PopulateDebugData()
	{
	}
}
