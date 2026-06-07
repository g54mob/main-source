using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Collections
{
	internal class LinkedDictionaryEnumerator : IDictionaryEnumerator, IEnumerator
	{
		private readonly LinkedDictionary parent;

		private int pos;

		public virtual object Current => null;

		public virtual DictionaryEntry Entry => default(DictionaryEntry);

		public virtual object Key => null;

		public virtual object Value => null;

		private object CurrentKey => null;

		internal LinkedDictionaryEnumerator(LinkedDictionary parent)
		{
		}

		public virtual bool MoveNext()
		{
			return false;
		}

		public virtual void Reset()
		{
		}
	}
}
