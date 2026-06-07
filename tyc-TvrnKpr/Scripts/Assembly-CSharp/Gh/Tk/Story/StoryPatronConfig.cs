using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.Story
{
	[CreateAssetMenu(fileName = "StoryPatronConfig", menuName = "Greenheart Custom/Story/Filters/Patron")]
	public class StoryPatronConfig : BaseActorConfig
	{
		[Header("Patron Config")]
		[StoryNodeTranslateFieldContent("Patron Title", "Node")]
		public string title;

		[Tooltip("If a patron has a title, the profession won't be displayed")]
		[StoryNodeTranslateFieldContent("Patron Profession", "Node")]
		public string professionKey;

		[Tooltip("This is only used when creating a patron from the config.")]
		public PatronType patronType;

		[Range(0f, 5f)]
		[Tooltip("Tier 0 means any tier")]
		public int tier;

		[Tooltip("If a model is set then configured Gender and Race are ignored.")]
		public GameObject[] models;

		[Header("Behaviour Config")]
		[Tooltip("If empty, default needs for this tier and race at spawning hour will be used.")]
		public string[] enabledNeeds;

		public string[] disabledNeed;

		[Tooltip("if true, any needs (except drink and tavern open) will only be added if they are optional")]
		public bool onlyAllowOptionalNeeds;

		[Tooltip("If true the patron will be remembered and returned when PatronData is requested, if false we will look for any patron that matches the config")]
		public bool rememberCreatedPatron;

		[Header("Skin/Hair color overrides")]
		[Tooltip("set colors to 0/0/0 to remove override")]
		public CharacterColors colorOverrides;

		[Header("Background")]
		public string[] characterBioKeys;

		public bool DoesPatronMatchConfig(PatronData patronData)
		{
			return false;
		}

		private PatronData GetPreviouslyCreatedPatronData()
		{
			return null;
		}

		private ActorData GetMatch()
		{
			return null;
		}

		public override List<ActorData> GetAllMatches()
		{
			return null;
		}

		public override void GenerateI18nEntries(string context)
		{
		}

		protected override void OnValidateInternal()
		{
		}
	}
}
