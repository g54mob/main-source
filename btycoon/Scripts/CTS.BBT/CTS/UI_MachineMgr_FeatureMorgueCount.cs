using CTS.BBT;

namespace CTS
{
	public class UI_MachineMgr_FeatureMorgueCount : UI_MachineMgr_FeatureMinusPlus<StationMorgue>
	{
		protected override bool CanBeDisplayedForFurniture(StationMorgue furniture)
		{
			return true;
		}

		protected override void OnFurnitureSet(StationMorgue furniture)
		{
			furniture.MaxBodiesChanged += OnCountChanged;
		}

		protected override void OnFurnitureUnset(StationMorgue furniture)
		{
			furniture.MaxBodiesChanged -= OnCountChanged;
		}

		protected override void OnPlusButtonTick()
		{
			StationMorgue currentFurniture = base._currentFurniture;
			currentFurniture.SetMaxBodies(currentFurniture.MaxBodies + 1);
		}

		protected override void OnMinusButtonTick()
		{
			StationMorgue currentFurniture = base._currentFurniture;
			currentFurniture.SetMaxBodies(currentFurniture.MaxBodies - 1);
		}

		protected override bool IsPlusButtonLocked(StationMorgue current)
		{
			return current.MaxBodies >= current.MaxCount;
		}

		protected override bool IsMinusButtonLocked(StationMorgue current)
		{
			return current.MaxBodies <= 1;
		}

		protected override string RepaintText(StationMorgue current)
		{
			return current.MaxBodies.ToString();
		}

		private void OnCountChanged()
		{
			OnRepaint();
		}
	}
}
