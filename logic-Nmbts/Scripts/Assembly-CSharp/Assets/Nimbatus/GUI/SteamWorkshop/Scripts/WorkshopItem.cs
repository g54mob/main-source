using Assets.Nimbatus.Scripts.Workshop;
using UnityEngine;

namespace Assets.Nimbatus.GUI.SteamWorkshop.Scripts
{
	public class WorkshopItem : MonoBehaviour
	{
		public UILabel TitleLabel;

		public UITexture DownloadedIcon;

		public UITexture Image;

		public UITexture Background;

		public GameObject ImageNotLoaded;

		public Color NormalColor;

		public Color HoverColor;

		public Color SelectedColor;

		public Color NotDownloadedColor;

		public Color DownloadedColor;

		private IWorkshopItemList _manager;

		private WorkshopItemResult _item;

		private bool _hover;

		public void Init(IWorkshopItemList manager, WorkshopItemResult item)
		{
			_manager = manager;
			_item = item;
			TitleLabel.text = item.Title;
			if (_item.PreviewImage == null)
			{
				ImageNotLoaded.SetActive(true);
			}
			Image.mainTexture = item.PreviewImage;
		}

		public void OnClick()
		{
			_manager.SelectItem(_item);
		}

		public void Update()
		{
			if (_item.PreviewImage != null)
			{
				Image.mainTexture = _item.PreviewImage;
				ImageNotLoaded.SetActive(false);
			}
			else
			{
				ImageNotLoaded.SetActive(true);
			}
			if (_manager.SelectedItem == _item)
			{
				Background.color = (_hover ? HoverColor : SelectedColor);
			}
			else
			{
				Background.color = (_hover ? HoverColor : NormalColor);
			}
			if (DownloadedIcon != null)
			{
				if (_item.IsDownloaded)
				{
					DownloadedIcon.color = DownloadedColor;
				}
				else
				{
					DownloadedIcon.color = NotDownloadedColor;
				}
			}
		}

		public void OnHover(bool isOver)
		{
			_hover = isOver;
		}
	}
}
