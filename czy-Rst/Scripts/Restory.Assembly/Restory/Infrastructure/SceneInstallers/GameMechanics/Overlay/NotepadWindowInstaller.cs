using System;
using Restory.UI.Presenters.Notepad;
using Restory.UserInterface.GameplayOverlay;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics.Overlay
{
	[Serializable]
	public sealed class NotepadWindowInstaller : Installer
	{
		[SerializeField]
		private GUI_NotepadWindow windowPrefab;

		[SerializeField]
		private GUI_NotepadElementItem elementItemPrefab;

		private Transform parentCanvas;

		[Inject]
		private void Construct(GUI_GameplayOverlayCanvas overlayCanvas)
		{
			parentCanvas = overlayCanvas.transform;
		}

		public override void InstallBindings()
		{
			InstallNotepadWindow();
			InstallNotepadWindowElement();
		}

		private void InstallNotepadWindow()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(windowPrefab.gameObject, parentCanvas);
			base.Container.BindInterfacesAndSelfTo<GUI_NotepadWindow>().FromComponentOn(gameObject).AsSingle();
			base.Container.BindInterfacesAndSelfTo<GUI_NotepadWindowPreviewer>().FromComponentOn(gameObject).AsSingle();
		}

		private void InstallNotepadWindowElement()
		{
			base.Container.Bind<NotepadElementItemPool>().FromNew().AsSingle()
				.WithArguments(elementItemPrefab.gameObject);
			base.Container.BindExecutionOrder<NotepadElementItemPool>(40);
		}
	}
}
