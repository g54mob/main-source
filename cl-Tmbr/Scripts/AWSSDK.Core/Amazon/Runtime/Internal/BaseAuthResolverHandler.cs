using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime.Credentials.Internal;
using Amazon.Runtime.Endpoints;
using Amazon.Runtime.Identity;
using Amazon.Runtime.Internal.Auth;
using Amazon.Runtime.Internal.UserAgent;

namespace Amazon.Runtime.Internal
{
	public abstract class BaseAuthResolverHandler : PipelineHandler
	{
		private readonly HashSet<IAuthScheme<BaseIdentity>> _supportedSchemes = new HashSet<IAuthScheme<BaseIdentity>>
		{
			new AnonymousAuthScheme(),
			new AwsV4aAuthScheme(),
			new AwsV4AuthScheme(),
			new BearerAuthScheme()
		};

		public override void InvokeSync(IExecutionContext executionContext)
		{
			PreInvoke(executionContext);
			base.InvokeSync(executionContext);
		}

		public override async Task<T> InvokeAsync<T>(IExecutionContext executionContext)
		{
			await PreInvokeAsync(executionContext).ConfigureAwait(continueOnCapturedContext: false);
			return await base.InvokeAsync<T>(executionContext).ConfigureAwait(continueOnCapturedContext: false);
		}

		protected void PreInvoke(IExecutionContext executionContext)
		{
			List<IAuthSchemeOption> authOptions = ResolveAuthOptions(executionContext);
			if (authOptions == null || authOptions.Count == 0)
			{
				throw new AmazonClientException("No valid authentication schemes defined for " + executionContext.RequestContext.RequestName);
			}
			IClientConfig clientConfig = executionContext.RequestContext.ClientConfig;
			int i;
			for (i = 0; i < authOptions.Count; i++)
			{
				IAuthScheme<BaseIdentity> authScheme = _supportedSchemes.FirstOrDefault((IAuthScheme<BaseIdentity> s) => s.SchemeId == authOptions[i].SchemeId);
				if (authScheme == null)
				{
					Logger.DebugFormat(authOptions[i].SchemeId + " scheme is not supported for " + executionContext.RequestContext.RequestName);
					continue;
				}
				try
				{
					executionContext.RequestContext.Signer = GetSigner(authScheme);
					if ((authScheme is AwsV4aAuthScheme || authScheme is AwsV4AuthScheme) && clientConfig.DefaultAWSCredentials != null)
					{
						executionContext.RequestContext.Identity = clientConfig.DefaultAWSCredentials;
						break;
					}
					if (authScheme is BearerAuthScheme && clientConfig.AWSTokenProvider != null)
					{
						TryResponse<AWSToken> result = clientConfig.AWSTokenProvider.TryResolveTokenAsync().GetAwaiter().GetResult();
						if (result.Success)
						{
							AWSToken value = result.Value;
							executionContext.RequestContext.Identity = value;
							break;
						}
					}
					else
					{
						IIdentityResolver identityResolver = authScheme.GetIdentityResolver(clientConfig.IdentityResolverConfiguration);
						executionContext.RequestContext.Identity = identityResolver.ResolveIdentity(clientConfig);
						if (executionContext.RequestContext.Identity != null)
						{
							break;
						}
					}
				}
				catch (Exception ex)
				{
					if (i < authOptions.Count - 1)
					{
						Logger.DebugFormat("Could not resolve identity for " + executionContext.RequestContext.RequestName + " using " + authScheme.SchemeId + " scheme: " + ex.Message);
						continue;
					}
					throw;
				}
			}
			if (executionContext.RequestContext.Identity == null)
			{
				throw new AmazonClientException("Could not determine which authentication scheme to use for " + executionContext.RequestContext.RequestName);
			}
			AddUserAgentDetails(executionContext);
		}

		protected async Task PreInvokeAsync(IExecutionContext executionContext)
		{
			List<IAuthSchemeOption> authOptions = ResolveAuthOptions(executionContext);
			if (authOptions == null || authOptions.Count == 0)
			{
				throw new AmazonClientException("No valid authentication schemes defined for " + executionContext.RequestContext.RequestName);
			}
			IClientConfig clientConfig = executionContext.RequestContext.ClientConfig;
			CancellationToken cancellationToken = executionContext.RequestContext.CancellationToken;
			int i;
			for (i = 0; i < authOptions.Count; i++)
			{
				IAuthScheme<BaseIdentity> scheme = _supportedSchemes.FirstOrDefault((IAuthScheme<BaseIdentity> s) => s.SchemeId == authOptions[i].SchemeId);
				if (scheme == null)
				{
					Logger.DebugFormat(authOptions[i].SchemeId + " scheme is not supported for " + executionContext.RequestContext.RequestName);
					continue;
				}
				try
				{
					executionContext.RequestContext.Signer = GetSigner(scheme);
					if ((scheme is AwsV4aAuthScheme || scheme is AwsV4AuthScheme) && clientConfig.DefaultAWSCredentials != null)
					{
						executionContext.RequestContext.Identity = clientConfig.DefaultAWSCredentials;
						break;
					}
					if (scheme is BearerAuthScheme && clientConfig.AWSTokenProvider != null)
					{
						TryResponse<AWSToken> tryResponse = await clientConfig.AWSTokenProvider.TryResolveTokenAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
						if (tryResponse.Success)
						{
							executionContext.RequestContext.Identity = tryResponse.Value;
							break;
						}
						continue;
					}
					IIdentityResolver identityResolver = scheme.GetIdentityResolver(clientConfig.IdentityResolverConfiguration);
					IRequestContext requestContext = executionContext.RequestContext;
					requestContext.Identity = await identityResolver.ResolveIdentityAsync(clientConfig, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (executionContext.RequestContext.Identity != null)
					{
						break;
					}
				}
				catch (Exception ex)
				{
					if (i < authOptions.Count - 1)
					{
						Logger.DebugFormat("Could not resolve identity for " + executionContext.RequestContext.RequestName + " using " + scheme.SchemeId + " scheme: " + ex.Message);
						continue;
					}
					throw;
				}
			}
			if (executionContext.RequestContext.Identity == null)
			{
				throw new AmazonClientException("Could not determine which authentication scheme to use for " + executionContext.RequestContext.RequestName);
			}
			AddUserAgentDetails(executionContext);
		}

		protected virtual ISigner GetSigner(IAuthScheme<BaseIdentity> scheme)
		{
			return scheme.Signer();
		}

		protected static List<IAuthSchemeOption> RetrieveSchemesFromEndpoint(Endpoint endpoint)
		{
			if (endpoint == null || endpoint.Attributes == null)
			{
				return null;
			}
			if (!(endpoint.Attributes["authSchemes"] is IList source))
			{
				return null;
			}
			List<string> list = (from scheme in source.OfType<PropertyBag>()
				select (string)scheme["name"]).ToList();
			if (list.Count == 1)
			{
				switch (list.First())
				{
				case "sigv4":
				case "sigv4-s3express":
					return AuthSchemeOption.DEFAULT_SIGV4;
				case "sigv4a":
					return AuthSchemeOption.DEFAULT_SIGV4A;
				}
			}
			List<IAuthSchemeOption> list2 = new List<IAuthSchemeOption>();
			foreach (string item in list)
			{
				switch (item)
				{
				case "sigv4":
				case "sigv4-s3express":
					list2.Add(new AuthSchemeOption
					{
						SchemeId = "aws.auth#sigv4"
					});
					break;
				case "sigv4a":
					list2.Add(new AuthSchemeOption
					{
						SchemeId = "aws.auth#sigv4a"
					});
					break;
				}
			}
			return list2;
		}

		protected abstract List<IAuthSchemeOption> ResolveAuthOptions(IExecutionContext executionContext);

		private static void AddUserAgentDetails(IExecutionContext executionContext)
		{
			IRequestContext requestContext = executionContext.RequestContext;
			if (requestContext.Identity == null || !(requestContext.Identity is AWSCredentials aWSCredentials))
			{
				return;
			}
			foreach (UserAgentFeatureId featureIdSource in aWSCredentials.FeatureIdSources)
			{
				requestContext.UserAgentDetails.AddFeature(featureIdSource);
			}
		}
	}
}
