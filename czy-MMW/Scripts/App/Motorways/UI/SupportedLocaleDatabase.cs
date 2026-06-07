using System.Collections.Generic;
using UnityEngine;

namespace Motorways.UI
{
	[CreateAssetMenu(fileName = "New Supported Locale Database", menuName = "Motorways/Locale/Supported Locale Database", order = 2)]
	public class SupportedLocaleDatabase : ScriptableObject
	{
		[SerializeField]
		private List<LocaleDatabase.LocaleId> _supportedLocales = new List<LocaleDatabase.LocaleId>();

		public List<LocaleDatabase.LocaleId> SupportedLocales => _supportedLocales;
	}
}
