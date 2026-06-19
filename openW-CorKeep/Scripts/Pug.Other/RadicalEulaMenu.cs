using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class RadicalEulaMenu : RadicalMenu
{
	public RadicalMenuOption declineOption;

	public RadicalMenuOption acceptOption;

	private GameObject eulaCanvasGo;

	private AsyncOperationHandle<GameObject> goHandle;

	private bool eulaPanelLoaded;

	private bool eulaLoadingFailed;

	private Scrollbar _scrollbar;

	private bool optionPressed;

	private bool isAccepted;

	private Vector2 scrollingSpeedMinMax = new Vector2(0.05f, 0.35f);

	private float scrollingSpeed = 0.05f;

	[SerializeField]
	private List<MenuHelperButtons.HelpButtonTypes> _helpButtonList;

	private void Start()
	{
		backNeverClosesMenu = true;
	}

	public override void Activate()
	{
		optionPressed = false;
		isAccepted = false;
		menuOptions.Clear();
		menuOptions.Add(declineOption);
		menuOptions.Add(acceptOption);
		acceptOption.canBeActivated = false;
		acceptOption.activeInTitle = false;
		base.Activate();
		SelectOptionIndex(0);
	}

	private void Update()
	{
		if (eulaPanelLoaded && _scrollbar != null)
		{
			HandleScrolling();
		}
	}

	private void HandleScrolling()
	{
		if (Manager.input.IsMenuUpButtonPressed())
		{
			_scrollbar.value = Mathf.Clamp01(_scrollbar.value + scrollingSpeed * Time.deltaTime);
			scrollingSpeed = Mathf.Clamp(scrollingSpeed + 0.02f * Time.deltaTime, scrollingSpeedMinMax.x, scrollingSpeedMinMax.y);
		}
		else if (Manager.input.IsMenuDownButtonPressed())
		{
			_scrollbar.value = Mathf.Clamp01(_scrollbar.value - scrollingSpeed * Time.deltaTime);
			scrollingSpeed = Mathf.Clamp(scrollingSpeed + 0.02f * Time.deltaTime, scrollingSpeedMinMax.x, scrollingSpeedMinMax.y);
			if (_scrollbar.value == 0f && !acceptOption.canBeActivated)
			{
				acceptOption.canBeActivated = true;
				acceptOption.activeInTitle = true;
				acceptOption.Select();
			}
		}
		else
		{
			scrollingSpeed = scrollingSpeedMinMax.x;
		}
	}

	private IEnumerator LoadEulaPanel()
	{
		eulaPanelLoaded = false;
		eulaLoadingFailed = false;
		goHandle = Addressables.LoadAssetAsync<GameObject>("EulaCanvas");
		yield return goHandle;
		if (goHandle.Status == AsyncOperationStatus.Succeeded)
		{
			GameObject result = goHandle.Result;
			eulaCanvasGo = UnityEngine.Object.Instantiate(result, base.transform);
			_scrollbar = GetComponentInChildren<Scrollbar>();
			eulaCanvasGo.SetActive(value: false);
			eulaPanelLoaded = true;
		}
		else
		{
			eulaLoadingFailed = true;
		}
	}

	public void StartEulaCheck(Action<bool> callback)
	{
		StartCoroutine(LoadEulaPanel());
		StartCoroutine(WaitForPlayerInput(callback));
	}

	private IEnumerator WaitForPlayerInput(Action<bool> callback)
	{
		while (!eulaPanelLoaded)
		{
			if (eulaLoadingFailed)
			{
				callback?.Invoke(obj: false);
			}
			yield return null;
		}
		eulaCanvasGo.SetActive(value: true);
		yield return null;
		bool isEulaRead = false;
		while (!isEulaRead)
		{
			if (optionPressed)
			{
				Debug.Log("Close EULA");
				isEulaRead = true;
			}
			yield return null;
		}
		if (eulaCanvasGo != null)
		{
			eulaCanvasGo.SetActive(value: false);
			UnityEngine.Object.Destroy(eulaCanvasGo);
		}
		Addressables.Release(goHandle);
		CloseEulaPopUp(callback);
	}

	private void CloseEulaPopUp(Action<bool> callback)
	{
		Manager.menu.PopMenu();
		callback?.Invoke(isAccepted);
	}

	public void AcceptPressed()
	{
		isAccepted = true;
		optionPressed = true;
	}

	public void DeclinePressed()
	{
		isAccepted = false;
		optionPressed = true;
	}

	public override List<MenuHelperButtons.HelpButtonTypes> GetHelpButtonsToShow()
	{
		return _helpButtonList;
	}
}
