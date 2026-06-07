namespace DV.Customization.Gadgets.Implementations
{
	public class GadgetBrakesThermometerLOD : CustomizerLODObject<GadgetBase>
	{
		public IndicatorGauge gauge;

		private void Update()
		{
			gauge.Value = ((base.Base.PowerState && base.IsOnTrainCar) ? base.Base.TrainCar.brakeSystem.heatController.temperature : 0f);
		}
	}
}
