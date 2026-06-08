using Unity.Entities;

namespace Kitchen
{
	public struct CLinkedView : ISystemStateComponentData, IComponentData
	{
		public ViewIdentifier Identifier;

		public bool DoNotUpdate;
	}
}
