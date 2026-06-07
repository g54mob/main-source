using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using I2.Loc;
using SFB;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneSelection.Scripts
{
	public class SaveDroneToFile : MonoBehaviour
	{
		private DroneData _item;

		private DroneInformationPanel _manager;

		private List<UIButton> _buttons;

		private bool _isVersionCompatible;

		public void Init(DroneInformationPanel manager, DroneData item)
		{
			_manager = manager;
			_item = item;
			_buttons = GetComponents<UIButton>().ToList();
			_isVersionCompatible = item.IsCompatible();
			if (_isVersionCompatible)
			{
				_buttons.ForEach(delegate(UIButton b)
				{
					b.SetState(UIButtonColor.State.Normal, true);
				});
			}
			else
			{
				_buttons.ForEach(delegate(UIButton b)
				{
					b.SetState(UIButtonColor.State.Disabled, true);
				});
			}
		}

		public void OnClick()
		{
			if (_item != null && _isVersionCompatible)
			{
				StandaloneFileBrowser.SaveFilePanelAsync(LocalizationManager.GetTermTranslation("DroneHangar/Export Drone"), "", _item.DroneName, "drn", SaveDrone);
			}
		}

		private void SaveDrone(string path)
		{
			SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.SaveDrone(_item, path);
		}

		public void OnTooltip(bool show)
		{
			if (show)
			{
				NimbatusToolTip.Show(LocalizationManager.GetTermTranslation("DroneHangar/Export Drone"));
			}
			else
			{
				NimbatusToolTip.Show(null);
			}
		}
	}
}
