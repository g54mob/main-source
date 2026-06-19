using Pug.Conversion;
using UnityEngine;

public class IdleEmoteStateConverter : SingleAuthoringComponentConverter<IdleEmoteStateAuthoring>
{
	protected override void Convert(IdleEmoteStateAuthoring authoring)
	{
		EnsureHasComponent<StateInfoCD>();
		EnsureHasComponent<IdleEmoteStateCD>();
		SetProperty("IdleEmote/minCooldown", authoring.minCooldown);
		SetProperty("IdleEmote/maxCooldown", authoring.maxCooldown);
		IdleEmoteAnimationData[] array = new IdleEmoteAnimationData[authoring.emoteAnimations.Count];
		for (int i = 0; i < authoring.emoteAnimations.Count; i++)
		{
			array[i] = new IdleEmoteAnimationData
			{
				animationId = Animator.StringToHash(authoring.emoteAnimations[i].animation),
				preIdleMinDuration = authoring.emoteAnimations[i].preIdleMinDuration,
				preIdleMaxDuration = authoring.emoteAnimations[i].preIdleMaxDuration,
				duration = authoring.emoteAnimations[i].duration,
				mustBeOnWalkableGround = authoring.emoteAnimations[i].mustBeOnWalkableGround
			};
		}
		SetPropertyList("IdleEmote/animations", array);
	}
}
