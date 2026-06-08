using KitchenData;
using UnityEngine;
using XNode;

namespace KitchenEditor
{
	public abstract class ReferenceNode<T> : Node, IGameDataReference where T : GameDataObject
	{
		[Output(ShowBackingValue.Always, ConnectionType.Multiple, TypeConstraint.None, false)]
		public T Item;

		public GameDataObject RefersTo => Item;

		private void OnValidate()
		{
			base.name = (((Object)Item == (Object)null) ? "Reference" : Item.name);
		}

		public override object GetValue(NodePort port)
		{
			return Item;
		}
	}
}
