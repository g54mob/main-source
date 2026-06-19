using CommandMinion;
using PlayerState;
using UnityEngine;

public class UseWeaponPrimaryButton : IngameButtonHint
{
	public SpriteRenderer icon;

	public GameObject textContainer;

	public Sprite commandMinionSprite;

	private Vector3 _currentScale;

	private bool _currentActive;

	private bool _hasValidSprite;

	private ContainedObjectsBuffer _currentContainedObject;

	private void Awake()
	{
		UpdateVisuals(force: true);
	}

	public override void UpdateVisuals()
	{
		UpdateVisuals(force: false);
	}

	public void UpdateVisuals(bool force)
	{
		UpdateScale(force);
	}

	private void UpdateScale(bool force)
	{
		Vector3 vector = Manager.ui.CalcGameplayUITargetScaleMultiplier();
		if (vector != _currentScale || force)
		{
			base.transform.localScale = vector;
			_currentScale = vector;
		}
		PlayerController player = Manager.main.player;
		bool flag = !Manager.ui.isAnyInventoryShowing && !Manager.ui.isShowingMap && player != null && !player.guestMode && !EntityUtility.GetComponentData<PlayerStateCD>(player.entity, player.world).HasAnyState(PlayerStateEnum.MinecartRiding | PlayerStateEnum.BoatRiding | PlayerStateEnum.VehicleRiding) && !player.instrumentHandler.IsPlayingInstrument;
		if (flag)
		{
			flag = TryUpdateSprite(force);
		}
		if (flag != _currentActive || force)
		{
			textContainer.SetActive(flag);
			icon.gameObject.SetActive(flag);
			_currentActive = flag;
		}
	}

	private bool TryUpdateSprite(bool force)
	{
		EquipmentSlot equippedSlot = Manager.main.player.GetEquippedSlot();
		if (equippedSlot == null)
		{
			return false;
		}
		if (!force && _currentContainedObject.Equals(equippedSlot.containedObject))
		{
			return _hasValidSprite;
		}
		if (equippedSlot.objectData.objectID == ObjectID.None || !PugDatabase.HasComponent<CommandMinionWeaponCD>(equippedSlot.objectData))
		{
			icon.sprite = null;
		}
		else
		{
			icon.sprite = commandMinionSprite;
		}
		_currentContainedObject = equippedSlot.containedObject;
		_hasValidSprite = icon.sprite != null;
		if (_hasValidSprite)
		{
			Manager.ui.ApplyAnyIconGradientMap(equippedSlot.containedObject, icon);
		}
		return _hasValidSprite;
	}
}
