using System;
using UnityEngine;

namespace Dhs5.Utility.Settings
{
	[Serializable]
	public class PlayerPrefVector3Int : PlayerPrefMember<Vector3Int>
	{
		public override void Load()
		{
			int x = PlayerPrefs.GetInt(Key + "X", base.Default.x);
			int y = PlayerPrefs.GetInt(Key + "Y", base.Default.y);
			int z = PlayerPrefs.GetInt(Key + "Z", base.Default.z);
			m_current = new Vector3Int(x, y, z);
		}

		public override void Save(Vector3Int value)
		{
			PlayerPrefs.SetInt(Key + "X", value.x);
			PlayerPrefs.SetInt(Key + "Y", value.y);
			PlayerPrefs.SetInt(Key + "Z", value.z);
		}
	}
}
