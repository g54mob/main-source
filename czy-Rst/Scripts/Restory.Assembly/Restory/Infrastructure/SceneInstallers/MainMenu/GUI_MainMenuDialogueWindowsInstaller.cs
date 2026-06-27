using Restory.UserInterface.ConfirmationDialogues;
using Restory.UserInterface.GameplayOverlay;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.MainMenu
{
	public class GUI_MainMenuDialogueWindowsInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject mainMenuVariantPrefab;

		public override void InstallBindings()
		{
			InstallMainMenuDialogue();
		}

		private void InstallMainMenuDialogue()
		{
			GUI_GameplayOverlayCanvas gUI_GameplayOverlayCanvas = Object.FindAnyObjectByType<GUI_GameplayOverlayCanvas>();
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(mainMenuVariantPrefab, gUI_GameplayOverlayCanvas.transform);
			base.Container.Bind<GameObject>().WithId("MainMenuWindow").FromInstance(gameObject)
				.AsCached();
			gameObject.SetActive(value: false);
			if (gameObject.TryGetComponent<GUI_ConfirmationDialog>(out var component))
			{
				component.IsPoolable = false;
			}
		}
	}
}
