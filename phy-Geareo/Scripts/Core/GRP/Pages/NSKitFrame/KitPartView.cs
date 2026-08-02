using Rhizomatic.Reactive;
using UnityEngine;

namespace GRP.Pages.NSKitFrame
{
	public class KitPartView : View<KitPartViewable>
	{
		public RectTransform rect;

		public TooltipArea tooltip;

		public float multiplier;

		protected override void OnRender()
		{
		}
	}
}
