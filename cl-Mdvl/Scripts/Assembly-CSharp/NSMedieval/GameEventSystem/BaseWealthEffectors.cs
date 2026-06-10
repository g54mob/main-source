using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.GameEventSystem
{
	[Serializable]
	public class BaseWealthEffectors : NSEipix.Base.Model
	{
		[Serializable]
		public class Setting
		{
			[SerializeField]
			private float minWealth;

			[SerializeField]
			private List<string> effectors;

			public float MinWealth => minWealth;

			public List<string> Effectors => effectors;
		}

		[SerializeField]
		private List<Setting> settings;

		[NonSerialized]
		private bool sortDone;

		public IEnumerable<Setting> Settings => settings;

		public override string GetID()
		{
			return "BaseWealthEffectors";
		}

		public Setting GetEffectors(float wealth)
		{
			if (settings.Count == 0)
			{
				Log.Warning("You need to define at least 1 setting in RoomImpressivenessSettings.json", "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\BaseWealthEffectors.cs");
				return null;
			}
			if (settings.Count == 1)
			{
				return settings[0];
			}
			if (!sortDone)
			{
				sortDone = true;
				settings.Sort((Setting a, Setting b) => (int)((a.MinWealth - b.MinWealth) * 1000f));
			}
			if (wealth <= settings[0].MinWealth)
			{
				return settings[0];
			}
			if (settings.Count > 2)
			{
				for (int num = 0; num < settings.Count - 2; num++)
				{
					Setting setting = settings[num];
					Setting setting2 = settings[num + 1];
					if (wealth >= setting.MinWealth && wealth < setting2.MinWealth)
					{
						return setting;
					}
				}
			}
			return settings[settings.Count - 1];
		}
	}
}
