using System.Collections.Generic;
using Steamworks;

namespace SteamIntegrations
{
	public static class SteamUGCHelper
	{
		private static Dictionary<EResult, string> resultDetails = new Dictionary<EResult, string>
		{
			{
				EResult.k_EResultLimitExceeded,
				"User upload limit exceeded"
			},
			{
				EResult.k_EResultFail,
				"Generic Fail... Sorry, Steam doesn't tell us more :( "
			},
			{
				EResult.k_EResultNoConnection,
				"User is not connected"
			},
			{
				EResult.k_EResultLoggedInElsewhere,
				"User is Logged-in to another application"
			},
			{
				EResult.k_EResultDuplicateName,
				"The item name already exists"
			},
			{
				EResult.k_EResultBusy,
				"Steam's servers are busy apparently. Action not taken, try again later."
			},
			{
				EResult.k_EResultBanned,
				"Apparently you're banned from Steam's cloud services... Sorry, that sucks"
			},
			{
				EResult.k_EResultDuplicateRequest,
				"This request has apparently been submitted twice, ignored the second time"
			}
		};

		public static string GetDetails(this EResult result)
		{
			if (!resultDetails.TryGetValue(result, out var value))
			{
				return "";
			}
			return ": " + value;
		}
	}
}
