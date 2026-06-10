using UnityEngine;

public class SingletonPersistent<T> : MonoBehaviour where T : Component
{
	public static T Instance { get; private set; }

	public virtual void Awake()
	{
	}
}
