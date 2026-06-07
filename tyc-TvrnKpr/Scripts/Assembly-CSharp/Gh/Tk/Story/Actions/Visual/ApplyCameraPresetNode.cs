using System;
using System.Collections.Generic;
using XNode;

namespace Gh.Tk.Story.Actions.Visual
{
	[NodeTint("#7f7189")]
	public class ApplyCameraPresetNode : ConnectedStoryNode, INodeActionProvider
	{
		private List<(string label, Action action)> _actions;

		public DirectorsToolbar3DUIView.CameraPresetData preset;

		public bool useFreeCamera;

		private string IsWaitingForCameraKey => null;

		public static void GetPresetData(DirectorsToolbar3DUIView.CameraPresetData preset)
		{
		}

		public static void ApplyPresetData(DirectorsToolbar3DUIView.CameraPresetData preset)
		{
		}

		public List<(string, Action)> GetActions()
		{
			return null;
		}

		public override void OnTrigger(ActiveStory story)
		{
		}

		public override void OnUpdate(ActiveStory story)
		{
		}

		private void ApplyPreset(ActiveStory story)
		{
		}
	}
}
