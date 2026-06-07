using System;
using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using PajamaLlama.Extensions;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Cursor Properties/Move Buildable")]
public class MoveBuildableCursorProperties : ConstructionCursorProperties, ITooltipProvider, IPanelContext
{
	private enum Interaction
	{
		None = 0,
		Pickup = 1,
		Store = 2
	}

	[Header("Move Construction")]
	[SerializeField]
	private LayerMask _layerMask;

	[SerializeField]
	private CursorState _selectCursor;

	[SerializeField]
	private CursorState _blockedCursor;

	[SerializeField]
	private CursorState _linkCursor;

	[SerializeField]
	private float _blinkRedDuration;

	[SerializeField]
	private int _blinkRedTimes;

	[SerializeField]
	private LocalizedString _blockingText;

	[SerializeField]
	private Color _blockingColor;

	[SerializeField]
	private SingleConstructionPreviewStrategy _singleConstructionPreviewStrategy;

	[SerializeField]
	private EnergyPolePreviewStrategy _energyPolePreviewStrategy;

	[SerializeField]
	private LineConstructionPreviewStrategy _lineConstructionPreviewStrategy;

	[SerializeField]
	private MoveBuildableEnergyConnectionCursorProperties _energyGridLinkCursorProperties;

	[SerializeField]
	public AssignmentType _achtitectAssignmentType;

	[SerializeField]
	private Material _architectWaterMaterial;

	[SerializeField]
	private DialogProperties _exitPanelProperties;

	[NonSerialized]
	protected Decoration _decoration;

	[NonSerialized]
	private Buildable _mouseOverBuildable;

	[NonSerialized]
	private Decoration _mouseOverDecoration;

	[NonSerialized]
	private Coroutine _blockingCoroutine;

	[NonSerialized]
	private List<Material> _blockingMaterials = new List<Material>();

	[NonSerialized]
	private ConstructionPreview _constructionPreview;

	[NonSerialized]
	private IMoveBuildablePreviewStrategy _buildablePreviewStrategy;

	[NonSerialized]
	private bool _changeLayout;

	[NonSerialized]
	private bool _restoreGameSpeed;

	[NonSerialized]
	private bool _connectingEnegryGridInProgress;

	[NonSerialized]
	private Agent _architect;

	[NonSerialized]
	private Material _defaultWaterMaterial;

	[NonSerialized]
	private Vector3 _cancelDownCameraPosition;

	public PanelID PanelID => PanelID.ArchitectExit;

	public bool BlocksApply
	{
		get
		{
			if (_constructionPreview == null)
			{
				return _connectingEnegryGridInProgress;
			}
			return true;
		}
	}

	public override void Activate()
	{
		RemoveSelectedBuildable();
		_defaultWaterMaterial = WaterManager.ReturnMaterial();
		WaterManager.SetMaterial(_architectWaterMaterial);
		if (GameSpeedManager.GameSpeed != GameSpeed.Zero)
		{
			_restoreGameSpeed = true;
			GameSpeedManager.ToggleGameSpeedZero();
			GameEventDispatcher.AddListener(GameEventType.GameSpeedChange, OnSpeedChanged);
		}
		Overlays.OverlayType = Overlays.Type.Architect;
		GameEventDispatcher.AddListener(GameEventType.OverlayUpdate, OnOverlayUpdate);
		GameEventDispatcher.AddListener(GameEventType.BuildableMenuToggled, OnBuildMenuToggled);
		_changeLayout = true;
		_connectingEnegryGridInProgress = false;
		if (GameManager.WorldManager != null)
		{
			GameManager.WorldManager.ShowConstructionBorder(enabled: true);
		}
		if (UIManager.TryReturnInstance(out var instance))
		{
			UIManager.SetState(UIState.Architect);
			instance.CloseAllPanels();
			if (Community.PlayerCommunity.ReturnAgentWithAssigmentType(_achtitectAssignmentType, out var agentOut))
			{
				_architect = agentOut;
				instance.EnableDynamicPortrait(_architect);
			}
			else
			{
				Debug.LogError("Activated Architect Mode without and Architect!");
			}
		}
		VisualBoundary.Display(display: true);
		_canBeDeactivated = true;
		GameManager.UIManager.DisplayPanel(PanelID.ArchitectBottomBar);
		UIManager.AddRewiredActionInfoToContext(this, base.Interact, base.Cancel);
	}

	private void OnSpeedChanged(GameEvent gameEvent)
	{
		if (!(gameEvent is GameSpeedChangedEvent { GameSpeed: GameSpeed.Zero }))
		{
			_restoreGameSpeed = false;
			GameManager.CursorManager.Deactivate(cancelled: true);
		}
	}

	private void OnBuildMenuToggled(GameEvent gameEvent)
	{
		GameManager.CursorManager.Deactivate();
	}

	private void OnOverlayUpdate(GameEvent gameEvent)
	{
		_changeLayout = false;
		GameManager.CursorManager.Deactivate(cancelled: true);
	}

	public override void DeactivateImmediately()
	{
		WaterManager.SetMaterial(_defaultWaterMaterial);
		StopFlashRed();
		if (GameManager.WorldManager != null)
		{
			GameManager.WorldManager.ShowConstructionBorder(enabled: false);
		}
		if (UIManager.TryReturnInstance(out var instance))
		{
			if (UIManager.State == UIState.Architect)
			{
				UIManager.SetState(UIState.Normal);
			}
			if ((bool)_architect)
			{
				instance.DisableDynamicPortrait(_architect);
			}
		}
		VisualBoundary.Display(display: false);
		_mouseOverBuildable = null;
		_mouseOverDecoration = null;
		RemoveSelectedBuildable(store: true);
		GameEventDispatcher.RemoveListener(GameEventType.GameSpeedChange, OnSpeedChanged);
		GameEventDispatcher.RemoveListener(GameEventType.OverlayUpdate, OnOverlayUpdate);
		GameEventDispatcher.RemoveListener(GameEventType.BuildableMenuToggled, OnBuildMenuToggled);
		if (_changeLayout)
		{
			Overlays.OverlayType = Overlays.Type.None;
		}
		if (_restoreGameSpeed && GameSpeedManager.GameSpeed == GameSpeed.Zero)
		{
			GameSpeedManager.ToggleGameSpeedZero();
		}
		GameManager.UIManager.ClosePanel(PanelID.ArchitectBottomBar);
		UIManager.DisableRewiredActionInfoContext(this);
	}

	public void OnRevert()
	{
		GameManager.CursorManager.Deactivate(cancelled: true);
		_constructionPreview = null;
		_buildable = null;
		_decoration = null;
	}

	public override void UpdateCursor(CursorManager cursorManager)
	{
		if (_connectingEnegryGridInProgress)
		{
			if (_energyGridLinkCursorProperties.GetCancel())
			{
				DeactivateEnergyConnection();
			}
			else
			{
				_energyGridLinkCursorProperties.UpdateCursor(cursorManager);
			}
			return;
		}
		if (_constructionPreview != null)
		{
			if (WasCanceled())
			{
				RemoveSelectedBuildable(store: true);
			}
			else if (GetInteract())
			{
				MoveSelectedBuildable();
			}
			else
			{
				UpdateConstuctionPreview();
			}
			return;
		}
		if ((bool)cursorManager.SelectionLink)
		{
			if (!AcquireMouseOverEnergyPoleDecoration(cursorManager))
			{
				AcquireMouseOverBuildable(cursorManager);
			}
		}
		else
		{
			_mouseOverBuildable = null;
			_mouseOverDecoration = null;
			base.Cursor = _defaultCursor;
		}
		if ((_mouseOverBuildable != null || _mouseOverDecoration != null) && TryReturnInteraction(out var interaction))
		{
			StopFlashRed();
			if (_mouseOverBuildable != null)
			{
				UpdateBuildableCursor(cursorManager, interaction);
			}
			else
			{
				UpdateDecorationCursor(interaction);
			}
		}
	}

	private bool AcquireMouseOverBuildable(CursorManager cursorManager)
	{
		if (cursorManager.SelectionLink.TryGetComponentInParent<Buildable>(out var componentInParent))
		{
			if (componentInParent != _mouseOverBuildable)
			{
				_mouseOverBuildable = componentInParent;
			}
			_mouseOverDecoration = null;
			base.Cursor = (cursorManager.SelectionLink.gameObject.TryGetComponent<QuickConnecting>(out var _) ? _linkCursor : (componentInParent.IsDraggable() ? _selectCursor : _blockedCursor));
			return true;
		}
		_mouseOverBuildable = null;
		base.Cursor = _blockedCursor;
		return false;
	}

	private bool AcquireMouseOverEnergyPoleDecoration(CursorManager cursorManager)
	{
		QuickConnecting component;
		if (cursorManager.SelectionLink.TryGetComponentInParent<EnergyPoleDecorationBehaviour>(out var componentInParent))
		{
			if (componentInParent.Deco != _mouseOverDecoration)
			{
				_mouseOverDecoration = componentInParent.Deco;
			}
			_mouseOverBuildable = null;
			base.Cursor = ((!componentInParent.Deco.IsDraggable()) ? _blockedCursor : (cursorManager.SelectionLink.gameObject.TryGetComponent<QuickConnecting>(out component) ? _linkCursor : _selectCursor));
			return true;
		}
		if (cursorManager.SelectionLink.TryGetComponentInParent<DecorationSlots>(out var componentInParent2))
		{
			if (componentInParent2.Buildable != _mouseOverBuildable)
			{
				_mouseOverBuildable = componentInParent2.Buildable;
			}
			_mouseOverDecoration = null;
			base.Cursor = (cursorManager.SelectionLink.gameObject.TryGetComponent<QuickConnecting>(out component) ? _linkCursor : (componentInParent2.Buildable.IsDraggable() ? _selectCursor : _blockedCursor));
			return true;
		}
		_mouseOverDecoration = null;
		base.Cursor = _blockedCursor;
		return false;
	}

	private void UpdateBuildableCursor(CursorManager cursorManager, Interaction interaction)
	{
		if (base.Cursor == _linkCursor && _mouseOverBuildable.TryReturnBuildableExtendable<EnergyGridBuildableComponent>(out var buildableExtendable))
		{
			_energyGridLinkCursorProperties.Initialize(buildableExtendable);
			_energyGridLinkCursorProperties.InitializeCursorState();
			_energyGridLinkCursorProperties.Activate(this);
			_connectingEnegryGridInProgress = true;
			return;
		}
		base.Cursor = _defaultCursor;
		if (_mouseOverBuildable.IsDraggable())
		{
			SetSelectedBuildable(_mouseOverBuildable);
			if (interaction == Interaction.Store)
			{
				RemoveSelectedBuildable(store: true);
			}
			return;
		}
		ListPool<VisualPrefab>.List blockingConstructions = ListPool<VisualPrefab>.Get();
		WalkwayPonton buildableExtendable3;
		Hookable buildableExtendable4;
		if (_mouseOverBuildable.TryReturnBuildableExtendable<WalkwaySegment>(out var buildableExtendable2))
		{
			buildableExtendable2.ReturnBlockingNeighbours(ref blockingConstructions);
		}
		else if (_mouseOverBuildable.TryReturnBuildableExtendable<WalkwayPonton>(out buildableExtendable3))
		{
			buildableExtendable3.ReturnBlockingNeighbours(ref blockingConstructions);
		}
		else if (_mouseOverBuildable.TryReturnBuildableExtendable<Hookable>(out buildableExtendable4))
		{
			buildableExtendable4.ReturnBlockingNeighbours(ref blockingConstructions);
		}
		if (_mouseOverBuildable.TryReturnBuildableExtendable<DecorationSlots>(out var buildableExtendable5))
		{
			buildableExtendable5.GetBlockingNeighbours(ref blockingConstructions);
		}
		if (blockingConstructions.Count > 0)
		{
			_blockingCoroutine = CoroutineMotor.StartRoutine(FlashRed(cursorManager, blockingConstructions, _blinkRedDuration, _blinkRedTimes));
		}
		blockingConstructions.Dispose();
	}

	private void SetSelectedBuildable(Buildable selected)
	{
		RemoveSelectedBuildable();
		if (selected.TryReturnBuildableExtendable<EnergyGridPole>(out var _))
		{
			_buildablePreviewStrategy = _energyPolePreviewStrategy.Activate(selected, _visualIndex, _previewSettings, out _constructionPreview, out _buildable);
			return;
		}
		if (selected.TryReturnBuildableExtendable<WalkwaySegment>(out var _) || selected.TryReturnBuildableExtendable<WalkwayPonton>(out var _))
		{
			_buildablePreviewStrategy = _lineConstructionPreviewStrategy.Activate(selected, _visualIndex, _previewSettings, out _constructionPreview, out _buildable);
			return;
		}
		_buildablePreviewStrategy = _singleConstructionPreviewStrategy.Activate(selected, _visualIndex, _previewSettings, out _constructionPreview, out _buildable);
		UpdateCanBeDeactivated(canBeDeactivated: false);
	}

	private void UpdateDecorationCursor(Interaction interaction)
	{
		if (base.Cursor == _linkCursor && _mouseOverDecoration.TryGetExtendable<EnergyGridDecorationComponent>(out var extendable))
		{
			_energyGridLinkCursorProperties.Initialize(extendable);
			_energyGridLinkCursorProperties.InitializeCursorState();
			_energyGridLinkCursorProperties.Activate(this);
			_connectingEnegryGridInProgress = true;
			return;
		}
		base.Cursor = _defaultCursor;
		if (_mouseOverDecoration.IsDraggable())
		{
			SetSelectedDecoration(_mouseOverDecoration);
			if (interaction == Interaction.Store)
			{
				RemoveSelectedBuildable(store: true);
			}
		}
	}

	private void SetSelectedDecoration(Decoration selected)
	{
		RemoveSelectedBuildable();
		if (selected.TryGetExtendable<EnergyGridPole>(out var _))
		{
			_buildablePreviewStrategy = _energyPolePreviewStrategy.Activate(selected, selected.Properties, _visualIndex, _previewSettings, out _constructionPreview, out _decoration);
		}
	}

	public void SetSelectedPlaceableProperties(IPlaceable placeable)
	{
		if (placeable is BuildableProperties properties)
		{
			SetSelectedBuildableProperties(properties);
		}
		else if (placeable is DecorationProperties properties2)
		{
			SetSelectedDecorationProperties(properties2);
		}
	}

	public void SetSelectedBuildableProperties(BuildableProperties properties, bool continuous = false)
	{
		RemoveSelectedBuildable(store: true, toggleCategory: false);
		if (Community.PlayerCommunity.GetStoredBuildable(properties, out var buildable))
		{
			if (properties.PlacementCursorProperties is EnergyPoleCursorProperties)
			{
				_buildablePreviewStrategy = _energyPolePreviewStrategy.Activate(buildable, _visualIndex, _previewSettings, out _constructionPreview, out _buildable);
			}
			else if (properties.Prefab.GetComponent<WalkwayPonton>() != null)
			{
				_buildablePreviewStrategy = _lineConstructionPreviewStrategy.Activate(buildable, properties, _visualIndex, _previewSettings, out _constructionPreview, out _buildable);
			}
			else
			{
				_buildablePreviewStrategy = _singleConstructionPreviewStrategy.Activate(buildable, _visualIndex, _previewSettings, out _constructionPreview, out _buildable);
				UpdateCanBeDeactivated(canBeDeactivated: false);
			}
			if (continuous && RewiredActions.IsContinuousBuilding())
			{
				_buildablePreviewStrategy.ContinuousBuilding();
			}
		}
	}

	public void SetSelectedDecorationProperties(DecorationProperties properties, bool continuous = false)
	{
		RemoveSelectedBuildable(store: true, toggleCategory: false);
		if (!Community.PlayerCommunity.GetStoredDecoration(properties, out var decoration))
		{
			if (properties is EnergyPoleDecorationProperties)
			{
				SetSelectedBuildableProperties(GameManager.Settings.BuildableSettings.EnergyPoleBuildableProperties, continuous);
			}
			return;
		}
		_buildablePreviewStrategy = _energyPolePreviewStrategy.Activate(decoration, properties, _visualIndex, _previewSettings, out _constructionPreview, out _decoration);
		if (continuous && RewiredActions.IsContinuousBuilding())
		{
			_buildablePreviewStrategy.ContinuousBuilding();
		}
	}

	private void RemoveSelectedBuildable(bool store = false, bool toggleCategory = true)
	{
		BuildingGrid.Disable();
		if ((bool)_buildable)
		{
			if (store)
			{
				_buildablePreviewStrategy.StoreBuildable(_buildable, toggleCategory);
			}
			_buildable = null;
		}
		else if (_decoration != null)
		{
			if (store)
			{
				_buildablePreviewStrategy.StoreDecoration(_decoration, toggleCategory);
			}
			_decoration = null;
		}
		if (_constructionPreview != null)
		{
			RemoveConstructionPreview(ref _constructionPreview);
		}
		_buildablePreviewStrategy = null;
	}

	private void MoveSelectedBuildable()
	{
		if (!_constructionPreview.CanPlace)
		{
			return;
		}
		if (_buildable != null)
		{
			BuildableProperties properties = _buildable.Properties;
			if (_buildablePreviewStrategy.MoveBuildable(ref _buildable, _constructionPreview))
			{
				RemoveSelectedBuildable();
				UpdateCanBeDeactivated(Community.PlayerCommunity.ReturnStoredBuildablesCount(onlyBuildings: true) == 0);
				SetSelectedBuildableProperties(properties, continuous: true);
			}
		}
		else if (_decoration != null)
		{
			DecorationProperties properties2 = _decoration.Properties;
			if (_buildablePreviewStrategy.MoveDecoration(_decoration, _constructionPreview))
			{
				RemoveSelectedBuildable();
				UpdateCanBeDeactivated(Community.PlayerCommunity.ReturnStoredBuildablesCount(onlyBuildings: true) == 0);
				SetSelectedDecorationProperties(properties2, continuous: true);
			}
		}
	}

	private void UpdateConstuctionPreview()
	{
		_buildablePreviewStrategy.UpdateConstructionPreview(ref _constructionPreview);
	}

	public override bool TryToDeactivate(CursorManager cursor)
	{
		return false;
	}

	public override bool DisplayExitPanel()
	{
		return false;
	}

	private void UpdateCanBeDeactivated(bool canBeDeactivated)
	{
		_canBeDeactivated = canBeDeactivated;
		OnChangeCanBeDeactivated.Invoke();
	}

	public void UpdateCanBeDeactivated()
	{
		UpdateCanBeDeactivated(Community.PlayerCommunity.ReturnStoredBuildablesCount(onlyBuildings: true) == 0);
	}

	public void DeactivateEnergyConnection()
	{
		_energyGridLinkCursorProperties.DeactivateImmediately();
		base.Cursor = _defaultCursor;
		_connectingEnegryGridInProgress = false;
	}

	public IEnumerator FlashRed(CursorManager cursor, List<VisualPrefab> constructions, float duration, int blinks)
	{
		TooltipPanel.ShowTooltip(this, delayed: false);
		SelectionLink tooltipSelectionLink = cursor.SelectionLink;
		ListPool<MeshRenderer>.List list = ListPool<MeshRenderer>.Get();
		VisualPrefab spawnedVisual = Construction.Townheart.Buildable.SpawnedVisual;
		foreach (VisualPrefab construction in constructions)
		{
			if (construction == spawnedVisual)
			{
				continue;
			}
			construction.GetComponentsInChildren(list);
			foreach (MeshRenderer item2 in list)
			{
				Material[] materials = item2.materials;
				foreach (Material item in materials)
				{
					_blockingMaterials.Add(item);
				}
			}
		}
		list.Dispose();
		for (int j = 0; j < 2 * blinks; j++)
		{
			foreach (Material blockingMaterial in _blockingMaterials)
			{
				ToggleMaterialColor(blockingMaterial, (j % 2 == 0) ? Color.red : Color.white);
			}
			yield return new WaitForSecondsRealtime(duration / (float)blinks);
		}
		_blockingCoroutine = null;
		_blockingMaterials.Clear();
		while ((bool)tooltipSelectionLink && cursor.SelectionLink == tooltipSelectionLink)
		{
			yield return null;
		}
		TooltipPanel.HideTooltip();
	}

	private void StopFlashRed()
	{
		if (_blockingCoroutine != null)
		{
			CoroutineMotor.StopRoutine(_blockingCoroutine);
		}
		_blockingCoroutine = null;
		foreach (Material blockingMaterial in _blockingMaterials)
		{
			ToggleMaterialColor(blockingMaterial, Color.white);
		}
		_blockingMaterials.Clear();
		TooltipPanel.HideTooltip();
	}

	private void ToggleMaterialColor(Material material, Color color)
	{
		material.color = color;
		if (material.HasColor("_DiffuseXColor"))
		{
			material.SetColor("_DiffuseXColor", color);
		}
		if (material.HasColor("_DiffuseRColor"))
		{
			material.SetColor("_DiffuseRColor", color);
		}
		if (material.HasColor("_DiffuseGColor"))
		{
			material.SetColor("_DiffuseGColor", color);
		}
		if (material.HasColor("_DiffuseBColor"))
		{
			material.SetColor("_DiffuseBColor", color);
		}
		if (material.HasColor("_Color1"))
		{
			material.SetColor("_Color1", color);
		}
	}

	public string GetTooltip(TooltipBuilder tooltipBuilder)
	{
		return _blockingText;
	}

	public Color GetColor(TooltipBuilder tooltipBuilder)
	{
		return _blockingColor;
	}

	private bool TryReturnInteraction(out Interaction interaction)
	{
		if (GetInteract())
		{
			interaction = Interaction.Pickup;
		}
		else if (WasCanceled())
		{
			interaction = Interaction.Store;
		}
		else
		{
			interaction = Interaction.None;
		}
		return interaction != Interaction.None;
	}

	private bool WasCanceled()
	{
		if (GetCancelDown())
		{
			_cancelDownCameraPosition = Camera.main.transform.position;
		}
		else if (GetCancel())
		{
			return Mathf.Approximately(Vector3.Distance(_cancelDownCameraPosition, Camera.main.transform.position), 0f);
		}
		return false;
	}
}
