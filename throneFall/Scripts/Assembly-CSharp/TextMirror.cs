using TMPro;
using UnityEngine;

public class TextMirror : MonoBehaviour
{
	public TextMeshProUGUI toMirror;

	public TextMeshProUGUI ownTMP;

	private void Update()
	{
		ownTMP.text = toMirror.text;
	}
}
