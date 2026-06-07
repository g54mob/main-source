using UnityEngine;
using UnityEngine.Scripting;

namespace Gh.Tk.Story.Actions
{
	[InitializeOnGameStarted]
	public class PlayMusicTrackActionNode : AudioActionBaseNode
	{
		[Tooltip("if true we play the selected track, otherwise reenable the music autoplay and play a track")]
		public bool setTrack;

		[DropDownChoice(typeof(StoryHelper), "GetAllMusicTracks")]
		public string track;

		private string TrackPlayedKey => null;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
