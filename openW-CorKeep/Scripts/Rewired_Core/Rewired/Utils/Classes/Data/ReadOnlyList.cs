using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[DefaultMember("Item")]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class ReadOnlyList<T> : Rewired.Utils.Interfaces.IReadOnlyList<T>, IReadOnlyList, IEnumerable<T>, IEnumerable
	{
		private readonly IList<T> xnCkzfHfkDLezySbPBTwYCBtOfCe;

		int IReadOnlyList.Count => xnCkzfHfkDLezySbPBTwYCBtOfCe.Count;

		T Rewired.Utils.Interfaces.IReadOnlyList<T>.this[int index] => xnCkzfHfkDLezySbPBTwYCBtOfCe[index];

		object IReadOnlyList.this[int P_0] => (this as IList)[P_0];

		public ReadOnlyList(IList<T> P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException();
			}
			xnCkzfHfkDLezySbPBTwYCBtOfCe = P_0;
		}

		public ReadOnlyList(ReadOnlyList<T> P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException();
			}
			xnCkzfHfkDLezySbPBTwYCBtOfCe = new List<T>(P_0.xnCkzfHfkDLezySbPBTwYCBtOfCe);
		}

		public bool Contains(T value)
		{
			return xnCkzfHfkDLezySbPBTwYCBtOfCe.Contains(value);
		}

		bool Rewired.Utils.Interfaces.IReadOnlyList<T>.Contains(T value)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Contains
			return this.Contains(value);
		}

		public int IndexOf(T value)
		{
			return xnCkzfHfkDLezySbPBTwYCBtOfCe.IndexOf(value);
		}

		int Rewired.Utils.Interfaces.IReadOnlyList<T>.IndexOf(T value)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IndexOf
			return this.IndexOf(value);
		}

		public void CopyTo(IList<T> destination)
		{
			if (destination == null)
			{
				throw new ArgumentNullException();
			}
			for (int i = 0; i < xnCkzfHfkDLezySbPBTwYCBtOfCe.Count; i++)
			{
				destination.Add(xnCkzfHfkDLezySbPBTwYCBtOfCe[i]);
			}
		}

		private int yGZGKKsnsShEmdnCKCUTVuklieDj(object P_0)
		{
			return (this as IList).IndexOf(P_0);
		}

		int IReadOnlyList.IndexOf(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in yGZGKKsnsShEmdnCKCUTVuklieDj
			return this.yGZGKKsnsShEmdnCKCUTVuklieDj(P_0);
		}

		private bool zsyhVQymktOhrYCVHXtpsFesiCww(object P_0)
		{
			return (this as IList).Contains(P_0);
		}

		bool IReadOnlyList.Contains(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in zsyhVQymktOhrYCVHXtpsFesiCww
			return this.zsyhVQymktOhrYCVHXtpsFesiCww(P_0);
		}

		private IEnumerator<T> HeARhEEDRNZhhIuyrsFvmeFkPCFj()
		{
			return xnCkzfHfkDLezySbPBTwYCBtOfCe.GetEnumerator();
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in HeARhEEDRNZhhIuyrsFvmeFkPCFj
			return this.HeARhEEDRNZhhIuyrsFvmeFkPCFj();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return xnCkzfHfkDLezySbPBTwYCBtOfCe.GetEnumerator();
		}
	}
}
