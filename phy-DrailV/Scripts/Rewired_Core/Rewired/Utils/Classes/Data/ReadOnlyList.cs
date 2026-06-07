using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class ReadOnlyList<T> : IEnumerable, IEnumerable<T>, Rewired.Utils.Interfaces.IReadOnlyList<T>, IReadOnlyList
	{
		private readonly IList<T> VclIzXqzjHdMOfpSsGrynyTedqzj;

		public int Count => VclIzXqzjHdMOfpSsGrynyTedqzj.Count;

		public T this[int index] => VclIzXqzjHdMOfpSsGrynyTedqzj[index];

		object IReadOnlyList.this[int P_0] => (this as IList)[P_0];

		public ReadOnlyList(IList<T> P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException();
			}
			VclIzXqzjHdMOfpSsGrynyTedqzj = P_0;
		}

		public ReadOnlyList(ReadOnlyList<T> P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException();
			}
			VclIzXqzjHdMOfpSsGrynyTedqzj = new List<T>(P_0.VclIzXqzjHdMOfpSsGrynyTedqzj);
		}

		public bool Contains(T value)
		{
			return VclIzXqzjHdMOfpSsGrynyTedqzj.Contains(value);
		}

		public int IndexOf(T value)
		{
			return VclIzXqzjHdMOfpSsGrynyTedqzj.IndexOf(value);
		}

		public void CopyTo(IList<T> destination)
		{
			if (destination == null)
			{
				throw new ArgumentNullException();
			}
			for (int i = 0; i < VclIzXqzjHdMOfpSsGrynyTedqzj.Count; i++)
			{
				destination.Add(VclIzXqzjHdMOfpSsGrynyTedqzj[i]);
			}
		}

		private int oopGXBOLFWlYyFeccShWLBwtSzt(object P_0)
		{
			return (this as IList).IndexOf(P_0);
		}

		int IReadOnlyList.IndexOf(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in oopGXBOLFWlYyFeccShWLBwtSzt
			return this.oopGXBOLFWlYyFeccShWLBwtSzt(P_0);
		}

		private bool drGGfFExRSonxdTcsfHrIXktIFggA(object P_0)
		{
			return (this as IList).Contains(P_0);
		}

		bool IReadOnlyList.Contains(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in drGGfFExRSonxdTcsfHrIXktIFggA
			return this.drGGfFExRSonxdTcsfHrIXktIFggA(P_0);
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return VclIzXqzjHdMOfpSsGrynyTedqzj.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return VclIzXqzjHdMOfpSsGrynyTedqzj.GetEnumerator();
		}
	}
}
