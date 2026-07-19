using UnityEngine;
using UnityEngine.UI;

public class Hints : MonoBehaviour
{
	public Sprite[] hints;

	public static Hints instance { get; private set; }

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		SetHint("default");
	}

	public void SetHint(string type)
	{
		Sprite[] array = hints;
		foreach (Sprite sprite in array)
		{
			if (sprite.name == type)
			{
				GetComponent<Image>().sprite = sprite;
				break;
			}
		}
	}

	public void SetColor(Color color, float alpha)
	{
		color.a = alpha;
		GetComponent<Image>().color = color;
	}
}
