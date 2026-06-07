using Motorways;

public interface IExtendedUserProfile : IJsonSerializableSaveData, IStorable
{
	int Version { get; }

	Player Player { get; set; }

	int AvatarColorIndex { get; set; }

	int AvatarIconIndex { get; set; }

	iCloudProvenance iCloudProvenance { get; set; }

	int LastTimeDailyChallengeSeen { get; set; }

	int LastTimeWeeklyChallengeSeen { get; set; }

	bool HasSeenNewContent(string newContentId);

	void SetNewContentSeen(string newContentId);

	void ClearNewContentSeen(string specificContent = null);

	GameMode GetSelectedModeForMap(string mapId);

	void SetSelectedGameModeForMap(string mapId, GameMode gameMode);
}
