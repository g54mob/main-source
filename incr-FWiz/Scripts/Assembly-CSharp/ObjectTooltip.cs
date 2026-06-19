using UnityEngine;

public abstract class ObjectTooltip : MonoBehaviour
{
	public abstract string ID { get; }

	public abstract bool CanHandle(object obj);

	public bool Handle(object obj)
	{
		return false;
	}

	protected abstract bool DoHandle(object obj);

	public abstract bool CanWipe(object obj);

	public bool Wipe(object obj)
	{
		return false;
	}

	protected abstract bool DoWipe(object obj);
}
