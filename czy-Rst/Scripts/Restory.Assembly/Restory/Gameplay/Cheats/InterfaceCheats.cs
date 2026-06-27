using System.ComponentModel;
using Restory.UserInterface.GameplayOverlay;
using UnityEngine.Scripting;
using Zenject;

namespace Restory.Gameplay.Cheats
{
	[Preserve]
	public class InterfaceCheats : SRDebugCheatBase
	{
		private readonly GUI_GameplayOverlayCanvas gameplayOverlayCanvas;

		private const string COMMON_CATEGORY = "Interface Cheats";

		[Category("Interface Cheats")]
		[DisplayName("Gameplay Overlay Visibility")]
		public bool GameplayOverlayVisibility
		{
			get
			{
				if (gameplayOverlayCanvas != null)
				{
					return gameplayOverlayCanvas.gameObject.activeSelf;
				}
				return false;
			}
			set
			{
				if (gameplayOverlayCanvas != null)
				{
					gameplayOverlayCanvas.gameObject.SetActive(value);
				}
			}
		}

		[Inject]
		public InterfaceCheats(GUI_GameplayOverlayCanvas gameplayOverlayCanvas)
		{
			this.gameplayOverlayCanvas = gameplayOverlayCanvas;
		}
	}
}
