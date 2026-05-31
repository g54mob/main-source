using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Levels/Setting List")]
	public class LevelSettingsList : ScriptableObject
	{
		[SerializeField]
		[Expandable]
		private List<LevelSetting> _settingList = new List<LevelSetting>();

		[SerializeField]
		[Expandable]
		private List<LevelSettingsList> _fallbackList = new List<LevelSettingsList>();

		private static readonly HashSet<Type> _usedKeys = new HashSet<Type>();

		public static void ClearKeys()
		{
			_usedKeys.Clear();
		}

		public bool TryGet<T>(out T outSetting) where T : LevelSetting
		{
			foreach (LevelSetting setting in _settingList)
			{
				if (setting is T val)
				{
					outSetting = val;
					return true;
				}
			}
			outSetting = null;
			return false;
		}

		public void AddSetting(LevelSetting setting)
		{
			_settingList.Add(setting);
		}

		public void ApplyAll()
		{
			ApplyAllSub(this);
			static void ApplyAllSub(LevelSettingsList list)
			{
				foreach (LevelSetting setting in list._settingList)
				{
					if (!(setting == null))
					{
						Type type = setting.GetType();
						if (_usedKeys.Add(type))
						{
							setting.Apply();
						}
					}
				}
				foreach (LevelSettingsList fallback in list._fallbackList)
				{
					ApplyAllSub(fallback);
				}
			}
		}
	}
}
