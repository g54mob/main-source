using System.Collections.Generic;
using System.Collections.Immutable;
using Timberborn.TimbermeshMaterials;

namespace Timberborn.GameFactionSystem
{
	internal class FactionMaterialCollectionIdsProvider : IMaterialCollectionIdsProvider
	{
		private readonly FactionService _factionService;

		public FactionMaterialCollectionIdsProvider(FactionService factionService)
		{
			_factionService = factionService;
		}

		public IEnumerable<string> GetMaterialCollectionIds()
		{
			ImmutableArray<string>.Enumerator enumerator = _factionService.Current.MaterialCollectionIds.GetEnumerator();
			while (enumerator.MoveNext())
			{
				yield return enumerator.Current;
			}
		}
	}
}
