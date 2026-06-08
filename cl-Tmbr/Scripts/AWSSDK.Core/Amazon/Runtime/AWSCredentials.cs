using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.Runtime.Identity;
using Amazon.Runtime.Internal.UserAgent;

namespace Amazon.Runtime
{
	public abstract class AWSCredentials : BaseIdentity
	{
		internal HashSet<UserAgentFeatureId> FeatureIdSources { get; set; } = new HashSet<UserAgentFeatureId>();

		public abstract ImmutableCredentials GetCredentials();

		protected virtual void Validate()
		{
		}

		public virtual Task<ImmutableCredentials> GetCredentialsAsync()
		{
			return Task.FromResult(GetCredentials());
		}
	}
}
