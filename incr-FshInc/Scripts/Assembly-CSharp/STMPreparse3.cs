using UnityEngine;

public class STMPreparse3 : MonoBehaviour
{
	public string textTag = "transcribe";

	public void Parse(STMTextContainer x)
	{
		string text = "<" + textTag + ">";
		string text2 = "</" + textTag + ">";
		int num;
		do
		{
			num = x.text.IndexOf(text);
			int num2 = ((num > -1) ? x.text.IndexOf(text2, num) : (-1));
			if (num2 == -1)
			{
				num2 = x.text.Length;
			}
			else
			{
				x.text = x.text.Remove(num2, text2.Length);
			}
			if (num > -1)
			{
				x.text = x.text.Remove(num, text.Length);
				num2 -= text.Length;
				Replace(x, num, num2);
			}
		}
		while (num > -1);
	}

	private void Replace(STMTextContainer x, int startingPoint, int endingPoint)
	{
		int num = startingPoint;
		bool flag = true;
		for (int i = startingPoint; i < endingPoint; i++)
		{
			string text = x.text[num].ToString();
			if (text == "<")
			{
				flag = false;
			}
			else if (text == ">")
			{
				flag = true;
			}
			if (flag)
			{
				string text2 = x.text[num].ToString().ToUpper();
				if (!(text2 == "A"))
				{
					if (text2 == "B")
					{
						text = "bbb";
					}
				}
				else
				{
					text = "aaa";
				}
				x.text = x.text.Remove(num, 1);
				x.text = x.text.Insert(num, text);
			}
			num += text.Length;
		}
	}
}
