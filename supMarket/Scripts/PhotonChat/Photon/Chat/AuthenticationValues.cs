using System.Collections.Generic;

namespace Photon.Chat
{
	public class AuthenticationValues
	{
		private CustomAuthenticationType authType;

		public CustomAuthenticationType AuthType
		{
			get
			{
				return default(CustomAuthenticationType);
			}
			set
			{
			}
		}

		public string AuthGetParameters { get; set; }

		public object AuthPostData { get; private set; }

		public object Token { get; protected internal set; }

		public string UserId { get; set; }

		public AuthenticationValues()
		{
		}

		public AuthenticationValues(string userId)
		{
		}

		public virtual void SetAuthPostData(string stringData)
		{
		}

		public virtual void SetAuthPostData(byte[] byteData)
		{
		}

		public virtual void SetAuthPostData(Dictionary<string, object> dictData)
		{
		}

		public virtual void AddAuthParameter(string key, string value)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public AuthenticationValues CopyTo(AuthenticationValues copy)
		{
			return null;
		}
	}
}
