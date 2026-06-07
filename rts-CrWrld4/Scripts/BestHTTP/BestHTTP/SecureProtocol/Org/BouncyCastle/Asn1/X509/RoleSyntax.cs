namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class RoleSyntax : Asn1Encodable
	{
		private readonly GeneralNames roleAuthority;

		private readonly GeneralName roleName;

		public GeneralNames RoleAuthority => null;

		public GeneralName RoleName => null;

		public static RoleSyntax GetInstance(object obj)
		{
			return null;
		}

		public RoleSyntax(GeneralNames roleAuthority, GeneralName roleName)
		{
		}

		public RoleSyntax(GeneralName roleName)
		{
		}

		public RoleSyntax(string roleName)
		{
		}

		private RoleSyntax(Asn1Sequence seq)
		{
		}

		public string GetRoleNameAsString()
		{
			return null;
		}

		public string[] GetRoleAuthorityAsString()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
