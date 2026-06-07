using UnityEngine;

namespace Data.TechTree.Validators
{
	[CreateAssetMenu(menuName = "Tech Tree/Validators/Is Unlockable", fileName = "IsUnlockable")]
	public class IsUnlockableValidator : AbstractTechTreeNodeValidator
	{
		public override bool CanBuy(TechTreeNodeSO node)
		{
			if (node.IncomingNodes.Count != 0)
			{
				return node.IsUnlockable;
			}
			return true;
		}

		public override void Buy(TechTreeNodeSO node)
		{
		}
	}
}
