using Unity.Entities;

namespace Kitchen
{
	public struct CDeleteTransitionAfterFrames : IComponentData
	{
		public int Frames;
	}
}
