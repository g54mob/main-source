using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
	public Sprite[] sprites;

	public void SetSprite(int index)
	{
		if ((bool)GetComponent<Image>())
		{
			GetComponent<Image>().sprite = sprites[index];
		}
	}
}
