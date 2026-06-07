using System;
using UnityEngine;

namespace SettingScripts
{
	[Serializable]
	public abstract class NumericSimulationSetting<TValueType> : NumericSetting<TValueType>
	{
		[SerializeField]
		private TValueType Value;

		public override TValueType val
		{
			get
			{
				return Value;
			}
			set
			{
				Value = value;
			}
		}
	}
}
