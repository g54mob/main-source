using Restory.Gameplay.TextureMasks;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameServices
{
	public class TextureSaveLoadServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private TextureSaveLoadService prefab;

		public override void InstallBindings()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(prefab.gameObject);
			base.Container.Bind<TextureSaveLoadService>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
