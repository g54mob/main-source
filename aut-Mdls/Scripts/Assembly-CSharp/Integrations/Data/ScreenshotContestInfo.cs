using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Integrations.Data
{
	[Serializable]
	public class ScreenshotContestInfo
	{
		public const string TitleDataKey = "ScreenshotContestInfo";

		[JsonProperty("TitleLocalizations")]
		private Dictionary<LanguageCode, string> _titleLocalizations = new Dictionary<LanguageCode, string>();

		[JsonProperty("Title")]
		private string _title;

		[JsonProperty("DescriptionLocalizations")]
		private Dictionary<LanguageCode, string> _descriptionLocalizations = new Dictionary<LanguageCode, string>();

		[JsonProperty("Description")]
		private string _description;

		[JsonProperty("CallToActionLocalizations")]
		private Dictionary<LanguageCode, string> _callToActionLocalizations = new Dictionary<LanguageCode, string>();

		[JsonProperty("CallToAction")]
		private string _callToAction;

		public bool Active { get; set; }

		public bool DisableCTA { get; set; }

		[JsonIgnore]
		public string Title => _titleLocalizations.GetValueOrDefault(LocalizationUtility.CurrentLanguage, _title);

		[JsonIgnore]
		public string Description => _descriptionLocalizations.GetValueOrDefault(LocalizationUtility.CurrentLanguage, _description);

		[JsonIgnore]
		public string CallToAction => _callToActionLocalizations.GetValueOrDefault(LocalizationUtility.CurrentLanguage, _callToAction);

		public string CallToActionLink { get; set; }

		[JsonProperty(PropertyName = "imageUrl")]
		public string ImageLocation { get; set; }

		public DownloadableAsset ImageDownloadableAsset { get; set; }

		public List<DownloadableAsset> GetInvalidatedCachedAssetsList()
		{
			PrepareDownloadableAsset();
			return new List<DownloadableAsset> { ImageDownloadableAsset };
		}

		public void GetCachedAssets()
		{
			PrepareDownloadableAsset();
			ImageDownloadableAsset.Available = File.Exists(ImageDownloadableAsset.Location);
		}

		private void PrepareDownloadableAsset()
		{
			if (DownloadHandler.GetFileNameFromUri(ImageLocation, out var fileName))
			{
				ImageDownloadableAsset = new DownloadableAsset
				{
					Url = ImageLocation,
					Location = StorageHandler.CreateCachedAssetPath(fileName, "ScreenshotContestInfo".ToLowerInvariant())
				};
			}
			else
			{
				ImageDownloadableAsset = new DownloadableAsset();
			}
		}

		public Texture2D GetImage()
		{
			Texture2D texture2D = new Texture2D(2, 2);
			if (StorageHandler.RetrieveCachedAsset(ImageDownloadableAsset.Location, out var data) && texture2D.LoadImage(data))
			{
				return texture2D;
			}
			return null;
		}

		public bool IsValid()
		{
			return ImageDownloadableAsset?.Available ?? false;
		}
	}
}
