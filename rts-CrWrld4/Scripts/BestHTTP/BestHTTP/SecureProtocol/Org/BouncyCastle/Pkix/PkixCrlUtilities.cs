using System;
using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.X509.Store;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Pkix
{
	public class PkixCrlUtilities
	{
		public virtual ISet FindCrls(X509CrlStoreSelector crlselect, PkixParameters paramsPkix, DateTime currentDate)
		{
			return null;
		}

		public virtual ISet FindCrls(X509CrlStoreSelector crlselect, PkixParameters paramsPkix)
		{
			return null;
		}

		private ICollection FindCrls(X509CrlStoreSelector crlSelect, IList crlStores)
		{
			return null;
		}
	}
}
