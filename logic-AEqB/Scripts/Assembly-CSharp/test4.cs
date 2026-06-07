using TMPro;
using UnityEngine;

public class test4 : MonoBehaviour
{
	public TMP_InputField input;

	private void Start()
	{
		input = GetComponent<TMP_InputField>();
	}

	private void Update()
	{
		input.caretPosition = 0;
	}
}
