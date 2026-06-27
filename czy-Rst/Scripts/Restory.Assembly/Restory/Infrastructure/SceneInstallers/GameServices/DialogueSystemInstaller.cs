using PixelCrushers.DialogueSystem;
using Restory.Gameplay.Dialogue;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameServices
{
	public class DialogueSystemInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject dialogueSystemPrefab;

		public override void InstallBindings()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(dialogueSystemPrefab);
			base.Container.Bind<DialogueSystemController>().FromComponentOn(gameObject).AsSingle();
			base.Container.Bind<DialogueSystemEvents>().FromComponentOn(gameObject).AsSingle();
			base.Container.BindInterfacesAndSelfTo<DialogueSystemLocalizationAdapter>().FromNew().AsSingle();
		}
	}
}
