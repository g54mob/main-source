using Unity.Entities;

namespace Kitchen
{
	public class KitchenArchetype
	{
		public ComponentType[] ComponentList;

		public KitchenArchetype(params ComponentType[] componentList)
		{
			ComponentList = componentList;
		}

		public KitchenArchetype(KitchenArchetype parent, params ComponentType[] componentList)
		{
			ComponentList = new ComponentType[parent.ComponentList.Length + componentList.Length];
			parent.ComponentList.CopyTo(ComponentList, 0);
			componentList.CopyTo(ComponentList, parent.ComponentList.Length);
		}

		public static implicit operator ComponentType[](KitchenArchetype a)
		{
			return a.ComponentList;
		}
	}
}
