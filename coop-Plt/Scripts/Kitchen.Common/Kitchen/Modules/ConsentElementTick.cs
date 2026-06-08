using Shapes;
using UnityEngine;

namespace Kitchen.Modules
{
	public class ConsentElementTick : MonoBehaviour
	{
		public RegularPolygon Polygon;

		public SpriteRenderer Tick;

		public void Setup(Color c, int sides, bool ready)
		{
			if (Polygon != null)
			{
				Polygon.gameObject.SetActive(ready);
				RegularPolygon polygon = Polygon;
				polygon.Sides = sides switch
				{
					0 => 10, 
					1 => 3, 
					2 => 4, 
					_ => 6, 
				};
				Polygon.Roundness = ((sides == 0) ? 1f : 0.25f);
				Polygon.Radius = ((Polygon.Sides == 3) ? 0.4f : 0.3f);
				Polygon.Color = c;
			}
			if (Tick != null)
			{
				Tick.gameObject.SetActive(ready);
				Color.RGBToHSV(c, out var H, out var S, out var V);
				V *= 0.75f;
				Color color = Color.HSVToRGB(H, S, V);
				Tick.color = (ready ? color : new Color(0f, 0f, 0f, 0f));
			}
		}
	}
}
