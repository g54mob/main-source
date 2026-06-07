using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using Vectrosity;

namespace Assets.Scripts.Ui.CurveEditor
{
	public class GridScript : MonoBehaviour
	{
		private VectorLine _vectorLineMajor;

		private VectorLine _vectorLineMinor;

		private CurveEditorScript _parent;

		[SerializeField]
		private Color _primary = Color.gray;

		[SerializeField]
		private float _power = 10f;

		[SerializeField]
		private float _adjustmentFactor = 2f;

		[SerializeField]
		private float _offset;

		[SerializeField]
		private Texture _lineTexture;

		[SerializeField]
		private float _lineWidth = 4f;

		[SerializeField]
		private float _minTextWidth = 20f;

		[SerializeField]
		private float _textPixelOffset = 3f;

		[SerializeField]
		private TextMeshProUGUI _horizontalLabels;

		[SerializeField]
		private TextMeshProUGUI _verticalLabels;

		public void UpdateGrids(Vector2 min, Vector2 max, Vector2 viewportSize, CurveEditorScript parent)
		{
			_parent = parent;
			UpdateGrid(min, max, viewportSize, ref _vectorLineMajor, fade: false);
			_offset -= 1f;
			UpdateGrid(min, max, viewportSize, ref _vectorLineMinor, fade: true);
			UpdateAxisLabels(min.x, max.x, vertical: false, _horizontalLabels);
			UpdateAxisLabels(min.y, max.y, vertical: true, _verticalLabels);
			_offset += 1f;
		}

		private void UpdateGrid(Vector2 min, Vector2 max, Vector2 viewportSize, ref VectorLine line, bool fade)
		{
			if (line == null)
			{
				line = VectorLine.SetLine(_primary, Vector2.zero, Vector2.one);
				line.lineType = LineType.Discrete;
				line.lineWidth = _lineWidth + (fade ? 0f : 2f);
				line.SetCanvas(GetComponentInParent<Canvas>());
				line.texture = _lineTexture;
				line.lineWidth = _lineWidth;
				RectTransform rectTransform = line.rectTransform;
				rectTransform.SetParent(base.transform, worldPositionStays: false);
				rectTransform.localPosition = Vector3.zero;
				rectTransform.localScale = Vector3.one;
				rectTransform.sizeDelta = Vector2.zero;
				rectTransform.pivot = Vector2.zero;
			}
			line.points2.Clear();
			UpdateGridAxis(min.x, max.x, Vector2.right, Vector2.up, viewportSize, line, fade);
			UpdateGridAxis(min.y, max.y, Vector2.up, Vector2.right, viewportSize, line, fade);
			line.Draw();
		}

		private void UpdateGridAxis(float min, float max, Vector2 axis, Vector2 lineAxis, Vector2 viewportSize, VectorLine line, bool fade)
		{
			float num = Mathf.Log(max - min, _power);
			Color primary = _primary;
			if (fade)
			{
				primary.a *= 1f - (num + _offset - Mathf.Floor(num + _offset));
			}
			float num2 = Mathf.Pow(_power, Mathf.Floor(num + _offset));
			List<Vector2> points = line.points2;
			for (float num3 = Mathf.Ceil(min / num2) * num2; num3 <= max; num3 += num2)
			{
				Vector2 vector = _parent.CurveToPixel(num3 * axis) * axis;
				points.Add(vector);
				points.Add(vector + lineAxis * viewportSize);
				line.SetColor(primary, points.Count / 2 - 1);
			}
		}

		private void UpdateAxisLabels(float min, float max, bool vertical, TextMeshProUGUI text)
		{
			StringBuilder stringBuilder = new StringBuilder();
			float num = Mathf.Pow(_power, Mathf.Floor(Mathf.Log(max - min, _power) + _offset));
			float num2 = _minTextWidth / (vertical ? _parent.CurveToPixelScale.y : _parent.CurveToPixelScale.x);
			while (num < num2)
			{
				num *= _adjustmentFactor;
			}
			for (float num3 = Mathf.Floor(min / num) * num; num3 <= max; num3 += num)
			{
				stringBuilder.Append("<pos=");
				float num4 = ((!vertical) ? _parent.CurveToPixel(new Vector2(num3, 0f)).x : _parent.CurveToPixel(new Vector2(0f, num3)).y);
				stringBuilder.Append(num4 + _textPixelOffset);
				stringBuilder.Append(">");
				stringBuilder.Append(FormatNumber(num3, num));
			}
			text.SetText(stringBuilder);
		}

		private string FormatNumber(float number, float divisions)
		{
			if (Mathf.Abs(number) < divisions / 2f)
			{
				return "0";
			}
			float num = Mathf.Pow(10f, Mathf.Floor(Mathf.Log10(Mathf.Abs(number))) - 2f);
			string text = (num * Mathf.Round(number / num)).ToString();
			if (text.Contains(".") && text.Length > 5)
			{
				text = text.Substring(0, 5);
			}
			return text;
		}
	}
}
