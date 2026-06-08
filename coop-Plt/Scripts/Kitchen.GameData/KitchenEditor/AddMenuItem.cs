using System.Collections.Generic;
using KitchenData;
using XNode;

namespace KitchenEditor
{
	[CreateNodeMenu("Menu Item")]
	[NodeWidth(300)]
	public class AddMenuItem : ReferenceNode<Item>, IUnlockNode
	{
		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public UnlockConnection UnlockedBy;

		public MenuPhase Phase = MenuPhase.Main;

		public float Weight = 1f;

		public DynamicMenuType DynamicMenuType;

		public Item DynamicMenuIngredient;

		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false, dynamicPortList = true)]
		public List<Item> IngredientUnlocks;

		public override object GetValue(NodePort port)
		{
			return null;
		}
	}
}
