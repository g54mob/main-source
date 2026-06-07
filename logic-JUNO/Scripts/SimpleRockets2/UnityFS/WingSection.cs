using System;
using Assets.Scripts;
using UnityEngine;

namespace UnityFS
{
	public class WingSection
	{
		private Vector3[] _aerodynamicCenterLocal;

		private float[] _area;

		private Vector3[] _chordLineLocal;

		private ControlSurface _controlSurface;

		private int _deflectionKeyframeCount;

		private int _deflectionKeyframeRange = 5;

		private float[] _deflectionKeyframeValues;

		private int _sectionIndex;

		private Vector3[] _upLocal;

		private Transform _wingTransform;

		public Vector3 AerodynamicCenter { get; private set; }

		public float Area { get; private set; }

		public Vector3 ChordLine { get; private set; }

		public Vector3 Up { get; private set; }

		public WingSection(Transform wingTransform, ControlSurface controlSurface, int sectionIndex, Vector3 rootLeadingEdge, Vector3 rootTrailingEdge, Vector3 tipLeadingEdge, Vector3 tipTrailingEdge, float liftLineChordPosition)
		{
			_wingTransform = wingTransform;
			_controlSurface = controlSurface;
			_sectionIndex = sectionIndex;
			if (_controlSurface == null)
			{
				_deflectionKeyframeValues = new float[1];
				Vector3 vector = CalculateChordLine(rootLeadingEdge, tipLeadingEdge, tipTrailingEdge, rootTrailingEdge);
				_chordLineLocal = new Vector3[1] { wingTransform.InverseTransformDirection(vector) };
				_aerodynamicCenterLocal = new Vector3[1] { wingTransform.InverseTransformPoint(CalculateAerodynamicCenter(rootLeadingEdge, tipLeadingEdge, tipTrailingEdge, rootTrailingEdge, liftLineChordPosition)) };
				_upLocal = new Vector3[1] { wingTransform.InverseTransformDirection(CalculateUp(rootLeadingEdge, tipLeadingEdge, tipTrailingEdge, rootTrailingEdge, vector, liftLineChordPosition)) };
				_area = new float[1] { CalculateArea(rootLeadingEdge, tipLeadingEdge, tipTrailingEdge, rootTrailingEdge) };
			}
			else
			{
				_deflectionKeyframeCount = (int)_controlSurface.MaxDeflectionDegrees / _deflectionKeyframeRange;
				if (_controlSurface.MaxDeflectionDegrees % (float)_deflectionKeyframeRange > 0f)
				{
					_deflectionKeyframeCount++;
				}
				if (Game.InDesignerScene)
				{
					_deflectionKeyframeCount = 0;
				}
				int num = _deflectionKeyframeCount * 2 + 1;
				_deflectionKeyframeValues = new float[num];
				_chordLineLocal = new Vector3[num];
				_aerodynamicCenterLocal = new Vector3[num];
				_upLocal = new Vector3[num];
				_area = new float[num];
				_deflectionKeyframeValues[0] = 0f;
				Vector3 vector2 = CalculateChordLine(rootLeadingEdge, tipLeadingEdge, tipTrailingEdge, rootTrailingEdge);
				_chordLineLocal[0] = wingTransform.InverseTransformDirection(vector2);
				_aerodynamicCenterLocal[0] = wingTransform.InverseTransformPoint(CalculateAerodynamicCenter(rootLeadingEdge, tipLeadingEdge, tipTrailingEdge, rootTrailingEdge, liftLineChordPosition));
				_upLocal[0] = wingTransform.InverseTransformDirection(CalculateUp(rootLeadingEdge, tipLeadingEdge, tipTrailingEdge, rootTrailingEdge, vector2, liftLineChordPosition));
				_area[0] = CalculateArea(rootLeadingEdge, tipLeadingEdge, tipTrailingEdge, rootTrailingEdge);
				for (int i = 1; i <= _deflectionKeyframeCount; i++)
				{
					float num2 = 0f;
					num2 = ((i != _deflectionKeyframeCount) ? ((float)(_deflectionKeyframeRange * i)) : _controlSurface.MaxDeflectionDegrees);
					int num3 = 1;
					while (num3 == 1 || num3 == -1)
					{
						Vector3 PointA = rootLeadingEdge;
						Vector3 PointB = tipLeadingEdge;
						Vector3 PointC = tipTrailingEdge;
						Vector3 PointD = rootTrailingEdge;
						_controlSurface.CurrentDeflection = num2 * (float)num3;
						_controlSurface.ModifyWingGeometry(_sectionIndex, ref PointA, ref PointB, ref PointC, ref PointD);
						int num4 = ((num3 == 1) ? i : (i + _deflectionKeyframeCount));
						_deflectionKeyframeValues[num4] = num2 * (float)num3;
						vector2 = CalculateChordLine(PointA, PointB, PointC, PointD);
						_chordLineLocal[num4] = wingTransform.InverseTransformDirection(vector2);
						_aerodynamicCenterLocal[num4] = wingTransform.InverseTransformPoint(CalculateAerodynamicCenter(PointA, PointB, PointC, PointD, liftLineChordPosition));
						_upLocal[num4] = wingTransform.InverseTransformDirection(CalculateUp(PointA, PointB, PointC, PointD, vector2, liftLineChordPosition));
						_area[num4] = CalculateArea(PointA, PointB, PointC, PointD);
						num3 -= 2;
					}
				}
				_controlSurface.CurrentDeflection = 0f;
			}
			Area = _area[0];
		}

		public void Update()
		{
			if (_controlSurface == null || _controlSurface.CurrentDeflection == 0f)
			{
				ChordLine = _wingTransform.TransformDirection(_chordLineLocal[0]);
				AerodynamicCenter = _wingTransform.TransformPoint(_aerodynamicCenterLocal[0]);
				Up = _wingTransform.TransformDirection(_upLocal[0]);
				Area = _area[0];
				return;
			}
			float currentDeflection = _controlSurface.CurrentDeflection;
			int num = Math.Abs((int)currentDeflection / _deflectionKeyframeRange);
			int num2 = ((num < _deflectionKeyframeCount) ? (num + 1) : num);
			float num3 = _deflectionKeyframeValues[num2] - _deflectionKeyframeValues[num];
			float t = (Mathf.Abs(currentDeflection) - (float)(num * _deflectionKeyframeRange)) / num3;
			if (currentDeflection < 0f)
			{
				num2 += _deflectionKeyframeCount;
				if (num != 0)
				{
					num += _deflectionKeyframeCount;
				}
			}
			if (num != num2)
			{
				ChordLine = _wingTransform.TransformDirection(Vector3.Lerp(_chordLineLocal[num], _chordLineLocal[num2], t));
				AerodynamicCenter = _wingTransform.TransformPoint(Vector3.Lerp(_aerodynamicCenterLocal[num], _aerodynamicCenterLocal[num2], t));
				Up = _wingTransform.TransformDirection(Vector3.Lerp(_upLocal[num], _upLocal[num2], t));
				Area = Mathf.Lerp(_area[num], _area[num2], t);
			}
			else
			{
				ChordLine = _wingTransform.TransformDirection(_chordLineLocal[num]);
				AerodynamicCenter = _wingTransform.TransformPoint(_aerodynamicCenterLocal[num]);
				Up = _wingTransform.TransformDirection(_upLocal[num]);
				Area = _area[num];
			}
		}

		private Vector3 CalculateAerodynamicCenter(Vector3 rootLeadingEdge, Vector3 tipLeadingEdge, Vector3 tipTrailingEdge, Vector3 rootTrailingEdge, float liftLineChordPosition)
		{
			Vector3 vector = rootTrailingEdge + (rootLeadingEdge - rootTrailingEdge) * liftLineChordPosition;
			Vector3 vector2 = tipTrailingEdge + (tipLeadingEdge - tipTrailingEdge) * liftLineChordPosition - vector;
			return vector + vector2 * 0.5f;
		}

		private float CalculateArea(Vector3 rootLeadingEdge, Vector3 tipLeadingEdge, Vector3 tipTrailingEdge, Vector3 rootTrailingEdge)
		{
			float magnitude = (tipLeadingEdge - rootLeadingEdge).magnitude;
			float magnitude2 = (tipTrailingEdge - tipLeadingEdge).magnitude;
			float magnitude3 = (rootTrailingEdge - tipTrailingEdge).magnitude;
			float magnitude4 = (rootLeadingEdge - rootTrailingEdge).magnitude;
			float num = (magnitude + magnitude2 + magnitude3 + magnitude4) * 0.5f;
			return Mathf.Sqrt((num - magnitude) * (num - magnitude2) * (num - magnitude3) * (num - magnitude4));
		}

		private Vector3 CalculateChordLine(Vector3 rootLeadingEdge, Vector3 tipLeadingEdge, Vector3 tipTrailingEdge, Vector3 rootTrailingEdge)
		{
			return (rootLeadingEdge + (tipLeadingEdge - rootLeadingEdge) * 0.5f - (rootTrailingEdge + (tipTrailingEdge - rootTrailingEdge) * 0.5f)).normalized;
		}

		private Vector3 CalculateUp(Vector3 rootLeadingEdge, Vector3 tipLeadingEdge, Vector3 tipTrailingEdge, Vector3 rootTrailingEdge, Vector3 chordLine, float liftLineChordPosition)
		{
			Vector3 vector = rootTrailingEdge + (rootLeadingEdge - rootTrailingEdge) * liftLineChordPosition;
			return Vector3.Cross(chordLine, (tipTrailingEdge + (tipLeadingEdge - tipTrailingEdge) * liftLineChordPosition - vector).normalized).normalized;
		}
	}
}
