using System.Collections;

namespace Novell.Directory.Ldap.Utilclass
{
	public class BindProperties
	{
		private int version = 3;

		private string dn;

		private string method;

		private bool anonymous;

		private Hashtable bindProperties;

		private object bindCallbackHandler;

		public virtual int ProtocolVersion
		{
			get
			{
				return version;
			}
		}

		public virtual string AuthenticationDN
		{
			get
			{
				return dn;
			}
		}

		public virtual string AuthenticationMethod
		{
			get
			{
				return method;
			}
		}

		public virtual Hashtable SaslBindProperties
		{
			get
			{
				return bindProperties;
			}
		}

		public virtual object SaslCallbackHandler
		{
			get
			{
				return bindCallbackHandler;
			}
		}

		public virtual bool Anonymous
		{
			get
			{
				return anonymous;
			}
		}

		public BindProperties(int version, string dn, string method, bool anonymous, Hashtable bindProperties, object bindCallbackHandler)
		{
			this.version = version;
			this.dn = dn;
			this.method = method;
			this.anonymous = anonymous;
			this.bindProperties = bindProperties;
			this.bindCallbackHandler = bindCallbackHandler;
		}
	}
}
