namespace Novell.Directory.Ldap.Utilclass
{
	public class ReferralInfo
	{
		private LdapConnection conn;

		private LdapUrl referralUrl;

		private string[] referralList;

		public virtual LdapUrl ReferralUrl
		{
			get
			{
				return referralUrl;
			}
		}

		public virtual LdapConnection ReferralConnection
		{
			get
			{
				return conn;
			}
		}

		public virtual string[] ReferralList
		{
			get
			{
				return referralList;
			}
		}

		public ReferralInfo(LdapConnection lc, string[] refList, LdapUrl refUrl)
		{
			conn = lc;
			referralUrl = refUrl;
			referralList = refList;
		}
	}
}
