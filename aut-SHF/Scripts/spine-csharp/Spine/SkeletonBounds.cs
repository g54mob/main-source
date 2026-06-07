namespace Spine
{
	public class SkeletonBounds
	{
		private ExposedList<Polygon> polygonPool;

		private float minX;

		private float minY;

		private float maxX;

		private float maxY;

		public ExposedList<BoundingBoxAttachment> BoundingBoxes { get; private set; }

		public ExposedList<Polygon> Polygons { get; private set; }

		public float MinX
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float MinY
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float MaxX
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float MaxY
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Width => 0f;

		public float Height => 0f;

		public void Update(Skeleton skeleton, bool updateAabb)
		{
		}

		private void AabbCompute()
		{
		}

		public bool AabbContainsPoint(float x, float y)
		{
			return false;
		}

		public bool AabbIntersectsSegment(float x1, float y1, float x2, float y2)
		{
			return false;
		}

		public bool AabbIntersectsSkeleton(SkeletonBounds bounds)
		{
			return false;
		}

		public bool ContainsPoint(Polygon polygon, float x, float y)
		{
			return false;
		}

		public BoundingBoxAttachment ContainsPoint(float x, float y)
		{
			return null;
		}

		public BoundingBoxAttachment IntersectsSegment(float x1, float y1, float x2, float y2)
		{
			return null;
		}

		public bool IntersectsSegment(Polygon polygon, float x1, float y1, float x2, float y2)
		{
			return false;
		}

		public Polygon GetPolygon(BoundingBoxAttachment attachment)
		{
			return null;
		}
	}
}
