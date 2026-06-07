using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class ShowHelpPopup : MonoBehaviour
	{
		private static bool _showPopup;

		public void Start()
		{
			if (_showPopup)
			{
				GetComponent<TweenPosition>().Toggle();
				_showPopup = false;
			}
		}
	}
}
