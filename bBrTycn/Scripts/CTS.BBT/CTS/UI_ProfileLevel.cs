using CTS.Core.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UI_ProfileLevel : UI_ProfileFeature
	{
		[SerializeField]
		private Image _imageContainer;

		[SerializeField]
		private Sprite _defaultImage;

		public override void Repaint()
		{
			if (!_careerMetaData.HasProfile())
			{
				_imageContainer.overrideSprite = _defaultImage;
				return;
			}
			MapInfoSO lastLevelPlayed = _careerMetaData.GetLastLevelPlayed();
			Texture2D texture;
			if ((object)lastLevelPlayed == null)
			{
				_imageContainer.overrideSprite = _defaultImage;
			}
			else if (LoadTexture(lastLevelPlayed, out texture))
			{
				_imageContainer.overrideSprite = Sprite.Create(texture, texture.GetRect(), Vector2.up);
			}
			else
			{
				_imageContainer.overrideSprite = lastLevelPlayed.MapIcon;
			}
		}

		private bool LoadTexture(MapInfoSO level, out Texture2D texture)
		{
			ES3Settings imageSaveSettings = SaveBarScreenshot.GetImageSaveSettings();
			string imagePath = (imageSaveSettings.path = SaveBarScreenshot.GetImagePath(CareerProfile.GetProfileName(_careerMetaData.GetProfile().ProfileIndex), level));
			if (ES3.FileExists(imageSaveSettings))
			{
				texture = ES3.LoadImage(imagePath);
				return texture != null;
			}
			texture = null;
			return false;
		}
	}
}
