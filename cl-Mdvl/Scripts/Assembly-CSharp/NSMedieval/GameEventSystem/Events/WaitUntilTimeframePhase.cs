using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.Model;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.UI;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.GameEventSystem.Events
{
	[FVSerializableKey("WaitUntilTimeframe", "")]
	public class WaitUntilTimeframePhase : GameEventLinearPhaseBase
	{
		[SerializeField]
		private long startTimestamp;

		[SerializeField]
		private long waitUntilTimestamp;

		[SerializeField]
		private float startTimeOfDayHours;

		[SerializeField]
		private float endTimeOfDayHours;

		[SerializeField]
		private string text;

		[SerializeField]
		private string tooltip;

		[SerializeField]
		private string icon;

		[SerializeField]
		private string factionBlueprintId;

		[SerializeField]
		private List<string> additionalTooltipLines;

		private WarningMessageData CountdownMessage { get; set; }

		public int StartTimeOfDayMinutes => (int)(startTimeOfDayHours * (float)GameEventPhaseBase.DateTime.MinutesInHour);

		public int EndTimeOfDayMinutes => (int)(endTimeOfDayHours * (float)GameEventPhaseBase.DateTime.MinutesInHour);

		private int MinutesLeft => (int)(waitUntilTimestamp - GameEventPhaseBase.DateTime.MinutesTotal);

		public WaitUntilTimeframePhase(float startTimeOfDayHours, float endTimeOfDayHours, string text, string tooltip, string icon, string factionBlueprintId = null, List<string> additionalTooltipLines = null)
		{
			this.startTimeOfDayHours = startTimeOfDayHours;
			this.endTimeOfDayHours = endTimeOfDayHours;
			this.text = text;
			this.tooltip = tooltip;
			this.icon = icon;
			this.factionBlueprintId = factionBlueprintId;
			this.additionalTooltipLines = additionalTooltipLines;
		}

		public override void Dispose()
		{
			base.Dispose();
			Unsubscribe();
			CountdownMessage = null;
		}

		private bool CheckShouldEnd()
		{
			if (GameEventPhaseBase.DateTime.MinutesSinceDay >= StartTimeOfDayMinutes)
			{
				return GameEventPhaseBase.DateTime.MinutesSinceDay <= EndTimeOfDayMinutes;
			}
			return false;
		}

		public override bool OnStart()
		{
			InitMessage();
			Subscribe();
			startTimestamp = GameEventPhaseBase.DateTime.MinutesTotal;
			int startTimeOfDayMinutes = StartTimeOfDayMinutes;
			int endTimeOfDayMinutes = EndTimeOfDayMinutes;
			int minutesSinceDay = GameEventPhaseBase.DateTime.MinutesSinceDay;
			int num = ((minutesSinceDay < startTimeOfDayMinutes || minutesSinceDay > endTimeOfDayMinutes) ? ((minutesSinceDay >= startTimeOfDayMinutes) ? (GameEventPhaseBase.DateTime.MinutesInDay - minutesSinceDay + startTimeOfDayMinutes) : (startTimeOfDayMinutes - minutesSinceDay)) : 0);
			waitUntilTimestamp = num + startTimestamp;
			Debug.Log("**** **** WE NEED TO WAIT UNTIL " + waitUntilTimestamp);
			OnQuarterHourUpdate();
			return true;
		}

		private void Subscribe()
		{
			MonoSingleton<WorldTimeManager>.Instance.QuarterHourUpdateEvent += OnQuarterHourUpdate;
		}

		private void Unsubscribe()
		{
			if (MonoSingleton<WorldTimeManager>.IsInstantiated())
			{
				MonoSingleton<WorldTimeManager>.Instance.QuarterHourUpdateEvent -= OnQuarterHourUpdate;
			}
		}

		private void OnQuarterHourUpdate()
		{
			UpdateWarningMessage();
		}

		public override void OnLoaded(bool fromSave)
		{
			InitMessage();
			Subscribe();
		}

		private void InitMessage()
		{
			CountdownMessage = new WarningMessageData(WarningMessageCategory.Warning, text, tooltip, icon, null, delegate(List<string> lines, WarningMessageData data)
			{
				if (additionalTooltipLines != null && additionalTooltipLines.Count != 0)
				{
					lines.AddRange(additionalTooltipLines);
				}
			});
			if (factionBlueprintId != null)
			{
				CountdownMessage.FactionInstance = MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.FactionInstances.FirstOrDefault((FactionInstance faction) => faction.BlueprintId.Equals(factionBlueprintId));
			}
			CountdownMessage.SetTimer(MinutesLeft);
			MonoSingleton<WarningMessageController>.Instance.ShowMessage(CountdownMessage);
		}

		private void UpdateWarningMessage()
		{
			CountdownMessage.SetTimer(MinutesLeft);
			MonoSingleton<WarningMessageController>.Instance.RefreshMessage(CountdownMessage, visible: true);
		}

		protected override bool TickShouldEnd()
		{
			if (CheckShouldEnd())
			{
				return true;
			}
			return false;
		}

		public override void OnEnd()
		{
			Unsubscribe();
			MonoSingleton<WarningMessageController>.Instance.RefreshMessage(CountdownMessage, visible: false);
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("startTimestamp", startTimestamp);
			serializer.Write("waitUntilTimestamp", waitUntilTimestamp);
			serializer.Write("startTimeOfDayHours", startTimeOfDayHours);
			serializer.Write("endTimeOfDayHours", endTimeOfDayHours);
			serializer.Write("text", text);
			serializer.Write("tooltip", tooltip);
			serializer.Write("icon", icon);
			serializer.Write("factionBlueprintId", factionBlueprintId);
			serializer.Write("additionalTooltipLines", additionalTooltipLines);
		}

		public WaitUntilTimeframePhase(FVDeserializer deserializer)
			: base(deserializer)
		{
			startTimestamp = deserializer.ReadLong("startTimestamp", 0L);
			waitUntilTimestamp = deserializer.ReadLong("waitUntilTimestamp", 0L);
			startTimeOfDayHours = deserializer.ReadFloat("startTimeOfDayHours");
			endTimeOfDayHours = deserializer.ReadFloat("endTimeOfDayHours");
			text = deserializer.ReadString("text");
			tooltip = deserializer.ReadString("tooltip");
			icon = deserializer.ReadString("icon");
			factionBlueprintId = deserializer.ReadString("factionBlueprintId");
			additionalTooltipLines = deserializer.ReadStringList("additionalTooltipLines");
		}
	}
}
