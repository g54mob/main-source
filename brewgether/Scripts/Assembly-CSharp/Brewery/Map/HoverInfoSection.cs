using System;
using System.Collections.Generic;
using UnityEngine;

namespace Brewery.Map
{
	[Serializable]
	public class HoverInfoSection
	{
		public string sectionTitle;

		public List<HoverInfoLine> lines;

		public HoverInfoSection(string title)
		{
		}

		public void AddLine(string label, string value, Color? color = null, Sprite icon = null)
		{
		}

		public void AddLine(HoverInfoLine line)
		{
		}
	}
}
