using UnityEngine;

namespace Placemaker.SceneProcessing
{
	public class PlatformDependent : MonoBehaviour, IOnScenePostProcess
	{
		public TargetPlatformFlags targetPlatformFlags;

		void IOnScenePostProcess.OnScenePostProcess(bool isBuild, TargetPlatformFlags platform)
		{
		}
	}
}
