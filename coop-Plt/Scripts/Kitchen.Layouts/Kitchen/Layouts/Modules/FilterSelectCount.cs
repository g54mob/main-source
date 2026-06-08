using System.Linq;
using Kitchen.Layouts.Features;
using UnityEngine;
using XNode;

namespace Kitchen.Layouts.Modules
{
	[CreateNodeMenu("Features/Filters/Count")]
	public class FilterSelectCount : LayoutModule
	{
		public int Count = 1;

		public override void ActOn(LayoutBlueprint blueprint)
		{
			blueprint.Features = blueprint.Features.OrderBy((Feature r) => Random.value).Take(Count).ToList();
		}
	}
}
