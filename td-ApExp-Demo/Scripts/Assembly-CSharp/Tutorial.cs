using UnityEngine;

public class Tutorial : MonoBehaviour
{
	private void Awake()
	{
		GameManager.Instance.GetComponent<AnyInputPressed>().onAnyInputPressed += OnAnyInputPressed;
	}

	private void OnAnyInputPressed()
	{
		if (Time.time > 0.5f)
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
