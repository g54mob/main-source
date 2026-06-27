using Restory.Data.GameWarnings;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameServices
{
	public class GameWarningDatabaseInstaller : MonoInstaller
	{
		[SerializeField]
		private GameWarningDatabase gameWarningDatabase;

		public override void InstallBindings()
		{
			InstallGameWarningDatabase();
		}

		private void InstallGameWarningDatabase()
		{
			base.Container.Bind<GameWarningDatabase>().FromInstance(Object.Instantiate(gameWarningDatabase)).AsSingle();
		}
	}
}
