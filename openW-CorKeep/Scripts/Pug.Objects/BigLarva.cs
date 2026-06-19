#define PUG_ACHIEVEMENTS
using System.Collections.Generic;
using UnityEngine;

public class BigLarva : EntityMonoBehaviour
{
	public List<Texture2D> GradientMap;

	protected override bool updateAnimOrientation => true;

	protected override bool updateAnimMovement => true;

	protected override bool updateAnimMovementSpeed => true;

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == -414722770)
		{
			Manager.effects.PlayPuff(PuffID.MediumPurplePuff, base.transform.position, 40);
			if (hasShadow)
			{
				shadow.SetActive(value: false);
			}
		}
	}

	public void OnInteract()
	{
		Emote.SpawnEmoteText(center, Emote.EmoteType.LarvaEmote);
		AudioManager.Sfx(SfxID.larvaAnticipation, base.transform.position, 0.6f, 0.8f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true);
		Manager.achievements.TriggerAchievement(AchievementID.TalkToBigLarva);
	}
}
