using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MultipleImagesInText : MonoBehaviour
{
	[Serializable]
	public class ImageInTextData
	{
		public int position;

		public Image imageComponent;

		public int spaceCount = 4;

		[HideInInspector]
		public int actualStartPos;

		[HideInInspector]
		public int actualEndPos;
	}

	[Header("Components")]
	public TextMeshProUGUI textComponent;

	[Header("Images")]
	public ImageInTextData[] images;

	[Header("Settings")]
	public string baseText = "Test Text With Multiple Images";

	private void Start()
	{
		SetupMultipleImages();
	}

	public void SetupMultipleImages()
	{
		string text = baseText;
		int num = 0;
		Array.Sort(images, (ImageInTextData a, ImageInTextData b) => a.position.CompareTo(b.position));
		for (int num2 = 0; num2 < images.Length; num2++)
		{
			string value = new string(' ', images[num2].spaceCount);
			int num3 = images[num2].position + num;
			text = text.Insert(num3, value);
			images[num2].actualStartPos = num3;
			images[num2].actualEndPos = num3 + images[num2].spaceCount - 1;
			num += images[num2].spaceCount;
		}
		textComponent.text = text;
		StartCoroutine(PositionAllImages());
	}

	private IEnumerator PositionAllImages()
	{
		yield return new WaitForEndOfFrame();
		textComponent.ForceMeshUpdate();
		TMP_TextInfo textInfo = textComponent.textInfo;
		ImageInTextData[] array = images;
		foreach (ImageInTextData imageInTextData in array)
		{
			if (imageInTextData.actualEndPos < textInfo.characterCount)
			{
				Vector3 bottomLeft = textInfo.characterInfo[imageInTextData.actualStartPos].bottomLeft;
				Vector3 bottomRight = textInfo.characterInfo[imageInTextData.actualEndPos].bottomRight;
				Vector3 position = (bottomLeft + bottomRight) / 2f;
				float num = textInfo.characterInfo[imageInTextData.actualStartPos].topLeft.y - textInfo.characterInfo[imageInTextData.actualStartPos].bottomLeft.y;
				position.y += num / 2f;
				Vector3 position2 = textComponent.transform.TransformPoint(position);
				imageInTextData.imageComponent.transform.position = position2;
			}
		}
	}
}
