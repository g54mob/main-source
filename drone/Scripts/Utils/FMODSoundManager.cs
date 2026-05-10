using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public static class FMODSoundManager
{
	private static SoundReferencesSO soundReferencesSO;

	private static bool gameStarted;

	private static EventInstance music;

	private static EventInstance ambience;

	private static List<EventInstance> droneSounds;

	public static void PlaySound(SoundEffectType effectType, Vector3 position)
	{
		switch (effectType)
		{
		case SoundEffectType.HarvestGrass:
			RuntimeManager.PlayOneShot(soundReferencesSO.OnHarvestHay, position);
			break;
		case SoundEffectType.HarvestBush:
			RuntimeManager.PlayOneShot(soundReferencesSO.OnHarvestBush, position);
			break;
		case SoundEffectType.HarvestTree:
			RuntimeManager.PlayOneShot(soundReferencesSO.OnHarvestTree, position);
			break;
		case SoundEffectType.HarvestCarrot:
			RuntimeManager.PlayOneShot(soundReferencesSO.OnHarvestCarrot, position);
			break;
		case SoundEffectType.HarvestPumpkin:
			RuntimeManager.PlayOneShot(soundReferencesSO.OnHarvestPumpkin, position);
			break;
		case SoundEffectType.HarvestSunflower:
			RuntimeManager.PlayOneShot(soundReferencesSO.OnHarvestSunflower, position);
			break;
		case SoundEffectType.HarvestCactus:
			RuntimeManager.PlayOneShot(soundReferencesSO.OnHarvestCactus, position);
			break;
		case SoundEffectType.HarvestTreasureChest:
			RuntimeManager.PlayOneShot(soundReferencesSO.OnHarvestTreasureChest, position);
			break;
		case SoundEffectType.Plant:
			RuntimeManager.PlayOneShot(soundReferencesSO.OnPlant, position);
			break;
		case SoundEffectType.Till:
			RuntimeManager.PlayOneShot(soundReferencesSO.OnTill, position);
			break;
		case SoundEffectType.PickUpItem:
			RuntimeManager.PlayOneShot(soundReferencesSO.OnItemPickup, position);
			break;
		case SoundEffectType.UseWater:
			RuntimeManager.PlayOneShot(soundReferencesSO.OnUseWater, position);
			break;
		case SoundEffectType.UseFertilizer:
			RuntimeManager.PlayOneShot(soundReferencesSO.OnUseFertilizer, position);
			break;
		case SoundEffectType.SwapPlants:
			RuntimeManager.PlayOneShot(soundReferencesSO.OnSwapPlants, position);
			break;
		case SoundEffectType.SpawnMaze:
			RuntimeManager.PlayOneShot(soundReferencesSO.OnSpawnMaze, position);
			break;
		case SoundEffectType.DinosaurEatApple:
			RuntimeManager.PlayOneShot(soundReferencesSO.OnDinosaurEatApple, position);
			break;
		case SoundEffectType.DinosaurDie:
			RuntimeManager.PlayOneShot(soundReferencesSO.OnDinosaurDeath, position);
			break;
		case SoundEffectType.Unlock:
			RuntimeManager.PlayOneShot(soundReferencesSO.OnUnlock, position);
			break;
		case SoundEffectType.ButtonHovered:
			RuntimeManager.PlayOneShot(soundReferencesSO.ButtonHovered, position);
			break;
		case SoundEffectType.ButtonPressed:
			RuntimeManager.PlayOneShot(soundReferencesSO.ButtonPressed, position);
			break;
		}
	}

	public static void GameStart(SoundReferencesSO scriptableObjectInstance)
	{
		if (!gameStarted)
		{
			gameStarted = true;
			soundReferencesSO = scriptableObjectInstance;
			music = RuntimeManager.CreateInstance(soundReferencesSO.Music);
			ambience = RuntimeManager.CreateInstance(soundReferencesSO.Ambience);
			ambience.start();
			music.start();
			droneSounds = new List<EventInstance> { CreateDroneSoundInstance() };
		}
	}

	private static EventInstance CreateDroneSoundInstance()
	{
		EventInstance result = RuntimeManager.CreateInstance(soundReferencesSO.DroneSound);
		result.start();
		return result;
	}

	public static void zoomLevelField(float zoom)
	{
		RuntimeManager.StudioSystem.setParameterByName("zoom", zoom);
	}

	public static void StopMusic()
	{
	}

	public static void OpenMenu()
	{
	}

	public static void CloseMenu()
	{
		music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
	}

	public static void UpdateDroneParams((float droneSpeed, Vector3 position)[] drones)
	{
		if (drones.Length < droneSounds.Count)
		{
			for (int i = drones.Length; i < droneSounds.Count; i++)
			{
				droneSounds[i].stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
				droneSounds[i].release();
			}
			droneSounds.RemoveRange(drones.Length, droneSounds.Count - drones.Length);
		}
		else if (drones.Length > droneSounds.Count)
		{
			for (int j = droneSounds.Count; j < drones.Length; j++)
			{
				droneSounds.Add(CreateDroneSoundInstance());
			}
		}
		for (int k = 0; k < drones.Length; k++)
		{
			droneSounds[k].set3DAttributes(drones[k].position.To3DAttributes());
			droneSounds[k].setParameterByName("droneSpeed", drones[k].droneSpeed);
		}
	}

	public static void SetGameSpeedParam(float gameSpeed)
	{
		RuntimeManager.StudioSystem.setParameterByName("gameSpeed", gameSpeed);
	}

	public static void SetMusicVCAVolume(float volume)
	{
		RuntimeManager.GetVCA(soundReferencesSO.musicVCA).setVolume(volume);
	}

	public static void SetAmbienceVCAVolume(float volume)
	{
		RuntimeManager.GetVCA(soundReferencesSO.ambienceVCA).setVolume(volume);
	}

	public static void SetSFXVCAVolume(float volume)
	{
		RuntimeManager.GetVCA(soundReferencesSO.sfxVCA).setVolume(volume);
	}

	public static void SetUIVCAVolume(float volume)
	{
		RuntimeManager.GetVCA(soundReferencesSO.uiVCA).setVolume(volume);
	}

	public static void SetDroneVCAVolume(float volume)
	{
		RuntimeManager.GetVCA(soundReferencesSO.droneVCA).setVolume(volume);
	}
}
