using Restory.UI.Presenters;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameOverlay
{
	public class DialogueCanvasFactory
	{
		private readonly DiContainer container;

		private readonly GameObject dialogueCanvasPrefab;

		private readonly Transform parentTransform;

		public DialogueCanvasFactory(DiContainer container, [Inject(Id = "DialogueCanvasPrefab")] GameObject dialogueCanvasPrefab, [Inject(Id = "GameplayOverlayCanvasParentTransform")] Transform parentTransform)
		{
			this.container = container;
			this.dialogueCanvasPrefab = dialogueCanvasPrefab;
			this.parentTransform = parentTransform;
		}

		public GameObject Create()
		{
			GameObject gameObject = container.InstantiateAndQueueForInject(dialogueCanvasPrefab, parentTransform);
			GUI_DialogueAdditionalImages componentInChildren = gameObject.GetComponentInChildren<GUI_DialogueAdditionalImages>();
			if ((bool)componentInChildren)
			{
				componentInChildren.Hide();
			}
			return gameObject;
		}
	}
}
