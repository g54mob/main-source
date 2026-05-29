using System;
using UnityEngine;

namespace SaveData
{
	[Serializable]
	public class LevelupAbility
	{
		[SerializeField]
		private int startLevel;

		[SerializeField]
		private int each;

		[SerializeField]
		private eUpgradeKind kind;

		[SerializeField]
		private bool isGetStart;

		public LevelupAbility(int startLevel, int each, eUpgradeKind kind, bool isGetStart = false)
		{
		}

		public eUpgradeKind CheckAbility(int nowLevel)
		{
			return default(eUpgradeKind);
		}
	}
}
