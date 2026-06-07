using UnityEngine;

namespace Events.SteamAchievements
{
	[CreateAssetMenu(menuName = "Events/SteamAchievements/SetSteamStatEvent", fileName = "SetSteamStatEvent", order = 0)]
	public class IncrementSteamStatEvent : BaseEvent<(string, int)>
	{
	}
}
