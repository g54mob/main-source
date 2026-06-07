using UnityEngine;

namespace Assets.Nimbatus.GUI.WeaponWorkshop.Scripts
{
	public class DisplaySelectedWeaponDetails : MonoBehaviour
	{
		public WeaponPresetList List;

		public UILabel Label;

		public void Update()
		{
			if (List.SelectedItem != null && List.SelectedItem.Emitter != null)
			{
				Label.text = List.SelectedItem.Emitter.GetDetailedTooltip();
			}
			else
			{
				Label.text = "";
			}
		}
	}
}
