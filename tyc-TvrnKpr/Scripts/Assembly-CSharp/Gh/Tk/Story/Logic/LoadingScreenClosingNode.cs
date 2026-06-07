using UnityEngine.Scripting;

namespace Gh.Tk.Story.Logic
{
	[InitializeOnGameStarted]
	public class LoadingScreenClosingNode : ConnectedStoryNode
	{
		[Preserve]
		private static void OnGameStarted()
		{
		}
	}
}
