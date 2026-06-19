#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TH20.UI
{
	public class AmbulanceRouteRenderer : UILineRenderer, iRenderStateChangeable
	{
		[SerializeField]
		private int _curveIntervals = 100;

		[SerializeField]
		private float _airThicknessMultiplier = 0.66f;

		private FoundationStyleDefinition _foundationStyle;

		private Vector2[] _curvePoints;

		private float _totalRouteDistance;

		private float[] _individualPointDistances;

		private Dictionary<ERenderState, FoundationStyleDefinition.StyleState> _styleStates;

		private ERenderState _currentRenderState;

		public void Setup(AmbulanceDepartment department)
		{
			_foundationStyle = department.FoundationStyle;
			_styleStates = new Dictionary<ERenderState, FoundationStyleDefinition.StyleState>
			{
				{
					ERenderState.Neutral,
					_foundationStyle.GetStyle(ERenderState.Neutral)
				},
				{
					ERenderState.Emphasised,
					_foundationStyle.GetStyle(ERenderState.Emphasised)
				}
			};
			material = _styleStates[ERenderState.Neutral].RouteMaterial;
			_currentRenderState = ERenderState.Neutral;
		}

		public void SetRenderState(ERenderState renderState)
		{
			if (_foundationStyle == null || _styleStates == null || _currentRenderState == renderState)
			{
				return;
			}
			if (_styleStates.TryGetValue(renderState, out var value))
			{
				material = value.RouteMaterial;
				LineThickness = value.RouteLineThickness;
				if (_curvePoints != null)
				{
					LineThickness *= _airThicknessMultiplier;
				}
			}
			_currentRenderState = renderState;
			SetAllDirty();
		}

		public Vector2 GetPositionAlongRoute(float progress)
		{
			float progress2 = progress / 100f * _totalRouteDistance;
			return GetPositionAlongRouteInternal(progress2);
		}

		public override void SetPosition(int index, Vector2 position)
		{
			base.SetPosition(index, position);
			CalculateRouteDistances();
		}

		public override void SetPositions(Vector2[] positions)
		{
			base.SetPositions(positions);
			CalculateRouteDistances();
		}

		public override void SetPositions(List<Vector2> positions)
		{
			base.SetPositions(positions);
			CalculateRouteDistances();
		}

		public override void ClearPositions()
		{
			base.ClearPositions();
			CalculateRouteDistances();
		}

		public void SetCurvedRoute(Vector2[] points)
		{
			if (points != null)
			{
				LineThickness *= _airThicknessMultiplier;
				if (points.Length == 3)
				{
					SetCurvedRouteInternal(points[0], points[1], points[2]);
				}
				else if (points.Length > 3)
				{
					SetCurvedRouteInternal(points[0], points[1], points[2], points[3]);
				}
				CalculateRouteDistances();
			}
		}

		public void SetCurvedRoute(List<Vector2> points)
		{
			if (points == null)
			{
				return;
			}
			if (points.Count > 4)
			{
				Logging.Error(LogChannels.AmbulanceEmergency, "Curved Routes only support a maximum of 4 control points. This route has " + points.Count);
				return;
			}
			if (points.Count < 3)
			{
				SetPositions(points);
			}
			else if (points.Count == 3)
			{
				SetCurvedRouteInternal(points[0], points[1], points[2]);
			}
			else if (points.Count == 4)
			{
				SetCurvedRouteInternal(points[0], points[1], points[2], points[3]);
			}
			CalculateRouteDistances();
		}

		private void SetCurvedRouteInternal(Vector2 start, Vector2 controlPoint1, Vector2 end)
		{
			_curvePoints = new Vector2[3] { start, controlPoint1, end };
			Array.Resize(ref Points, _curveIntervals);
			float num = 0f;
			for (int i = 0; i < _curveIntervals; i++)
			{
				Vector2 vector = (1f - num) * (1f - num) * start + 2f * (1f - num) * num * controlPoint1 + num * num * end;
				Points[i] = vector;
				num += 1f / (float)_curveIntervals;
			}
			SetAllDirty();
		}

		private void SetCurvedRouteInternal(Vector2 start, Vector2 controlPoint1, Vector2 controlPoint2, Vector2 end)
		{
			_curvePoints = new Vector2[4] { start, controlPoint1, controlPoint2, end };
			Array.Resize(ref Points, _curveIntervals);
			float num = 0f;
			for (int i = 0; i < _curveIntervals; i++)
			{
				Vector2 vector = (1f - num) * (1f - num) * (1f - num) * start + 3f * (1f - num) * (1f - num) * num * controlPoint1 + 3f * (1f - num) * num * num * controlPoint2 + num * num * num * end;
				Points[i] = vector;
				num += 1f / (float)_curveIntervals;
			}
			SetAllDirty();
		}

		private void CalculateRouteDistances()
		{
			_totalRouteDistance = 0f;
			if (Points.Length == 0)
			{
				if (_individualPointDistances == null || _individualPointDistances.Length != 0)
				{
					_individualPointDistances = new float[0];
				}
				return;
			}
			_individualPointDistances = new float[Points.Length - 1];
			for (int i = 0; i < Points.Length - 1; i++)
			{
				float num = Vector2.Distance(Points[i], Points[i + 1]);
				_individualPointDistances[i] = num;
				_totalRouteDistance += num;
			}
		}

		private Vector2 GetPositionAlongRouteInternal(float progress)
		{
			if (_individualPointDistances == null)
			{
				if (Points.Length == 0)
				{
					return Vector2.zero;
				}
				return Points[0];
			}
			int num = 0;
			float num2 = 0f;
			for (int i = 0; i < _individualPointDistances.Length; i++)
			{
				if (progress <= _individualPointDistances[i] || i == _individualPointDistances.Length - 1)
				{
					num = i;
					num2 = progress / _individualPointDistances[i];
					break;
				}
				progress -= _individualPointDistances[i];
			}
			if (num > Points.Length - 1)
			{
				return Points[num];
			}
			return new Vector2
			{
				x = Points[num].x + (Points[num + 1].x - Points[num].x) * num2,
				y = Points[num].y + (Points[num + 1].y - Points[num].y) * num2
			};
		}
	}
}
