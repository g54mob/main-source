using System;
using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public abstract class RoomUnlockRequirementBaseNode : RequirementNode
	{
		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void InvalidateNodes(object sender, EventArgs e)
		{
		}
	}
}
