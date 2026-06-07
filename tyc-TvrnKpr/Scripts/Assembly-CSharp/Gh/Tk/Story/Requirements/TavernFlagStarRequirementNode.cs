using System;
using UnityEngine;
using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class TavernFlagStarRequirementNode : RequirementNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetTavernFlagCategories")]
		public string tavernFlag;

		[Range(0f, 5f)]
		public float flagStar;

		private void OnValidate()
		{
		}

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void InvalidateAll(object sender, EventArgs e)
		{
		}

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
