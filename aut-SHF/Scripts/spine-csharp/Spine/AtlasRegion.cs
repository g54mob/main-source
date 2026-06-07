namespace Spine
{
	public class AtlasRegion : TextureRegion
	{
		public AtlasPage page;

		public string name;

		public int x;

		public int y;

		public float offsetX;

		public float offsetY;

		public int originalWidth;

		public int originalHeight;

		public int degrees;

		public bool rotate;

		public int index;

		public string[] names;

		public int[][] values;

		public int packedWidth
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int packedHeight
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public override int OriginalWidth => 0;

		public override int OriginalHeight => 0;

		public AtlasRegion Clone()
		{
			return null;
		}
	}
}
