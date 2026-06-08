using Rhizomatic.Reactive;
using UnityEngine;

namespace Rhizomatic
{
	public class LayoutItem
	{
		public readonly int index;

		public RectTransform rect;

		public View view;

		public Vector2 position;

		public float top => 0f;

		public float bottom => 0f;

		public float left => 0f;

		public float right => 0f;

		public LayoutItem(int index, RectTransform rect)
		{
		}

		public LayoutItem(int index)
		{
		}
	}
}
