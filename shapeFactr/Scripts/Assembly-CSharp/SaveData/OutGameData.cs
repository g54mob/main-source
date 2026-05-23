using System;
using System.Collections.Generic;
using UI;

namespace SaveData
{
	public class OutGameData
	{
		private const string SAVE_KEY = "OutGame";

		private const string Version000 = "0.0.0";

		private const string Version001 = "0.0.1";

		private const string Version002 = "0.0.2";

		private const string Version010 = "0.1.0";

		private const string Version020 = "0.2.0";

		private const string Version030 = "0.3.0";

		private const string Version031 = "0.3.1";

		private const string Version040 = "0.4.0";

		private const string Version041 = "0.4.1";

		private const string Version042 = "0.4.2";

		private const string Version043 = "0.4.3";

		private const string Version044 = "0.4.4";

		private const string Version045 = "0.4.5";

		private const string Version046 = "0.4.6";

		private const string Version047 = "0.4.7";

		private const string Version048 = "0.4.8";

		private const string Version049 = "0.4.9";

		private const string Version050 = "0.5.0";

		private const string Version051 = "0.5.1";

		private const string Version052 = "0.5.2";

		private const string Version053 = "0.5.3";

		public static readonly Version SaveOutGameVersion;

		public string outGameVersion;

		public bool completedIntroduction;

		public bool completedIntroTutorial;

		public bool isShowEnding;

		public bool isShowOpenLastStage;

		public bool isWaitEliminatedLastBoss;

		public eReadDirection readDirection;

		public eWriterId lobbyWriter;

		public int lobbyAscension;

		public int openMaxAscension;

		public bool lobbyFreeControlMode;

		public eChallengeId lobbyChallengeMode;

		public PlayAuthorData authorData;

		public PlayChallengeData challengeData;

		public List<eSteamAchivementId> achievementIds;

		private Dictionary<eSteamAchivementId, bool> _achieveMap;

		public PlayOutGameShopData outGameShopData;

		public PlayArchiveData archiveData;

		public List<eUnlockId> completedUnlockIds;

		public List<eUnlockId> waitUnlockIds;

		public int knowledgePoint;

		public int prevClearWave;

		public List<eTutorialSectionId> completedTutorialList;

		public List<eTipsId> completedTipsList;

		public List<eLargeTips> completedLargeTipsList;

		public List<eLargeTips> completedCollectionLargeTipsList;

		public bool isShowLongthinkBubble;

		public bool isUsedFreeControlMode;

		public bool showFreeControlLargeTips;

		[Obsolete]
		public SettingData settingData;

		[Obsolete]
		public List<eMachine> favoritePaletteData;

		[Obsolete]
		public string inputDataJson;

		public int lastReadReleaseNoteId;

		public string lastUpdate;

		public eResearchCategory prevChoiceChangeFactory;

		public bool seenEndMovie;

		public bool seenTrialClearMessage;

		public static string SaveKey => null;

		public Version OutGameVersion
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Dictionary<eSteamAchivementId, bool> AchieveMap
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool IsBroken => false;

		private bool _isBroken { get; set; }

		public void SetOutGame(bool withSave = false)
		{
		}

		public void GetOutGame()
		{
		}

		public void ResetPlayOutGameShopData()
		{
		}

		public bool CheckClearAscensionWriter(eWriterId writer, int ascension)
		{
			return false;
		}

		public bool CheckClearAscensionAllWriter(int ascension)
		{
			return false;
		}

		public bool CheckClearAscensionAnyWriter(int ascension)
		{
			return false;
		}

		public bool CheckUnlockPair(List<eUnlockId> pair)
		{
			return false;
		}

		public string GetLockText(eArchiveCategory category, string key)
		{
			return null;
		}

		public void AddKnowledgePoint(int point)
		{
		}

		public void WriteClearWaveLog(int waveCount)
		{
		}

		public void CompleteTips(eTipsId tipsId)
		{
		}

		public bool IsCompletedTips(eTipsId tipsId)
		{
			return false;
		}

		public void CompleteLargeTips(eLargeTips tipsId)
		{
		}

		public void CompleteCollectionLargeTips(eLargeTips tipsId)
		{
		}

		public bool IsCompletedLargeTips(eLargeTips tipsId)
		{
			return false;
		}

		public bool IsCompletedCollectionLargeTips(eLargeTips tipsId)
		{
			return false;
		}

		public void DisplaySingleLargeTips(eLargeTips id)
		{
		}

		[Obsolete]
		public void SetFavoritePaletteData(List<eMachine> favs)
		{
		}

		[Obsolete]
		public void SetInputData(string json)
		{
		}

		public void CompleteTutorial(eTutorialSectionId id)
		{
		}

		public void DebugCompleteTutorialAll()
		{
		}

		private void AddCollection(CollectionDialog.eCollectionPage page, int enumNumber)
		{
		}

		public void CompleteRelic(eRelic relic)
		{
		}

		public void CompleteEnemy(eEnemy enemy)
		{
		}

		public void CompleteResearch(eResearchCategory research)
		{
		}

		public void CompleteMachine(eMachine machine)
		{
		}

		public void CompleteLuggage(eLuggage luggage)
		{
		}

		public void CompleteCustomLuggage(eLuggage luggage)
		{
		}

		public void RegisterAchieveSave(eSteamAchivementId id)
		{
		}

		public void SyncSteamAcheivement()
		{
		}

		public void SetAchivement(eSteamAchivementId id)
		{
		}

		public void AchieveCheckClearTutorial()
		{
		}

		public void AchieveCheckCollectorResearch()
		{
		}

		public void AchieveCheckKnowledgeCollection()
		{
		}

		public void SettingAchievementMap()
		{
		}

		private void UpdateCollection(CollectionDialog.eCollectionPage page)
		{
		}

		public void LevelUpLuggage(eLuggage luggage, int level)
		{
		}

		public void ManufactureLuggage(eLuggage luggage)
		{
		}

		public void EliminatedEnemy(eEnemy enemy)
		{
		}

		public void UpdateLastReadReleaseNote()
		{
		}

		public int GetLatestReleaseNoteId()
		{
			return 0;
		}

		public bool IsUpdateReleaseNote()
		{
			return false;
		}

		public bool UnreadReleaseNote()
		{
			return false;
		}

		public void ValidateKnowledgeData(OutGameData saveData)
		{
		}

		public void OpenAscensionCheck(ref OutGameData saveData)
		{
		}

		public void OpenUnlockCheck(ref OutGameData saveData)
		{
		}
	}
}
