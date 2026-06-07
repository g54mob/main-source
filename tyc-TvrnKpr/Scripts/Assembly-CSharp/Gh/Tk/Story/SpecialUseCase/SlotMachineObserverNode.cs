using UnityEngine;
using UnityEngine.Scripting;
using XNode;

namespace Gh.Tk.Story.SpecialUseCase
{
	[NodeTint("#1B90AD")]
	[InitializeOnGameStarted]
	public class SlotMachineObserverNode : ConnectedStoryNode
	{
		public enum CharacterMode
		{
			UseAllCharacters = 0,
			UseSameCharacter = 1,
			UseChosenActor = 2
		}

		public int losses;

		public int wins;

		[Range(-1f, 1f)]
		public float winRateThreshold;

		public bool mustBeAboveThreshold;

		public bool resetIfRateDropsBelowThreshold;

		public bool mustBeStreak;

		public CharacterMode characterMode;

		public bool ignoreActorsUsedInStories;

		private string _winLossScoreKey;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void OnSlotsGamePlayed(object sender, SlotsGameEventArgs e)
		{
		}

		public void RecordGame(ActiveStory story, Actor actor, float winRate, bool didWin)
		{
		}

		private void ContinueStory(ActiveStory story, int actorDataId)
		{
		}
	}
}
