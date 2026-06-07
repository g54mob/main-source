using UnityEngine;
using UnityEngine.Scripting;

namespace Gh.Tk.Story.Actions
{
	[InitializeOnGameStarted]
	public class PlayThemeMusicActionNode : AudioActionBaseNode
	{
		[Tooltip("Any will use the default music. Otherwise, specify the level to use the music variation for.")]
		public GameLevel level;

		public bool loopTrack;

		private string TrackPlayedKey => null;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		public override void OnTrigger(ActiveStory story)
		{
		}

		private void PlayTrackInternal(ActiveStory story)
		{
		}
	}
}
