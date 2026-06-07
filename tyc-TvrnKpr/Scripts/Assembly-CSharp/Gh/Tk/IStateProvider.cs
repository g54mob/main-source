using System.Collections.Generic;

namespace Gh.Tk
{
	public interface IStateProvider
	{
		List<Tuple<string, int>> TweenKeys { get; }

		T GetStateVariable<T>(string key, T fallback);

		T GetOrSetStateVariable<T>(string key, T fallback);

		void SetStateVariable<T>(string key, T value);
	}
}
