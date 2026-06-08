using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Timberborn.Goods;
using Timberborn.InventorySystem;
using Timberborn.TemplateInstantiation;

namespace Timberborn.Reproduction
{
	public class BreedingPodInventoryInitializer : IDedicatedDecoratorInitializer<BreedingPod, Inventory>
	{
		private static readonly string InventoryComponentName = "BreedingPod";

		private readonly InventoryInitializerFactory _inventoryInitializerFactory;

		public BreedingPodInventoryInitializer(InventoryInitializerFactory inventoryInitializerFactory)
		{
			_inventoryInitializerFactory = inventoryInitializerFactory;
		}

		public void Initialize(BreedingPod subject, Inventory decorator)
		{
			List<StorableGoodAmount> list = new List<StorableGoodAmount>();
			BreedingPodSpec component = subject.GetComponent<BreedingPodSpec>();
			ImmutableArray<GoodAmountSpec>.Enumerator enumerator = component.NutrientsPerCycle.GetEnumerator();
			while (enumerator.MoveNext())
			{
				GoodAmountSpec current = enumerator.Current;
				StorableGood storableGood = StorableGood.CreateAsGivable(current.Id);
				list.Add(new StorableGoodAmount(storableGood, current.Amount * component.CyclesCapacity));
			}
			InventoryInitializer inventoryInitializer = _inventoryInitializerFactory.Create(decorator, list.Sum((StorableGoodAmount good) => good.Amount), InventoryComponentName);
			inventoryInitializer.AddAllowedGoods(list);
			inventoryInitializer.Initialize();
			subject.InitializeInventory(decorator);
		}
	}
}
