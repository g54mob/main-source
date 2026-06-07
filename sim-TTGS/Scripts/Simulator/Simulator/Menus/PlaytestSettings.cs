using Dhs5.Utility.Settings;
using UnityEngine;

namespace Simulator.Menus
{
	[Settings("Playtest", Scope.Project)]
	public class PlaytestSettings : CustomSettings<PlaytestSettings>
	{
		[SerializeField]
		private string m_surveyUrl;

		[SerializeField]
		private string m_steamGameWishlistUrl;

		public static string SurveyUrl => CustomSettings<PlaytestSettings>.I.m_surveyUrl;

		public static string SteamGameWishlistUrl => CustomSettings<PlaytestSettings>.I.m_steamGameWishlistUrl;
	}
}
