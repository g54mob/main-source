using UnityEngine;

public class GlobalRefManager : MonoBehaviour
{
	public static GlobalRefManager S;

	private void Awake()
	{
		if (S != null && S != this)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		S = this;
		Object.DontDestroyOnLoad(base.gameObject);
	}

	private void Start()
	{
	}

	private void Update()
	{
	}
}
