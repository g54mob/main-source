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
		private readonly IList<T> EEkLeUzmCVUPSoypsumLTchaeNTo;

		int IReadOnlyList.Count => EEkLeUzmCVUPSoypsumLTchaeNTo.Count;

		T Rewired.Utils.Interfaces.IReadOnlyList<T>.this[int index] => EEkLeUzmCVUPSoypsumLTchaeNTo[index];

		object IReadOnlyList.this[int P_0] => (this as IList)[P_0];

		public ReadOnlyList(IList<T> P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException();
			}
			EEkLeUzmCVUPSoypsumLTchaeNTo = P_0;
		}

		public ReadOnlyList(ReadOnlyList<T> P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException();
			}
			EEkLeUzmCVUPSoypsumLTchaeNTo = new List<T>(P_0.EEkLeUzmCVUPSoypsumLTchaeNTo);
		}

		public bool Contains(T value)
		{
			return EEkLeUzmCVUPSoypsumLTchaeNTo.Contains(value);
		}

		bool Rewired.Utils.Interfaces.IReadOnlyList<T>.Contains(T value)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Contains
			return this.Contains(value);
		}

		public int IndexOf(T value)
		{
			return EEkLeUzmCVUPSoypsumLTchaeNTo.IndexOf(value);
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
			for (int i = 0; i < EEkLeUzmCVUPSoypsumLTchaeNTo.Count; i++)
			{
				destination.Add(EEkLeUzmCVUPSoypsumLTchaeNTo[i]);
			}
		}

		private int XgpbplAPqEacHlrtzrDJENtybdEE(object P_0)
		{
			return (this as IList).IndexOf(P_0);
		}

		int IReadOnlyList.IndexOf(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in XgpbplAPqEacHlrtzrDJENtybdEE
			return this.XgpbplAPqEacHlrtzrDJENtybdEE(P_0);
		}

		private bool UuKIehWLQvBGEMGaocNdfnHfFnzF(object P_0)
		{
			return (this as IList).Contains(P_0);
		}

		bool IReadOnlyList.Contains(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in UuKIehWLQvBGEMGaocNdfnHfFnzF
			return this.UuKIehWLQvBGEMGaocNdfnHfFnzF(P_0);
		}

		private IEnumerator<T> qOscXdscaNONGWRTGNZdzbuhWHKL()
		{
			return EEkLeUzmCVUPSoypsumLTchaeNTo.GetEnumerator();
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in qOscXdscaNONGWRTGNZdzbuhWHKL
			return this.qOscXdscaNONGWRTGNZdzbuhWHKL();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return EEkLeUzmCVUPSoypsumLTchaeNTo.GetEnumerator();
		}
	}
}
