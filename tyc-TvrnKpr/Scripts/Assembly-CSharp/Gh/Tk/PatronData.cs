using System.Collections.Generic;
using LitJson;
using UnityEngine.Serialization;

namespace Gh.Tk
{
	public class PatronData : ActorData
	{
		public int specificEntryPoint;

		public int Tier { get; set; }

		[JsonIgnore]
		public bool IsHero => false;

		public bool HeroIntroStoryPlayed { get; set; }

		public string TemplateId { get; set; }

		public string ChosenPrefab { get; set; }

		[field: FormerlySerializedAs("Title")]
		public string TitleKey { get; set; }

		[field: FormerlySerializedAs("Profession")]
		public string ProfessionKey { get; set; }

		[field: FormerlySerializedAs("Bio")]
		public string[] BioKeys { get; set; }

		public bool UseDirectBiosKeysTranslations { get; set; }

		public Dictionary<string, List<string>> BiosTextsPerLanguage { get; set; }

		public float Energy { get; set; }

		public float Patience { get; set; }

		public int PreferredPrivateRoomId { get; set; }

		public List<PatronNeedData> Needs { get; set; }

		public bool DisableImpromptuOptionalNeeds { get; set; }

		[JsonIgnore]
		public bool WantsAccommodation => false;

		[JsonIgnore]
		public bool WantsFood => false;

		[JsonIgnore]
		public bool WantsDrink => false;

		[JsonIgnore]
		public bool WantsShop => false;

		[JsonIgnore]
		public bool WantsCouncelor => false;

		public List<string> Prefabs { get; set; }

		public bool IsSpawned { get; set; }

		public float LastDayVisited { get; set; }

		public Dictionary<string, SatisfactionStatBase.SatisfactionStatLog> SatisfactionLogs { get; set; }

		public Dictionary<float, Dictionary<string, SatisfactionStatBase.SatisfactionStatLog>> SatisfactionLogHistory { get; set; }

		public float AverageSatisfactionFromPastVisits { get; internal set; }

		public int NumberOfPastVisits { get; internal set; }

		public int GroupId { get; internal set; }

		public int GroupSize { get; internal set; }

		public bool IsVip { get; internal set; }

		public string SpawnedByStoryNodeId { get; internal set; }

		public bool CanVisitTavern()
		{
			return false;
		}

		public bool HasVisitedWithin(float days = 1f)
		{
			return false;
		}

		public bool HasVisitedToday()
		{
			return false;
		}

		public override string GetFullNameKey()
		{
			return null;
		}

		public bool IsSatisfied()
		{
			return false;
		}

		public float GetSatisfaction(Dictionary<string, SatisfactionStatBase.SatisfactionStatLog> logs = null, string categoryFilter = null)
		{
			return 0f;
		}

		public void FillBioAndProfessionInfo()
		{
		}

		private void SetPatronProfession()
		{
		}

		public void GeneratePatronBio()
		{
		}

		private void GeneratePatronBio(string languageCode)
		{
		}

		private IEnumerable<string> GetBiosKeys(int amount, string languageCode)
		{
			return null;
		}
	}
}
