using TMPro;
using UnityEngine;

public class TMPOutline : MonoBehaviour
{
	public float outlineWidth;

	public Color outlineColor;

	private void Awake()
	{
		TMP_Text component = GetComponent<TMP_Text>();
		component.outlineWidth = outlineWidth;
		component.outlineColor = outlineColor;
	}
}
