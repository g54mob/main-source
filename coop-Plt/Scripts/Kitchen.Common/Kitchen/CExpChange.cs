using System;
using MessagePack;
using Unity.Entities;

namespace Kitchen
{
	[Serializable]
	[MessagePackObject(false)]
	public struct CExpChange : IComponentData
	{
		[Key(0)]
		public SPlayerLevel Old;

		[Key(1)]
		public SPlayerLevel New;

		[Key(2)]
		public int ExpGranted;

		[Key(3)]
		public int ExpIdentifier;
	}
}
