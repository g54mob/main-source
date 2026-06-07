using Assets.Scripts.Craft.Wings.Airfoils;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Design.UI
{
	public class AirfoilPreviewWidget : WidgetScript
	{
		private AirfoilPreviewRenderer _renderer;

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			base.gameObject.AddComponent<CanvasRenderer>();
			_renderer = base.gameObject.AddComponent<AirfoilPreviewRenderer>();
		}

		public void SetAirfoil(IAirfoil airfoil)
		{
			_renderer.SetAirfoil(airfoil);
		}
	}
}
