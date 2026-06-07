using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
	public GameObject PersistPrefab;

	private void Awake()
	{
		if (!GameObject.Find("PERSIST"))
		{
			Object.Instantiate(PersistPrefab).name = "PERSIST";
		}
	}

	private void Start()
	{
	}

	private void Update()
	{
	}
}
