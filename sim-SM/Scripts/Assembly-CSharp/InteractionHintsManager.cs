using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class InteractionHintsManager : NoktaSingleton<InteractionHintsManager>
{
	[SerializeField]
	private InputActionName m_InputActionName;

	[SerializeField]
	private Transform m_HintsWindow;

	[SerializeField]
	private RectTransform m_ParentVerticalLayout;

	[SerializeField]
	private VerticalLayoutGroup m_MissionVerticalLayoutGroup;

	[SerializeField]
	private LocalizeStringEvent m_HintTextPrefab;

	public bool isGamepadConnected;

	private Dictionary<int, LocalizeStringEvent> Hints;

	private RectTransform m_HintWindowDefaultRectPosition;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	private void OnGamePadConnected(bool isConnected)
	{
	}

	public void AddHint(InputActionID actionID, string actionName, string localizationEntryKey, PlayerInstance playerInstance)
	{
	}

	public void AddHint(InputActionID actionID, string actionName, string localizationEntryKey, bool isOnlyGamepad)
	{
	}

	public void AddHintOnlyGamepad(InputActionID actionID, string actionName, string localizationEntryKey)
	{
	}

	public void UpdateHints(bool isConnected)
	{
	}

	public void RemoveHint(InputActionID actionID, PlayerInstance playerInstance)
	{
	}

	public void Clear(PlayerInstance playerInstance)
	{
	}

	private void UpdateVisibility()
	{
	}

	public void MoveHintWindow(bool IsLeft)
	{
	}
}
