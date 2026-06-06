using UnityEngine;

public class SceneBehaviour : MonoBehaviour
{
	public static bool Ignore;

	protected virtual void Awake()
	{
		if (!GameManager.Initialized && base.enabled && !Ignore)
		{
			base.enabled = false;
			GameEventDispatcher.AddListener(GameEventType.GameStart, OnGameStart);
		}
	}

	private void OnGameStart(GameEvent gameEvent)
	{
		GameEventDispatcher.RemoveListener(GameEventType.GameStart, OnGameStart);
		base.enabled = true;
		OnGameStart();
	}

	protected virtual void OnGameStart()
	{
	}
}
