using System.Collections.Generic;
using UnityEngine;

public static class UpgradeStateDataExtension
{
	private static readonly Dictionary<UpgradeState, Color> data = new Dictionary<UpgradeState, Color>
	{
		{
			UpgradeState.Hidden,
			new Color(0f, 0f, 0f, 1f)
		},
		{
			UpgradeState.Locked,
			new Color(35f / 106f, 35f / 106f, 35f / 106f, 1f)
		},
		{
			UpgradeState.Available,
			new Color(79f / 106f, 79f / 106f, 79f / 106f, 1f)
		},
		{
			UpgradeState.Purchaseable,
			new Color(0f, 1f, 0.7607844f, 1f)
		},
		{
			UpgradeState.Bought,
			new Color(0f, 0.7603686f, 1f, 1f)
		}
	};

	public static Color Value(this UpgradeState key)
	{
		return data[key];
	}
}
