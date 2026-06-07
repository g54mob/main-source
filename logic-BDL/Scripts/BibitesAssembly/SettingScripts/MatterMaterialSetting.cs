using System;
using SimulationScripts;

namespace SettingScripts
{
	public class MatterMaterialSetting : SimulationSetting<MatterMaterial>
	{
		[NonSerialized]
		public string labelForNoTarget;

		public override string ToString()
		{
			if (!(val == null))
			{
				return val.Name;
			}
			return labelForNoTarget;
		}
	}
}
