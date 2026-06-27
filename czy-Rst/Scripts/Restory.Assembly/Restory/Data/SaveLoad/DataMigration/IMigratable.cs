using UnityEngine;

namespace Restory.Data.SaveLoad.DataMigration
{
	public interface IMigratable
	{
	}
	public interface IMigratable<TPreviousType> : IMigratable
	{
		void Migrate(TPreviousType previousModel, GameObject associatedGameObject);
	}
}
