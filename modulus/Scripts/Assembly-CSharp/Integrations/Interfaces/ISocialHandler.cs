using System;

namespace Integrations.Interfaces
{
	public interface ISocialHandler
	{
		bool Ready { get; set; }

		Action OnSocialReady { get; set; }

		void ClearPresence();

		void UpdateSocialPresenceMainMenu();

		void UpdateSocialPresenceBasedOnRank(int rank);

		void UpdateSocialPresenceCreativeMode();
	}
}
