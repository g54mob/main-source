using System.Collections.Generic;
using LitJson;
using UnityEngine;

namespace Gh.Tk
{
	[PersistenceIgnoreParent]
	public class EntertainmentController : MonoBehaviour, IPersistable
	{
		[PersistenceOptIn]
		private List<EntertainerProfile> _entertainerProfiles;

		[JsonIgnore]
		private Dictionary<int, List<string>> _entertainerNames;

		[JsonIgnore]
		private List<EntertainerTierConfig> _entertainerTierConfigs;

		public static float EntertainerTraitDurationHours;

		private int _entertainerDefaultPlaytimeHours;

		private static void ApplyEntertained(Actor actor)
		{
		}

		private static void ApplyHighlyEntertained(Actor actor)
		{
		}

		private static T ApplyEntertainmentTrait<T>(Actor actor) where T : ActorTrait
		{
			return null;
		}

		public EntertainerTierConfig GetTierConfig(int tier)
		{
			return null;
		}

		public void Init(bool isNewGame)
		{
		}

		private void GenerateEntertainers()
		{
		}

		public EntertainerProfile GetEntertainerProfile(string profileId)
		{
			return null;
		}

		public EntertainerProfile GetEntertainerProfile(int actorId)
		{
			return null;
		}

		public void AddEntertainer(EntertainerProfile profile)
		{
		}

		public IEnumerable<EntertainerProfile> GetAvailableEntertainers()
		{
			return null;
		}

		public IEnumerable<EntertainerProfile> GetAllEntertainers()
		{
			return null;
		}

		public IEnumerable<BookedEntertainerEvent> GetBookedActs()
		{
			return null;
		}

		public bool IsEntertainmentAtTime(int hourToSpawn)
		{
			return false;
		}
	}
}
