using Assets.Nimbatus.Scripts.WorldObjects.Items.Selection;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class DisplayItemStats : MonoBehaviour
	{
		public UILabel Label;

		public void Update()
		{
			if (ItemSelector.GetOnlySelection() != null)
			{
				Label.text = ItemSelector.GetOnlySelection().GetTooltip();
			}
			else
			{
				Label.text = "";
			}
		}
	}
}
