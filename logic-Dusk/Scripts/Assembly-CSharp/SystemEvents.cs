using UnityEngine;
using UnityEngine.EventSystems;

public class SystemEvents : MonoBehaviour
{
	public static SystemEvents Instance;

	public EventSystem eventSystem;

	private void Awake()
	{
		Instance = this;
	}
}
