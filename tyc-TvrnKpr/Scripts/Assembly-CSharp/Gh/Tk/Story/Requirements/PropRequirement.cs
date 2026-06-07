using System;
using UnityEngine;
using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class PropRequirement : PipProgressBaseRequirementNode
	{
		[Tooltip("If specified, this will be used instead of the prop filter")]
		public int specificPropId;

		[DropDownChoice(typeof(StoryHelper), "GetAllPropOptions")]
		public string prop;

		public bool checkTargetZone;

		[DropDownChoice(typeof(StoryHelper), "GetZoneIds")]
		public string targetZone;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void OnPropsChanged(object sender, EventArgs e)
		{
		}

		private void OnPropsChanged(ActiveStory data)
		{
		}

		public override string GetLabelKey(ActiveStory data)
		{
			return null;
		}

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}

		protected override int GetCurrentValue(ActiveStory dataStore)
		{
			return 0;
		}
	}
}
