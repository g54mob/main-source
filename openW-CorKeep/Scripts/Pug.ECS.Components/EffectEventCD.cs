using PugTilemap;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

public struct EffectEventCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public EffectID effectID;

	[GhostField]
	public byte localOnlyEffect;

	[GhostField(Quantization = 1000, Composite = true)]
	public float3 position1;

	[GhostField(Quantization = 1000, Composite = true)]
	public float3 vector1;

	[GhostField]
	public int value1;

	[GhostField]
	public int value2;

	[GhostField]
	public Entity entity;

	[GhostField]
	public Entity entity2;

	[GhostField]
	public TileInfo tileInfo;

	public readonly bool AreEqualInRegardsForMisprediction(EffectEventCD other)
	{
		if (this.effectID != other.effectID)
		{
			return false;
		}
		EffectID effectID = this.effectID;
		if ((effectID == EffectID.RedDamageNumber || effectID == EffectID.WhiteDamageNumber || effectID == EffectID.PlayerTakeDamage || effectID == EffectID.PlayerTakeMagicBarrierDamage) && entity == other.entity && entity2 == other.entity2)
		{
			return true;
		}
		if (value1 == other.value1 && value2 == other.value2 && entity == other.entity && tileInfo.Equals(other.tileInfo) && math.all(vector1 == other.vector1))
		{
			return math.distancesq(position1.xz, other.position1.xz) < 1.05f;
		}
		return false;
	}
}
