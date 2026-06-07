using System;
using UnityEngine;

namespace Gh.Tk
{
	public interface ITooltipProvider
	{
		event EventHandler TooltipChanged;

		TooltipData GetTooltipData();

		Vector3 GetTooltipPosition();
	}
}
