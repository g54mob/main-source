using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public static class TextImagePositioner
{
	public static void PositionImageInText(TextMeshProUGUI text, Image image, int position, int spaceCount = 4)
	{
		string text2 = text.text;
		string value = new string(' ', spaceCount);
		text.text = text2.Insert(position, value);
		text.StartCoroutine(PositionImageCoroutine(text, image, position, spaceCount));
	}

	private static IEnumerator PositionImageCoroutine(TextMeshProUGUI text, Image image, int startPos, int spaceCount)
	{
		yield return new WaitForEndOfFrame();
		text.ForceMeshUpdate();
		TMP_TextInfo textInfo = text.textInfo;
		int num = startPos + spaceCount - 1;
		if (num < textInfo.characterCount)
		{
			Vector3 bottomLeft = textInfo.characterInfo[startPos].bottomLeft;
			Vector3 bottomRight = textInfo.characterInfo[num].bottomRight;
			Vector3 position = (bottomLeft + bottomRight) / 2f;
			float num2 = textInfo.characterInfo[startPos].topLeft.y - textInfo.characterInfo[startPos].bottomLeft.y;
			position.y += num2 / 2f;
			Vector3 position2 = text.transform.TransformPoint(position);
			image.transform.position = position2;
		}
	}
}
