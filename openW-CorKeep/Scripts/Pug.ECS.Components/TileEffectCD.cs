using Unity.Entities;

public struct TileEffectCD : IComponentData, IQueryTypeParameter
{
	public int sfxTableDamageId;

	public int sfxTableDestroyId;
}
