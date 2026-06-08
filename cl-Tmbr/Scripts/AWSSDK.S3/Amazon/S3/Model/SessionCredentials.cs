using System;
using Amazon.Runtime.Internal;

namespace Amazon.S3.Model
{
	public class SessionCredentials
	{
		private string _accessKeyId;

		private DateTime? _expiration;

		private string _secretAccessKey;

		private string _sessionToken;

		[AWSProperty(Required = true)]
		public string AccessKeyId
		{
			get
			{
				return _accessKeyId;
			}
			set
			{
				_accessKeyId = value;
			}
		}

		[AWSProperty(Required = true)]
		public DateTime? Expiration
		{
			get
			{
				return _expiration;
			}
			set
			{
				_expiration = value;
			}
		}

		[AWSProperty(Required = true, Sensitive = true)]
		public string SecretAccessKey
		{
			get
			{
				return _secretAccessKey;
			}
			set
			{
				_secretAccessKey = value;
			}
		}

		[AWSProperty(Required = true, Sensitive = true)]
		public string SessionToken
		{
			get
			{
				return _sessionToken;
			}
			set
			{
				_sessionToken = value;
			}
		}

		internal bool IsSetAccessKeyId()
		{
			return _accessKeyId != null;
		}

		internal bool IsSetExpiration()
		{
			return _expiration.HasValue;
		}

		internal bool IsSetSecretAccessKey()
		{
			return _secretAccessKey != null;
		}

		internal bool IsSetSessionToken()
		{
			return _sessionToken != null;
		}
	}
}
