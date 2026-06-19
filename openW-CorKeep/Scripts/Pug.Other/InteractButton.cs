using Interaction;
using PlayerState;
using Pug.UnityExtensions;
using Unity.Entities;
using UnityEngine;

public class InteractButton : IngameButtonHint
{
	public SpriteRenderer icon;

	public GameObject textContainer;

	public LightUpHintIcon lightUpHintIcon;

	public override bool isButtonActive => icon.enabled;

	public override void UpdateVisuals()
	{
		base.transform.localScale = Manager.ui.CalcGameplayUITargetScaleMultiplier();
		PlayerController player = Manager.main.player;
		if (!Manager.ui.isAnyInventoryShowing && !Manager.ui.isShowingMap && !(player == null) && !player.instrumentHandler.IsPlayingInstrument && !player.guestMode)
		{
			Entity currentClosestInteractable = EntityUtility.GetComponentData<InteractorCD>(player.entity, player.world).currentClosestInteractable;
			PlayerStateCD componentData = EntityUtility.GetComponentData<PlayerStateCD>(player.entity, player.world);
			bool flag = currentClosestInteractable != Entity.Null || componentData.HasAnyState(PlayerStateEnum.MinecartRiding | PlayerStateEnum.BoatRiding | PlayerStateEnum.VehicleRiding) || player.playerCanInteractWithGreatWall;
			icon.enabled = true;
			icon.SetAlpha(flag ? 1f : 0.1f);
			textContainer.SetActive(flag);
		}
		else
		{
			icon.enabled = false;
			textContainer.SetActive(value: false);
		}
		base.LateUpdate();
	}

	public void ShowLightUpHint()
	{
		lightUpHintIcon.ShowLightUpHint();
	}

	public void HideLightUpHint()
	{
		lightUpHintIcon.HideLightUpHint();
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
