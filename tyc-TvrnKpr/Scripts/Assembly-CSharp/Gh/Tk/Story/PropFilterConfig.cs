using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.Story
{
	[CreateAssetMenu(fileName = "PropFilter", menuName = "Greenheart Custom/Story/Filters/Prop")]
	public class PropFilterConfig : BaseTargetFilterConfig<Prop>
	{
		[DropDownChoice(typeof(StoryHelper), "GetAllPropOptions")]
		public string propId;

		public int maxMatches;

		public bool IsMatch(Prop gox)
		{
			return false;
		}

		public override List<Prop> GetAllMatches()
		{
			return null;
		}
	}
}
