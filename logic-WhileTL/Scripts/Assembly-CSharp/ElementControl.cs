using App.Data;
using UnityEngine.UI;

public class ElementControl : ActiveComponent
{
	public Text text;

	public Image image;

	public Outline outline;

	public void Init(Element el)
	{
		text.enabled = true;
		outline.enabled = true;
		text.gameObject.SetActive(value: true);
		if (el.word == null)
		{
			image.enabled = true;
			image.sprite = Logic.GetSpriteByKeyName(el.SpriteName);
			if (!el.IsZIPElement())
			{
				image.color = el.GetColor(ActiveComponent._staticData);
			}
			else
			{
				base.gameObject.transform.localScale *= 1.7f;
				image.color = Logic.GetColor(Logic.GetColorIdByKeyName("WHITE"));
			}
			text.enabled = false;
			outline.enabled = false;
			text.gameObject.SetActive(value: false);
			if (el.isCarElem || el.hideColor)
			{
				image.color = Logic.GetColor(Logic.GetColorIdByKeyName("WHITE"));
			}
		}
		else
		{
			text.enabled = true;
			outline.enabled = true;
			text.text = Logic.WordToString(el.word).ToUpper();
			if (!el.IsZIPElement())
			{
				image.enabled = false;
			}
			if (el.colorsQueue != null)
			{
				if (el.revealed)
				{
					text.color = Logic.GetColor(el.colorsQueue[el.iterWord] - 48);
				}
				else
				{
					text.color = Logic.GetColor("SETTINGSGREY");
				}
			}
			else
			{
				text.color = Logic.GetColor("SETTINGSGREY");
			}
		}
		base.enabled = false;
	}
}
