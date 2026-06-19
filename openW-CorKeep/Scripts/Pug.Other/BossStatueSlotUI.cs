#define PUG_RGB_ENABLED
using System;
using System.Collections.Generic;
using Interaction;
using Pug.UnityExtensions;
using UnityEngine;

public class BossStatueSlotUI : InventorySlotUI
{
	[Serializable]
	public class CrystalIDToSpriteBackground
	{
		public ObjectID crystalID;

		public Sprite sprite;
	}

	public SpriteRenderer lockedBorder;

	public Color inactiveColor;

	public Color activeColor;

	public SpriteRenderer glow;

	private bool crystalPlaced;

	public List<CrystalIDToSpriteBackground> crystalBackgroundIcons;

	private float activatedAlpha;

	public void OnEnable()
	{
		bool flag = HasObject();
		activatedAlpha = (flag ? 1 : 0);
		crystalPlaced = flag;
		PlayerController player = Manager.main.player;
		EntityUtility.TryGetComponentData<InteractorCD>(player.entity, player.world, out var value);
		EntityUtility.TryGetComponentData<BossStatueCD>(value.currentClosestInteractable, player.world, out var value2);
		ObjectID acceptsCrystalID = value2.acceptsCrystalID;
		Sprite sprite = null;
		foreach (CrystalIDToSpriteBackground crystalBackgroundIcon in crystalBackgroundIcons)
		{
			if (crystalBackgroundIcon.crystalID == acceptsCrystalID)
			{
				sprite = crystalBackgroundIcon.sprite;
				break;
			}
		}
		background.sprite = sprite;
	}

	protected override bool RenderAmountNumber(int amount)
	{
		return false;
	}

	public override void UpdateSlot()
	{
		base.UpdateSlot();
		UpdateAncientCrystalHint();
	}

	public void UpdateAncientCrystalHint()
	{
		if (icon.sprite == null)
		{
			activatedAlpha -= Time.deltaTime;
		}
		else
		{
			activatedAlpha += Time.deltaTime;
		}
		activatedAlpha = Mathf.Clamp01(activatedAlpha);
		lockedBorder.SetAlpha(activatedAlpha);
		if (!crystalPlaced && icon.sprite != null)
		{
			crystalPlaced = true;
			SetAnimationTrigger(2039883312);
			AudioManager.SfxFollowTransform(SfxID.shoop, base.transform, 1f, 1f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
			AudioManager.SfxFollowTransform(SfxID.Bell, base.transform, 1f, 1f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
			Manager.rgb.TriggerEvent(RGBManager.Event.InsertBossCrystal);
		}
		if (HasObject())
		{
			glow.gameObject.SetActive(value: true);
		}
		else
		{
			glow.gameObject.SetActive(value: false);
		}
	}

	public override HoverWindowAlignment GetHoverWindowAlignment()
	{
		if (crystalPlaced)
		{
			return base.GetHoverWindowAlignment();
		}
		return HoverWindowAlignment.BOTTOM_RIGHT_OF_CURSOR;
	}
}
