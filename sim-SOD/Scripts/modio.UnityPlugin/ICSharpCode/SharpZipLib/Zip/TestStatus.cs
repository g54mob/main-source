namespace ICSharpCode.SharpZipLib.Zip
{
	public class TestStatus
	{
		private readonly ZipFile file_;

		private ZipEntry entry_;

		private bool entryValid_;

		private int errorCount_;

		private long bytesTested_;

		private TestOperation operation_;

		public TestOperation Operation => default(TestOperation);

		public ZipFile File => null;

		public ZipEntry Entry => null;

		public int ErrorCount => 0;

		public long BytesTested => 0L;

		public bool EntryValid => false;

		public TestStatus(ZipFile file)
		{
		}

		internal void AddError()
		{
		}

		internal void SetOperation(TestOperation operation)
		{
		}

		internal void SetEntry(ZipEntry entry)
		{
		}

		internal void SetBytesTested(long value)
		{
		}
	}
}
