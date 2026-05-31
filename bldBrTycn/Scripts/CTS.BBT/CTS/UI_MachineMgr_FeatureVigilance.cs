using System;
using CTS.BBT;

namespace CTS
{
	public class UI_MachineMgr_FeatureVigilance : UI_MachineMgr_MachinePanelFeature
	{
		public override bool CanBeDisplayedForFurniture(FurnitureInteractor furniture)
		{
			return false;
		}

		protected override void OnFurnitureSet(FurnitureInteractor furniture)
		{
			throw new NotImplementedException();
		}

		protected override void OnFurnitureUnset(FurnitureInteractor furniture)
		{
			throw new NotImplementedException();
		}

		protected override void OnRepaint()
		{
			throw new NotImplementedException();
		}
	}
}
