using DV.Customization.Gadgets.Implementations;
using DV.HUD;
using DV.UI.LocoHUD;
using DV.UIFramework;
using Unity.Mathematics;

namespace HUD.GadgetImplementations
{
	public class GadgetRoadrunnerHUDModule : GadgetHUDModule<GadgetRoadrunner, GadgetRoadrunnerLOD>
	{
		public int lengthIncrement;

		public LocoHUDControlBase distanceSelector;

		public LocoHUDControlBase trackButton;

		public LocoHUDControlBase resetButton;

		private void Awake()
		{
			distanceSelector.controlModule.ValueChanged += delegate(float val)
			{
				if (val != 0f)
				{
					gadget.LengthMeters += lengthIncrement * (int)math.sign(val);
				}
			};
			trackButton.controlModule.ValueChanged += delegate(float val)
			{
				if (val != 0f)
				{
					gadget.StartMeasure();
				}
			};
			resetButton.controlModule.ValueChanged += delegate(float val)
			{
				if (val != 0f)
				{
					gadget.Acknowledge();
				}
			};
			HUDProgressBarLevelModule hUDProgressBarLevelModule = distanceSelector.visualLevelModule as HUDProgressBarLevelModule;
			if (!(hUDProgressBarLevelModule != null))
			{
				return;
			}
			hUDProgressBarLevelModule.useCallbackForScrollSound = true;
			hUDProgressBarLevelModule.scrollSoundCallbackOverride = delegate(int notches)
			{
				if (notches > 0)
				{
					return gadget.LengthMeters != gadget.MaxLength;
				}
				return notches < 0 && gadget.LengthMeters != 0;
			};
		}

		private void Update()
		{
			distanceSelector.textModule.SetTextValue(gadget.LengthMeters.ToString());
			distanceSelector.textModule.SetTextUnit("m");
			trackButton.lightIndicatorModule.SetIndicatorColor(gadget.IsCounting ? UIColors.GREEN : UIColors.CLEAR);
			resetButton.lightIndicatorModule.SetIndicatorColor(gadget.HasCompleted ? UIColors.RED : UIColors.CLEAR);
			distanceSelector.visualLevelModule.SetVisualLevel(gadget.IsCounting ? (1f - gadget.Countup / (float)gadget.LengthMeters) : 0f);
		}
	}
}
