using Newtonsoft.Json.Linq;

namespace ScriptHelpers
{
	public interface ISaveable
	{
		JObject SaveState();

		void LoadState(JObject state);
	}
}
