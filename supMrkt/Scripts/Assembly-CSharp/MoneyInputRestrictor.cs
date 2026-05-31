using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_InputField))]
public class MoneyInputRestrictor : MonoBehaviour
{
	private TMP_InputField m_InputField;

	private void Awake()
	{
	}

	private void OnEndEdit(string text)
	{
	}
}
