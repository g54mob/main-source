using Pug.Conversion;
using UnityEngine;

public class CombatEmoteStateConverter : SingleAuthoringComponentConverter<CombatEmoteStateAuthoring>
{
	protected override void Convert(CombatEmoteStateAuthoring authoring)
	{
		EnsureHasComponent<StateInfoCD>();
		EnsureHasComponent<CombatEmoteStateCD>();
		EnsureHasComponent<IsInCombatCD>();
		SetProperty("CombatEmote/minCooldown", authoring.minCooldown);
		SetProperty("CombatEmote/maxCooldown", authoring.maxCooldown);
		SetProperty("CombatEmote/emoteInstantlyChance", authoring.emoteInstantlyChance);
		CombatEmoteAnimationData[] array = new CombatEmoteAnimationData[authoring.emoteAnimations.Count];
		for (int i = 0; i < authoring.emoteAnimations.Count; i++)
		{
			array[i] = new CombatEmoteAnimationData
			{
				animationId = Animator.StringToHash(authoring.emoteAnimations[i].animation),
				duration = authoring.emoteAnimations[i].duration,
				preCombatMinDuration = authoring.emoteAnimations[i].preCombatMinDuration,
				preCombatMaxDuration = authoring.emoteAnimations[i].preCombatMaxDuration
			};
		}
		SetPropertyList("CombatEmote/animations", array);
	}
}
