using UnityEngine;

public class DestroyOrDisableOnEnable : MonoBehaviour
{
	[SerializeField]
	private Hp[] destroy;

	[SerializeField]
	private GameObject[] disable;

	private void OnEnable()
	{
		Hp[] array = destroy;
		foreach (Hp hp in array)
		{
			if (hp.gameObject.activeInHierarchy)
			{
				hp.TakeDamage(1E+09f);
			}
		}
		GameObject[] array2 = disable;
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i].SetActive(value: false);
		}
	}
}
