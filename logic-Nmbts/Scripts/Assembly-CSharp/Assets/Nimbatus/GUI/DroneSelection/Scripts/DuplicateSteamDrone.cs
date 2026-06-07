using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Sirenix.Utilities;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneSelection.Scripts
{
	public class DuplicateSteamDrone : MonoBehaviour
	{
		private DroneData _item;

		private SteamDroneInformationPanel _manager;

		private UIButton[] _buttons;

		private bool _isVersionCompatible;

		public void Init(SteamDroneInformationPanel manager, DroneData item)
		{
			_buttons = GetComponents<UIButton>();
			_manager = manager;
			_item = item;
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
				_manager.DuplicateDrone(_item);
			}
		}

		public void Update()
		{
			if (_isVersionCompatible)
			{
				return;
			}
			UIButton[] buttons = _buttons;
			if (buttons != null)
			{
				buttons.ForEach(delegate(UIButton b)
				{
					b.SetState(UIButtonColor.State.Disabled, true);
				});
			}
		}

		public void OnTooltip(bool show)
		{
			if (show)
			{
				if (!_isVersionCompatible)
				{
					NimbatusToolTip.Show("Drone Version not compatible");
				}
			}
			else
			{
				NimbatusToolTip.Show(null);
			}
		}
	}
}
