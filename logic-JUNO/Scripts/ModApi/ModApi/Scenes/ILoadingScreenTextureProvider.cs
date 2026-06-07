namespace ModApi.Scenes
{
	public interface ILoadingScreenTextureProvider
	{
		LoadingScreenTextureData GetLoadingScreenTexture(string scene, string previousScene, string flightSceneActivePlanet);
	}
}
