using System;

namespace Gh.Tk.Story.Requirements
{
	public class IsRunningGameTypeRequirementNode : RequirementNode
	{
		[Serializable]
		public enum GameType
		{
			DEMO = 0,
			FULL = 1
		}

		public GameType targetGameType;

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
