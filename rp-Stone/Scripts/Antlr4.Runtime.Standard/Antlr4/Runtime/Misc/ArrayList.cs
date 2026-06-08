using System.Collections.Generic;

namespace Antlr4.Runtime.Misc
{
	public class ArrayList<T> : List<T>
	{
		public ArrayList()
		{
		}

		public ArrayList(int count)
			: base(count)
		{
		}

		public override int GetHashCode()
		{
			int hash = MurmurHash.Initialize(1);
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					hash = MurmurHash.Update(hash, enumerator.Current.GetHashCode());
				}
			}
			return MurmurHash.Finish(hash, base.Count);
		}

		public override bool Equals(object o)
		{
			if (o != this)
			{
				if (o is List<T>)
				{
					return Equals((List<T>)o);
				}
				return false;
			}
			return true;
		}

		public bool Equals(List<T> o)
		{
			if (base.Count != o.Count)
			{
				return false;
			}
			IEnumerator<T> enumerator = GetEnumerator();
			IEnumerator<T> enumerator2 = o.GetEnumerator();
			while (enumerator.MoveNext() && enumerator2.MoveNext())
			{
				if (!enumerator.Current.Equals(enumerator2.Current))
				{
					return false;
				}
			}
			return true;
		}
	}
}
