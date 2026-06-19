using UnityEngine.Events;

public class CoreButton : DogButtonBase
{
	public delegate void OnClickDelegate();

	public delegate void OnClickDelegateArg(object i);

	public bool startActive = true;

	public UnityEvent onClickEvents;

	private OnClickDelegate onClickCallback;

	private object clickCallbackArg;

	private OnClickDelegateArg onClickCallbackArg;

	protected override void OnStart()
	{
		base.OnStart();
		if (!startActive)
		{
			LockScale();
		}
	}

	public void SetCallback(OnClickDelegate callback)
	{
		onClickCallback = callback;
	}

	public void SetArgCallback(OnClickDelegateArg callback, object arg)
	{
		clickCallbackArg = arg;
		onClickCallbackArg = callback;
	}

	public void SetCallbackArg(object arg)
	{
		clickCallbackArg = arg;
	}

	protected override void ButtonBehavior()
	{
		onClickEvents?.Invoke();
		onClickCallback?.Invoke();
		onClickCallbackArg?.Invoke(clickCallbackArg);
	}
}
