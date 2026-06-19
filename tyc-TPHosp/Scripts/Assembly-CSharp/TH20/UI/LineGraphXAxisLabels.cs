using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TH20.UI
{
	public class LineGraphXAxisLabels : UIBehaviour
	{
		[SerializeField]
		private LineGraph _lineGraph;

		[SerializeField]
		private TMP_FontAsset _font;

		[SerializeField]
		private float _fontSize = 10f;

		[SerializeField]
		private Color _fontColor = Color.white;

		[SerializeField]
		private TextAlignmentOptions _textAlignment = TextAlignmentOptions.Midline;

		[SerializeField]
		private double _verticalSpacing = 1.0;

		private List<TextMeshProUGUI> _labels = new List<TextMeshProUGUI>();

		public Func<double, string> Formatter;

		private RectTransform _rectTransform;

		protected RectTransform RectTransform
		{
			get
			{
				if (_rectTransform == null)
				{
					_rectTransform = GetComponent<RectTransform>();
				}
				return _rectTransform;
			}
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			foreach (TextMeshProUGUI label in _labels)
			{
				UnityEngine.Object.Destroy(label.gameObject);
			}
			_labels.Clear();
		}

		protected void Update()
		{
			if (_lineGraph == null)
			{
				return;
			}
			Vector2 vector = new Vector2(RectTransform.rect.width, RectTransform.rect.height);
			Vector2 pivot = RectTransform.pivot;
			Vector2 vector2 = new Vector2(pivot.x * vector.x, pivot.y * vector.y);
			Vector2 vector3 = new Vector2((0f - pivot.x) * vector.x, (0f - pivot.y) * vector.y);
			LineGraph.DataVector2 dataVector = _lineGraph.ScreenPositionToDataPoint(RectTransform.TransformPoint(vector2));
			LineGraph.DataVector2 dataVector2 = _lineGraph.ScreenPositionToDataPoint(RectTransform.TransformPoint(vector3));
			int num = Mathf.CeilToInt((float)((dataVector.x - dataVector2.x) / _verticalSpacing)) + 1;
			double num2 = Math.Floor(dataVector2.x / _verticalSpacing) * _verticalSpacing;
			int num3 = _labels.Count - 1;
			while (num3 >= num && num3 >= 0)
			{
				UnityEngine.Object.Destroy(_labels[num3].gameObject);
				_labels.RemoveAt(num3);
				num3--;
			}
			for (int i = 0; i < num; i++)
			{
				LineGraph.DataVector2 point = new LineGraph.DataVector2(num2 + (double)i * _verticalSpacing, 0.0);
				Vector3 vector4 = RectTransform.InverseTransformPoint(_lineGraph.DataPointToScreenPosition(point));
				RectTransform rectTransform;
				TextMeshProUGUI textMeshProUGUI;
				if (i >= _labels.Count)
				{
					GameObject obj = new GameObject("Label");
					rectTransform = obj.AddComponent<RectTransform>();
					rectTransform.SetParent(base.transform, worldPositionStays: false);
					textMeshProUGUI = obj.AddComponent<TextMeshProUGUI>();
					_labels.Add(textMeshProUGUI);
				}
				else
				{
					textMeshProUGUI = _labels[i];
					rectTransform = _labels[i].rectTransform;
				}
				textMeshProUGUI.text = ((Formatter != null) ? Formatter(point.x) : point.x.ToString("0"));
				textMeshProUGUI.font = _font;
				textMeshProUGUI.fontSize = _fontSize;
				textMeshProUGUI.alignment = _textAlignment;
				textMeshProUGUI.color = _fontColor;
				rectTransform.SetAnchor(AnchorPresets.VertStretchCenter);
				rectTransform.SetSizeWithCurrentAnchorsSafe(RectTransform.Axis.Vertical, RectTransform.rect.height);
				rectTransform.SetSizeWithCurrentAnchorsSafe(RectTransform.Axis.Horizontal, textMeshProUGUI.preferredWidth);
				rectTransform.anchoredPosition = new Vector2(vector4.x, 0f);
			}
		}
	}
}
