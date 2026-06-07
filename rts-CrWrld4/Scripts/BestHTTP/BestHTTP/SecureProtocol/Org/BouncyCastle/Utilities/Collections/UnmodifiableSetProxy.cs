using System;
using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Collections
{
	public class UnmodifiableSetProxy : UnmodifiableSet
	{
		private readonly ISet s;

		public override int Count => 0;

		public override bool IsEmpty => false;

		public override bool IsFixedSize => false;

		public override bool IsSynchronized => false;

		public override object SyncRoot => null;

		public UnmodifiableSetProxy(ISet s)
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
	}
}
