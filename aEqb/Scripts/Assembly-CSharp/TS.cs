using UnityEngine;
using UnityEngine.UI;

public class TS : MonoBehaviour
{
	private Text myText;

	public Text OtherText;

	private void Start()
	{
		myText = GetComponent<Text>();
	}

	private void Update()
	{
		Canvas.ForceUpdateCanvases();
		string text = "";
		int num = 0;
		bool flag = true;
		for (int i = 0; i < myText.cachedTextGenerator.lines.Count; i++)
		{
			int startCharIdx = myText.cachedTextGenerator.lines[i].startCharIdx;
			int num2 = ((i == myText.cachedTextGenerator.lines.Count - 1) ? myText.text.Length : myText.cachedTextGenerator.lines[i + 1].startCharIdx) - startCharIdx;
			if (flag)
			{
				if (num2 > 2)
				{
					num++;
					text += num;
				}
				flag = false;
			}
			if (myText.text[startCharIdx + num2 - 1] == '\n')
			{
				flag = true;
			}
			text += "\n";
			Debug.Log(myText.text.Substring(startCharIdx, num2));
		}
		OtherText.text = text;
	}
}
