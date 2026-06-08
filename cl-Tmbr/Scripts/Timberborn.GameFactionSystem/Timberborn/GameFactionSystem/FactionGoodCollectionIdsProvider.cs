using System.Collections.Generic;
using System.Collections.Immutable;
using Timberborn.GoodCollectionSystem;

namespace Timberborn.GameFactionSystem
{
	internal class FactionGoodCollectionIdsProvider : IGoodCollectionIdsProvider
	{
		private readonly FactionService _factionService;

		public FactionGoodCollectionIdsProvider(FactionService factionService)
		{
			_factionService = factionService;
		}

		public IEnumerable<string> GetGoodCollectionIds()
		{
			ImmutableArray<string>.Enumerator enumerator = _factionService.Current.GoodCollectionIds.GetEnumerator();
			while (enumerator.MoveNext())
			{
				yield return enumerator.Current;
			}
		}
	}
}
