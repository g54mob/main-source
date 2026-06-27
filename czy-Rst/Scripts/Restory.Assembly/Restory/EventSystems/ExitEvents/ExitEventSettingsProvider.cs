using System.Collections.Generic;
using UnityEngine;

namespace Restory.EventSystems.ExitEvents
{
	public class ExitEventSettingsProvider
	{
		private readonly Dictionary<string, ExitEventSettingsData> settingsCache = new Dictionary<string, ExitEventSettingsData>();

		public ExitEventSettingsProvider(ExitEventSettings exitEventSettings)
		{
			CacheSettings(exitEventSettings);
		}

		public bool TryGetSettings(string handlerID, out ExitEventSettingsData handlerSettings)
		{
			if (!settingsCache.TryGetValue(handlerID, out handlerSettings))
			{
				Debug.LogError("settingsCache not contains settings for handler " + handlerID);
				return false;
			}
			return true;
		}

		private void CacheSettings(ExitEventSettings exitEventSettings)
		{
			foreach (ExitEventSettingsData entry in exitEventSettings.Entries)
			{
				if (entry == null)
				{
					Debug.LogError("exitEventSettings contains empty entry");
				}
				else if (!settingsCache.TryAdd(entry.Identificator.ID, entry))
				{
					Debug.LogError("exitEventSettings contains duplicate identificator " + entry.Identificator.ID);
				}
			}
		}
	}
}
