using System;
using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Collections
{
	public class UnmodifiableListProxy : UnmodifiableList
	{
		private readonly IList l;

		public override int Count => 0;

		public override bool IsFixedSize => false;

		public override bool IsSynchronized => false;

		public override object SyncRoot => null;

		public UnmodifiableListProxy(IList l)
		{
		}

		public override bool Contains(object o)
		{
			return false;
		}

		public override void CopyTo(Array array, int index)
		{
		}

		public override IEnumerator GetEnumerator()
		{
			return null;
		}

		public override int IndexOf(object o)
		{
			return 0;
		}

		protected override object GetValue(int i)
		{
			return null;
		}
	}
}
