using UnityEngine;

namespace Simulator
{
	public class WaitWhileSceneLoading : CustomYieldInstruction
	{
		public override bool keepWaiting
		{
			get
			{
				if (!SceneManager.IsLoadingScene)
				{
					return SceneManager.IsUnloadingScene;
				}
				return true;
			}
		}
	}
}
