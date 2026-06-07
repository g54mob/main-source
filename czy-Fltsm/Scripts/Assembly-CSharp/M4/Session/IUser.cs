using UnityEngine.Events;

namespace M4.Session
{
	public interface IUser
	{
		int Id { get; }

		string Name { get; }

		void RequestSignIn();

		void Initialize(IUserEventHandler event_handler);

		void LoadPlayerRuns(PlayerProfile playerProfile, UnityAction result_callback);

		void LoadFile(string filename, UnityAction<StorageActionResult> result_callback);

		void SaveFile(string filename, byte[] data, UnityAction<StorageActionResult> result_callback);

		void RemoveFile(string filename, UnityAction<StorageActionResult> result_callback);

		bool IsAchievementUnlocked(AchievementId achievement_id);

		void UnlockAchievement(AchievementBase achievement);

		bool OwnsDLC(PlatformId platformId);

		bool IsEarlyAccesOwner()
		{
			return true;
		}

		void Dispose();
	}
}
