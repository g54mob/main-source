using UnityEngine;

public class MainInstantiator : MonoBehaviour
{
	public static bool isLoadingComplete;

	public GameObject[] essentialPrefabs;

	public GameObject[] lateLoadPrefabs;

	public string[] preloadAddressables;

	private int frameSkip;

	private int lateLoadIndex = -1;

	private void Start()
	{
		for (int i = 0; i < essentialPrefabs.Length; i++)
		{
			if (essentialPrefabs[i] != null)
			{
				Object.Instantiate(essentialPrefabs[i]);
			}
		}
	}

	private void Update()
	{
		if (++frameSkip % 2 != 0)
		{
			return;
		}
		if (lateLoadIndex > lateLoadPrefabs.Length)
		{
			isLoadingComplete = true;
			PreloadAddressables();
			Object.Destroy(base.gameObject);
			return;
		}
		if (lateLoadIndex >= 0 && lateLoadIndex < lateLoadPrefabs.Length)
		{
			Object.Instantiate(lateLoadPrefabs[lateLoadIndex]);
		}
		lateLoadIndex++;
	}

	private void PreloadAddressables()
	{
		for (int i = 0; i < preloadAddressables.Length; i++)
		{
			Utils.PreloadAsyncPrefab(preloadAddressables[i]);
		}
	}
}
