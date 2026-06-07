using System;
using System.Xml.Linq;
using ModApi.Craft.Parts;
using UnityEngine;

namespace ModApi.Craft
{
	public class Drag
	{
		public enum DragDirection
		{
			Forward = 0,
			Backward = 1,
			Upward = 2,
			Downward = 3,
			Leftward = 4,
			Rightward = 5
		}

		private const int ArraySize = 6;

		private float[] _area;

		private float[] _drag;

		private Vector3[] _positions;

		private float _totalArea;

		public bool IsOccluded
		{
			get
			{
				if (!(TotalArea < 0.001f) || OcclusionCalculation != OcclusionCalculationType.Auto)
				{
					return OcclusionCalculation == OcclusionCalculationType.Always;
				}
				return true;
			}
		}

		public OcclusionCalculationType OcclusionCalculation { get; set; }

		public float TotalArea
		{
			get
			{
				return _totalArea;
			}
			private set
			{
				_totalArea = value;
			}
		}

		public Drag()
		{
			Initialize();
		}

		public Drag(XElement element)
		{
			Initialize();
			if (element != null)
			{
				ParseFloatArray(_drag, element.Attribute("drag").Value);
				ParseFloatArray(_area, element.Attribute("area").Value);
				for (int i = 0; i < 6; i++)
				{
					TotalArea += _area[i];
				}
			}
		}

		public static Vector3 DragDirectionToVector3(DragDirection dragDirection)
		{
			return dragDirection switch
			{
				DragDirection.Forward => Vector3.forward, 
				DragDirection.Backward => -Vector3.forward, 
				DragDirection.Rightward => Vector3.right, 
				DragDirection.Leftward => -Vector3.right, 
				DragDirection.Upward => Vector3.up, 
				_ => -Vector3.up, 
			};
		}

		public static DragDirection OppositeDirection(DragDirection direction)
		{
			return direction switch
			{
				DragDirection.Forward => DragDirection.Backward, 
				DragDirection.Backward => DragDirection.Forward, 
				DragDirection.Upward => DragDirection.Downward, 
				DragDirection.Downward => DragDirection.Upward, 
				DragDirection.Leftward => DragDirection.Rightward, 
				DragDirection.Rightward => DragDirection.Leftward, 
				_ => throw new ArgumentException("Invalid direction: " + direction), 
			};
		}

		public void AddDrag(DragDirection direction, float value, Vector3 position, float area)
		{
			if (!(position.x > -1E-06f) || !(position.x < 1E-06f) || !(position.y > -1E-06f) || !(position.y < 1E-06f) || !(position.z > -1E-06f) || !(position.z < 1E-06f))
			{
				float num = _drag[(int)direction] + value;
				if (num > 0f)
				{
					float num2 = _drag[(int)direction] / num;
					float num3 = value / num;
					_positions[(int)direction] = num2 * _positions[(int)direction] + num3 * position;
				}
				else
				{
					_positions[(int)direction] = position;
				}
			}
			_drag[(int)direction] += value;
			_area[(int)direction] += area;
			_totalArea += area;
		}

		public void AddDrag(Drag drag)
		{
			for (int i = 0; i < 6; i++)
			{
				AddDrag((DragDirection)i, drag._drag[i], drag._positions[i], drag._area[i]);
			}
		}

		public void ClearDrag(DragDirection? direction = null)
		{
			if (direction.HasValue)
			{
				int value = (int)direction.Value;
				_drag[value] = 0f;
				_area[value] = 0f;
				_positions[value] = Vector3.zero;
				float num = 0f;
				for (int i = 0; i < 6; i++)
				{
					num += _area[i];
				}
				TotalArea = num;
				return;
			}
			_drag[0] = 0f;
			_drag[1] = 0f;
			_drag[2] = 0f;
			_drag[3] = 0f;
			_drag[4] = 0f;
			_drag[5] = 0f;
			_area[0] = 0f;
			_area[1] = 0f;
			_area[2] = 0f;
			_area[3] = 0f;
			_area[4] = 0f;
			_area[5] = 0f;
			Vector3 zero = Vector3.zero;
			_positions[0] = zero;
			_positions[1] = zero;
			_positions[2] = zero;
			_positions[3] = zero;
			_positions[4] = zero;
			_positions[5] = zero;
			TotalArea = 0f;
		}

		public XElement GenerateXml()
		{
			XElement xElement = new XElement("Drag");
			xElement.SetAttributeValue("drag", WriteFloatArray(_drag));
			xElement.SetAttributeValue("area", WriteFloatArray(_area));
			return xElement;
		}

		public float GetArea(DragDirection direction)
		{
			return _area[(int)direction];
		}

		public Vector3 GetCenterOfDrag(DragDirection direction)
		{
			return _positions[(int)direction];
		}

		public float[] GetDrag()
		{
			return _drag;
		}

		public float GetDrag(DragDirection direction)
		{
			return _drag[(int)direction];
		}

		public void SetCenterOfDrag(DragDirection direction, Vector3 position)
		{
			_positions[(int)direction] = position;
		}

		public void SetDrag(DragDirection direction, float value, float area)
		{
			_drag[(int)direction] = value;
			_area[(int)direction] = area;
			TotalArea = 0f;
			for (int i = 0; i < 6; i++)
			{
				TotalArea += _area[i];
			}
		}

		public override string ToString()
		{
			return WriteFloatArray(_drag);
		}

		private static void ParseFloatArray(float[] floatArray, string valueString)
		{
			string[] array = valueString.Split(new char[1] { ',' });
			if (floatArray.Length == array.Length)
			{
				for (int i = 0; i < floatArray.Length; i++)
				{
					float value = 0f;
					if (DataIO.TryParseFloat(array[i], out value))
					{
						floatArray[i] = value;
					}
				}
				return;
			}
			throw new InvalidOperationException($"Float Array length ({floatArray.Length}) does not equal token array length ({array.Length})");
		}

		private static string WriteFloatArray(float[] floatArray)
		{
			string text = DataIO.ToString(floatArray[0]);
			for (int i = 1; i < floatArray.Length; i++)
			{
				text = text + "," + DataIO.ToString(floatArray[i]);
			}
			return text;
		}

		private void Initialize()
		{
			_drag = new float[6];
			_area = new float[6];
			_positions = new Vector3[6];
		}
	}
}
