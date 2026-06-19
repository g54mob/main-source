using PlayerState;
using UnityEngine;

public class UseWeaponSecondaryButton : IngameButtonHint
{
	public SpriteRenderer icon;

	public GameObject textContainer;

	private bool _initialized;

	private Vector3 _currentScale;

	private bool _currentActive;

	private bool _spriteInitialized;

	private ContainedObjectsBuffer _currentContainedObject;

	private bool _hasValidSprite;

	public override bool isButtonActive => _currentActive;

	public void Awake()
	{
		UpdateVisuals(force: true);
	}

	private bool CheckAndUpdateSprite()
	{
		EquipmentSlot equippedSlot = Manager.main.player.GetEquippedSlot();
		if (equippedSlot == null)
		{
			return false;
		}
		if (!_spriteInitialized || !_currentContainedObject.Equals(equippedSlot.containedObject))
		{
			if (equippedSlot.objectData.objectID == ObjectID.None || !PugDatabase.TryGetComponent<SecondaryUseCD>(equippedSlot.objectData, out var component) || !component.hasSecondaryUse)
			{
				icon.sprite = null;
			}
			else
			{
				Sprite iconOverride = Manager.ui.itemOverridesTable.GetIconOverride(equippedSlot.objectData, getSmallIcon: false);
				if (iconOverride != null)
				{
					icon.sprite = iconOverride;
				}
				else
				{
					icon.sprite = PugDatabase.GetObjectInfo(equippedSlot.objectData.objectID, equippedSlot.objectData.variation).icon;
				}
			}
			_currentContainedObject = equippedSlot.containedObject;
			_hasValidSprite = icon.sprite != null;
			if (_hasValidSprite)
			{
				Manager.ui.ApplyAnyIconGradientMap(equippedSlot.containedObject, icon);
			}
			_spriteInitialized = true;
		}
		return _hasValidSprite;
	}

	public override void UpdateVisuals()
	{
		UpdateVisuals(force: false);
	}

	private void UpdateVisuals(bool force)
	{
		PlayerController player = Manager.main.player;
		Vector3 vector = Manager.ui.CalcGameplayUITargetScaleMultiplier();
		if (vector != _currentScale || force)
		{
			base.transform.localScale = vector;
			_currentScale = vector;
		}
		bool flag = !Manager.ui.isAnyInventoryShowing && !Manager.ui.isShowingMap && player != null && !player.guestMode && !EntityUtility.GetComponentData<PlayerStateCD>(player.entity, player.world).HasAnyState(PlayerStateEnum.MinecartRiding | PlayerStateEnum.BoatRiding | PlayerStateEnum.VehicleRiding) && !player.instrumentHandler.IsPlayingInstrument && CheckAndUpdateSprite();
		if (!_initialized || flag != _currentActive || force)
		{
			textContainer.SetActive(flag);
			icon.gameObject.SetActive(flag);
			_currentActive = flag;
		}
		_initialized = true;
		base.LateUpdate();
	}

	public override void OnDeselected(bool playEffect = true)
	{
	}

	public override void OnLeftClicked(bool mod1, bool mod2)
	{
	}

	public override void OnRightClicked(bool mod1, bool mod2)
	{
	}

	public override void OnSelected()
	{
	}
}
