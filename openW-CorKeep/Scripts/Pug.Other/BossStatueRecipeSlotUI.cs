using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

public class BossStatueRecipeSlotUI : RecipeSlotUI
{
	private bool wasAlreadyActivatedOnShow;

	private TimerSimple revealDelayTimer;

	private bool isActivated
	{
		get
		{
			if (base.activeCraftingHandler != null && base.activeCraftingHandler.inventoryHandler != null)
			{
				return base.activeCraftingHandler.inventoryHandler.HasObject(0);
			}
			return false;
		}
	}

	protected override bool IsCraftingAllowed => isActivated;

	private void OnEnable()
	{
		wasAlreadyActivatedOnShow = isActivated;
		revealDelayTimer = default(TimerSimple);
		if (isActivated)
		{
			SetAnimationTrigger(-714038971);
		}
		else
		{
			SetAnimationTrigger(243082084);
		}
	}

	public override void UpdateSlot()
	{
		base.UpdateSlot();
		if (!isActivated)
		{
			icon.color = new Color(0f, 0f, 0f, 0.5f);
		}
		if (!wasAlreadyActivatedOnShow && isActivated)
		{
			wasAlreadyActivatedOnShow = isActivated;
			revealDelayTimer.Start((float)visibleSlotIndex * 0.5f);
		}
		if (revealDelayTimer.isRunning && revealDelayTimer.isTimerElapsed)
		{
			revealDelayTimer.Stop();
			SetAnimationTrigger(-1638894518);
		}
	}

	private void Reveal_AE()
	{
		Manager.effects.PlayPuff(PuffID.UISlotDust, base.transform.position, 20);
		Manager.effects.PlayPuff(PuffID.CoreUISlotFilled, base.transform.position, 20);
		AudioManager.SfxFollowTransform(SfxID.wall, base.transform, 1f, 1.2f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
	}

	public override void OnLeftClicked(bool mod1, bool mod2)
	{
		if (isActivated)
		{
			base.OnLeftClicked(mod1, mod2);
		}
	}

	public override void OnRightClicked(bool mod1, bool mod2)
	{
		if (isActivated)
		{
			base.OnRightClicked(mod1, mod2);
		}
	}

	public override ContainedObjectsBuffer GetContainedObject()
	{
		if (!isActivated)
		{
			return default(ContainedObjectsBuffer);
		}
		return base.GetContainedObject();
	}

	public override TextAndFormatFields GetHoverTitle()
	{
		if (!isActivated)
		{
			return null;
		}
		return base.GetHoverTitle();
	}

	public override List<TextAndFormatFields> GetHoverDescription()
	{
		if (!isActivated)
		{
			return null;
		}
		return base.GetHoverDescription();
	}

	public override List<TextAndFormatFields> GetHoverStats(bool previewReinforced)
	{
		if (!isActivated)
		{
			return null;
		}
		return base.GetHoverStats(previewReinforced);
	}

	public override List<PugDatabase.MaterialInfo> GetRequiredMaterials(bool isRepairing, bool isReinforcing)
	{
		if (!isActivated)
		{
			return null;
		}
		return base.GetRequiredMaterials(isRepairing, isReinforcing);
	}

	public override bool GetDurabilityOrFullnessOrXp(out int durability, out int maxDurability, out AmountType amountType)
	{
		durability = 0;
		maxDurability = 0;
		amountType = AmountType.Amount;
		if (!isActivated)
		{
			return false;
		}
		return base.GetDurabilityOrFullnessOrXp(out durability, out maxDurability, out amountType);
	}
}
