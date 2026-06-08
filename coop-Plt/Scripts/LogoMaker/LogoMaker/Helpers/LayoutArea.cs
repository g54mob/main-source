using LogoMaker.Extensions;
using TMPro;
using UnityEngine;

namespace LogoMaker.Helpers
{
	public class LayoutArea
	{
		public Bounds Bounds;

		public LayoutScalingMode LayoutScalingMode;

		public Vector3 AnchorPoint;

		public void AddText(TextMeshPro tmp)
		{
			tmp.ForceMeshUpdate();
			Bounds actualBounds = tmp.GetActualBounds();
			Bounds bounds = Bounds;
			float num = 1f;
			switch (LayoutScalingMode)
			{
			case LayoutScalingMode.FreeVertical:
				num = bounds.size.x / actualBounds.size.x;
				break;
			case LayoutScalingMode.FreeHorizontal:
				num = bounds.size.y / actualBounds.size.y;
				break;
			case LayoutScalingMode.Free:
				num = Mathf.Max(bounds.size.x / actualBounds.size.x, bounds.size.y / actualBounds.size.y);
				break;
			}
			tmp.transform.localScale = new Vector3(num, num, 1f);
			Vector3 vector = num * actualBounds.extents;
			vector.Scale(-AnchorPoint);
			tmp.transform.localPosition = bounds.center + vector;
			Bounds = new Bounds(tmp.transform.localPosition, num * actualBounds.size);
		}

		public static LayoutArea HorizontalBox(float width, Vector3 position, Vector3 anchor)
		{
			return new LayoutArea
			{
				Bounds = new Bounds(position, new Vector3(width, 0f, 0f)),
				LayoutScalingMode = LayoutScalingMode.FreeVertical,
				AnchorPoint = anchor
			};
		}

		public static LayoutArea VerticalBox(float height, Vector3 position, Vector3 anchor)
		{
			return new LayoutArea
			{
				Bounds = new Bounds(position, new Vector3(0f, height, 0f)),
				LayoutScalingMode = LayoutScalingMode.FreeHorizontal,
				AnchorPoint = anchor
			};
		}
	}
}
