using CTS.Core;

namespace CTS
{
	public interface IPlatformLibrary
	{
		bool IsDLCInstalled(StringKey dlcName);

		bool TryAuthenticateGame();
	}
}
