using UnityEngine;

namespace Brewery.Crime
{
	public interface ICrimeQuery
	{
		bool IsPlayerWanted(ulong playerId);

		void MarkPlayerWanted(ulong playerId, Vector3 crimeLocation);

		void MarkPlayerArrested(ulong playerId);

		CrimeRateManager.PlayerWantedStatus GetPlayerWantedStatus(ulong playerId);

		void RecordArrestEscape(ulong playerId);

		void RecordPoliceAttack(ulong playerId);

		CrimeRateManager.WantedLevel GetPlayerWantedLevel(ulong playerId);

		void SetPlayerWantedLevel(ulong playerId, CrimeRateManager.WantedLevel level, string reason = "");

		void EscalateWantedLevel(ulong playerId, string reason = "");
	}
}
