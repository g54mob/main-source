using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Serialization;
using NSMedieval.Village;

namespace NSMedieval.Construction
{
	[FVSerializableKey("FurnitureInstance", "")]
	public class FurnitureInstanceMigration : WorldObject, IFVMigrated
	{
		public override List<Vec3Int> Positions { get; }

		public override bool BlueprintExists => true;

		public FurnitureInstanceMigration(FVDeserializer deserializer)
		{
			MonoSingleton<MigrationManager>.Instance.MigrateBuilding(deserializer, this);
		}
	}
}
