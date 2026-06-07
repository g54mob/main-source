using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Wwise.API.Runtime.WwiseTypes.WwiseObjectsManagers
{
	public class WwiseEventReferencesManager
	{
		private ConcurrentDictionary<string, WwiseEventReference> m_wwiseEventReferences;

		private static WwiseEventReferencesManager instance;

		public static WwiseEventReferencesManager Instance
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public void AddReference(WwiseEventReference eventReference)
		{
		}

		public void RemoveReference(WwiseEventReference eventReference)
		{
		}

		public void SetLanguageAndReloadLocalizedBanks(string language, List<string> eventNames = null)
		{
		}
	}
}
