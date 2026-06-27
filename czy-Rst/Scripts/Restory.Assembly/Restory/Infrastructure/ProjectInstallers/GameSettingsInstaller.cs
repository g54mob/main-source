using Restory.Gameplay.GameSettings;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.ProjectInstallers
{
	public class GameSettingsInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject gameSettingsPrefab;

		public override void InstallBindings()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(gameSettingsPrefab);
			base.Container.BindInterfacesAndSelfTo<GameSettingsManager>().FromInstance(gameObject.GetComponent<GameSettingsManager>()).AsSingle();
			base.Container.BindInterfacesAndSelfTo<GameSettingsDataSaveLoadSystem>().FromInstance(gameObject.GetComponent<GameSettingsDataSaveLoadSystem>()).AsSingle();
		}
	}
}
