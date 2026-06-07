using DV.CabControls;
using DV.CabControls.Spec;
using UnityEngine;

namespace DV.HUD
{
	public class NotchedControlNumberedNames : ControlNameHolderBase
	{
		private LeverBase lever;

		private RotaryBase rotary;

		private int notches;

		private void Start()
		{
			notches = GetNotches();
			lever = GetComponent<LeverBase>();
			rotary = GetComponent<RotaryBase>();
		}

		public override (string value, string unit) GetName()
		{
			return (value: ((lever != null) ? Mathf.RoundToInt((float)(notches - 1) * lever.Value) : Mathf.RoundToInt((float)(notches - 1) * rotary.Value)).ToString(), unit: null);
		}

		private int GetNotches()
		{
			Lever component = GetComponent<Lever>();
			if ((bool)component)
			{
				return component.notches;
			}
			Rotary component2 = GetComponent<Rotary>();
			if ((bool)component2)
			{
				return component2.notches;
			}
			return 0;
		}
	}
}
