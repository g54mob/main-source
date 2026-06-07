using UnityEngine;

namespace Assets.Scripts.Scenes
{
	public class DefaultLoadingScreenTextureProvider : ILoadingScreenTextureProvider
	{
		public static readonly LoadingScreenTextureData DefaultLoadingScreen;

		public static readonly LoadingScreenTextureData StartupLoadingScreen;

		static DefaultLoadingScreenTextureProvider()
		{
			Texture2D texture2D = new Texture2D(2, 2, TextureFormat.RGB24, mipChain: false, linear: false);
			texture2D.filterMode = FilterMode.Point;
			texture2D.wrapMode = TextureWrapMode.Clamp;
			texture2D.name = "BlackLoadingScreen";
			Color32 color = new Color32(0, 0, 0, 1);
			texture2D.SetPixels32(new Color32[4] { color, color, color, color });
			texture2D.Apply(updateMipmaps: false, makeNoLongerReadable: true);
			DefaultLoadingScreen = new LoadingScreenTextureData(texture2D, LoadingScreenTextureDisposalMethod.None);
			StartupLoadingScreen = new LoadingScreenTextureData(texture2D, LoadingScreenTextureDisposalMethod.None);
		}

		public LoadingScreenTextureData GetLoadingScreenTexture(string scene, string previousScene)
		{
			if (scene == "Startup" || previousScene == "Startup")
			{
				return StartupLoadingScreen;
			}
			LoadingScreenTextureData loadingScreenTextureData = null;
			Texture2D texture2D = Game.Instance.ResourceLoader.LoadTexture($"LoadingScreens/LoadingScreen-{Random.Range(0, 15)}", logErrors: false);
			if (texture2D != null)
			{
				loadingScreenTextureData = new LoadingScreenTextureData(texture2D, LoadingScreenTextureDisposalMethod.UnloadAsset);
			}
			if (loadingScreenTextureData == null)
			{
				Texture2D texture2D2 = Game.Instance.ResourceLoader.LoadTexture("LoadingScreens/Default", logErrors: false);
				if (texture2D2 != null)
				{
					loadingScreenTextureData = new LoadingScreenTextureData(texture2D2, LoadingScreenTextureDisposalMethod.UnloadAsset);
				}
			}
			if (loadingScreenTextureData == null)
			{
				loadingScreenTextureData = DefaultLoadingScreen;
			}
			return loadingScreenTextureData;
		}
	}
}
