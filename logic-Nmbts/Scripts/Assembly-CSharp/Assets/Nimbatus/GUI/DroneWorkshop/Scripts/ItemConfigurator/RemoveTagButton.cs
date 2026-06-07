using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator
{
	public class RemoveTagButton : MonoBehaviour
	{
		public void OnClick()
		{
			TagInputPopup.Instance.RemoveTag();
		}
	}
}
