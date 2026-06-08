using System.Collections.Generic;
using UnityEngine;

public static class GameAudio
{
	public enum SoundEnum
	{
		None = 0,
		AlertWarning = 1,
		AlertError = 2,
		EventRadiation = 3,
		Notification = 4,
		WeaponTriggered = 5,
		SensorTriggered = 6,
		SensorUntriggered = 7,
		TerminalOn = 8,
		TerminalOff = 9,
		ItemDetected = 10,
		FlagPlaced = 11,
		FlagRemoved = 12,
		A_MotherShip = 13,
		Docking1 = 14,
		Docking2 = 15,
		CommandSuccess = 16,
		CommandError = 17,
		BIOSFan = 18,
		BIOSBeep = 19,
		BIOSText1 = 20,
		BIOSText2 = 21,
		BIOSTextSingle = 22,
		UIEquip = 23,
		UIUnEquip = 24,
		UIOpenMenu = 25,
		UIExitMenu = 26,
		UISelectHigh = 27,
		UISelectLow = 28,
		UIChangeViewDown1 = 29,
		UIChangeViewDown2 = 30,
		UIChangeViewDown3 = 31,
		UIChangeViewUp1 = 32,
		UIChangeViewUp2 = 33,
		UIChangeViewUp3 = 34,
		UIDialogShow = 35,
		GalaxySelectNode = 36,
		UniverseWarpOut = 37,
		UniverseWarpIn = 38,
		Hint = 39,
		DroneCS_1 = 40,
		DroneCS_2 = 41,
		DroneCS_3 = 42,
		DroneCS_4 = 43,
		DroneCS_5 = 44,
		DroneCS_6 = 45,
		DroneCS_7 = 46,
		DroneCS_8 = 47,
		DroneCS_9 = 48,
		DroneCS_10 = 49,
		DroneCS_11 = 50,
		DroneCS_12 = 51,
		DroneCS_13 = 52,
		ShipCreak1 = 53,
		ShipCreak2 = 54,
		ShipCreak3 = 55,
		AsteroidHit = 56,
		ShipCannon = 57,
		ShipCollector = 58,
		ShipDecontaminate = 59,
		ShipOverload = 60,
		AVNTLaugh = 61,
		Schematic_DroneMapMove_Start = 62,
		Schematic_DroneMapMove_Sustain = 63,
		Schematic_ItemPickedUp = 64,
		Schematic_Interface = 65,
		Remote_DoorOpen = 66,
		Remote_DroneEngineAccel = 67,
		Remote_DroneEngineDeaccel = 68,
		Remote_DroneEngineLoop = 69,
		Remote_DroneMoveStart = 70,
		Remote_DroneMoveStop = 71,
		Remote_DroneMoveSustain = 72,
		Remote_DroneCollide1 = 73,
		Remote_DroneCollide2 = 74,
		Remote_DroneCollide3 = 75,
		Remote_Generator = 76,
		Remote_BotShot = 77,
		Remote_BotIdle = 78,
		Remote_Swarm = 79,
		Remote_BruteScream1 = 80,
		Remote_BruteScream2 = 81,
		Remote_BruteScream3 = 82,
		Remote_BruteScream4 = 83,
		Remote_A_HostShip1 = 84,
		Remote_A_HostShip2 = 85,
		Remote_A_HostShip3 = 86,
		Remote_A_StaticA = 87,
		Remote_A_StaticB = 88,
		Remote_A_StaticC = 89,
		Remote_A_StaticD = 90,
		Remote_A_StaticE = 91,
		Remote_A_Emiter1 = 92,
		Remote_A_Emiter2 = 93,
		Remote_A_Emiter3 = 94,
		Remote_A_Emiter4 = 95,
		Remote_A_Emiter5 = 96,
		Remote_A_Emiter6 = 97,
		Remote_A_Emiter7 = 98,
		Remote_A_Emiter8 = 99,
		Remote_A_Emiter9 = 100,
		Remote_A_Emiter10 = 101,
		Remote_A_Emiter11 = 102,
		Remote_A_Emiter12 = 103,
		Remote_A_Emiter13 = 104,
		Remote_A_Emiter14 = 105,
		Remote_A_Emiter15 = 106,
		Remote_A_Emiter16 = 107,
		Remote_A_Emiter17 = 108,
		Remote_A_Emiter18 = 109,
		Remote_A_Emiter19 = 110,
		Remote_A_Emiter20 = 111,
		Remote_A_Emiter21 = 112,
		Remote_ShipCreak1 = 113,
		Remote_ShipCreak2 = 114,
		Remote_ShipCreak3 = 115,
		Remote_ItemPickedUp = 116,
		Remote_ItemDropped1 = 117,
		Remote_ItemDropped2 = 118,
		Remote_MicGlitchA = 119,
		Remote_MicGlitchB = 120,
		Remote_MicGlitchC = 121,
		Remote_MicGlitchD = 122,
		Remote_MicGlitchE = 123,
		Remote_MicGlitchF = 124,
		Remote_MicGlitchG = 125,
		Remote_MicGlitchH = 126,
		Remote_MicGlitchJ = 127,
		Remote_MicGlitchK = 128,
		Remote_MicGlitchL = 129,
		Remote_MicGlitchM = 130,
		Remote_MicGlitchN = 131,
		Remote_MicGlitchO = 132,
		Remote_MicGlitchP = 133,
		Remote_MicGlitchQ = 134,
		Remote_MicGlitchR = 135,
		Remote_MicGlitchS = 136,
		Remote_MicGlitchT = 137,
		Remote_MicStaticA = 138,
		Remote_MicStaticE = 139
	}

	public static class AudioVolumeFactors
	{
		public static class OtherAudioVolumeFactors
		{
			public const float DRONE_EXPLOSION = 1f;

			public const float DRONE_TURRET = 1f;

			public const float DRONE_FUEL_GATHER = 1f;

			public const float DRONE_MOTION = 1f;

			public const float DRONE_TELEPORT = 1f;

			public const float DRONE_TRANSPORT = 1f;

			public const float DRONE_SONIC = 1f;

			public const float DRONE_STEALTH = 1f;

			public const float DRONE_SHIELD = 1f;

			public const float DRONE_TOW_LATCH = 1f;

			public const float DRONE_TOW_MOVE = 1f;

			public const float DRONE_PRY = 1f;

			public const float PROBE_HOVER = 1f;

			public const float SENSOR = 1f;

			public const float STUN_EXPLOSION = 1f;

			public const float MINE_EXPLOSION = 1f;

			public const float ROOM_VACUUM = 1f;

			public const float DEFENSE_FIRE = 1f;

			public const float ENEMY_BOT_FIRE = 1f;

			public const float ENEMY_BOT_IDLE = 1f;

			public const float ENEMY_BRUTE_HIT = 1f;
		}

		public const float AlertWarning = 1f;

		public const float AlertError = 1f;

		public const float EventRadiation = 1f;

		public const float Notification = 1f;

		public const float WeaponTriggered = 1f;

		public const float SensorTriggered = 1f;

		public const float SensorUntriggered = 1f;

		public const float TerminalOn = 1f;

		public const float TerminalOff = 1f;

		public const float ItemDetected = 1f;

		public const float FlagPlaced = 1f;

		public const float FlagRemoved = 1f;

		public const float A_MotherShip = 1f;

		public const float Docking1 = 1f;

		public const float Docking2 = 1f;

		public const float CommandSuccess = 1f;

		public const float CommandError = 1f;

		public const float BIOSFan = 1f;

		public const float BIOSBeep = 1f;

		public const float BIOSText1 = 1f;

		public const float BIOSText2 = 1f;

		public const float BIOSTextSingle = 1f;

		public const float UIEquip = 1f;

		public const float UIUnEquip = 1f;

		public const float UIOpenMenu = 1f;

		public const float UIExitMenu = 1f;

		public const float UISelectHigh = 1f;

		public const float UISelectLow = 1f;

		public const float UIChangeViewDown1 = 1f;

		public const float UIChangeViewDown2 = 1f;

		public const float UIChangeViewDown3 = 1f;

		public const float UIChangeViewUp1 = 1f;

		public const float UIChangeViewUp2 = 1f;

		public const float UIChangeViewUp3 = 1f;

		public const float UIDialogShow = 1f;

		public const float GalaxySelectNode = 1f;

		public const float UniverseWarpOut = 1f;

		public const float UniverseWarpIn = 1f;

		public const float Hint = 1f;

		public const float DroneCS_1 = 1f;

		public const float DroneCS_2 = 1f;

		public const float DroneCS_3 = 1f;

		public const float DroneCS_4 = 1f;

		public const float DroneCS_5 = 1f;

		public const float DroneCS_6 = 1f;

		public const float DroneCS_7 = 1f;

		public const float DroneCS_8 = 1f;

		public const float DroneCS_9 = 1f;

		public const float DroneCS_10 = 1f;

		public const float DroneCS_11 = 1f;

		public const float DroneCS_12 = 1f;

		public const float DroneCS_13 = 1f;

		public const float ShipCreak1 = 1f;

		public const float ShipCreak2 = 1f;

		public const float ShipCreak3 = 1f;

		public const float AsteroidHit = 1f;

		public const float ShipCannon = 1f;

		public const float ShipCollector = 1f;

		public const float ShipDecontaminate = 1f;

		public const float ShipOverload = 1f;

		public const float AVNTLaugh = 1f;

		public const float Schematic_DroneMapMove_Start = 1f;

		public const float Schematic_DroneMapMove_Sustain = 1f;

		public const float Schematic_ItemPickedUp = 1f;

		public const float Schematic_Interface = 1f;

		public const float Remote_DoorOpen = 1f;

		public const float Remote_DroneEngineAccel = 1f;

		public const float Remote_DroneEngineDeaccel = 1f;

		public const float Remote_DroneEngineLoop = 1f;

		public const float Remote_DroneMoveStart = 1f;

		public const float Remote_DroneMoveStop = 1f;

		public const float Remote_DroneMoveSustain = 1f;

		public const float Remote_DroneCollide1 = 1f;

		public const float Remote_DroneCollide2 = 1f;

		public const float Remote_DroneCollide3 = 1f;

		public const float Remote_Generator = 1f;

		public const float Remote_BotShot = 1f;

		public const float Remote_BotIdle = 1f;

		public const float Remote_Swarm = 1f;

		public const float Remote_BruteScream1 = 1f;

		public const float Remote_BruteScream2 = 1f;

		public const float Remote_BruteScream3 = 1f;

		public const float Remote_BruteScream4 = 1f;

		public const float Remote_A_HostShip1 = 1f;

		public const float Remote_A_HostShip2 = 1f;

		public const float Remote_A_HostShip3 = 1f;

		public const float Remote_A_StaticA = 1f;

		public const float Remote_A_StaticB = 1f;

		public const float Remote_A_StaticC = 1f;

		public const float Remote_A_StaticD = 1f;

		public const float Remote_A_StaticE = 1f;

		public const float Remote_A_Emiter1 = 1f;

		public const float Remote_A_Emiter2 = 1f;

		public const float Remote_A_Emiter3 = 1f;

		public const float Remote_A_Emiter4 = 1f;

		public const float Remote_A_Emiter5 = 1f;

		public const float Remote_A_Emiter6 = 1f;

		public const float Remote_A_Emiter7 = 1f;

		public const float Remote_A_Emiter8 = 1f;

		public const float Remote_A_Emiter9 = 1f;

		public const float Remote_A_Emiter10 = 1f;

		public const float Remote_A_Emiter11 = 1f;

		public const float Remote_A_Emiter12 = 1f;

		public const float Remote_A_Emiter13 = 1f;

		public const float Remote_A_Emiter14 = 1f;

		public const float Remote_A_Emiter15 = 1f;

		public const float Remote_A_Emiter16 = 1f;

		public const float Remote_A_Emiter17 = 1f;

		public const float Remote_A_Emiter18 = 1f;

		public const float Remote_A_Emiter19 = 1f;

		public const float Remote_A_Emiter20 = 1f;

		public const float Remote_A_Emiter21 = 1f;

		public const float Remote_ShipCreak1 = 1f;

		public const float Remote_ShipCreak2 = 1f;

		public const float Remote_ShipCreak3 = 1f;

		public const float Remote_ItemPickedUp = 1f;

		public const float Remote_ItemDropped1 = 1f;

		public const float Remote_ItemDropped2 = 1f;

		public const float Remote_MicGlitchA = 1f;

		public const float Remote_MicGlitchB = 1f;

		public const float Remote_MicGlitchC = 1f;

		public const float Remote_MicGlitchD = 1f;

		public const float Remote_MicGlitchE = 1f;

		public const float Remote_MicGlitchF = 1f;

		public const float Remote_MicGlitchG = 1f;

		public const float Remote_MicGlitchH = 1f;

		public const float Remote_MicGlitchJ = 1f;

		public const float Remote_MicGlitchK = 1f;

		public const float Remote_MicGlitchL = 1f;

		public const float Remote_MicGlitchM = 1f;

		public const float Remote_MicGlitchN = 1f;

		public const float Remote_MicGlitchO = 1f;

		public const float Remote_MicGlitchP = 1f;

		public const float Remote_MicGlitchQ = 1f;

		public const float Remote_MicGlitchR = 1f;

		public const float Remote_MicGlitchS = 1f;

		public const float Remote_MicGlitchT = 1f;

		public const float Remote_MicStaticA = 1f;

		public const float Remote_MicStaticE = 1f;
	}

	public struct AudioData
	{
		public AudioClip clip;

		public float volume;

		public AudioData(AudioClip clip, float volume)
		{
			this.clip = clip;
			this.volume = volume;
		}
	}

	private static Dictionary<SoundEnum, AudioData> sfxDict = new Dictionary<SoundEnum, AudioData>();

	private static Dictionary<SoundEnum, AudioSource> playing2DSFXs = null;

	private static AudioSource audioSource = null;

	public static bool IsInitalized { get; private set; }

	public static float MasterVolume
	{
		get
		{
			return GameSaveFile.Get("VOL_MASTER", GlobalSettings.SFXMaster);
		}
	}

	public static float AlertVolume
	{
		get
		{
			return GameSaveFile.Get("VOL_ALERTS", GlobalSettings.SFXVolume) * MasterVolume;
		}
	}

	public static float RemoteVolume
	{
		get
		{
			return GameSaveFile.Get("VOL_REMOTE", GlobalSettings.SFXVolumeRemote) * MasterVolume;
		}
	}

	public static float AmbienceVolume
	{
		get
		{
			return GameSaveFile.Get("VOL_AMBIENCE", GlobalSettings.SFXVolumeRemoteAmbience) * MasterVolume;
		}
	}

	public static float SchematicVolume
	{
		get
		{
			return GameSaveFile.Get("VOL_SCHEMATIC", GlobalSettings.SFXVolumeSchematic) * MasterVolume;
		}
	}

	public static float InterfaceVolume
	{
		get
		{
			return GameSaveFile.Get("VOL_INTERFACE", GlobalSettings.SFXVolumeInterface) * MasterVolume;
		}
	}

	public static float DroneCallSignalVolume
	{
		get
		{
			return GameSaveFile.Get("VOL_CALLSIGNAL", GlobalSettings.SFXDroneCallSignal) * MasterVolume;
		}
	}

	public static void Initialize()
	{
		if (!IsInitalized)
		{
			sfxDict.Add(SoundEnum.AlertWarning, LoadSFX("Audio/SFX/Alert_Beep_2"));
			sfxDict.Add(SoundEnum.AlertError, LoadSFX("Audio/SFX/Alert_Beep_6"));
			sfxDict.Add(SoundEnum.SensorTriggered, LoadSFX("Audio/SFX/SensorBeep3"));
			sfxDict.Add(SoundEnum.SensorUntriggered, LoadSFX("Audio/SFX/SensorBeep2"));
			sfxDict.Add(SoundEnum.EventRadiation, LoadSFX("Audio/SFX/alarmclock"));
			sfxDict.Add(SoundEnum.Notification, LoadSFX("Audio/SFX/hiBeep_2up"));
			sfxDict.Add(SoundEnum.WeaponTriggered, LoadSFX("Audio/SFX/hiBeep_2up"));
			LoadSFXIntoDict(SoundEnum.FlagPlaced);
			LoadSFXIntoDict(SoundEnum.FlagRemoved);
			LoadSFXIntoDict(SoundEnum.TerminalOn);
			LoadSFXIntoDict(SoundEnum.TerminalOff);
			LoadSFXIntoDict(SoundEnum.Docking1);
			LoadSFXIntoDict(SoundEnum.Docking2);
			LoadSFXIntoDict(SoundEnum.BIOSFan);
			LoadSFXIntoDict(SoundEnum.BIOSBeep);
			LoadSFXIntoDict(SoundEnum.BIOSText1);
			LoadSFXIntoDict(SoundEnum.BIOSText2);
			LoadSFXIntoDict(SoundEnum.BIOSTextSingle);
			LoadSFXIntoDict(SoundEnum.CommandSuccess);
			LoadSFXIntoDict(SoundEnum.CommandError);
			LoadSFXIntoDict(SoundEnum.Hint);
			LoadSFXIntoDict(SoundEnum.Schematic_Interface);
			LoadSFXIntoDict(SoundEnum.Remote_ShipCreak1);
			LoadSFXIntoDict(SoundEnum.Remote_ShipCreak2);
			LoadSFXIntoDict(SoundEnum.Remote_ShipCreak3);
			LoadSFXIntoDict(SoundEnum.AsteroidHit);
			LoadSFXIntoDict(SoundEnum.ShipCannon);
			LoadSFXIntoDict(SoundEnum.ShipCollector);
			LoadSFXIntoDict(SoundEnum.ShipDecontaminate);
			LoadSFXIntoDict(SoundEnum.ShipOverload);
			LoadSFXIntoDict(SoundEnum.UIEquip);
			LoadSFXIntoDict(SoundEnum.UIUnEquip);
			LoadSFXIntoDict(SoundEnum.UIOpenMenu);
			LoadSFXIntoDict(SoundEnum.UIExitMenu);
			LoadSFXIntoDict(SoundEnum.UISelectLow);
			LoadSFXIntoDict(SoundEnum.UISelectHigh);
			LoadSFXIntoDict(SoundEnum.UIUnEquip);
			LoadSFXIntoDict(SoundEnum.UIChangeViewDown1);
			LoadSFXIntoDict(SoundEnum.UIChangeViewDown2);
			LoadSFXIntoDict(SoundEnum.UIChangeViewDown3);
			LoadSFXIntoDict(SoundEnum.UIChangeViewUp1);
			LoadSFXIntoDict(SoundEnum.UIChangeViewUp2);
			LoadSFXIntoDict(SoundEnum.UIChangeViewUp3);
			LoadSFXIntoDict(SoundEnum.UIDialogShow);
			LoadSFXIntoDict(SoundEnum.GalaxySelectNode);
			LoadSFXIntoDict(SoundEnum.UniverseWarpOut);
			LoadSFXIntoDict(SoundEnum.UniverseWarpIn);
			LoadSFXIntoDict(SoundEnum.Remote_MicGlitchA);
			LoadSFXIntoDict(SoundEnum.Remote_MicGlitchB);
			LoadSFXIntoDict(SoundEnum.Remote_MicGlitchC);
			LoadSFXIntoDict(SoundEnum.Remote_MicGlitchD);
			LoadSFXIntoDict(SoundEnum.Remote_MicGlitchE);
			LoadSFXIntoDict(SoundEnum.Remote_MicGlitchF);
			LoadSFXIntoDict(SoundEnum.Remote_MicGlitchG);
			LoadSFXIntoDict(SoundEnum.Remote_MicGlitchH);
			LoadSFXIntoDict(SoundEnum.Remote_MicGlitchJ);
			LoadSFXIntoDict(SoundEnum.Remote_MicGlitchK);
			LoadSFXIntoDict(SoundEnum.Remote_MicGlitchL);
			LoadSFXIntoDict(SoundEnum.Remote_MicGlitchM);
			LoadSFXIntoDict(SoundEnum.Remote_MicGlitchN);
			LoadSFXIntoDict(SoundEnum.Remote_MicGlitchO);
			LoadSFXIntoDict(SoundEnum.Remote_MicGlitchP);
			LoadSFXIntoDict(SoundEnum.Remote_MicGlitchQ);
			LoadSFXIntoDict(SoundEnum.Remote_MicGlitchR);
			LoadSFXIntoDict(SoundEnum.Remote_MicGlitchS);
			LoadSFXIntoDict(SoundEnum.Remote_MicGlitchT);
			LoadSFXIntoDict(SoundEnum.Remote_MicStaticA);
			LoadSFXIntoDict(SoundEnum.Remote_MicStaticE);
			LoadSFXIntoDict(SoundEnum.AVNTLaugh);
			IsInitalized = true;
		}
	}

	public static string GetPath(SoundEnum key)
	{
		switch (key)
		{
		case SoundEnum.ItemDetected:
			return "Audio/SFX/item-detected";
		case SoundEnum.FlagPlaced:
			return "Audio/SFX/UI/UI-confirm-E";
		case SoundEnum.FlagRemoved:
			return "Audio/SFX/UI/UI-confirm-C";
		case SoundEnum.TerminalOn:
			return "Audio/SFX/terminal-activate";
		case SoundEnum.TerminalOff:
			return "Audio/SFX/terminal-deactivate";
		case SoundEnum.Docking1:
			return "Audio/SFX/docking2";
		case SoundEnum.Docking2:
			return "Audio/SFX/docking3-1";
		case SoundEnum.BIOSFan:
			return "Audio/SFX/BIOS_fan_intro_fadeout";
		case SoundEnum.BIOSBeep:
			return "Audio/SFX/BIOS_beep";
		case SoundEnum.BIOSText1:
			return "Audio/SFX/BIOS_text1";
		case SoundEnum.BIOSText2:
			return "Audio/SFX/BIOS_text2";
		case SoundEnum.BIOSTextSingle:
			return "Audio/SFX/BIOS_text_single";
		case SoundEnum.CommandSuccess:
			return "Audio/SFX/dataconfirm-3_tk";
		case SoundEnum.CommandError:
			return "Audio/SFX/datadenied-3_tk";
		case SoundEnum.Hint:
			return "Audio/SFX/Hint";
		case SoundEnum.A_MotherShip:
			return "Audio/Ambience/drone-mothership-C";
		case SoundEnum.DroneCS_1:
			return "Audio/SFX/Drone/cs11";
		case SoundEnum.DroneCS_2:
			return "Audio/SFX/Drone/cs12";
		case SoundEnum.DroneCS_3:
			return "Audio/SFX/Drone/cs13-tk1";
		case SoundEnum.DroneCS_4:
			return "Audio/SFX/Drone/cs13-tk2";
		case SoundEnum.DroneCS_5:
			return "Audio/SFX/Drone/cs14-tk";
		case SoundEnum.DroneCS_6:
			return "Audio/SFX/Drone/cs14-tk2";
		case SoundEnum.DroneCS_7:
			return "Audio/SFX/Drone/DroneCall_01";
		case SoundEnum.DroneCS_8:
			return "Audio/SFX/Drone/dronechirp-22-tk1";
		case SoundEnum.DroneCS_9:
			return "Audio/SFX/Drone/cs17";
		case SoundEnum.DroneCS_10:
			return "Audio/SFX/Drone/cs22_tk";
		case SoundEnum.DroneCS_11:
			return "Audio/SFX/Drone/cs19-2";
		case SoundEnum.DroneCS_12:
			return "Audio/SFX/Drone/cs20_tk";
		case SoundEnum.DroneCS_13:
			return "Audio/SFX/Drone/ui-beep-F-dry";
		case SoundEnum.ShipCreak1:
			return "Audio/SFX/Events/mothership-creak-6_1";
		case SoundEnum.ShipCreak2:
			return "Audio/SFX/Events/mothership-creak-7_1";
		case SoundEnum.ShipCreak3:
			return "Audio/SFX/Events/mothership-creak-7_2";
		case SoundEnum.UIEquip:
			return "Audio/SFX/UI/ui equip";
		case SoundEnum.UIUnEquip:
			return "Audio/SFX/UI/ui unequip";
		case SoundEnum.UIOpenMenu:
			return "Audio/SFX/UI/UI confirm_tk";
		case SoundEnum.UIExitMenu:
			return "Audio/SFX/UI/ui exit menu";
		case SoundEnum.UISelectLow:
			return "Audio/SFX/UI/ui select low";
		case SoundEnum.UISelectHigh:
			return "Audio/SFX/UI/ui select high";
		case SoundEnum.UIChangeViewDown1:
			return "Audio/SFX/UI/ui zoom in 1";
		case SoundEnum.UIChangeViewDown2:
			return "Audio/SFX/UI/ui zoom in 4";
		case SoundEnum.UIChangeViewDown3:
			return "Audio/SFX/UI/ui zoom in 6";
		case SoundEnum.UIChangeViewUp1:
			return "Audio/SFX/UI/ui zoom out 2";
		case SoundEnum.UIChangeViewUp2:
			return "Audio/SFX/UI/ui zoom out 3";
		case SoundEnum.UIChangeViewUp3:
			return "Audio/SFX/UI/ui zoom out 5";
		case SoundEnum.UIDialogShow:
			return "Audio/SFX/UI/UI confirm";
		case SoundEnum.GalaxySelectNode:
			return "Audio/SFX/galaxy/galaxy nav 1";
		case SoundEnum.UniverseWarpOut:
			return "Audio/SFX/galaxy/ship-warp_02";
		case SoundEnum.UniverseWarpIn:
			return "Audio/SFX/galaxy/ship-warp_02_in";
		case SoundEnum.AVNTLaugh:
			return "Audio/SFX/Easter/avnt_laugh_virusSpread";
		case SoundEnum.Remote_DroneMoveSustain:
			return "Audio/SFX/drone-move-sustain";
		case SoundEnum.Remote_DroneEngineLoop:
			return "Audio/SFX/drone-engine-loop";
		case SoundEnum.Remote_DroneCollide1:
			return "Audio/SFX/Drone/drone_collide_wall_1";
		case SoundEnum.Remote_DroneCollide2:
			return "Audio/SFX/Drone/drone_collide_wall_5";
		case SoundEnum.Remote_DroneCollide3:
			return "Audio/SFX/Drone/drone_collide_wall_7";
		case SoundEnum.Remote_DoorOpen:
			return "Audio/SFX/door-open";
		case SoundEnum.Remote_Generator:
			return "Audio/SFX/generator(loop)-filtered_tk";
		case SoundEnum.Remote_BotShot:
			return "Audio/SFX/Enemy/Turret fire (near)";
		case SoundEnum.Remote_BotIdle:
			return "Audio/SFX/Enemy/Patrol-bot-idle 2";
		case SoundEnum.Remote_Swarm:
			return "Audio/SFX/Enemy/swarm7-tk";
		case SoundEnum.Remote_BruteScream1:
			return "Audio/SFX/Enemy/brute-scream-A";
		case SoundEnum.Remote_BruteScream2:
			return "Audio/SFX/Enemy/brute-scream-B";
		case SoundEnum.Remote_BruteScream3:
			return "Audio/SFX/Enemy/brute-scream-C";
		case SoundEnum.Remote_BruteScream4:
			return "Audio/SFX/Enemy/brute-scream-D";
		case SoundEnum.Remote_A_HostShip1:
			return "Audio/Ambience/drone-hostship";
		case SoundEnum.Remote_A_HostShip2:
			return "Audio/Ambience/drone-hostship-12";
		case SoundEnum.Remote_A_HostShip3:
			return "Audio/Ambience/drone-hostship-k3";
		case SoundEnum.Remote_A_StaticA:
			return "Audio/Ambience/static-A";
		case SoundEnum.Remote_A_StaticB:
			return "Audio/Ambience/static-B";
		case SoundEnum.Remote_A_StaticC:
			return "Audio/Ambience/static-C";
		case SoundEnum.Remote_A_StaticD:
			return "Audio/Ambience/static-D";
		case SoundEnum.Remote_A_StaticE:
			return "Audio/Ambience/static-E";
		case SoundEnum.Remote_ItemPickedUp:
			return "Audio/SFX/pickup_raw";
		case SoundEnum.Remote_ItemDropped1:
			return "Audio/SFX/Upgrade/Drop_1";
		case SoundEnum.Remote_ItemDropped2:
			return "Audio/SFX/Upgrade/Drop_2";
		case SoundEnum.Remote_A_Emiter1:
			return "Audio/Ambience/equipment/emitter_airHiss";
		case SoundEnum.Remote_A_Emiter2:
			return "Audio/Ambience/equipment/emitter_clock";
		case SoundEnum.Remote_A_Emiter3:
			return "Audio/Ambience/equipment/emitter_computer";
		case SoundEnum.Remote_A_Emiter4:
			return "Audio/Ambience/equipment/emitter_drain";
		case SoundEnum.Remote_A_Emiter5:
			return "Audio/Ambience/equipment/emitter_electricSparks";
		case SoundEnum.Remote_A_Emiter6:
			return "Audio/Ambience/equipment/emitter_firePlace";
		case SoundEnum.Remote_A_Emiter7:
			return "Audio/Ambience/equipment/emitter_hailStorm";
		case SoundEnum.Remote_A_Emiter8:
			return "Audio/Ambience/equipment/emitter_horror";
		case SoundEnum.Remote_A_Emiter9:
			return "Audio/Ambience/equipment/emitter_mechanicalRhythm";
		case SoundEnum.Remote_A_Emiter10:
			return "Audio/Ambience/equipment/emitter_myEarsAreOnFire";
		case SoundEnum.Remote_A_Emiter11:
			return "Audio/Ambience/equipment/emitter_myFaceIsOnFire";
		case SoundEnum.Remote_A_Emiter12:
			return "Audio/Ambience/equipment/emitter_myLegsAreOnFire";
		case SoundEnum.Remote_A_Emiter13:
			return "Audio/Ambience/equipment/emitter_powerCycle";
		case SoundEnum.Remote_A_Emiter14:
			return "Audio/Ambience/equipment/emitter_powerTool";
		case SoundEnum.Remote_A_Emiter15:
			return "Audio/Ambience/equipment/emitter_toyTrain";
		case SoundEnum.Remote_A_Emiter16:
			return "Audio/Ambience/equipment/emitter_trash";
		case SoundEnum.Remote_A_Emiter17:
			return "Audio/Ambience/equipment/emitter_wind";
		case SoundEnum.Remote_A_Emiter18:
			return "Audio/Ambience/equipment/collision_nudge_1";
		case SoundEnum.Remote_A_Emiter19:
			return "Audio/Ambience/equipment/collision_nudge_2";
		case SoundEnum.Remote_A_Emiter20:
			return "Audio/Ambience/equipment/emitter_beepLight";
		case SoundEnum.Remote_A_Emiter21:
			return "Audio/Ambience/equipment/emitter_toiletBowl";
		case SoundEnum.Remote_ShipCreak1:
			return "Audio/SFX/Events/speaker-creak14";
		case SoundEnum.Remote_ShipCreak2:
			return "Audio/SFX/Events/speaker-creak16";
		case SoundEnum.Remote_ShipCreak3:
			return "Audio/SFX/Events/speaker-creak17";
		case SoundEnum.AsteroidHit:
			return "Audio/SFX/Events/Asteroid_hit_01";
		case SoundEnum.ShipCannon:
			return "Audio/SFX/Upgrade/ship-perm-cannon_short";
		case SoundEnum.ShipCollector:
			return "Audio/SFX/Upgrade/ship-perm-collector";
		case SoundEnum.ShipDecontaminate:
			return "Audio/SFX/Upgrade/ship-perm-decon-E";
		case SoundEnum.ShipOverload:
			return "Audio/SFX/Upgrade/ship-perm-overload-B";
		case SoundEnum.Schematic_DroneMapMove_Sustain:
			return "Audio/SFX/drone-mapmove-sustain";
		case SoundEnum.Schematic_ItemPickedUp:
			return "Audio/SFX/collect-ration";
		case SoundEnum.Schematic_Interface:
			return "Audio/SFX/mothership_beepAlert";
		case SoundEnum.Remote_MicGlitchA:
			return "Audio/SFX/Drone/mic-glitch-A";
		case SoundEnum.Remote_MicGlitchB:
			return "Audio/SFX/Drone/mic-glitch-B";
		case SoundEnum.Remote_MicGlitchC:
			return "Audio/SFX/Drone/mic-glitch-C";
		case SoundEnum.Remote_MicGlitchD:
			return "Audio/SFX/Drone/mic-glitch-D";
		case SoundEnum.Remote_MicGlitchE:
			return "Audio/SFX/Drone/mic-glitch-E";
		case SoundEnum.Remote_MicGlitchF:
			return "Audio/SFX/Drone/mic-glitch-F";
		case SoundEnum.Remote_MicGlitchG:
			return "Audio/SFX/Drone/mic-glitch-G";
		case SoundEnum.Remote_MicGlitchH:
			return "Audio/SFX/Drone/mic-glitch-H";
		case SoundEnum.Remote_MicGlitchJ:
			return "Audio/SFX/Drone/mic-glitch-J";
		case SoundEnum.Remote_MicGlitchK:
			return "Audio/SFX/Drone/mic-glitch-K";
		case SoundEnum.Remote_MicGlitchL:
			return "Audio/SFX/Drone/mic-glitch-L";
		case SoundEnum.Remote_MicGlitchM:
			return "Audio/SFX/Drone/mic-glitch-M";
		case SoundEnum.Remote_MicGlitchN:
			return "Audio/SFX/Drone/mic-glitch-N";
		case SoundEnum.Remote_MicGlitchO:
			return "Audio/SFX/Drone/mic-glitch-O";
		case SoundEnum.Remote_MicGlitchP:
			return "Audio/SFX/Drone/mic-glitch-P";
		case SoundEnum.Remote_MicGlitchQ:
			return "Audio/SFX/Drone/mic-glitch-Q";
		case SoundEnum.Remote_MicGlitchR:
			return "Audio/SFX/Drone/mic-glitch-R";
		case SoundEnum.Remote_MicGlitchS:
			return "Audio/SFX/Drone/mic-glitch-S";
		case SoundEnum.Remote_MicGlitchT:
			return "Audio/SFX/Drone/mic-glitch-T";
		case SoundEnum.Remote_MicStaticA:
			return "Audio/SFX/Drone/mic-static-A";
		case SoundEnum.Remote_MicStaticE:
			return "Audio/SFX/Drone/mic-static-E";
		default:
			Debug.LogError(string.Format("GetPath() doesn't have a path for the '{0}' sound", key));
			return string.Empty;
		}
	}

	public static AudioClip GetClip(SoundEnum key)
	{
		if (!sfxDict.ContainsKey(key))
		{
			sfxDict.Add(key, LoadSFX(GetPath(key)));
		}
		return sfxDict[key].clip;
	}

	public static void RemoveClip(SoundEnum key)
	{
		if (sfxDict.ContainsKey(key) && ResourceManager.UnloadAsset(GetPath(key)))
		{
			sfxDict.Remove(key);
		}
	}

	private static void LoadSFXIntoDict(SoundEnum sound)
	{
		if (!sfxDict.ContainsKey(sound))
		{
			sfxDict.Add(sound, LoadSFX(GetPath(sound)));
		}
	}

	private static AudioData LoadSFX(string path)
	{
		return LoadSFX(path, 1f);
	}

	private static AudioData LoadSFX(string path, float volume)
	{
		AudioClip audioClip = Resources.Load<AudioClip>(path);
		if (audioClip == null)
		{
			Debug.LogError("Clip not loaded! - " + path);
			return default(AudioData);
		}
		return new AudioData(audioClip, volume);
	}

	public static void Play2DSFX(SoundEnum key)
	{
		Play2DSFX(key, false);
	}

	public static void Play2DSFX(SoundEnum key, bool singlePlayingInstance)
	{
		Play2DSFX(key, AlertVolume, singlePlayingInstance);
	}

	public static void Play2DSFX(SoundEnum key, float volume)
	{
		Play2DSFX(key, volume, false);
	}

	public static void Play2DSFX(SoundEnum key, float volume, bool singlePlayingInstance)
	{
		if (DroneManager.Instance != null)
		{
			Play2DSFX(key, DroneManager.Instance.ActiveCamera.gameObject, volume, singlePlayingInstance);
		}
		else if (GalaxyMapManager.Instance != null)
		{
			Play2DSFX(key, GalaxyMapManager.Instance.GetComponent<Camera>().gameObject, volume, singlePlayingInstance);
		}
		else if (Camera.main != null)
		{
			Play2DSFX(key, Camera.main.gameObject, volume, singlePlayingInstance);
		}
	}

	public static void Play2DSFX(SoundEnum key, GameObject sourceGameObject, float volume)
	{
		Play2DSFX(key, sourceGameObject, volume, false);
	}

	public static void Play2DSFX(SoundEnum key, GameObject sourceGameObject, float volume, bool singlePlayingInstance)
	{
		if (sfxDict.ContainsKey(key))
		{
			if (!(sfxDict[key].clip != null))
			{
				return;
			}
			if (playing2DSFXs == null)
			{
				playing2DSFXs = new Dictionary<SoundEnum, AudioSource>();
			}
			AudioSource audioSource = null;
			if (playing2DSFXs.Count > 0 && playing2DSFXs.ContainsKey(key))
			{
				if (singlePlayingInstance && playing2DSFXs[key] != null && playing2DSFXs[key].isPlaying)
				{
					return;
				}
				Object.Destroy(playing2DSFXs[key]);
				playing2DSFXs.Remove(key);
			}
			if (playing2DSFXs.Count == 0 || !playing2DSFXs.ContainsKey(key))
			{
				volume = VolumeMultiplier(key, volume);
				audioSource = sourceGameObject.AddComponent<AudioSource>();
				audioSource.volume = volume;
				audioSource.playOnAwake = false;
				audioSource.loop = false;
				audioSource.spatialBlend = 0f;
				playing2DSFXs.Add(key, audioSource);
			}
			else
			{
				audioSource = playing2DSFXs[key];
			}
			audioSource.clip = sfxDict[key].clip;
			audioSource.Play();
		}
		else
		{
			Debug.LogError("No SFX audio clip for audio track: " + key);
		}
	}

	public static void PlaySFX(SoundEnum key)
	{
		PlaySFX(key, AlertVolume);
	}

	public static void PlaySFX(SoundEnum key, float volume)
	{
		if (DroneManager.Instance != null)
		{
			PlaySFX(key, DroneManager.Instance.ActiveCamera.transform.position, volume);
		}
		else if (GalaxyMapManager.Instance != null)
		{
			PlaySFX(key, GalaxyMapManager.Instance.GetComponent<Camera>().transform.position, volume);
		}
		else if (Camera.main != null)
		{
			PlaySFX(key, Camera.main.transform.position, volume);
		}
	}

	public static void PlaySFX(SoundEnum key, Vector3 pos)
	{
		PlaySFX(key, pos, AlertVolume);
	}

	public static void PlaySFX(SoundEnum key, Vector3 pos, float volume)
	{
		if (sfxDict.ContainsKey(key))
		{
			if (sfxDict[key].clip != null)
			{
				AudioSource.PlayClipAtPoint(sfxDict[key].clip, pos, sfxDict[key].volume * volume);
			}
		}
		else
		{
			Debug.LogError("No SFX audio clip for audio track: " + key);
		}
	}

	public static void Stop2DSFX(SoundEnum key)
	{
		if (playing2DSFXs != null && playing2DSFXs.Count > 0 && playing2DSFXs.ContainsKey(key))
		{
			if (playing2DSFXs[key] != null && playing2DSFXs[key].isPlaying)
			{
				playing2DSFXs[key].Stop();
			}
			Object.Destroy(playing2DSFXs[key]);
			playing2DSFXs.Remove(key);
		}
	}

	public static bool IsSoundPlaying(SoundEnum key)
	{
		return audioSource != null && audioSource.isPlaying;
	}

	public static float VolumeMultiplier(SoundEnum key, float volume)
	{
		switch (key)
		{
		case SoundEnum.AlertWarning:
			volume *= 1f;
			break;
		case SoundEnum.AlertError:
			volume *= 1f;
			break;
		case SoundEnum.EventRadiation:
			volume *= 1f;
			break;
		case SoundEnum.Notification:
			volume *= 1f;
			break;
		case SoundEnum.WeaponTriggered:
			volume *= 1f;
			break;
		case SoundEnum.SensorTriggered:
			volume *= 1f;
			break;
		case SoundEnum.SensorUntriggered:
			volume *= 1f;
			break;
		case SoundEnum.TerminalOn:
			volume *= 1f;
			break;
		case SoundEnum.TerminalOff:
			volume *= 1f;
			break;
		case SoundEnum.ItemDetected:
			volume *= 1f;
			break;
		case SoundEnum.FlagPlaced:
			volume *= 1f;
			break;
		case SoundEnum.FlagRemoved:
			volume *= 1f;
			break;
		case SoundEnum.A_MotherShip:
			volume *= 1f;
			break;
		case SoundEnum.Docking1:
			volume *= 1f;
			break;
		case SoundEnum.Docking2:
			volume *= 1f;
			break;
		case SoundEnum.CommandSuccess:
			volume *= 1f;
			break;
		case SoundEnum.CommandError:
			volume *= 1f;
			break;
		case SoundEnum.BIOSFan:
			volume *= 1f;
			break;
		case SoundEnum.BIOSBeep:
			volume *= 1f;
			break;
		case SoundEnum.BIOSText1:
			volume *= 1f;
			break;
		case SoundEnum.BIOSText2:
			volume *= 1f;
			break;
		case SoundEnum.BIOSTextSingle:
			volume *= 1f;
			break;
		case SoundEnum.UIEquip:
			volume *= 1f;
			break;
		case SoundEnum.UIUnEquip:
			volume *= 1f;
			break;
		case SoundEnum.UIOpenMenu:
			volume *= 1f;
			break;
		case SoundEnum.UIExitMenu:
			volume *= 1f;
			break;
		case SoundEnum.UISelectHigh:
			volume *= 1f;
			break;
		case SoundEnum.UISelectLow:
			volume *= 1f;
			break;
		case SoundEnum.UIChangeViewDown1:
			volume *= 1f;
			break;
		case SoundEnum.UIChangeViewDown2:
			volume *= 1f;
			break;
		case SoundEnum.UIChangeViewDown3:
			volume *= 1f;
			break;
		case SoundEnum.UIChangeViewUp1:
			volume *= 1f;
			break;
		case SoundEnum.UIChangeViewUp2:
			volume *= 1f;
			break;
		case SoundEnum.UIChangeViewUp3:
			volume *= 1f;
			break;
		case SoundEnum.UIDialogShow:
			volume *= 1f;
			break;
		case SoundEnum.GalaxySelectNode:
			volume *= 1f;
			break;
		case SoundEnum.UniverseWarpOut:
			volume *= 1f;
			break;
		case SoundEnum.UniverseWarpIn:
			volume *= 1f;
			break;
		case SoundEnum.Hint:
			volume *= 1f;
			break;
		case SoundEnum.DroneCS_1:
			volume *= 1f;
			break;
		case SoundEnum.DroneCS_2:
			volume *= 1f;
			break;
		case SoundEnum.DroneCS_3:
			volume *= 1f;
			break;
		case SoundEnum.DroneCS_4:
			volume *= 1f;
			break;
		case SoundEnum.DroneCS_5:
			volume *= 1f;
			break;
		case SoundEnum.DroneCS_6:
			volume *= 1f;
			break;
		case SoundEnum.DroneCS_7:
			volume *= 1f;
			break;
		case SoundEnum.DroneCS_8:
			volume *= 1f;
			break;
		case SoundEnum.DroneCS_9:
			volume *= 1f;
			break;
		case SoundEnum.DroneCS_10:
			volume *= 1f;
			break;
		case SoundEnum.DroneCS_11:
			volume *= 1f;
			break;
		case SoundEnum.DroneCS_12:
			volume *= 1f;
			break;
		case SoundEnum.DroneCS_13:
			volume *= 1f;
			break;
		case SoundEnum.ShipCreak1:
			volume *= 1f;
			break;
		case SoundEnum.ShipCreak2:
			volume *= 1f;
			break;
		case SoundEnum.ShipCreak3:
			volume *= 1f;
			break;
		case SoundEnum.AsteroidHit:
			volume *= 1f;
			break;
		case SoundEnum.ShipCannon:
			volume *= 1f;
			break;
		case SoundEnum.ShipCollector:
			volume *= 1f;
			break;
		case SoundEnum.ShipDecontaminate:
			volume *= 1f;
			break;
		case SoundEnum.ShipOverload:
			volume *= 1f;
			break;
		case SoundEnum.AVNTLaugh:
			volume *= 1f;
			break;
		case SoundEnum.Schematic_DroneMapMove_Start:
			volume *= 1f;
			break;
		case SoundEnum.Schematic_DroneMapMove_Sustain:
			volume *= 1f;
			break;
		case SoundEnum.Schematic_ItemPickedUp:
			volume *= 1f;
			break;
		case SoundEnum.Schematic_Interface:
			volume *= 1f;
			break;
		case SoundEnum.Remote_DoorOpen:
			volume *= 1f;
			break;
		case SoundEnum.Remote_DroneEngineAccel:
			volume *= 1f;
			break;
		case SoundEnum.Remote_DroneEngineDeaccel:
			volume *= 1f;
			break;
		case SoundEnum.Remote_DroneEngineLoop:
			volume *= 1f;
			break;
		case SoundEnum.Remote_DroneMoveStart:
			volume *= 1f;
			break;
		case SoundEnum.Remote_DroneMoveStop:
			volume *= 1f;
			break;
		case SoundEnum.Remote_DroneMoveSustain:
			volume *= 1f;
			break;
		case SoundEnum.Remote_DroneCollide1:
			volume *= 1f;
			break;
		case SoundEnum.Remote_DroneCollide2:
			volume *= 1f;
			break;
		case SoundEnum.Remote_DroneCollide3:
			volume *= 1f;
			break;
		case SoundEnum.Remote_Generator:
			volume *= 1f;
			break;
		case SoundEnum.Remote_BotShot:
			volume *= 1f;
			break;
		case SoundEnum.Remote_BotIdle:
			volume *= 1f;
			break;
		case SoundEnum.Remote_Swarm:
			volume *= 1f;
			break;
		case SoundEnum.Remote_BruteScream1:
			volume *= 1f;
			break;
		case SoundEnum.Remote_BruteScream2:
			volume *= 1f;
			break;
		case SoundEnum.Remote_BruteScream3:
			volume *= 1f;
			break;
		case SoundEnum.Remote_BruteScream4:
			volume *= 1f;
			break;
		case SoundEnum.Remote_A_HostShip1:
			volume *= 1f;
			break;
		case SoundEnum.Remote_A_HostShip2:
			volume *= 1f;
			break;
		case SoundEnum.Remote_A_HostShip3:
			volume *= 1f;
			break;
		case SoundEnum.Remote_A_StaticA:
			volume *= 1f;
			break;
		case SoundEnum.Remote_A_StaticB:
			volume *= 1f;
			break;
		case SoundEnum.Remote_A_StaticC:
			volume *= 1f;
			break;
		case SoundEnum.Remote_A_StaticD:
			volume *= 1f;
			break;
		case SoundEnum.Remote_A_StaticE:
			volume *= 1f;
			break;
		case SoundEnum.Remote_A_Emiter1:
			volume *= 1f;
			break;
		case SoundEnum.Remote_A_Emiter2:
			volume *= 1f;
			break;
		case SoundEnum.Remote_A_Emiter3:
			volume *= 1f;
			break;
		case SoundEnum.Remote_A_Emiter4:
			volume *= 1f;
			break;
		case SoundEnum.Remote_A_Emiter5:
			volume *= 1f;
			break;
		case SoundEnum.Remote_A_Emiter6:
			volume *= 1f;
			break;
		case SoundEnum.Remote_A_Emiter7:
			volume *= 1f;
			break;
		case SoundEnum.Remote_A_Emiter8:
			volume *= 1f;
			break;
		case SoundEnum.Remote_A_Emiter9:
			volume *= 1f;
			break;
		case SoundEnum.Remote_A_Emiter10:
			volume *= 1f;
			break;
		case SoundEnum.Remote_A_Emiter11:
			volume *= 1f;
			break;
		case SoundEnum.Remote_A_Emiter12:
			volume *= 1f;
			break;
		case SoundEnum.Remote_A_Emiter13:
			volume *= 1f;
			break;
		case SoundEnum.Remote_A_Emiter14:
			volume *= 1f;
			break;
		case SoundEnum.Remote_A_Emiter15:
			volume *= 1f;
			break;
		case SoundEnum.Remote_A_Emiter16:
			volume *= 1f;
			break;
		case SoundEnum.Remote_A_Emiter17:
			volume *= 1f;
			break;
		case SoundEnum.Remote_A_Emiter18:
			volume *= 1f;
			break;
		case SoundEnum.Remote_A_Emiter19:
			volume *= 1f;
			break;
		case SoundEnum.Remote_A_Emiter20:
			volume *= 1f;
			break;
		case SoundEnum.Remote_A_Emiter21:
			volume *= 1f;
			break;
		case SoundEnum.Remote_ShipCreak1:
			volume *= 1f;
			break;
		case SoundEnum.Remote_ShipCreak2:
			volume *= 1f;
			break;
		case SoundEnum.Remote_ShipCreak3:
			volume *= 1f;
			break;
		case SoundEnum.Remote_ItemPickedUp:
			volume *= 1f;
			break;
		case SoundEnum.Remote_ItemDropped1:
			volume *= 1f;
			break;
		case SoundEnum.Remote_ItemDropped2:
			volume *= 1f;
			break;
		case SoundEnum.Remote_MicGlitchA:
			volume *= 1f;
			break;
		case SoundEnum.Remote_MicGlitchB:
			volume *= 1f;
			break;
		case SoundEnum.Remote_MicGlitchC:
			volume *= 1f;
			break;
		case SoundEnum.Remote_MicGlitchD:
			volume *= 1f;
			break;
		case SoundEnum.Remote_MicGlitchE:
			volume *= 1f;
			break;
		case SoundEnum.Remote_MicGlitchF:
			volume *= 1f;
			break;
		case SoundEnum.Remote_MicGlitchG:
			volume *= 1f;
			break;
		case SoundEnum.Remote_MicGlitchH:
			volume *= 1f;
			break;
		case SoundEnum.Remote_MicGlitchJ:
			volume *= 1f;
			break;
		case SoundEnum.Remote_MicGlitchK:
			volume *= 1f;
			break;
		case SoundEnum.Remote_MicGlitchL:
			volume *= 1f;
			break;
		case SoundEnum.Remote_MicGlitchM:
			volume *= 1f;
			break;
		case SoundEnum.Remote_MicGlitchN:
			volume *= 1f;
			break;
		case SoundEnum.Remote_MicGlitchO:
			volume *= 1f;
			break;
		case SoundEnum.Remote_MicGlitchP:
			volume *= 1f;
			break;
		case SoundEnum.Remote_MicGlitchQ:
			volume *= 1f;
			break;
		case SoundEnum.Remote_MicGlitchR:
			volume *= 1f;
			break;
		case SoundEnum.Remote_MicGlitchS:
			volume *= 1f;
			break;
		case SoundEnum.Remote_MicGlitchT:
			volume *= 1f;
			break;
		case SoundEnum.Remote_MicStaticA:
			volume *= 1f;
			break;
		case SoundEnum.Remote_MicStaticE:
			volume *= 1f;
			break;
		}
		return volume;
	}
}
