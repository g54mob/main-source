using System;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class GetSetValue<T> : IGetSetValue<T>, IGetValue<T>, ISetValue<T>
	{
		private Func<T> nDUnuFzGkUMAbyKKbyuRzSgVPmEb;

		private Action<T> OIfDfqmlfobfirjIpQXnBkcjkCXi;

		public Func<T> getValueDelegate
		{
			get
			{
				return nDUnuFzGkUMAbyKKbyuRzSgVPmEb;
			}
			set
			{
				nDUnuFzGkUMAbyKKbyuRzSgVPmEb = value;
			}
		}

		public Action<T> setValueDelegate
		{
			get
			{
				return OIfDfqmlfobfirjIpQXnBkcjkCXi;
			}
			set
			{
				OIfDfqmlfobfirjIpQXnBkcjkCXi = value;
			}
		}

		public GetSetValue(Func<T> P_0, Action<T> P_1)
		{
			nDUnuFzGkUMAbyKKbyuRzSgVPmEb = P_0;
			OIfDfqmlfobfirjIpQXnBkcjkCXi = P_1;
		}

		public T GetValue()
		{
			if (nDUnuFzGkUMAbyKKbyuRzSgVPmEb == null)
			{
				throw new ArgumentNullException("getValueDelegate");
			}
			return nDUnuFzGkUMAbyKKbyuRzSgVPmEb();
		}

		public void SetValue(T value)
		{
			if (OIfDfqmlfobfirjIpQXnBkcjkCXi == null)
			{
				throw new ArgumentNullException("setValueDelegate");
			}
			OIfDfqmlfobfirjIpQXnBkcjkCXi(value);
		}
	}
}
