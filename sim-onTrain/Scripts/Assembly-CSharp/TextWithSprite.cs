using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextWithSprite : MonoBehaviour
{
	[Header("Components")]
	public TextMeshProUGUI textComponent;

	public Image inlineImage;

	[Header("Settings")]
	public string originalText = "Test Text";

	public int imagePosition = 4;

	public int spaceCount = 4;

	private void Start()
	{
		InsertImageAtPosition(imagePosition);
	}

	public void InsertImageAtPosition(int position)
	{
		string value = new string(' ', spaceCount);
		originalText = textComponent.text;
		string text = originalText.Insert(position, value);
		textComponent.text = text;
		StartCoroutine(CenterImageInSpace(position));
	}

	private IEnumerator CenterImageInSpace(int spaceStartPosition)
	{
		yield return new WaitForEndOfFrame();
		textComponent.ForceMeshUpdate();
		TMP_TextInfo textInfo = textComponent.textInfo;
		int num = spaceStartPosition + spaceCount - 1;
		if (num < textInfo.characterCount)
		{
			Vector3 bottomLeft = textInfo.characterInfo[spaceStartPosition].bottomLeft;
			Vector3 bottomRight = textInfo.characterInfo[num].bottomRight;
			Vector3 position = (bottomLeft + bottomRight) / 2f;
			float num2 = textInfo.characterInfo[spaceStartPosition].topLeft.y - textInfo.characterInfo[spaceStartPosition].bottomLeft.y;
			position.y += num2 / 2f;
			Vector3 vector = textComponent.transform.TransformPoint(position);
			inlineImage.transform.position = vector;
			Debug.Log($"Image positioned at: {vector}");
		}
	}

	public void UpdateTextWithImage(string newText, int newPosition)
	{
		originalText = newText;
		imagePosition = newPosition;
		InsertImageAtPosition(imagePosition);
	}

	public void AdjustImageSizeToText()
	{
		StartCoroutine(AdjustImageSizeCoroutine());
	}

	private IEnumerator AdjustImageSizeCoroutine()
	{
		yield return new WaitForEndOfFrame();
		textComponent.ForceMeshUpdate();
		TMP_TextInfo textInfo = textComponent.textInfo;
		if (textInfo.characterCount > 0)
		{
			float num = textInfo.characterInfo[0].topLeft.y - textInfo.characterInfo[0].bottomLeft.y;
			inlineImage.GetComponent<RectTransform>().sizeDelta = new Vector2(num, num);
		}
	}
}
