using UnityEngine;

public class AutoStartObjective : MonoBehaviour
{
	public string id = "Objectives";

	public string key;

	private void Start()
	{
		StoreManager.Instance.NewObjective("Objectives", key);
	}
}
