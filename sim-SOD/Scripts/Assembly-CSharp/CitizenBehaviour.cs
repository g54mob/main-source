using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CitizenBehaviour : MonoBehaviour
{
	[Serializable]
	public class Smokestack
	{
		public NewBuilding building;

		public float timer;
	}

	public delegate void GameWorldLoop();

	public List<NewAIController> veryLowTickRate;

	public List<NewAIController> lowTickRate;

	public List<NewAIController> mediumTickRate;

	public List<NewAIController> highTickRate;

	public List<NewAIController> veryHighTickRate;

	[NonSerialized]
	public List<NewAIController> updateList;

	public int tickCounter;

	public int AITicksPerFrame;

	public int executionsThisFrame;

	public int aiTickBacklog;

	public int visibleHumans;

	public int frequentTickCounter;

	private float frequentTick5FPS;

	private float frequentTick20FPS;

	private float frequentTick50FPS;

	private List<LightController> lightUpdateQueue;

	public HashSet<Actor> actorsInStealthMode;

	private float passiveIncomeTimer;

	public bool initialPositioning;

	public bool cancelUmbrellaAutoSelect;

	private bool umbrellaAutoSelected;

	public float triggerHeadache;

	public const float footprintMaxTime = 12f;

	public List<NewBuilding> buildingEmissionTexturesToUpdate;

	public float timeOnLastGameWorldUpdate;

	[Header("Citizen Rendering")]
	public int loadCitizensPerFrame;

	public HashSet<Human> citizensRenderQueue;

	[Header("Smokestacks")]
	public List<Smokestack> smokestacks;

	[Header("Scene Captures")]
	public List<SceneRecorder> sceneRecorders;

	public List<NewGameLocation> tempEscalationBoost;

	private static CitizenBehaviour _instance;

	private List<Interactable> toRemove;

	public static CitizenBehaviour Instance => null;

	public event GameWorldLoop OnGameWorldLoop
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public void StartGame()
	{
	}

	public void GameSpeedChange()
	{
	}

	public void RoutineCheck()
	{
	}

	public void AddToCitizenRenderQueue(Human human)
	{
	}

	public void RemoveFromCitizenRenderQueue(Human human)
	{
	}

	private void Update()
	{
	}

	private void LateUpdate()
	{
	}

	private void GameWorldCheck()
	{
	}

	private void UpdateRainHaptics()
	{
	}

	private void LightLevelLoop()
	{
	}

	public void OnHourChange()
	{
	}

	public void OnDayChange()
	{
	}

	public void UpdateForSale()
	{
	}
}
