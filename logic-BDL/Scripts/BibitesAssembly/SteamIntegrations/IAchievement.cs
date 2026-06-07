using UnityEngine;

namespace SteamIntegrations
{
	public interface IAchievement
	{
		string id { get; }

		string title { get; }

		string desc { get; }

		bool achieved { get; }

		void Sync();

		void Trigger(GameObject source = null);
	}
}
