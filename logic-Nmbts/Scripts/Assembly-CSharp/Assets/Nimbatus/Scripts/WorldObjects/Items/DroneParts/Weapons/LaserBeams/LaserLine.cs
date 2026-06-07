using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.LaserBeams
{
	public class LaserLine
	{
		private VectorLine _line;

		private Vector3[] _linePoints;

		private List<Vector3> _currentLinePoints;

		public LaserLine(float width, Material lineMaterial)
		{
			_linePoints = new Vector3[20];
			_line = new VectorLine("laser", _linePoints, lineMaterial, width, LineType.Continuous, Joins.Fill);
		}

		public void Show(bool show)
		{
			_line.active = show;
		}

		public void SetColor(Color ammunitionColorModifier)
		{
			_line.SetColor(ammunitionColorModifier);
		}

		public void SetWidth(float width)
		{
			_line.lineWidth = width;
		}

		public void ResetPoints()
		{
			_currentLinePoints = new List<Vector3>();
		}

		public void AddPoint(Vector3 startPos)
		{
			_currentLinePoints.Add(startPos);
		}

		public void ApplyLine()
		{
			if (_currentLinePoints.Count > 0)
			{
				_linePoints = _currentLinePoints.ToArray();
				if (_line != null)
				{
					_line.Resize(_linePoints);
					_line.SetTextureScale(1f);
					_line.Draw3D();
				}
			}
		}

		public void Destroy()
		{
			if (_line != null)
			{
				_line.active = false;
				VectorLine.Destroy(ref _line);
			}
		}
	}
}
