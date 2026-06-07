using UnityEngine.Events;

namespace M4.Session
{
	public interface IPlatform
	{
		bool ItIsInitialized { get; }

		bool ItHasDefaultUser { get; }

		bool ItHandlesTextInput { get; }

		float MinimumSaveInterval => 5f;

		void Initialize();

		void OnStart();

		void OnUpdate();

		void OnQuit();

		void RequestUser(UnityAction<UserRequestResult, IUser> callback);

		IUser ChangeUser(IUser user);

		void SaveSettings(object settings);
	}
}
