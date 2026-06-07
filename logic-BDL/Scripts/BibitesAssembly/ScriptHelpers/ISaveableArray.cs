using Newtonsoft.Json.Linq;

namespace ScriptHelpers
{
	public interface ISaveableArray
	{
		bool HasData();

		JArray SaveState();

		void LoadState(JArray jArray);
	}
}
