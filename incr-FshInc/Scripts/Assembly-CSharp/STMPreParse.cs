using UnityEngine;

public class STMPreParse : MonoBehaviour
{
	public string addToStart = "";

	public void Parse(STMTextContainer x)
	{
		x.text = addToStart + x.text;
	}
}
