using System;
using System.Collections.Generic;
using UnityEngine;

namespace SettingScripts
{
	public abstract class ColorSetting : Setting<Color>
	{
		[NonSerialized]
		public bool allowAlphaChange;

		[NonSerialized]
		public List<Color> presetColors;
	}
}
