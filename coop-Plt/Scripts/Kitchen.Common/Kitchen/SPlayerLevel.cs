using System;
using MessagePack;
using Unity.Entities;

namespace Kitchen
{
	[Serializable]
	[MessagePackObject(false)]
	public struct SPlayerLevel : IComponentData
	{
		[Key(0)]
		public int Level;

		[Key(1)]
		public int ExpProgress;
	}
}
