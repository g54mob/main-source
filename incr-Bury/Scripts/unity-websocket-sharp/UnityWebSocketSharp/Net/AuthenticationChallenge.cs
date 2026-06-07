using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Text;

namespace UnityWebSocketSharp.Net
{
	internal class AuthenticationChallenge
	{
		private NameValueCollection _parameters;

		private AuthenticationSchemes _scheme;

		internal NameValueCollection Parameters => _parameters;

		public string Algorithm => _parameters["algorithm"];

		public string Domain => _parameters["domain"];

		public string Nonce => _parameters["nonce"];

		public string Opaque => _parameters["opaque"];

		public string Qop => _parameters["qop"];

		public string Realm => _parameters["realm"];

		public AuthenticationSchemes Scheme => _scheme;

		public string Stale => _parameters["stale"];

		private AuthenticationChallenge(AuthenticationSchemes scheme, NameValueCollection parameters)
		{
			_scheme = scheme;
			_parameters = parameters;
		}

		internal AuthenticationChallenge(AuthenticationSchemes scheme, string realm)
			: this(scheme, new NameValueCollection())
		{
			_parameters["realm"] = realm;
			if (scheme == AuthenticationSchemes.Digest)
			{
				_parameters["nonce"] = CreateNonceValue();
				_parameters["algorithm"] = "MD5";
				_parameters["qop"] = "auth";
			}
		}

		internal static AuthenticationChallenge CreateBasicChallenge(string realm)
		{
			return new AuthenticationChallenge(AuthenticationSchemes.Basic, realm);
		}

		internal static AuthenticationChallenge CreateDigestChallenge(string realm)
		{
			return new AuthenticationChallenge(AuthenticationSchemes.Digest, realm);
		}

		internal static string CreateNonceValue()
		{
			RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
			byte[] array = new byte[16];
			randomNumberGenerator.GetBytes(array);
			StringBuilder stringBuilder = new StringBuilder(32);
			byte[] array2 = array;
			foreach (byte b in array2)
			{
				stringBuilder.Append(b.ToString("x2"));
			}
			return stringBuilder.ToString();
		}

		internal static AuthenticationChallenge Parse(string value)
		{
			string[] array = value.Split(new char[1] { ' ' }, 2);
			if (array.Length != 2)
			{
				return null;
			}
			string text = array[0].ToLower();
			if (text == "basic")
			{
				NameValueCollection parameters = ParseParameters(array[1]);
				return new AuthenticationChallenge(AuthenticationSchemes.Basic, parameters);
			}
			if (text == "digest")
			{
				NameValueCollection parameters2 = ParseParameters(array[1]);
				return new AuthenticationChallenge(AuthenticationSchemes.Digest, parameters2);
			}
			return null;
		}

		internal static NameValueCollection ParseParameters(string value)
		{
			NameValueCollection nameValueCollection = new NameValueCollection();
			foreach (string item in value.SplitHeaderValue(','))
			{
				int num = item.IndexOf('=');
				string name = ((num > 0) ? item.Substring(0, num).Trim() : null);
				string value2 = ((num < 0) ? item.Trim().Trim('"') : ((num < item.Length - 1) ? item.Substring(num + 1).Trim().Trim('"') : string.Empty));
				nameValueCollection.Add(name, value2);
			}
			return nameValueCollection;
		}

		internal string ToBasicString()
		{
			return string.Format("Basic realm=\"{0}\"", _parameters["realm"]);
		}

		internal string ToDigestString()
		{
			StringBuilder stringBuilder = new StringBuilder(128);
			string text = _parameters["domain"];
			string arg = _parameters["realm"];
			string text2 = _parameters["nonce"];
			if (text != null)
			{
				stringBuilder.AppendFormat("Digest realm=\"{0}\", domain=\"{1}\", nonce=\"{2}\"", arg, text, text2);
			}
			else
			{
				stringBuilder.AppendFormat("Digest realm=\"{0}\", nonce=\"{1}\"", arg, text2);
			}
			string text3 = _parameters["opaque"];
			if (text3 != null)
			{
				stringBuilder.AppendFormat(", opaque=\"{0}\"", text3);
			}
			string text4 = _parameters["stale"];
			if (text4 != null)
			{
				stringBuilder.AppendFormat(", stale={0}", text4);
			}
			string text5 = _parameters["algorithm"];
			if (text5 != null)
			{
				stringBuilder.AppendFormat(", algorithm={0}", text5);
			}
			string text6 = _parameters["qop"];
			if (text6 != null)
			{
				stringBuilder.AppendFormat(", qop=\"{0}\"", text6);
			}
			return stringBuilder.ToString();
		}

		public override string ToString()
		{
			if (_scheme == AuthenticationSchemes.Basic)
			{
				return ToBasicString();
			}
			if (_scheme == AuthenticationSchemes.Digest)
			{
				return ToDigestString();
			}
			return string.Empty;
		}
	}
}
