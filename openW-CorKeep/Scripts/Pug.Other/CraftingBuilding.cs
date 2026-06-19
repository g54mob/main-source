using System;
using System.Collections.Generic;
using I2.Loc;
using Pug.Automation;
using Pug.Sprite;
using Pug.UnityExtensions;
using Unity.Entities;
using UnityEngine;

public class CraftingBuilding : EntityMonoBehaviour
{
	[Serializable]
	public class CraftingCategoryWindowInfos
	{
		public ObjectID usedForBuilding;

		public List<CraftingCategoryWindowInfo> windowInfos;
	}

	[Serializable]
	public class CraftingCategoryWindowInfo
	{
		public Season showAsDefaultDuringSeason;

		public Sprite icon;

		public int startSlotIndex;

		public int endSlotIndex;
	}

	[Serializable]
	public class CraftingUISettings
	{
		public List<LocalizedString> titles = new List<LocalizedString>();

		public UIManager.CraftingUIThemeType craftingUIBackgroundVariation;

		public CraftingUISettings(UIManager.CraftingUIThemeType craftingUIBackgroundVariation, params LocalizedString[] titles)
		{
			this.craftingUIBackgroundVariation = craftingUIBackgroundVariation;
			this.titles = new List<LocalizedString>(titles);
		}
	}

	[Serializable]
	public class CraftingUISettingsOverride
	{
		public ObjectID usedForBuilding;

		public CraftingUISettings settings;
	}

	[Header("Crafting UI settings")]
	public bool hideRecipes;

	public SpriteObject electricitySprite;

	public CraftingUISettings defaultUISettings;

	[ArrayElementTitle("usedForBuilding")]
	public List<CraftingUISettingsOverride> buildingSpecificUISettings;

	private Color _baselineElectricityEmission;

	[ArrayElementTitle("usedForBuilding")]
	public List<CraftingCategoryWindowInfos> craftingCategoryWindowInfos;

	protected CraftingHandler craftingHandler;

	private int prevCraftingState;

	protected override void Awake()
	{
		base.Awake();
		_baselineElectricityEmission = ((electricitySprite != null) ? electricitySprite.emissiveColor : Color.black);
	}

	public CraftingUISettings GetCraftingUISettings()
	{
		if (!TryGetBuildingSpecificSettings(base.objectData.objectID, out var result))
		{
			return defaultUISettings;
		}
		return result;
	}

	private bool TryGetBuildingSpecificSettings(ObjectID buildingObjectID, out CraftingUISettings result)
	{
		foreach (CraftingUISettingsOverride buildingSpecificUISetting in buildingSpecificUISettings)
		{
			if (buildingObjectID == buildingSpecificUISetting.usedForBuilding)
			{
				result = buildingSpecificUISetting.settings;
				return true;
			}
		}
		result = null;
		return false;
	}

	public CraftingCategoryWindowInfo GetCraftingCategoryWindowInfo(int currentCategoryIndex)
	{
		ObjectID objectID = base.objectData.objectID;
		foreach (CraftingCategoryWindowInfos craftingCategoryWindowInfo in craftingCategoryWindowInfos)
		{
			if (objectID == craftingCategoryWindowInfo.usedForBuilding && craftingCategoryWindowInfo.windowInfos.Count > currentCategoryIndex)
			{
				return craftingCategoryWindowInfo.windowInfos[currentCategoryIndex];
			}
		}
		return null;
	}

	public List<CraftingCategoryWindowInfo> GetCraftingCategoryWindowInfos()
	{
		ObjectID objectID = base.objectData.objectID;
		foreach (CraftingCategoryWindowInfos craftingCategoryWindowInfo in craftingCategoryWindowInfos)
		{
			if (objectID == craftingCategoryWindowInfo.usedForBuilding)
			{
				return craftingCategoryWindowInfo.windowInfos;
			}
		}
		return null;
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		craftingHandler = new CraftingHandler(this, base.world, treatAsAllInventoriesForTransfer: false);
		prevCraftingState = 0;
		UpdateCraftingStateAnimations();
		if (EntityUtility.HasComponentData<IncludedCraftingBuildingsBuffer>(base.entity, base.world))
		{
			this.craftingCategoryWindowInfos = new List<CraftingCategoryWindowInfos>();
			DynamicBuffer<IncludedCraftingBuildingsBuffer> buffer = EntityUtility.GetBuffer<IncludedCraftingBuildingsBuffer>(base.entity, base.world);
			int num = 0;
			CraftingCategoryWindowInfos craftingCategoryWindowInfos = new CraftingCategoryWindowInfos
			{
				usedForBuilding = base.objectData.objectID,
				windowInfos = new List<CraftingCategoryWindowInfo>()
			};
			foreach (IncludedCraftingBuildingsBuffer item2 in buffer)
			{
				ObjectInfo objectInfo = PugDatabase.GetObjectInfo(item2.objectID);
				if (objectInfo != null)
				{
					CraftingCategoryWindowInfo item = new CraftingCategoryWindowInfo
					{
						icon = objectInfo.smallIcon,
						startSlotIndex = num,
						endSlotIndex = num + item2.amountOfCraftingOptions - 1
					};
					num += item2.amountOfCraftingOptions;
					craftingCategoryWindowInfos.windowInfos.Add(item);
				}
			}
			this.craftingCategoryWindowInfos.Add(craftingCategoryWindowInfos);
		}
		UpdateElectricitySprite();
	}

	public override void OnDestroy()
	{
		Dispose();
		base.OnDestroy();
	}

	private void Dispose()
	{
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		OnPlayerLeftBuilding();
	}

	public override void OnFree()
	{
		OnPlayerLeftBuilding();
		Dispose();
		base.OnFree();
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		UpdateCraftingStateAnimations();
		UpdateElectricitySprite();
	}

	private void UpdateCraftingStateAnimations()
	{
		if (!craftingHandler.IsAutoCrafter())
		{
			return;
		}
		int num = (craftingHandler.IsAnySlotCrafting() ? 1 : (-1));
		if (prevCraftingState != num)
		{
			prevCraftingState = num;
			if (num == 1)
			{
				OnActive();
			}
			else
			{
				OnInactive();
			}
		}
	}

	public virtual void Use()
	{
		Manager.main.player.SetActiveCraftingHandler(craftingHandler);
		Manager.ui.OnPlayerInventoryOpen();
	}

	public void OnPlayerLeftBuilding()
	{
		PlayerController player = Manager.main.player;
		if (!(player == null) && player.activeCraftingHandler == craftingHandler)
		{
			Manager.ui.HideAllInventoryAndCraftingUI();
		}
	}

	protected virtual void OnActive()
	{
		if (hasAnimator)
		{
			animator.SetTrigger(1260321794);
		}
	}

	protected virtual void OnInactive()
	{
		if (hasAnimator)
		{
			animator.SetTrigger(-1949102368);
		}
	}

	public ObjectID? getOutputObjectIDatIndex(int index)
	{
		CraftingHandler craftingHandler = this.craftingHandler;
		if (craftingHandler != null && craftingHandler.inventoryHandler.HasObject(index))
		{
			return craftingHandler.inventoryHandler.GetObjectData(index).objectID;
		}
		return ObjectID.None;
	}

	public bool HasOutputSlot()
	{
		if (EntityUtility.TryGetComponentData<CraftingCD>(base.entity, base.world, out var value))
		{
			return value.outputSlotIndex != -1;
		}
		return false;
	}

	public void UpdateElectricitySprite()
	{
		if (!(electricitySprite == null))
		{
			EntityUtility.TryGetComponentData<ElectricityCD>(base.entity, base.world, out var value);
			bool hasEnoughElectricityToPowerStuff = value.hasEnoughElectricityToPowerStuff;
			electricitySprite.emissiveColor = (hasEnoughElectricityToPowerStuff ? _baselineElectricityEmission : Color.black);
		}
	}
}
