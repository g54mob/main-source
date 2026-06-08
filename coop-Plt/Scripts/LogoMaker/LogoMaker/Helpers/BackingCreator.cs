using System;
using LogoMaker.Extensions;
using Shapes;
using UnityEngine;

namespace LogoMaker.Helpers
{
	public static class BackingCreator
	{
		public static void CreatingBacking(TextLayout layout, Func<Rectangle> get_rect)
		{
			Backing random = EnumExtensions.GetRandom<Backing>();
			RectangleProperties randomValues = RectangleProperties.RandomValues;
			switch (random)
			{
			case Backing.None:
				break;
			case Backing.First:
				DrawAround(layout.LayoutAreas[0], get_rect(), randomValues);
				break;
			case Backing.Last:
				DrawAround(layout.LayoutAreas[layout.LayoutAreas.Count - 1], get_rect(), randomValues);
				break;
			case Backing.All:
				DrawAround(layout.GetWholeArea(), get_rect(), randomValues);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		private static void DrawAround(LayoutArea area, Rectangle rectangle, RectangleProperties props)
		{
			Bounds bounds = area.Bounds;
			rectangle.Width = bounds.size.x;
			rectangle.Height = bounds.size.y;
			Vector3 center = bounds.center;
			rectangle.transform.localPosition = new Vector3(center.x, center.y, 1f);
			Color.RGBToHSV(new Color(0.85f, 0.62f, 0.55f), out var _, out var S, out var V);
			rectangle.Color = Color.HSVToRGB(UnityEngine.Random.Range(0f, 1f), S, V);
			props.ApplyTo(rectangle);
		}
	}
}
