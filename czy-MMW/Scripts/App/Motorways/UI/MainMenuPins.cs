using Motorways.Views;
using UnityEngine;

namespace Motorways.UI
{
	public class MainMenuPins : MonoBehaviour
	{
		[SerializeField]
		private MainMenuScreen _mainMenu;

		public void OnPinAppear(int pinIndex)
		{
			_mainMenu.OnLogoPinAppear(pinIndex);
		}

		public void OnPinDisappear(int pinIndex)
		{
			_mainMenu.OnLogoPinDisappear(pinIndex);
		}
	}
}
