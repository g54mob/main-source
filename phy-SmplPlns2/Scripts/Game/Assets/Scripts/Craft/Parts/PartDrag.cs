using System;
using System.Xml.Linq;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts
{
	public class PartDrag
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

		private int[] _hits;

		private Vector3[] _positions;

		private float _totalArea;

		public int DragCalculatorVolume { get; set; }

		public float DragScale { get; set; } = 1f;

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

		public PartDrag()
		{
			Initialize();
		}

		public PartDrag(XElement xml)
		{
			Initialize();
			if (xml != null)
			{
				ParseFloatArray(xml.Attribute("drag"), _drag);
				ParseFloatArray(xml.Attribute("dragArea"), _area);
				for (int i = 0; i < 6; i++)
				{
					_totalArea += _area[i];
				}
			}
		}

		public static Vector3 DragDirectionToVector3(DragDirection dragDirection)
		{
			return dragDirection switch
			{
				DragDirection.Forward => Vector3.forward, 
				DragDirection.Backward => Vector3.back, 
				DragDirection.Rightward => Vector3.right, 
				DragDirection.Leftward => Vector3.left, 
				DragDirection.Upward => Vector3.up, 
				_ => Vector3.down, 
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

		public static DragDirection? Vector3ToDragDirection(Vector3 vector)
		{
			if (vector == Vector3.forward)
			{
				return DragDirection.Forward;
			}
			if (vector == Vector3.back)
			{
				return DragDirection.Backward;
			}
			if (vector == Vector3.right)
			{
				return DragDirection.Rightward;
			}
			if (vector == Vector3.left)
			{
				return DragDirection.Leftward;
			}
			if (vector == Vector3.up)
			{
				return DragDirection.Upward;
			}
			if (vector == Vector3.down)
			{
				return DragDirection.Downward;
			}
			return null;
		}

		public void AddDrag(DragDirection direction, float value, Vector3? position, float area)
		{
			if (position.HasValue)
			{
				Vector3 value2 = position.Value;
				if (!(value2.x > -1E-06f) || !(value2.x < 1E-06f) || !(value2.y > -1E-06f) || !(value2.y < 1E-06f) || !(value2.z > -1E-06f) || !(value2.z < 1E-06f))
				{
					float num = _drag[(int)direction] + value;
					if (num > 0f)
					{
						float num2 = _drag[(int)direction] / num;
						float num3 = value / num;
						_positions[(int)direction] = num2 * _positions[(int)direction] + num3 * value2;
					}
					else
					{
						_positions[(int)direction] = value2;
					}
				}
			}
			_drag[(int)direction] += value;
			_area[(int)direction] += area;
			_totalArea += area;
		}

		public void AddDrag(PartDrag drag)
		{
			for (int i = 0; i < 6; i++)
			{
				AddDrag((DragDirection)i, drag._drag[i], drag._positions[i], drag._area[i]);
			}
		}

		public void AddHit(DragDirection direction)
		{
			_hits[(int)direction]++;
		}

		public void AddVolume()
		{
			DragCalculatorVolume++;
		}

		public float CalculateSkinDrag()
		{
			return TotalArea * 0.0025f;
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
				_totalArea = num;
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

		public void ClearVolume()
		{
			DragCalculatorVolume = 0;
		}

		public void Copy(PartDrag copyTarget, float scale)
		{
			scale *= DragScale;
			for (int i = 0; i < _drag.Length; i++)
			{
				copyTarget._drag[i] = _drag[i] * scale;
				copyTarget._area[i] = _area[i] * scale;
				copyTarget._positions[i] = _positions[i];
				copyTarget._hits[i] = _hits[i];
			}
		}

		public float[] GetArea()
		{
			return _area;
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
			return _drag[(int)direction] * DragScale;
		}

		public int GetDragHitCount(DragDirection direction)
		{
			return _hits[(int)direction];
		}

		public PartDrag Scale(float scalar)
		{
			PartDrag partDrag = new PartDrag();
			for (int i = 0; i < _drag.Length; i++)
			{
				partDrag._drag[i] = _drag[i] * scalar;
				partDrag._area[i] = _area[i] * scalar;
				partDrag._positions[i] = _positions[i];
				partDrag._hits[i] = _hits[i];
			}
			return partDrag;
		}

		public void SetCenterOfDrag(DragDirection direction, Vector3 position)
		{
			_positions[(int)direction] = position;
		}

		public void SetDrag(DragDirection direction, float value, float area)
		{
			_drag[(int)direction] = value;
			_area[(int)direction] = area;
			_hits[(int)direction] = 0;
			_totalArea = 0f;
			for (int i = 0; i < 6; i++)
			{
				_totalArea += _area[i];
			}
		}

		public void SetPosition(Vector3 position)
		{
			for (int i = 0; i < 6; i++)
			{
				_positions[i] = position;
			}
		}

		public override string ToString()
		{
			return WriteFloatArray(_drag);
		}

		public void WriteToXml(XElement xml)
		{
			xml.SetAttributeValue("drag", WriteFloatArray(_drag));
			xml.SetAttributeValue("dragArea", WriteFloatArray(_area));
		}

		private static void ParseFloatArray(XAttribute attribute, float[] array)
		{
			if (attribute == null)
			{
				return;
			}
			StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(attribute.Value, ',').GetEnumerator();
			while (enumerator.MoveNext())
			{
				StringUtility.StringSplitEntry current = enumerator.Current;
				if (current.Index < 6)
				{
					if (DataIO.TryParseFloat(current.Span, out var value))
					{
						array[current.Index] = value;
					}
					continue;
				}
				break;
			}
		}

		private static string WriteFloatArray(float[] array)
		{
			return DataIO.ToString(array[0]) + "," + DataIO.ToString(array[1]) + "," + DataIO.ToString(array[2]) + "," + DataIO.ToString(array[3]) + "," + DataIO.ToString(array[4]) + "," + DataIO.ToString(array[5]);
		}

		private void Initialize()
		{
			_drag = new float[6];
			_area = new float[6];
			_hits = new int[6];
			_positions = new Vector3[6];
		}
	}
}
