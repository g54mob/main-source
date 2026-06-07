using System;

namespace Google.Apis.Auth.OAuth2
{
	internal static class JsonCredentialParametersExtensions
	{
		public static string ExtractSubjectTokenFieldName(this JsonCredentialParameters parameters)
		{
			JsonCredentialParameters.CredentialSource.SubjectTokenFormat format = parameters.CredentialSourceConfig.Format;
			if (format == null || format.Type?.Equals("json", StringComparison.OrdinalIgnoreCase) != true)
			{
				return null;
			}
			return parameters.CredentialSourceConfig.Format.SubjectTokenFieldName;
		}
	}
}
