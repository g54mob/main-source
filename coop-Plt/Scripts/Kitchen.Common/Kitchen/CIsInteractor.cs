using Unity.Entities;

namespace Kitchen
{
	public struct CIsInteractor : IComponentData
	{
		public float InteractionOffset;

		public float InteractionRadius;

		public InteractionMode Mode;
	}
}
