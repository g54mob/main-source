using System.Collections.Generic;
using UnityEngine;

public static class DatacenterStateDataExtension
{
	private static readonly Dictionary<DatacenterState, Color> data = new Dictionary<DatacenterState, Color>
	{
		{
			DatacenterState.Unprovisioned,
			new Color(0.33f, 0.33f, 0.33f, 1f)
		},
		{
			DatacenterState.Nominal,
			new Color(0.04313726f, 0.8392157f, 0f, 1f)
		},
		{
			DatacenterState.Degraded,
			new Color(0.8980392f, 0.5568628f, 0.07843138f, 1f)
		},
		{
			DatacenterState.Critical,
			new Color(0.8980392f, 0.07843138f, 8f / 85f, 1f)
		},
		{
			DatacenterState.Construction,
			new Color(0.3294118f, 0.3294118f, 0.3294118f, 1f)
		}
	};

	public static Color Value(this DatacenterState key)
	{
		return data[key];
	}
}
