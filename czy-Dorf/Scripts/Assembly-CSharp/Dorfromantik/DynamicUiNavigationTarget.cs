using System;
using UnityEngine.UI;

namespace Dorfromantik
{
	[Serializable]
	public class DynamicUiNavigationTarget
	{
		public MainMenuScreenType mainMenuScreenType;

		public UiDirection direction;

		public Selectable targetSelectable;
	}
}
