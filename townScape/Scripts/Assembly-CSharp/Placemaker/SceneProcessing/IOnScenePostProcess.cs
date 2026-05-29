namespace Placemaker.SceneProcessing
{
	public interface IOnScenePostProcess
	{
		void OnScenePostProcess(bool isBuild, TargetPlatformFlags platform);
	}
}
