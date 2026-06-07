using System;
using System.Collections.Generic;
using Factory;

public interface IActivePlayer
{
	string Id { get; }

	bool IsVibrationEnabled { get; set; }

	bool HasAvatar { get; }

	int AvatarColorIndex { get; set; }

	int AvatarIconIndex { get; set; }

	LocaleDatabase.LocaleId LocaleId { get; set; }

	bool SyncToCloud { get; set; }

	bool HasLocalSavedGame { get; }

	IGameJournalSave LocalSavedGame { get; set; }

	bool IsChallengeRemindersEnabledSetting { get; set; }

	bool IsContentRemindersEnabledSetting { get; set; }

	bool HasForeignSavedGames { get; }

	IEnumerable<IGameJournalSave> ForeignSavedGames { get; }

	Player Player { get; }

	bool HasActivePlayer { get; }

	ILegacyUserProfile UserProfile { get; }

	IExtendedUserProfile ExtendedUserProfile { get; }

	IDeviceSettings DeviceSettings { get; }

	IScope Scope { get; }

	event Action DataChanged;

	event Action SavedGamesChanged;

	event PlayedChangedEventHandler PlayerChanged;

	bool IsAchievementCompleted(AchievementDefinition achievementDefinition);

	void CompleteAchievement(AchievementDefinition achievementDefinition, bool showNotification);

	bool HasSeenNewContent(string newContentId);

	void SetNewContentSeen(string newContentId);

	void ClearNewContentSeen(string specificContent = null);

	Dictionary<string, string> GetDeviceControlMapping(string deviceName);

	void SetDeviceControlMappings(string deviceName, Dictionary<string, string> deviceControlMappings);

	void AddForeignSavedGame(IGameJournalSave newForeignSavedGame);

	IGameJournalSave GetForeignSavedGame(string gameId);

	void RemoveSavedGame(IGameJournalSave savedGame);

	void Touch();

	void ActivatePlayer(Player newActivePlayer);
}
