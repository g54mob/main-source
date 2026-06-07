using System.Collections.Generic;
using UnityEngine;

public static class IRCColorDataExtension
{
	private static readonly Dictionary<IRCColor, Color> data = new Dictionary<IRCColor, Color>
	{
		{
			IRCColor.Red,
			new Color(0.6792453f, 0.2210751f, 0.2210751f, 1f)
		},
		{
			IRCColor.Blue,
			new Color(0.2333571f, 0.2609625f, 0.7169812f, 1f)
		},
		{
			IRCColor.Green,
			new Color(0.245105f, 0.6415094f, 0.2587448f, 1f)
		},
		{
			IRCColor.Magenta,
			new Color(83f / 106f, 0.02585441f, 0.7333713f, 1f)
		},
		{
			IRCColor.Cyan,
			new Color(0f, 0.735849f, 0.7358488f, 1f)
		},
		{
			IRCColor.Orange,
			new Color(91f / 106f, 0.4625023f, 0f, 1f)
		},
		{
			IRCColor.Purple,
			new Color(0.4936813f, 0f, 83f / 106f, 1f)
		},
		{
			IRCColor.System,
			new Color(1f, 0.4941176f, 0.9843137f, 1f)
		}
	};

	public static Color Value(this IRCColor key)
	{
		return data[key];
	}
}
