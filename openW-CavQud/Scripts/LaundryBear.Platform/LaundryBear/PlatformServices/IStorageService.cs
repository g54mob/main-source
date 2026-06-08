using System.Collections;

namespace LaundryBear.PlatformServices
{
	public interface IStorageService
	{
		bool SupportsPlayerPrefs { get; }

		bool RequiresAssociatedUser { get; }

		void InitializePlayerPrefs();

		IEnumerator InitializePlayerPrefsAsync();

		string Combine(params string[] paths);

		void OpenOrCreate(string drive, OnCreateStorage callback);

		void OpenOrCreate(IUser user, string name, OnCreateStorage callback);
	}
}
