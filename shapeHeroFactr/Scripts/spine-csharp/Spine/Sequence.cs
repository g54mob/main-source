namespace Spine
{
	public class Sequence
	{
		private static int nextID;

		private static readonly object nextIdLock;

		internal readonly int id;

		internal readonly TextureRegion[] regions;

		internal int start;

		internal int digits;

		internal int setupIndex;

		public int Start
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Digits
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int SetupIndex
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public TextureRegion[] Regions => null;

		public int Id => 0;

		public Sequence(int count)
		{
		}

		public Sequence(Sequence other)
		{
		}

		public void Apply(Slot slot, IHasTextureRegion attachment)
		{
		}

		public string GetPath(string basePath, int index)
		{
			return null;
		}
	}
}
