using System;
using UnityEngine;

namespace Dhs5.Utility.Settings
{
	[Serializable]
	public class PlayerPrefVector2Int : PlayerPrefMember<Vector2Int>
	{
		public override void Load()
		{
			int x = PlayerPrefs.GetInt(Key + "X", base.Default.x);
			int y = PlayerPrefs.GetInt(Key + "Y", base.Default.y);
			m_current = new Vector2Int(x, y);
		}

		public override void Save(Vector2Int value)
		{
			PlayerPrefs.SetInt(Key + "X", value.x);
			PlayerPrefs.SetInt(Key + "Y", value.y);
		}
	}
}
