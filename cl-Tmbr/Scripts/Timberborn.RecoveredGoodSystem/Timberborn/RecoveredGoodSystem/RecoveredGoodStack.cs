using System.Collections.Generic;
using System.Collections.Immutable;
using Timberborn.BaseComponentSystem;
using Timberborn.BlockSystem;
using Timberborn.Common;
using Timberborn.EntitySystem;
using Timberborn.GoodStackSystem;
using Timberborn.Goods;
using Timberborn.InventorySystem;
using Timberborn.TerrainPhysics;
using UnityEngine;

namespace Timberborn.RecoveredGoodSystem
{
	public class RecoveredGoodStack : BaseComponent, IGoodStackInventory, IInitializableEntity, INonStackPickable
	{
		private readonly EntityService _entityService;

		private ImmutableArray<GoodAmount> _initialGoodAmounts;

		public Inventory Inventory { get; private set; }

		public RecoveredGoodStack(EntityService entityService)
		{
			_entityService = entityService;
		}

		public void InitializeInventory(Inventory inventory)
		{
			Asserts.FieldIsNull(this, Inventory, "Inventory");
			Inventory = inventory;
			Inventory.Enable();
			Inventory.InventoryChanged += OnInventoryChanged;
		}

		public void InitializeEntity()
		{
			if (!_initialGoodAmounts.IsDefault)
			{
				GiveGoodAmounts(_initialGoodAmounts);
			}
			if (Inventory.IsEmpty)
			{
				Debug.LogWarning($"RecoveredGoodStack at {GetComponent<BlockObject>().Coordinates} " + "was empty after initialization. Deleting.");
				Delete();
			}
		}

		public void SetInitialGoods(IEnumerable<GoodAmount> initialGoodAmounts)
		{
			_initialGoodAmounts = initialGoodAmounts.ToImmutableArray();
		}

		public void MergeInto(RecoveredGoodStack otherGoodStack)
		{
			otherGoodStack.GiveGoodAmounts(Inventory.Stock);
			Delete();
		}

		public void GiveGoodAmounts(IEnumerable<GoodAmount> goodAmounts)
		{
			foreach (GoodAmount goodAmount in goodAmounts)
			{
				Inventory.Give(goodAmount);
			}
		}

		public void Delete()
		{
			_entityService.Delete(this);
		}

		private void OnInventoryChanged(object sender, InventoryChangedEventArgs e)
		{
			if (Inventory.IsEmpty)
			{
				Delete();
			}
		}
	}
}
