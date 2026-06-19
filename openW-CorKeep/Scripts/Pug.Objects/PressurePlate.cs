using Pug.UnityExtensions;
using PugTilemap;
using UnityEngine;

public class PressurePlate : EntityMonoBehaviour
{
	private bool playerIsOn;

	private bool playerIsOnPrev;

	private float distanceToActivateStandingOn;

	public override void OnOccupied()
	{
		base.OnOccupied();
		playerIsOn = false;
		playerIsOnPrev = false;
		if (EntityUtility.TryGetComponentData<ChangeVariationWhenObjectNearbyCD>(base.entity, base.world, out var value))
		{
			distanceToActivateStandingOn = value.radius;
		}
	}

	protected override void OnShow()
	{
		Manager.multiMap.SetHiddenTile(base.WorldPosition.RoundToInt2(), 4, TileType.circuitPlate, 0);
		base.OnShow();
	}

	protected override void OnHide()
	{
		Manager.multiMap.ClearHiddenTileOfType(base.WorldPosition.RoundToInt2(), TileType.circuitPlate);
		base.OnHide();
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (!(Time.timeScale > 0f))
		{
			return;
		}
		if (playerIsOnPrev != playerIsOn)
		{
			if (playerIsOn)
			{
				animator.SetTrigger(2039883312);
				AudioManager.SfxFollowTransform(SfxID.shoop, base.transform, 1f, 1.1f, 0.05f, reuse: true, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
			}
			else
			{
				animator.SetTrigger(2043490037);
				AudioManager.SfxFollowTransform(SfxID.shoop, base.transform, 1f, 0.9f, 0.05f, reuse: true, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
			}
			playerIsOnPrev = playerIsOn;
		}
		playerIsOn = false;
	}

	public override void OnPlayerTrigger(PlayerController pc)
	{
		if (!EntityUtility.IsComponentEnabled<GodModeCD>(pc.entity, pc.world))
		{
			base.OnPlayerTrigger(pc);
			float magnitude = (pc.RenderPosition - base.RenderPosition).magnitude;
			if (distanceToActivateStandingOn > magnitude)
			{
				playerIsOn = true;
			}
		}
	}
}
