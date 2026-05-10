using System.Security.Cryptography.X509Certificates;

namespace Mono.Btls
{
	internal class MonoBtlsX509LookupMonoCollection : MonoBtlsX509LookupMono
	{
		private long[] hashes;

		private MonoBtlsX509[] certificates;

		private X509CertificateCollection collection;

		private MonoBtlsX509TrustKind trust;

		internal MonoBtlsX509LookupMonoCollection(X509CertificateCollection collection, MonoBtlsX509TrustKind trust)
		{
		}

		private void Initialize()
		{
		}

		protected override MonoBtlsX509 OnGetBySubject(MonoBtlsX509Name name)
		{
			return null;
		}

		protected override void Close()
		{
		}
	}
}
