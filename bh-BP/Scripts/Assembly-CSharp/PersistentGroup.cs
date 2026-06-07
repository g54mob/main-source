using UnityEngine;

public class PersistentGroup : MonoBehaviour
{
	public static PersistentGroup I;

	public GameObject[] SingletonPrefabs;

	public GameObject[] MobilePrefabs;

	private void Awake()
	{
	}
}
