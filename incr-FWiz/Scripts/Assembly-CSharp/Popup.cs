using UnityEngine;

public abstract class Popup : MonoBehaviour
{
	public abstract string ID { get; }

	public abstract bool CanHandle(object obj);

	public bool Handle(object obj)
	{
		return false;
	}

	protected abstract bool DoHandle(object obj);

	protected void End()
	{
	}

	public void PopTopPopup()
	{
	}
}
