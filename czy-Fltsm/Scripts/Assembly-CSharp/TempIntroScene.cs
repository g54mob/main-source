using System;
using System.Collections.Generic;
using M4.Session;
using PajamaLlama.Debugs;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempIntroScene : MonoBehaviour
{
	private enum CanvasElement
	{
		MENU = 0,
		CONTROLS = 1,
		STATISTICS = 2
	}

	[Tooltip("Change log component for the main menu.")]
	[SerializeField]
	private ChangeLog _changeLog;

	[Tooltip("Reference to the Continue button")]
	[SerializeField]
	private GameObject _continueButton;

	private Canvas _canvas;

	private AsyncOperation _asyncLoad;

	private Dictionary<string, GameObject> _namesToCanvasElements = new Dictionary<string, GameObject>();

	private CanvasElement _activeCanvasElement;

	private void Awake()
	{
		LoadCanvasGameObjects();
		ShowOneDisableOthers("menu");
		if (_changeLog != null)
		{
			_changeLog.Initialize();
		}
	}

	private void OnEnable()
	{
		_continueButton.SetActive(Session.Profile.HasRuns);
	}

	private void Start()
	{
		if (_asyncLoad == null)
		{
			_asyncLoad = SceneManager.LoadSceneAsync("_GameWorld");
			_asyncLoad.allowSceneActivation = false;
		}
	}

	private void Update()
	{
		switch (_activeCanvasElement)
		{
		case CanvasElement.CONTROLS:
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				ShowOneDisableOthers(CanvasElement.MENU);
			}
			else if (Input.anyKeyDown)
			{
				StartMainLevel();
			}
			break;
		case CanvasElement.STATISTICS:
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				ShowOneDisableOthers(CanvasElement.MENU);
			}
			break;
		case CanvasElement.MENU:
			break;
		}
	}

	private void LoadCanvasGameObjects()
	{
		if (_canvas == null)
		{
			_canvas = GetComponent<Canvas>();
		}
		for (int i = 0; i < _canvas.transform.childCount; i++)
		{
			GameObject gameObject = _canvas.transform.GetChild(i).gameObject;
			_namesToCanvasElements.Add(gameObject.name.ToLower(), gameObject);
		}
	}

	private void ShowOneDisableOthers(CanvasElement canvasElement)
	{
		ShowOneDisableOthers(canvasElement.ToString());
	}

	public void ShowOneDisableOthers(string canvasElementName)
	{
		foreach (KeyValuePair<string, GameObject> namesToCanvasElement in _namesToCanvasElements)
		{
			if (namesToCanvasElement.Key.Equals(canvasElementName.ToLower()))
			{
				namesToCanvasElement.Value.SetActive(value: true);
				try
				{
					_activeCanvasElement = (CanvasElement)Enum.Parse(typeof(CanvasElement), canvasElementName.ToUpper());
					if (_activeCanvasElement == CanvasElement.CONTROLS && _asyncLoad == null)
					{
						_asyncLoad = SceneManager.LoadSceneAsync("_GameWorld");
						_asyncLoad.allowSceneActivation = false;
					}
				}
				catch
				{
					Debugger.Warning("Invalid canvasElement conversion " + canvasElementName.ToUpper());
				}
			}
			else
			{
				namesToCanvasElement.Value.SetActive(value: false);
			}
		}
	}

	public void StartMainLevel()
	{
		_asyncLoad.allowSceneActivation = true;
	}

	public void Continue()
	{
		StartMainLevel();
	}

	public void QuitGame()
	{
		GameManager.QuitToDesktop();
	}
}
