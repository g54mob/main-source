using TMPro;
using UnityEngine;

public class StorySector : MonoBehaviour
{
	public GameObject spanNetworkPlanetObjectivePrefab;

	public GameObject leftButton;

	public GameObject rightButton;

	public GameObject planets;

	public GalaxyMissionPanel gmp;

	public Transform objectiveContainer;

	public GameObject completeText;

	public GameObject[] objectives;

	public TextMeshProUGUI missionTitle;

	public const int PLANET_COUNT = 20;

	private int _planetShown;

	public int planetShown
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	private string missionGUID => null;

	private bool isMissionComplete => false;

	private bool IsOverBlockingUI()
	{
		return false;
	}

	public void OnEnable()
	{
	}

	public void Update()
	{
	}

	public void OnMoveRight()
	{
	}

	public void OnMoveLeft()
	{
	}

	private void OnPlanetTweenComplete()
	{
	}

	private void SetMission()
	{
	}

	private void ShowObjectives()
	{
	}

	public static void DestroyChildren(Transform transform)
	{
	}
}
