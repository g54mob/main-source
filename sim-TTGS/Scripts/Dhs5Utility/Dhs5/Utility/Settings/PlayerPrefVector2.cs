using System;
using UnityEngine;

namespace Dhs5.Utility.Settings
{
	[Serializable]
	public class PlayerPrefVector2 : PlayerPrefMember<Vector2>
	{
		public override void Load()
		{
			float x = PlayerPrefs.GetFloat(Key + "X", base.Default.x);
			float y = PlayerPrefs.GetFloat(Key + "Y", base.Default.y);
			m_current = new Vector2(x, y);
		}

		public override void Save(Vector2 value)
		{
			PlayerPrefs.SetFloat(Key + "X", value.x);
			PlayerPrefs.SetFloat(Key + "Y", value.y);
		}
	}
}
