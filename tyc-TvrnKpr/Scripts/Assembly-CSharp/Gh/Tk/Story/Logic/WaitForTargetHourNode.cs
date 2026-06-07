using System;
using UnityEngine.Scripting;

namespace Gh.Tk.Story.Logic
{
	[InitializeOnGameStarted]
	public class WaitForTargetHourNode : ConnectedStoryNode
	{
		public int targetHour;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void HourChanged(object sender, EventArgs e)
		{
		}
	}
}
