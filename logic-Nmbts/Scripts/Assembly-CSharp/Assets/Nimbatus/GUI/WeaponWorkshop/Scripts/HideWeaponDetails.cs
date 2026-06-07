using UnityEngine;

namespace Assets.Nimbatus.GUI.WeaponWorkshop.Scripts
{
	public class HideWeaponDetails : MonoBehaviour
	{
		public WeaponPresetList List;

		public void OnClick()
		{
			List.SelectedItem = null;
		}
	}
}
