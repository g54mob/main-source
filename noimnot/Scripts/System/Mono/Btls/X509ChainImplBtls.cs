using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Mono.Btls
{
	internal class X509ChainImplBtls : X509ChainImpl
	{
		private MonoBtlsX509StoreCtx storeCtx;

		private MonoBtlsX509Chain chain;

		private MonoBtlsX509Chain untrustedChain;

		private X509ChainElementCollection elements;

		private X509Certificate2Collection untrusted;

		private X509Certificate2[] certificates;

		private X509ChainPolicy policy;

		private List<X509ChainStatus> chainStatusList;

		public override bool IsValid => false;

		internal MonoBtlsX509StoreCtx StoreCtx => null;

		public override X509ChainElementCollection ChainElements => null;

		public override X509ChainPolicy ChainPolicy => null;

		internal X509ChainImplBtls(MonoBtlsX509Chain chain)
		{
		}

		internal X509ChainImplBtls(MonoBtlsX509StoreCtx storeCtx)
		{
		}

		public override void AddStatus(X509ChainStatusFlags errorCode)
		{
		}

		public override bool Build(X509Certificate2 certificate)
		{
			return false;
		}

		public override void Reset()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}
	}
}
