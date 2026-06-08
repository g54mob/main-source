using System.Collections.Generic;

namespace Jobberwocky.TriangleNet.Geometry
{
	public interface IPolygon
	{
		List<Vertex> Points { get; }

		List<ISegment> Segments { get; }

		List<Point> Holes { get; }

		List<RegionPointer> Regions { get; }
	}
}
