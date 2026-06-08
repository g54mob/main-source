using System.Collections.Generic;
using System.Collections.Immutable;
using Timberborn.NeedCollectionSystem;

namespace Timberborn.GameFactionSystem
{
	internal class FactionNeedCollectionIdsProvider : INeedCollectionIdsProvider
	{
		private readonly FactionService _factionService;

		public FactionNeedCollectionIdsProvider(FactionService factionService)
		{
			_factionService = factionService;
		}

		public IEnumerable<string> GetNeedCollectionIds()
		{
			ImmutableArray<string>.Enumerator enumerator = _factionService.Current.NeedCollectionIds.GetEnumerator();
			while (enumerator.MoveNext())
			{
				yield return enumerator.Current;
			}
		}
	}
}
