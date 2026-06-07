using System.Collections.Generic;
using ModApi.Services.Purchasing;

namespace Assets.Scripts.Ui.Purchase
{
	public class CardInfoSource
	{
		public const string CompleteEditionProductId = "CompleteEdition";

		private IPurchaseService _purchaseService;

		public List<CardInfo> Cards { get; } = new List<CardInfo>();

		public CardInfoSource(IPurchaseService purchaseService)
		{
			_purchaseService = purchaseService;
			string[] screenshotTitles = new string[3] { "Ad Free Downloads From the JNO Website", "Private Uploads To The JNO Website", "No More Ads When Launching A Craft" };
			string[] videoTitles = new string[6] { "Vizzy Programming", "Custom Subassemblies", "Procedural Wheels", "Procedural Rockets", "Procedural Jets", "Procedural Propellers" };
			string[] videoTitles2 = new string[6] { "Full Sandbox System", "Community Systems", "Fly Unlimited Crafts", "New Sandbox Facilities", "Save Launch Locations", "Cheats and Tinkering" };
			string[] videoTitles3 = new string[6] { "More Customers", "Dozens of Contracts", "Leave the Village", "Unlock All The Tech", "Visit All Landmarks", "Adds Engineer Bundle" };
			CreateCard("Engineer Bundle", "EngineerBundle", InAppPurchaseProduct.EngineerBundle.Id, videoTitles).ParentProductIDs.Add(InAppPurchaseProduct.CareerBundle.Id);
			CreateCard("Sandbox Bundle", "SandboxBundle", InAppPurchaseProduct.SandboxBundle.Id, videoTitles2);
			CreateCard("Career Bundle", "CareerBundle", InAppPurchaseProduct.CareerBundle.Id, videoTitles3);
			CreateCard("Remove Ads", "RemoveAds", InAppPurchaseProduct.RemoveAds.Id, null, screenshotTitles);
			CreateCompleteEditionCardInfo();
			RefreshStatus();
		}

		public void RefreshStatus()
		{
			foreach (CardInfo card in Cards)
			{
				if (card.IsCompleteEdition)
				{
					card.IsPurchased = false;
					card.Price = "BUY";
					card.IsAvailable = true;
				}
				else
				{
					(bool, string, bool) productStatus = _purchaseService.GetProductStatus(card.ProductId);
					card.IsPurchased = productStatus.Item3;
					card.Price = productStatus.Item2;
					(card.IsAvailable, _, _) = productStatus;
				}
				foreach (string parentProductID in card.ParentProductIDs)
				{
					(bool, string, bool) productStatus2 = _purchaseService.GetProductStatus(parentProductID);
					card.IsPurchased = card.IsPurchased || productStatus2.Item3;
				}
			}
		}

		private CardInfo CreateCard(string name, string folderName, string productId, string[] videoTitles, string[] screenshotTitles = null)
		{
			CardInfo cardInfo = new CardInfo(name, productId);
			string text = "Ui/Sprites/Purchase/Cards/" + folderName;
			cardInfo.CoverImageSprite = text + "/CoverImage";
			if (videoTitles != null)
			{
				cardInfo.DetailFormat = CardInfo.DetailFormatType.SixVideos;
				for (int i = 0; i < videoTitles.Length; i++)
				{
					CardInfo.VideoInfo item = new CardInfo.VideoInfo
					{
						VideoFile = $"{text}/Video-{i + 1}",
						ThumbnailFile = $"{text}/Video-{i + 1}-Thumb",
						Title = videoTitles[i]
					};
					cardInfo.Videos.Add(item);
				}
			}
			else if (screenshotTitles != null)
			{
				cardInfo.DetailFormat = CardInfo.DetailFormatType.ThreeScreenshots;
				for (int j = 0; j < screenshotTitles.Length; j++)
				{
					CardInfo.ScreenshotInfo item2 = new CardInfo.ScreenshotInfo
					{
						ScreenshotFile = $"{text}/Screenshot-{j + 1}",
						Title = screenshotTitles[j]
					};
					cardInfo.Screenshots.Add(item2);
				}
			}
			Cards.Add(cardInfo);
			return cardInfo;
		}

		private CardInfo CreateCompleteEditionCardInfo()
		{
			CardInfo cardInfo = new CardInfo("Complete Edition", "CompleteEdition");
			string text = "Ui/Sprites/Purchase/Cards/CompleteEdition";
			cardInfo.CoverImageSprite = text + "/CoverImage";
			Cards.Add(cardInfo);
			return cardInfo;
		}
	}
}
