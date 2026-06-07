namespace Assets.Scripts.Scenes
{
	public interface ILoadingScreenTextureProvider
	{
		LoadingScreenTextureData GetLoadingScreenTexture(string scene, string previousScene);
	}
}
