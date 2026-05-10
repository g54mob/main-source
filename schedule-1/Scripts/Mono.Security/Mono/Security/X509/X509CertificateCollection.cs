using System;
using System.Collections;

namespace Mono.Security.X509
{
	[Serializable]
	public class X509CertificateCollection : CollectionBase, IEnumerable
	{
		public class X509CertificateEnumerator : IEnumerator
		{
			private IEnumerator enumerator;

			public X509Certificate Current => null;

			object IEnumerator.Current => null;

			public X509CertificateEnumerator(X509CertificateCollection mappings)
			{
			}

			bool IEnumerator.MoveNext()
			{
				return false;
			}

			void IEnumerator.Reset()
			{
			}

			public bool MoveNext()
			{
				return false;
			}
		}

		public X509Certificate this[int index] => null;

		public int Add(X509Certificate value)
		{
			return 0;
		}

		public void AddRange(X509CertificateCollection value)
		{
		}

		public bool Contains(X509Certificate value)
		{
			return false;
		}

		public new X509CertificateEnumerator GetEnumerator()
		{
			return null;
		}

		private new IEnumerator GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetEnumerator
			return this.GetEnumerator();
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public int IndexOf(X509Certificate value)
		{
			return 0;
		}

		private bool Compare(byte[] array1, byte[] array2)
		{
			return false;
		}
	}
}
