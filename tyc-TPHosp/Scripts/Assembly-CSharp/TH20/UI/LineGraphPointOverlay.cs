using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TH20.UI
{
	[AddComponentMenu("UI/Line Graph Point Overlay", 110)]
	public class LineGraphPointOverlay : UIBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private List<LineGraph> _lineGraphs = new List<LineGraph>();

		[SerializeField]
		private double _valueSnap = 0.5;

		[Header("Point References")]
		[SerializeField]
		private RectTransform _pointTransform;

		[SerializeField]
		private PointGraphic _pointGraphic;

		[SerializeField]
		private TMP_Text _yValueText;

		private bool _isMouseOver;

		private RectTransform _rectTransform;

		protected override void Start()
		{
			base.Start();
			_rectTransform = GetComponent<RectTransform>();
			_isMouseOver = false;
			if (_pointTransform != null)
			{
				_pointTransform.gameObject.SetActive(value: true);
			}
			if (_pointGraphic != null)
			{
				_pointGraphic.enabled = true;
			}
		}

		protected void Update()
		{
			bool flag = false;
			int num = -1;
			double y = -1.0;
			LineGraph lineGraph = null;
			Vector2 anchoredPosition = Vector2.zero;
			Vector2 vector = Vector2.zero;
			if (_isMouseOver)
			{
				Vector2 vector2 = Input.mousePosition;
				foreach (LineGraph lineGraph2 in _lineGraphs)
				{
					if (!RectTransformUtility.RectangleContainsScreenPoint(lineGraph2.GetComponent<RectTransform>(), vector2))
					{
						continue;
					}
					LineGraph.DataVector2 dataVector = lineGraph2.ScreenPositionToDataPoint(vector2);
					dataVector.x = Math.Round(dataVector.x / _valueSnap) * _valueSnap;
					for (int i = 0; i < lineGraph2.NumOfDataSets; i++)
					{
						double x = dataVector.x;
						if (!lineGraph2.GetYDataValue(i, x, out var y2))
						{
							int dataCount = lineGraph2.GetDataCount(i);
							if (dataCount <= 0)
							{
								continue;
							}
							LineGraph.DataVector2 dataVector2 = lineGraph2.GetDataVector(i, 0);
							LineGraph.DataVector2 dataVector3 = lineGraph2.GetDataVector(i, dataCount - 1);
							if (x > dataVector3.x)
							{
								x = dataVector3.x;
								y2 = dataVector3.y;
							}
							else if (x < dataVector2.x)
							{
								x = dataVector2.x;
								y2 = dataVector2.y;
							}
						}
						Vector2 vector3 = lineGraph2.DataPointToScreenPosition(new LineGraph.DataVector2(x, y2));
						if (num < 0 || Mathf.Abs(vector.y - vector2.y) > Mathf.Abs(vector3.y - vector2.y))
						{
							anchoredPosition = _rectTransform.InverseTransformPoint(vector3);
							vector = vector3;
							num = i;
							y = y2;
							lineGraph = lineGraph2;
							flag = true;
						}
					}
				}
			}
			if (num >= 0)
			{
				if (_yValueText != null)
				{
					_yValueText.text = lineGraph.FormatYValue(num, y);
				}
				if (_pointTransform != null)
				{
					_pointTransform.anchoredPosition = anchoredPosition;
				}
				if (_pointGraphic != null)
				{
					_pointGraphic.color = lineGraph.GetLineColor(num);
				}
			}
			if (_pointTransform.gameObject.activeSelf != flag && _pointTransform != null)
			{
				_pointTransform.gameObject.SetActive(flag);
				if (flag)
				{
					Vector2 anchoredPosition2 = _pointTransform.anchoredPosition;
					_pointTransform.anchoredPosition = anchoredPosition2 + Vector2.one;
					_pointTransform.anchoredPosition = anchoredPosition2;
				}
			}
		}

		void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
		{
			_isMouseOver = true;
		}

		void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
		{
			_isMouseOver = false;
		}
	}
}
