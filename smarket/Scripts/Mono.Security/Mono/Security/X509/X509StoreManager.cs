namespace Mono.Security.X509
{
	public sealed class X509StoreManager
	{
		private static string _userPath;

		private static string _localMachinePath;

		private static string _newUserPath;

		private static string _newLocalMachinePath;

		private static X509Stores _userStore;

		private static X509Stores _machineStore;

		internal static string CurrentUserPath => null;

		internal static string LocalMachinePath => null;

		internal static string NewCurrentUserPath => null;

		internal static string NewLocalMachinePath => null;

		public static X509Stores CurrentUser => null;

		public static X509Stores LocalMachine => null;

		public static X509CertificateCollection TrustedRootCertificates => null;
	}
}
