using System;
using System.Collections.Generic;
using Restory.Data.EntityMigrations;
using Restory.Data.GameEntities;
using UnityEngine;

namespace Restory.AssetManagement
{
	public class GameEntityDataBaseProvider : MonoBehaviour, IDisposable
	{
		[SerializeField]
		private GameEntityDataBase asset;

		[SerializeField]
		private List<GameEntityMigrationScheme> migrationSchemes = new List<GameEntityMigrationScheme>();

		public GameEntityDataBase Asset => asset;

		public IReadOnlyList<GameEntityMigrationScheme> MigrationSchemes => migrationSchemes;

		public void Dispose()
		{
			asset = null;
		}
	}
}
