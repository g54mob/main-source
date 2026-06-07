using System.Collections;
using DV.CabControls;
using DV.Utils;
using UnityEngine;

namespace DV.Customization.Gadgets.Implementations
{
	public class GadgetSwitchLOD : CustomizerLODObject<GadgetSwitch>
	{
		public GameObject controlKnob;

		public IndicatorEmission indicator;

		private ControlImplBase controlKnobControl;

		private void Start()
		{
			SingletonBehaviour<CoroutineManager>.Instance.StartCoroutine(Initialize());
		}

		private IEnumerator Initialize()
		{
			controlKnobControl = controlKnob.GetComponent<ControlImplBase>();
			base.Base.OnOutputValueUpdated += UpdateIndicatorLight;
			yield return null;
			if ((bool)controlKnobControl && (bool)base.Base)
			{
				controlKnobControl.ValueChanged += base.Base.SetOutputValue;
				SyncControls();
			}
		}

		public void SyncControls()
		{
			controlKnobControl.SetValue(base.Base.RawOutputValue);
		}

		private void UpdateIndicatorLight(GadgetSwitch sw)
		{
			if (indicator != null)
			{
				indicator.Value = Mathf.Clamp01(sw.DefaultOutputValue);
			}
		}
	}
}
