namespace VoxelBusters.CoreLibrary
{
	public class Error
	{
		public string Domain { get; private set; }

		public int Code { get; private set; }

		public string Description { get; private set; }

		public Error(string description)
		{
		}

		public Error(string domain, int code, string description)
		{
		}

		public static Error CreateNullableError(string description)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
