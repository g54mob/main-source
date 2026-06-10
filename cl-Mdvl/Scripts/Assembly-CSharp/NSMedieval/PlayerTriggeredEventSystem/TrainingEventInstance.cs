using System.Collections.Generic;
using System.Linq;
using NSMedieval.BuildingComponents;
using NSMedieval.Serialization;

namespace NSMedieval.PlayerTriggeredEventSystem
{
	[FVSerializableKey("TrainingEventInstance", "")]
	public class TrainingEventInstance : PlayerTriggeredEventInstance
	{
		public TrainingEventInstance()
		{
		}

		protected override void StartGathering()
		{
			base.HostBuilding.AddReachablePosition(base.HostBuilding.GetComponentInstance<DecorationComponentInstance>().WorkplacePositions.FirstOrDefault());
			ReserveRolePosition(base.HostBuilding.GetComponentInstance<DecorationComponentInstance>().WorkplacePositions);
			base.StartGathering();
		}

		public override IEnumerable<PlayerTriggeredEventInfo> IterateEventQualityInfo()
		{
			foreach (PlayerTriggeredEventInfo item in base.IterateEventQualityInfo())
			{
				yield return item;
			}
			yield return ResourceAmountPerParticipant();
		}

		public TrainingEventInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
