using System;
using System.Threading;
using System.Threading.Tasks;
using Amazon.S3.Model;

namespace Amazon.S3
{
	public interface IS3ExpressCredentialProvider : IDisposable
	{
		SessionCredentials ResolveSessionCredentials(string bucketName);

		Task<SessionCredentials> ResolveSessionCredentialsAsync(string bucketName, CancellationToken cancellationToken = default(CancellationToken));
	}
}
