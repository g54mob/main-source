namespace GRP
{
	public struct RattleKey
	{
		public int a;

		public int b;

		public bool Equals(RattleKey other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
