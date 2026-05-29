using UnityEngine;
using UnityEngine.Localization;

public class OnlineOrderTutorial : MonoBehaviour, ITutorial
{
	private Mission[] m_Missions;

	[SerializeField]
	private TutorialObjectiveData[] m_Objectives;

	[SerializeField]
	private TutorialObjectiveDisplay m_ObjectiveDisplay;

	private int m_MissionIndex;

	public bool IsCompleted => false;

	private void Awake()
	{
	}

	public void BeginTutorial()
	{
	}

	public void EndTutorial()
	{
	}

	private void OnOrderDelivered(OrderListData obj)
	{
	}

	private void OnLanguageChanged(Locale obj)
	{
	}

	private void OnGamepadConnected(bool obj)
	{
	}

	private void Update()
	{
	}

	private void AddOrderData()
	{
	}

	private void StartCurrentMission()
	{
	}

	private void UpdateObjectiveData()
	{
	}

	private void EndCurrentMission()
	{
	}

	private void NextMission()
	{
	}

	private void OnMissionCompleted()
	{
	}
}
