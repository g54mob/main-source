using UnityEngine;

public class EpilepsyHandler : MonoBehaviour
{
	public void OnEnable()
	{
		if (PlayerPrefs.GetInt("Epilepsy", 0) == 1)
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
