using UnityEngine.EventSystems;

public class SceneUIBehaviour : UIBehaviour
{
	protected override void Awake()
	{
		base.Awake();
		if (!GameManager.Initialized)
		{
			base.enabled = false;
			GameEventDispatcher.AddListener(GameEventType.GameStart, OnGameStart);
		}
	}

	private void OnGameStart(GameEvent gameEvent)
	{
		GameEventDispatcher.RemoveListener(GameEventType.GameStart, OnGameStart);
		base.enabled = true;
	}
}
