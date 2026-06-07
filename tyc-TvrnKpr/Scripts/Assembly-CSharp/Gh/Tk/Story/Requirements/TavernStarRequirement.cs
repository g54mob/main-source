using UnityEngine;
using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class TavernStarRequirement : RequirementNode
	{
		[Range(0f, 5f)]
		public float tavernStar;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private void OnStarsChanged(ActiveStory data)
		{
		}

		private void OnValidate()
		{
		}

		public override string GetLabelKey(ActiveStory data)
		{
			return null;
		}

		protected override bool IsMetInternal(ActiveStory data)
		{
			return false;
		}
	}
}
