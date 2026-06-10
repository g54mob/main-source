using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Dictionary;
using NSMedieval.Repository;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class LeaveMapOutcomeSettings : SingletonModel<LeaveMapOutcomeSettings, LeaveMapOutcomeSettingsData>
	{
		[Serializable]
		public class MapTypeSettings
		{
			[SerializeField]
			private float escapeLoseCargoPercent;

			[SerializeField]
			private float defeatLoseCargoPercent;

			[SerializeField]
			private float tieLoseCargoPercent;

			public float EscapeLoseCargoPercent => escapeLoseCargoPercent;

			public float DefeatLoseCargoPercent => defeatLoseCargoPercent;

			public float TieLoseCargoPercent => tieLoseCargoPercent;

			public MapTypeSettings()
			{
			}

			public MapTypeSettings(float escapeLoseCargoPercent, float defeatLoseCargoPercent, float tieLoseCargoPercent)
			{
				this.escapeLoseCargoPercent = escapeLoseCargoPercent;
				this.defeatLoseCargoPercent = defeatLoseCargoPercent;
				this.tieLoseCargoPercent = tieLoseCargoPercent;
			}
		}

		[SerializeField]
		private SerializableDictionary<SecondMapType, MapTypeSettings> mapTypeSettings;

		[SerializeField]
		private float friendlinessGainAfterBanditCampVictory;

		[SerializeField]
		private float friendlinessGainAfterSettlementVictory;

		public float FriendlinessGainAfterBanditCampVictory => friendlinessGainAfterBanditCampVictory;

		public float FriendlinessGainAfterSettlementVictory => friendlinessGainAfterSettlementVictory;

		public MapTypeSettings Get(SecondMapType secondMapType)
		{
			return mapTypeSettings.Dictionary.GetValueOrDefault(secondMapType) ?? new MapTypeSettings(0f, 0f, 0f);
		}

		public override string GetID()
		{
			return "LeaveMapOutcomeSettings";
		}
	}
}
