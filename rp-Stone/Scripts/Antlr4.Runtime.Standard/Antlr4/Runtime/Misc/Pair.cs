namespace Antlr4.Runtime.Misc
{
	public class Pair<A, B>
	{
		public readonly A a;

		public readonly B b;

		public Pair(A a, B b)
		{
			this.a = a;
			this.b = b;
		}

		public override bool Equals(object obj)
		{
			if (obj == this)
			{
				return true;
			}
			if (!(obj is Pair<A, B>))
			{
				return false;
			}
			Pair<A, B> pair = (Pair<A, B>)obj;
			if ((a == null) ? (pair.a == null) : a.Equals(pair.a))
			{
				if (b != null)
				{
					return b.Equals(pair.b);
				}
				return pair.b == null;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return MurmurHash.Finish(MurmurHash.Update(MurmurHash.Update(MurmurHash.Initialize(), a), b), 2);
		}

		public override string ToString()
		{
			return $"({a}, {b})";
		}
	}
}
