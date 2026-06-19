namespace Loxodon.Framework.Tutorials
{
	public class Progress
	{
		public int bytes;

		public int TotalBytes;

		public int Percentage => bytes * 100 / TotalBytes;
	}
}
