using Timberborn.BaseComponentSystem;
using Timberborn.NaturalResourcesLifecycle;
using Timberborn.NaturalResourcesMoisture;
using Timberborn.SoilContaminationSystem;
using Timberborn.SoilMoistureSystem;

namespace Timberborn.MapEditorNaturalResources
{
	internal class InstantNaturalResource : BaseComponent, IAwakableComponent
	{
		private LivingNaturalResource _livingNaturalResource;

		private DryObject _dryObject;

		private LivingWaterObject _livingWaterObject;

		private ContaminatedObject _contaminatedObject;

		public void Awake()
		{
			_livingNaturalResource = GetComponent<LivingNaturalResource>();
			_dryObject = GetComponent<DryObject>();
			if ((bool)_dryObject)
			{
				_dryObject.EnteredDryState += delegate
				{
					UpdateLivingState();
				};
				_dryObject.ExitedDryState += delegate
				{
					UpdateLivingState();
				};
			}
			_livingWaterObject = GetComponent<LivingWaterObject>();
			if ((bool)_livingWaterObject)
			{
				_livingWaterObject.WaterNeedsUnmet += delegate
				{
					UpdateLivingState();
				};
				_livingWaterObject.WaterNeedsMet += delegate
				{
					UpdateLivingState();
				};
			}
			_contaminatedObject = GetComponent<ContaminatedObject>();
			if ((bool)_contaminatedObject)
			{
				_contaminatedObject.EnteredContaminatedState += delegate
				{
					UpdateLivingState();
				};
				_contaminatedObject.ExitedContaminatedState += delegate
				{
					UpdateLivingState();
				};
			}
		}

		private void UpdateLivingState()
		{
			if (((bool)_dryObject && _dryObject.IsDry) || ((bool)_livingWaterObject && !_livingWaterObject.WaterNeedsAreMet) || ((bool)_contaminatedObject && _contaminatedObject.IsContaminated))
			{
				_livingNaturalResource.Die();
			}
			else
			{
				_livingNaturalResource.ReverseDeath();
			}
		}
	}
}
