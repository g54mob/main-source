using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using Objectives;

namespace NSMedieval.GameEventSystem.Events
{
	[FVSerializableKey("LeaveMapPhase", "")]
	public class LeaveMapReligionRangePhase : GameEventLinearPhaseBase
	{
		private readonly float minReligion;

		private readonly float maxReligion;

		public LeaveMapReligionRangePhase(float minReligion, float maxReligion)
		{
			this.minReligion = minReligion;
			this.maxReligion = maxReligion;
		}

		public override bool OnStart()
		{
			LeaveMap();
			MonoSingleton<ObjectiveManager>.Instance.ActiveObjective?.TurnFactionsIntoFullyFriendly();
			return true;
		}

		public IEnumerable<HumanoidInstance> IterateNPCsInReligionRange()
		{
			foreach (CreatureBase creature in MonoSingleton<CreatureManager>.Instance.Creatures)
			{
				if (creature is HumanoidInstance humanoidInstance && humanoidInstance.IsWorker() && !humanoidInstance.IsInIncognitoMode() && CheckReligionRange(humanoidInstance, minReligion, maxReligion))
				{
					yield return humanoidInstance;
				}
			}
		}

		protected override bool TickShouldEnd()
		{
			return true;
		}

		private void LeaveMap()
		{
			foreach (HumanoidInstance item in IterateNPCsInReligionRange())
			{
				item.LeaveMapSilent();
			}
		}

		private static bool CheckReligionRange(HumanoidInstance humanoidInstance, float minReligion, float maxReligion)
		{
			if (humanoidInstance.HasDisposed || humanoidInstance.HasDied || humanoidInstance.Stats == null)
			{
				return false;
			}
			StatInstance stat = humanoidInstance.Stats.GetStat(StatType.ReligiousAlignment);
			if (stat.Current < minReligion || stat.Current > maxReligion)
			{
				return false;
			}
			return true;
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("minReligion", minReligion);
			serializer.Write("maxReligion", maxReligion);
		}

		public LeaveMapReligionRangePhase(FVDeserializer deserializer)
			: base(deserializer)
		{
			minReligion = deserializer.ReadFloat("minReligion");
			maxReligion = deserializer.ReadFloat("maxReligion");
		}
	}
}
