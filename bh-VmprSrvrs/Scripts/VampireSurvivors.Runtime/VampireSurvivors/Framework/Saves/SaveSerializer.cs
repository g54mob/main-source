using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using VampireSurvivors.Data;

namespace VampireSurvivors.Framework.Saves
{
	public class SaveSerializer
	{
		private StringWriter _stringWriter;

		private JsonTextWriter _writer;

		private PlayerOptionsData _pod;

		public static string Serialize(PlayerOptionsData playerOptionsData)
		{
			return null;
		}

		public string SerializePOD(PlayerOptionsData pod, string prefix = "")
		{
			return null;
		}

		private void SerializeEnumArray<T>(List<T> array, List<T> exclude = null)
		{
		}

		private void SerializeEnumArrayAsIntArray<T>(List<T> array, List<T> exclude = null)
		{
		}

		private void SerializeEnumValArray<T>(List<T> array)
		{
		}

		private void SerializeUIntArray(List<uint> array)
		{
		}

		private void SerializeObjectEnumInt<T>(Dictionary<T, int> obj)
		{
		}

		private void SerializeObjectEnumEnum<T1, T2>(Dictionary<T1, T2> obj)
		{
		}

		private void SerializeObjectEnumEnumArray<T, T2>(Dictionary<T, List<T2>> obj)
		{
		}

		private void SerializeObjectEnumIntArray<T, T2>(Dictionary<T, List<T2>> obj)
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

		private void WriteFloat(float value)
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

		private void StageLighting()
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
