using R3;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class GamePauseToggle : MonoBehaviour, InputListener.IHandler
{
	[SerializeField]
	private GameObject paused;

	[SerializeField]
	private GameObject unpaused;

	public int Priority => 0;

	private void Awake()
	{
		MonoSingleton<InputListener>.Instance.Register(this);
		GetComponent<Button>().onClick.AddListener(Database.State.Studio.Paused.Toggle);
		Database.State.Studio.Paused.SubscribeToSetToggle(paused, unpaused).AddTo(this);
	}

	private void OnDestroy()
	{
		if (MonoSingleton<InputListener>.HasInstance)
		{
			MonoSingleton<InputListener>.Instance.Unregister(this);
		}
	}

	public void Handle(InputEvent ctx)
	{
		if (ctx.Input == InputEvent.Key.Pause)
		{
			Database.State.Studio.Paused.Toggle();
			ctx.Consume();
		}
	}
}
