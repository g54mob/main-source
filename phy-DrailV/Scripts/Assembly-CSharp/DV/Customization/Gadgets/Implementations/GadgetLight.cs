using UnityEngine;

namespace DV.Customization.Gadgets.Implementations
{
	public class GadgetLight : GadgetBase
	{
		private GadgetSwitch currentController;

		[SerializeField]
		private float intensityMultiplier = 1f;

		[SerializeField]
		private LightingGadgetController lighting;

		[SerializeField]
		private IndicatorEmission emission;

		public float Value { get; private set; }

		public Color Color { get; private set; } = Color.white;

		public float IntensityMultiplier => intensityMultiplier;

		protected override void Awake()
		{
			base.Awake();
			RegisterWireLink<GadgetSwitch>(LinkController, UnlinkController, allowMultipleLinks: false);
			if (lighting != null)
			{
				lighting.UpdateColorAlpha(Value);
			}
		}

		private void StateChanged(GadgetSwitch sw)
		{
			Value = GadgetSwitch.ValueOfPower(sw, this);
		}

		private void Update()
		{
			if (lighting != null && lighting.color.a != Value)
			{
				lighting.UpdateColorAlpha(Value);
			}
			if (emission != null)
			{
				emission.Value = Value;
			}
		}

		protected override void OnPowerStateChanged(bool _ = false)
		{
			StateChanged(currentController);
		}

		private void LinkController(GadgetSwitch controller)
		{
			if (!(currentController != null))
			{
				currentController = controller;
				currentController.OnOutputValueUpdated += StateChanged;
				OnPowerStateChanged(false);
			}
		}

		private void UnlinkController(GadgetSwitch controller)
		{
			if (!(currentController != controller))
			{
				currentController.OnOutputValueUpdated -= StateChanged;
				currentController = null;
				OnPowerStateChanged(false);
			}
		}

		protected override void OnItemAssigned()
		{
			if (GadgetItemAttributeColorChanger.ExtractColor(base.GadgetItem, out var color))
			{
				Color = color;
				if (emission != null)
				{
					emission.emissionColor = color * intensityMultiplier;
					emission.emissionLight.color = color;
				}
				if (lighting != null)
				{
					lighting.UpdateColor(new Color(color.r, color.g, color.b, 0f) * color.a);
				}
			}
		}
	}
}
