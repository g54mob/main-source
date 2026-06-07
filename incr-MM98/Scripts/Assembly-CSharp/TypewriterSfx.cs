using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_InputField))]
public class TypewriterSfx : MonoBehaviour
{
	private void Awake()
	{
		GetComponent<TMP_InputField>().onValueChanged.AddListener(delegate
		{
			Audio.PlayTypewriterClick();
		});
	}
}
