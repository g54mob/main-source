using Unity.Entities;
using UnityEngine.Scripting;

[Preserve]
[TypeManager.ForcedMemoryOrdering(4854830781492898327uL)]
[TypeManager.OverrideTypeHash(1510908940499422986uL)]
public struct ObjectDataSerializedCD : IComponentData, IQueryTypeParameter
{
	public ObjectID ObjectID;

	public int Amount;

	public int Variation;

	public static implicit operator ObjectDataSerializedCD(ObjectDataCD o)
	{
		return new ObjectDataSerializedCD
		{
			ObjectID = o.objectID,
			Variation = o.variation,
			Amount = o.amount
		};
	}

	public static implicit operator ObjectDataCD(ObjectDataSerializedCD c)
	{
		return new ObjectDataCD
		{
			objectID = c.ObjectID,
			variation = c.Variation,
			amount = c.Amount
		};
	}
}
