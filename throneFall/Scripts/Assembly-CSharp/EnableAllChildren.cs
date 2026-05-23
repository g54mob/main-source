using UnityEngine;

public class EnableAllChildren : MonoBehaviour
{
	private void Start()
	{
		for (int i = 0; i < base.transform.childCount; i++)
		{
			base.transform.GetChild(i).gameObject.SetActive(value: true);
		}
	}
}
