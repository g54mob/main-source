using Rhizomatic.Reactive;
using UnityEngine;

namespace GRP
{
	public class CollapsibleView : View<CollapsibleViewable>
	{
		public CollapsibleButton button;

		public RectTransform content;

		public RectTransform container;

		public Direction direction;

		public float multiplier;

		private Canvas canvas;

		private Vector2 currentAnchorMin;

		private Vector2 currentAnchorMax;

		private Vector2 closeMin;

		private Vector2 closeMax;

		private Vector2 openMin;

		private Vector2 openMax;

		protected override void OnViewCreated()
		{
		}

		protected override void OnViewOpen()
		{
		}

		protected override void OnViewClose()
		{
		}

		protected override void OnRender()
		{
		}

		protected override void Update()
		{
		}

		public void OnEndDrag(Vector2 delta)
		{
		}

		public Vector2 Lerp(Vector2 a, Vector2 b, float t)
		{
			return default(Vector2);
		}

		public void ResetOffset()
		{
		}

		public void SetupAnchors()
		{
		}

		public void SetAnchors()
		{
		}

		public void OnClick()
		{
		}
	}
}
