using System.Collections.Generic;

namespace Assets.Scripts.Ui.Purchase
{
	public class CardInfo
	{
		public enum DetailFormatType
		{
			SixVideos = 0,
			ThreeScreenshots = 1
		}

		public class ScreenshotInfo
		{
			public string ScreenshotFile { get; set; }

			public string Title { get; set; }
		}

		public class VideoInfo
		{
			public string ThumbnailFile { get; set; }

			public string Title { get; set; }

			public string VideoFile { get; set; }
		}

		public string CoverImageSprite { get; set; }

		public DetailFormatType DetailFormat { get; set; }

		public bool Hidden { get; set; }

		public bool IsAvailable { get; set; }

		public bool IsCompleteEdition => ProductId == "CompleteEdition";

		public bool IsPurchased { get; set; }

		public string Name { get; }

		public List<string> ParentProductIDs { get; private set; } = new List<string>();

		public string Price { get; set; }

		public string ProductId { get; private set; }

		public List<ScreenshotInfo> Screenshots { get; } = new List<ScreenshotInfo>();

		public List<VideoInfo> Videos { get; } = new List<VideoInfo>();

		public CardInfo(string name, string productId)
		{
			Name = name;
			ProductId = productId;
		}
	}
}
