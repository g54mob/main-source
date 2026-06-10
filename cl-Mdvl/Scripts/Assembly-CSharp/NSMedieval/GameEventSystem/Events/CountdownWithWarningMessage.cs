using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.Model;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.UI;
using NSMedieval.Utils.TimeHelpers;
using NSMedieval.WorldMap;

namespace NSMedieval.GameEventSystem.Events
{
	[FVSerializableKey("CountdownWithWarningMessage", "")]
	public class CountdownWithWarningMessage : IFVSerializable
	{
		private string text;

		private string tooltip;

		private string icon;

		private List<string> additionalTooltipLines;

		private string factionBlueprintId;

		private TimeInterval timeInterval;

		private bool showWarningMessage;

		private const string fvs_text = "text";

		private const string fvs_tooltip = "tooltip";

		private const string fvs_icon = "icon";

		private const string fvs_additionalTooltipLines = "additionalTooltipLines";

		private const string fvs_factionBlueprintId = "factionBlueprintId";

		private const string fvs_timeInterval = "timeInterval";

		private WarningMessageData CountdownMessage { get; set; }

		public TimeInterval TimeInterval => timeInterval;

		public Action<WarningMessageData> OnClick
		{
			get
			{
				return CountdownMessage?.ClickAction;
			}
			set
			{
				if (CountdownMessage != null)
				{
					CountdownMessage.ClickAction = value;
					if (value != null)
					{
						UpdateWarningMessage();
					}
				}
			}
		}

		public CountdownWithWarningMessage(string text, string tooltip, string icon, int durationMinutes, string factionBlueprintId = null, List<string> additionalTooltipLines = null, bool showWarningMessage = true)
		{
			this.text = text;
			this.tooltip = tooltip;
			this.icon = icon;
			this.additionalTooltipLines = additionalTooltipLines;
			this.factionBlueprintId = factionBlueprintId;
			timeInterval = TimeInterval.FromNowMinutes(durationMinutes);
			this.showWarningMessage = showWarningMessage;
			OnStart();
		}

		public void OnStart()
		{
			InitMessage();
			Subscribe();
		}

		public void OnLoaded()
		{
			InitMessage();
			Subscribe();
		}

		public void Dispose()
		{
			Unsubscribe();
			if (MonoSingleton<WarningMessageController>.IsInstantiated() && showWarningMessage)
			{
				MonoSingleton<WarningMessageController>.Instance.RefreshMessage(CountdownMessage, visible: false);
			}
			if (showWarningMessage)
			{
				CountdownMessage?.Dispose();
			}
		}

		private void Subscribe()
		{
			if (showWarningMessage)
			{
				MonoSingleton<WorldTimeManager>.Instance.QuarterHourUpdateEvent += OnQuarterHourUpdate;
			}
		}

		private void Unsubscribe()
		{
			if (showWarningMessage && MonoSingleton<WorldTimeManager>.IsInstantiated())
			{
				MonoSingleton<WorldTimeManager>.Instance.QuarterHourUpdateEvent -= OnQuarterHourUpdate;
			}
		}

		private void OnQuarterHourUpdate()
		{
			UpdateWarningMessage();
		}

		private void InitMessage()
		{
			if (!showWarningMessage)
			{
				return;
			}
			CountdownMessage = new WarningMessageData(WarningMessageCategory.Warning, text, tooltip, icon, null, delegate(List<string> lines, WarningMessageData data)
			{
				if (additionalTooltipLines != null)
				{
					lines.AddRange(additionalTooltipLines);
				}
			});
			if (factionBlueprintId != null)
			{
				CountdownMessage.FactionInstance = MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.FactionInstances.FirstOrDefault((FactionInstance faction) => faction.BlueprintId.Equals(factionBlueprintId));
			}
			MonoSingleton<WarningMessageController>.Instance.ShowMessage(CountdownMessage);
		}

		private void UpdateWarningMessage()
		{
			if (showWarningMessage)
			{
				CountdownMessage.SetTimer(timeInterval.MinutesLeft);
				MonoSingleton<WarningMessageController>.Instance.RefreshMessage(CountdownMessage, visible: true);
			}
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("text", text);
			serializer.Write("tooltip", tooltip);
			serializer.Write("icon", icon);
			serializer.Write("additionalTooltipLines", additionalTooltipLines);
			serializer.Write("factionBlueprintId", factionBlueprintId);
			serializer.Write("timeInterval", timeInterval);
			serializer.Write("showWarningMessage", showWarningMessage);
		}

		public CountdownWithWarningMessage(FVDeserializer deserializer)
		{
			text = deserializer.ReadString("text");
			tooltip = deserializer.ReadString("tooltip");
			icon = deserializer.ReadString("icon");
			additionalTooltipLines = deserializer.ReadStringList("additionalTooltipLines");
			factionBlueprintId = deserializer.ReadString("factionBlueprintId");
			timeInterval = deserializer.ReadObject<TimeInterval>("timeInterval");
			showWarningMessage = deserializer.ReadBool("showWarningMessage");
		}
	}
}
