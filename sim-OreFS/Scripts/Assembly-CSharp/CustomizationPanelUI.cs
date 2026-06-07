using System.Collections.Generic;
using Kamgam.UGUIComponentsForSettings;
using Mirror;
using UnityEngine;

public class CustomizationPanelUI : MonoBehaviour
{
	[Header("Templates (deactivated in scene)")]
	public CustomizationHeaderUI headerTemplate;

	public CustomizationOptionUI optionTemplate;

	[Header("Content Parent")]
	public Transform contentParent;

	[Header("Category Configs (sıra: Head, Top, Bottom, Helmet, Gloves, Boots, Belt)")]
	public List<CustomizationCategoryConfig> categoryConfigs = new List<CustomizationCategoryConfig>();

	[Header("Option Label Keys")]
	public string typeI2Key = "Customization_Type";

	public string colorI2Key = "Customization_Color";

	private GamePlayer localPlayer;

	private SkinWrapper skinWrapper;

	private int headID;

	private int topID;

	private int bottomID;

	private int helmetID;

	private int glovesID;

	private int bootsID;

	private int beltID;

	private int topMatID;

	private int bottomMatID;

	private int glovesMatID;

	private int helmetMatID;

	private int bootsMatID;

	private CustomizationOptionUI topColorRow;

	private CustomizationOptionUI bottomColorRow;

	private CustomizationOptionUI glovesTypeRow;

	private CustomizationOptionUI glovesColorRow;

	private CustomizationOptionUI helmetColorRow;

	private CustomizationOptionUI bootsColorRow;

	private readonly List<GameObject> spawnedInstances = new List<GameObject>();

	private CustomizationHeaderUI activeHeader;

	private const int CAT_HEAD = 0;

	private const int CAT_TOP = 1;

	private const int CAT_BOTTOM = 2;

	private const int CAT_HELMET = 3;

	private const int CAT_GLOVES = 4;

	private const int CAT_BOOTS = 5;

	private const int CAT_BELT = 6;

	private void OnEnable()
	{
		localPlayer = GetLocalPlayer();
		if (!(localPlayer == null))
		{
			skinWrapper = localPlayer.skinWrapper;
			if (!(skinWrapper == null))
			{
				headID = localPlayer.headID;
				topID = localPlayer.topID;
				bottomID = localPlayer.bottomID;
				helmetID = localPlayer.helmetID;
				glovesID = localPlayer.glovesID;
				bootsID = localPlayer.bootsID;
				beltID = localPlayer.beltID;
				topMatID = localPlayer.topMatID;
				bottomMatID = localPlayer.bottomMatID;
				glovesMatID = localPlayer.glovesMatID;
				helmetMatID = localPlayer.helmetMatID;
				bootsMatID = localPlayer.bootsMatID;
				BuildUI();
			}
		}
	}

	private void OnDisable()
	{
		ClearUI();
	}

	private void BuildUI()
	{
		ClearUI();
		SpawnHeader(0);
		SpawnOption(typeI2Key, GetCount(skinWrapper.headRef), headID, OnHeadTypeChanged);
		SpawnHeader(1);
		SpawnOption(typeI2Key, GetCount(skinWrapper.topRef), topID, OnTopTypeChanged);
		topColorRow = SpawnOption(colorI2Key, GetMatCount(skinWrapper.topMaterials, topID), topMatID, OnTopColorChanged);
		SpawnHeader(2);
		SpawnOption(typeI2Key, GetCount(skinWrapper.bottomRef), bottomID, OnBottomTypeChanged);
		bottomColorRow = SpawnOption(colorI2Key, GetMatCount(skinWrapper.bottomMaterials, bottomID), bottomMatID, OnBottomColorChanged);
		SpawnHeader(3);
		SpawnOption(typeI2Key, GetCount(skinWrapper.helmetRef), helmetID, OnHelmetTypeChanged);
		helmetColorRow = SpawnOption(colorI2Key, GetMatCount(skinWrapper.helmetMaterials, helmetID), helmetMatID, OnHelmetColorChanged);
		SpawnHeader(4);
		glovesTypeRow = SpawnOption(typeI2Key, GetGlovesCount(), glovesID, OnGlovesTypeChanged);
		glovesColorRow = SpawnOption(colorI2Key, GetMatCount(skinWrapper.glovesMaterials, glovesID), glovesMatID, OnGlovesColorChanged);
		SpawnHeader(5);
		bool flag = GetCount(skinWrapper.highBootsRef) > 0;
		int count = 3 + (flag ? 1 : 0);
		SpawnOption(typeI2Key, count, bootsID, OnBootsTypeChanged);
		bootsColorRow = SpawnOption(colorI2Key, GetBootsMatCount(), bootsMatID, OnBootsColorChanged);
		SpawnHeader(6);
		SpawnOption(typeI2Key, GetCount(skinWrapper.beltRef), beltID, OnBeltTypeChanged);
	}

	private void ClearUI()
	{
		topColorRow = null;
		bottomColorRow = null;
		glovesTypeRow = null;
		glovesColorRow = null;
		helmetColorRow = null;
		bootsColorRow = null;
		activeHeader = null;
		foreach (GameObject spawnedInstance in spawnedInstances)
		{
			if (spawnedInstance != null)
			{
				Object.Destroy(spawnedInstance);
			}
		}
		spawnedInstances.Clear();
	}

	private void SpawnHeader(int categoryIndex)
	{
		CustomizationCategoryConfig categoryConfig = GetCategoryConfig(categoryIndex);
		CustomizationHeaderUI customizationHeaderUI = Object.Instantiate(headerTemplate, contentParent);
		customizationHeaderUI.gameObject.SetActive(value: true);
		customizationHeaderUI.Setup(categoryConfig.i2Key, categoryConfig.icon);
		spawnedInstances.Add(customizationHeaderUI.gameObject);
		activeHeader = customizationHeaderUI;
	}

	private CustomizationOptionUI SpawnOption(string i2Key, int count, int currentValue, OptionsButtonUGUI.OnValueChangedDelegate onChange)
	{
		Transform parent = ((activeHeader != null && activeHeader.optionContent != null) ? activeHeader.optionContent : contentParent);
		CustomizationOptionUI customizationOptionUI = Object.Instantiate(optionTemplate, parent);
		customizationOptionUI.Setup(i2Key, count, currentValue, onChange);
		spawnedInstances.Add(customizationOptionUI.gameObject);
		return customizationOptionUI;
	}

	private CustomizationCategoryConfig GetCategoryConfig(int index)
	{
		if (categoryConfigs != null && index >= 0 && index < categoryConfigs.Count)
		{
			return categoryConfigs[index];
		}
		return new CustomizationCategoryConfig
		{
			i2Key = "Customization_Unknown",
			icon = null
		};
	}

	private void OnHeadTypeChanged(int index)
	{
		headID = index;
		SendCustomization();
	}

	private void OnTopTypeChanged(int index)
	{
		topID = index;
		topMatID = 0;
		topColorRow?.Refresh(GetMatCount(skinWrapper.topMaterials, topID), OnTopColorChanged);
		int glovesCount = GetGlovesCount();
		if (glovesID >= glovesCount)
		{
			glovesID = Mathf.Max(0, glovesCount - 1);
		}
		glovesTypeRow?.Refresh(glovesCount, glovesID, OnGlovesTypeChanged);
		glovesColorRow?.Refresh(GetMatCount(skinWrapper.glovesMaterials, glovesID), glovesMatID, OnGlovesColorChanged);
		SendCustomization();
	}

	private void OnTopColorChanged(int index)
	{
		topMatID = index;
		SendCustomization();
	}

	private void OnBottomTypeChanged(int index)
	{
		bottomID = index;
		bottomMatID = 0;
		bottomColorRow?.Refresh(GetMatCount(skinWrapper.bottomMaterials, bottomID), OnBottomColorChanged);
		SendCustomization();
	}

	private void OnBottomColorChanged(int index)
	{
		bottomMatID = index;
		SendCustomization();
	}

	private void OnHelmetTypeChanged(int index)
	{
		helmetID = index;
		helmetMatID = 0;
		helmetColorRow?.Refresh(GetMatCount(skinWrapper.helmetMaterials, helmetID), OnHelmetColorChanged);
		SendCustomization();
	}

	private void OnHelmetColorChanged(int index)
	{
		helmetMatID = index;
		SendCustomization();
	}

	private void OnGlovesTypeChanged(int index)
	{
		glovesID = index;
		glovesMatID = 0;
		glovesColorRow?.Refresh(GetMatCount(skinWrapper.glovesMaterials, glovesID), OnGlovesColorChanged);
		SendCustomization();
	}

	private void OnGlovesColorChanged(int index)
	{
		glovesMatID = index;
		SendCustomization();
	}

	private void OnBootsTypeChanged(int index)
	{
		bootsID = index;
		bootsMatID = 0;
		bootsColorRow?.Refresh(GetBootsMatCount(), OnBootsColorChanged);
		SendCustomization();
	}

	private void OnBootsColorChanged(int index)
	{
		bootsMatID = index;
		SendCustomization();
	}

	private void OnBeltTypeChanged(int index)
	{
		beltID = index;
		SendCustomization();
	}

	public void Randomize()
	{
		if (!(skinWrapper == null))
		{
			headID = Random.Range(0, GetCount(skinWrapper.headRef));
			topID = Random.Range(0, GetCount(skinWrapper.topRef));
			bottomID = Random.Range(0, GetCount(skinWrapper.bottomRef));
			helmetID = Random.Range(0, GetCount(skinWrapper.helmetRef));
			beltID = Random.Range(0, GetCount(skinWrapper.beltRef));
			int glovesCount = GetGlovesCount();
			glovesID = ((glovesCount > 0) ? Random.Range(0, glovesCount) : 0);
			bool flag = GetCount(skinWrapper.highBootsRef) > 0;
			int maxExclusive = 3 + (flag ? 1 : 0);
			bootsID = Random.Range(0, maxExclusive);
			topMatID = RandomMatID(skinWrapper.topMaterials, topID);
			bottomMatID = RandomMatID(skinWrapper.bottomMaterials, bottomID);
			glovesMatID = RandomMatID(skinWrapper.glovesMaterials, glovesID);
			helmetMatID = RandomMatID(skinWrapper.helmetMaterials, helmetID);
			bootsMatID = ((bootsID != 3) ? RandomMatID(skinWrapper.bootsMaterials, bootsID) : 0);
			SendCustomization();
			BuildUI();
		}
	}

	private int RandomMatID(List<ClothingMaterialEntry> entries, int meshIndex)
	{
		int matCount = GetMatCount(entries, meshIndex);
		if (matCount <= 0)
		{
			return 0;
		}
		return Random.Range(0, matCount);
	}

	private void SendCustomization()
	{
		if (!(localPlayer == null))
		{
			localPlayer.SetCustomizationByIds(headID, topID, bottomID, helmetID, glovesID, bootsID, beltID, topMatID, bottomMatID, glovesMatID, helmetMatID, bootsMatID);
		}
	}

	private int GetCount(List<SkinnedMeshRenderer> list)
	{
		return list?.Count ?? 0;
	}

	private int GetMatCount(List<ClothingMaterialEntry> entries, int meshIndex)
	{
		if (entries == null || meshIndex < 0 || meshIndex >= entries.Count)
		{
			return 0;
		}
		ClothingMaterialEntry clothingMaterialEntry = entries[meshIndex];
		if (clothingMaterialEntry == null || clothingMaterialEntry.materials == null)
		{
			return 0;
		}
		return clothingMaterialEntry.materials.Count;
	}

	private int GetBootsMatCount()
	{
		if (bootsID == 3)
		{
			return 0;
		}
		return GetMatCount(skinWrapper.bootsMaterials, bootsID);
	}

	private int GetGlovesCount()
	{
		if (topID < 2)
		{
			return GetCount(skinWrapper.closeGlovesRef);
		}
		return GetCount(skinWrapper.openGlovesRef);
	}

	private GamePlayer GetLocalPlayer()
	{
		if (NetworkClient.localPlayer != null)
		{
			return NetworkClient.localPlayer.GetComponent<GamePlayer>();
		}
		return null;
	}
}
