using System.Collections.Generic;

namespace Polygon2DTriangulation
{
	public class SplitComplexPolygonNode
	{
		private List<SplitComplexPolygonNode> mConnected;

		private Point2D mPosition;

		public int NumConnected => 0;

		public Point2D Position
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public SplitComplexPolygonNode this[int index] => null;

		public SplitComplexPolygonNode()
		{
		}

		public SplitComplexPolygonNode(Point2D pos)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(SplitComplexPolygonNode pn)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static bool operator ==(SplitComplexPolygonNode lhs, SplitComplexPolygonNode rhs)
		{
			return false;
		}

		public static bool operator !=(SplitComplexPolygonNode lhs, SplitComplexPolygonNode rhs)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}

		private bool IsRighter(double sinA, double cosA, double sinB, double cosB)
		{
			return false;
		}

		private int remainder(int x, int modulus)
		{
			return 0;
		}

		public void AddConnection(SplitComplexPolygonNode toMe)
		{
		}

		public void RemoveConnection(SplitComplexPolygonNode fromMe)
		{
		}

		private void RemoveConnectionByIndex(int index)
		{
		}

		public void ClearConnections()
		{
		}

		private bool IsConnectedTo(SplitComplexPolygonNode me)
		{
			return false;
		}

		public SplitComplexPolygonNode GetRightestConnection(SplitComplexPolygonNode incoming)
		{
			return null;
		}

		public SplitComplexPolygonNode GetRightestConnection(Point2D incomingDir)
		{
			return null;
		}
	}
}
