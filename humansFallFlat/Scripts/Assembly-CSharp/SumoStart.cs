using UnityEngine;

public class SumoStart : MonoBehaviour
{
	private void Start()
	{
		Object[] array = Resources.LoadAll(string.Empty);
		Object[] array2 = array;
		foreach (Object obj in array2)
		{
			Debug.Log("object: " + obj.name + " : " + obj.GetType().ToString());
		}
	}
}
