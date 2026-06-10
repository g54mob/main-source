using System.Collections.Generic;
using GameEventSystem.Core.Events;
using NSMedieval.Dialogs.Data;
using NSMedieval.Serialization;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.GameEventSystem.Events
{
	[FVSerializableKey("GameEvents.EndGameEvent", "")]
	public class EndGameEvent : GameEventInstance, IEndGamePhaseDataHolder
	{
		private const string CountdownText = "warning_message_short_EndGameEvent";

		private const string CountdownTooltip = "warning_message_info_EndGameEvent";

		private const string CountdownIcon = "Idle";

		private const float NpcsArriveTimeframeStartHour = 6f;

		private const float NpcsArriveTimeframeEndHour = 21f;

		[SerializeField]
		private List<HumanoidInstance> npcs;

		private LeaveMapReligionRangePhase leaveMapReligionRangePhase;

		public List<HumanoidInstance> NPCs => npcs;

		public EndGameEvent()
		{
			npcs = new List<HumanoidInstance>();
		}

		public override void Dispose()
		{
			base.Dispose();
			npcs?.Clear();
			npcs = null;
		}

		protected override GameEventPhaseBase GetStartingPhase()
		{
			if (leaveMapReligionRangePhase == null && base.Blueprint.ReligionRange != null)
			{
				float min = base.Blueprint.ReligionRange.Min;
				float max = base.Blueprint.ReligionRange.Max;
				leaveMapReligionRangePhase = new LeaveMapReligionRangePhase(min, max);
			}
			int npcSpawnCount = base.Blueprint.NpcsCountRange?.RandomMaxInclusive() ?? 1;
			GameEventLinearPhaseBase nextPhase = new CompleteObjectiveTaskPhase(base.Blueprint.EndGameObjective, base.Blueprint.EndGameObjectiveTaskToComplete);
			SpawnIdleNPCsPhase spawnIdleNPCsPhase = new SpawnIdleNPCsPhase(npcSpawnCount, spawnInGroup: false, base.Blueprint.RoomTypes, base.Blueprint.IdleAnimTrigger, base.Blueprint.NpcsStandInPlace);
			GameEventLinearPhaseBase nextPhase2;
			if (leaveMapReligionRangePhase != null)
			{
				nextPhase2 = leaveMapReligionRangePhase;
				leaveMapReligionRangePhase.LinkNextPhase(spawnIdleNPCsPhase);
			}
			else
			{
				nextPhase2 = spawnIdleNPCsPhase;
			}
			spawnIdleNPCsPhase.LinkNextPhase(nextPhase);
			WaitUntilTimeframePhase waitUntilTimeframePhase = new WaitUntilTimeframePhase(6f, 21f, "warning_message_short_EndGameEvent", "warning_message_info_EndGameEvent", "Idle");
			waitUntilTimeframePhase.LinkNextPhase(nextPhase2);
			return new ShowDialogPhaseBranching(0).NextPhaseOnChoice(1, waitUntilTimeframePhase);
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("npcs", npcs);
		}

		public EndGameEvent(FVDeserializer deserializer)
			: base(deserializer)
		{
			npcs = deserializer.ReadObjectList<HumanoidInstance>("npcs");
			if (npcs == null)
			{
				npcs = new List<HumanoidInstance>();
			}
		}

		public override void FillAgentsLeavingTooltip(TooltipData tooltipData)
		{
			if (tooltipData == null)
			{
				return;
			}
			base.FillAgentsLeavingTooltip(tooltipData);
			if (tooltipData.Args == null)
			{
				tooltipData.Args = new List<string>();
			}
			else
			{
				tooltipData.Args.Clear();
			}
			foreach (HumanoidInstance item in leaveMapReligionRangePhase.IterateNPCsInReligionRange())
			{
				tooltipData.Args.Add(item.Info.GetFullName());
			}
		}
	}
}
