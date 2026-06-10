using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.StatsSystem;

namespace NSMedieval.PlayerTriggeredEventSystem
{
	[FVSerializableKey("MasterClassEventInstance", "")]
	public class MasterClassEventInstance : PlayerTriggeredEventInstance
	{
		public MasterClassEventInstance()
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
			base.HostBuilding.AddReachablePosition(base.HostBuilding.GetComponentInstance<DecorationComponentInstance>().WorkplacePositions.FirstOrDefault());
			ReserveRolePosition(base.HostBuilding.GetComponentInstance<DecorationComponentInstance>().WorkplacePositions);
			AssignChairs();
			base.StartGathering();
		}

		protected override string[] GetParticipantEffectorParsed(EventAttendeeType eventAttendeeType)
		{
			List<string> list = new List<string>(GetOutcome().ParticipantEffectors);
			if (UniqueResourceGroups.ContainsKey("skill_book"))
			{
				Resource resource = UniqueResourceGroups["skill_book"];
				if ((object)resource != null)
				{
					SkillType affectedSkillType = resource.AffectedSkillType;
					if (affectedSkillType == SkillType.None)
					{
						return list.ToArray();
					}
					string[] skillEffectors = GetOutcome().SkillEffectors;
					foreach (string text in skillEffectors)
					{
						list.Add(text.Replace("{skill}", affectedSkillType.ToString()));
					}
					return list.ToArray();
				}
			}
			return list.ToArray();
		}

		public override IEnumerable<PlayerTriggeredEventInfo> IterateEventQualityInfo()
		{
			foreach (PlayerTriggeredEventInfo item in base.IterateEventQualityInfo())
			{
				yield return item;
			}
			foreach (KeyValuePair<string, Resource> uniqueResourceGroup in UniqueResourceGroups)
			{
				yield return GetUniqueResourceEventInfo(uniqueResourceGroup);
			}
		}

		public MasterClassEventInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
