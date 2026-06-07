using System;
using UnityEngine;

namespace Dhs5.Utility.Settings
{
	[Serializable]
	public class PlayerPrefEnum<T> : PlayerPrefMember<T> where T : struct, Enum
	{
		public override void Load()
		{
			string value = PlayerPrefs.GetString(Key, base.Default.ToString());
			m_current = (Enum.TryParse<T>(value, ignoreCase: true, out var result) ? result : base.Default);
		}

		public override void Save(T value)
		{
			PlayerPrefs.SetString(Key, value.ToString());
		}
	}
}
