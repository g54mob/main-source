using System.Collections.Generic;
using UnityEngine;

namespace Motorways.UI
{
	public class ToggleButtonGroup : MonoBehaviour
	{
		[SerializeField]
		private List<TouchToggle> _toggles = new List<TouchToggle>();

		public bool allowSwitchOff;

		public void ClearToggles()
		{
			_toggles.Clear();
		}

		public void RegisterToggle(TouchToggle toggle)
		{
			toggle.Group = this;
			_toggles.Add(toggle);
		}

		public void NotifyToggleOn(TouchToggle toggle)
		{
			foreach (TouchToggle toggle2 in _toggles)
			{
				if (toggle2 != toggle)
				{
					toggle2.IsOn = false;
				}
			}
		}

		public bool AnyTogglesOn()
		{
			foreach (TouchToggle toggle in _toggles)
			{
				if (toggle.IsOn)
				{
					return true;
				}
			}
			return false;
		}

		public void EnsureValidState()
		{
			if (!Diagnostics.Verify(_toggles.Count > 0, "There is no toggles in the {0} group!", base.name))
			{
				return;
			}
			bool flag = false;
			foreach (TouchToggle toggle in _toggles)
			{
				if (flag)
				{
					toggle.IsOn = false;
				}
				else
				{
					flag = toggle.IsOn;
				}
			}
			if (!flag && !allowSwitchOff)
			{
				_toggles[0].IsOn = true;
			}
		}
	}
}
