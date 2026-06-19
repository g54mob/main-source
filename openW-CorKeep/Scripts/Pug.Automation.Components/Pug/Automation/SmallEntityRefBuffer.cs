using Unity.Entities;

namespace Pug.Automation
{
	[InternalBufferCapacity(1)]
	public struct SmallEntityRefBuffer : ICleanupBufferElementData, IBufferElementData
	{
		public Entity Value;
	}
}
