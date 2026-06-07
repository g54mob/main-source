using UnityEngine;

public class VersionHandler : MonoBehaviour
{
	public static VersionHandler Singleton;

	public string versionPrefix;

	public string gameVersion;

	private void Awake()
	{
		Object.DontDestroyOnLoad(this);
		if ((bool)Singleton)
		{
			base.gameObject.SetActive(value: false);
			Object.Destroy(base.gameObject);
		}
		else
		{
			Singleton = this;
		}
	}
}
