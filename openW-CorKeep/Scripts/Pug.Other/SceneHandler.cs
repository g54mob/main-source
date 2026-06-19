using System;
using System.Collections.Generic;
using System.IO;
using PlayerState;
using Pug.UnityExtensions;
using Unity.Entities;
using Unity.NetCode;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SceneHandler : MonoBehaviour
{
	public enum SceneType
	{
		MAIN_GAME = 0,
		TITLE = 1,
		INTRO = 2,
		DEV = 3,
		LOADING = 4,
		OUTRO = 5,
		BENCHMARK = 6
	}

	[Serializable]
	public class PostProcessBlending
	{
		public PostProcessProfile postProcessProfile;

		[Range(0f, 1f)]
		public float weight = 1f;
	}

	[Serializable]
	public class MapVariation
	{
		public List<GameObject> rootObjects;
	}

	[Header(" - Scene settings - ")]
	[SerializeField]
	private SceneType sceneHandlerType;

	public List<MenuHelperButtons.HelpButtonTypes> helpButtonsToShow;

	[Header(" - Audio settings - ")]
	public bool ignoreMusicRosterSetting;

	public bool startMusicAutomatically = true;

	public bool restartMusic = true;

	public bool stopMusic;

	public MusicRosterType musicRoster;

	public bool fadeInAudioOnStart = true;

	[Header(" - Cutscene handler -")]
	public CutsceneHandler optionalCutsceneHandler;

	[Header(" - Title -")]
	public TitleScreenAnimator titleScreenAnimator;

	[Header(" - Post processing -")]
	public bool useBloom = true;

	public List<PostProcessBlending> postProcessProfiles;

	public List<MapVariation> mapVariations;

	[Header(" - Optimization -")]
	public bool skipFrustumCullingLogicOptimization;

	[NonSerialized]
	public bool playerWantsToExitToTitle;

	private bool sceneHandlerMarkedAsReady;

	private NetworkTick startTick;

	private static bool hasCheckedCommandLine;

	public bool alwaysShowIntroDebug;

	public bool isIntro => sceneHandlerType == SceneType.INTRO;

	public bool isOutro => sceneHandlerType == SceneType.OUTRO;

	public bool isTitle => sceneHandlerType == SceneType.TITLE;

	public bool isInGame
	{
		get
		{
			SceneType sceneType = sceneHandlerType;
			return sceneType == SceneType.MAIN_GAME || sceneType == SceneType.DEV || sceneType == SceneType.BENCHMARK;
		}
	}

	public bool isDev => sceneHandlerType == SceneType.DEV;

	public bool isGameStartUpLoading => sceneHandlerType == SceneType.LOADING;

	public bool cutsceneIsPlaying
	{
		get
		{
			if (optionalCutsceneHandler != null)
			{
				return optionalCutsceneHandler.isPlaying;
			}
			return false;
		}
	}

	public bool isSceneHandlerReady => sceneHandlerMarkedAsReady;

	private void Awake()
	{
		if (Manager.load.IsApplicationQuitting())
		{
			return;
		}
		if (isInGame)
		{
			Manager.FindAndAssignMultiMap();
		}
		if (mapVariations.Count > 0)
		{
			int num = UnityEngine.Random.Range(0, mapVariations.Count);
			for (int i = 0; i < mapVariations.Count; i++)
			{
				bool active = num == i;
				foreach (GameObject rootObject in mapVariations[i].rootObjects)
				{
					rootObject.SetActive(active);
				}
			}
		}
		Manager.main.currentSceneHandler = this;
		StartMusic();
		if (isInGame)
		{
			if (Manager.ecs.ClientWorld == null)
			{
				Manager.prefs.UpdateSeason();
				if (sceneHandlerType == SceneType.BENCHMARK)
				{
					Manager.saves.SetCharacterId(60);
					Manager.saves.UseCustomCharacterDataProvider(() => File.ReadAllBytes(Application.streamingAssetsPath + "/BenchmarkData/character.json"));
					Manager.saves.SetWorldId(30);
					Manager.saves.UseCustomWorldDataProvider(() => File.ReadAllBytes(Application.streamingAssetsPath + "/BenchmarkData/world.gzip"), () => File.ReadAllBytes(Application.streamingAssetsPath + "/BenchmarkData/world.worldinfo"));
				}
				WallClockTimer frameWorkloadTimer = new WallClockTimer(TimeSpan.FromMilliseconds(100.0));
				Manager.ecs.StartEcs(startClient: true, Manager.saves.GetWorldId(), frameWorkloadTimer, delegate(bool result)
				{
					if (!result)
					{
						Debug.LogWarning("SceneHandler.Awake: ECS start failed or was cancelled.");
					}
					else
					{
						Manager.networking.Connect(default(ServerConnectionInfo), delegate(bool b)
						{
							if (!b)
							{
								Debug.LogError("connect to local server failed");
								Entity entity = Manager.ecs.ClientWorld.EntityManager.CreateEntity(typeof(ConnectionState));
								Manager.ecs.ClientWorld.EntityManager.SetComponentData(entity, new ConnectionState
								{
									CurrentState = ConnectionState.State.Disconnected
								});
							}
						});
					}
				});
			}
			Manager.ecs.EnableSave();
		}
		else if (sceneHandlerType == SceneType.TITLE)
		{
			Manager.prefs.UpdateSeason();
		}
	}

	public void Start()
	{
		Manager.camera.UpdateSceneHandler(this);
		if (fadeInAudioOnStart)
		{
			Manager.audio.FadeInAudioEffects(0.5f);
		}
		Manager.ui.OnNewSceneHandler(this);
	}

	private void Update()
	{
		UpdateExitingToTitle();
		if (sceneHandlerMarkedAsReady)
		{
			return;
		}
		if (Manager.load.GetNameOfCurrentScene() != "Main")
		{
			SetSceneHandlerReady();
		}
		else
		{
			if (!Manager.ecs.WorldsAreLoaded || Manager.ecs.ClientWorld == null)
			{
				return;
			}
			World clientWorld = Manager.ecs.ClientWorld;
			EntityQueryDesc entityQueryDesc = new EntityQueryDesc();
			entityQueryDesc.All = new ComponentType[2]
			{
				typeof(Prefab),
				typeof(GhostType)
			};
			entityQueryDesc.Options = EntityQueryOptions.IncludeDisabledEntities;
			EntityQueryDesc entityQueryDesc2 = entityQueryDesc;
			using EntityQuery entityQuery = clientWorld.EntityManager.CreateEntityQuery(entityQueryDesc2);
			using EntityQuery entityQuery2 = clientWorld.EntityManager.CreateEntityQuery(typeof(GhostCollection));
			if (entityQuery2.IsEmpty || entityQuery.IsEmpty)
			{
				return;
			}
			if (!startTick.IsValid)
			{
				using (EntityQuery entityQuery3 = clientWorld.EntityManager.CreateEntityQuery(typeof(NetworkTime)))
				{
					startTick = entityQuery3.GetSingleton<NetworkTime>().ServerTick;
					return;
				}
			}
			using EntityQuery entityQuery4 = clientWorld.EntityManager.CreateEntityQuery(typeof(NetworkSnapshotAck));
			NetworkSnapshotAck singleton = entityQuery4.GetSingleton<NetworkSnapshotAck>();
			NetworkTick old = startTick;
			old.Add(30u);
			if (singleton.LastReceivedSnapshotByLocal.IsNewerThan(old))
			{
				Debug.Log("has loaded enough from server; ready to fade in");
				SetSceneHandlerReady();
			}
		}
	}

	private void StartMusic()
	{
		MusicManager music = Manager.music;
		if (!ignoreMusicRosterSetting)
		{
			music.SetNewMusicPlaylist(musicRoster);
		}
		if (startMusicAutomatically)
		{
			music.shuffle = true;
			music.repeat = true;
			if (!music.IsPlaying() || restartMusic)
			{
				music.PlayRandomMusic();
			}
			music.FadeInVolume(1f);
		}
		else if (stopMusic)
		{
			music.StopMusic();
		}
		else
		{
			music.shuffle = false;
			music.repeat = false;
		}
	}

	private void SetSceneHandlerReady()
	{
		alwaysShowIntroDebug = false;
		Manager.load.MakeSceneHandlerReady();
		sceneHandlerMarkedAsReady = true;
		if (optionalCutsceneHandler != null && (Manager.load.nameOfPreviousScene == "Intro" || alwaysShowIntroDebug))
		{
			if (!optionalCutsceneHandler.isPlaying)
			{
				optionalCutsceneHandler.StartPlaying();
			}
			return;
		}
		WorldInfo worldInfo = Manager.saves.GetWorldInfo();
		if (worldInfo != null && worldInfo.worldGenerationType == WorldGenerationType.Classic && Manager.load.GetNameOfCurrentScene() == "Main")
		{
			Manager.ui.chatWindow.AddInfoText(ChatWindow.MessageTextType.StartingClassicWorld);
		}
	}

	private void UpdateExitingToTitle()
	{
		if (!playerWantsToExitToTitle)
		{
			return;
		}
		PlayerController player = Manager.main.player;
		if (player != null)
		{
			PlayerStateCD componentData = EntityUtility.GetComponentData<PlayerStateCD>(player.entity, player.world);
			CharacterTypeCD componentData2 = EntityUtility.GetComponentData<CharacterTypeCD>(player.entity, player.world);
			if ((componentData.HasAnyState(PlayerStateEnum.Death) && !componentData2.IsHardcore()) || componentData.HasAnyState(PlayerStateEnum.Teleporting))
			{
				return;
			}
		}
		Manager.load.QueueScene("Title", 1f, 0.5f, FadePresets.blackToBlack, setFadeValueTo1: false, 1);
		if (player != null)
		{
			player.SetInvincibility(value: true);
			player.inputModule.DisableInputFor();
		}
		playerWantsToExitToTitle = false;
	}
}
