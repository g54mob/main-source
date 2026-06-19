using Pug.Sprite;
using Pug.UnityExtensions;
using PugTilemap;
using UnityEngine;

public class Lever : EntityMonoBehaviour
{
	public SpriteObject baseSprite;

	public SpriteObject leverSprite;

	private int prevState;

	public override void OnOccupied()
	{
		base.OnOccupied();
		prevState = base.variation;
		if (prevState == 1)
		{
			baseSprite.emissiveColor = new Color(1f, 1f, 1f, 1f);
			leverSprite.SetVariantByIndex(2);
		}
		else
		{
			baseSprite.emissiveColor = new Color(0f, 0f, 0f, 1f);
			leverSprite.SetVariantByIndex(1);
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
				baseSprite.emissiveColor = new Color(1f, 1f, 1f, 1f);
				leverSprite.SetVariantByIndex(2);
				AudioManager.SfxFollowTransform(SfxID.shoop, base.transform, 1f, 1.1f, 0.05f, reuse: true, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
			}
			else
			{
				baseSprite.emissiveColor = new Color(0f, 0f, 0f, 1f);
				leverSprite.SetVariantByIndex(1);
				AudioManager.SfxFollowTransform(SfxID.shoop, base.transform, 1f, 0.9f, 0.05f, reuse: true, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
			}
		}
	}
}
