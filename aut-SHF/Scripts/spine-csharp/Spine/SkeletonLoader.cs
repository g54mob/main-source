namespace Spine
{
	public abstract class SkeletonLoader
	{
		protected readonly AttachmentLoader attachmentLoader;

		protected float scale;

		public float Scale
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public SkeletonLoader(params Atlas[] atlasArray)
		{
		}

		public SkeletonLoader(AttachmentLoader attachmentLoader)
		{
		}

		public abstract SkeletonData ReadSkeletonData(string path);
	}
}
