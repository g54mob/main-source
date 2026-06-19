using Unity.Entities;
using UnityEngine;

public class ResizeButton : IngameButtonHint
{
	public GameObject textContainer;

	public SpriteRenderer icon;

	private bool _initialized;

	private Vector3 _currentScale;

	private bool _currentActive;

	public override bool isButtonActive => _currentActive;

	public void Awake()
	{
		UpdateVisuals();
	}

	public override void UpdateVisuals()
	{
		Vector3 vector = Manager.ui.CalcGameplayUITargetScaleMultiplier();
		if (!_initialized || _currentScale != vector)
		{
			base.transform.localScale = vector;
			_currentScale = vector;
		}
		PlayerController player = Manager.main.player;
		bool flag = false;
		if (player != null)
		{
			Entity equipmentPrefab = EntityUtility.GetComponentData<EquippedObjectCD>(player.entity, player.world).equipmentPrefab;
			ComponentLookup<ResizableTileSizeCD> componentLookup = player.querySystem.GetComponentLookup<ResizableTileSizeCD>(isReadOnly: true);
			flag = !player.guestMode && !Manager.ui.isAnyInventoryShowing && !Manager.ui.isShowingMap && player != null && !player.instrumentHandler.IsPlayingInstrument && PlacementHandler.PlacementCanBeResized(equipmentPrefab, componentLookup) && player.CurrentStateAllowInteractions(isTryingToUseSecondInteract: true) && !player.RotateInteractionIsConflicting();
		}
		if (!_initialized || _currentActive != flag)
		{
			textContainer.SetActive(flag);
			icon.enabled = flag;
			_currentActive = flag;
		}
		_initialized = true;
		base.LateUpdate();
	}
}
