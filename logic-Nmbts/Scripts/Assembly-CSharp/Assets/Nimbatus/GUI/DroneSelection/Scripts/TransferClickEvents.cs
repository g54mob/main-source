using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneSelection.Scripts
{
	public class TransferClickEvents : MonoBehaviour
	{
		public UIInput Input;

		public void OnClick()
		{
			Input.OnSelect(true);
		}
	}
}
