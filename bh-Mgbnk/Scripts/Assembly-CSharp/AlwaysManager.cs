using Assets.Scripts.Actors.Enemies;
using UnityEngine;

public class AlwaysManager : MonoBehaviour
{
	public SaveManager saveManager;

	public DataManager dataManager;

	public SteamManager steamManager;

	public GameObject rewiredManager;

	public GameObject eventSystem;

	public AlwaysUi alwaysUi;

	public static AlwaysManager Instance;

	public Material playerMaterialPreset;

	private int index;

	private Enemy testEnemy;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	private void OnDestroy()
	{
	}
}
