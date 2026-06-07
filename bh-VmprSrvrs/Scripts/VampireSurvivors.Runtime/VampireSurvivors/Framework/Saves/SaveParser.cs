using System.Collections.Generic;
using Newtonsoft.Json;
using VampireSurvivors.Data;

namespace VampireSurvivors.Framework.Saves
{
	public class SaveParser
	{
		private JsonTextReader _reader;

		private PlayerOptionsData _pod;

		public static PlayerOptionsData Parse(string data)
		{
			return null;
		}

		public static PlayerOptionsData ParseAdventureData(JsonTextReader reader)
		{
			return null;
		}

		public PlayerOptionsData ParsePod(string data)
		{
			return null;
		}

		public PlayerOptionsData ParseAdventurePod(JsonTextReader reader)
		{
			return null;
		}

		private void PostParseFixes()
		{
		}

		private void ParseProp(string propName)
		{
		}

		private T ParseEnum<T>(object value)
		{
			return default(T);
		}

		private T ParseIntToEnum<T>(object value)
		{
			return default(T);
		}

		private bool ParseBool(object value)
		{
			return false;
		}

		private int ParseInt(object value)
		{
			return 0;
		}

		private uint ParseUInt(object value)
		{
			return 0u;
		}

		private float ParseFloat(object value)
		{
			return 0f;
		}

		private double ParseDouble(object value)
		{
			return 0.0;
		}

		private string ParseString(object value)
		{
			return null;
		}

		private void ParseEnumArray<T>(List<T> target, bool allowDuplicate = false)
		{
		}

		private void ParseUIntArray(List<uint> target)
		{
		}

		private void ParseObjectEnumInt<T>(Dictionary<T, int> target)
		{
		}

		private void ParseObjectEnumEnum<T1, T2>(Dictionary<T1, T2> target)
		{
		}

		private void ParseObjectEnumEnumArray<T1, T2>(Dictionary<T1, List<T2>> target, bool allowDuplicate = false)
		{
		}

		private void ParseCharacterEggData()
		{
		}

		private void ParseCharacterStageData()
		{
		}

		private void saveDate()
		{
		}

		private void Platform()
		{
		}

		private void SaveSyncPlatformAchievements()
		{
		}

		private void SaveOriginalPlatform()
		{
		}

		private void SaveTouchedPlatforms()
		{
		}

		private void itemInCollection()
		{
		}

		private void itemInUnlocks()
		{
		}

		private void itemInSecrets()
		{
		}

		private void SelectedCharacter()
		{
		}

		private void SelectedStage()
		{
		}

		private void SelectedHyper()
		{
		}

		private void SelectedHurry()
		{
		}

		private void AcceptedEULA()
		{
		}

		private void SelectedMazzo()
		{
		}

		private void SelectedLimitBreak()
		{
		}

		private void SelectedInverse()
		{
		}

		private void SelectedReapers()
		{
		}

		private void SelectedGoldenEggs()
		{
		}

		private void SelectedSharePassives()
		{
		}

		private void SelectedArcana()
		{
		}

		private void SelectedRandomEvents()
		{
		}

		private void SelectedRandomLevels()
		{
		}

		private void SelectedBGMSave()
		{
		}

		private void SelectedBGM()
		{
		}

		private void SelectedBGMMod()
		{
		}

		private void SelectedMaxWeapons()
		{
		}

		private void Fullscreen()
		{
		}

		private void Version()
		{
		}

		private void Coins()
		{
		}

		private void LifetimeCoins()
		{
		}

		private void TotalCoins()
		{
		}

		private void BeginnersLuck()
		{
		}

		private void RunFever()
		{
		}

		private void LifetimeSurvived()
		{
		}

		private void LifetimeHeal()
		{
		}

		private void TrainHazardEnemiesHit()
		{
		}

		private void TopLapsCarlo()
		{
		}

		private void TotalLapsCarlo()
		{
		}

		private void TopLapsHighway()
		{
		}

		private void TotalLapsHighway()
		{
		}

		private void OwO()
		{
		}

		private void CompletedHurries()
		{
		}

		private void ReducePhysics()
		{
		}

		private void ClassicMusic()
		{
		}

		private void VisuallyInvertStages()
		{
		}

		private void HideProgress()
		{
		}

		private void SoundsEnabled()
		{
		}

		private void MusicEnabled()
		{
		}

		private void SoundsVolume()
		{
		}

		private void MusicVolume()
		{
		}

		private void FlashingVFXEnabled()
		{
		}

		private void JoystickVisible()
		{
		}

		private void SelectedJoystickType()
		{
		}

		private void DamageNumbersEnabled()
		{
		}

		private void GlimmerCarouselEnabled()
		{
		}

		private void StreamSafeEnabled()
		{
		}

		private void hideXPBar()
		{
		}

		private void CheatCodeUsed()
		{
		}

		private void HasKilledTheFinalBoss()
		{
		}

		private void HasSeenFinalFireworks()
		{
		}

		private void Language()
		{
		}

		private void ShowQuitDescription()
		{
		}

		private void HideCompletedAchievements()
		{
		}

		private void PlayedRNJ()
		{
		}

		private void ShowPickups()
		{
		}

		private void ShowSmallMapIcons()
		{
		}

		private void LongestFever()
		{
		}

		private void HighestFever()
		{
		}

		private void HasUsedMirror()
		{
		}

		private void HasUsedTrumpet()
		{
		}

		private void BoughtCharacters()
		{
		}

		private void BoughtPowerups()
		{
		}

		private void CollectedWeapons()
		{
		}

		private void UnlockedWeapons()
		{
		}

		private void UnlockedCharacters()
		{
		}

		private void OpenedCoffins()
		{
		}

		private void CollectedItems()
		{
		}

		private void Achievements()
		{
		}

		private void Secrets()
		{
		}

		private void UnlockedStages()
		{
		}

		private void UnlockedHypers()
		{
		}

		private void UnlockedPowerUpRanks()
		{
		}

		private void DisabledPowerups()
		{
		}

		private void UnlockedArcanas()
		{
		}

		private void KillCount()
		{
		}

		private void PickupCount()
		{
		}

		private void DestroyedCount()
		{
		}

		private void StageCompletionLog()
		{
		}

		private void CharacterStageData()
		{
		}

		private void CharacterEnemiesKilled()
		{
		}

		private void CharacterSurvivedMinutes()
		{
		}

		private void MusicSelectionPerStage()
		{
		}

		private void checksum()
		{
		}

		private void EggData()
		{
		}

		private void Didit()
		{
		}

		private void Seals()
		{
		}

		private void SealedItems()
		{
		}

		private void SealedWeapons()
		{
		}

		private void UnlockedSkins()
		{
		}

		private void UnlockedSkinsV2()
		{
		}

		private void SelectedSkins()
		{
		}

		private void SelectedSkinsV2()
		{
		}

		private void HideAdsButtons()
		{
		}

		private void ScreenShakeEnabled()
		{
		}

		private void ControllerVibrationEnabled()
		{
		}

		private void AssignControllerToPlayer1()
		{
		}

		private void ShowPlayerIndicators()
		{
		}

		private void PermanentCoopOutlines()
		{
		}

		private void TintUISelection()
		{
		}

		private void PlayerColours()
		{
		}

		private void SequentialChestMode()
		{
		}

		private void DisableMovingBackground()
		{
		}

		private void DisableBlood()
		{
		}

		private void BorderType()
		{
		}

		private void PixelFont()
		{
		}

		private void DisplayDefangedEnemies()
		{
		}

		private void StageLighting()
		{
		}

		private void SelectedAdventureType()
		{
		}

		private void AdventureProgress()
		{
		}

		private void AdventuresSaveData()
		{
		}

		private void HasSeenAdventureReveal()
		{
		}

		private void AdventureCompletionCount()
		{
		}

		private void CollectionFilterMode()
		{
		}

		private void HideUnavailableAdventures()
		{
		}

		private void TotalAdventurePlaytime()
		{
		}

		private void AllTimeAdventurePlaytime()
		{
		}

		private void AscensionPointsAllocation()
		{
		}

		private void HasSeenAdventuresIntroTutorial()
		{
		}

		private void AdventureStars()
		{
		}

		private void HasPlayedStage3()
		{
		}

		private void CompletedAdventures()
		{
		}

		private void HasSeenMerchantTutorial()
		{
		}

		private void SeenAscensionPopups()
		{
		}

		private void HasSeenDarkanaTransition()
		{
		}

		private void HasFixedSkinIds()
		{
		}

		private void BoughtSkins()
		{
		}

		private void BanishedContentGroups()
		{
		}

		private void ContentGroupSealedItems()
		{
		}

		private void ContentGroupSealedWeapons()
		{
		}

		private void SelectedBGMPlayback()
		{
		}

		private void PlayBGMOnlyDuringRun()
		{
		}

		private void TP_FrozenShadesCount()
		{
		}

		private void TP_AxeArmorCount()
		{
		}

		private void TP_SniperCount()
		{
		}

		private void TP_PortraitsCount()
		{
		}

		private void LibraryMerchantGoldSpent()
		{
		}

		private void EME_NextBossBiome()
		{
		}

		private void WW_ZoneProgress()
		{
		}
	}
}
