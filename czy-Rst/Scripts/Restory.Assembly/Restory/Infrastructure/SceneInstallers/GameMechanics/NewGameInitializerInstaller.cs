using Restory.Data.NewGame;
using Restory.Gameplay.NewGame;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class NewGameInitializerInstaller : MonoInstaller
	{
		[SerializeField]
		private NewGameSettings newGameSettings;

		public override void InstallBindings()
		{
			InstallNewGameInitializer();
		}

		private void InstallNewGameInitializer()
		{
			base.Container.BindInterfacesAndSelfTo<NewGameInitializer>().FromNew().AsSingle()
				.WithArguments(newGameSettings);
		}
	}
}
