using System;
using System.Collections.Generic;
using UnityEngine;

namespace LogoMaker.Helpers
{
	public static class LayoutCreator
	{
		public static TextLayout CreateLayout(Layout layout, string text = "Seize a salad")
		{
			return layout switch
			{
				Layout.TwoPartVertical => new TextLayout
				{
					LayoutAreas = new List<LayoutArea>
					{
						LayoutArea.HorizontalBox(5f, Vector3.zero, Vector3.down),
						LayoutArea.HorizontalBox(5f, Vector3.zero, Vector3.up)
					}
				}, 
				Layout.TwoPartLine => new TextLayout
				{
					LayoutAreas = new List<LayoutArea>
					{
						LayoutArea.VerticalBox(5f, Vector3.zero, Vector3.right),
						LayoutArea.VerticalBox(5f, Vector3.zero, Vector3.left)
					}
				}, 
				Layout.Subtitle => new TextLayout
				{
					LayoutAreas = new List<LayoutArea>
					{
						LayoutArea.HorizontalBox(5f, Vector3.zero, Vector3.down),
						LayoutArea.HorizontalBox(3f, Vector3.zero, Vector3.up)
					}
				}, 
				_ => throw new ArgumentOutOfRangeException("layout", layout, null), 
			};
		}
	}
}
