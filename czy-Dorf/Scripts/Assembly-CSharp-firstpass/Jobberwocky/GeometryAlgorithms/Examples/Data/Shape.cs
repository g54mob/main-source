using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Jobberwocky.GeometryAlgorithms.Examples.Data
{
	public class Shape
	{
		private Vector3[] _003CPoints_003Ek__BackingField;

		private Vector3[] _003CBoundary_003Ek__BackingField;

		private Vector3[][] _003CHoles_003Ek__BackingField;

		private Vector3 _003CCameraPoint_003Ek__BackingField;

		private Quaternion _003CCameraRotation_003Ek__BackingField;

		public Vector3[] Points
		{
			get
			{
				return _003CPoints_003Ek__BackingField;
			}
			set
			{
				_003CPoints_003Ek__BackingField = value;
			}
		}

		public Vector3[] Boundary
		{
			get
			{
				return _003CBoundary_003Ek__BackingField;
			}
			set
			{
				_003CBoundary_003Ek__BackingField = value;
			}
		}

		public Vector3[][] Holes
		{
			get
			{
				return _003CHoles_003Ek__BackingField;
			}
			set
			{
				_003CHoles_003Ek__BackingField = value;
			}
		}

		public Vector3 CameraPoint
		{
			get
			{
				return _003CCameraPoint_003Ek__BackingField;
			}
			set
			{
				_003CCameraPoint_003Ek__BackingField = value;
			}
		}

		public Quaternion CameraRotation
		{
			get
			{
				return _003CCameraRotation_003Ek__BackingField;
			}
			set
			{
				_003CCameraRotation_003Ek__BackingField = value;
			}
		}

		public Vector3[] GetAllPoints()
		{
			int pointCount = GetPointCount();
			int boundaryPointCount = GetBoundaryPointCount();
			int holesPointCount = GetHolesPointCount();
			int num = pointCount + boundaryPointCount + holesPointCount;
			Vector3[] array = null;
			if (num > 0)
			{
				array = new Vector3[num];
				int num2 = 0;
				for (int i = 0; i < pointCount; i++)
				{
					array[num2++] = Points[i];
				}
				for (int j = 0; j < boundaryPointCount; j++)
				{
					array[num2++] = Boundary[j];
				}
				for (int k = 0; k < GetHoleCount(); k++)
				{
					for (int l = 0; l < Holes[k].Length; l++)
					{
						array[num2++] = Holes[k][l];
					}
				}
			}
			return array;
		}

		public int GetBoundaryPointCount()
		{
			int num = 0;
			if (Boundary != null)
			{
				num += Boundary.Length;
			}
			return num;
		}

		public int GetHolesPointCount()
		{
			int num = 0;
			for (int i = 0; i < GetHoleCount(); i++)
			{
				num += Holes[i].Length;
			}
			return num;
		}

		public int GetPointCount()
		{
			int num = 0;
			if (Points != null)
			{
				num += Points.Length;
			}
			return num;
		}

		public int GetHoleCount()
		{
			int num = 0;
			if (Holes != null)
			{
				num += Holes.Length;
			}
			return num;
		}

		public void LoadDataFromFile(string path)
		{
			string[] array = File.ReadAllText(path).Split('#');
			foreach (string text in array)
			{
				if (text.StartsWith("Boundary"))
				{
					Boundary = GetPointsFromString(text);
				}
				else if (text.StartsWith("Holes"))
				{
					string[] array2 = text.Split('&');
					Vector3[][] array3 = new Vector3[array2.Length][];
					for (int j = 0; j < array2.Length; j++)
					{
						array3[j] = GetPointsFromString(array2[j]);
					}
					Holes = array3;
				}
				else if (text.StartsWith("Points"))
				{
					Points = GetPointsFromString(text);
				}
			}
		}

		private Vector3[] GetPointsFromString(string textPoints)
		{
			string[] array = textPoints.Split('\n');
			List<Vector3> list = new List<Vector3>(array.Length);
			for (int i = 0; i < array.Length; i++)
			{
				Vector3 item = default(Vector3);
				string[] array2 = array[i].Split(' ');
				if (array2.Length < 2)
				{
					continue;
				}
				for (int j = 0; j < array2.Length; j++)
				{
					switch (j)
					{
					case 0:
						item.x = float.Parse(array2[j]);
						break;
					case 1:
						item.y = float.Parse(array2[j]);
						break;
					case 2:
						item.z = float.Parse(array2[j]);
						break;
					}
				}
				list.Add(item);
			}
			return list.ToArray();
		}
	}
}
