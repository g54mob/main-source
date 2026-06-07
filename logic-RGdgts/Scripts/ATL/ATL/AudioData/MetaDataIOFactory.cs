namespace ATL.AudioData
{
	public class MetaDataIOFactory : Factory
	{
		public enum TagType
		{
			ID3V1 = 0,
			ID3V2 = 1,
			APE = 2,
			NATIVE = 3,
			ANY = 99
		}

		public static readonly int TAG_TYPE_COUNT;

		private static MetaDataIOFactory theFactory;

		private static readonly object _lockable;

		public bool CrossReading { get; }

		public TagType[] TagPriority { get; set; }

		public static MetaDataIOFactory GetInstance()
		{
			return null;
		}

		public IMetaDataIO GetMetaReader(AudioDataManager theDataManager, TagType forceTagType = TagType.ANY)
		{
			return null;
		}
	}
}
