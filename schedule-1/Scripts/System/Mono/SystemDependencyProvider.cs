namespace Mono
{
	internal class SystemDependencyProvider : ISystemDependencyProvider
	{
		private static SystemDependencyProvider instance;

		private static object syncRoot;

		public static SystemDependencyProvider Instance => null;

		ISystemCertificateProvider ISystemDependencyProvider.CertificateProvider => null;

		public SystemCertificateProvider CertificateProvider { get; }

		public X509PalImpl X509Pal => null;

		internal static void Initialize()
		{
		}

		private SystemDependencyProvider()
		{
		}
	}
}
