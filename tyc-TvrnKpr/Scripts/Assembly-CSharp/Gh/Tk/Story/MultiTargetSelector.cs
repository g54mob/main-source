using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.Story
{
	[CreateAssetMenu(fileName = "MultiTargetSelector", menuName = "Greenheart Custom/Story/Filters/Multiple Target Selector")]
	public class MultiTargetSelector : BaseTargetFilterConfig<ActorData>
	{
		[Tooltip("The filter to apply to the target actor")]
		public List<BaseActorConfig> actorFilters;

		public override List<ActorData> GetAllMatches()
		{
			return null;
		}
	}
}
