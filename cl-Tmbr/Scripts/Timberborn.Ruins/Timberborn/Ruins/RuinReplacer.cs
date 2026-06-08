using System;
using System.Collections.Immutable;
using Timberborn.BlockSystem;
using Timberborn.Coordinates;
using Timberborn.EntitySystem;
using Timberborn.Goods;
using Timberborn.SelectionSystem;
using Timberborn.SingletonSystem;
using Timberborn.TemplateSystem;

namespace Timberborn.Ruins
{
	public class RuinReplacer : ILoadableSingleton
	{
		private readonly BlockObjectFactory _blockObjectFactory;

		private readonly TemplateService _templateService;

		private readonly EntityService _entityService;

		private readonly EntitySelectionService _entitySelectionService;

		private readonly RuinModelFactory _ruinModelFactory;

		private ImmutableArray<RuinSpec> _ruinTemplates;

		public RuinReplacer(BlockObjectFactory blockObjectFactory, TemplateService templateService, EntityService entityService, EntitySelectionService entitySelectionService, RuinModelFactory ruinModelFactory)
		{
			_blockObjectFactory = blockObjectFactory;
			_templateService = templateService;
			_entityService = entityService;
			_entitySelectionService = entitySelectionService;
			_ruinModelFactory = ruinModelFactory;
		}

		public void Load()
		{
			_ruinTemplates = _templateService.GetAll<RuinSpec>().ToImmutableArray();
		}

		public void Shuffle(Ruin originalRuin)
		{
			bool wasSelected = _entitySelectionService.IsSelected(originalRuin.GetComponent<SelectableObject>());
			_entityService.Delete(originalRuin);
			RuinSpec ruinForHeight = GetRuinForHeight(originalRuin.SpecifiedHeight);
			Ruin ruin = Instantiate(ruinForHeight, originalRuin);
			CreateModels(ruin, null, wasSelected);
		}

		public void Shrink(Ruin originalRuin)
		{
			bool wasSelected = _entitySelectionService.IsSelected(originalRuin.GetComponent<SelectableObject>());
			int amount = originalRuin.Yielder.Yield.Amount;
			_entityService.Delete(originalRuin);
			if (TryGetNextRuin(originalRuin, out var nextRuin))
			{
				Ruin ruin = Instantiate(nextRuin, originalRuin);
				CreateModels(ruin, originalRuin.GetComponent<RuinModels>().VariantId, wasSelected);
				UpdateYield(ruin, amount);
			}
		}

		private bool TryGetNextRuin(Ruin originalRuin, out RuinSpec nextRuin)
		{
			int num = originalRuin.SpecifiedHeight - 1;
			if (num == 0)
			{
				nextRuin = null;
				return false;
			}
			nextRuin = GetRuinForHeight(num);
			return true;
		}

		private RuinSpec GetRuinForHeight(int nextHeight)
		{
			ImmutableArray<RuinSpec>.Enumerator enumerator = _ruinTemplates.GetEnumerator();
			while (enumerator.MoveNext())
			{
				RuinSpec current = enumerator.Current;
				if (current.RuinHeight == nextHeight)
				{
					return current;
				}
			}
			throw new ArgumentException("No ruin template found for height " + nextHeight);
		}

		private void CreateModels(Ruin ruin, string variantId, bool wasSelected)
		{
			_ruinModelFactory.CreateModels(variantId, ruin);
			if (wasSelected)
			{
				_entitySelectionService.Select(ruin.GetComponent<SelectableObject>());
			}
		}

		private static void UpdateYield(Ruin instantiatedRuin, int currentYield)
		{
			GoodAmountSpec yield = instantiatedRuin.YielderSpec.Yield;
			int num = yield.Amount - currentYield;
			if (num > 0)
			{
				instantiatedRuin.Yielder.DecreaseYield(new GoodAmount(yield.Id, num));
			}
		}

		private Ruin Instantiate(RuinSpec nextRuinTemplate, Ruin originalRuin)
		{
			Placement placement = originalRuin.GetComponent<BlockObject>().Placement;
			return _blockObjectFactory.CreateFinished(nextRuinTemplate.GetSpec<BlockObjectSpec>(), placement).GetComponent<Ruin>();
		}
	}
}
