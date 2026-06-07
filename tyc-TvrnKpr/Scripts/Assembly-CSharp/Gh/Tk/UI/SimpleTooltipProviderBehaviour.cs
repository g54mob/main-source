using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class SimpleTooltipProviderBehaviour : MonoBehaviour, ITooltipProvider
	{
		public Func<TooltipData> LazyTooltipData;

		public string HeaderKey { get; set; }

		public string ContentKey { get; set; }

		public TooltipData Tooltip { get; set; }

		public event EventHandler TooltipChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public TooltipData GetTooltipData()
		{
			return null;
		}

		public Vector3 GetTooltipPosition()
		{
			return default(Vector3);
		}
	}
}
