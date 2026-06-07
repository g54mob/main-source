using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshPro))]
public class ShipName : SceneBehaviour
{
	private TextMeshPro _textMeshPro;

	protected override void Awake()
	{
		base.Awake();
		_textMeshPro = GetComponent<TextMeshPro>();
		GameEventDispatcher.AddListener(GameEventType.GameStart, SetName);
		GameEventDispatcher.AddListener(GameEventType.NewGameStart, SetName);
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.GameStart, SetName);
		GameEventDispatcher.RemoveListener(GameEventType.NewGameStart, SetName);
	}

	private void SetName(GameEvent gameEvent)
	{
		_textMeshPro.text = Community.PlayerCommunity.Name;
	}
}
