namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Engines
{
	public class VmpcKsa3Engine : VmpcEngine
	{
		public override string AlgorithmName => null;

		protected override void InitKey(byte[] keyBytes, byte[] ivBytes)
		{
		}
	}
}
