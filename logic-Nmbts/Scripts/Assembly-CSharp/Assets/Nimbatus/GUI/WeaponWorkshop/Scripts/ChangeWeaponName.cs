using UnityEngine;

namespace Assets.Nimbatus.GUI.WeaponWorkshop.Scripts
{
	public class ChangeWeaponName : MonoBehaviour
	{
		public WeaponPresetList List;

		public UIInput Label;

		public void Update()
		{
			if (List.SelectedItem != null)
			{
				List.SelectedItem.Name = Label.value;
			}
		}
	}
}
