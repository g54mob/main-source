using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FlexibleColumnLayout : LayoutGroup
{
	public int Columns = 1;

	public float ColumnWidth = 256f;

	public float Spacing = 1f;

	public RectTransform ViewTransform;

	public Vector2 ViewTransformOffset;

	private float _lastMaxHeight = 64f;

	private int _lastMaxColumns = 1;

	public override float preferredHeight
	{
		get
		{
			return _lastMaxHeight;
		}
	}

	public override float preferredWidth
	{
		get
		{
			return (float)_lastMaxColumns * ColumnWidth + (float)(_lastMaxColumns - 1) * Spacing + (float)base.padding.horizontal;
		}
	}

	public override void CalculateLayoutInputVertical()
	{
	}

	private void UpdateSmallest(float[] heights, int[] list)
	{
		int num = list[0];
		for (int i = 0; i < list.Length - 1 && heights[num] > heights[list[i + 1]]; i++)
		{
			list[i] = list[i + 1];
			list[i + 1] = num;
		}
	}

	public override void SetLayoutHorizontal()
	{
		float num = ((ViewTransform == null) ? 0f : (ViewTransform.rect.height - ViewTransformOffset.y));
		int num2 = ((ViewTransform == null) ? Columns : Mathf.Max(1, Mathf.Min(Mathf.CeilToInt((base.rectChildren.Sum((RectTransform x) => x.rect.height + Spacing) - Spacing) / num), Mathf.FloorToInt((ViewTransform.rect.width - ViewTransformOffset.x) / ColumnWidth))));
		float[] array = new float[num2];
		int[] array2 = new int[num2];
		for (int num3 = 0; num3 < array.Length; num3++)
		{
			array[num3] = base.padding.top;
			array2[num3] = num3;
		}
		int num4 = 0;
		for (int num5 = 0; num5 < base.rectChildren.Count; num5++)
		{
			RectTransform rectTransform = base.rectChildren[num5];
			int num6 = array2[0];
			num4 = Mathf.Max(num6, num4);
			SetChildAlongAxis(rectTransform, 0, (float)base.padding.left + (float)num6 * (ColumnWidth + Spacing), ColumnWidth);
			SetChildAlongAxis(rectTransform, 1, array[num6]);
			array[num6] += rectTransform.rect.height + Spacing;
			UpdateSmallest(array, array2);
		}
		_lastMaxColumns = num4 + 1;
		_lastMaxHeight = 0f;
		for (int num7 = 0; num7 < array.Length; num7++)
		{
			_lastMaxHeight = Mathf.Max(array[num7], _lastMaxHeight);
		}
		_lastMaxHeight += (float)base.padding.bottom - Spacing;
	}

	public override void SetLayoutVertical()
	{
	}
}
