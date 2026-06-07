using Assets.Nimbatus.GUI.Common.Scripts;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator
{
	public class SaveTagButton : MonoBehaviour
	{
		public SimpleInputLabel TagText;

		public void OnClick()
		{
			TagInputPopup.Instance.SaveTag(TagText.CurrentText);
		}
	}
}
