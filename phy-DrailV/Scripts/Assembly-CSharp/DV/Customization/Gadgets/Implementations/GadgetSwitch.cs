using System;
using DV.CabControls;
using DV.JObjectExtstensions;
using Newtonsoft.Json.Linq;

namespace DV.Customization.Gadgets.Implementations
{
	public class GadgetSwitch : GadgetBase
	{
		protected const string KEY_VALUE = "value";

		private float outputValue;

		public float RawOutputValue => outputValue;

		public float DefaultOutputValue
		{
			get
			{
				if (!base.PowerState)
				{
					return 0f;
				}
				return outputValue;
			}
		}

		public event Action<GadgetSwitch> OnOutputValueUpdated;

		public static float ValueOfPower(GadgetSwitch sw, GadgetBase gadget)
		{
			if (!gadget.PowerState)
			{
				return 0f;
			}
			if (!(sw != null))
			{
				return 1f;
			}
			return sw.OutputValueOf(gadget);
		}

		public static bool ValueOfPowerBool(GadgetSwitch sw, GadgetBase gadget)
		{
			return ValueOfPower(sw, gadget) > 0f;
		}

		protected override void Awake()
		{
			base.Awake();
			RegisterWireLink<GadgetBase>(OnGadgetWired, OnGadgetUnwired, allowMultipleLinks: true, markPassive: true);
		}

		public void SetOutputValue(float value)
		{
			if (value < 0f)
			{
				value = 0f;
			}
			if (value > 1f)
			{
				value = 1f;
			}
			outputValue = value;
			FireOnOutputValueUpdated();
		}

		protected virtual void OnGadgetWired(GadgetBase subscriber)
		{
		}

		protected virtual void OnGadgetUnwired(GadgetBase subscriber)
		{
		}

		protected void FireOnOutputValueUpdated()
		{
			this.OnOutputValueUpdated?.Invoke(this);
		}

		public void SetOutputValue(ValueChangedEventArgs e)
		{
			SetOutputValue(e.newValue);
		}

		protected override void OnPowerStateChanged(bool _)
		{
			FireOnOutputValueUpdated();
		}

		public override void SaveDataRequested(JObject dst)
		{
			dst.SetFloat("value", outputValue);
			base.SaveDataRequested(dst);
		}

		public override void SaveDataLoaded(JObject src)
		{
			base.SaveDataLoaded(src);
			SetOutputValue(src.GetFloat("value") ?? 0f);
		}

		public virtual float OutputValueOf(Customization.CustomizerBase customizer)
		{
			return DefaultOutputValue;
		}
	}
}
