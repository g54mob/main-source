using System.Collections;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
	public delegate void OnSpawnPlayer(Character playerCharacter, PlayerController playerController, Character oldPlayerCharacter, PlayerController oldPlayerController);

	public delegate void OnPause();

	public static GameManager instance;

	private LevelController currentLevelController;

	[SerializeField]
	private GameObject playerCharacterPrefab;

	[SerializeField]
	private GameObject playerControllerPrefab;

	[SerializeField]
	private bool delayedStart;

	[SerializeField]
	private bool spawnOnStart = true;

	private Character playerCharacter;

	private PlayerController playerController;

	private bool isGamePaused;

	public Character PlayerCharacter => playerCharacter;

	public PlayerController PlayerController
	{
		get
		{
			return playerController;
		}
		protected set
		{
			playerController = value;
		}
	}

	public LevelController CurrentLevelController
	{
		get
		{
			return currentLevelController;
		}
		set
		{
			currentLevelController = value;
		}
	}

	public bool IsGamePaused
	{
		get
		{
			return isGamePaused;
		}
		private set
		{
			isGamePaused = value;
		}
	}

	public event OnSpawnPlayer onSpawnPlayer;

	public event OnPause onPause;

	public event OnPause onResume;

	protected virtual void Awake()
	{
		if (!instance)
		{
			instance = this;
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}

	protected virtual void Start()
	{
		if (delayedStart)
		{
			StartCoroutine(DelayedStartCoroutine());
		}
		else
		{
			InternalStart();
		}
	}

	private IEnumerator DelayedStartCoroutine()
	{
		yield return null;
		InternalStart();
	}

	private void InternalStart()
	{
		if (spawnOnStart)
		{
			SpawnPlayer();
		}
	}

	public virtual void SpawnPlayer()
	{
		if ((bool)playerCharacterPrefab && (bool)playerCharacterPrefab.GetComponent<Character>())
		{
			Character oldPlayerCharacter = playerCharacter;
			Vector3 position = Vector3.zero;
			Quaternion rotation = Quaternion.identity;
			if ((bool)currentLevelController && (bool)currentLevelController.SpawnTransform)
			{
				position = currentLevelController.SpawnTransform.position;
				rotation = currentLevelController.SpawnTransform.rotation;
			}
			playerCharacter = Object.Instantiate(playerCharacterPrefab, position, rotation).GetComponent<Character>();
			if ((bool)playerCharacterPrefab && (bool)playerControllerPrefab)
			{
				playerCharacter.GetComponent<Character>().DefaultController = playerControllerPrefab;
			}
			playerCharacter.gameObject.tag = "Player";
			PlayerController oldPlayerController = playerController;
			playerController = (PlayerController)playerCharacter.Controller;
			this.onSpawnPlayer?.Invoke(playerCharacter, playerController, oldPlayerCharacter, oldPlayerController);
		}
	}

	public void PauseGame(bool pause, bool sendEvents = true)
	{
		if (!pause && IsGamePaused)
		{
			IsGamePaused = false;
			if (sendEvents)
			{
				this.onResume?.Invoke();
			}
			Time.timeScale = 1f;
		}
		else if (pause && !IsGamePaused)
		{
			IsGamePaused = true;
			if (sendEvents)
			{
				this.onPause?.Invoke();
			}
			Time.timeScale = 0f;
		}
	}
}
