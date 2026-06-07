namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.Field
{
	internal class GenericPolynomialExtensionField : IPolynomialExtensionField, IExtensionField, IFiniteField
	{
		protected readonly IFiniteField subfield;

		protected readonly IPolynomial minimalPolynomial;

		public virtual BigInteger Characteristic => null;

		public virtual int Dimension => 0;

		public virtual IFiniteField Subfield => null;

		public virtual int Degree => 0;

		public virtual IPolynomial MinimalPolynomial => null;

		internal GenericPolynomialExtensionField(IFiniteField subfield, IPolynomial polynomial)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
