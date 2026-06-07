namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Engines
{
	public class XSalsa20Engine : Salsa20Engine
	{
		public override string AlgorithmName => null;

		protected override int NonceSize => 0;

		protected override void SetKey(byte[] keyBytes, byte[] ivBytes)
		{
		}
	}
}
