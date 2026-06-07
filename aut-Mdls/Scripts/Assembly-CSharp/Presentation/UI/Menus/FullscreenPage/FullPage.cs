using UnityEngine;

namespace Presentation.UI.Menus.FullscreenPage
{
	public abstract class FullPage : MonoBehaviour
	{
		public abstract void Initialize();

		public abstract void ShowPage();

		public abstract void HidePage();
	}
}
