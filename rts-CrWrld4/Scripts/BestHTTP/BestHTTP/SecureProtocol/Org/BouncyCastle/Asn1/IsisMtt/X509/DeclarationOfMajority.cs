namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.IsisMtt.X509
{
	public class DeclarationOfMajority : Asn1Encodable, IAsn1Choice
	{
		public enum Choice
		{
			NotYoungerThan = 0,
			FullAgeAtCountry = 1,
			DateOfBirth = 2
		}

		private readonly Asn1TaggedObject declaration;

		public Choice Type => default(Choice);

		public virtual int NotYoungerThan => 0;

		public virtual Asn1Sequence FullAgeAtCountry => null;

		public virtual DerGeneralizedTime DateOfBirth => null;

		public DeclarationOfMajority(int notYoungerThan)
		{
		}

		public DeclarationOfMajority(bool fullAge, string country)
		{
		}

		public DeclarationOfMajority(DerGeneralizedTime dateOfBirth)
		{
		}

		public static DeclarationOfMajority GetInstance(object obj)
		{
			return null;
		}

		private DeclarationOfMajority(Asn1TaggedObject o)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
