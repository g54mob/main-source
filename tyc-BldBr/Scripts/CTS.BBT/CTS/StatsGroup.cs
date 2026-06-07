using System;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public struct StatsGroup
	{
		[field: SerializeField]
		public PrestigeUIStatsSO[] Stats { get; private set; }
	}
}
