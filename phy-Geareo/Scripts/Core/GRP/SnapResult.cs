namespace GRP
{
	public struct SnapResult
	{
		public SnapPoint a;

		public SnapPoint b;

		public float distance => 0f;

		public bool Equals(SnapResult other)
		{
			return false;
		}
	}
}
