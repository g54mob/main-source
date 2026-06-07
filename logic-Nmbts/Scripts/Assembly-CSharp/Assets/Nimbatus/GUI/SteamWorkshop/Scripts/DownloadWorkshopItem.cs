using Assets.Nimbatus.Scripts.Workshop;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.SteamWorkshop.Scripts
{
	public class DownloadWorkshopItem : MonoBehaviour
	{
		public UILabel Label;

		public UITexture Background;

		public Color DownloadColor;

		public Color RemoveColor;

		public Color HoverColor;

		public Color NotCompatibleColor;

		private WorkshopItemResult _item;

		private DroneWorkshopInformation _parent;

		private bool _hover;

		public void Init(DroneWorkshopInformation parent, WorkshopItemResult item)
		{
			_item = item;
			_parent = parent;
		}

		public void Update()
		{
			if (_item != null && _item.IsDownloaded)
			{
				Label.text = LocalizationManager.GetTermTranslation("DroneHangar/Remove");
				Background.color = (_hover ? HoverColor : RemoveColor);
			}
			else
			{
				Label.text = LocalizationManager.GetTermTranslation("DroneHangar/Download");
				Background.color = (_hover ? HoverColor : DownloadColor);
			}
			if (_item != null && !DroneData.IsCompatible(_item.Version) && !_item.IsDownloaded)
			{
				Label.text = LocalizationManager.GetTermTranslation("DroneHangar/NotCompatible");
				Background.color = NotCompatibleColor;
			}
		}

		public void OnClick()
		{
			if (_item.IsDownloaded)
			{
				StartCoroutine(_parent.UnsubscribeItem(_item));
			}
			else if (DroneData.IsCompatible(_item.Version))
			{
				StartCoroutine(_parent.DownloadItem(_item));
			}
		}

		public void OnHover(bool isOver)
		{
			_hover = isOver;
		}
	}
}
