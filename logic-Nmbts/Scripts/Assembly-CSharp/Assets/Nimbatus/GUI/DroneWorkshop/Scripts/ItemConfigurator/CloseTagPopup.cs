using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator
{
	public class CloseTagPopup : MonoBehaviour
	{
		public void OnClick()
		{
			TagInputPopup.Instance.Close(false);
		}
	}
}
