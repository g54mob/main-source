namespace Spine
{
	public static class SpineSkeletonExtensions
	{
		public static bool IsWeighted(this VertexAttachment va)
		{
			return false;
		}

		public static bool InheritsRotation(this Inherit mode)
		{
			return false;
		}

		public static bool InheritsScale(this Inherit mode)
		{
			return false;
		}
	}
}
