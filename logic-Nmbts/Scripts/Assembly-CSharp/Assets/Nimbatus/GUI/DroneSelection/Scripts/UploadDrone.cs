using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneSelection.Scripts
{
	public class UploadDrone : MonoBehaviour
	{
		public UITexture Icon;

		public Color NormalColor;

		public Color DisabledColor;

		public Color HoverColor;

		private DroneData _item;

		private DroneInformationPanel _manager;

		private bool _hover;

		public void Init(DroneInformationPanel manager, DroneData item)
		{
			_manager = manager;
			_item = item;
		}

		public void OnClick()
		{
			if (SteamManager.Connected && !SteamManager.ModsActive && _item != null)
			{
				_manager.ShowDroneUploadPanel(_item);
			}
		}

		public void Update()
		{
			if (SteamManager.Connected && !SteamManager.ModsActive)
			{
				Icon.color = (_hover ? HoverColor : NormalColor);
			}
			else
			{
				Icon.color = DisabledColor;
			}
		}

		public void OnHover(bool isOver)
		{
			_hover = isOver;
		}

		public void OnTooltip(bool show)
		{
			if (show)
			{
				if (SteamManager.Connected)
				{
					if (SteamManager.ModsActive)
					{
						NimbatusToolTip.Show(LocalizationManager.GetTermTranslation("DroneHangar/Upload not possible"));
					}
					else
					{
						NimbatusToolTip.Show(LocalizationManager.GetTermTranslation("DroneHangar/Upload Drone"));
					}
				}
				else
				{
					NimbatusToolTip.Show(LocalizationManager.GetTermTranslation("Tournaments/Not Connected"));
				}
			}
			else
			{
				NimbatusToolTip.Show(null);
			}
		}
	}
}
