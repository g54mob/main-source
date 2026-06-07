using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

public class DebugController : MonoBehaviour
{
	public enum SaveLoadMode
	{
		Normal = 0,
		LoadEmptySaveFileOnStartup = 1,
		LoadMaxedOutSaveFileOnStartup = 2
	}

	[Tooltip("Set to -1 to disable")]
	public int startGameInWave = -1;

	public static DebugController instance;

	[SerializeField]
	private SaveLoadMode saveLoadMode;

	public TextAsset emptySaveFile;

	public TextAsset maxedSaveFile;

	public KeyCode addCoin = KeyCode.Alpha2;

	public KeyCode removeCoin = KeyCode.Alpha3;

	public KeyCode getPoints = KeyCode.Alpha4;

	public KeyCode upgradeAllBuildingsToMax = KeyCode.Alpha9;

	public KeyCode reviveAllYourUnits = KeyCode.Alpha6;

	public KeyCode killAllEnemyUnits = KeyCode.Alpha7;

	public KeyCode restartScene = KeyCode.R;

	public KeyCode spawnNextWave = KeyCode.T;

	public KeyCode goToLevelSelect = KeyCode.Escape;

	public KeyCode instaWinLevel = KeyCode.End;

	public KeyCode causeLagSpike = KeyCode.L;

	public KeyCode openTestChoice = KeyCode.C;

	public KeyCode softWinLevel = KeyCode.Alpha8;

	public KeyCode loseLevel = KeyCode.Q;

	public KeyCode deletePlayerPrefs = KeyCode.Minus;

	public KeyCode killPlayer = KeyCode.K;

	public KeyCode enableDisableUI = KeyCode.KeypadMinus;

	public KeyCode printNextWaveInfo = KeyCode.N;

	public KeyCode changeColorscheme = KeyCode.C;

	public List<Colorscheme> allColorschemes;

	private int currentColorscheme = -1;

	public KeyCode changeNextWave = KeyCode.N;

	private PlayerInteraction playerInteraction;

	private float muteClock;

	private bool muted;

	private float initMasterVol;

	private Player player;

	[Header("BOUNDARY PLACEMENTS")]
	[SerializeField]
	private bool bounderyPlacementMode;

	public KeyCode placeBounteryNode = KeyCode.B;

	public string placeBounteryNodeRewired = "";

	public KeyCode startNewBoundary = KeyCode.V;

	public string startNewBoundaryRewired = "";

	public KeyCode removeLastBoundaryNode = KeyCode.Z;

	public string removeLastBoundaryNodeRewired = "";

	[SerializeField]
	private GameObject invisibleWalls;

	[SerializeField]
	private GameObject boundariesPrefab;

	[SerializeField]
	private Transform playerCharacter;

	private Transform currentBoundaryParent;

	public int StartGameInWave => -1;

	public static SaveLoadMode SaveLoadModeToUse
	{
		get
		{
			if (instance == null)
			{
				return SaveLoadMode.Normal;
			}
			_ = instance.enabled;
			return SaveLoadMode.Normal;
		}
	}

	public static bool SaveTheGame
	{
		get
		{
			if (instance == null)
			{
				return true;
			}
			_ = instance.enabled;
			return true;
		}
	}

	private void Start()
	{
		player = ReInput.players.GetPlayer(0);
	}

	private void Awake()
	{
		if (instance != null)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		instance = this;
		Object.DontDestroyOnLoad(base.gameObject);
	}

	public void EnableUICanvases()
	{
		NightCall.instance.gameObject.SetActive(value: true);
		UIFrameManager.instance.gameObject.SetActive(value: true);
	}

	private void Update()
	{
	}

	public void LogChoice(Choice _choice)
	{
		if (_choice != null)
		{
			Debug.Log(_choice.name);
		}
		else
		{
			Debug.Log("Choice cancelled.");
		}
	}

	public void Mute(float duration = 3f)
	{
		ThronefallAudioManager.Mute();
		muted = true;
		if (duration > muteClock)
		{
			muteClock = duration;
		}
	}

	public void StartNewBoundary()
	{
		if (currentBoundaryParent != null)
		{
			currentBoundaryParent.GetComponent<PathMesher>().loop = true;
			currentBoundaryParent.GetComponent<PathMesher>().UpdateMesh();
		}
		currentBoundaryParent = Object.Instantiate(boundariesPrefab, invisibleWalls.transform).transform;
		currentBoundaryParent.GetComponent<PathMesher>().loop = false;
		currentBoundaryParent.GetComponent<Collider>().enabled = false;
	}

	public void PlaceBountaryNode()
	{
		if (currentBoundaryParent == null)
		{
			StartNewBoundary();
		}
		GameObject obj = new GameObject("Node");
		obj.transform.position = playerCharacter.position;
		obj.transform.SetParent(currentBoundaryParent);
		obj.transform.localScale = Vector3.one * 7f;
		currentBoundaryParent.GetComponent<PathMesher>().UpdateMesh();
	}

	private IEnumerator RemoveLastBoundaryNode()
	{
		if (currentBoundaryParent != null && currentBoundaryParent.childCount > 0)
		{
			Object.Destroy(currentBoundaryParent.GetChild(currentBoundaryParent.childCount - 1).gameObject);
			yield return null;
			currentBoundaryParent.GetComponent<PathMesher>().UpdateMesh();
		}
	}
}
