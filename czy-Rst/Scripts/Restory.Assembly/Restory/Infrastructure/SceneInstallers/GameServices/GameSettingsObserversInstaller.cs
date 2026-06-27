using Restory.Gameplay.GameSettings.Observers;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameServices
{
	[CreateAssetMenu(fileName = "GameSettingsObserversInstaller", menuName = "Restory/Infrastructure/GameSettingsObserversInstaller")]
	public class GameSettingsObserversInstaller : ScriptableObjectInstaller
	{
		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<GameSettingsLanguageChangeObserver>().FromNew().AsSingle();
			base.Container.BindInterfacesAndSelfTo<GameSettingsTextSizeChangeObserver>().FromNew().AsSingle();
		}
	}
}
