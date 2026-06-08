using UnityEngine;

public class FileCounter : MonoBehaviour
{
	private void Start()
	{
		AsciiSprite[] array = Object.FindObjectsOfType<AsciiSprite>();
		AsciiAnimation[] array2 = Object.FindObjectsOfType<AsciiAnimation>();
		Debug.LogError("Sprites: " + array.Length);
		Debug.LogError("Animations: " + array2.Length);
		int num = 0;
		int num2 = 0;
		AsciiSprite[] array3 = array;
		foreach (AsciiSprite asciiSprite in array3)
		{
			asciiSprite.Load();
			if (asciiSprite.data == null || asciiSprite.data.Pages == null)
			{
				continue;
			}
			foreach (AsciiData.Page page in asciiSprite.data.Pages)
			{
				num2 += page.width * page.height;
			}
		}
		AsciiAnimation[] array4 = array2;
		foreach (AsciiAnimation asciiAnimation in array4)
		{
			if (!(asciiAnimation.Sprite == null))
			{
				asciiAnimation.Sprite.Load();
				if (asciiAnimation.Sprite.data != null && asciiAnimation.Sprite.data.Pages != null)
				{
					num += asciiAnimation.Sprite.data.Pages.Count;
				}
			}
		}
		Debug.LogError("Total frames: " + num);
		Debug.LogError("Total glyphs: " + num2);
	}
}
