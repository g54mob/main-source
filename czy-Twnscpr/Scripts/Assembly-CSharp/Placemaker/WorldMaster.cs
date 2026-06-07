using System;
using System.Collections.Generic;
using System.Diagnostics;
using Placemaker.Audio;
using Placemaker.Graphs;
using Placemaker.Life;
using Placemaker.Modules;
using Placemaker.Props;
using Placemaker.SceneProcessing;
using Placemaker.Ui;
using UnityEngine;

namespace Placemaker
{
	public class WorldMaster : MonoBehaviour, IOnScenePostProcess
	{
		public enum YieldType : byte
		{
			KeepGoing = 0,
			SkipFrame = 1
		}

		public enum State : byte
		{
			DoNothing = 0,
			StartLoad = 1,
			PreLoad = 2,
			LoadCleanupQubes0 = 3,
			LoadCleanupProps0 = 4,
			ResetPropAnimator = 5,
			AwaitDim = 6,
			BeginLoadGraph = 7,
			LoadGraph = 8,
			LoadGraphFocus = 9,
			LoadOthers = 10,
			LoadCleanupQubes1 = 11,
			LoadCleanupProps1 = 12,
			LoadGraph1 = 13,
			LoadGridFocus = 14,
			LoadCentralGridBit = 15,
			LoadWaveFunctionCollapse0 = 16,
			LoadApplyModules = 17,
			LoadBakeShadows0 = 18,
			NormalStart = 19,
			GraphFocus = 20,
			GridFocus = 21,
			Graph = 22,
			BakeShadow0 = 23,
			WaveFunctionCollapse0 = 24,
			WaveFunctionCollapse1 = 25,
			BakeShadow1 = 26,
			WaveFunctionCollapseDecor = 27,
			BakeShadow2 = 28,
			WaveFunctionCollapseReset = 29,
			Sandbanker = 30,
			GraphRefillPools = 31,
			Props = 32,
			PropAchievements = 33,
			BakeShadow3 = 34,
			SpawnBirds = 35,
			CleanupRemovedQubes = 36,
			CleanupProps = 37,
			ResetPropPlacer = 38,
			IterateRefillWorldMeshPools = 39,
			SaveToUrl = 40,
			GridBits = 41,
			RefreshSaveSystem = 42,
			Done = 43
		}

		public interface IOnOnEnable
		{
			void OnOnEnable(WorldMaster worldMaster);
		}

		public UiMaster uiMaster;

		public GridGenerator grid;

		public Maker maker;

		public Graph graph;

		public ModuleLibrary moduleLibrary;

		public WorldMeshes worldMeshes;

		public WaveFunctionCollapse waveFunctionCollapse;

		public AoBaker aoBaker;

		public HoverHightlight hoverHightlight;

		public MaterialMaster materialMaster;

		public ClickEffect clickEffect;

		public VoxelBobEffect voxelBobEffect;

		public ModuleBuilder moduleBuilder;

		public TextSaveSystem textSaveSystem;

		public HoverData hoverData;

		public PropPlacer propPlacer;

		public BorderDrawer borderDrawer;

		public BirdFlock flock;

		public Sandbanker sandbanker;

		public AudioSourcePool audioSourcePool;

		public UiAudio uiAudioSourcePool;

		public SaveCamera saveCamera;

		public ScreenshotCamera screenshotCamera;

		public SaveDataScripableObject defaultSaveData;

		public PropMeshAnimator propMeshAnimator;

		public MiscReferences miscReferences;

		public ButterflyFlock butterflyFlock;

		public ShadowBaker shadowBaker;

		public ManySoundsManager manySoundsManager;

		public Palette palette;

		public TexturePngMaster texturePngMaster;

		public SaveSystem saveSystem;

		public BigMeshMaster bigMeshMaster;

		public ObjExporter objExporter;

		public PropAchievements propAchievements;

		[SerializeField]
		private string lastSaveString;

		[Space]
		public bool stopFrame;

		public Stopwatch stopwatch;

		public bool startedCounting;

		public SaveData saveData;

		private static WorldMaster instance;

		public static float expTSlow;

		public static float expTMid;

		public static float expTFast;

		public static float expTFaster;

		private float saveCurrentTime;

		private const float saveEverySeconds = 10f;

		private bool doGo;

		private bool pause;

		public Action<SaveData> onCameraLoad;

		public Action<SaveData> onCameraSave;

		[SerializeField]
		private float milliseconds;

		public bool isDimmed;

		public bool awaitingDim;

		public State state;

		private List<string> stateStrings;

		public bool anyChange;

		public float lastChangeTime;

		public float lastStartChangeTime;

		public SettingsData settingsData => null;

		public bool keeepGoing => false;

		public bool shouldBeLoading => false;

		public bool KeepGoing()
		{
			return false;
		}

		public void StartCounting()
		{
		}

		public void OnOnEnable()
		{
		}

		public void SetDirty()
		{
		}

		public void ResetState()
		{
		}

		public void OnStart()
		{
		}

		private void Update()
		{
		}

		private bool Iterate()
		{
			return false;
		}

		private void LateUpdate()
		{
		}

		public void PopulateSaveData(SaveData saveData, MetaSave metaSave = null)
		{
		}

		public string GetSaveString()
		{
			return null;
		}

		public void Load(SaveData saveData)
		{
		}

		public void NothingToLoadAtStartup()
		{
		}

		public bool Load(string saveString)
		{
			return false;
		}

		public void New()
		{
		}

		public void New(SaveData saveData)
		{
		}

		void IOnScenePostProcess.OnScenePostProcess(bool isBuild, TargetPlatformFlags platform)
		{
		}

		public void ResetSaveCurrentTimer()
		{
		}

		public bool MaybeUpdateGameVersionInSettingsData()
		{
			return false;
		}
	}
}
