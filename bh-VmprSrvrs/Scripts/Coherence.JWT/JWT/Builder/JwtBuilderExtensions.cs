using System;
using System.Collections.Generic;

namespace JWT.Builder
{
	public static class JwtBuilderExtensions
	{
		public static JwtBuilder AddClaim(this JwtBuilder builder, ClaimName name, object value)
		{
			return null;
		}

		public static JwtBuilder AddClaim<T>(this JwtBuilder builder, ClaimName name, T value)
		{
			return null;
		}

		public static JwtBuilder AddClaim<T>(this JwtBuilder builder, string name, T value)
		{
			return null;
		}

		public static JwtBuilder AddClaims(this JwtBuilder builder, IEnumerable<KeyValuePair<string, object>> claims)
		{
			return null;
		}

		public static JwtBuilder ExpirationTime(this JwtBuilder builder, DateTime time)
		{
			return null;
		}

		public static JwtBuilder ExpirationTime(this JwtBuilder builder, long time)
		{
			return null;
		}

		public static JwtBuilder Issuer(this JwtBuilder builder, string issuer)
		{
			return null;
		}

		public static JwtBuilder Subject(this JwtBuilder builder, string subject)
		{
			return null;
		}

		public static JwtBuilder Audience(this JwtBuilder builder, string audience)
		{
			return null;
		}

		public static JwtBuilder NotBefore(this JwtBuilder builder, DateTime time)
		{
			return null;
		}

		public static JwtBuilder NotBefore(this JwtBuilder builder, long time)
		{
			return null;
		}

		public static JwtBuilder IssuedAt(this JwtBuilder builder, DateTime time)
		{
			return null;
		}

		public static JwtBuilder IssuedAt(this JwtBuilder builder, long time)
		{
			return null;
		}

		public static JwtBuilder Id(this JwtBuilder builder, Guid id)
		{
			return null;
		}

		public static JwtBuilder Id(this JwtBuilder builder, long id)
		{
			return null;
		}

		public static JwtBuilder Id(this JwtBuilder builder, string id)
		{
			return null;
		}

		public static JwtBuilder GivenName(this JwtBuilder builder, string name)
		{
			return null;
		}

		public static JwtBuilder FamilyName(this JwtBuilder builder, string lastname)
		{
			return null;
		}

		public static JwtBuilder MiddleName(this JwtBuilder builder, string middleName)
		{
			return null;
		}
	}
}
