using UnityEngine;

namespace SLS.Widgets.Table
{
	public class Control
	{
		private class VerticalControl
		{
			public int top;

			public float verticalPosition;
		}

		private Factory factory;

		private Table table;

		public Control(Table table, Factory factory)
		{
		}

		public void Draw()
		{
		}

		public void HandleDataChange()
		{
		}

		private VerticalControl GetVerticalControl()
		{
			return null;
		}

		public void OnBodyScroll(Vector2 val)
		{
		}

		private void HorPosExtraText(Row row)
		{
		}

		private void CheckSizerVerticalSize()
		{
		}

		public void SetLayoutVertical()
		{
		}

		public void SetLayoutHorizontal()
		{
		}

		private float LayoutRow(Row row, float minH)
		{
			return 0f;
		}

		public void SizeForRectTransform()
		{
		}
	}
}
