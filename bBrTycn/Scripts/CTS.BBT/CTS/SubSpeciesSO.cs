using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	[CreateAssetMenu(fileName = "SubSpeciesMenu", menuName = "BBT/Species/SO")]
	public class SubSpeciesSO : ScriptableObject
	{
		[Serializable]
		private struct LocalizedSpecies
		{
			public ESubSpecies eSubSpecies;

			public LocalizedString localizedString;
		}

		[SerializeField]
		private List<LocalizedSpecies> _localizedSpecies;

		public LocalizedString GetLocalizedString(ESubSpecies eSubSpecies)
		{
			foreach (LocalizedSpecies localizedSpecy in _localizedSpecies)
			{
				if (localizedSpecy.eSubSpecies == eSubSpecies)
				{
					return localizedSpecy.localizedString;
				}
			}
			return null;
		}
	}
}
