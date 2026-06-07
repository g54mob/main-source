using UnityEngine;

public class AppStoreBase : MonoBehaviour
{
	public static AppStoreBase Instance;

	public AppStoreBaseData[] ApplicationBase;

	private void Awake()
	{
	}

	private void OnValidate()
	{
	}

	public AppStoreBaseData GetAppByName(string NameIdentifierInAppBase)
	{
		return null;
	}
}
