using System.Collections.Generic;

namespace Jobberwocky.TriangleNet.Geometry
{
	public class Polygon : IPolygon
	{
		private List<Vertex> points;

		private List<Point> holes;

		private List<RegionPointer> regions;

		private List<ISegment> segments;

		private bool _003CHasPointMarkers_003Ek__BackingField;

		private bool _003CHasSegmentMarkers_003Ek__BackingField;

		public List<Vertex> Points => points;

		public List<Point> Holes => holes;

		public List<RegionPointer> Regions => regions;

		public List<ISegment> Segments => segments;

		public bool HasPointMarkers
		{
			set
			{
				_003CHasPointMarkers_003Ek__BackingField = value;
			}
		}

		public bool HasSegmentMarkers
		{
			set
			{
				_003CHasSegmentMarkers_003Ek__BackingField = value;
			}
		}

		public Polygon()
			: this(3, markers: false)
		{
		}

		public Polygon(int capacity, bool markers)
		{
			points = new List<Vertex>(capacity);
			holes = new List<Point>();
			regions = new List<RegionPointer>();
			segments = new List<ISegment>();
			HasPointMarkers = markers;
			HasSegmentMarkers = markers;
		}

		public void Add(Vertex vertex)
		{
			points.Add(vertex);
		}

		public void Add(Contour contour, bool hole = false)
		{
			if (hole)
			{
				Add(contour, contour.FindInteriorPoint());
				return;
			}
			points.AddRange(contour.Points);
			segments.AddRange(contour.GetSegments());
		}

		public void Add(Contour contour, Point hole)
		{
			points.AddRange(contour.Points);
			segments.AddRange(contour.GetSegments());
			holes.Add(hole);
		}
	}
}
