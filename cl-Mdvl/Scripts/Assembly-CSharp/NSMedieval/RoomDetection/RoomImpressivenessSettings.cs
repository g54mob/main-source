using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval.RoomDetection
{
	[Serializable]
	public class RoomImpressivenessSettings : NSEipix.Base.Model
	{
		[Serializable]
		public class Setting
		{
			[SerializeField]
			private RoomImpressLevel roomImpressLevel;

			[SerializeField]
			private int minValue;

			[SerializeField]
			private string name;

			[SerializeField]
			private LocKeys[] locKeys;

			public int MinValue => minValue;

			public string Name => name;

			public string NameLocalized => MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(locKeys));

			public string InfoLocalized => MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetInfo(locKeys));

			public RoomImpressLevel RoomImpressLevel => roomImpressLevel;
		}

		private const string ImpressiveLvlName = "slightly_impressive";

		[SerializeField]
		private List<Setting> settings;

		[NonSerialized]
		private bool sortDone;

		[NonSerialized]
		private Setting impressiveSetting;

		[NonSerialized]
		private bool impressiveSettingDone;

		public Setting ImpressiveSetting
		{
			get
			{
				if (!impressiveSettingDone)
				{
					impressiveSettingDone = true;
					impressiveSetting = settings.FirstOrDefault((Setting s) => s.Name.Equals("slightly_impressive"));
				}
				return impressiveSetting;
			}
		}

		public Setting GetImpressivenessSetting(int impressivenessValue)
		{
			if (settings.Count == 0)
			{
				Log.Warning("You need to define at least 1 setting in RoomImpressivenessSettings.json", "C:\\GIT\\dev\\Assets\\Scripts\\RoomDetection\\RoomImpressivenessSettings.cs");
				return null;
			}
			if (settings.Count == 1)
			{
				return settings[0];
			}
			if (!sortDone)
			{
				sortDone = true;
				settings.Sort((Setting a, Setting b) => a.MinValue - b.MinValue);
			}
			if (impressivenessValue <= settings[0].MinValue)
			{
				return settings[0];
			}
			if (settings.Count > 2)
			{
				for (int num = 0; num < settings.Count - 2; num++)
				{
					Setting setting = settings[num];
					Setting setting2 = settings[num + 1];
					if (impressivenessValue >= setting.MinValue && impressivenessValue < setting2.MinValue)
					{
						return setting;
					}
				}
			}
			return settings[settings.Count - 1];
		}

		public override string GetID()
		{
			return "RoomImpressivenessSettings";
		}
	}
}
