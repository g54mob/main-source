using UnityEngine;

public class STMPreParse2 : MonoBehaviour
{
	public string addToEnd = "";

	public void Parse(STMTextContainer x)
	{
		x.text += addToEnd;
	}
}
