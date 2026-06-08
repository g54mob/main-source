using System;
using MessagePack;
using Unity.Entities;

namespace Kitchen
{
	[Serializable]
	[MessagePackObject(false)]
	public struct CPopupEndDayData : IManagedPopupData, IComponentData
	{
		[Key(0)]
		public int Base;

		[Key(1)]
		public int PlayerBonus;
	}
}
