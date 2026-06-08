using System.Runtime.InteropServices;
using Unity.Entities;

namespace Kitchen
{
	[InternalBufferCapacity(12)]
	public struct CWaitingForItem : IBufferElementData
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct Marker : IComponentData
		{
		}

		public int ItemID;

		public Entity Item;

		public bool Satisfied;

		public int Reward;

		public int MemberIndex;

		public bool IsSide;

		public int DirtItem;

		public int SourceMenuItem;

		public int Extra;

		public bool ExtraRequested;

		public bool ExtraSatisfied;

		public bool SatisfiedBySharer;
	}
}
