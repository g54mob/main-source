using System;
using System.Collections.Generic;
using UltimateReplay.Core;
using UltimateReplay.Storage;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UltimateReplay
{
	public sealed class ReplayManager : MonoBehaviour
	{
		public static Func<GameObject, Vector3, Quaternion, GameObject> OnReplayInstantiate;

		public static Action<GameObject> OnReplayDestroy;

		private static IReplayPreparer preparer = new DefaultReplayPreparer();

		private static ReplayManager instance = null;

		private static bool isSceneDisposing = false;

		private static bool isDisposing = false;

		private ReplayScene scene = new ReplayScene();

		private ReplaySequencer sequence = new ReplaySequencer();

		private ReplayTarget target;

		private PlaybackState state;

		private bool singlePlayback;

		private ReplayTimer recordTimer = new ReplayTimer();

		private ReplayTimer recordStepTimer = new ReplayTimer();

		private List<ReplayObject> replayPrefabs = new List<ReplayObject>();

		[Tooltip("When true, the manager will automatically start recording on startup")]
		public bool recordOnStart = true;

		[Tooltip("When true, the game object will survie scene changes. This is useful if you dont want to place a replay manager in every scene")]
		public bool dontDestroyOnLoad;

		[Tooltip("The beaviour used when playback reaches the end of the current replay")]
		public PlaybackEndBehaviour playbackEndBehaviour;

		[Tooltip("The update method used to record and replay. You may need to change this value for best compatibility with game scripts or 3rd party assets")]
		public UpdateMethod updateMethod;

		[Range(1f, 48f)]
		[Tooltip("The target frame rate to record at. Higher values provide more accurate playback but will result in more cpu load and memory usage")]
		public int recordFPS = 8;

		public GameObject[] prefabs = new GameObject[0];

		public static ReplayManager Instance
		{
			get
			{
				if (instance == null && isDisposing)
				{
					throw new ObjectDisposedException("The replay manager instance has been disposed and will not be recreated because the game is quitting. Use 'ReplayManager.IsDisposing' to check if you should access the replay manager");
				}
				if (instance == null)
				{
					ReplayManager[] array = UnityEngine.Object.FindObjectsOfType<ReplayManager>();
					if (array.Length != 0)
					{
						if (array.Length > 1)
						{
							Debug.LogWarning("There are multiple replay managers in the scene. " + array[0].name + " will become the active replay manager instance");
						}
						instance = array[0];
					}
					else
					{
						instance = new GameObject(typeof(ReplayManager).Name).AddComponent<ReplayManager>();
					}
				}
				return instance;
			}
		}

		public static bool IsDisposing
		{
			get
			{
				if (!isDisposing)
				{
					return isSceneDisposing;
				}
				return true;
			}
		}

		public static IReplayPreparer Preparer
		{
			get
			{
				return preparer;
			}
			set
			{
				if (value == null)
				{
					value = new DefaultReplayPreparer();
				}
				preparer = value;
			}
		}

		public static ReplayTarget Target
		{
			get
			{
				if (Instance == null)
				{
					return null;
				}
				if (Instance.target == null)
				{
					Instance.target = Instance.GetComponent<ReplayTarget>();
					if (Instance.target == null)
					{
						Instance.target = Instance.gameObject.AddComponent<ReplayMemoryTarget>();
					}
					Instance.sequence.Target = Instance.target;
				}
				return Instance.target;
			}
			set
			{
				if (!(Instance == null) && value != null)
				{
					Instance.target = value;
					Instance.sequence.Target = Instance.target;
				}
			}
		}

		public static ReplayScene Scene
		{
			get
			{
				if (Instance == null)
				{
					return null;
				}
				return Instance.scene;
			}
		}

		public static bool IsRecording
		{
			get
			{
				if (Instance == null)
				{
					return false;
				}
				if (Instance.state != PlaybackState.Recording)
				{
					return Instance.state == PlaybackState.Recording_Paused;
				}
				return true;
			}
		}

		public static bool IsReplaying
		{
			get
			{
				if (Instance == null)
				{
					return false;
				}
				if (Instance.state != PlaybackState.Playback)
				{
					return Instance.state == PlaybackState.Playback_Paused;
				}
				return true;
			}
		}

		public static bool IsPaused
		{
			get
			{
				if (Instance == null)
				{
					return false;
				}
				if (Instance.state != PlaybackState.Playback_Paused)
				{
					return Instance.state == PlaybackState.Recording_Paused;
				}
				return true;
			}
		}

		public static PlaybackDirection PlaybackDirection => ReplayTime.TimeScaleDirection;

		public static float CurrentPlaybackTime
		{
			get
			{
				if (Instance == null)
				{
					return 0f;
				}
				return Instance.sequence.CurrentTime;
			}
		}

		public static float CurrentPlaybackTimeNormalized
		{
			get
			{
				if (Instance == null)
				{
					return 0f;
				}
				return Instance.sequence.CurrentTimeNormalized;
			}
		}

		public void Awake()
		{
			isSceneDisposing = false;
			if (dontDestroyOnLoad)
			{
				UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			}
		}

		public void Start()
		{
			GameObject[] array = prefabs;
			for (int i = 0; i < array.Length; i++)
			{
				RegisterReplayPrefab(array[i]);
			}
			_ = Target == null;
			if (recordOnStart)
			{
				BeginRecording();
			}
			recordStepTimer.Interval = 1f / (float)recordFPS;
			SceneManager.sceneLoaded += delegate
			{
				OnActiveSceneChanged();
			};
		}

		public void OnApplicationQuit()
		{
			isDisposing = true;
		}

		public void Update()
		{
			if (updateMethod == UpdateMethod.Update)
			{
				UpdateState(fixedTime: false);
			}
		}

		public void LateUpdate()
		{
			if (updateMethod == UpdateMethod.LateUpdate)
			{
				UpdateState(fixedTime: false);
			}
		}

		public void FixedUpdate()
		{
			if (updateMethod == UpdateMethod.FixedUpdate)
			{
				UpdateState(fixedTime: true);
			}
		}

		public void UpdateState(bool fixedTime)
		{
			switch (state)
			{
			case PlaybackState.Recording_Paused_Playback:
			case PlaybackState.Playback:
				if (!singlePlayback)
				{
					ReplaySnapshot frame;
					ReplaySequenceResult replaySequenceResult = sequence.UpdatePlayback(out frame, playbackEndBehaviour, fixedTime);
					switch (replaySequenceResult)
					{
					case ReplaySequenceResult.SequenceAdvance:
						scene.RestoreSnapshot(frame, Target.InitialStateBuffer);
						break;
					case ReplaySequenceResult.SequenceEnd:
						StopPlayback();
						break;
					}
					if (replaySequenceResult == ReplaySequenceResult.SequenceIdle || replaySequenceResult == ReplaySequenceResult.SequenceAdvance)
					{
						ReplayBehaviour.Events.CallReplayUpdateEvents();
					}
				}
				break;
			case PlaybackState.Recording:
				ReplayTimer.Tick(fixedTime);
				if (recordStepTimer.HasElapsed())
				{
					ReplaySnapshot replaySnapshot = scene.RecordSnapshot(Instance.recordTimer.ElapsedSeconds, Target.InitialStateBuffer);
					Target.RecordSnapshot(replaySnapshot);
				}
				break;
			case PlaybackState.Idle:
			case PlaybackState.Recording_Paused:
			case PlaybackState.Playback_Paused:
				break;
			}
		}

		public void OnValidate()
		{
			recordStepTimer.Interval = 1f / (float)recordFPS;
			if (Application.isPlaying || prefabs == null)
			{
				return;
			}
			GameObject[] array = prefabs;
			foreach (GameObject gameObject in array)
			{
				if (gameObject != null)
				{
					ReplayObject component = gameObject.GetComponent<ReplayObject>();
					if (component != null)
					{
						component.UpdatePrefabLinks();
					}
				}
			}
		}

		public void OnDestroy()
		{
			if (IsRecording)
			{
				StopRecording();
			}
			if (target != null)
			{
				UnityEngine.Object.Destroy(target);
			}
			if (!dontDestroyOnLoad)
			{
				isSceneDisposing = true;
			}
		}

		public static void BeginRecording(bool cleanRecording = true)
		{
			if (!(Instance == null))
			{
				if (cleanRecording)
				{
					DiscardRecording();
				}
				if (IsReplaying)
				{
					StopPlayback();
				}
				Target.PrepareTarget(ReplayTargetTask.PrepareWrite);
				if (instance.state != PlaybackState.Recording_Paused)
				{
					Instance.recordStepTimer.Reset();
					Instance.recordTimer.Reset();
					ReplaySnapshot replaySnapshot = Instance.scene.RecordSnapshot(0f, Target.InitialStateBuffer);
					Target.RecordSnapshot(replaySnapshot);
				}
				Instance.state = PlaybackState.Recording;
			}
		}

		public static void PauseRecording()
		{
			if (!(Instance == null) && Instance.state == PlaybackState.Recording)
			{
				Instance.state = PlaybackState.Recording_Paused;
				StopRecording();
			}
		}

		public static void ResumeRecording()
		{
			if (!(Instance == null) && Instance.state == PlaybackState.Recording_Paused)
			{
				instance.state = PlaybackState.Recording_Paused;
				BeginRecording(cleanRecording: false);
			}
		}

		public static void StopRecording()
		{
			if (!(Instance == null) && IsRecording)
			{
				Instance.target.PrepareTarget(ReplayTargetTask.Commit);
				Instance.target.PrepareTarget(ReplayTargetTask.PrepareRead);
				if (instance.state != PlaybackState.Recording_Paused)
				{
					Instance.recordTimer.Reset();
					Instance.state = PlaybackState.Idle;
				}
			}
		}

		public static void DiscardRecording()
		{
			if (!(Instance == null))
			{
				if (Instance.target != null)
				{
					Instance.target.PrepareTarget(ReplayTargetTask.Discard);
				}
				if (IsReplaying)
				{
					StopPlayback();
				}
			}
		}

		public static void SetPlaybackFrame(float offset, PlaybackOrigin origin = PlaybackOrigin.Start)
		{
			if (!(Instance == null))
			{
				ReplaySnapshot replaySnapshot = Instance.sequence.SeekPlayback(offset, origin, normalized: false);
				if (replaySnapshot != null)
				{
					Instance.scene.RestoreSnapshot(replaySnapshot, Target.InitialStateBuffer);
					ReplayBehaviour.Events.CallReplayResetEvents();
					ReplayBehaviour.Events.CallReplayUpdateEvents();
				}
			}
		}

		public static void SetPlaybackFrameNormalized(float normalizedOffset, PlaybackOrigin origin = PlaybackOrigin.Start)
		{
			if (!(Instance == null))
			{
				ReplaySnapshot replaySnapshot = Instance.sequence.SeekPlayback(normalizedOffset, origin, normalized: true);
				if (replaySnapshot != null)
				{
					Instance.scene.RestoreSnapshot(replaySnapshot, Target.InitialStateBuffer);
					ReplayBehaviour.Events.CallReplayResetEvents();
					ReplayBehaviour.Events.CallReplayUpdateEvents();
				}
			}
		}

		public static void BeginPlaybackFrame()
		{
			if (Instance == null)
			{
				return;
			}
			if (Instance.target.MemorySize == 0)
			{
				Debug.LogWarning($"[{typeof(ReplayManager)}]: Playback cannot begin because there is no recorded data");
				return;
			}
			if (instance.state == PlaybackState.Recording_Paused)
			{
				instance.state = PlaybackState.Recording_Paused_Playback;
			}
			else if (IsRecording)
			{
				StopRecording();
			}
			Instance.target.PrepareTarget(ReplayTargetTask.PrepareRead);
			Instance.scene.SetReplaySceneMode(ReplayScene.ReplaySceneMode.Playback, Instance.target.InitialStateBuffer);
			Instance.singlePlayback = true;
			if (instance.state != PlaybackState.Recording_Paused_Playback)
			{
				Instance.state = PlaybackState.Playback;
			}
			string text = SceneManager.GetActiveScene().name;
			if (Instance.target.TargetSceneName != text)
			{
				Debug.LogWarning($"The replay file was recorded from a different scene called '{Instance.target.TargetSceneName}'. Playback may contain errors");
			}
		}

		public static void BeginPlayback(bool fromStart = true)
		{
			if (Instance == null)
			{
				return;
			}
			if (instance.state == PlaybackState.Recording_Paused)
			{
				if (IsRecording)
				{
					StopRecording();
				}
				instance.state = PlaybackState.Recording_Paused_Playback;
			}
			else if (IsRecording)
			{
				StopRecording();
			}
			if (!IsReplaying)
			{
				Instance.target.PrepareTarget(ReplayTargetTask.PrepareRead);
				Instance.scene.SetReplaySceneMode(ReplayScene.ReplaySceneMode.Playback, Instance.target.InitialStateBuffer);
				ReplayBehaviour.Events.CallReplayResetEvents();
				ReplayBehaviour.Events.CallReplayStartEvents();
			}
			if (fromStart)
			{
				SetPlaybackFrame(0f);
			}
			Instance.singlePlayback = false;
			if (instance.state != PlaybackState.Recording_Paused_Playback)
			{
				Instance.state = PlaybackState.Playback;
			}
		}

		[Obsolete("Use 'BeginPlayback(bool)' instead. If you need to change the playback direction use 'Time.timeScale' where negative values will cause playback to rewind")]
		public static void BeginPlayback(bool fromStart, PlaybackDirection direction)
		{
			if (Instance == null)
			{
				return;
			}
			if (instance.state == PlaybackState.Recording_Paused)
			{
				instance.state = PlaybackState.Recording_Paused_Playback;
			}
			else if (IsRecording)
			{
				StopRecording();
			}
			if (!IsReplaying)
			{
				Instance.target.PrepareTarget(ReplayTargetTask.PrepareRead);
				Instance.scene.SetReplaySceneMode(ReplayScene.ReplaySceneMode.Playback, Instance.target.InitialStateBuffer);
				ReplayBehaviour.Events.CallReplayResetEvents();
				ReplayBehaviour.Events.CallReplayStartEvents();
			}
			if (fromStart)
			{
				SetPlaybackFrame(0f);
			}
			switch (direction)
			{
			case PlaybackDirection.Forward:
				if (Time.timeScale < 0f)
				{
					Time.timeScale = 1f;
				}
				break;
			case PlaybackDirection.Backward:
				if (Time.timeScale > 0f)
				{
					Time.timeScale = -1f;
				}
				break;
			}
			Instance.singlePlayback = false;
			if (instance.state != PlaybackState.Recording_Paused_Playback)
			{
				Instance.state = PlaybackState.Playback;
			}
		}

		public static void PausePlayback()
		{
			if (!(Instance == null) && Instance.state == PlaybackState.Playback)
			{
				Instance.state = PlaybackState.Playback_Paused;
				ReplayBehaviour.Events.CallReplayPlayPauseEvents(paused: true);
			}
		}

		public static void ResumePlayback()
		{
			if (!(Instance == null) && Instance.state == PlaybackState.Playback_Paused)
			{
				Instance.state = PlaybackState.Playback;
				ReplayBehaviour.Events.CallReplayPlayPauseEvents(paused: false);
			}
		}

		public static void StopPlayback(bool restorePreviousSceneState = true)
		{
			if (!(Instance == null) && (IsReplaying || instance.state == PlaybackState.Recording_Paused_Playback))
			{
				ReplayBehaviour.Events.CallReplayEndEvents();
				Instance.scene.restorePreviousSceneState = restorePreviousSceneState;
				Instance.scene.SetReplaySceneMode(ReplayScene.ReplaySceneMode.Live, Instance.target.InitialStateBuffer);
				if (instance.state == PlaybackState.Recording_Paused_Playback)
				{
					instance.state = PlaybackState.Recording_Paused;
				}
				else
				{
					Instance.state = PlaybackState.Idle;
				}
			}
		}

		public static ReplayManager ForceAwake()
		{
			isSceneDisposing = false;
			return Instance;
		}

		public static void RegisterReplayPrefab(GameObject prefab)
		{
			if (!(prefab == null) && !(Instance == null))
			{
				ReplayObject component = prefab.GetComponent<ReplayObject>();
				if (component == null)
				{
					Debug.LogWarning($"Prefab '{prefab.name}' cannot be registered for replay because it does not have a 'ReplayObject' component attached to it");
				}
				else if (!component.IsPrefab)
				{
					Debug.LogWarning($"Object '{prefab.name}' cannot be registered as a replay prefab because it is not a prefab object");
				}
				else if (!Instance.replayPrefabs.Contains(component))
				{
					Instance.replayPrefabs.Add(component);
				}
			}
		}

		public static GameObject FindReplayPrefab(string prefabName)
		{
			if (Instance == null)
			{
				return null;
			}
			foreach (ReplayObject replayPrefab in Instance.replayPrefabs)
			{
				if (string.Compare(replayPrefab.PrefabIdentity, prefabName) == 0)
				{
					return replayPrefab.gameObject;
				}
			}
			return null;
		}

		public static GameObject ReplayInstantiate(GameObject prefab, Vector3 position, Quaternion rotation)
		{
			if (prefab == null)
			{
				throw new ArgumentException("The thing you want to instantiate is null");
			}
			GameObject result = null;
			bool flag = false;
			if (OnReplayInstantiate != null)
			{
				try
				{
					result = OnReplayInstantiate(prefab, position, rotation);
				}
				catch (Exception arg)
				{
					Debug.LogWarning($"An exception was thrown by the override instantiation handler ({arg}). Default instantiation will be used");
					flag = true;
				}
			}
			else
			{
				flag = true;
			}
			if (flag)
			{
				result = UnityEngine.Object.Instantiate(prefab, position, rotation);
			}
			return result;
		}

		public static void ReplayDestroy(GameObject go)
		{
			if (go == null)
			{
				return;
			}
			bool flag = false;
			if (OnReplayDestroy != null)
			{
				try
				{
					OnReplayDestroy(go);
				}
				catch (Exception arg)
				{
					Debug.LogWarning($"An exception was thrown by the override destroy handler ({arg}). Default destruction will be used");
					flag = true;
				}
			}
			else
			{
				flag = true;
			}
			if (flag)
			{
				UnityEngine.Object.Destroy(go);
			}
		}

		private void OnActiveSceneChanged()
		{
			if (!IsDisposing)
			{
				DiscardRecording();
			}
		}

		public void SetRecordFPS(int fps)
		{
			recordFPS = fps;
			recordStepTimer.Interval = 1f / (float)recordFPS;
		}
	}
}
