using PajamaLlama.Utilities;
using Rewired;
using Rewired.Integration.UnityUI;
using RewiredConsts;
using UnityEngine;

public class RewiredStandaloneInputModuleMap : MonoBehaviour
{
	[SerializeField]
	private RewiredStandaloneInputModule _inputModule;

	[SerializeField]
	[ActionIdProperty(typeof(Action))]
	private int _horizontalActionId;

	[SerializeField]
	[ActionIdProperty(typeof(Action))]
	private int _verticalActionId;

	[SerializeField]
	[ActionIdProperty(typeof(Action))]
	private int _horizontalRestrictedActionId;

	[SerializeField]
	[ActionIdProperty(typeof(Action))]
	private int _verticalRestrictedActionId;

	private void Awake()
	{
		GameEventDispatcher.AddListener(GameEventType.GameStartedLoading, OnGameStartedLoading);
		if (LoadingScreen.IsLoading)
		{
			GameEventDispatcher.AddListener(GameEventType.GameStart, OnGameStart);
		}
		else
		{
			OnGameStart();
		}
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.GameStartedLoading, OnGameStartedLoading);
		GameEventDispatcher.RemoveListener(GameEventType.GameStart, OnGameStart);
		GameEventDispatcher.RemoveListener(GameEventType.UIFlagsUpdated, OnUIFlagsUpdated);
	}

	public void Restrict()
	{
		_inputModule.HorizontalActionId = _horizontalRestrictedActionId;
		_inputModule.VerticalActionId = _verticalRestrictedActionId;
	}

	public void Unrestrict()
	{
		_inputModule.HorizontalActionId = _horizontalActionId;
		_inputModule.VerticalActionId = _verticalActionId;
	}

	private void OnGameStartedLoading(GameEvent gameEvent)
	{
		Unrestrict();
		FinalUpdate.RegisterOneShot(delegate
		{
			GameEventDispatcher.AddListener(GameEventType.GameStartedLoading, OnGameStartedLoading);
			GameEventDispatcher.AddListener(GameEventType.GameStart, OnGameStart);
		});
	}

	private void OnGameStart(GameEvent gameEvent = null)
	{
		GameEventDispatcher.RemoveListener(GameEventType.GameStart, OnGameStart);
		GameEventDispatcher.AddListener(GameEventType.UIFlagsUpdated, OnUIFlagsUpdated);
		OnUIFlagsUpdated();
	}

	private void OnUIFlagsUpdated(GameEvent gameEvent = null)
	{
		if (UIManager.HasFlagsSet(PanelContainerFlags.RestrictUINavigation))
		{
			Restrict();
		}
		else
		{
			Unrestrict();
		}
	}
}
