using System;
using System.Collections.Generic;
using PlayerState;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class GameMusicHandler : MonoBehaviour
{
	[Serializable]
	public class SubBiomeMusic
	{
		public List<Biome> biomes;

		[ArrayElementTitle("TileType, Tileset")]
		public List<TileTypeAndTileset> tiles;

		public MusicRosterType roster;
	}

	public class EntityPlayingMusic
	{
		public Entity entity;

		public MusicSheetPlayedCD MusicSheetPlayedCD;

		public List<AudioManager.RunningSfxReference> runningSfx;

		public EntityPlayingMusic(Entity entity, MusicSheetPlayedCD musicSheetPlayedCD, List<AudioManager.RunningSfxReference> runningSfx)
		{
			this.entity = entity;
			MusicSheetPlayedCD = musicSheetPlayedCD;
			this.runningSfx = runningSfx;
		}
	}

	[ArrayElementTitle("roster")]
	public List<SubBiomeMusic> subBiomeMusics;

	private TimerSimple changeBiomeMusicTimer;

	private TimerSimple biomeMusicTimer;

	private const float MUSIC_MIN_PAUSE_LENGTH = 5f;

	private const float MUSIC_MAX_PAUSE_LENGTH = 5f;

	public Dictionary<MusicRosterType, TimerSimple> musicRostersOnCooldowns = new Dictionary<MusicRosterType, TimerSimple>();

	private TimerSimple delayToFadeInMusicAfterInstrumentPlayedTimer = new TimerSimple(1f, false, false);

	private EntityQuery musicAreaQuery;

	private const float MUSIC_FADE_TIME = 3f;

	private TimerSimple musicFadeTimer = new TimerSimple(3f);

	private Entity activeAreaMusicEntity;

	private MusicAreaCD activeMusicArea = new MusicAreaCD
	{
		musicRosterType = MusicRosterType.DONT_PLAY_MUSIC
	};

	private bool playedBiomeMusicPreviousFrame;

	public float tilesRequiredToKeepSubBiomeMusic;

	public float tilesRequiredToTriggerNewSubBiomeMusic;

	private const float SQ_DISTANCE_FROM_INSTRUMENT_TO_FADE_OUT_MUSIC = 400f;

	private readonly List<EntityPlayingMusic> activeInstrumentSongs = new List<EntityPlayingMusic>();

	private bool currentMusicIsBiomeMusic => Manager.music.IsMusicRosterOfType(activeMusicArea.musicRosterType, MusicType.Biome);

	private bool currentMusicIsDungeonMusic => Manager.music.IsMusicRosterOfType(activeMusicArea.musicRosterType, MusicType.Dungeon);

	private bool currentMusicIsDontPlayMusic => activeMusicArea.musicRosterType == MusicRosterType.DONT_PLAY_MUSIC;

	private bool isOkToStartMusic => !musicFadeTimer.isRunning;

	public MusicRosterType currentMusicRoster => activeMusicArea.musicRosterType;

	private void Start()
	{
		changeBiomeMusicTimer.Start(15f);
		MusicManager music = Manager.music;
		music.StopMusic();
		music.FadeOutVolume(0f);
		music.shuffle = true;
		music.repeat = false;
		playedBiomeMusicPreviousFrame = false;
		EntityQueryDesc entityQueryDesc = new EntityQueryDesc();
		entityQueryDesc.All = new ComponentType[2]
		{
			typeof(MusicAreaCD),
			typeof(LocalTransform)
		};
		EntityQueryDesc entityQueryDesc2 = entityQueryDesc;
		musicAreaQuery = Manager.ecs.GetClientEntityQuery(entityQueryDesc2);
	}

	private void LateUpdate()
	{
		Manager.audio.ambientSoundsHandler.GetNearbyTileData(out var tileCount).Complete();
		UpdateMusicRosterCooldowns();
		UpdateTargetMusic(tileCount);
		if (isOkToStartMusic)
		{
			if (currentMusicIsBiomeMusic)
			{
				UpdateBiomeMusic();
			}
			else
			{
				UpdateMusicArea();
			}
		}
		UpdatePlayerInstrumentSongs();
		bool flag = IsAnyonePlayingAnyInstrument();
		if (flag && !Manager.music.VolumeIsFadingOutOrHasFadedOut())
		{
			Manager.music.FadeOutVolume(1f);
		}
		else if (!flag && !Manager.music.VolumeIsFadingInOrHasFadedIn() && isOkToStartMusic)
		{
			if (!delayToFadeInMusicAfterInstrumentPlayedTimer.isRunning)
			{
				delayToFadeInMusicAfterInstrumentPlayedTimer.Start();
			}
			else if (delayToFadeInMusicAfterInstrumentPlayedTimer.isTimerElapsed)
			{
				Manager.music.FadeInVolume(2f);
				delayToFadeInMusicAfterInstrumentPlayedTimer.Stop();
			}
		}
	}

	private void UpdateMusicRosterCooldowns()
	{
		NativeList<MusicRosterType> nativeList = new NativeList<MusicRosterType>(Allocator.Temp);
		foreach (KeyValuePair<MusicRosterType, TimerSimple> musicRostersOnCooldown in musicRostersOnCooldowns)
		{
			if (musicRostersOnCooldown.Value.isTimerElapsed)
			{
				nativeList.Add(musicRostersOnCooldown.Key);
			}
		}
		foreach (MusicRosterType item in nativeList)
		{
			musicRostersOnCooldowns.Remove(item);
		}
		nativeList.Dispose();
	}

	private void UpdateTargetMusic(NativeHashMap<TileTypeAndTileset, int> nearbyTileCount)
	{
		MusicAreaCD musicAreaCD = GetActiveMusicArea(nearbyTileCount);
		MusicManager music = Manager.music;
		if (activeMusicArea.musicRosterType != musicAreaCD.musicRosterType)
		{
			activeMusicArea = musicAreaCD;
			if (music.IsPlaying())
			{
				music.repeat = false;
				float num = ((currentMusicIsBiomeMusic || currentMusicIsDungeonMusic || currentMusicIsDontPlayMusic) ? 3f : 0.5f);
				musicFadeTimer.Start(num);
				music.FadeOutVolume(num);
			}
			else
			{
				musicFadeTimer.Start(0f);
			}
		}
		if (musicFadeTimer.isRunning && musicFadeTimer.isTimerElapsed)
		{
			musicFadeTimer.Stop();
			music.StopMusic();
		}
	}

	private void UpdateBiomeMusic()
	{
		MusicManager music = Manager.music;
		if (music.currentMusicRosterType != activeMusicArea.musicRosterType)
		{
			music.SetNewMusicPlaylist(activeMusicArea.musicRosterType);
			music.PauseMusic();
		}
		if (!music.IsPlaying())
		{
			if (playedBiomeMusicPreviousFrame && (!changeBiomeMusicTimer.isRunning || changeBiomeMusicTimer.isTimerElapsed))
			{
				biomeMusicTimer.Start(UnityEngine.Random.Range(5f, 5f));
			}
			if ((!changeBiomeMusicTimer.isRunning || changeBiomeMusicTimer.isTimerElapsed) && (!biomeMusicTimer.isRunning || biomeMusicTimer.isTimerElapsed))
			{
				music.repeat = false;
				music.PlayRandomMusic();
				changeBiomeMusicTimer.Start(10f);
			}
		}
		playedBiomeMusicPreviousFrame = music.IsPlaying();
	}

	private void UpdateMusicArea()
	{
		MusicManager music = Manager.music;
		bool flag = activeMusicArea.maxCooldownToPlay > 0f;
		bool flag2 = flag && musicRostersOnCooldowns.ContainsKey(activeMusicArea.musicRosterType);
		if ((!flag && music.currentMusicRosterType != activeMusicArea.musicRosterType) || (flag && !flag2))
		{
			music.repeat = !flag;
			music.SetNewMusicPlaylist(activeMusicArea.musicRosterType);
			if (activeMusicArea.musicRosterType != MusicRosterType.DONT_PLAY_MUSIC)
			{
				music.PlayRandomMusic();
			}
			if (flag)
			{
				Unity.Mathematics.Random rng = PugRandom.GetRng();
				musicRostersOnCooldowns.Add(activeMusicArea.musicRosterType, TimerSimple.StartNew(rng.NextFloat(activeMusicArea.minCooldownToPlay, activeMusicArea.maxCooldownToPlay)));
			}
		}
	}

	private MusicAreaCD GetActiveMusicArea(NativeHashMap<TileTypeAndTileset, int> nearbyTileCount)
	{
		PlayerController player = Manager.main.player;
		MusicAreaCD result = new MusicAreaCD
		{
			musicRosterType = activeMusicArea.musicRosterType
		};
		if (activeAreaMusicEntity != Entity.Null && EntityUtility.HasComponentData<MusicAreaCD>(activeAreaMusicEntity, Manager.ecs.ClientWorld) && EntityUtility.GetComponentData<MusicAreaCD>(activeAreaMusicEntity, Manager.ecs.ClientWorld).isInactive)
		{
			result = default(MusicAreaCD);
		}
		activeAreaMusicEntity = Entity.Null;
		if (player == null)
		{
			return result;
		}
		if (EntityUtility.GetComponentData<PlayerStateCD>(player.entity, player.world).HasAnyState(PlayerStateEnum.Death) || Manager.load.IsScreenFadingOutOrBlack())
		{
			return new MusicAreaCD
			{
				musicRosterType = MusicRosterType.DONT_PLAY_MUSIC
			};
		}
		bool flag = false;
		foreach (SubBiomeMusic subBiomeMusic in subBiomeMusics)
		{
			if (!PlayerIsInBiome(subBiomeMusic.biomes))
			{
				continue;
			}
			int num = 0;
			foreach (TileTypeAndTileset tile in subBiomeMusic.tiles)
			{
				num += (nearbyTileCount.TryGetValue(tile, out var item) ? item : 0);
			}
			float num2 = ((currentMusicRoster == subBiomeMusic.roster) ? tilesRequiredToKeepSubBiomeMusic : tilesRequiredToTriggerNewSubBiomeMusic);
			if ((float)num > num2)
			{
				result = new MusicAreaCD
				{
					musicRosterType = subBiomeMusic.roster
				};
				flag = true;
				break;
			}
		}
		if (!flag && (changeBiomeMusicTimer.isTimerElapsed || !Manager.music.IsPlaying() || currentMusicIsDungeonMusic))
		{
			MusicRosterType musicRosterType = player.currentBiome switch
			{
				Biome.Slime => MusicRosterType.SLIME_BIOME, 
				Biome.Stone => MusicRosterType.STONE_BIOME, 
				Biome.Larva => MusicRosterType.LARVA_BIOME, 
				Biome.Nature => MusicRosterType.NATURE_BIOME, 
				Biome.Sea => MusicRosterType.SEA_BIOME, 
				Biome.Desert => MusicRosterType.DESERT_BIOME, 
				Biome.Crystal => MusicRosterType.CRYSTAL_BIOME, 
				Biome.Passage => MusicRosterType.PASSAGE_BIOME, 
				Biome.Excavation => MusicRosterType.EXCAVATION_BIOME, 
				_ => MusicRosterType.DONT_PLAY_MUSIC, 
			};
			if (musicRosterType != MusicRosterType.DONT_PLAY_MUSIC)
			{
				result = new MusicAreaCD
				{
					musicRosterType = musicRosterType
				};
			}
		}
		NativeArray<LocalTransform> nativeArray = musicAreaQuery.ToComponentDataArray<LocalTransform>(Allocator.Temp);
		NativeArray<MusicAreaCD> nativeArray2 = musicAreaQuery.ToComponentDataArray<MusicAreaCD>(Allocator.Temp);
		NativeArray<Entity> nativeArray3 = musicAreaQuery.ToEntityArray(Allocator.Temp);
		float num3 = float.MaxValue;
		int num4 = -1;
		for (int i = 0; i < nativeArray.Length; i++)
		{
			if (nativeArray2[i].isInactive)
			{
				continue;
			}
			float num5 = math.length(nativeArray[i].Position - (float3)player.WorldPosition);
			float num6 = ((nativeArray2[i].musicRosterType == activeMusicArea.musicRosterType) ? nativeArray2[i].stopAtDistance : nativeArray2[i].startAtDistance);
			if (num5 < num6)
			{
				int prio = nativeArray2[i].prio;
				if (prio > num4 || (prio == num4 && num5 < num3))
				{
					num4 = prio;
					result = nativeArray2[i];
					num3 = num5;
					activeAreaMusicEntity = nativeArray3[i];
				}
			}
		}
		nativeArray.Dispose();
		nativeArray2.Dispose();
		return result;
	}

	private bool PlayerIsInBiome(List<Biome> biomes)
	{
		if (Manager.main.player == null)
		{
			return false;
		}
		Biome currentBiome = Manager.main.player.currentBiome;
		foreach (Biome biome in biomes)
		{
			if (biome == currentBiome)
			{
				return true;
			}
		}
		return false;
	}

	private bool IsAnyonePlayingAnyInstrument()
	{
		PlayerController player = Manager.main.player;
		if (player == null)
		{
			return false;
		}
		if (player.instrumentHandler.IsPlayingInstrument)
		{
			return true;
		}
		foreach (PlayerController nonLocalPlayer in Manager.main.nonLocalPlayers)
		{
			if (EntityUtility.TryGetComponentData<PlayerStateCD>(nonLocalPlayer.entity, nonLocalPlayer.world, out var value) && value.HasAnyState(PlayerStateEnum.PlayingInstrument) && math.distancesq(EntityUtility.GetComponentData<LocalTransform>(nonLocalPlayer.entity, Manager.ecs.ClientWorld).Position, player.WorldPosition) < 400f)
			{
				return true;
			}
		}
		return false;
	}

	private void UpdatePlayerInstrumentSongs()
	{
		for (int num = activeInstrumentSongs.Count - 1; num >= 0; num--)
		{
			EntityPlayingMusic entityPlayingMusic = activeInstrumentSongs[num];
			bool num2 = EntityUtility.HasComponentData<MusicSheetPlayedCD>(entityPlayingMusic.entity, Manager.ecs.ClientWorld);
			MusicSheetPlayedCD musicSheetPlayedCD = (num2 ? EntityUtility.GetComponentData<MusicSheetPlayedCD>(entityPlayingMusic.entity, Manager.ecs.ClientWorld) : default(MusicSheetPlayedCD));
			if (!num2 || !musicSheetPlayedCD.Equals(entityPlayingMusic.MusicSheetPlayedCD))
			{
				foreach (AudioManager.RunningSfxReference item in activeInstrumentSongs[num].runningSfx)
				{
					item.FadeOutAndStop(1f);
				}
				activeInstrumentSongs.RemoveAt(num);
			}
		}
		foreach (PlayerController allPlayer in Manager.main.allPlayers)
		{
			bool flag = false;
			foreach (EntityPlayingMusic activeInstrumentSong in activeInstrumentSongs)
			{
				if (activeInstrumentSong.entity == allPlayer.entity)
				{
					flag = true;
					break;
				}
			}
			if (flag || !EntityUtility.TryGetComponentData<MusicSheetPlayedCD>(allPlayer.entity, allPlayer.world, out var value) || value.currentSheetPlayed == ObjectID.None || !EntityUtility.TryGetComponentData<EquippedObjectCD>(allPlayer.entity, allPlayer.world, out var value2) || !PugDatabase.HasComponent<InstrumentCD>(value2.containedObject.objectData))
			{
				continue;
			}
			InstrumentType instrumentType = PugDatabase.GetComponent<InstrumentCD>(value2.containedObject.objectData).instrumentType;
			InstrumentSongInfoCD component = PugDatabase.GetComponent<InstrumentSongInfoCD>(value.currentSheetPlayed);
			List<AudioManager.RunningSfxReference> list = new List<AudioManager.RunningSfxReference>();
			AudioManager.SfxFollowTransform(component.GetSongSfxTableID(instrumentType), allPlayer.transform, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.INSTRUMENTS, reuseSfxs: false, playOnGamepad: false, list);
			if (list.Count <= 0)
			{
				continue;
			}
			foreach (AudioManager.RunningSfxReference item2 in list)
			{
				item2.FadeIn(2f, startVolumeAtZero: true);
			}
			activeInstrumentSongs.Add(new EntityPlayingMusic(allPlayer.entity, value, list));
		}
		for (int i = 0; i < activeInstrumentSongs.Count; i++)
		{
			EntityPlayingMusic entityPlayingMusic2 = activeInstrumentSongs[i];
			for (int j = 0; j < entityPlayingMusic2.runningSfx.Count; j++)
			{
				AudioManager.RunningSfxReference runningSfxReference = entityPlayingMusic2.runningSfx[j];
				float num3 = Time.time % runningSfxReference.ClipLength;
				if (Mathf.Abs(runningSfxReference.Time - num3) > 0.05f)
				{
					runningSfxReference.SetTime(num3);
				}
			}
		}
	}
}
