using UnityEngine;

namespace ModApi.Scenes
{
	public class LoadingScreenTextureData
	{
		public string AuthorText { get; set; }

		public LoadingScreenTextureDisposalMethod DisposalMethod { get; private set; }

		public LoadingScreenTexturePosition Position { get; private set; }

		public bool ShowLoadingText { get; private set; }

		public Texture Texture { get; private set; }

		public LoadingScreenTextureData(Texture texture, LoadingScreenTextureDisposalMethod disposalMethod, bool showLoadingText = true)
		{
			Texture = texture;
			DisposalMethod = disposalMethod;
			ShowLoadingText = showLoadingText;
		}

		public LoadingScreenTextureData(Texture texture, LoadingScreenTextureDisposalMethod disposalMethod, LoadingScreenTexturePosition position, string authorText, bool showLoadingText = true)
		{
			Texture = texture;
			DisposalMethod = disposalMethod;
			Position = position;
			AuthorText = authorText;
			ShowLoadingText = showLoadingText;
		}

		public void SetRectTransformPosition(RectTransform rectTransform)
		{
			Vector2 pivot = (rectTransform.anchorMax = (rectTransform.anchorMin = Position switch
			{
				LoadingScreenTexturePosition.CenterLeft => new Vector2(0f, 0.5f), 
				LoadingScreenTexturePosition.CenterRight => new Vector2(1f, 0.5f), 
				LoadingScreenTexturePosition.TopLeft => new Vector2(0f, 1f), 
				LoadingScreenTexturePosition.TopCenter => new Vector2(0.5f, 1f), 
				LoadingScreenTexturePosition.TopRight => new Vector2(1f, 1f), 
				LoadingScreenTexturePosition.BottomLeft => new Vector2(0f, 0f), 
				LoadingScreenTexturePosition.BottomCenter => new Vector2(0.5f, 0f), 
				LoadingScreenTexturePosition.BottomRight => new Vector2(1f, 0f), 
				_ => new Vector2(0.5f, 0.5f), 
			}));
			rectTransform.pivot = pivot;
		}
	}
}
