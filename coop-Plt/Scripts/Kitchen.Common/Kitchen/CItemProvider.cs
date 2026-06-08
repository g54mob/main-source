using JetBrains.Annotations;
using KitchenData;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public struct CItemProvider : IApplianceProperty, IAttachableProperty, IComponentData, IAttachmentLogic
	{
		[SerializeField]
		private int Item;

		public int Available;

		public int Maximum;

		public bool DirectInsertionOnly;

		public bool EmptyAtNight;

		public bool PreventReturns;

		public bool DestroyOnEmpty;

		public bool AutoGrabFromHolder;

		public bool AutoPlaceOnHolder;

		public bool AllowRefreshes;

		public int ProvidedItem;

		public ItemList ProvidedComponents;

		public int DefaultProvidedItem => Item;

		public static CItemProvider InfiniteItemProvider(int e)
		{
			CItemProvider result = default(CItemProvider);
			result.SetAsItem(e);
			return result;
		}

		public void SetAsItem(int id)
		{
			ProvidedItem = id;
			ProvidedComponents = new ItemList(id);
		}

		public static CItemProvider EditorCreateProvider(Item i)
		{
			return new CItemProvider
			{
				Item = i.ID
			};
		}

		[Pure]
		public bool Matches(int id)
		{
			if (ProvidedItem == id)
			{
				return ProvidedComponents.IsNonGroup;
			}
			return false;
		}

		[Pure]
		public bool HasAvailableItems()
		{
			if (ProvidedItem != 0)
			{
				if (Available < 0)
				{
					return Maximum <= 0;
				}
				return true;
			}
			return false;
		}

		public void Attach(EntityManager em, EntityCommandBuffer ecb, Entity e)
		{
			SetAsItem(Item);
			ecb.AddComponent(e, this);
		}
	}
}
