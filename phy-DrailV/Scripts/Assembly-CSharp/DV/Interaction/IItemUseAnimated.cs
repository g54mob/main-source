using UnityEngine;

namespace DV.Interaction
{
	public interface IItemUseAnimated : IItemUse, IInteractionPointProvider
	{
		(Vector3 pos, Quaternion rot) TargetPoint(ItemUseTarget target);
	}
}
