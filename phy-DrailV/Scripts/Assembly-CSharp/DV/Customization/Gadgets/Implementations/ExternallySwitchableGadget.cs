namespace DV.Customization.Gadgets.Implementations
{
	public class ExternallySwitchableGadget : GadgetBase
	{
		protected override void Awake()
		{
			base.Awake();
			RegisterWireLink<GadgetSwitch>(SwitchWired, SwitchUnwired, allowMultipleLinks: false);
		}

		private void SwitchWired(GadgetSwitch sw)
		{
			sw.OnOutputValueUpdated += UpdateState;
			UpdateState(sw);
		}

		private void SwitchUnwired(GadgetSwitch sw)
		{
			sw.OnOutputValueUpdated -= UpdateState;
			UpdateState(null);
		}

		private void UpdateState(GadgetSwitch sw)
		{
			base.PowerSwitch = sw == null || sw.OutputValueOf(this) > 0f;
		}
	}
}
