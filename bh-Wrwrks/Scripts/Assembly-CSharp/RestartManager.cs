using UnityEngine;

public class RestartManager : MonoBehaviour
{
	private static RestartManager _instance;

	public bool restarter;

	public bool menuTransition;

	public bool win;

	public static RestartManager Instance => _instance;

	private void Awake()
	{
		if (_instance != null)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		if (_instance != null && _instance != this)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			_instance = this;
		}
		Object.DontDestroyOnLoad(base.gameObject);
	}
}
