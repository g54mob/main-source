using UnityEngine.Events;

namespace M4.Session
{
	public interface IStatistic
	{
		bool IsInitialized { get; }

		void Initialize(IUser player, UnityAction initialize_callback);
	}
}
