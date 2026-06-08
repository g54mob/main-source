using System;
using MessagePack;
using Unity.Entities;

namespace Kitchen
{
	[Serializable]
	[MessagePackObject(false)]
	public struct CPopupFloat : IManagedPopupData, IComponentData
	{
		[Key(0)]
		public int Value;
	}
}
