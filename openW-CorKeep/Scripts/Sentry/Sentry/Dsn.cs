using System;

namespace Sentry
{
	internal sealed class Dsn
	{
		public string Source { get; }

		public string ProjectId { get; }

		public string? Path { get; }

		public string? SecretKey { get; }

		public string PublicKey { get; }

		private Uri ApiBaseUri { get; }

		private Dsn(string source, string projectId, string? path, string? secretKey, string publicKey, Uri apiBaseUri)
		{
			Source = source;
			ProjectId = projectId;
			Path = path;
			SecretKey = secretKey;
			PublicKey = publicKey;
			ApiBaseUri = apiBaseUri;
		}

		public Uri GetStoreEndpointUri()
		{
			return new Uri(ApiBaseUri, "store/");
		}

		public Uri GetEnvelopeEndpointUri()
		{
			return new Uri(ApiBaseUri, "envelope/");
		}

		public override string ToString()
		{
			return Source;
		}

		public static bool IsDisabled(string? dsn)
		{
			return "".Equals(dsn, StringComparison.OrdinalIgnoreCase);
		}

		public static Dsn Parse(string dsn)
		{
			Uri uri = new Uri(dsn);
			if (string.IsNullOrWhiteSpace(uri.UserInfo))
			{
				throw new ArgumentException("Invalid DSN: No public key provided.");
			}
			string[] array = uri.UserInfo.Split(new char[1] { ':' });
			string text = array[0];
			if (string.IsNullOrWhiteSpace(text))
			{
				throw new ArgumentException("Invalid DSN: No public key provided.");
			}
			string secretKey = ((array.Length > 1) ? array[1] : null);
			string text2 = uri.AbsolutePath.Substring(0, uri.AbsolutePath.LastIndexOf('/'));
			string absoluteUri = uri.AbsoluteUri;
			int num = uri.AbsoluteUri.LastIndexOf('/') + 1;
			string text3 = absoluteUri.Substring(num, absoluteUri.Length - num);
			if (string.IsNullOrWhiteSpace(text3))
			{
				throw new ArgumentException("Invalid DSN: A Project Id is required.");
			}
			Uri uri2 = new UriBuilder
			{
				Scheme = uri.Scheme,
				Host = uri.DnsSafeHost,
				Port = uri.Port,
				Path = text2 + "/api/" + text3 + "/"
			}.Uri;
			return new Dsn(dsn, text3, text2, secretKey, text, uri2);
		}

		public static Dsn? TryParse(string? dsn)
		{
			if (string.IsNullOrWhiteSpace(dsn))
			{
				return null;
			}
			try
			{
				return Parse(dsn);
			}
			catch
			{
				return null;
			}
		}
	}
}
