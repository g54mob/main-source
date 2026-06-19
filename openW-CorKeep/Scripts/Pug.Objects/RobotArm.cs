using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using Pug.Automation;
using Pug.Sprite;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Mathematics;
using UnityEngine;

public class RobotArm : EntityMonoBehaviour, IFilteringBuilding
{
	public SpriteRenderer itemSR;

	public ColorReplacer colorReplacer;

	public LocalizedString UITitle = "filtering";

	private ObjectID currentContainedObjectID;

	private int currentContainedVariation;

	private bool _requiresElectricity = true;

	private int prevVariation;

	private int pickUpAnim;

	private int dropOffAnim;

	private int grabAnim;

	private int grabDropAnim;

	public SpriteObject armSprite;

	public SpriteObject clawSprite;

	public Transform clawTransform;

	public Transform itemTransform;

	public List<Vector3> clawPos;

	public float[] itemYPos = new float[6] { -0.5f, -0.5625f, -0.625f, -0.6875f, -0.75f, -0.8125f };

	private bool _isMultiDirectionArm;

	private bool _shouldDisplayItem;

	private Color _defaultFilteringEnabledEmission;

	private bool _filteringDisplayed = true;

	private const float ROTATION_ANIMATION_TIME = 0.3f;

	private static readonly int armIdleDown = SpriteAsset.StringToHash("idleDown");

	private static readonly int armIdleRight = SpriteAsset.StringToHash("idleRight");

	private static readonly int armIdleLeft = SpriteAsset.StringToHash("idleLeft");

	private static readonly int armIdleUp = SpriteAsset.StringToHash("idleUp");

	private static readonly int grabDown = SpriteAsset.StringToHash("Pick_pickDown");

	private static readonly int grabRight = SpriteAsset.StringToHash("Pick_pickRight");

	private static readonly int grabLeft = SpriteAsset.StringToHash("Pick_pickLeft");

	private static readonly int grabUp = SpriteAsset.StringToHash("Pick_pickUp");

	private static readonly int armEvent0 = SpriteAsset.StringToHash("clawPos0");

	private static readonly int armEvent1 = SpriteAsset.StringToHash("clawPos1");

	private static readonly int armEvent2 = SpriteAsset.StringToHash("clawPos2");

	private static readonly int armEvent3 = SpriteAsset.StringToHash("clawPos3");

	private static readonly int armEvent4 = SpriteAsset.StringToHash("clawPos4");

	private static readonly int armEvent5 = SpriteAsset.StringToHash("clawPos5");

	private static readonly int armEvent6 = SpriteAsset.StringToHash("clawPos6");

	private static readonly int armEvent7 = SpriteAsset.StringToHash("clawPos7");

	private static readonly int armEvent8 = SpriteAsset.StringToHash("clawPos8");

	private static readonly int armEvent9 = SpriteAsset.StringToHash("clawPos9");

	private static readonly int clawEvent0 = SpriteAsset.StringToHash("itemPos0");

	private static readonly int clawEvent1 = SpriteAsset.StringToHash("itemPos1");

	private static readonly int clawEvent2 = SpriteAsset.StringToHash("itemPos2");

	private static readonly int clawEvent3 = SpriteAsset.StringToHash("itemPos3");

	private static readonly int clawEvent4 = SpriteAsset.StringToHash("itemPos4");

	private static readonly int clawEvent5 = SpriteAsset.StringToHash("itemPos5");

	private Coroutine _activeRoutine;

	public InventoryHandler inventoryHandler { get; private set; }

	public virtual bool IsFarmArm => false;

	protected override void Awake()
	{
		base.Awake();
		armSprite.onAnimationEvent += HandleAnimationEvent;
		if (clawSprite != null)
		{
			clawSprite.onAnimationEvent += HandleAnimationEvent;
		}
		_defaultFilteringEnabledEmission = armSprite.emissiveColor;
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		currentContainedObjectID = ObjectID.None;
		itemSR.sprite = null;
		inventoryHandler = new InventoryHandler(this, base.world);
		_shouldDisplayItem = true;
		prevVariation = -1;
		UpdateVisuals();
		if (clawSprite != null)
		{
			clawSprite.PlayAnimation(486510651, forceResetTime: false, skipTransition: true);
			clawSprite.SetVariantByIndex(0);
			clawSprite.ApplyVisualChange();
		}
		_requiresElectricity = EntityUtility.HasComponentData<ElectricityCD>(base.entity, base.world);
		_isMultiDirectionArm = EntityUtility.HasComponentData<PugAutomationEnabledMoverSyncedCD>(base.entity, base.world);
		UpdateFilteringVisuals();
	}

	protected override void OnShow()
	{
		Manager.multiMap.SetHiddenTile(base.WorldPosition.RoundToInt2(), 4, TileType.circuitPlate, 0);
		base.OnShow();
	}

	protected override void OnHide()
	{
		Manager.multiMap.ClearHiddenTileOfType(base.WorldPosition.RoundToInt2(), TileType.circuitPlate);
		base.OnHide();
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		UpdateVisuals();
	}

	private void UpdateVisuals()
	{
		bool flag = currentContainedObjectID != ObjectID.None;
		ContainedObjectsBuffer containedObjectData = inventoryHandler.GetContainedObjectData(0);
		if (containedObjectData.objectID != currentContainedObjectID || containedObjectData.variation != currentContainedVariation)
		{
			UpdateDisplayedItem();
			currentContainedObjectID = containedObjectData.objectID;
			currentContainedVariation = containedObjectData.variation;
		}
		int num = base.variation;
		if (num != prevVariation)
		{
			switch (num)
			{
			case 0:
				armSprite.PlayAnimation(armIdleUp, forceResetTime: false, skipTransition: true);
				pickUpAnim = armIdleUp;
				dropOffAnim = armIdleDown;
				grabAnim = grabUp;
				grabDropAnim = grabDown;
				break;
			case 1:
				armSprite.PlayAnimation(armIdleRight, forceResetTime: false, skipTransition: true);
				pickUpAnim = armIdleRight;
				dropOffAnim = armIdleLeft;
				grabAnim = grabRight;
				grabDropAnim = grabLeft;
				break;
			case 2:
				armSprite.PlayAnimation(armIdleDown, forceResetTime: false, skipTransition: true);
				pickUpAnim = armIdleDown;
				dropOffAnim = armIdleUp;
				grabAnim = grabDown;
				grabDropAnim = grabUp;
				break;
			case 3:
				armSprite.PlayAnimation(armIdleLeft, forceResetTime: false, skipTransition: true);
				pickUpAnim = armIdleLeft;
				dropOffAnim = armIdleRight;
				grabAnim = grabLeft;
				grabDropAnim = grabRight;
				break;
			}
			armSprite.ApplyVisualChange();
			prevVariation = num;
		}
		bool flag2 = currentContainedObjectID != ObjectID.None;
		if (flag && !flag2)
		{
			if (_activeRoutine != null)
			{
				StopCoroutine(_activeRoutine);
			}
			_activeRoutine = StartCoroutine(RaiseEmptyTurnBackLowerEmptyRoutine());
		}
		else if (!flag && flag2)
		{
			if (_activeRoutine != null)
			{
				StopCoroutine(_activeRoutine);
			}
			UpdateAnimIfMultiDirectionArm();
			_activeRoutine = StartCoroutine(PickupTurnAndDropRoutine());
		}
		UpdateFilteringVisuals();
	}

	private void UpdateFilteringVisuals()
	{
		EntityUtility.TryGetComponentData<ObjectFilteringCD>(base.entity, base.world, out var value);
		bool flag = value.filterType != FilterType.None;
		if (_filteringDisplayed != flag)
		{
			_filteringDisplayed = flag;
			if (flag)
			{
				armSprite.emissiveColor = _defaultFilteringEnabledEmission;
			}
			else
			{
				armSprite.emissiveColor = Color.black;
			}
		}
	}

	public void UpdateAnimIfMultiDirectionArm()
	{
		if (EntityUtility.TryGetComponentData<PugAutomationEnabledMoverSyncedCD>(base.entity, base.world, out var value))
		{
			int2 moveVector = value.moveVector;
			if (math.dot(moveVector, new int2(0, 1)) > 0)
			{
				pickUpAnim = armIdleDown;
				dropOffAnim = armIdleUp;
				grabAnim = grabDown;
				grabDropAnim = grabUp;
			}
			else if (math.dot(moveVector, new int2(1, 0)) > 0)
			{
				pickUpAnim = armIdleLeft;
				dropOffAnim = armIdleRight;
				grabAnim = grabLeft;
				grabDropAnim = grabRight;
			}
			else if (math.dot(moveVector, new int2(0, -1)) > 0)
			{
				pickUpAnim = armIdleUp;
				dropOffAnim = armIdleDown;
				grabAnim = grabUp;
				grabDropAnim = grabDown;
			}
			else if (math.dot(moveVector, new int2(-1, 0)) > 0)
			{
				pickUpAnim = armIdleRight;
				dropOffAnim = armIdleLeft;
				grabAnim = grabRight;
				grabDropAnim = grabLeft;
			}
		}
	}

	public IEnumerator RaiseEmptyTurnBackLowerEmptyRoutine()
	{
		if (clawSprite != null)
		{
			clawSprite.PlayAnimation(1133833840);
			clawSprite.SetVariantByIndex(0);
			clawSprite.ApplyVisualChange();
		}
		else
		{
			armSprite.PlayAnimation(grabDropAnim);
		}
		yield return new WaitForSeconds(0.2f);
		if (!_isMultiDirectionArm)
		{
			armSprite.PlayAnimation(dropOffAnim);
			armSprite.PlayAnimation(pickUpAnim);
			yield return new WaitForSeconds(0.3f);
		}
		if (clawSprite != null)
		{
			clawSprite.PlayAnimation(486510651);
		}
		yield return null;
		_activeRoutine = null;
	}

	private IEnumerator PickupTurnAndDropRoutine()
	{
		if (armSprite.currentAnimationHash != pickUpAnim)
		{
			_shouldDisplayItem = false;
			UpdateDisplayedItem();
			armSprite.PlayAnimation(pickUpAnim);
			if (IsFarmArm)
			{
				AudioManager.Sfx(SfxTableID.seedArmRotateSfx, base.transform.position);
			}
			yield return new WaitForSeconds(0.3f);
			_shouldDisplayItem = true;
			UpdateDisplayedItem();
		}
		if (clawSprite != null)
		{
			clawSprite.PlayAnimation(1133833840);
			clawSprite.SetVariantByIndex(1);
			clawSprite.ApplyVisualChange();
		}
		else
		{
			armSprite.PlayAnimation(grabAnim);
		}
		AudioManager.Sfx(IsFarmArm ? SfxTableID.robotFarmArmSfx : SfxTableID.robotArmSfx, base.transform.position);
		yield return new WaitForSeconds(0.2f);
		armSprite.PlayAnimation(pickUpAnim);
		armSprite.PlayAnimation(dropOffAnim);
		yield return new WaitForSeconds(0.3f);
		if (clawSprite != null)
		{
			clawSprite.PlayAnimation(486510651);
			clawSprite.SetVariantByIndex(1);
			clawSprite.ApplyVisualChange();
		}
		yield return null;
		_activeRoutine = null;
	}

	private void UpdateDisplayedItem()
	{
		ContainedObjectsBuffer containedObjectData = inventoryHandler.GetContainedObjectData(0);
		if (!_shouldDisplayItem || containedObjectData.objectID == ObjectID.None)
		{
			itemSR.sprite = null;
			return;
		}
		ObjectInfo objectInfo = PugDatabase.GetObjectInfo(containedObjectData.objectID, containedObjectData.variation);
		Sprite iconOverride = Manager.ui.itemOverridesTable.GetIconOverride(containedObjectData.objectData, getSmallIcon: true);
		itemSR.sprite = ((iconOverride != null) ? iconOverride : objectInfo.smallIcon);
		colorReplacer.UpdateColorReplacerFromObjectData(containedObjectData);
		Manager.ui.ApplyAnyIconGradientMap(containedObjectData, itemSR);
	}

	private void HandleAnimationEvent(int hash)
	{
		int num = -1;
		if (hash == armEvent0)
		{
			num = 0;
		}
		else if (hash == armEvent1)
		{
			num = 1;
		}
		else if (hash == armEvent2)
		{
			num = 2;
		}
		else if (hash == armEvent3)
		{
			num = 3;
		}
		else if (hash == armEvent4)
		{
			num = 4;
		}
		else if (hash == armEvent5)
		{
			num = 5;
		}
		else if (hash == armEvent6)
		{
			num = 6;
		}
		else if (hash == armEvent7)
		{
			num = 7;
		}
		else if (hash == armEvent8)
		{
			num = 8;
		}
		else if (hash == armEvent9)
		{
			num = 9;
		}
		if (num > -1)
		{
			clawTransform.localPosition = clawPos[num];
		}
		num = -1;
		if (hash == clawEvent0)
		{
			num = 0;
		}
		else if (hash == clawEvent1)
		{
			num = 1;
		}
		else if (hash == clawEvent2)
		{
			num = 2;
		}
		else if (hash == clawEvent3)
		{
			num = 3;
		}
		else if (hash == clawEvent4)
		{
			num = 4;
		}
		else if (hash == clawEvent5)
		{
			num = 5;
		}
		if (num > -1)
		{
			itemTransform.localPosition = new Vector3(0f, itemYPos[num], 0.001f);
		}
	}

	private void OnDrawGizmos()
	{
		foreach (Vector3 clawPo in clawPos)
		{
			Gizmos.DrawSphere(base.transform.TransformPoint(clawPo), 0.05f);
		}
	}

	public void Use()
	{
		Manager.main.player.SetActiveFilterStructure(this);
		Manager.ui.OnFilterWindowOpen();
	}

	public void OnPlayerLeftBuilding()
	{
		PlayerController player = Manager.main.player;
		if (!(player == null) && player.GetActiveFilteringBuilding() == this)
		{
			Manager.ui.HideAllInventoryAndCraftingUI();
			player.SetActiveFilterStructure(null);
		}
	}

	public bool RequiresElectricity()
	{
		return _requiresElectricity;
	}

	public bool HasElectricity()
	{
		if (_requiresElectricity)
		{
			return EntityUtility.GetComponentData<ElectricityCD>(base.entity, base.world).hasEnoughElectricityToPowerStuff;
		}
		return false;
	}

	public LocalizedString GetUITitle()
	{
		return UITitle;
	}
}
