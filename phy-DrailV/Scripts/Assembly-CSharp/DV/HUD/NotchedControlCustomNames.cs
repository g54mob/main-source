using System;
using DV.CabControls;
using DV.CabControls.Spec;
using UnityEngine;

namespace DV.HUD
{
	public class NotchedControlCustomNames : ControlNameHolderBase
	{
		public string[] customNames;

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
			int value = ((lever != null) ? Mathf.RoundToInt((float)(notches - 1) * lever.Value) : Mathf.RoundToInt((float)(notches - 1) * rotary.Value));
			return (value: customNames[Mathf.Clamp(value, 0, customNames.Length - 1)], unit: null);
		}

		private void OnValidate()
		{
			int num = GetNotches();
			if (customNames == null)
			{
				customNames = new string[num];
			}
			if (customNames.Length != num)
			{
				Array.Resize(ref customNames, num);
			}
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
