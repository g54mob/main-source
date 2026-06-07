using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneSelection.Scripts
{
	public class DeleteDrone : MonoBehaviour
	{
		private DroneData _item;

		private DroneInformationPanel _manager;

		public void Init(DroneInformationPanel manager, DroneData item)
		{
			_manager = manager;
			_item = item;
		}

		public void OnClick()
		{
			if (_item != null)
			{
				_manager.DeleteDrone(_item);
			}
		}

		public void OnTooltip(bool show)
		{
			if (show)
			{
				NimbatusToolTip.Show(LocalizationManager.GetTermTranslation("DroneHangar/Delete Drone"));
			}
			else
			{
				NimbatusToolTip.Show(null);
			}
		}
	}
}
