using Restory.Gameplay.UserInterface;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameOverlay
{
	public class GUI_DialoguePanelInstaller : MonoInstaller
	{
		[SerializeField]
		private GUI_DialoguePanel dialoguePanel;

		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<GUI_DialoguePanel>().FromComponentOn(dialoguePanel.gameObject).AsSingle();
			base.Container.QueueAllComponentsForInject(dialoguePanel.gameObject);
		}
	}
}
