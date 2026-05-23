using System;
using Integrations.Interfaces;

namespace Integrations
{
	public class DefaultPlatformCloudServiceConnector : IPlatformCloudServiceConnector
	{
		public Action<bool, string> OnLoginSequenceComplete { get; set; }

		public void AttemptLogin()
		{
			OnLoginSequenceComplete?.Invoke(arg1: true, string.Empty);
		}
	}
}
