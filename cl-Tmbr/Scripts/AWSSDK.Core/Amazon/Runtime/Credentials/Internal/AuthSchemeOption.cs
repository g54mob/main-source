using System.Collections.Generic;
using Amazon.Runtime.Internal.Auth;

namespace Amazon.Runtime.Credentials.Internal
{
	public class AuthSchemeOption : IAuthSchemeOption
	{
		internal const string SigV4 = "aws.auth#sigv4";

		internal const string SigV4A = "aws.auth#sigv4a";

		internal const string Bearer = "smithy.api#httpBearerAuth";

		internal const string NoAuth = "smithy.api#noAuth";

		public static readonly List<IAuthSchemeOption> DEFAULT_SIGV4 = new List<IAuthSchemeOption>
		{
			new AuthSchemeOption
			{
				SchemeId = "aws.auth#sigv4"
			}
		};

		public static readonly List<IAuthSchemeOption> DEFAULT_SIGV4A = new List<IAuthSchemeOption>
		{
			new AuthSchemeOption
			{
				SchemeId = "aws.auth#sigv4a"
			}
		};

		public static readonly List<IAuthSchemeOption> DEFAULT_SIGV4_SIGV4A = new List<IAuthSchemeOption>
		{
			new AuthSchemeOption
			{
				SchemeId = "aws.auth#sigv4"
			},
			new AuthSchemeOption
			{
				SchemeId = "aws.auth#sigv4a"
			}
		};

		public static readonly List<IAuthSchemeOption> DEFAULT_BEARER = new List<IAuthSchemeOption>
		{
			new AuthSchemeOption
			{
				SchemeId = "smithy.api#httpBearerAuth"
			}
		};

		public static readonly List<IAuthSchemeOption> DEFAULT_NOAUTH = new List<IAuthSchemeOption>
		{
			new AuthSchemeOption
			{
				SchemeId = "smithy.api#noAuth"
			}
		};

		public string SchemeId { get; set; }
	}
}
