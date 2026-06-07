using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class StreamGeometryContext : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		internal StreamGeometryContext(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(StreamGeometryContext obj)
		{
			return default(HandleRef);
		}

		~StreamGeometryContext()
		{
		}

		public virtual void Dispose()
		{
		}

		private void DisposeCore()
		{
		}

		private void VerifyApi()
		{
		}

		public void Close()
		{
		}

		public void BeginFigure(Point startPoint, bool isFilled, bool isClosed)
		{
		}

		public void LineTo(Point point, bool isStroked, bool isSmoothJoin)
		{
		}

		public void QuadraticBezierTo(Point point1, Point point2, bool isStroked, bool isSmoothJoin)
		{
		}

		public void BezierTo(Point point1, Point point2, Point point3, bool isStroked, bool isSmoothJoin)
		{
		}

		public void PolyLineTo(IList<Point> points, bool isStroked, bool isSmoothJoin)
		{
		}

		public void PolyQuadraticBezierTo(IList<Point> points, bool isStroked, bool isSmoothJoin)
		{
		}

		public void PolyBezierTo(IList<Point> points, bool isStroked, bool isSmoothJoin)
		{
		}

		public void ArcTo(Point point, Size size, double rotationAngle, bool isLargeArc, SweepDirection sweepDirection, bool isStroked, bool isSmoothJoin)
		{
		}

		private void CloseCore()
		{
		}

		private void BeginFigureHelper(Point startPoint, bool isClosed)
		{
		}

		private void LineToHelper(Point point)
		{
		}

		private void QuadraticBezierToHelper(Point point1, Point point2)
		{
		}

		private void BezierToHelper(Point point1, Point point2, Point point3)
		{
		}

		private void ArcToHelper(Point point, Size size, double rotationAngle, bool isLargeArc, SweepDirection sweepDirection)
		{
		}
	}
}
