using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Menu.Windows
{
	public class TabsExplicitNavigation : MonoBehaviour
	{
		private enum NavDirection
		{
			Up = 0,
			Down = 1,
			Left = 2,
			Right = 3
		}

		public Selectable topButton;

		public Selectable[] bottomButtons;

		public Transform content;

		public bool manualRefresh;

		private void Start()
		{
		}

		public void Refresh()
		{
		}

		private void SetNavigation(Selectable parent, Selectable toButton, NavDirection direction)
		{
		}
	}
}
