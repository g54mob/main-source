using System;
using PixelCrushers.DialogueSystem;
using Restory.UI.Presenters;
using Restory.UserInterface.GameplayOverlay;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameOverlay
{
	[Serializable]
	public sealed class DialogueCanvasInstaller : Installer
	{
		[SerializeField]
		private CanvasDialogueUI dialogueCanvasPrefab;

		private GameObject dialogueCanvasInstance;

		public override void InstallBindings()
		{
			base.Container.Bind<GameObject>().WithId("DialogueCanvasPrefab").FromInstance(dialogueCanvasPrefab.gameObject)
				.AsCached()
				.WhenInjectedInto<DialogueCanvasFactory>();
			base.Container.Bind<Transform>().WithId("GameplayOverlayCanvasParentTransform").FromResolveGetter((GUI_GameplayOverlayCanvas x) => x.transform)
				.AsCached()
				.WhenInjectedInto<DialogueCanvasFactory>();
			base.Container.Bind<IDialogueUI>().FromMethod(GetDialogueUiInstance).AsSingle();
			base.Container.Bind<GUI_DialogueAdditionalImages>().FromMethod(GetDialogueAdditionalImagesInstance).AsSingle();
		}

		private IDialogueUI GetDialogueUiInstance(InjectContext injectContext)
		{
			return GetDialogueCanvasInstance(injectContext).GetComponentInChildren<IDialogueUI>();
		}

		private GUI_DialogueAdditionalImages GetDialogueAdditionalImagesInstance(InjectContext injectContext)
		{
			return GetDialogueCanvasInstance(injectContext).GetComponentInChildren<GUI_DialogueAdditionalImages>();
		}

		private GameObject GetDialogueCanvasInstance(InjectContext injectContext)
		{
			if (dialogueCanvasInstance == null)
			{
				DialogueCanvasFactory dialogueCanvasFactory = injectContext.Container.Instantiate<DialogueCanvasFactory>();
				dialogueCanvasInstance = dialogueCanvasFactory.Create();
			}
			return dialogueCanvasInstance;
		}

		private Transform GetCanvas(InjectContext c)
		{
			return c.Container.Resolve<GUI_GameplayOverlayCanvas>().transform;
		}
	}
}
