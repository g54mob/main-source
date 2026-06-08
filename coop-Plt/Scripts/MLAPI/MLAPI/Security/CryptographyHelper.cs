using System.Security.Cryptography.X509Certificates;

namespace MLAPI.Security
{
	public static class CryptographyHelper
	{
		public delegate bool VerifyCertificateDelegate(X509Certificate2 certificate, string hostname);

		public static VerifyCertificateDelegate OnValidateCertificateCallback;

		public static bool VerifyCertificate(X509Certificate2 certificate, string hostname)
		{
			if (OnValidateCertificateCallback != null)
			{
				return OnValidateCertificateCallback(certificate, hostname);
			}
			if (certificate.Verify())
			{
				if (!(hostname == certificate.GetNameInfo(X509NameType.DnsName, forIssuer: false)))
				{
					return hostname == "127.0.0.1";
				}
				return true;
			}
			return false;
		}

		public static byte[] GetClientKey(ulong clientId)
		{
			if (NetworkingManager.Singleton.IsServer)
			{
				if (NetworkingManager.Singleton.ConnectedClients.ContainsKey(clientId))
				{
					return NetworkingManager.Singleton.ConnectedClients[clientId].AesKey;
				}
				if (NetworkingManager.Singleton.PendingClients.ContainsKey(clientId))
				{
					return NetworkingManager.Singleton.PendingClients[clientId].AesKey;
				}
				return null;
			}
			return null;
		}

		public static byte[] GetServerKey()
		{
			if (NetworkingManager.Singleton.IsServer)
			{
				return null;
			}
			return NetworkingManager.Singleton.clientAesKey;
		}

		internal static bool ConstTimeArrayEqual(byte[] a, byte[] b)
		{
			if (a.Length != b.Length)
			{
				return false;
			}
			int num = a.Length;
			int num2 = 0;
			while (num != 0)
			{
				num--;
				num2 |= a[num] ^ b[num];
			}
			return num2 == 0;
		}
	}
}
