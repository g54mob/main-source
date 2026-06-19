using Pug.Automation;
using Pug.UnityExtensions;
using PugTilemap;
using UnityEngine;

public class Turret : EntityMonoBehaviour
{
	private int prevVariation;

	private float lastTriggerTime;

	private float timeBetweenAttacks;

	protected bool hasElectricity;

	public override void OnOccupied()
	{
		base.OnOccupied();
		prevVariation = -1;
	}

	protected override void OnShow()
	{
		hasElectricity = EntityUtility.HasComponentData<ElectricityCD>(base.entity, base.world);
		if (hasElectricity)
		{
			Manager.multiMap.SetHiddenTile(base.WorldPosition.RoundToInt2(), 4, TileType.circuitPlate, 0);
		}
		base.OnShow();
	}

	protected override void OnHide()
	{
		if (hasElectricity)
		{
			Manager.multiMap.ClearHiddenTileOfType(base.WorldPosition.RoundToInt2(), TileType.circuitPlate);
		}
		base.OnHide();
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		UpdateVisuals();
	}

	private void UpdateVisuals()
	{
		int num = base.variation;
		if (animator != null && num != prevVariation)
		{
			XScaler.localScale = new Vector3((num != 3) ? 1 : (-1), 1f, 1f);
			switch (num)
			{
			case 0:
				animator.SetFloat(1116435161, 1f);
				break;
			case 1:
				animator.SetFloat(1116435161, 0f);
				break;
			case 2:
				animator.SetFloat(1116435161, -1f);
				break;
			case 3:
				animator.SetFloat(1116435161, 0f);
				break;
			}
			prevVariation = num;
			animator.Update(Time.deltaTime);
		}
	}

	protected override bool ShouldPlayAnimTrigger(int animID)
	{
		if (animID != 1203776827)
		{
			return base.ShouldPlayAnimTrigger(animID);
		}
		return false;
	}

	private void AE_AnticipationSound()
	{
		AudioManager.Sfx(SfxID.guncock, base.transform.position, 0.2f, 0.8f, 0.05f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true);
		AudioManager.Sfx(SfxID.rockscrape, base.transform.position, 0.5f, 0.8f, 0.05f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true);
	}

	public virtual void AE_AttackEffects()
	{
		AudioManager.Sfx(SfxID.slingshotImpact, base.transform.position, 0.5f, 0.7f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
		AudioManager.Sfx(SfxID.toolbreak, base.transform.position, 0.5f, 0.7f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true);
		AudioManager.Sfx(SfxID.bow, base.transform.position, 0.8f, 1f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true);
		Manager.effects.PlayPuff(PuffID.AncientSmoke, base.transform.position, 6);
	}
}
