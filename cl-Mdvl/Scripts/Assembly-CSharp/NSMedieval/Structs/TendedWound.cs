using System;
using UnityEngine;

namespace NSMedieval.Structs
{
	[Serializable]
	public struct TendedWound
	{
		[SerializeField]
		private string name;

		[SerializeField]
		private long tendTime;

		public string Name => name;

		public long TendTime => tendTime;

		public TendedWound(string name, long tendTime)
		{
			this.name = name;
			this.tendTime = tendTime;
		}
	}
}
