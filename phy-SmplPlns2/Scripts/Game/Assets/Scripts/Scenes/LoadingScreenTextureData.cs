using UnityEngine;

namespace Assets.Scripts.Scenes
{
	public class LoadingScreenTextureData
	{
		public LoadingScreenTextureDisposalMethod DisposalMethod { get; private set; }

		public bool ShowLoadingText { get; private set; }

		public Texture Texture { get; private set; }

		public LoadingScreenTextureData(Texture texture, LoadingScreenTextureDisposalMethod disposalMethod, bool showLoadingText = true)
		{
			Texture = texture;
			DisposalMethod = disposalMethod;
			ShowLoadingText = showLoadingText;
		}
	}
}
