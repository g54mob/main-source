using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Serialization;
using NSMedieval.Village;

namespace NSMedieval.Construction
{
	[FVSerializableKey("DoorBuildingInstance", "")]
	public class DoorBuildingInstanceMigration : WorldObject, IFVMigrated
	{
		public override List<Vec3Int> Positions { get; }

		public override bool BlueprintExists => true;

		public DoorBuildingInstanceMigration(FVDeserializer deserializer)
		{
			MonoSingleton<MigrationManager>.Instance.MigrateBuilding(deserializer, this);
		}
	}
}
