using UnityEngine;
using UnityEngine.UI;

public class StatisticFieldController : ActiveComponent
{
	private Image image;

	private Text text;

	private static Color greenColor;

	private static Color redColor;

	public static Color greyColor;

	public void SetSprite(Sprite sprite)
	{
		image.sprite = sprite;
	}

	protected override void OnInit()
	{
		base.OnInit();
		image = base.gameObject.GetComponent<Image>();
		text = base.gameObject.GetComponentInChildren<Text>();
		greenColor = Logic.GetColor("GREEN");
		redColor = Logic.GetColor("RED");
		greyColor = Logic.GetColor("GRAYUNDERBLOCK");
	}

	public void Init(Sprite sprite)
	{
		base.Init();
		SetSprite(sprite);
	}

	public void SetColor(Color color)
	{
		image.color = color;
		text.gameObject.SetActive(color == Color.white);
	}

	public void SetPrecision(float precision)
	{
		text.text = (int)(100f * precision) + "%";
		text.color = greenColor * precision + redColor * (1f - precision);
	}
}
