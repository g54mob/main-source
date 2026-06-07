using Rewired.Data;
using Rewired.Platforms;

namespace Rewired.Utils.Interfaces
{
	public interface IExternalInputManager
	{
		object Initialize(Platform platform, ConfigVars configVars);

		void Deinitialize();
	}
}
