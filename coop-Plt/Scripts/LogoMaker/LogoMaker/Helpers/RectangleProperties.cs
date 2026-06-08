using Shapes;
using UnityEngine;

namespace LogoMaker.Helpers
{
	public struct RectangleProperties
	{
		public float Expansion;

		public bool IsBorder;

		public Vector4 Radii;

		public bool IsUnderline;

		public static RectangleProperties RandomValues
		{
			get
			{
				RectangleProperties result = new RectangleProperties
				{
					Expansion = ((Random.value < 0.25f) ? 0.1f : 0f),
					IsBorder = (Random.value < 0.25f),
					IsUnderline = (Random.value < 0.25f)
				};
				result.SetCorners();
				return result;
			}
		}

		public void ApplyTo(Rectangle rect)
		{
			if (IsUnderline)
			{
				rect.transform.localPosition = rect.transform.localPosition - new Vector3(0f, rect.Height / 2f, 0f);
				rect.Height = 0.1f;
			}
			else
			{
				rect.CornerRadiii = Radii;
				rect.CornerRadiusMode = Rectangle.RectangleCornerRadiusMode.PerCorner;
				rect.Type = ((!IsBorder) ? Rectangle.RectangleType.RoundedSolid : Rectangle.RectangleType.RoundedHollow);
			}
			rect.Width *= 1f + Expansion;
			rect.Height *= 1f + Expansion;
		}

		private void SetCorners()
		{
			Radii = new Vector4(corner(), corner(), corner(), corner());
			static float corner()
			{
				float value = Random.value;
				if (value < 0.25f)
				{
					return 0f;
				}
				if (value < 0.75f)
				{
					return 0.25f;
				}
				return 2f;
			}
		}
	}
}
