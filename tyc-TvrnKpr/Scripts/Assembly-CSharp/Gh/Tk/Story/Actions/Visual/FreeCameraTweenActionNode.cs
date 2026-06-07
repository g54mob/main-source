using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using XNode;

namespace Gh.Tk.Story.Actions.Visual
{
	[NodeTint("#7f7189")]
	public class FreeCameraTweenActionNode : ConnectedStoryNode, INodeActionProvider, ISkippableNode
	{
		private List<(string label, Action action)> _actions;

		public Ease easing;

		public float duration;

		public DirectorsToolbar3DUIView.CameraPresetData preset1;

		public DirectorsToolbar3DUIView.CameraPresetData preset2;

		public bool allowSkip;

		private string TweenStartedKey => null;

		private string TweenCompleteKey => null;

		public List<(string, Action)> GetActions()
		{
			return null;
		}

		public override void OnTrigger(ActiveStory story)
		{
		}

		private void StartTween(ActiveStory story)
		{
		}

		public override void OnUpdate(ActiveStory story)
		{
		}

		private Sequence TweenWithData(TransformData data, Transform transform)
		{
			return null;
		}

		public void Skip(ActiveStory story)
		{
		}
	}
}
