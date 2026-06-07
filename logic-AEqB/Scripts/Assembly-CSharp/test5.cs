using TMPro;
using UnityEngine;

public class test5 : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
		GetComponent<TMP_InputField>().ForceLabelUpdate();
	}
}
