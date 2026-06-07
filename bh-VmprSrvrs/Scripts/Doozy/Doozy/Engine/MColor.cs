using System;
using UnityEngine;

namespace Doozy.Engine
{
	[Serializable]
	public class MColor
	{
		public string Name;

		public Color M50;

		public Color M100;

		public Color M200;

		public Color M300;

		public Color M400;

		public Color M500;

		public Color M600;

		public Color M700;

		public Color M800;

		public Color M900;

		public Color A100;

		public Color A200;

		public Color A400;

		public Color A700;

		public MColor(string name, Color m50, Color m100, Color m200, Color m300, Color m400, Color m500, Color m600, Color m700, Color m800, Color m900, Color a100, Color a200, Color a400, Color a700)
		{
		}

		public MColor(string name, string m50Hex, string m100Hex, string m200Hex, string m300Hex, string m400Hex, string m500Hex, string m600Hex, string m700Hex, string m800Hex, string m900Hex, string a100Hex, string a200Hex, string a400Hex, string a700Hex)
		{
		}
	}
}
