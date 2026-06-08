using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Timberborn.BlueprintSystem;
using Timberborn.FactionSystem;
using Timberborn.NeedCollectionSystem;

namespace Timberborn.FactionValidators
{
	internal class FactionSpecNeedsValidator : IFactionSpecValidator
	{
		private readonly ISpecService _specService;

		public FactionSpecNeedsValidator(ISpecService specService)
		{
			_specService = specService;
		}

		public bool IsValid(FactionSpec faction, out string errorMessage)
		{
			ImmutableArray<string> needCollectionIds = faction.NeedCollectionIds;
			List<string> list = (from @group in _specService.GetSpecs<NeedCollectionSpec>()
				select @group.CollectionId).ToList();
			ImmutableArray<string>.Enumerator enumerator = needCollectionIds.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string current = enumerator.Current;
				if (!list.Contains(current))
				{
					errorMessage = "NeedCollectionSpec with id " + current + " not found";
					return false;
				}
			}
			errorMessage = null;
			return true;
		}
	}
}
