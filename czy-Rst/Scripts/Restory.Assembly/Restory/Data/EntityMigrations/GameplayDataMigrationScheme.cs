using System;
using UnityEngine;

namespace Restory.Data.EntityMigrations
{
	[CreateAssetMenu(menuName = "Restory/Data/GameplayDataMigrationScheme", fileName = "GameplayDataMigrationScheme", order = 0)]
	public class GameplayDataMigrationScheme : ScriptableObject
	{
		[Serializable]
		public class Entry
		{
			public string JsonParentContainerName;

			public RemoveRule[] RemoveByIdentificatorRules;
		}

		public string[] OriginalTypeNames;

		public string FinalTypeName;

		public Entry[] Entries = new Entry[0];
	}
}
