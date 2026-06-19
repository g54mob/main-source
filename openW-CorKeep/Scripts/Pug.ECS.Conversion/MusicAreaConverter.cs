using Pug.Conversion;

public class MusicAreaConverter : SingleAuthoringComponentConverter<MusicAreaAuthoring>
{
	protected override void Convert(MusicAreaAuthoring authoring)
	{
		AddComponentData(new MusicAreaCD
		{
			activeWhenEntityIsInCombat = authoring.activeWhenEntityIsInCombat,
			deactivateWhenEntityIsInState = authoring.deactivateWhenEntityIsInState,
			stateToDeactivateIn = authoring.stateToDeactivateIn,
			musicRosterType = authoring.musicRosterType,
			fadeTime = authoring.fadeTime,
			playOtherMusicWhenInCombat = authoring.playOtherMusicWhenInCombat,
			otherMusicRosterType = authoring.otherMusicRosterType,
			originalRosterType = authoring.musicRosterType,
			startAtDistance = authoring.startAtDistance,
			stopAtDistance = authoring.stopAtDistance,
			minCooldownToPlay = authoring.minCooldownToPlay,
			maxCooldownToPlay = authoring.maxCooldownToPlay,
			isInactive = authoring.isInactive,
			prio = authoring.prio,
			originalFadeTime = authoring.fadeTime
		});
	}
}
