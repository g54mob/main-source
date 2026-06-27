using Restory.Audio;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameServices
{
	public class DemoSimpleDialogueVoicesSfxInstaller : MonoInstaller
	{
		[SerializeField]
		private DemoSimpleDialogueVoicesSFX dialogueSFX;

		public override void InstallBindings()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(dialogueSFX.gameObject);
			base.Container.Bind<DemoSimpleDialogueVoicesSFX>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
