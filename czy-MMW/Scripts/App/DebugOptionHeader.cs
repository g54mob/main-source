using TMPro;
using UnityEngine;

public class DebugOptionHeader : MonoBehaviour
{
	public TMP_Text headerText;

	public void Initialize(string newHeaderText)
	{
		headerText.text = newHeaderText;
	}
}
