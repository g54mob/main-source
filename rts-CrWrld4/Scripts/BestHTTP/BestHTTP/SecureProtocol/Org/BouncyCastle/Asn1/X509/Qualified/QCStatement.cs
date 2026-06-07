namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509.Qualified
{
	public class QCStatement : Asn1Encodable
	{
		private readonly DerObjectIdentifier qcStatementId;

		private readonly Asn1Encodable qcStatementInfo;

		public DerObjectIdentifier StatementId => null;

		public Asn1Encodable StatementInfo => null;

		public static QCStatement GetInstance(object obj)
		{
			return null;
		}

		private QCStatement(Asn1Sequence seq)
		{
		}

		public QCStatement(DerObjectIdentifier qcStatementId)
		{
		}

		public QCStatement(DerObjectIdentifier qcStatementId, Asn1Encodable qcStatementInfo)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
