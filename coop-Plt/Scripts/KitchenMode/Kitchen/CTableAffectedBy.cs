using Unity.Entities;

namespace Kitchen
{
	[InternalBufferCapacity(8)]
	public struct CTableAffectedBy : IBufferElementData
	{
		public int EffectRepresentation;

		public bool Active;
	}
}
