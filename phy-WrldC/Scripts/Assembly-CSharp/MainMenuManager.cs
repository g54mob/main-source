using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainMenuManager : MonoBehaviour
{
	[Serializable]
	public class MainMenuType
	{
		public GameObject staticObjectsFolder;

		public GameObject cameraFocusPoint;

		public GameObject creationBuildingPoint;

		public GameObject creationSpawnPoint;

		public bool isRandomOrientation;
	}

	[SerializeField]
	private int shouldShowOnlySelectedIndex = -1;

	[SerializeField]
	private List<MainMenuType> mainMenuTypes;

	[Space(20f)]
	[SerializeField]
	private UnityEvent onSpawnCreationStartingEvent;

	[SerializeField]
	private UnityEvent onSpawnCreationEndingEvent;

	public static MainMenuManager Instance => Singleton<MainMenuManager>.Instance;

	private void OnEnable()
	{
		MenuState.Instance.OnSpawnCreationStartingEvent += OnSpawnCreationStartingHandler;
		MenuState.Instance.OnSpawnCreationEndingEvent += OnSpawnCreationEndingHandler;
	}

	private void OnDisable()
	{
		MenuState.Instance.OnSpawnCreationStartingEvent -= OnSpawnCreationStartingHandler;
		MenuState.Instance.OnSpawnCreationEndingEvent -= OnSpawnCreationEndingHandler;
	}

	private void OnSpawnCreationStartingHandler()
	{
		onSpawnCreationStartingEvent.Invoke();
	}

	private void OnSpawnCreationEndingHandler()
	{
		onSpawnCreationEndingEvent.Invoke();
	}

	public MainMenuType GetRandomMainMenuType(bool shouldReturnFirstTypeOnly)
	{
		MainMenuType mainMenuType = ((shouldShowOnlySelectedIndex > 0 && shouldShowOnlySelectedIndex < mainMenuTypes.Count) ? mainMenuTypes[shouldShowOnlySelectedIndex] : (shouldReturnFirstTypeOnly ? mainMenuTypes[0] : mainMenuTypes[UnityEngine.Random.Range(0, mainMenuTypes.Count)]));
		for (int i = 0; i < mainMenuTypes.Count; i++)
		{
			mainMenuTypes[i].staticObjectsFolder.SetActive(mainMenuType == mainMenuTypes[i]);
		}
		return mainMenuType;
	}
}
