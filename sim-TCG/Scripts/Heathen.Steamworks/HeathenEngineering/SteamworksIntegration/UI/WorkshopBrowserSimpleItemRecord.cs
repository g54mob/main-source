using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HeathenEngineering.SteamworksIntegration.UI
{
	public class WorkshopBrowserSimpleItemRecord : MonoBehaviour, IWorkshopBrowserItemTemplate
	{
		public RawImage previewImage;

		public TextMeshProUGUI titleLabel;

		public TextMeshProUGUI authorLabel;

		public Image voteFillImage;

		[Header("Tooltip Elements")]
		public TextMeshProUGUI tipTitleLabel;

		public TextMeshProUGUI tipDescriptionLabel;

		private WorkshopItem _item;

		public WorkshopItem Item
		{
			get
			{
				return _item;
			}
			set
			{
				Load(value);
			}
		}

		public void Load(WorkshopItem item)
		{
			_item = item;
			if (item.previewImage != null)
			{
				previewImage.texture = item.previewImage;
			}
			else
			{
				item.DownloadPreviewImage();
			}
		}
	}
}
