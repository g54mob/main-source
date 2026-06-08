using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using Timberborn.BaseComponentSystem;
using Timberborn.Common;
using Timberborn.CoreUI;
using Timberborn.EntityPanelSystem;
using Timberborn.Goods;
using Timberborn.GoodsUI;
using Timberborn.Localization;
using Timberborn.Reproduction;

namespace Timberborn.ReproductionUI
{
	public class BreedingPodDescriber : BaseComponent, IAwakableComponent, IEntityDescriber
	{
		private static readonly string NutrientsNeededLocKey = "Breeding.NutrientsNeeded";

		private static readonly string NutrientBringingLocKey = "Breeding.NutrientBringing";

		private readonly GoodDescriber _goodDescriber;

		private readonly ILoc _loc;

		private BreedingPod _breedingPod;

		public BreedingPodDescriber(GoodDescriber goodDescriber, ILoc loc)
		{
			_goodDescriber = goodDescriber;
			_loc = loc;
		}

		public void Awake()
		{
			_breedingPod = GetComponent<BreedingPod>();
		}

		public IEnumerable<EntityDescription> DescribeEntity()
		{
			yield return EntityDescription.CreateTextSection(Describe(), 60);
		}

		private string Describe()
		{
			StringBuilder stringBuilder = new StringBuilder();
			StringListBuilder stringListBuilder = new StringListBuilder(stringBuilder, ", ");
			stringBuilder.AppendLine(SpecialStrings.RowStarter + _loc.T(NutrientBringingLocKey));
			stringBuilder.Append(SpecialStrings.RowStarter + _loc.T(NutrientsNeededLocKey) + " ");
			ImmutableArray<GoodAmountSpec>.Enumerator enumerator = _breedingPod.NutrientsPerCycle.GetEnumerator();
			while (enumerator.MoveNext())
			{
				GoodAmountSpec current = enumerator.Current;
				stringListBuilder.BeginItem();
				GoodAmount goodAmount = new GoodAmount(current.Id, current.Amount * _breedingPod.CyclesUntilFullyGrown);
				stringBuilder.Append(_goodDescriber.Describe(goodAmount));
			}
			return stringBuilder.ToString();
		}
	}
}
