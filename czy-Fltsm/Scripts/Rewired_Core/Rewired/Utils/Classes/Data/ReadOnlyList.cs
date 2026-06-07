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
		private readonly IList<T> jsCgbutvDJDMLVKeCWWiPqQUVnSJ;

		int IReadOnlyList.Count => jsCgbutvDJDMLVKeCWWiPqQUVnSJ.Count;

		T Rewired.Utils.Interfaces.IReadOnlyList<T>.this[int index] => jsCgbutvDJDMLVKeCWWiPqQUVnSJ[index];

		object IReadOnlyList.this[int P_0] => (this as IList)[P_0];

		public ReadOnlyList(IList<T> P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException();
			}
			jsCgbutvDJDMLVKeCWWiPqQUVnSJ = P_0;
		}

		public ReadOnlyList(ReadOnlyList<T> P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException();
			}
			jsCgbutvDJDMLVKeCWWiPqQUVnSJ = new List<T>(P_0.jsCgbutvDJDMLVKeCWWiPqQUVnSJ);
		}

		public bool Contains(T value)
		{
			return jsCgbutvDJDMLVKeCWWiPqQUVnSJ.Contains(value);
		}

		bool Rewired.Utils.Interfaces.IReadOnlyList<T>.Contains(T value)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Contains
			return this.Contains(value);
		}

		public int IndexOf(T value)
		{
			return jsCgbutvDJDMLVKeCWWiPqQUVnSJ.IndexOf(value);
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
			for (int i = 0; i < jsCgbutvDJDMLVKeCWWiPqQUVnSJ.Count; i++)
			{
				destination.Add(jsCgbutvDJDMLVKeCWWiPqQUVnSJ[i]);
			}
		}

		private int mjDKKROAAEpuQGtaVPviImgYbQZh(object P_0)
		{
			return (this as IList).IndexOf(P_0);
		}

		int IReadOnlyList.IndexOf(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in mjDKKROAAEpuQGtaVPviImgYbQZh
			return this.mjDKKROAAEpuQGtaVPviImgYbQZh(P_0);
		}

		private bool pvqrsRGAtvOBFtdqECOKvusZHime(object P_0)
		{
			return (this as IList).Contains(P_0);
		}

		bool IReadOnlyList.Contains(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in pvqrsRGAtvOBFtdqECOKvusZHime
			return this.pvqrsRGAtvOBFtdqECOKvusZHime(P_0);
		}

		private IEnumerator<T> HBQJkXwZpHTwNfoAadtGnbFZGpFH()
		{
			return jsCgbutvDJDMLVKeCWWiPqQUVnSJ.GetEnumerator();
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in HBQJkXwZpHTwNfoAadtGnbFZGpFH
			return this.HBQJkXwZpHTwNfoAadtGnbFZGpFH();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return jsCgbutvDJDMLVKeCWWiPqQUVnSJ.GetEnumerator();
		}
	}
}
