using System.Collections.Generic;
using UnityEngine;

public class PassageCraftingStatue : CraftingBuilding
{
	private PoolableAudioSource _ambienceSoundPool;

	public SfxUnityInspectorFriendlyID ambienceSound;

	public List<SfxUnityInspectorFriendlyID> interactSounds;

	protected override void OnShow()
	{
		_ambienceSoundPool = AudioManager.Sfx(Manager.audio.InspectorFriendlySfxIDToSfxID(ambienceSound), base.transform.position, 0.6f, 1f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: true, 5f, 5f);
		base.OnShow();
	}

	protected override void OnHide()
	{
		if (_ambienceSoundPool != null)
		{
			_ambienceSoundPool.FadeOutAndStop();
		}
		base.OnHide();
	}

	public override void Use()
	{
		base.Use();
		int index = Random.Range(0, interactSounds.Count);
		AudioManager.SfxFollowTransform(Manager.audio.InspectorFriendlySfxIDToSfxID(interactSounds[index]), base.transform, 1f, 1f, 0.05f);
	}
}
