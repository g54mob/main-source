namespace ToolBuddy.ThirdParty.VectorGraphics
{
	internal class PathPatternIterator
	{
		private float[] pattern;

		private int currentSegment;

		private bool solid;

		private float segmentLength;

		private float patternLength;

		private float patternOffset;

		public float SegmentLength => 0f;

		public bool IsSolid => false;

		public PathPatternIterator(float[] pattern, float patternOffset = 0f)
		{
		}

		public void Advance()
		{
		}

		public bool IsSolidAt(float unitsFromPathStart)
		{
			return false;
		}

		public bool IsSolidAt(float unitsFromPathStart, out int patternSegmentIndex, out float patternSegmentLength)
		{
			patternSegmentIndex = default(int);
			patternSegmentLength = default(float);
			return false;
		}
	}
}
