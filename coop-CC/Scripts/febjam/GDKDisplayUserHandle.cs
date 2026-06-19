using TMPro;
using UnityEngine;

public class GDKDisplayUserHandle : MonoBehaviour
{
	public TMP_Text text;

	private void Awake()
	{
		base.gameObject.SetActive(value: false);
	}
}
