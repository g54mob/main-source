using System;
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
	[Serializable]
	[FVSerializableKey("DelayCountdownPhase", "")]
	public class DelayCountdownPhase : GameEventLinearPhaseBase
	{
		[SerializeField]
		private long expireTimeMinutes;

		[SerializeField]
		private uint durationMinutes;

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

		private const string fvs_expireTimeMinutes = "expireTimeMinutes";

		private const string fvs_durationMinutes = "durationMinutes";

		private const string fvs_text = "text";

		private const string fvs_tooltip = "tooltip";

		private const string fvs_icon = "icon";

		private const string fvs_factionBlueprintId = "factionBlueprintId";

		private const string fvs_additionalTooltipLines = "additionalTooltipLines";

		private WarningMessageData CountdownMessage { get; set; }

		private int MinutesLeft => (int)(expireTimeMinutes - GameEventPhaseBase.CurrentTimeMinutes);

		public DelayCountdownPhase(uint minutes, string text, string tooltip, string icon, string factionBlueprintId = null, List<string> additionalTooltipLines = null)
		{
			durationMinutes = minutes;
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

		public override bool OnStart()
		{
			expireTimeMinutes = GameEventPhaseBase.CurrentTimeMinutes + durationMinutes;
			InitMessage();
			Subscribe();
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
			if (MinutesLeft <= 0)
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
			serializer.Write("expireTimeMinutes", expireTimeMinutes);
			serializer.Write("durationMinutes", durationMinutes);
			serializer.Write("text", text);
			serializer.Write("tooltip", tooltip);
			serializer.Write("icon", icon);
			serializer.Write("factionBlueprintId", factionBlueprintId);
			serializer.Write("additionalTooltipLines", additionalTooltipLines);
		}

		public DelayCountdownPhase(FVDeserializer deserializer)
			: base(deserializer)
		{
			expireTimeMinutes = deserializer.ReadLong("expireTimeMinutes", 0L);
			durationMinutes = deserializer.ReadUInt("durationMinutes");
			text = deserializer.ReadString("text");
			tooltip = deserializer.ReadString("tooltip");
			icon = deserializer.ReadString("icon");
			factionBlueprintId = deserializer.ReadString("factionBlueprintId");
			additionalTooltipLines = deserializer.ReadStringList("additionalTooltipLines");
		}
	}
}
