using UnityEngine;

namespace Gh.Tk.Story
{
	[CreateAssetMenu(fileName = "EntertainerConfig", menuName = "Greenheart Custom/Story/Filters/Custom Entertainer")]
	public class EntertainerConfig : ScriptableObjectX
	{
		[Header("Entertain Config")]
		[StoryNodeTranslateFieldContent("Entertainer Act Name", "Node")]
		public string actName;

		[StoryNodeTranslateFieldContent("Entertainer Name", "Node")]
		public string entertainerName;

		[StoryNodeTranslateFieldContent("Entertainer Title", "Node")]
		public string entertainerTitle;

		public string modelName;

		public int tier;

		[DropDownChoice(typeof(EntertainerConfig), "GetRaces")]
		public string race;

		public Gender gender;

		public int cost;

		public int playtime;

		[DropDownChoice(new string[] { "politician", "bard", "poet" })]
		public string actType;

		[DropDownChoice(typeof(EntertainerConfig), "GetBonusRaces")]
		public string bonusRace;

		public bool isUnique;

		private static string[] GetRaces()
		{
			return null;
		}

		private static string[] GetBonusRaces()
		{
			return null;
		}
	}
}
