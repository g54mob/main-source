using UnityEngine;

namespace Restory.Data.EntityMigrations
{
	[CreateAssetMenu(menuName = "Restory/Data/Create GameEntityMigrationScheme", fileName = "GameEntityMigrationScheme", order = 0)]
	public class GameEntityMigrationScheme : ScriptableObject
	{
		public string OriginalTypeName;

		public string FinalTypeName;

		public RenameRule[] RenameRules;

		public RemoveRule[] RemoveRules;

		public ChangeItemObjectTypeRule[] ChangeItemObjectTypeRules;
	}
}
