using TMPro;
using UnityEngine;

public class testtmp3 : MonoBehaviour
{
	private TMP_Text mytxt;

	public TMP_Text line_number_txt;

	private void Start()
	{
		mytxt = GetComponent<TMP_Text>();
	}

	private void Update()
	{
		string text = "";
		bool flag = true;
		int num = 0;
		for (int i = 0; i < mytxt.textInfo.lineInfo.Length; i++)
		{
			Debug.Log(i);
			if (flag)
			{
				flag = false;
				if (mytxt.text[mytxt.textInfo.lineInfo[i].firstCharacterIndex] != '#' && mytxt.textInfo.lineInfo[i].visibleCharacterCount > 0)
				{
					num++;
					text += num;
				}
			}
			text += "\n";
			if (mytxt.text[mytxt.textInfo.lineInfo[i].lastCharacterIndex] == '\n')
			{
				flag = true;
			}
		}
		line_number_txt.text = text;
	}
}
