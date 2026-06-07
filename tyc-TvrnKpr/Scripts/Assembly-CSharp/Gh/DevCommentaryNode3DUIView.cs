using System;
using Gh.Tk;
using UnityEngine;

namespace Gh
{
	public class DevCommentaryNode3DUIView : Button3DUIView
	{
		public string commentaryId;

		public GameObject mainPart;

		public GameObject completedState;

		public GameObject isPlayingState;

		public GameObject hasPlayedState;

		private DevCommentaryMetadata _commentary;

		private bool _commentarySet;

		private bool _isWorldMapView;

		private bool _isUIView;

		private DevCommentaryMetadata Commentary => null;

		protected override void Awake()
		{
		}

		private void OnDialogTransition(object sender, EventArgs e)
		{
		}

		private void OnDialogOpened(object sender, EventArgs e)
		{
		}

		protected override void OnDestroy()
		{
		}

		protected override void OnInteractionSuspendedChanged()
		{
		}

		private void OnUIVisibilityChanged(object sender, EventArgs e)
		{
		}

		private void OnNodeVisibilityModeChanged(object sender, EventArgs e)
		{
		}

		private void OnProfileChanged(object sender, EventArgs<PlayerProfile> e)
		{
		}

		private void OnCommentaryCompleted(object sender, EventArgs<string> e)
		{
		}

		protected override void OnHoveredChanged()
		{
		}

		private void OnPlayingStateChanged(object sender, EventArgs e)
		{
		}

		private void OnDevCommentaryEnabledChanged(object sender, EventArgs e)
		{
		}

		private void InvalidateNodeState()
		{
		}

		private void InvalidateActiveState()
		{
		}

		private bool CanUIShowCommentaries()
		{
			return false;
		}

		private bool ShouldBeActive()
		{
			return false;
		}

		public override void CheckState()
		{
		}

		public override void OnClicked()
		{
		}
	}
}
