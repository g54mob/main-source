using DV.CabControls;
using UnityEngine;

namespace DV.HUD
{
	public class PercentageControlNames : ControlNameHolderBase
	{
		public Vector2 minMaxPercentages = new Vector2(0f, 100f);

		private ControlImplBase implBase;

		private void Start()
		{
			implBase = GetComponent<ControlImplBase>();
		}

		public override (string value, string unit) GetName()
		{
			return (value: NumberUtil.MapClamp(implBase.Value, 0f, 1f, minMaxPercentages.x, minMaxPercentages.y).ToString("F0"), unit: "%");
		}
	}
}
