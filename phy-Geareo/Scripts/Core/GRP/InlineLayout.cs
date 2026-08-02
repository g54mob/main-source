using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GRP
{
	[ExecuteAlways]
	public class InlineLayout : UIBehaviour
	{
		[Serializable]
		public struct Padding
		{
			public float left;

			public float right;

			public float top;

			public float bottom;
		}

		public Padding padding;

		private RectTransform _container;

		private Vector3[] sizes;

		private Rect[] rects;

		public RectTransform container => null;

		protected override void OnRectTransformDimensionsChange()
		{
		}

		protected override void OnTransformParentChanged()
		{
		}

		public void Build()
		{
		}

		public float BuildRow(Vector2Int range, float offset, float leftOver)
		{
			return 0f;
		}

		public Vector3 GetPosition(Vector3 pos)
		{
			return default(Vector3);
		}

		public Vector3 GetVector(Vector3 vector)
		{
			return default(Vector3);
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
