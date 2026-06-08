using System;
using MessagePack;
using Unity.Entities;

namespace Kitchen
{
	[Serializable]
	[MessagePackObject(false)]
	public struct CPopupRecipe : IManagedPopupData, IComponentData
	{
		[Key(0)]
		public int ID;
	}
}
