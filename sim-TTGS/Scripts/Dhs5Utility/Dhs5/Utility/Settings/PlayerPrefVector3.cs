using System;
using UnityEngine;

namespace Dhs5.Utility.Settings
{
	[Serializable]
	public class PlayerPrefVector3 : PlayerPrefMember<Vector3>
	{
		public override void Load()
		{
			float x = PlayerPrefs.GetFloat(Key + "X", base.Default.x);
			float y = PlayerPrefs.GetFloat(Key + "Y", base.Default.y);
			float z = PlayerPrefs.GetFloat(Key + "Z", base.Default.z);
			m_current = new Vector3(x, y, z);
		}

		public override void Save(Vector3 value)
		{
			PlayerPrefs.SetFloat(Key + "X", value.x);
			PlayerPrefs.SetFloat(Key + "Y", value.y);
			PlayerPrefs.SetFloat(Key + "Z", value.z);
		}
	}
}
