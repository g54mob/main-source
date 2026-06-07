using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace Dreamteck.Splines.IO
{
	public class CSV : SplineParser
	{
		public enum ColumnType
		{
			Position = 0,
			Tangent = 1,
			Tangent2 = 2,
			Normal = 3,
			Size = 4,
			Color = 5
		}

		public List<ColumnType> columns;

		private CultureInfo culture;

		private NumberStyles style;

		public CSV(SplineComputer computer)
		{
		}

		public CSV(string filePath, List<ColumnType> customColumns = null)
		{
		}

		private void Read(string[] lines)
		{
		}

		public SplineComputer CreateSplineComputer(Vector3 position, Quaternion rotation)
		{
			return null;
		}

		public Spline CreateSpline()
		{
			return null;
		}

		public void FlatX()
		{
		}

		public void FlatY()
		{
		}

		public void FlatZ()
		{
		}

		private void AddTitle(ref string[] content, string title)
		{
		}

		private void AddVector3Title(ref string[] content, string prefix)
		{
		}

		private void AddColorTitle(ref string[] content, string prefix)
		{
		}

		private void AddVector3(ref string[] content, int index, Vector3 vector)
		{
		}

		private void AddColor(ref string[] content, int index, Color color)
		{
		}

		private void AddFloat(ref string[] content, int index, float value)
		{
		}

		public void Write(string filePath)
		{
		}
	}
}
