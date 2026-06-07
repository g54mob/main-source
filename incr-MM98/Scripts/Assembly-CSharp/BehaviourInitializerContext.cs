using UnityEngine;

public class BehaviourInitializerContext : InitializerContext<Behaviour>
{
	public BehaviourInitializerContext GetComponent<T>(out T result)
	{
		result = Target.GetComponent<T>();
		return this;
	}

	public BehaviourInitializerContext GetComponentInChildren<T>(out T result)
	{
		result = Target.GetComponentInChildren<T>();
		return this;
	}

	public BehaviourInitializerContext GetComponentInParent<T>(out T result)
	{
		result = Target.GetComponentInParent<T>();
		return this;
	}
}
