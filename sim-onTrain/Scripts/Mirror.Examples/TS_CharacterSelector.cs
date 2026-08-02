using System;
using System.Collections;
using System.Collections.Generic;
using Mirror.Examples.CharacterSelection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TS_CharacterSelector : MonoBehaviour
{
	public enum OpenMode
	{
		Normal = 0,
		PendingNewGame = 1,
		PendingJoinGame = 2
	}

	[Header("UI References")]
	[SerializeField]
	private Button closeButton;

	[SerializeField]
	private Button startNewGameButton;

	[SerializeField]
	private Button startJoinGameButton;

	[SerializeField]
	private Button leftButton;

	[SerializeField]
	private Button rightButton;

	[SerializeField]
	private TextMeshProUGUI characterNameText;

	[Header("Panels")]
	[SerializeField]
	private CanvasGroup mainButtonsPanel;

	[SerializeField]
	private CanvasGroup characterSelectionPanel;

	[Header("Virtual Cameras")]
	[SerializeField]
	private GameObject mainVirtualCamera;

	[SerializeField]
	private GameObject podiumVirtualCamera;

	[Header("Character")]
	[SerializeField]
	private Transform podiumPosition;

	[Header("Podium Lights")]
	[SerializeField]
	private float lightsDelay = 0.5f;

	[SerializeField]
	private List<GameObject> podiumLightsTurnOn;

	[SerializeField]
	private List<GameObject> podiumLightsTurnOff;

	[Header("Camera Blend")]
	[SerializeField]
	private float cameraBlendDuration = 1f;

	private CharacterData characterData;

	private int selectedCharacterIndex = 1;

	private GameObject currentPreviewCharacter;

	private Action onCloseCallback;

	private bool isOpen;

	private void Start()
	{
		characterData = CharacterData.characterDataSingleton;
		if (characterData == null)
		{
			Debug.LogError("CharacterData singleton not found in scene!");
			return;
		}
		closeButton.onClick.AddListener(CloseCharacterSelection);
		if (startNewGameButton != null)
		{
			startNewGameButton.onClick.AddListener(CloseCharacterSelection);
		}
		if (startJoinGameButton != null)
		{
			startJoinGameButton.onClick.AddListener(CloseCharacterSelection);
		}
		leftButton.onClick.AddListener(PreviousCharacter);
		rightButton.onClick.AddListener(NextCharacter);
		if (startNewGameButton != null)
		{
			startNewGameButton.gameObject.SetActive(value: false);
		}
		if (startJoinGameButton != null)
		{
			startJoinGameButton.gameObject.SetActive(value: false);
		}
		SetPanelActive(characterSelectionPanel, active: false);
		SetPanelActive(mainButtonsPanel, active: true);
		mainVirtualCamera.SetActive(value: true);
		podiumVirtualCamera.SetActive(value: false);
	}

	private void Update()
	{
		if (isOpen && Input.GetKeyDown(KeyCode.Escape))
		{
			onCloseCallback = null;
			if (closeButton != null)
			{
				closeButton.gameObject.SetActive(value: true);
			}
			CloseCharacterSelection();
		}
	}

	public void OpenCharacterSelection(Action callback = null, OpenMode mode = OpenMode.Normal)
	{
		Debug.Log("TS_CharacterSelector.OpenCharacterSelection çağrıldı");
		onCloseCallback = callback;
		isOpen = true;
		bool flag = mode != OpenMode.Normal;
		if (startNewGameButton != null)
		{
			startNewGameButton.gameObject.SetActive(mode == OpenMode.PendingNewGame);
		}
		if (startJoinGameButton != null)
		{
			startJoinGameButton.gameObject.SetActive(mode == OpenMode.PendingJoinGame);
		}
		if (closeButton != null)
		{
			closeButton.gameObject.SetActive(!flag);
		}
		SetPanelActive(mainButtonsPanel, active: false);
		SetPanelActive(characterSelectionPanel, active: true);
		if (mainVirtualCamera != null)
		{
			mainVirtualCamera.SetActive(value: false);
		}
		if (podiumVirtualCamera != null)
		{
			podiumVirtualCamera.SetActive(value: true);
		}
		StartCoroutine(SetLightsForOpen());
		LoadSavedSelection();
	}

	private IEnumerator SetLightsForOpen()
	{
		yield return new WaitForSeconds(lightsDelay);
		foreach (GameObject item in podiumLightsTurnOn)
		{
			if (item != null)
			{
				item.SetActive(value: true);
			}
		}
		foreach (GameObject item2 in podiumLightsTurnOff)
		{
			if (item2 != null)
			{
				item2.SetActive(value: false);
			}
		}
	}

	public void CloseCharacterSelection()
	{
		isOpen = false;
		SetPanelActive(characterSelectionPanel, active: false);
		podiumVirtualCamera.SetActive(value: false);
		mainVirtualCamera.SetActive(value: true);
		StartCoroutine(SetLightsForClose());
		if (currentPreviewCharacter != null)
		{
			UnityEngine.Object.Destroy(currentPreviewCharacter);
			currentPreviewCharacter = null;
		}
		if (onCloseCallback != null)
		{
			Action callback = onCloseCallback;
			onCloseCallback = null;
			StartCoroutine(InvokeAfterBlend(callback));
		}
		else
		{
			SetPanelActive(mainButtonsPanel, active: true);
		}
	}

	private IEnumerator InvokeAfterBlend(Action callback)
	{
		yield return new WaitForSeconds(cameraBlendDuration);
		callback();
	}

	private IEnumerator SetLightsForClose()
	{
		yield return new WaitForSeconds(lightsDelay);
		foreach (GameObject item in podiumLightsTurnOn)
		{
			if (item != null)
			{
				item.SetActive(value: false);
			}
		}
		foreach (GameObject item2 in podiumLightsTurnOff)
		{
			if (item2 != null)
			{
				item2.SetActive(value: true);
			}
		}
	}

	private void SetPanelActive(CanvasGroup panel, bool active)
	{
		if (!(panel == null))
		{
			if (active)
			{
				panel.gameObject.SetActive(value: true);
			}
			panel.alpha = (active ? 1f : 0f);
			panel.interactable = active;
			panel.blocksRaycasts = active;
		}
	}

	public void NextCharacter()
	{
		selectedCharacterIndex++;
		if (selectedCharacterIndex >= characterData.characterPrefabs.Length)
		{
			selectedCharacterIndex = 1;
		}
		ApplySelection();
	}

	public void PreviousCharacter()
	{
		selectedCharacterIndex--;
		if (selectedCharacterIndex < 1)
		{
			selectedCharacterIndex = characterData.characterPrefabs.Length - 1;
		}
		ApplySelection();
	}

	private void ApplySelection()
	{
		StaticVariables.characterNumber = selectedCharacterIndex;
		PlayerPrefs.SetInt("SelectedCharacter", selectedCharacterIndex);
		PlayerPrefs.Save();
		UpdateCharacterName();
		UpdatePreviewCharacter();
	}

	private void UpdateCharacterName()
	{
		if (!(characterNameText == null))
		{
			string text = ((characterData.characterTitles != null && selectedCharacterIndex < characterData.characterTitles.Length) ? characterData.characterTitles[selectedCharacterIndex] : ("Character " + selectedCharacterIndex));
			characterNameText.text = text;
		}
	}

	private void UpdatePreviewCharacter()
	{
		if (!(podiumPosition == null))
		{
			if (currentPreviewCharacter != null)
			{
				UnityEngine.Object.Destroy(currentPreviewCharacter);
			}
			GameObject original = ((characterData.previewPrefabs != null && selectedCharacterIndex < characterData.previewPrefabs.Length) ? characterData.previewPrefabs[selectedCharacterIndex] : characterData.characterPrefabs[selectedCharacterIndex]);
			currentPreviewCharacter = UnityEngine.Object.Instantiate(original, podiumPosition);
			currentPreviewCharacter.transform.localPosition = Vector3.zero;
			currentPreviewCharacter.transform.localRotation = Quaternion.identity;
			currentPreviewCharacter.transform.localScale = Vector3.one;
		}
	}

	private void LoadSavedSelection()
	{
		int num = PlayerPrefs.GetInt("SelectedCharacter", 1);
		if (num > 0 && num < characterData.characterPrefabs.Length)
		{
			selectedCharacterIndex = num;
		}
		else
		{
			selectedCharacterIndex = 1;
		}
		StaticVariables.characterNumber = selectedCharacterIndex;
		UpdateCharacterName();
		UpdatePreviewCharacter();
	}

	public int GetSelectedCharacterIndex()
	{
		return selectedCharacterIndex;
	}

	private void OnDestroy()
	{
		if (currentPreviewCharacter != null)
		{
			UnityEngine.Object.Destroy(currentPreviewCharacter);
		}
	}
}
