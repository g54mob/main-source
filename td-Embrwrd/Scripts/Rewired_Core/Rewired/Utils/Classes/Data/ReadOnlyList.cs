using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class ReadOnlyList<T> : Rewired.Utils.Interfaces.IReadOnlyList<T>, IReadOnlyList, IEnumerable<T>, IEnumerable
	{
		private readonly IList<T> rqiDYCOIJVXtOTBWNyHriUsAIpgs;

		public int Count => 0;

		public T this[int index] => default(T);

		object IReadOnlyList.this[int P_0] => null;

		public ReadOnlyList(IList<T> P_0)
		{
		}

		public ReadOnlyList(ReadOnlyList<T> P_0)
		{
		}

		public bool Contains(T value)
		{
			return false;
		}

		public int IndexOf(T value)
		{
			return 0;
		}

		public void CopyTo(IList<T> destination)
		{
		}

		private int kHfgunhsCGPHNAvWOKVtdCAUeTfP(object P_0)
		{
			return 0;
		}

		int IReadOnlyList.IndexOf(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in kHfgunhsCGPHNAvWOKVtdCAUeTfP
			return this.kHfgunhsCGPHNAvWOKVtdCAUeTfP(P_0);
		}

		private bool nVCKJppSKxVkQpUXBrDNSBORQjSy(object P_0)
		{
			return false;
		}

		bool IReadOnlyList.Contains(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in nVCKJppSKxVkQpUXBrDNSBORQjSy
			return this.nVCKJppSKxVkQpUXBrDNSBORQjSy(P_0);
		}

		private IEnumerator<T> RhidxvGRfJmvOylehAqFeKlhBefub()
		{
			return null;
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in RhidxvGRfJmvOylehAqFeKlhBefub
			return this.RhidxvGRfJmvOylehAqFeKlhBefub();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}
