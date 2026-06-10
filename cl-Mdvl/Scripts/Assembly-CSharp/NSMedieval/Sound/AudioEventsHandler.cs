using System;
using System.Collections.Generic;
using System.Linq;
using FMOD;
using FMOD.Studio;
using FMODUnity;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.GameEventSystem;
using NSMedieval.GameEventSystem.Events;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Managers.Selection;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Resources;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.Utils.Pool;
using NSMedieval.Village;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.Sound
{
	public class AudioEventsHandler : MonoBehaviour, IObserver
	{
		private enum MusicState
		{
			None = 0,
			Home = 1,
			Gameplay = 2,
			Combat = 3
		}

		private AudioManager audioManager;

		private const string HomeAmbiance = "HomeSceneAmbience";

		private const string DefaultAmbience = "DefaultAmbience";

		private const string GameplayList = "GameplayList";

		private const string CombatList = "CombatPlaylist";

		private const string HomePlaylist = "HomePlaylist";

		private MusicState musicState;

		private MusicState targetMusicState;

		private float lastDrag;

		private const string WaterfallEvent = "Waterfall";

		private readonly Dictionary<int, EventInstance> waterfallEvents = new Dictionary<int, EventInstance>();

		private const bool WaterfallDebug = false;

		private WaterManager WaterManager => VillageManager.ActiveVillage.Map.WaterManager;

		private void Start()
		{
			audioManager = MonoSingleton<AudioManager>.Instance;
			MonoSingleton<LoadingController>.Instance.HomeSceneLoadedEvent += OnHomeSceneLoadedEvent;
			MonoSingleton<LoadingController>.Instance.LoadingSceneLoadedEvent += OnLoadingSceneLoadedEvent;
			MonoSingleton<LoadingController>.Instance.MainSceneLoadedEvent += OnMainSceneLoadedEvent;
		}

		private void OnHomeSceneStart()
		{
			if (!MonoSingleton<GlobalSaveController>.Instance.IsSecondMapTransition)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(52, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioEventsHandler.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("OnHomeSceneStart music: ");
					messageBuilder.AppendFormatted(musicState);
					messageBuilder.AppendLiteral(", second map in transition: ");
					messageBuilder.AppendFormatted(MonoSingleton<GlobalSaveController>.Instance.IsSecondMapTransition);
				}
				Log.Info(messageBuilder);
				if (RuntimeManager.IsInitialized)
				{
					MonoSingleton<MixerSnapshotManager>.Instance.ActivateSnapshot(Snapshot.None);
					audioManager.StartEventInstance("HomeSceneAmbience");
					SwitchMusic(MusicState.Home, 0f, 1f);
				}
			}
		}

		private void OnLoadingSceneStart()
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(65, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioEventsHandler.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("OnLoadingSceneStart music: ");
				messageBuilder.AppendFormatted(musicState);
				messageBuilder.AppendLiteral(", target: ");
				messageBuilder.AppendFormatted(targetMusicState);
				messageBuilder.AppendLiteral(", second map in transition: ");
				messageBuilder.AppendFormatted(MonoSingleton<GlobalSaveController>.Instance.IsSecondMapTransition);
			}
			Log.Info(messageBuilder);
			if (targetMusicState == MusicState.Gameplay || targetMusicState == MusicState.Combat)
			{
				SwitchMusic(MusicState.None, 0f, 0f);
			}
			MonoSingleton<MixerSnapshotManager>.Instance.ActivateSnapshot(Snapshot.LoadingSnapshot);
			audioManager.StopEventInstance("HomeSceneAmbience", FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
			audioManager.StopEventInstance("DefaultAmbience", FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
		}

		private void OnGameplayStart(bool started)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(52, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioEventsHandler.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("OnGameplayStart ");
				messageBuilder.AppendFormatted(started);
				messageBuilder.AppendLiteral(" music: ");
				messageBuilder.AppendFormatted(musicState);
				messageBuilder.AppendLiteral(", second map in transition: ");
				messageBuilder.AppendFormatted(MonoSingleton<GlobalSaveController>.Instance.IsSecondMapTransition);
			}
			Log.Info(messageBuilder);
			if (!started)
			{
				return;
			}
			MonoSingleton<ConstructionController>.Instance.ShowFoundationEvent += OnShowFoundation;
			MonoSingleton<ConstructionController>.Instance.BlueprintPlacedEvent += OnBuildablePlaced;
			MonoSingleton<ConstructionController>.Instance.ConstructionCompletedEvent += OnConstructionCompleted;
			WaterEventSubscribe();
			MonoSingleton<MixerSnapshotManager>.Instance.ActivateSnapshot(Snapshot.None);
			SwitchMusic(MusicState.None, 0f, 0f);
			AmbienceInitOnLoad();
			Dictionary<string, float> parameters = new Dictionary<string, float> { 
			{
				"PlaylistPause",
				MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.PlaylistPause ? 1 : 0
			} };
			UpdateGameplayListParameters(parameters);
			MonoSingleton<TaskController>.Instance.WaitForUnscaled(2f).Then(delegate
			{
				if (IsEnemyOnTheMap())
				{
					SwitchCombatPhase(3);
				}
				else
				{
					SwitchMusic(MusicState.Gameplay, 0f, 0f);
				}
			});
		}

		private void OnHomeSceneLoadedEvent()
		{
			OnHomeSceneStart();
			if (MonoSingleton<UIController>.IsInstantiated())
			{
				MonoSingleton<UIController>.Instance.GameStartedEvent -= OnGameplayStart;
			}
			if (MonoSingleton<RtsCamera>.IsInstantiated())
			{
				MonoSingleton<RtsCamera>.Instance.CameraUpdateEvent -= OnCameraUpdate;
			}
			if (MonoSingleton<WorldTimeManager>.IsInstantiated())
			{
				MonoSingleton<WorldTimeManager>.Instance.SeasonUpdateEvent -= OnSeasonChange;
			}
			if (MonoSingleton<WeatherManager>.IsInstantiated())
			{
				MonoSingleton<WeatherManager>.Instance.DayStartEvent -= OnDayStart;
				MonoSingleton<WeatherManager>.Instance.NightStartEvent -= OnNightStart;
			}
			if (MonoSingleton<ConstructionController>.IsInstantiated())
			{
				MonoSingleton<ConstructionController>.Instance.LockStateChangedEvent -= BuildableLockStateChange;
				MonoSingleton<ConstructionController>.Instance.ShowFoundationEvent -= OnShowFoundation;
				MonoSingleton<ConstructionController>.Instance.BlueprintPlacedEvent -= OnBuildablePlaced;
				MonoSingleton<ConstructionController>.Instance.ConstructionCompletedEvent -= OnConstructionCompleted;
			}
			if (MonoSingleton<WarningMessageController>.IsInstantiated())
			{
				MonoSingleton<WarningMessageController>.Instance.MessageAlertEvent -= OnShowWarningMessage;
			}
			if (MonoSingleton<BlackBarMessageController>.IsInstantiated())
			{
				MonoSingleton<BlackBarMessageController>.Instance.MessageEvent -= OnShowBlackBarMessage;
				MonoSingleton<BlackBarMessageController>.Instance.ClickableMessageEvent -= OnShowBlackBarClickableMessage;
			}
			if (MonoSingleton<NSMedieval.GameEventSystem.GameEventSystem>.IsInstantiated())
			{
				NSMedieval.GameEventSystem.GameEventSystem instance = MonoSingleton<NSMedieval.GameEventSystem.GameEventSystem>.Instance;
				instance.EventStart = (Action<GameEventInstance>)Delegate.Remove(instance.EventStart, new Action<GameEventInstance>(OnGameEventStart));
			}
			if (MonoSingleton<NPCController>.IsInstantiated())
			{
				MonoSingleton<NPCController>.Instance.OnNPCChanged -= OnNpcChanged;
				MonoSingleton<NPCController>.Instance.OnNPCDiedEvent -= OnNpcDied;
				MonoSingleton<NPCController>.Instance.LeavingMapEvent -= OnEnemyLeft;
			}
			if (MonoSingleton<OptionsController>.IsInstantiated())
			{
				MonoSingleton<OptionsController>.Instance.PlaylistPauseChangeEvent -= UpdateGameplayListParameters;
			}
			if (MonoSingleton<RaidController>.IsInstantiated())
			{
				MonoSingleton<RaidController>.Instance.RaidSpawnedEvent -= OnRaidSpawn;
				MonoSingleton<RaidController>.Instance.RaidAttackEngageEvent -= OnRaidEngage;
				MonoSingleton<RaidController>.Instance.RaidEndedEvent -= OnRaidEnd;
			}
			if (MonoSingleton<ResourcePileController>.IsInstantiated())
			{
				MonoSingleton<ResourcePileController>.Instance.SpawnPileEvent -= OnSpawnPile;
			}
			if (MonoSingleton<GlobalShaderVariables>.IsInstantiated())
			{
				MonoSingleton<GlobalShaderVariables>.Instance.EnvironmentUpdateEvent -= OnEnvironmentUpdate;
			}
			if (MonoSingleton<SelectionManager>.IsInstantiated())
			{
				MonoSingleton<SelectionManager>.Instance.ZoneSelectionDrag -= OnZoneSelectionDrag;
				MonoSingleton<SelectionManager>.Instance.ZoneSelectionPlace -= OnZoneSelectionPlace;
			}
			if (MonoSingleton<CombatController>.IsInstantiated())
			{
				MonoSingleton<CombatController>.Instance.DamageTakenEvent -= OnAgentDamageTaken;
			}
			if (MonoSingleton<FactionsController>.IsInstantiated())
			{
				MonoSingleton<FactionsController>.Instance.FriendlinessChangedEvent -= OnFactionFriendlinessChanged;
			}
			if (MonoSingleton<GameSpeedManager>.IsInstantiated())
			{
				MonoSingleton<GameSpeedManager>.Instance.UpdateTimeScaleUIEvent -= OnChangeTimeScale;
			}
		}

		private void OnLoadingSceneLoadedEvent()
		{
			OnLoadingSceneStart();
		}

		private void OnMainSceneLoadedEvent()
		{
			MonoSingleton<UIController>.Instance.GameStartedEvent += OnGameplayStart;
			MonoSingleton<RtsCamera>.Instance.CameraUpdateEvent += OnCameraUpdate;
			MonoSingleton<WorldTimeManager>.Instance.SeasonUpdateEvent += OnSeasonChange;
			MonoSingleton<WeatherManager>.Instance.DayStartEvent += OnDayStart;
			MonoSingleton<WeatherManager>.Instance.NightStartEvent += OnNightStart;
			MonoSingleton<GlobalShaderVariables>.Instance.EnvironmentUpdateEvent += OnEnvironmentUpdate;
			MonoSingleton<WarningMessageController>.Instance.MessageAlertEvent += OnShowWarningMessage;
			MonoSingleton<BlackBarMessageController>.Instance.MessageEvent += OnShowBlackBarMessage;
			MonoSingleton<BlackBarMessageController>.Instance.ClickableMessageEvent += OnShowBlackBarClickableMessage;
			NSMedieval.GameEventSystem.GameEventSystem instance = MonoSingleton<NSMedieval.GameEventSystem.GameEventSystem>.Instance;
			instance.EventStart = (Action<GameEventInstance>)Delegate.Combine(instance.EventStart, new Action<GameEventInstance>(OnGameEventStart));
			MonoSingleton<RaidController>.Instance.RaidSpawnedEvent += OnRaidSpawn;
			MonoSingleton<RaidController>.Instance.RaidAttackEngageEvent += OnRaidEngage;
			MonoSingleton<RaidController>.Instance.RaidEndedEvent += OnRaidEnd;
			MonoSingleton<NPCController>.Instance.OnNPCChanged += OnNpcChanged;
			MonoSingleton<NPCController>.Instance.OnNPCDiedEvent += OnNpcDied;
			MonoSingleton<NPCController>.Instance.LeavingMapEvent += OnEnemyLeft;
			MonoSingleton<OptionsController>.Instance.PlaylistPauseChangeEvent += UpdateGameplayListParameters;
			MonoSingleton<GameSpeedManager>.Instance.UpdateTimeScaleUIEvent += OnChangeTimeScale;
			MonoSingleton<ConstructionController>.Instance.LockStateChangedEvent += BuildableLockStateChange;
			MonoSingleton<ResourcePileController>.Instance.SpawnPileEvent += OnSpawnPile;
			MonoSingleton<SelectionManager>.Instance.ZoneSelectionDrag += OnZoneSelectionDrag;
			MonoSingleton<SelectionManager>.Instance.ZoneSelectionPlace += OnZoneSelectionPlace;
			MonoSingleton<CombatController>.Instance.DamageTakenEvent += OnAgentDamageTaken;
			MonoSingleton<FactionsController>.Instance.FriendlinessChangedEvent += OnFactionFriendlinessChanged;
		}

		private void OnAgentDamageTaken(IDamageDealAgent deal, IDamageTakingAgent take, CombatHitInfo hitInfo)
		{
			if ((deal is SiegeWeaponProjectileInstance && take == null) || (object)take?.GetTransform() == null)
			{
				return;
			}
			Vector3 position = take.GetTransform().position;
			if (hitInfo.Critical)
			{
				audioManager.PlaySoundAtPosition("CriticalStrike", position);
			}
			Dictionary<string, string> dictionary = DictionaryPool<string, string>.Get();
			if (hitInfo.HasBlocked)
			{
				switch (hitInfo.ItemThatBlocked.Blueprint.Resource.Material)
				{
				case "wood":
					dictionary["Material"] = "Wood";
					break;
				case "metal":
					dictionary["Material"] = "Metal";
					break;
				case "cloth":
					dictionary["Material"] = "Cloth";
					break;
				default:
					dictionary["Material"] = "None";
					break;
				}
			}
			if (hitInfo.DidAnyDamage())
			{
				dictionary["Material"] = GetHitMaterial(take);
			}
			string impactEvent = GetImpactEvent(deal);
			MonoSingleton<AudioManager>.Instance.PlaySoundAtPosition(impactEvent, position, dictionary);
			DictionaryPool<string, string>.Return(dictionary);
		}

		private string GetHitMaterial(IDamageTakingAgent take)
		{
			if (take is CreatureBase)
			{
				return "Creature";
			}
			if (take is BaseBuildingInstance baseBuildingInstance)
			{
				return baseBuildingInstance.Blueprint.SoundMaterialCategory.ToString();
			}
			return "None";
		}

		private string GetImpactEvent(IDamageDealAgent deal)
		{
			if (CombatUtils.GetAttackType(deal) != AttackType.Melee)
			{
				return "RangedDamageImpact";
			}
			return "MeleeDamageImpact";
		}

		private void OnZoneSelectionPlace(float minPtX, float maxPtX, float minPtZ, float maxPtZ)
		{
			Vector3 worldPosition = GetWorldPosition(minPtX, maxPtX, minPtZ, maxPtZ);
			audioManager.PlaySoundAtPosition("UI_AreaDragStop", worldPosition);
			lastDrag = 0f;
		}

		private void OnZoneSelectionDrag(float minPtX, float maxPtX, float minPtZ, float maxPtZ)
		{
			float num = Mathf.Abs(minPtX - maxPtX) + Mathf.Abs(minPtZ - maxPtZ);
			if (!num.Equals(lastDrag))
			{
				if (lastDrag == 0f)
				{
					audioManager.PlaySoundAtPosition("UI_AreaDragStart", GetWorldPosition(minPtX, maxPtX, minPtZ, maxPtZ));
				}
				float value = ((num > lastDrag) ? 1 : (-1));
				Vector3 worldPosition = GetWorldPosition(minPtX, maxPtX, minPtZ, maxPtZ);
				audioManager.PlaySoundAtPosition("UI_AreaDrag", worldPosition, new Dictionary<string, float> { { "Value", value } });
				lastDrag = num;
			}
		}

		private Vector3 GetWorldPosition(float minPtX, float maxPtX, float minPtZ, float maxPtZ)
		{
			int x = Mathf.RoundToInt((minPtX + maxPtX) / 2f);
			int z = Mathf.RoundToInt((minPtZ + maxPtZ) / 2f);
			return GridUtils.GetWorldPosition(x, 1, z);
		}

		private void OnSpawnPile(ResourcePileInstance resourcePileInstance)
		{
			audioManager.PlaySoundAtPosition("ObjectDrop", resourcePileInstance.WorldPosition);
		}

		private void OnChangeTimeScale(float timescale, int timescaleIndex)
		{
			if (MonoSingleton<UIController>.Instance.GameStarted)
			{
				audioManager.PlaySound("UI_TimeControl", new Dictionary<string, float> { { "TimeSpeed", timescaleIndex } });
				audioManager.SetBusPaused("bus:/SFX", timescaleIndex == 0);
			}
		}

		private void OnRaidStartPopup()
		{
			audioManager.PlayStinger("EventEnemy");
			SwitchMusic(MusicState.None, 0f, 0f);
		}

		private void OnRaidSpawn(ActiveRaidInfo info, List<HumanoidInstance> enemies)
		{
			SwitchCombatPhase(1);
		}

		private void OnRaidEngage(ActiveRaidInfo info)
		{
			audioManager.PlaySound("AttackStart");
			SwitchCombatPhase(3);
		}

		private void OnRaidEnd(ActiveRaidInfo info)
		{
			SwitchCombatPhase(4);
			string soundID = info.RaidStatus switch
			{
				RaidStatus.PlayerVictory => "EventBattleWon", 
				RaidStatus.EnemyVictory => "EventBattleLost", 
				RaidStatus.Tie => "EventBattleWon", 
				_ => "", 
			};
			MonoSingleton<AudioManager>.Instance.PlayStinger(soundID);
		}

		private void OnEnemyLeft(HumanoidInstance humanoid)
		{
			RefreshEnemyStateChange();
		}

		private void OnNpcDied(HumanoidInstance humanoid)
		{
			RefreshEnemyStateChange();
		}

		private void OnNpcChanged(HumanoidInstance humanoid)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(13, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioEventsHandler.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Npc changed: ");
				messageBuilder.AppendFormatted(humanoid);
			}
			Log.Debug(messageBuilder);
			if (humanoid.IsEnemy() || humanoid.IsCaptive() || humanoid.IsPrisoner())
			{
				RefreshEnemyStateChange();
			}
		}

		private void OnFactionFriendlinessChanged(FactionFriendliness friendliness, FactionInstance factionInstance)
		{
			if (friendliness == FactionFriendliness.Hostile || friendliness == FactionFriendliness.PermanentlyHostile)
			{
				RefreshEnemyStateChange();
			}
		}

		private void RefreshEnemyStateChange()
		{
			Log.Debug("Refresh Enemies", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioEventsHandler.cs");
			if (!IsEnemyOnTheMap())
			{
				SwitchCombatPhase(5);
			}
			else if (targetMusicState != MusicState.Combat && targetMusicState != MusicState.Home)
			{
				SwitchCombatPhase(3);
			}
		}

		private bool IsEnemyOnTheMap()
		{
			if (!MonoSingleton<GlobalSaveController>.IsInstantiated() || MonoSingleton<GlobalSaveController>.IsApplicationIsQuitting() || GlobalSaveController.CurrentVillageData == null)
			{
				return false;
			}
			if (GlobalSaveController.CurrentVillageData.NPCs == null || GlobalSaveController.CurrentVillageData.NPCs.Count <= 0)
			{
				return false;
			}
			foreach (HumanoidInstance nPC in GlobalSaveController.CurrentVillageData.NPCs)
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(39, 5, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioEventsHandler.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(nPC);
					messageBuilder.AppendLiteral(" DIED: ");
					messageBuilder.AppendFormatted(nPC.HasDiedOrFainted);
					messageBuilder.AppendLiteral(", PRISONER: ");
					messageBuilder.AppendFormatted(nPC.IsPrisoner());
					messageBuilder.AppendLiteral(", CAPTIVE: ");
					messageBuilder.AppendFormatted(nPC.IsCaptive());
					messageBuilder.AppendLiteral(", ENEMY: ");
					messageBuilder.AppendFormatted(nPC.IsEnemy());
				}
				Log.Trace(messageBuilder);
				if (!nPC.HasDiedOrFainted && !nPC.IsPrisoner() && !nPC.IsCaptive() && nPC.IsEnemy())
				{
					FVLogDebugInterpolationHandler messageBuilder2 = new FVLogDebugInterpolationHandler(20, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioEventsHandler.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendFormatted(nPC);
						messageBuilder2.AppendLiteral(" is Enemy on the map");
					}
					Log.Debug(messageBuilder2);
					isEnabled = true;
					return isEnabled;
				}
			}
			return false;
		}

		private void OnGameEventStart(GameEventInstance eventInstance)
		{
			if (!(eventInstance is HailstormEvent))
			{
				if (!(eventInstance is ThunderstormEvent))
				{
					if (!(eventInstance is AlterWeatherEvent))
					{
						if (!(eventInstance is CropBlightEvent))
						{
							if (!(eventInstance is RunawayEvent))
							{
								if (!(eventInstance is NewWorkerEvent))
								{
									if (!(eventInstance is RaidEvent))
									{
										if (!(eventInstance is TraderEvent))
										{
											if (!(eventInstance is AnimalGroupEvent))
											{
												if (!(eventInstance is GameOverEvent))
												{
													if (eventInstance is GameOverSecondMapEvent)
													{
														MonoSingleton<AudioManager>.Instance.PlayStinger("EventGameOver");
													}
													else
													{
														MonoSingleton<AudioManager>.Instance.PlayStinger("EventDefault");
													}
												}
												else
												{
													MonoSingleton<AudioManager>.Instance.PlayStinger("EventGameOver");
												}
												return;
											}
											switch (eventInstance.Blueprint.AnimalType)
											{
											case AnimalType.Wild:
											case AnimalType.WildAggressive:
												MonoSingleton<AudioManager>.Instance.PlayStinger("EventAnimalRaid");
												break;
											case AnimalType.Domestic:
											case AnimalType.DomesticNpc:
											case AnimalType.Pet:
												MonoSingleton<AudioManager>.Instance.PlayStinger("EventNewAnimal");
												break;
											default:
												throw new ArgumentOutOfRangeException();
											}
										}
										else if (eventInstance.Blueprint.Category.Equals("rare_goods_trader"))
										{
											MonoSingleton<AudioManager>.Instance.PlayStinger("EventMerchantRare");
										}
										else
										{
											MonoSingleton<AudioManager>.Instance.PlayStinger("EventMerchantGeneral");
										}
									}
									else if (GlobalSaveController.CurrentVillageData.Raids.Count <= 0 || !GlobalSaveController.CurrentVillageData.Raids.LastOrDefault().HasEnded)
									{
										OnRaidStartPopup();
									}
								}
								else
								{
									MonoSingleton<AudioManager>.Instance.PlayStinger("EventNewWorker");
								}
							}
							else
							{
								MonoSingleton<AudioManager>.Instance.PlayStinger("EventNewWorker");
								OnRaidStartPopup();
							}
						}
						else
						{
							MonoSingleton<AudioManager>.Instance.PlayStinger("EventCropBlight");
						}
						return;
					}
					string iD = eventInstance.Blueprint.GetID();
					if (!(iD == "game_event_cold_snap"))
					{
						if (iD == "game_event_heat_wave")
						{
							MonoSingleton<AudioManager>.Instance.PlayStinger("EventHeatwave");
						}
						else
						{
							MonoSingleton<AudioManager>.Instance.PlayStinger("EventNature");
						}
					}
					else
					{
						MonoSingleton<AudioManager>.Instance.PlayStinger("EventCold");
					}
				}
				else
				{
					MonoSingleton<AudioManager>.Instance.PlayStinger("EventThunderStorm");
				}
			}
			else
			{
				MonoSingleton<AudioManager>.Instance.PlayStinger("EventHailStorm");
			}
		}

		private void OnShowBlackBarClickableMessage(string messagetext, Vector3 position)
		{
			MonoSingleton<AudioManager>.Instance.PlaySound("BlackBarText");
		}

		private void OnShowBlackBarMessage(string messagetext)
		{
			MonoSingleton<AudioManager>.Instance.PlaySound("BlackBarText");
		}

		private void OnShowWarningMessage(WarningMessageData message)
		{
			switch (message.Category)
			{
			case WarningMessageCategory.Warning:
				if (!message.Text.Equals("warning_message_short_Idle"))
				{
					audioManager.PlaySound("MessageWarning");
				}
				break;
			case WarningMessageCategory.Notification:
				audioManager.PlaySound("MessageInfo");
				break;
			case WarningMessageCategory.Lesson:
				audioManager.PlaySound("MessageTutorial");
				break;
			case WarningMessageCategory.Objective:
				audioManager.PlaySound("MessageInfo");
				break;
			}
		}

		private void OnEnvironmentUpdate(Dictionary<string, float> parameters)
		{
			UpdateAmbienceParameters(parameters);
		}

		private void AmbienceInitOnLoad()
		{
			OnSeasonChange();
			audioManager.StartEventInstance("DefaultAmbience");
		}

		private void OnDayStart()
		{
			SetDayNightParams(0);
			if (MonoSingleton<WeatherManager>.Instance.DayPercent <= 0.001f)
			{
				audioManager.PlaySound("RoosterCall");
			}
		}

		private void OnNightStart()
		{
			SetDayNightParams(1);
		}

		private void SetDayNightParams(int dayNightValue)
		{
			Dictionary<string, float> dictionary = DictionaryPool<string, float>.Get();
			dictionary.Add("DayNight", dayNightValue);
			UpdateAmbienceParameters(dictionary);
			DictionaryPool<string, float>.Return(dictionary);
		}

		private void OnSeasonChange()
		{
			Season season = GlobalSaveController.CurrentVillageData.DateAndTime.Season;
			float value = Repository<DateTimeSettingsData, DateTimeSettings>.Instance.GetData<DateTimeSettings>().Seasons.FindIndex((Season s) => s.Name == season.Name);
			UpdateAmbienceParameters(new Dictionary<string, float> { { "Season", value } });
		}

		private void OnCameraUpdate()
		{
			float num = Mathf.Clamp(MonoSingleton<RtsCamera>.Instance.CurrentHeightNormalized, 0f, 1f);
			float value = 1f - num;
			Dictionary<string, float> parameters = new Dictionary<string, float> { { "CameraZoom", value } };
			UpdateGameplayListParameters(parameters);
			UpdateAmbienceParameters(parameters);
		}

		private void UpdateAmbienceParameters(Dictionary<string, float> parameters)
		{
			audioManager.UpdateEventInstance("DefaultAmbience", MonoSingleton<RtsCamera>.Instance.transform.position, Truncate1Decimal(parameters));
		}

		private static Dictionary<string, float> Truncate1Decimal(Dictionary<string, float> parameters)
		{
			Dictionary<string, float> dictionary = new Dictionary<string, float>(parameters.Count);
			foreach (KeyValuePair<string, float> parameter in parameters)
			{
				dictionary[parameter.Key] = Truncate1Decimal(parameter.Value);
			}
			return dictionary;
		}

		private static float Truncate1Decimal(float value)
		{
			return (float)(int)(value * 10f) * 0.1f;
		}

		private void OnBuildablePlaced(BaseBuildingInstance instance)
		{
			MonoSingleton<TaskController>.Instance.OptimizedCall(this, "PlaySoundOnBuildablePlaced", delegate
			{
				audioManager?.PlaySoundAtPosition("UI_ConstructionPlace", instance.WorldPosition);
			});
		}

		private void OnShowFoundation(BaseBuildingInstance instance)
		{
			audioManager.PlaySoundAtPosition("ConstructionStart", instance.WorldPosition);
		}

		private void OnConstructionCompleted(BaseBuildingInstance instance)
		{
			audioManager.PlaySoundAtPosition("ConstructionFinish", instance.WorldPosition);
		}

		private void BuildableLockStateChange(BaseBuildingInstance building)
		{
			if (building.BuildingType.Equals(BuildingType.Window))
			{
				string soundID = (building.LockState.Equals(LockState.AlwaysOpen) ? "WindowOpen" : "WindowClose");
				audioManager.PlaySoundAtPosition(soundID, building.GetTransform().position);
			}
		}

		private void SwitchCombatPhase(int phase)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(23, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioEventsHandler.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Switching combat phase ");
				messageBuilder.AppendFormatted(phase);
			}
			Log.Debug(messageBuilder);
			audioManager.UpdateEventInstance("CombatPlaylist", "CombatPhase", phase);
			if (phase == 5)
			{
				SwitchMusic(MusicState.Gameplay, 5f, 5f);
			}
			else
			{
				SwitchMusic(MusicState.Combat, 0f, 0f);
			}
		}

		private void SwitchMusic(MusicState triggerState, float stopDelay, float startDelay)
		{
			if (targetMusicState == triggerState)
			{
				return;
			}
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(59, 5, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioEventsHandler.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("SwitchMusic: ");
				messageBuilder.AppendFormatted(musicState);
				messageBuilder.AppendLiteral(" -> ");
				messageBuilder.AppendFormatted(triggerState);
				messageBuilder.AppendLiteral(" (was targeting ");
				messageBuilder.AppendFormatted(targetMusicState);
				messageBuilder.AppendLiteral("), stopDelay=");
				messageBuilder.AppendFormatted(stopDelay);
				messageBuilder.AppendLiteral(", startDelay=");
				messageBuilder.AppendFormatted(startDelay);
			}
			Log.Trace(messageBuilder);
			targetMusicState = triggerState;
			switch (triggerState)
			{
			case MusicState.None:
				musicState = triggerState;
				Log.Info("SwitchMusic: stopping all playlists", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioEventsHandler.cs");
				audioManager.StopEventInstance("GameplayList", FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
				audioManager.StopEventInstance("CombatPlaylist", FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
				audioManager.StopEventInstance("HomePlaylist", FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
				break;
			case MusicState.Home:
				MonoSingleton<TaskController>.Instance.WaitForUnscaled(stopDelay).Then(delegate
				{
					if (targetMusicState != triggerState)
					{
						bool isEnabled2;
						FVLogInfoInterpolationHandler messageBuilder2 = new FVLogInfoInterpolationHandler(52, 1, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioEventsHandler.cs");
						if (isEnabled2)
						{
							messageBuilder2.AppendLiteral("SwitchMusic: Home stop cancelled, target changed to ");
							messageBuilder2.AppendFormatted(targetMusicState);
						}
						Log.Info(messageBuilder2);
					}
					else
					{
						Log.Info("SwitchMusic: stopping playlists for Home", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioEventsHandler.cs");
						audioManager.StopEventInstance("GameplayList", FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
						audioManager.StopEventInstance("CombatPlaylist", FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
					}
				}).ThenWaitFor(startDelay, isUnscaled: true)
					.Then(delegate
					{
						if (targetMusicState != triggerState)
						{
							bool isEnabled2;
							FVLogInfoInterpolationHandler messageBuilder2 = new FVLogInfoInterpolationHandler(53, 1, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioEventsHandler.cs");
							if (isEnabled2)
							{
								messageBuilder2.AppendLiteral("SwitchMusic: Home start cancelled, target changed to ");
								messageBuilder2.AppendFormatted(targetMusicState);
							}
							Log.Info(messageBuilder2);
						}
						else
						{
							Log.Info("SwitchMusic: starting HomePlaylist", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioEventsHandler.cs");
							musicState = triggerState;
							MonoSingleton<MixerSnapshotManager>.Instance.ActivateSnapshot(Snapshot.None);
							audioManager.StartEventInstance("HomePlaylist");
						}
					});
				break;
			case MusicState.Gameplay:
				MonoSingleton<TaskController>.Instance.WaitForUnscaled(stopDelay).Then(delegate
				{
					if (targetMusicState != triggerState)
					{
						bool isEnabled2;
						FVLogInfoInterpolationHandler messageBuilder2 = new FVLogInfoInterpolationHandler(56, 1, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioEventsHandler.cs");
						if (isEnabled2)
						{
							messageBuilder2.AppendLiteral("SwitchMusic: Gameplay stop cancelled, target changed to ");
							messageBuilder2.AppendFormatted(targetMusicState);
						}
						Log.Info(messageBuilder2);
					}
					else
					{
						Log.Info("SwitchMusic: stopping playlists for Gameplay", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioEventsHandler.cs");
						audioManager.StopEventInstance("HomePlaylist", FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
						audioManager.StopEventInstance("CombatPlaylist", FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
					}
				}).ThenWaitFor(startDelay, isUnscaled: true)
					.Then(delegate
					{
						if (targetMusicState != triggerState)
						{
							bool isEnabled2;
							FVLogInfoInterpolationHandler messageBuilder2 = new FVLogInfoInterpolationHandler(57, 1, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioEventsHandler.cs");
							if (isEnabled2)
							{
								messageBuilder2.AppendLiteral("SwitchMusic: Gameplay start cancelled, target changed to ");
								messageBuilder2.AppendFormatted(targetMusicState);
							}
							Log.Info(messageBuilder2);
						}
						else
						{
							Log.Info("SwitchMusic: starting GameplayList", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioEventsHandler.cs");
							musicState = triggerState;
							MonoSingleton<MixerSnapshotManager>.Instance.ActivateSnapshot(Snapshot.None);
							audioManager.StartEventInstance("GameplayList");
						}
					});
				break;
			case MusicState.Combat:
				MonoSingleton<TaskController>.Instance.WaitForUnscaled(stopDelay).Then(delegate
				{
					if (targetMusicState != triggerState)
					{
						bool isEnabled2;
						FVLogInfoInterpolationHandler messageBuilder2 = new FVLogInfoInterpolationHandler(54, 1, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioEventsHandler.cs");
						if (isEnabled2)
						{
							messageBuilder2.AppendLiteral("SwitchMusic: Combat stop cancelled, target changed to ");
							messageBuilder2.AppendFormatted(targetMusicState);
						}
						Log.Info(messageBuilder2);
					}
					else
					{
						Log.Info("SwitchMusic: stopping playlists for Combat", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioEventsHandler.cs");
						audioManager.StopEventInstance("HomePlaylist", FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
						audioManager.StopEventInstance("GameplayList", FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
					}
				}).ThenWaitFor(startDelay, isUnscaled: true)
					.Then(delegate
					{
						if (targetMusicState != triggerState)
						{
							bool isEnabled2;
							FVLogInfoInterpolationHandler messageBuilder2 = new FVLogInfoInterpolationHandler(55, 1, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioEventsHandler.cs");
							if (isEnabled2)
							{
								messageBuilder2.AppendLiteral("SwitchMusic: Combat start cancelled, target changed to ");
								messageBuilder2.AppendFormatted(targetMusicState);
							}
							Log.Info(messageBuilder2);
						}
						else
						{
							Log.Info("SwitchMusic: starting CombatList", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioEventsHandler.cs");
							musicState = triggerState;
							MonoSingleton<MixerSnapshotManager>.Instance.ActivateSnapshot(Snapshot.BattleSnapshot);
							audioManager.StartEventInstance("CombatPlaylist");
						}
					});
				break;
			default:
				throw new ArgumentOutOfRangeException("triggerState", triggerState, null);
			}
		}

		private void UpdateGameplayListParameters(Dictionary<string, float> parameters)
		{
			audioManager.UpdateEventInstance("GameplayList", MonoSingleton<RtsCamera>.Instance.transform.position, parameters);
		}

		private void OnWaterfallsChanged(List<Waterfall> waterfalls)
		{
			if (waterfalls == null || waterfalls.Count == 0)
			{
				return;
			}
			HashSet<int> hashSet = new HashSet<int>();
			foreach (KeyValuePair<int, EventInstance> waterfallEvent in waterfallEvents)
			{
				if (waterfalls.All((Waterfall waterfall) => waterfall.NodesHash != waterfallEvent.Key))
				{
					waterfallEvent.Value.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
					hashSet.Add(waterfallEvent.Key);
				}
			}
			foreach (int item in hashSet)
			{
				waterfallEvents.Remove(item);
			}
			foreach (Waterfall waterfall in waterfalls)
			{
				if (waterfallEvents.TryGetValue(waterfall.NodesHash, out var value))
				{
					if (value.isValid() && value.getPlaybackState(out var state) == RESULT.OK && state == PLAYBACK_STATE.STOPPED)
					{
						value.start();
					}
					continue;
				}
				EventInstance eventInstance = RuntimeManager.CreateInstance(MonoSingleton<AudioManager>.Instance.GetEvent("Waterfall"));
				int num = Mathf.Clamp(waterfall.WaterNodesCount, 1, 50);
				eventInstance.setParameterByName("Size", num);
				MonoSingleton<AudioManager>.Instance.PlayLoopAtPosition(eventInstance, waterfall.GridPosition);
				waterfallEvents.Add(waterfall.NodesHash, eventInstance);
				eventInstance.get3DAttributes(out var attributes);
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(19, 5, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioEventsHandlerWater.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(waterfall.WorldPosition);
					messageBuilder.AppendLiteral(" pos:");
					messageBuilder.AppendFormatted(vecstring(attributes.position));
					messageBuilder.AppendLiteral(" up:");
					messageBuilder.AppendFormatted(vecstring(attributes.up));
					messageBuilder.AppendLiteral(" fwd:");
					messageBuilder.AppendFormatted(vecstring(attributes.forward));
					messageBuilder.AppendLiteral(" vel:");
					messageBuilder.AppendFormatted(vecstring(attributes.velocity));
				}
				Log.Debug(messageBuilder);
			}
			DebugDraw();
		}

		private string vecstring(VECTOR vector)
		{
			return $"({vector.x}, {vector.y}, {vector.z})";
		}

		private void WaterEventSubscribe()
		{
			WaterManager.WaterfallsChangedEvent += OnWaterfallsChanged;
			Log.Debug("Waterfall: Subscribed to WaterfallsChangedEvent", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioEventsHandlerWater.cs");
			foreach (KeyValuePair<int, EventInstance> waterfallEvent in waterfallEvents)
			{
				waterfallEvent.Value.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
			}
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(25, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioEventsHandlerWater.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Waterfall: Stopped ");
				messageBuilder.AppendFormatted(waterfallEvents.Count);
				messageBuilder.AppendLiteral(" event");
			}
			Log.Debug(messageBuilder);
			waterfallEvents.Clear();
			OnWaterfallsChanged(WaterManager.WaterfallDetection.WaterfallsList);
		}

		private void DebugDraw()
		{
		}
	}
}
