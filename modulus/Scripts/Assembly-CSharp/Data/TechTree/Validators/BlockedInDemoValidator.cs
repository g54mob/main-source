using UnityEngine;

namespace Data.TechTree.Validators
{
	[CreateAssetMenu(menuName = "Tech Tree/Validators/Blocked In Demo", fileName = "BlockedInDemoValidator")]
	public class BlockedInDemoValidator : AbstractTechTreeNodeValidator
	{
		public override bool CanBuy(TechTreeNodeSO node)
		{
			return false;
		}

		public override void Buy(TechTreeNodeSO node)
		{
		}
	}
}
