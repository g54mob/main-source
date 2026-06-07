using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using UnityEngine;

namespace Assets.Nimbatus.GUI.WeaponWorkshop.Scripts
{
	public class DisplaySelectedWeaponName : MonoBehaviour
	{
		public WeaponPresetList List;

		public UIInput Label;

		private WeaponPreset _selectedPreset;

		public void Update()
		{
			if (List.SelectedItem != _selectedPreset)
			{
				if (List.SelectedItem != null)
				{
					Label.Set(List.SelectedItem.Name, false);
				}
				_selectedPreset = List.SelectedItem;
			}
		}
	}
}
