using UnityEngine;

public class TriggerBase : MonoBehaviour
{
	public delegate void TriggerCallback();

	private TriggerCallback currentCallback;

	public virtual void ProcessTrigger(TriggerCallback callback)
	{
		currentCallback = callback;
	}

	public virtual void FinishTrigger()
	{
		currentCallback();
		Object.Destroy(base.gameObject);
	}
}
