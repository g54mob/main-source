using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	public class BuildingUsePositionsToParentComponent : BuildingUsePositionsComponent
	{
		[SerializeField]
		private Transform useParent;

		protected override void Awake()
		{
			base.WorkPositionsParent = useParent;
			base.Awake();
		}
	}
}
