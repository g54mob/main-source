using Restory.Data.Locations;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.ProjectInstallers
{
	public class GameScenesPresetDataBaseInstaller : MonoInstaller
	{
		[SerializeField]
		private GameScenesPresetDataBase dataBase;

		public override void InstallBindings()
		{
			base.Container.Bind<GameScenesPresetDataBase>().FromInstance(dataBase).AsSingle();
		}
	}
}
