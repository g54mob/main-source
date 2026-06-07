using UnityEngine;

namespace UMA
{
	public abstract class RaceLibraryBase : MonoBehaviour
	{
		public abstract RaceData HasRace(string raceName);

		public abstract RaceData HasRace(int raceHash);

		public abstract void AddRace(RaceData race);

		public abstract RaceData GetRace(string raceName);

		public abstract RaceData GetRace(int raceHash);

		public abstract RaceData[] GetAllRaces();

		public abstract void UpdateDictionary();

		public abstract void ValidateDictionary();
	}
}
