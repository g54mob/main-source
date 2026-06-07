using TMPro;
using UnityEngine;

[SelectionBase]
public class SignText : MonoBehaviour
{
	public string text;

	private void Start()
	{
		UpdateText();
	}

	private void OnValidate()
	{
		UpdateText();
	}

	private void UpdateText()
	{
		TextMeshPro[] componentsInChildren = GetComponentsInChildren<TextMeshPro>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].text = text;
		}
	}
}
