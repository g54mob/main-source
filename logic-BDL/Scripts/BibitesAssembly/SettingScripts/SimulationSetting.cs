using UnityEngine;

namespace SettingScripts
{
	public abstract class SimulationSetting<TValueType> : Setting<TValueType>
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
