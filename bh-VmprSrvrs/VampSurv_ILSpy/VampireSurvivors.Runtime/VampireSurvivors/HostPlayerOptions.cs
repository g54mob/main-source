using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Coherence;
using Coherence.Connection;
using Coherence.Toolkit;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors;

public class HostPlayerOptions : MonoBehaviour
{
	private sealed class _003CWaitForPlayerOptions_003Ed__145(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public HostPlayerOptions _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0a87: Expected I4, but got I8
			//IL_0015: Expected O, but got I4
			//IL_00e1: Expected I4, but got I8
			//IL_0aeb: Expected I4, but got O
			//IL_0052: Expected I4, but got I8
			HostPlayerOptions hostPlayerOptions = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (!flag)
				{
					if ((nint)obj != 1)
					{
						goto IL_0b14;
					}
					_003C_003E1__state = -1;
					Debug.Log("Received All Data, building host player config");
					if ((object)_003C_003E4__this != null && hostPlayerOptions._playerOptions != null)
					{
						hostPlayerOptions._playerOptions.BuildHostPlayerConfig(_003C_003E4__this);
						hostPlayerOptions._003CIsReady_003Ek__BackingField = true;
						return false;
					}
				}
				else
				{
					_003C_003E1__state = -1;
					if ((object)_003C_003E4__this != null && (object)hostPlayerOptions._coherenceSync != null)
					{
						if (!hostPlayerOptions._coherenceSync.HasStateAuthority)
						{
							Debug.Log("Sending Request Save Data");
							Action action = _003C_003E4__this.RequestSaveData;
							if ((object)hostPlayerOptions._coherenceSync != null)
							{
								bool flag2 = hostPlayerOptions._coherenceSync.SendCommand(action, MessageTarget.AuthorityOnly);
								Func<bool> predicate = null;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180005010");
								WaitUntil waitUntil = new WaitUntil(predicate);
								_003C_003E2__current = waitUntil;
								_003C_003E1__state = 2;
								return true;
							}
						}
						else if (hostPlayerOptions._playerOptions != null)
						{
							PlayerOptionsData config = hostPlayerOptions._playerOptions.Config;
							if (config != null)
							{
								hostPlayerOptions._003CSelectedStage_003Ek__BackingField = (int)config._003CSelectedStage_003Ek__BackingField;
								Debug.Log("Serializing Save Data");
								if (hostPlayerOptions._playerOptions != null)
								{
									PlayerOptionsData config2 = hostPlayerOptions._playerOptions.Config;
									if (config2 != null)
									{
										byte[] openedCoffins = SerializationUtils.SerializeEnum(config2._003COpenedCoffins_003Ek__BackingField);
										hostPlayerOptions._openedCoffins = openedCoffins;
										if (hostPlayerOptions._playerOptions != null)
										{
											PlayerOptionsData config3 = hostPlayerOptions._playerOptions.Config;
											if (config3 != null)
											{
												byte[] unlockedArcanas = SerializationUtils.SerializeEnum(config3._003CUnlockedArcanas_003Ek__BackingField);
												hostPlayerOptions._unlockedArcanas = unlockedArcanas;
												if (hostPlayerOptions._playerOptions != null)
												{
													PlayerOptionsData config4 = hostPlayerOptions._playerOptions.Config;
													if (config4 != null)
													{
														byte[] boughtPowerUps = SerializationUtils.SerializePowerUps(config4._003CBoughtPowerups_003Ek__BackingField);
														hostPlayerOptions._boughtPowerUps = boughtPowerUps;
														if (hostPlayerOptions._playerOptions != null)
														{
															PlayerOptionsData config5 = hostPlayerOptions._playerOptions.Config;
															if (config5 != null)
															{
																byte[] disabledPowerUps = SerializationUtils.SerializeEnum(config5._003CDisabledPowerups_003Ek__BackingField);
																hostPlayerOptions._disabledPowerUps = disabledPowerUps;
																if (hostPlayerOptions._playerOptions != null)
																{
																	PlayerOptionsData config6 = hostPlayerOptions._playerOptions.Config;
																	if (config6 != null)
																	{
																		byte[] collectedItems = SerializationUtils.SerializeEnum(config6._003CCollectedItems_003Ek__BackingField);
																		hostPlayerOptions._collectedItems = collectedItems;
																		if (hostPlayerOptions._playerOptions != null)
																		{
																			PlayerOptionsData config7 = hostPlayerOptions._playerOptions.Config;
																			if (config7 != null)
																			{
																				byte[] buffer = SerializationUtils.SerializeEnum(config7._003CUnlockedWeapons_003Ek__BackingField);
																				List<byte[]> unlockedWeaponsChunks = SerializationUtils.SplitByteArray(buffer);
																				hostPlayerOptions._unlockedWeaponsChunks = unlockedWeaponsChunks;
																				if (hostPlayerOptions._playerOptions != null)
																				{
																					PlayerOptionsData config8 = hostPlayerOptions._playerOptions.Config;
																					if (config8 != null)
																					{
																						byte[] buffer2 = SerializationUtils.SerializeEnum(config8._003CCollectedWeapons_003Ek__BackingField);
																						List<byte[]> collectedWeaponsChunks = SerializationUtils.SplitByteArray(buffer2);
																						hostPlayerOptions._collectedWeaponsChunks = collectedWeaponsChunks;
																						if (hostPlayerOptions._playerOptions != null)
																						{
																							PlayerOptionsData config9 = hostPlayerOptions._playerOptions.Config;
																							if (config9 != null)
																							{
																								byte[] buffer3 = SerializationUtils.SerializeEnum(config9._003CSealedWeapons_003Ek__BackingField);
																								List<byte[]> sealedWeaponsChunks = SerializationUtils.SplitByteArray(buffer3);
																								hostPlayerOptions._sealedWeaponsChunks = sealedWeaponsChunks;
																								if (hostPlayerOptions._playerOptions != null)
																								{
																									PlayerOptionsData config10 = hostPlayerOptions._playerOptions.Config;
																									if (config10 != null)
																									{
																										byte[] sealedItems = SerializationUtils.SerializeEnum(config10._003CSealedItems_003Ek__BackingField);
																										hostPlayerOptions._sealedItems = sealedItems;
																										if (hostPlayerOptions._playerOptions != null)
																										{
																											PlayerOptionsData config11 = hostPlayerOptions._playerOptions.Config;
																											if (config11 != null)
																											{
																												byte[] unlockedStages = SerializationUtils.SerializeEnum(config11._003CUnlockedStages_003Ek__BackingField);
																												hostPlayerOptions._unlockedStages = unlockedStages;
																												if (hostPlayerOptions._playerOptions != null)
																												{
																													PlayerOptionsData config12 = hostPlayerOptions._playerOptions.Config;
																													if (config12 != null)
																													{
																														byte[] buffer4 = SerializationUtils.SerializePickupCount(config12._003CPickupCount_003Ek__BackingField);
																														List<byte[]> hostPickupCountChunks = SerializationUtils.SplitByteArray(buffer4);
																														hostPlayerOptions._hostPickupCountChunks = hostPickupCountChunks;
																														if (hostPlayerOptions._playerOptions != null)
																														{
																															PlayerOptionsData config13 = hostPlayerOptions._playerOptions.Config;
																															if (config13 != null)
																															{
																																byte[] buffer5 = SerializationUtils.SerializeEnum(config13._003CAchievements_003Ek__BackingField);
																																List<byte[]> hostAchievementsChunks = SerializationUtils.SplitByteArray(buffer5);
																																hostPlayerOptions._hostAchievementsChunks = hostAchievementsChunks;
																																if (hostPlayerOptions._playerOptions != null)
																																{
																																	PlayerOptionsData config14 = hostPlayerOptions._playerOptions.Config;
																																	if (config14 != null)
																																	{
																																		byte[] ascensionData = SerializationUtils.SerializeAscensionData(config14._003CAscensionPointsAllocation_003Ek__BackingField);
																																		hostPlayerOptions._ascensionData = ascensionData;
																																		if (hostPlayerOptions._playerOptions != null)
																																		{
																																			PlayerOptionsData config15 = hostPlayerOptions._playerOptions.Config;
																																			if (config15 != null)
																																			{
																																				byte[] buffer6 = SerializationUtils.SerializeEnum(config15.OnlineMultiplayerSelections);
																																				List<byte[]> onlineMultiplayerSelectionsChunks = SerializationUtils.SplitByteArray(buffer6);
																																				hostPlayerOptions._onlineMultiplayerSelectionsChunks = onlineMultiplayerSelectionsChunks;
																																				if (hostPlayerOptions._playerOptions != null)
																																				{
																																					PlayerOptionsData config16 = hostPlayerOptions._playerOptions.Config;
																																					if (config16 != null)
																																					{
																																						PlayerOptionsData config17 = config16.Clone();
																																						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C0C0");
																																						if (hostPlayerOptions._playerOptions != null)
																																						{
																																							bool adventureMode = default(bool);
																																							bool onlineClientWithRunData = default(bool);
																																							hostPlayerOptions._playerOptions.ApplyConfig(config17, adventureMode, hostConfig: true, onlineClientWithRunData);
																																							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C0C0");
																																							object obj2 = default(object);
																																							if (obj2 != null)
																																							{
																																								AdventureManager adventureManager = hostPlayerOptions._adventureManager;
																																								if (hostPlayerOptions._adventureManager == null || hostPlayerOptions._dataManager == null)
																																								{
																																									goto IL_0add;
																																								}
																																								hostPlayerOptions._dataManager.GenerateAdventureSpecificData(adventureManager._003CAdventureData_003Ek__BackingField);
																																							}
																																							hostPlayerOptions._003CIsReady_003Ek__BackingField = true;
																																							goto IL_0b14;
																																						}
																																					}
																																				}
																																			}
																																		}
																																	}
																																}
																															}
																														}
																													}
																												}
																											}
																										}
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
				goto IL_0add;
			}
			_003C_003E1__state = -1;
			Debug.Log("Waiting for Player Options");
			Func<bool> predicate2 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180005010");
			WaitUntil waitUntil2 = new WaitUntil(predicate2);
			_003C_003E2__current = waitUntil2;
			_003C_003E1__state = 1;
			return true;
			IL_0add:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_0b14:
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private static HostPlayerOptions _003CInstance_003Ek__BackingField;

	private bool _003CIsReady_003Ek__BackingField;

	private int _003CSelectedStage_003Ek__BackingField;

	private int _003CSelectedBGM_003Ek__BackingField;

	private PlayerOptions _playerOptions;

	private AdventureManager _adventureManager;

	private CoherenceSync _coherenceSync;

	private SignalBus _signalBus;

	private DataManager _dataManager;

	private byte[] _openedCoffins;

	private byte[] _unlockedArcanas;

	private byte[] _boughtPowerUps;

	private byte[] _disabledPowerUps;

	private byte[] _collectedItems;

	private List<byte[]> _unlockedWeaponsChunks;

	private List<byte[]> _collectedWeaponsChunks;

	private List<byte[]> _sealedWeaponsChunks;

	private List<byte[]> _onlineMultiplayerSelectionsChunks;

	private byte[] _sealedItems;

	private byte[] _unlockedStages;

	private List<byte[]> _hostPickupCountChunks;

	private List<byte[]> _hostAchievementsChunks;

	private byte[] _ascensionData;

	private int _currentAdventureType;

	private bool _openedCoffinsReady;

	private bool _unlockedArcanasReady;

	private bool _boughtPowerUpsReady;

	private bool _disabledPowerUpsReady;

	private bool _collectedItemsReady;

	private bool _unlockedWeaponsReady;

	private bool _collectedWeaponsReady;

	private bool _sealedWeaponsReady;

	private bool _sealedItemsReady;

	private bool _unlockedStagesReady;

	private bool _hostPickupCountReady;

	private bool _hostAchievementsReady;

	private bool _ascensionDataReady;

	private bool _adventureReady;

	private bool _onlineMultiplerSelectionsReady;

	public static HostPlayerOptions Instance
	{
		get
		{
			return _003CInstance_003Ek__BackingField;
		}
		private set
		{
			_003CInstance_003Ek__BackingField = value;
		}
	}

	public bool IsReady
	{
		get
		{
			return _003CIsReady_003Ek__BackingField;
		}
		set
		{
			_003CIsReady_003Ek__BackingField = value;
		}
	}

	public int SelectedStage
	{
		get
		{
			return _003CSelectedStage_003Ek__BackingField;
		}
		set
		{
			_003CSelectedStage_003Ek__BackingField = value;
		}
	}

	public int SelectedBGM
	{
		get
		{
			return _003CSelectedBGM_003Ek__BackingField;
		}
		set
		{
			_003CSelectedBGM_003Ek__BackingField = value;
		}
	}

	public byte[] HostOpenedCoffins => _openedCoffins;

	public byte[] AvailableHostArcanas => _unlockedArcanas;

	public byte[] AvailableHostBoughtPowerUps => _boughtPowerUps;

	public byte[] HostDisabledPowerUps => _disabledPowerUps;

	public byte[] HostCollectedItems => _collectedItems;

	public List<byte[]> HostUnlockedWeapons => _unlockedWeaponsChunks;

	public List<byte[]> HostCollectedWeapons => _collectedWeaponsChunks;

	public List<byte[]> HostSealedWeapons => _sealedWeaponsChunks;

	public List<byte[]> OnlineMultiplayerSelections => _onlineMultiplayerSelectionsChunks;

	public byte[] HostSealedItems => _sealedItems;

	public byte[] HostUnlockedStages => _unlockedStages;

	public List<byte[]> HostPickupCount => _hostPickupCountChunks;

	public List<byte[]> HostAchievements => _hostAchievementsChunks;

	public byte[] AscensionData => _ascensionData;

	public bool SelectedHyper
	{
		get
		{
			//IL_0069: Expected I4, but got O
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config != null)
				{
					return config._003CSelectedHyper_003Ek__BackingField;
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			return false;
		}
		set
		{
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				PlayerOptions playerOptions = _playerOptions;
				if (config != playerOptions._mainGameConfig)
				{
					PlayerOptionsData config2 = playerOptions.Config;
					config2._003CSelectedHyper_003Ek__BackingField = value;
				}
			}
		}
	}

	public bool SelectedHurry
	{
		get
		{
			//IL_0069: Expected I4, but got O
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config != null)
				{
					return config._003CSelectedHurry_003Ek__BackingField;
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			return false;
		}
		set
		{
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				PlayerOptions playerOptions = _playerOptions;
				if (config != playerOptions._mainGameConfig)
				{
					PlayerOptionsData config2 = playerOptions.Config;
					config2._003CSelectedHurry_003Ek__BackingField = value;
				}
			}
		}
	}

	public bool SelectedInverse
	{
		get
		{
			//IL_0069: Expected I4, but got O
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config != null)
				{
					return config._003CSelectedInverse_003Ek__BackingField;
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			return false;
		}
		set
		{
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				PlayerOptions playerOptions = _playerOptions;
				if (config != playerOptions._mainGameConfig)
				{
					PlayerOptionsData config2 = playerOptions.Config;
					config2._003CSelectedInverse_003Ek__BackingField = value;
				}
			}
		}
	}

	public bool VisuallyInvert
	{
		get
		{
			//IL_0069: Expected I4, but got O
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config != null)
				{
					return config._003CVisuallyInvertStages_003Ek__BackingField;
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			return false;
		}
		set
		{
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				PlayerOptions playerOptions = _playerOptions;
				if (config != playerOptions._mainGameConfig)
				{
					PlayerOptionsData config2 = playerOptions.Config;
					config2._003CVisuallyInvertStages_003Ek__BackingField = value;
				}
			}
		}
	}

	public bool SelectedReapers
	{
		get
		{
			//IL_0069: Expected I4, but got O
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config != null)
				{
					return config._003CSelectedReapers_003Ek__BackingField;
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			return false;
		}
		set
		{
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				PlayerOptions playerOptions = _playerOptions;
				if (config != playerOptions._mainGameConfig)
				{
					PlayerOptionsData config2 = playerOptions.Config;
					config2._003CSelectedReapers_003Ek__BackingField = value;
				}
			}
		}
	}

	public bool SelectedMazzo
	{
		get
		{
			//IL_0069: Expected I4, but got O
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config != null)
				{
					return config._003CSelectedMazzo_003Ek__BackingField;
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			return false;
		}
		set
		{
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				PlayerOptions playerOptions = _playerOptions;
				if (config != playerOptions._mainGameConfig)
				{
					PlayerOptionsData config2 = playerOptions.Config;
					config2._003CSelectedMazzo_003Ek__BackingField = value;
				}
			}
		}
	}

	public bool SelectedRandomEvents
	{
		get
		{
			//IL_0069: Expected I4, but got O
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config != null)
				{
					return config._003CSelectedRandomEvents_003Ek__BackingField;
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			return false;
		}
		set
		{
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				PlayerOptions playerOptions = _playerOptions;
				if (config != playerOptions._mainGameConfig)
				{
					PlayerOptionsData config2 = playerOptions.Config;
					config2._003CSelectedRandomEvents_003Ek__BackingField = value;
				}
			}
		}
	}

	public bool HasKilledTheFinalBoss
	{
		get
		{
			//IL_0069: Expected I4, but got O
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config != null)
				{
					return config._003CHasKilledTheFinalBoss_003Ek__BackingField;
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			return false;
		}
		set
		{
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				PlayerOptions playerOptions = _playerOptions;
				if (config != playerOptions._mainGameConfig)
				{
					PlayerOptionsData config2 = playerOptions.Config;
					config2._003CHasKilledTheFinalBoss_003Ek__BackingField = value;
				}
			}
		}
	}

	public bool HasSeenFinalFireworks
	{
		get
		{
			//IL_0069: Expected I4, but got O
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config != null)
				{
					return config._003CHasSeenFinalFireworks_003Ek__BackingField;
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			return false;
		}
		set
		{
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				PlayerOptions playerOptions = _playerOptions;
				if (config != playerOptions._mainGameConfig)
				{
					PlayerOptionsData config2 = playerOptions.Config;
					config2._003CHasSeenFinalFireworks_003Ek__BackingField = value;
				}
			}
		}
	}

	public bool SelectedSharePassives
	{
		get
		{
			//IL_0069: Expected I4, but got O
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config != null)
				{
					return config._003CSelectedSharePassives_003Ek__BackingField;
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			return false;
		}
		set
		{
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				PlayerOptions playerOptions = _playerOptions;
				if (config != playerOptions._mainGameConfig)
				{
					PlayerOptionsData config2 = playerOptions.Config;
					config2._003CSelectedSharePassives_003Ek__BackingField = value;
				}
			}
		}
	}

	public bool HasSeenDarkanaTransition
	{
		get
		{
			//IL_000a: Expected I4, but got O
			//IL_0015: Expected I4, but got O
			//IL_006c: Expected I4, but got O
			//IL_0033: Expected O, but got I
			//IL_007a: Expected I4, but got O
			bool flag = (byte)(int)_playerOptions != 0;
			if ((int)(~_playerOptions) == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal1 @ rax_v1 (System.Boolean)+50]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal1 @ rax_v1 (System.Boolean)+50]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rax_v2+29D]");
					return false;
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			return (byte)(int)_playerOptions != 0;
		}
		set
		{
			if (_playerOptions != null)
			{
				PlayerOptions playerOptions = _playerOptions;
				PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
				mainGameConfig._003CHasSeenDarkanaTransition_003Ek__BackingField = value;
			}
		}
	}

	public int SelectedArcana
	{
		get
		{
			//IL_0069: Expected I4, but got O
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config != null)
				{
					return config._003CSelectedArcana_003Ek__BackingField;
				}
				NullReferenceException ex = new NullReferenceException();
				return (int)ex;
			}
			return 0;
		}
		set
		{
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				PlayerOptions playerOptions = _playerOptions;
				if (config != playerOptions._mainGameConfig)
				{
					PlayerOptionsData config2 = playerOptions.Config;
					config2._003CSelectedArcana_003Ek__BackingField = value;
				}
			}
		}
	}

	public bool SelectedOnlineFreeRoam
	{
		get
		{
			//IL_0069: Expected I4, but got O
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config != null)
				{
					return config._003CSelectedOnlineFreeRoam_003Ek__BackingField;
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			return true;
		}
		set
		{
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				PlayerOptions playerOptions = _playerOptions;
				if (config != playerOptions._mainGameConfig)
				{
					PlayerOptionsData config2 = playerOptions.Config;
					config2._003CSelectedOnlineFreeRoam_003Ek__BackingField = value;
				}
			}
		}
	}

	public int EME_NextBossBiome
	{
		get
		{
			//IL_0069: Expected I4, but got O
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config != null)
				{
					return config._003CEME_NextBossBiome_003Ek__BackingField;
				}
				NullReferenceException ex = new NullReferenceException();
				return (int)ex;
			}
			return 0;
		}
		set
		{
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				PlayerOptions playerOptions = _playerOptions;
				if (config != playerOptions._mainGameConfig)
				{
					PlayerOptionsData config2 = playerOptions.Config;
					config2._003CEME_NextBossBiome_003Ek__BackingField = value;
				}
			}
		}
	}

	public int CurrentAdventureType
	{
		get
		{
			//IL_00f6: Expected I4, but got O
			//IL_00e1: Expected I4, but got I8
			//IL_008c: Expected O, but got I
			CoherenceSync coherenceSync = _coherenceSync;
			if ((object)_coherenceSync != null)
			{
				NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
				if (coherenceSync._003CEntityState_003Ek__BackingField != null)
				{
					ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
					if (networkEntityState._003CAuthorityType_003Ek__BackingField == null)
					{
						goto IL_00e8;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rcx_v7 (Coherence.Toolkit.ObservableAuthorityType)+10]");
					bool flag = false;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rcx_v7 (Coherence.Toolkit.ObservableAuthorityType)+10]");
					if ((nint)0 != 1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rcx_v7 (Coherence.Toolkit.ObservableAuthorityType)+10]");
						object obj = -3;
						bool flag2 = obj == null;
						flag = flag2;
					}
					if (!flag)
					{
						goto IL_00e1;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C0C0");
				object obj2 = default(object);
				if (obj2 == null)
				{
					return -1;
				}
				goto IL_00e1;
			}
			goto IL_00e8;
			IL_00e8:
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
			IL_00e1:
			return _currentAdventureType;
		}
		set
		{
			_currentAdventureType = value;
		}
	}

	private void Construct(SignalBus signalBus, PlayerOptions playerOptions, AdventureManager adventureManager, DataManager dataManager)
	{
		_signalBus = signalBus;
		_playerOptions = playerOptions;
		_adventureManager = adventureManager;
		DataManager dataManager2 = default(DataManager);
		_dataManager = dataManager2;
	}

	public void SendOpenedCoffins(byte[] openedCoffins)
	{
		if (!_openedCoffinsReady)
		{
			_openedCoffinsReady = true;
			_openedCoffins = openedCoffins;
		}
	}

	public void SendUnlockedArcanas(byte[] unlockedArcanas)
	{
		if (!_unlockedArcanasReady)
		{
			_unlockedArcanasReady = true;
			_unlockedArcanas = unlockedArcanas;
		}
	}

	public void SendBoughtPowerUps(byte[] boughtPowerUps)
	{
		if (!_boughtPowerUpsReady)
		{
			_boughtPowerUpsReady = true;
			_boughtPowerUps = boughtPowerUps;
		}
	}

	public void SendDisabledPowerUps(byte[] disabledPowerUps)
	{
		if (!_disabledPowerUpsReady)
		{
			_disabledPowerUpsReady = true;
			_disabledPowerUps = disabledPowerUps;
		}
	}

	public void SendCollectedItems(byte[] collectedItems)
	{
		if (!_collectedItemsReady)
		{
			_collectedItemsReady = true;
			_collectedItems = collectedItems;
		}
	}

	public unsafe void SendUnlockedWeaponsChunk(byte[] unlockedWeaponsChunk, int expectedChunks)
	{
		//IL_00d0: Expected O, but got Ref
		if (!_unlockedWeaponsReady)
		{
			if (_unlockedWeaponsChunks == null)
			{
				List<byte[]> unlockedWeaponsChunks = new List<byte[]>();
				_unlockedWeaponsChunks = unlockedWeaponsChunks;
			}
			if (unlockedWeaponsChunk != null && unlockedWeaponsChunk.Length != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B5C40");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			object arg2 = default(object);
			System.ParamsArray paramsArray = new System.ParamsArray(arg, arg2);
			object obj = default(object);
			string message = string.FormatHelper((IFormatProvider)null, "Received Unlocked Weapons Chunk. {0} / {1}", (System.ParamsArray)(&obj));
			Debug.Log(message);
			List<byte[]> unlockedWeaponsChunks2 = _unlockedWeaponsChunks;
			int num = default(int);
			if (unlockedWeaponsChunks2._size == num || num == 0)
			{
				_unlockedWeaponsReady = true;
			}
		}
	}

	public unsafe void SendOnlineMultiplayerSelectionsChunk(byte[] onlineMultiplayerSelectionsChunk, int expectedChunks)
	{
		//IL_00d0: Expected O, but got Ref
		if (!_onlineMultiplerSelectionsReady)
		{
			if (_onlineMultiplayerSelectionsChunks == null)
			{
				List<byte[]> onlineMultiplayerSelectionsChunks = new List<byte[]>();
				_onlineMultiplayerSelectionsChunks = onlineMultiplayerSelectionsChunks;
			}
			if (onlineMultiplayerSelectionsChunk != null && onlineMultiplayerSelectionsChunk.Length != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B5C40");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			object arg2 = default(object);
			System.ParamsArray paramsArray = new System.ParamsArray(arg, arg2);
			object obj = default(object);
			string message = string.FormatHelper((IFormatProvider)null, "Received Online Multiplayer Selection Chunk. {0} / {1}", (System.ParamsArray)(&obj));
			Debug.Log(message);
			List<byte[]> onlineMultiplayerSelectionsChunks2 = _onlineMultiplayerSelectionsChunks;
			int num = default(int);
			if (onlineMultiplayerSelectionsChunks2._size == num || num == 0)
			{
				_onlineMultiplerSelectionsReady = true;
			}
		}
	}

	public unsafe void SendCollectedWeaponsChunk(byte[] collectedWeaponsChunk, int expectedChunks)
	{
		//IL_00d0: Expected O, but got Ref
		if (!_collectedWeaponsReady)
		{
			if (_collectedWeaponsChunks == null)
			{
				List<byte[]> collectedWeaponsChunks = new List<byte[]>();
				_collectedWeaponsChunks = collectedWeaponsChunks;
			}
			if (collectedWeaponsChunk != null && collectedWeaponsChunk.Length != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B5C40");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			object arg2 = default(object);
			System.ParamsArray paramsArray = new System.ParamsArray(arg, arg2);
			object obj = default(object);
			string message = string.FormatHelper((IFormatProvider)null, "Received Collected Weapons Chunk. {0} / {1}", (System.ParamsArray)(&obj));
			Debug.Log(message);
			List<byte[]> collectedWeaponsChunks2 = _collectedWeaponsChunks;
			int num = default(int);
			if (collectedWeaponsChunks2._size == num || num == 0)
			{
				_collectedWeaponsReady = true;
			}
		}
	}

	public unsafe void SendSealedWeaponsChunk(byte[] sealedWeaponsChunk, int expectedChunks)
	{
		//IL_00d0: Expected O, but got Ref
		if (!_sealedWeaponsReady)
		{
			if (_sealedWeaponsChunks == null)
			{
				List<byte[]> sealedWeaponsChunks = new List<byte[]>();
				_sealedWeaponsChunks = sealedWeaponsChunks;
			}
			if (sealedWeaponsChunk != null && sealedWeaponsChunk.Length != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B5C40");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			object arg2 = default(object);
			System.ParamsArray paramsArray = new System.ParamsArray(arg, arg2);
			object obj = default(object);
			string message = string.FormatHelper((IFormatProvider)null, "Received Sealed Weapons Chunk. {0} / {1}", (System.ParamsArray)(&obj));
			Debug.Log(message);
			List<byte[]> sealedWeaponsChunks2 = _sealedWeaponsChunks;
			int num = default(int);
			if (sealedWeaponsChunks2._size == num || num == 0)
			{
				_sealedWeaponsReady = true;
			}
		}
	}

	public void SendSealedItems(byte[] sealedItems)
	{
		if (!_sealedItemsReady)
		{
			_sealedItemsReady = true;
			_sealedItems = sealedItems;
		}
	}

	public void SendUnlockedStages(byte[] unlockedStages)
	{
		if (!_unlockedStagesReady)
		{
			_unlockedStagesReady = true;
			_unlockedStages = unlockedStages;
		}
	}

	public void SendHostPickupCountChunk(byte[] hostPickupCountChunk, int expectedChunks)
	{
		if (!_hostPickupCountReady)
		{
			if (_hostPickupCountChunks == null)
			{
				List<byte[]> hostPickupCountChunks = new List<byte[]>();
				_hostPickupCountChunks = hostPickupCountChunks;
			}
			if (hostPickupCountChunk != null && hostPickupCountChunk.Length != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B5C40");
			}
			List<byte[]> hostPickupCountChunks2 = _hostPickupCountChunks;
			int num = default(int);
			if (hostPickupCountChunks2._size == num || num == 0)
			{
				_hostPickupCountReady = true;
			}
		}
	}

	public void SendHostAchievementsChunk(byte[] hostAchievementsChunk, int expectedChunks)
	{
		if (!_hostAchievementsReady)
		{
			if (_hostAchievementsChunks == null)
			{
				List<byte[]> hostAchievementsChunks = new List<byte[]>();
				_hostAchievementsChunks = hostAchievementsChunks;
			}
			if (hostAchievementsChunk != null && hostAchievementsChunk.Length != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B5C40");
			}
			List<byte[]> hostAchievementsChunks2 = _hostAchievementsChunks;
			int num = default(int);
			if (hostAchievementsChunks2._size == num || num == 0)
			{
				_hostAchievementsReady = true;
			}
		}
	}

	public void SendAdventureType(int adventureType)
	{
		//IL_0058: Expected O, but got I4
		if (!_adventureReady)
		{
			_adventureReady = true;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C0C0");
			object obj = default(object);
			if (obj != null)
			{
				bool flag = false;
			}
			else
			{
				object obj2 = adventureType - -1;
				bool flag2 = obj2 == null;
				bool flag = !flag2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186E45000");
			_currentAdventureType = adventureType;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C0C0");
			object obj3 = default(object);
			if (obj3 != null && adventureType == -1)
			{
				_adventureManager.ExitAdventureMode();
			}
		}
	}

	public void SendAscensionData(byte[] ascensionData)
	{
		if (!_ascensionDataReady)
		{
			_ascensionDataReady = true;
			_ascensionData = ascensionData;
		}
	}

	public void RequestSaveData()
	{
		SendHostSaveData();
	}

	private unsafe void Awake()
	{
		//IL_0081: Expected O, but got I
		//IL_01e5: Expected O, but got Ref
		UnityEngine.Object.DontDestroyOnLoad(this);
		_003CInstance_003Ek__BackingField = this;
		CoherenceSync component = GetComponent<CoherenceSync>();
		_coherenceSync = component;
		CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
		UnityEvent<CoherenceBridge, ConnectionCloseReason> onDisconnected = masterBridge.onDisconnected;
		UnityAction<CoherenceBridge, ConnectionCloseReason> action = OnDisconnected;
		UnityEngine.Events.BaseInvokableCall baseInvokableCall = UnityEvent<CoherenceBridge, ConnectionCloseReason>.GetDelegate(action);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v289 @ rdi_v2 (UnityEngine.Events.UnityEvent`2<Coherence.Toolkit.CoherenceBridge, Coherence.Connection.ConnectionCloseReason>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A5D0D0");
		_ = 1;
		_003CWaitForPlayerOptions_003Ed__145 obj2 = null;
		obj2._003C_003E1__state = 0;
		obj2._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj2);
		CoherenceSync coherenceSync = _coherenceSync;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rcx_v36 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			if ((nint)0 == 1)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		CoherenceSync coherenceSync2 = _coherenceSync;
		if (coherenceSync2._003CEntityState_003Ek__BackingField != null)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		object arg2 = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg, arg2);
		object obj3 = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "OnlineStageManager: Authority: {0}. Orphaned: {1}", (System.ParamsArray)(&obj3));
		Debug.Log(message);
	}

	private void OnDestroy()
	{
		//IL_006e: Expected O, but got I
		//IL_006e: Expected O, but got I
		CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
		UnityEvent<CoherenceBridge, ConnectionCloseReason> onDisconnected = masterBridge.onDisconnected;
		UnityAction<CoherenceBridge, ConnectionCloseReason> unityAction = OnDisconnected;
		MethodInfo methodImpl = ((MulticastDelegate)unityAction).GetMethodImpl();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rsi_v2 (UnityEngine.Events.UnityEvent`2<Coherence.Toolkit.CoherenceBridge, Coherence.Connection.ConnectionCloseReason>)+10]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rax_v9 (UnityEngine.Events.UnityAction`2<Coherence.Toolkit.CoherenceBridge, Coherence.Connection.ConnectionCloseReason>)+20]");
		((UnityEngine.Events.InvokableCallList)num).RemoveListener(0, methodImpl);
	}

	private unsafe void OnStageSelectedRemotely(int oldStage, int newStage)
	{
		//IL_0027: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		string message = "Stage Selected Remotely: " + text;
		Debug.Log(message);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA03B0");
	}

	private unsafe void OnBGMSelectedRemotely(int oldBGM, int newBGM)
	{
		//IL_013d: Expected O, but got Ref
		//IL_00c0: Expected O, but got I
		//IL_00d5: Expected O, but got I
		//IL_00ea: Expected O, but got I
		Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _dataManager.GetConvertedCharacterData();
		PlayerOptionsData config = _playerOptions.Config;
		object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)config._selectedChar);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rax_v10 (System.Object)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rax_v10 (System.Object)+18]");
				if ((nint)0 <= (nint)0)
				{
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rax_v10 (System.Object)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rcx_v16+20]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v20+100]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v20+100]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rax_v21+10]");
					if ((nint)0 > (nint)0)
					{
						return;
					}
				}
			}
		}
		object obj5 = default(object);
		string text = ((Enum)(&obj5)).ToString();
		string message = "BGM updated remotely to " + text;
		Debug.Log(message);
		PlayerOptionsData config2 = _playerOptions.Config;
		config2._003CSelectedBGM_003Ek__BackingField = (BgmType)newBGM;
	}

	private IEnumerator WaitForPlayerOptions()
	{
		_003CWaitForPlayerOptions_003Ed__145 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void SendHostSaveData()
	{
		//IL_01eb: Expected I4, but got O
		//IL_0241: Expected I4, but got I8
		//IL_0297: Expected O, but got I4
		Debug.Log("Sending data to other clients");
		Action<byte[]> action = SendOpenedCoffins;
		bool flag = _coherenceSync.SendCommand((Action<object>)action, MessageTarget.Other, _openedCoffins);
		Action<byte[]> action2 = SendUnlockedArcanas;
		bool flag2 = _coherenceSync.SendCommand((Action<object>)action2, MessageTarget.Other, _unlockedArcanas);
		Action<byte[]> action3 = SendBoughtPowerUps;
		bool flag3 = _coherenceSync.SendCommand((Action<object>)action3, MessageTarget.Other, _boughtPowerUps);
		Action<byte[]> action4 = SendDisabledPowerUps;
		bool flag4 = _coherenceSync.SendCommand((Action<object>)action4, MessageTarget.Other, _disabledPowerUps);
		Action<byte[]> action5 = SendCollectedItems;
		bool flag5 = _coherenceSync.SendCommand((Action<object>)action5, MessageTarget.Other, _collectedItems);
		Action<byte[]> action6 = SendSealedItems;
		bool flag6 = _coherenceSync.SendCommand((Action<object>)action6, MessageTarget.Other, _sealedItems);
		Action<byte[]> action7 = SendUnlockedStages;
		bool flag7 = _coherenceSync.SendCommand((Action<object>)action7, MessageTarget.Other, _unlockedStages);
		Action<byte[]> action8 = SendAscensionData;
		bool flag8 = _coherenceSync.SendCommand((Action<object>)action8, MessageTarget.Other, _ascensionData);
		Action<int> action9 = null;
		((HostPlayerOptions)(object)action9).SendAdventureType((int)this);
		int param;
		if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			AdventureManager adventureManager = _adventureManager;
			param = (int)adventureManager.CurrentAdventure;
		}
		else
		{
			param = -1;
		}
		bool flag9 = _coherenceSync.SendCommand(action9, MessageTarget.Other, param);
		if (!AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			bool flag10 = false;
		}
		else
		{
			AdventureManager adventureManager2 = _adventureManager;
			object obj = adventureManager2.CurrentAdventure - -1;
			bool flag11 = obj == null;
			bool flag10 = !flag11;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186E45000");
		Action<byte[], int> sendChunkCommand = SendHostPickupCountChunk;
		SendChunks(_hostPickupCountChunks, sendChunkCommand);
		Action<byte[], int> sendChunkCommand2 = SendHostAchievementsChunk;
		SendChunks(_hostAchievementsChunks, sendChunkCommand2);
		Action<byte[], int> sendChunkCommand3 = SendSealedWeaponsChunk;
		SendChunks(_sealedWeaponsChunks, sendChunkCommand3);
		Action<byte[], int> sendChunkCommand4 = SendCollectedWeaponsChunk;
		SendChunks(_collectedWeaponsChunks, sendChunkCommand4);
		Action<byte[], int> sendChunkCommand5 = SendUnlockedWeaponsChunk;
		SendChunks(_unlockedWeaponsChunks, sendChunkCommand5);
		Action<byte[], int> action10 = SendOnlineMultiplayerSelectionsChunk;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 605 Invalid \"Jump target not found in method: 0x186F3BAD0\"");
		throw new NullReferenceException();
	}

	public void RefundGuestsPowerUps()
	{
		//IL_006f: Expected O, but got I
		CoherenceSync coherenceSync = _coherenceSync;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v9 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			bool flag = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v9 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			if ((nint)0 != 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v9 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				object obj = -3;
				bool flag2 = obj == null;
				flag = flag2;
			}
			if (!flag)
			{
				return;
			}
		}
		Action action = SendRefundPowerUps;
		bool flag3 = _coherenceSync.SendCommand(action, MessageTarget.Other);
	}

	public void SendRefundPowerUps()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0940");
	}

	private void SendChunks(List<byte[]> chunks, Action<byte[], int> sendChunkCommand)
	{
		if (chunks != null)
		{
			int param = default(int);
			if (chunks._size != 0)
			{
				List<byte[]>.Enumerator enumerator = default(List<byte[]>.Enumerator);
				while (true)
				{
					if (enumerator.MoveNext())
					{
						if ((object)_coherenceSync == null)
						{
							break;
						}
						bool flag = _coherenceSync.SendOrderedCommand((Action<object, int>)sendChunkCommand, MessageTarget.Other, null, param);
						continue;
					}
					return;
				}
				throw new NullReferenceException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18047E1C0");
			if ((object)_coherenceSync != null)
			{
				object param2 = default(object);
				bool flag2 = _coherenceSync.SendOrderedCommand((Action<object, int>)sendChunkCommand, MessageTarget.Other, param2, param);
				return;
			}
		}
		throw new NullReferenceException();
	}

	private bool ReceivedAllData()
	{
		if (_openedCoffinsReady && _unlockedArcanasReady && _boughtPowerUpsReady && _disabledPowerUpsReady && _collectedItemsReady && _unlockedWeaponsReady && _collectedWeaponsReady && _sealedWeaponsReady && _sealedItemsReady && _unlockedStagesReady && _hostPickupCountReady && _hostAchievementsReady && _ascensionDataReady && _adventureReady)
		{
			return _onlineMultiplerSelectionsReady;
		}
		return false;
	}

	private void OnDisconnected(CoherenceBridge _, ConnectionCloseReason __)
	{
		GameObject obj = base.gameObject;
		UnityEngine.Object.Destroy(obj, 0f);
	}

	public HostPlayerOptions()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private bool _003CWaitForPlayerOptions_003Eb__145_0()
	{
		bool flag = (nint)_playerOptions < 0;
		bool flag2 = _playerOptions == null;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		return flag4 & flag3;
	}
}
