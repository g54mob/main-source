using PlayerState;
using UnityEngine;

public class UseOffHandButton : IngameButtonHint
{
	public SpriteRenderer icon;

	public GameObject textContainer;

	private bool _initialized;

	private bool _initializedSprite;

	private Vector3 _currentScale;

	private bool _currentActive;

	private ContainedObjectsBuffer _currentContainedObject;

	private bool _hasValidSprite;

	public override bool isButtonActive => _currentActive;

	public void Awake()
	{
		UpdateVisuals(force: true);
	}

	private bool CheckAndUpdateSprite()
	{
		ContainedObjectsBuffer offHand = Manager.main.player.GetOffHand();
		if (!_initializedSprite || !_currentContainedObject.Equals(offHand))
		{
			if (offHand.objectData.objectID != ObjectID.None && PugDatabase.TryGetComponent<OffHandCD>(offHand.objectData, out var component))
			{
				OffHandMechanic mechanic = component.mechanic;
				if (mechanic != OffHandMechanic.None && mechanic != OffHandMechanic.Bait)
				{
					Sprite iconOverride = Manager.ui.itemOverridesTable.GetIconOverride(offHand.objectData, getSmallIcon: false);
					if (iconOverride != null)
					{
						icon.sprite = iconOverride;
					}
					else
					{
						icon.sprite = PugDatabase.GetObjectInfo(offHand.objectID, offHand.variation).icon;
					}
					goto IL_00b7;
				}
			}
			icon.sprite = null;
			goto IL_00b7;
		}
		goto IL_00f5;
		IL_00f5:
		return _hasValidSprite;
		IL_00b7:
		_currentContainedObject = offHand;
		_hasValidSprite = icon.sprite != null;
		if (_hasValidSprite)
		{
			Manager.ui.ApplyAnyIconGradientMap(offHand, icon);
		}
		_initializedSprite = true;
		goto IL_00f5;
	}

	public override void UpdateVisuals()
	{
		UpdateVisuals(force: false);
	}

	private void UpdateVisuals(bool force)
	{
		PlayerController player = Manager.main.player;
		Vector3 vector = Manager.ui.CalcGameplayUITargetScaleMultiplier();
		if (!_initialized || vector != _currentScale || force)
		{
			base.transform.localScale = vector;
			_currentScale = vector;
		}
		bool flag = !Manager.ui.isAnyInventoryShowing && !Manager.ui.isShowingMap && player != null && !player.guestMode && !EntityUtility.GetComponentData<PlayerStateCD>(player.entity, player.world).HasAnyState(PlayerStateEnum.MinecartRiding | PlayerStateEnum.BoatRiding | PlayerStateEnum.VehicleRiding) && !player.instrumentHandler.IsPlayingInstrument && player.GetEquippedSlot() != null && CheckAndUpdateSprite();
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
