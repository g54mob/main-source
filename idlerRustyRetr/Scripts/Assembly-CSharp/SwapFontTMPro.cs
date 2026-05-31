using TMPro;
using UnityEngine;

public class SwapFontTMPro : MonoBehaviour
{
	private TMP_Text text;

	private TMP_FontAsset previousFont;

	private void Start()
	{
		text = GetComponent<TMP_Text>();
		CheckFont();
	}

	private void OnEnable()
	{
		CheckFont();
	}

	private void Update()
	{
		CheckFont();
	}

	private void CheckFont()
	{
		if (!(text == null) && !(text.font == GameManager.ins.fontAsset))
		{
			text.font = GameManager.ins.fontAsset;
			previousFont = text.font;
		}
	}
}
