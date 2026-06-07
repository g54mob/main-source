using TMPro;
using UnityEngine;

public class TextSizeControl : MonoBehaviour
{
	private TMP_Text txt;

	private void Start()
	{
		txt = GetComponent<TMP_Text>();
	}

	private void Update()
	{
		txt.enableAutoSizing = true;
		txt.fontSizeMax = Screen.height / 60;
		txt.enableWordWrapping = true;
	}
}
