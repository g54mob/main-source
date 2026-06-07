using System;
using UnityEngine;
using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class GameSpeedRequirementNode : RequirementNode
	{
		[Tooltip("If true, the requirement is met when the speed is not the configured speedSetting")]
		public bool invertCheck;

		[Range(0f, 3f)]
		public int speedSetting;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void OnTimeSettingsChanged(object sender, EventArgs e)
		{
		}

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
