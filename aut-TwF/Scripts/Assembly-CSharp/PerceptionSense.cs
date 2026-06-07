using UnityEngine;

public abstract class PerceptionSense : MonoBehaviour
{
	public delegate void OnEnterSense(GameObject go);

	public delegate void OnExitSense(GameObject go);

	protected PerceptionAI perceptionAI;

	public event OnEnterSense onEnterSense;

	public event OnExitSense onExitSense;

	public virtual void InitSense(PerceptionAI perceptionAI)
	{
		this.perceptionAI = perceptionAI;
	}

	protected void CallOnEnterSense(GameObject go)
	{
		this.onEnterSense?.Invoke(go);
	}

	protected void CallOnExitSense(GameObject go)
	{
		this.onExitSense?.Invoke(go);
	}
}
