#define LOG_LEVEL_VERBOSE
using System.Collections.Generic;
using FullInspector;

namespace TH20
{
	[DontSave]
	public class DLCManager
	{
		public class Config
		{
			public List<SharedInstance<DLCItemDefinition>> DLCItems;
		}

		private readonly Config _config;

		private readonly HashSet<DLCItemDefinition> _installedDLC = new HashSet<DLCItemDefinition>();

		public IReadOnlyCollection<SharedInstance<DLCItemDefinition>> AvailableItems => _config.DLCItems.AsReadOnly();

		public DLCManager(Config config)
		{
			_config = config;
			RevalidatePurchasedDLC();
		}

		public bool IsDLCInstalled(DLCItemDefinition dlcItem)
		{
			return _installedDLC.Contains(dlcItem);
		}

		public void RevalidatePurchasedDLC()
		{
			_installedDLC.Clear();
			foreach (SharedInstance<DLCItemDefinition> dLCItem in _config.DLCItems)
			{
				if (!dLCItem.IsNull() && DLCUtils.IsDLCInstalled(dLCItem.Instance))
				{
					_installedDLC.Add(dLCItem.Instance);
					Logging.Info(LogChannels.Online, $"DLC Module Installed: {dLCItem.Instance.Name.Term}");
				}
			}
		}

		public DLCItemDefinition GetDLCByAppID(uint appID)
		{
			return _config.DLCItems.Find((SharedInstance<DLCItemDefinition> x) => x.Instance.AppID == appID)?.Instance;
		}
	}
}
