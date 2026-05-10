using CTS.BBT;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class UI_MachineMgr_FeatureGroup : UI_MachineMgr_MachinePanelFeature
	{
		[InjectScope(EGetScope.ChildrenExclusive)]
		[SerializeField]
		[Inject(false)]
		private UI_MachineMgr_MachinePanelFeature[] _features;

		public override bool CanBeDisplayedForFurniture(FurnitureInteractor furniture)
		{
			UI_MachineMgr_MachinePanelFeature[] features = _features;
			for (int i = 0; i < features.Length; i++)
			{
				if (features[i].CanBeDisplayedForFurniture(furniture))
				{
					return true;
				}
			}
			return false;
		}

		protected override void OnFurnitureSet(FurnitureInteractor furniture)
		{
		}

		protected override void OnFurnitureUnset(FurnitureInteractor furniture)
		{
		}

		protected override void OnRepaint()
		{
		}
	}
}
