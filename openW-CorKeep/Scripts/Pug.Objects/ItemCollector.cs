using System.Collections.Generic;
using I2.Loc;
using Pug.Automation;
using Pug.Sprite;
using Pug.UnityExtensions;
using PugTilemap;
using UnityEngine;

public class ItemCollector : EntityMonoBehaviour, IFilteringBuilding
{
	public LocalizedString uiTitle = "filtering";

	public Transform scanEffectCenter;

	public PuffID teleportEffectSource;

	public PuffID teleportEffectDestination;

	public SpriteObject electricitySprite;

	public SpriteObject electricitySpriteShadow;

	public SpriteObject filterSprite;

	private MaterialPropertyBlock _scanProperties;

	public MeshRenderer scannerRenderer;

	private Vector3 _dropOfPosition;

	private ContainedObjectsBuffer _containedObject;

	private bool _requiresElectricity;

	private bool _hadElectricity;

	private bool _filteringDisplayed = true;

	private Color _defaultFilteringEnabledColor;

	private Color _defaultFilteringEnabledEmission;

	private List<AudioManager.RunningSfxReference> loopingSfx = new List<AudioManager.RunningSfxReference>();

	public InventoryHandler inventoryHandler { get; private set; }

	protected override void Awake()
	{
		base.Awake();
		_scanProperties = new MaterialPropertyBlock();
		_defaultFilteringEnabledColor = filterSprite.color;
		_defaultFilteringEnabledEmission = filterSprite.emissiveColor;
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		inventoryHandler = new InventoryHandler(this, base.world);
		_containedObject = inventoryHandler.GetContainedObjectData(0);
		_dropOfPosition = -EntityUtility.GetComponentData<DirectionCD>(base.entity, base.world).direction;
		scanEffectCenter.localPosition = -_dropOfPosition * (1f + Mathf.Floor(scanEffectCenter.localScale.x * 0.5f));
		_requiresElectricity = EntityUtility.HasComponentData<ElectricityCD>(base.entity, base.world);
		DisplaySprites(visible: true);
		UpdateVisuals(force: true);
	}

	protected override void OnShow()
	{
		Manager.multiMap.SetHiddenTile(base.WorldPosition.RoundToInt2(), 4, TileType.circuitPlate, 0);
		base.OnShow();
	}

	protected override void OnHide()
	{
		Manager.multiMap.ClearHiddenTileOfType(base.WorldPosition.RoundToInt2(), TileType.circuitPlate);
		DisplaySprites(visible: false);
		base.OnHide();
		if (loopingSfx == null)
		{
			return;
		}
		foreach (AudioManager.RunningSfxReference item in loopingSfx)
		{
			item.FadeOutAndStop();
		}
		loopingSfx.Clear();
	}

	private void DisplaySprites(bool visible)
	{
		electricitySprite.enabled = visible;
		electricitySpriteShadow.enabled = visible;
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		UpdateVisuals();
		bool num = _containedObject.objectID != ObjectID.None;
		_containedObject = inventoryHandler.GetContainedObjectData(0);
		bool flag = _containedObject.objectID != ObjectID.None;
		if (!num && flag)
		{
			PlayTeleportEffects(base.RenderPosition + GetActiveMoverPosition());
		}
		if (num && !flag)
		{
			PlayTeleportEffects(base.RenderPosition + _dropOfPosition);
		}
	}

	private void UpdateVisuals(bool force = false)
	{
		bool flag = HasElectricity();
		if (flag != _hadElectricity || force)
		{
			_hadElectricity = flag;
			electricitySprite.PlayAnimation(flag ? 1260321794 : (-1949102368));
			scanEffectCenter.gameObject.SetActive(flag);
			if (loopingSfx == null || loopingSfx.Count == 0)
			{
				AudioManager.Sfx(SfxTableID.itemCollectorScanSfx, base.RenderPosition, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, loopingSfx);
			}
		}
		if (!flag && loopingSfx != null)
		{
			foreach (AudioManager.RunningSfxReference item in loopingSfx)
			{
				item.FadeOutAndStop();
			}
			loopingSfx.Clear();
		}
		float value = Time.time + base.WorldPosition.z + base.WorldPosition.x;
		_scanProperties.SetFloat("_ScanTime", value);
		scannerRenderer.SetPropertyBlock(_scanProperties);
		UpdateFilteringVisuals();
	}

	private void PlayTeleportEffects(Vector3 position)
	{
		Manager.effects.PlayPuff(teleportEffectSource, position, 1);
		AudioManager.Sfx(SfxID.item_collector_pick_up_1_01, position, 0.088f, 1f, 0.05f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 9f, 8f);
	}

	private Vector3 GetActiveMoverPosition()
	{
		Vector3 vector = EntityUtility.GetComponentData<PugAutomationEnabledMoverSyncedCD>(base.entity, base.world).moveVector.ToFloat3();
		return _dropOfPosition - vector;
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
				filterSprite.color = _defaultFilteringEnabledColor;
				filterSprite.emissiveColor = _defaultFilteringEnabledEmission;
			}
			else
			{
				filterSprite.color = new Color(0f, 0f, 0f, 0f);
				filterSprite.emissiveColor = Color.black;
			}
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
		return uiTitle;
	}
}
