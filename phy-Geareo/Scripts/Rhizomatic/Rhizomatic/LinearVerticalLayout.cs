using UnityEngine;

namespace Rhizomatic
{
	public class LinearVerticalLayout : LinearLayout
	{
		protected override bool GetInvertedScroll()
		{
			return false;
		}

		protected override float GetAxis(Vector2 vector)
		{
			return 0f;
		}

		protected override float GetCrossAxis(Vector2 vector)
		{
			return 0f;
		}

		protected override float GetStart(LayoutItem item)
		{
			return 0f;
		}

		protected override float GetEnd(LayoutItem item)
		{
			return 0f;
		}

		protected override Vector2 GetVector(float axis, float crossAxis)
		{
			return default(Vector2);
		}

		protected override void SetupItem(RectTransform r, float axisSize, float crossAxisSize, float start)
		{
		}

		protected override void BuildLayout()
		{
		}

		public void UpdatePlacement()
		{
		}
	}
}
