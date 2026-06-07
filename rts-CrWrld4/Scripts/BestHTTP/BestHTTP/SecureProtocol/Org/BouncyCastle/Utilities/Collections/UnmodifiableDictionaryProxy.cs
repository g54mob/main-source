using System;
using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Collections
{
	public class UnmodifiableDictionaryProxy : UnmodifiableDictionary
	{
		private readonly IDictionary d;

		public override int Count => 0;

		public override bool IsFixedSize => false;

		public override bool IsSynchronized => false;

		public override object SyncRoot => null;

		public override ICollection Keys => null;

		public override ICollection Values => null;

		public UnmodifiableDictionaryProxy(IDictionary d)
		{
		}

		public override bool Contains(object k)
		{
			return false;
		}

		public override void CopyTo(Array array, int index)
		{
		}

		public override IDictionaryEnumerator GetEnumerator()
		{
			return null;
		}

		protected override object GetValue(object k)
		{
			return null;
		}
	}
}
