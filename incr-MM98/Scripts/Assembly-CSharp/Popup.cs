using UnityEngine;
using UnityEngine.UI;

public abstract class Popup : MonoBehaviour, InputListener.IHandler
{
	[SerializeField]
	private GameObject content;

	[SerializeField]
	private GameObject blocker;

	[SerializeField]
	private Button closeButton;

	[SerializeField]
	private bool submitEvent;

	[SerializeField]
	private bool cancelEvent = true;

	public int Priority => 0;

	protected virtual void Awake()
	{
		HideContent();
	}

	protected virtual void Start()
	{
		Initialize(Initializer.Context(closeButton).AddListener(OnCancel));
	}

	protected virtual void OnDestroy()
	{
		if (MonoSingleton<InputListener>.HasInstance)
		{
			MonoSingleton<InputListener>.Instance.Unregister(this);
		}
	}

	protected abstract void Initialize(StatelessInitializerContext initializer);

	public virtual void ShowContent()
	{
		content.SetActive(value: true);
		if ((bool)blocker)
		{
			blocker.SetActive(value: true);
		}
		MonoSingleton<InputListener>.Instance.Register(this);
	}

	public virtual void HideContent()
	{
		content.SetActive(value: false);
		if ((bool)blocker)
		{
			blocker.SetActive(value: false);
		}
		MonoSingleton<InputListener>.Instance.Unregister(this);
	}

	public virtual void Handle(InputEvent ctx)
	{
		if (content.activeSelf)
		{
			if (submitEvent && ctx.Input == InputEvent.Key.Submit)
			{
				OnSubmit();
				ctx.Consume();
			}
			else if (cancelEvent && ctx.Input == InputEvent.Key.Cancel)
			{
				OnCancel();
				ctx.Consume();
			}
		}
	}

	protected virtual void OnSubmit()
	{
		HideContent();
	}

	protected virtual void OnCancel()
	{
		HideContent();
	}
}
