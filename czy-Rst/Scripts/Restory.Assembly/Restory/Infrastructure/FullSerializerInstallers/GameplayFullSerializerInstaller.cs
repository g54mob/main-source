using Restory.Data.EntityMigrations;
using Restory.Data.SaveLoad.FullSerializerWrappers;
using Restory.Data.SaveLoad.FullSerializerWrappers.GameEntities;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.FullSerializerInstallers
{
	public class GameplayFullSerializerInstaller : MonoInstaller
	{
		[SerializeField]
		private GameplayDataMigrationScheme[] gameplayDataMigrationSchemes;

		public override void InstallBindings()
		{
			base.Container.BindFactory<GameEntityCustomConverter, GameEntityCustomConverter.Factory>();
			base.Container.BindFactory<GameplayProgressSaveDataProcessor, GameplayProgressSaveDataProcessor.Factory>().WithArguments(gameplayDataMigrationSchemes);
			base.Container.BindFactory<GameEntityFullSerializer, GameEntityFullSerializer.Factory>();
		}
	}
}
