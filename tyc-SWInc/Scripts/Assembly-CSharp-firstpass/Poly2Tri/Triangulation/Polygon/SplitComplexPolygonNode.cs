using System;
using System.Collections.Generic;
using System.Text;
using Poly2Tri.Utility;

namespace Poly2Tri.Triangulation.Polygon
{
	public class SplitComplexPolygonNode
	{
		private readonly List<SplitComplexPolygonNode> _connected = new List<SplitComplexPolygonNode>();

		private Point2D _position;

		public int NumConnected
		{
			get
			{
				return _connected.Count;
			}
		}

		public Point2D Position
		{
			get
			{
				return _position;
			}
			set
			{
				_position = value;
			}
		}

		public SplitComplexPolygonNode this[int index]
		{
			get
			{
				return _connected[index];
			}
		}

		public SplitComplexPolygonNode(Point2D pos)
		{
			_position = pos;
		}

		public override bool Equals(object obj)
		{
			SplitComplexPolygonNode splitComplexPolygonNode = obj as SplitComplexPolygonNode;
			if (splitComplexPolygonNode != null)
			{
				return Equals(splitComplexPolygonNode);
			}
			return false;
		}

		public bool Equals(SplitComplexPolygonNode pn)
		{
			if ((object)pn == null)
			{
				return false;
			}
			if (_position == null || pn.Position == null)
			{
				return false;
			}
			return _position.Equals(pn.Position);
		}

		public override int GetHashCode()
		{
			return _position.GetHashCode();
		}

		public static bool operator ==(SplitComplexPolygonNode lhs, SplitComplexPolygonNode rhs)
		{
			if ((object)lhs != null)
			{
				return lhs.Equals(rhs);
			}
			if ((object)rhs == null)
			{
				return true;
			}
			return false;
		}

		public static bool operator !=(SplitComplexPolygonNode lhs, SplitComplexPolygonNode rhs)
		{
			if ((object)lhs != null)
			{
				return !lhs.Equals(rhs);
			}
			if ((object)rhs == null)
			{
				return false;
			}
			return true;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(256);
			stringBuilder.Append(_position);
			stringBuilder.Append(" -> ");
			for (int i = 0; i < NumConnected; i++)
			{
				if (i != 0)
				{
					stringBuilder.Append(", ");
				}
				stringBuilder.Append(_connected[i].Position);
			}
			return stringBuilder.ToString();
		}

		private bool IsRighter(double sinA, double cosA, double sinB, double cosB)
		{
			if (sinA < 0.0)
			{
				if (sinB > 0.0 || cosA <= cosB)
				{
					return true;
				}
				return false;
			}
			if (sinB < 0.0 || cosA <= cosB)
			{
				return false;
			}
			return true;
		}

		public void AddConnection(SplitComplexPolygonNode toMe)
		{
			if (!_connected.Contains(toMe) && toMe != this)
			{
				_connected.Add(toMe);
			}
		}

		public void RemoveConnection(SplitComplexPolygonNode fromMe)
		{
			_connected.Remove(fromMe);
		}

		public void ClearConnections()
		{
			_connected.Clear();
		}

		public SplitComplexPolygonNode GetRightestConnection(SplitComplexPolygonNode incoming)
		{
			if (NumConnected == 0)
			{
				throw new Exception("the connection graph is inconsistent");
			}
			if (NumConnected == 1)
			{
				return incoming;
			}
			Point2D point2D = _position - incoming._position;
			double num = point2D.Magnitude();
			point2D.Normalize();
			if (num <= 1E-12)
			{
				throw new Exception("Length too small");
			}
			SplitComplexPolygonNode splitComplexPolygonNode = null;
			for (int i = 0; i < NumConnected; i++)
			{
				if (_connected[i] == incoming)
				{
					continue;
				}
				Point2D point2D2 = _connected[i]._position - _position;
				double num2 = point2D2.MagnitudeSquared();
				point2D2.Normalize();
				if (num2 <= 1E-24)
				{
					throw new Exception("Length too small");
				}
				double cosA = Point2D.Dot(point2D, point2D2);
				double sinA = Point2D.Cross(point2D, point2D2);
				if (splitComplexPolygonNode != null)
				{
					Point2D point2D3 = splitComplexPolygonNode._position - _position;
					point2D3.Normalize();
					double cosB = Point2D.Dot(point2D, point2D3);
					double sinB = Point2D.Cross(point2D, point2D3);
					if (IsRighter(sinA, cosA, sinB, cosB))
					{
						splitComplexPolygonNode = _connected[i];
					}
				}
				else
				{
					splitComplexPolygonNode = _connected[i];
				}
			}
			return splitComplexPolygonNode;
		}

		public SplitComplexPolygonNode GetRightestConnection(Point2D incomingDir)
		{
			SplitComplexPolygonNode incoming = new SplitComplexPolygonNode(_position - incomingDir);
			return GetRightestConnection(incoming);
		}
	}
}
