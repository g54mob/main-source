using System;
using UnityEngine;
using XNode;

namespace Gh.Tk.Story.Actions
{
	public class PlayCinematicScreenSaverActionNode : ConnectedStoryNode
	{
		[Tooltip("On video finished but before fade out")]
		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodePort onVideoFinished;

		public string skipPrompt;

		public KeyCode skipKey;

		public bool loop;

		public bool skipTransition;

		[SerializeField]
		private GameObject _cinematicVideoPrefab;

		private FullScreenVideoPlayer _cinematicPlayer;

		private void SetupIntroVideo(Action onVideoReady, Action onVideoFinished, Action onVideoFadeOutFinished)
		{
		}

		public override void OnTrigger(ActiveStory story)
		{
		}

		public override void OnUpdate(ActiveStory story)
		{
		}

		public override void Complete(ActiveStory story)
		{
		}

		private void CleanUp(object sender, EventArgs e)
		{
		}

		private void CleanUp()
		{
		}
	}
}
