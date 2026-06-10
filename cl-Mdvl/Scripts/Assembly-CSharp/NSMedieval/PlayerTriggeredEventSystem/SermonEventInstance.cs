using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Manager;
using NSMedieval.Serialization;
using NSMedieval.State;

namespace NSMedieval.PlayerTriggeredEventSystem
{
	[FVSerializableKey("SermonEventInstance", "")]
	public class SermonEventInstance : PlayerTriggeredEventInstance
	{
		public SermonEventInstance()
		{
		}

		public override void Initialize()
		{
			base.Initialize();
			foreach (HumanoidInstance key in MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys)
			{
				if (CanParticipate(key) && CanPathFind(key) && !base.AttendeesByType[EventAttendeeType.RoleParticipant].Contains(key))
				{
					AddRemoveParticipant(key, add: true);
				}
			}
		}

		protected override void StartGathering()
		{
			ReserveRolePosition(base.HostBuilding.GetComponentInstance<DecorationComponentInstance>().WorkplacePositions);
			AssignChairs();
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

		public SermonEventInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
