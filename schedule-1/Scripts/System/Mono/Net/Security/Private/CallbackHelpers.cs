using System.Net.Security;
using Mono.Security.Interface;

namespace Mono.Net.Security.Private
{
	internal static class CallbackHelpers
	{
		internal static MonoRemoteCertificateValidationCallback PublicToMono(RemoteCertificateValidationCallback callback)
		{
			return null;
		}

		internal static LocalCertSelectionCallback MonoToInternal(MonoLocalCertificateSelectionCallback callback)
		{
			return null;
		}
	}
}
