using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Serialization;

namespace NSMedieval.GameEventSystem
{
	[FVSerializableKey("RaiderBlueprintId", "")]
	public class RaiderBlueprintId : IFVSerializable
	{
		[Serializable]
		public enum RaiderType
		{
			None = 0,
			NPC = 1,
			Animal = 2,
			Trebuchet = 3
		}

		private RaiderType type;

		private string unitId;

		private int? randomSeed;

		private const string fvs_type = "type";

		private const string fvs_unitId = "unitId";

		private const string fvs_randomSeed = "randomSeed";

		public RaiderType Type => type;

		public string Id => unitId;

		public int? RandomSeed
		{
			get
			{
				return randomSeed;
			}
			set
			{
				randomSeed = value;
			}
		}

		public RaiderBlueprintId(IEnemyPurchaseUnit unit)
		{
			if (!(unit is NPC))
			{
				if (!(unit is Animal))
				{
					if (unit is Trebuchet)
					{
						type = RaiderType.Trebuchet;
					}
					else
					{
						bool isEnabled;
						FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(40, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Common\\RaiderBlueprintId.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Unsupported raider type ");
							messageBuilder.AppendFormatted(unit.GetType().Name);
							messageBuilder.AppendLiteral(", defaulting to ");
							messageBuilder.AppendFormatted("NPC");
						}
						Log.Error(messageBuilder);
						type = RaiderType.NPC;
					}
				}
				else
				{
					type = RaiderType.Animal;
				}
			}
			else
			{
				type = RaiderType.NPC;
			}
			unitId = unit.GetID();
		}

		public IEnemyPurchaseUnit FindBlueprint()
		{
			return type switch
			{
				RaiderType.NPC => Repository<NPCRepository, NPC>.Instance.GetByID(unitId), 
				RaiderType.Animal => Repository<AnimalBaseRepository, Animal>.Instance.GetByID(unitId), 
				RaiderType.Trebuchet => Repository<TrebuchetRepository, Trebuchet>.Instance.GetByID(unitId), 
				_ => null, 
			};
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.WriteEnum("type", type);
			serializer.Write("unitId", unitId);
			serializer.Write("randomSeed", randomSeed);
		}

		public RaiderBlueprintId(FVDeserializer deserializer)
		{
			type = deserializer.ReadEnum("type", RaiderType.None);
			unitId = deserializer.ReadString("unitId");
			randomSeed = deserializer.ReadNullableInt("randomSeed");
		}
	}
}
