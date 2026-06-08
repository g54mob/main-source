using System;
using Unity.Entities;

namespace Kitchen
{
	[Serializable]
	public struct CMoneyPopup : IComponentData
	{
		public int Change;

		public int TwitchBits;
	}
}
