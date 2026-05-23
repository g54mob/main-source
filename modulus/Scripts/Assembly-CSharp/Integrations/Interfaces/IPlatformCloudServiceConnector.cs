using System;

namespace Integrations.Interfaces
{
	public interface IPlatformCloudServiceConnector
	{
		Action<bool, string> OnLoginSequenceComplete { get; set; }

		void AttemptLogin();
	}
}
