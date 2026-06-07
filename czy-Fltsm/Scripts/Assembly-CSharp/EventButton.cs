using UnityEngine;
using UnityEngine.UI;

public abstract class EventButton : Button
{
	[SerializeField]
	private GameEventType _gameEventType;

	protected override void OnEnable()
	{
		GameEventDispatcher.AddListener(_gameEventType, OnEvent);
	}

	protected override void OnDisable()
	{
		GameEventDispatcher.RemoveListener(_gameEventType, OnEvent);
	}

	private void OnEvent(GameEvent gameEvent)
	{
		SetInteractable(ReturnCanInteract(gameEvent));
	}

	private void SetInteractable(bool canInteract)
	{
		base.interactable = canInteract;
	}

	protected abstract bool ReturnCanInteract(GameEvent gameEvent);
}
