using System.Collections.Generic;
using Synty.AnimationBaseLocomotion.Samples;
using Synty.AnimationBaseLocomotion.Samples.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyStuff.Core
{
	public class CursorManager : MonoBehaviour
	{
		[Header("Cursor Settings")]
		[Tooltip("Should the cursor start locked for gameplay?")]
		[SerializeField]
		private bool startLocked;

		[Tooltip("Should this manager persist across scene loads?")]
		[SerializeField]
		private bool dontDestroyOnLoad;

		[Header("Scene Settings")]
		[Tooltip("Scenes where cursor should always be unlocked (menu scenes)")]
		[SerializeField]
		private string[] menuScenes;

		private InputReader localInputReader;

		private SampleCameraController localCameraController;

		private bool awaitingInputReader;

		private bool awaitingCameraController;

		private readonly HashSet<string> _unlockRequests;

		public static CursorManager Instance { get; private set; }

		public bool SuppressCursorToggle { get; set; }

		public bool IsCursorLocked => false;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
		}

		private bool IsMenuScene(string sceneName)
		{
			return false;
		}

		public void RequestUnlock(string requestId)
		{
		}

		public void ReleaseUnlock(string requestId)
		{
		}

		public void ForceLock()
		{
		}

		public void UnlockCursor()
		{
		}

		public void LockCursor()
		{
		}

		public void SetCursorState(bool locked)
		{
		}

		private void ApplyCursorState()
		{
		}

		private void ToggleCursor()
		{
		}

		private void LocateInputReader()
		{
		}

		private void LocateCameraController()
		{
		}

		private void SetLocalCameraController(SampleCameraController controller)
		{
		}

		private void SubscribeToInputReader(InputReader reader)
		{
		}

		private void UnsubscribeFromInputReader()
		{
		}

		public HashSet<string> GetActiveRequests()
		{
			return null;
		}
	}
}
