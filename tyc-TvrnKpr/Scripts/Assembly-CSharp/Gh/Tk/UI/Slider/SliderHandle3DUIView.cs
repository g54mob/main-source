using UnityEngine;

namespace Gh.Tk.UI.Slider
{
	public class SliderHandle3DUIView : Button3DUIView
	{
		public Vector2 MouseOffsetFromCenter;

		public Slider3DUIView SliderParent { get; set; }

		protected override void UpdateIsPressed()
		{
		}
	}
}
