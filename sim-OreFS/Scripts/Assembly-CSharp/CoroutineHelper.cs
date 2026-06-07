using UnityEngine;

public class CoroutineHelper : MonoBehaviour
{
	private static CoroutineHelper _instance;

	public static CoroutineHelper Instance
	{
		get
		{
			if (_instance == null)
			{
				GameObject obj = new GameObject("CoroutineHelper");
				_instance = obj.AddComponent<CoroutineHelper>();
				Object.DontDestroyOnLoad(obj);
			}
			return _instance;
		}
	}

	private void OnDestroy()
	{
		if (_instance == this)
		{
			_instance = null;
		}
	}
}
