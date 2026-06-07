using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.Story
{
	[CreateAssetMenu(fileName = "CustomStaffConfig", menuName = "Greenheart Custom/Story/Filters/Custom Staff")]
	public class StaffDataConfig : BaseActorConfig
	{
		[Header("Staff Config")]
		[DropDownChoice(typeof(StoryHelper), "GetRaces")]
		public string race;

		public string prefabVariant;

		[Range(1f, 3f)]
		[Tooltip("if set, this tier will be used to generate the staff skills. if staff skills and tiers are set, the maximum tier will be used as the target tier")]
		public int staffTier;

		[Header("Background")]
		[StoryNodeTranslateFieldContent("Character Bio", "Node")]
		public string[] characterBio;

		public StoryGraph characterStory;

		[Header("Traits")]
		[DropDownChoice(typeof(StoryHelper), "GetStaffTraits")]
		public string[] traits;

		public bool removeAllRandomTraits;

		[DropDownChoice(typeof(StoryHelper), "GetStaffTraits")]
		public string[] forbidTraits;

		[Header("Mental Breaks")]
		public bool setSpecificMentalBreakTrait;

		[DropDownChoice(typeof(StoryHelper), "GetMentalBreakTraits")]
		public string mentalBreakTrait;

		[Header("Stats - Server")]
		[Range(0f, 3f)]
		public int serverTier;

		[Range(-1f, 100f)]
		public int serverSkill;

		[Header("Stats - Chef")]
		[Range(0f, 3f)]
		public int chefTier;

		[Range(-1f, 100f)]
		public int chefSkill;

		[Header("Stats - Janitor")]
		[Range(0f, 3f)]
		public int janitorTier;

		[Range(-1f, 100f)]
		public int janitorSkill;

		[Header("Stats - Dogsbody")]
		[Range(0f, 3f)]
		public int dogsbodyTier;

		[Range(-1f, 100f)]
		public int dogsbodySkill;

		[Header("Skin/Hair color overrides")]
		[Tooltip("set colors to 0/0/0 to remove override")]
		public CharacterColors colorOverrides;

		public bool useMultipleMatches;

		private ActorData GetMatch()
		{
			return null;
		}

		public Staff GetTargetStaff()
		{
			return null;
		}

		public override List<ActorData> GetAllMatches()
		{
			return null;
		}
	}
}
