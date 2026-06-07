using System;
using UnityEngine;

namespace Gh.Tk.Story
{
	[Serializable]
	public class TemplateItemUnlockConfig
	{
		[DropDownChoice(typeof(StoryHelper), "GetCreatorCustomTemplates")]
		public string decoProp;

		public GameLevel[] levels;

		[Range(0f, 5f)]
		public float minTavernStar;

		[Range(0f, 5f)]
		public float maxTavernStar;

		[Range(0f, 200f)]
		[Tooltip("The height the weighting the higher the change when being selected for unlock.")]
		public int percentageWeighting;

		[Tooltip("This is in addition to the TemplateOf base prop that would also be required to be unlocked.")]
		[DropDownChoice(typeof(StoryHelper), "GetAllPropOptions")]
		public string[] additionalPropsRequired;

		[DropDownChoice(typeof(StoryHelper), "GetAllDecoProps")]
		public string[] additionalDecoPropsRequired;

		[Tooltip("If set to the same prop group, weighting will be double when one of the propgroup is unlocked already.")]
		public string propGroup;
	}
}
