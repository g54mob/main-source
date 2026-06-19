using Pug.UnityExtensions;
using PugTilemap;
using UnityEngine;

public class HostileCreatureProximitySensor : EntityMonoBehaviour
{
	private int prevState;

	public override void OnOccupied()
	{
		base.OnOccupied();
		prevState = base.variation;
		if (prevState == 1)
		{
			spriteObjects[0].emissiveColor = new Color(1f, 1f, 1f, 1f);
		}
		else
		{
			spriteObjects[0].emissiveColor = new Color(0f, 0f, 0f, 1f);
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
		int num = base.variation;
		if (prevState != num)
		{
			prevState = num;
			if (num == 1)
			{
				spriteObjects[0].emissiveColor = new Color(1f, 1f, 1f, 1f);
				AudioManager.SfxFollowTransform(SfxID.proximity_sensor_set, base.transform, 0.15f, 1f, 0.08f, reuse: true, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 10f, 9f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
			}
			else
			{
				spriteObjects[0].emissiveColor = new Color(0f, 0f, 0f, 1f);
				AudioManager.SfxFollowTransform(SfxID.proximity_sensor_off, base.transform, 0.05f, 0.9f, 0.08f, reuse: true, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 10f, 9f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
			}
		}
	}
}
