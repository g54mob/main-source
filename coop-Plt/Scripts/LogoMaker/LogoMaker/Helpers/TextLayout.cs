using System.Collections.Generic;
using UnityEngine;

namespace LogoMaker.Helpers
{
	public class TextLayout
	{
		public List<LayoutArea> LayoutAreas = new List<LayoutArea>();

		public LayoutArea GetWholeArea()
		{
			if (LayoutAreas.Count == 0)
			{
				return new LayoutArea();
			}
			Bounds bounds = new Bounds(LayoutAreas[0].Bounds.center, Vector3.zero);
			foreach (LayoutArea layoutArea in LayoutAreas)
			{
				bounds.Encapsulate(layoutArea.Bounds);
			}
			return new LayoutArea
			{
				LayoutScalingMode = LayoutScalingMode.Fixed,
				Bounds = bounds,
				AnchorPoint = Vector3.zero
			};
		}
	}
}
