using System;
using UnityEngine;
using UnityEngine.UI;

namespace TH20.UI
{
	public class LineGraphGridGraphic : MaskableGraphic
	{
		private const float _featherScale = 0.5f;

		[SerializeField]
		private LineGraph _lineGraph;

		[SerializeField]
		private float _verticalLineThickness = 5f;

		[SerializeField]
		private double _verticalSpacing = 1.0;

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

		protected void Update()
		{
			SetVerticesDirty();
		}

		protected override void OnPopulateMesh(VertexHelper vh)
		{
			vh.Clear();
			if (_lineGraph == null)
			{
				return;
			}
			float num = ((base.canvas.renderMode != RenderMode.WorldSpace) ? (0.5f / base.canvas.scaleFactor) : 0.5f);
			Vector2 vector = new Vector2(base.rectTransform.rect.width, base.rectTransform.rect.height);
			Vector2 pivot = base.rectTransform.pivot;
			Vector2 vector2 = new Vector2(pivot.x * vector.x, pivot.y * vector.y);
			Vector2 vector3 = new Vector2((0f - pivot.x) * vector.x, (0f - pivot.y) * vector.y);
			LineGraph.DataVector2 dataVector = _lineGraph.ScreenPositionToDataPoint(RectTransform.TransformPoint(vector2));
			LineGraph.DataVector2 dataVector2 = _lineGraph.ScreenPositionToDataPoint(RectTransform.TransformPoint(vector3));
			if (!(Math.Abs(dataVector.x - dataVector2.x) < (double)Mathf.Epsilon) && !(Math.Abs(dataVector.y - dataVector2.y) < (double)Mathf.Epsilon))
			{
				int num2 = Mathf.CeilToInt((float)((dataVector.x - dataVector2.x) / _verticalSpacing)) + 1;
				double num3 = Math.Floor(dataVector2.x / _verticalSpacing) * _verticalSpacing;
				UIVertex simpleVert = UIVertex.simpleVert;
				for (int i = 0; i < num2; i++)
				{
					LineGraph.DataVector2 point = new LineGraph.DataVector2(num3 + (double)i * _verticalSpacing, dataVector.y);
					LineGraph.DataVector2 point2 = new LineGraph.DataVector2(num3 + (double)i * _verticalSpacing, dataVector2.y);
					Vector3 vector4 = RectTransform.InverseTransformPoint(_lineGraph.DataPointToScreenPosition(point));
					Vector3 vector5 = RectTransform.InverseTransformPoint(_lineGraph.DataPointToScreenPosition(point2));
					float x = vector4.x;
					int currentVertCount = vh.currentVertCount;
					simpleVert.color = color;
					simpleVert.position = new Vector2(x - _verticalLineThickness * 0.5f, vector5.y);
					vh.AddVert(simpleVert);
					simpleVert.position = new Vector2(x - _verticalLineThickness * 0.5f, vector4.y);
					vh.AddVert(simpleVert);
					simpleVert.position = new Vector2(x + _verticalLineThickness * 0.5f, vector4.y);
					vh.AddVert(simpleVert);
					simpleVert.position = new Vector2(x + _verticalLineThickness * 0.5f, vector5.y);
					vh.AddVert(simpleVert);
					vh.AddTriangle(currentVertCount, currentVertCount + 1, currentVertCount + 2);
					vh.AddTriangle(currentVertCount, currentVertCount + 2, currentVertCount + 3);
					int currentVertCount2 = vh.currentVertCount;
					simpleVert.position = new Vector2(x - _verticalLineThickness * 0.5f - num, vector5.y);
					simpleVert.color = new Color(color.r, color.g, color.b, 0f);
					vh.AddVert(simpleVert);
					simpleVert.position = new Vector2(x - _verticalLineThickness * 0.5f - num, vector4.y);
					simpleVert.color = new Color(color.r, color.g, color.b, 0f);
					vh.AddVert(simpleVert);
					simpleVert.position = new Vector2(x - _verticalLineThickness * 0.5f, vector4.y);
					simpleVert.color = color;
					vh.AddVert(simpleVert);
					simpleVert.position = new Vector2(x - _verticalLineThickness * 0.5f, vector5.y);
					simpleVert.color = color;
					vh.AddVert(simpleVert);
					vh.AddTriangle(currentVertCount2, currentVertCount2 + 1, currentVertCount2 + 2);
					vh.AddTriangle(currentVertCount2, currentVertCount2 + 2, currentVertCount2 + 3);
					int currentVertCount3 = vh.currentVertCount;
					simpleVert.position = new Vector2(x + _verticalLineThickness * 0.5f, vector5.y);
					simpleVert.color = color;
					vh.AddVert(simpleVert);
					simpleVert.position = new Vector2(x + _verticalLineThickness * 0.5f, vector4.y);
					simpleVert.color = color;
					vh.AddVert(simpleVert);
					simpleVert.position = new Vector2(x + _verticalLineThickness * 0.5f + num, vector4.y);
					simpleVert.color = new Color(color.r, color.g, color.b, 0f);
					vh.AddVert(simpleVert);
					simpleVert.position = new Vector2(x + _verticalLineThickness * 0.5f + num, vector5.y);
					simpleVert.color = new Color(color.r, color.g, color.b, 0f);
					vh.AddVert(simpleVert);
					vh.AddTriangle(currentVertCount3, currentVertCount3 + 1, currentVertCount3 + 2);
					vh.AddTriangle(currentVertCount3, currentVertCount3 + 2, currentVertCount3 + 3);
				}
			}
		}
	}
}
