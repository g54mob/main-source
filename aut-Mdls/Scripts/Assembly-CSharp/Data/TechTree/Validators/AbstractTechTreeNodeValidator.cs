using UnityEngine;

namespace Data.TechTree.Validators
{
	public abstract class AbstractTechTreeNodeValidator : ScriptableObject
	{
		public abstract bool CanBuy(TechTreeNodeSO node);

		public abstract void Buy(TechTreeNodeSO node);
	}
}
