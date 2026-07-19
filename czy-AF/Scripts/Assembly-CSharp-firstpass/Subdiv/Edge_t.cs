namespace Subdiv
{
	public struct Edge_t
	{
		public int v0;

		public int v1;

		public override bool Equals(object obj)
		{
			if (!(obj is Edge_t edge_t))
			{
				return false;
			}
			if (Has(edge_t.v0))
			{
				return Has(edge_t.v1);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public bool Has(int iv)
		{
			if (v0 != iv)
			{
				return v1 == iv;
			}
			return true;
		}
	}
}
