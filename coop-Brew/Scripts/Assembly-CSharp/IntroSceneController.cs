using System.Collections.Generic;
using Synty.AnimationBaseLocomotion.Samples.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneController : MonoBehaviour
{
	[Header("Timing")]
	[Tooltip("Duration of the intro cutscene in seconds")]
	[SerializeField]
	private float introDuration;

	[Header("Input")]
	[Tooltip("InputReader reference (auto-finds if not assigned)")]
	[SerializeField]
	private InputReader inputReader;

	[Header("Skip Settings")]
	[Tooltip("Allow clients to skip intro, or only host?")]
	[SerializeField]
	private bool allowClientsToSkip;

	[Tooltip("Minimum time to wait before allowing skip (gives clients time to load)")]
	[SerializeField]
	private float minimumWaitBeforeSkip;

	[Header("Debug")]
	[Tooltip("Show debug logs")]
	[SerializeField]
	private bool showDebugLogs;

	private bool hasTransitioned;

	private float elapsedTime;

	private bool _allClientsLoadedIntoIntroScene;

	private HashSet<ulong> _clientsLoadedIntoScene;

	private float _sceneLoadedTime;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnEscapePressed()
	{
	}

	private void TransitionToMainScene()
	{
	}

	private void OnNetworkSceneLoadCompleted(string sceneName, LoadSceneMode loadSceneMode, List<ulong> clientsCompleted, List<ulong> clientsTimedOut)
	{
	}

	private void CheckAllClientsLoaded()
	{
	}

	private void OnDestroy()
	{
	}
}
