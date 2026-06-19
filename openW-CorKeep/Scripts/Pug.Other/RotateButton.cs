using Pug.Properties;
using Unity.Entities;
using UnityEngine;

public class RotateButton : IngameButtonHint
{
	public GameObject textContainer;

	public SpriteRenderer icon;

	private bool _initialized;

	private Vector3 _currentScale;

	private bool _currentActive;

	public override bool isButtonActive => _currentActive;

	public void Awake()
	{
		UpdateVisuals(force: true);
	}

	public override void UpdateVisuals()
	{
		UpdateVisuals(force: false);
	}

	private void UpdateVisuals(bool force)
	{
		Vector3 vector = Manager.ui.CalcGameplayUITargetScaleMultiplier();
		if (!_initialized || _currentScale != vector || force)
		{
			base.transform.localScale = vector;
			_currentScale = vector;
		}
		PlayerController player = Manager.main.player;
		bool flag = false;
		if (player != null)
		{
			Entity equipmentPrefab = EntityUtility.GetComponentData<EquippedObjectCD>(player.entity, player.world).equipmentPrefab;
			ComponentLookup<DirectionBasedOnVariationCD> componentLookup = player.querySystem.GetComponentLookup<DirectionBasedOnVariationCD>(isReadOnly: true);
			ComponentLookup<ObjectPropertiesCD> componentLookup2 = player.querySystem.GetComponentLookup<ObjectPropertiesCD>(isReadOnly: true);
			ComponentLookup<DirectionCD> componentLookup3 = player.querySystem.GetComponentLookup<DirectionCD>(isReadOnly: true);
			flag = !player.guestMode && !Manager.ui.isAnyInventoryShowing && !Manager.ui.isShowingMap && player != null && !player.instrumentHandler.IsPlayingInstrument && player.GetEquippedSlot() is PlaceObjectSlot && (PlacementHandler.ObjectCanBeRotated(equipmentPrefab, componentLookup, componentLookup2, componentLookup3) || PlacementHandler.ObjectCanBeToggledToNewNonRotationOption(equipmentPrefab, componentLookup2)) && player.CurrentStateAllowInteractions(isTryingToUseSecondInteract: true) && !player.RotateInteractionIsConflicting();
		}
		if (!_initialized || _currentActive != flag || force)
		{
			textContainer.SetActive(flag);
			icon.enabled = flag;
			_currentActive = flag;
		}
		_initialized = true;
		base.LateUpdate();
	}
}
