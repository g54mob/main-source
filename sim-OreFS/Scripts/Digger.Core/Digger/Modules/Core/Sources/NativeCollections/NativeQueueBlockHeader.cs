namespace Digger.Modules.Core.Sources.NativeCollections
{
	internal struct NativeQueueBlockHeader
	{
		public unsafe byte* nextBlock;

		public int itemsInBlock;
	}
}
