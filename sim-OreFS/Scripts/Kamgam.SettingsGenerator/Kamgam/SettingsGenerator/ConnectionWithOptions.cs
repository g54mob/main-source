using System.Collections.Generic;

namespace Kamgam.SettingsGenerator
{
	public abstract class ConnectionWithOptions<TOption> : Connection<int>, IConnectionWithOptions<TOption>, IConnection<int>, IConnection, IQualityChangeReceiver
	{
		public bool HasOptions()
		{
			List<TOption> optionLabels = GetOptionLabels();
			if (optionLabels != null)
			{
				return optionLabels.Count > 0;
			}
			return false;
		}

		public abstract List<TOption> GetOptionLabels();

		public abstract void SetOptionLabels(List<TOption> optionLabels);

		public abstract void RefreshOptionLabels();
	}
}
