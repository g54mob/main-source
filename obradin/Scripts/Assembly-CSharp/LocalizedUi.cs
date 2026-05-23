using UnityEngine;
using UnityEngine.UI;

public class LocalizedUi : MonoBehaviour
{
	public enum Kind
	{
		None = 0,
		Image = 1,
		Text = 2
	}

	[Readonly]
	public Kind kind;

	[Readonly]
	public string id;

	public void ApplyLocalization()
	{
		if (kind == Kind.Image)
		{
			Image component = GetComponent<Image>();
			component.sprite = Lang.GetSprite(id);
		}
		else if (kind == Kind.Text)
		{
			Text component2 = GetComponent<Text>();
			component2.text = Lang.GetGendered(id, SaveData.it.generalRo.playerGender);
		}
	}

	public static void ApplyLocalization(GameObject rootGo)
	{
		LocalizedUi[] componentsInChildren = rootGo.GetComponentsInChildren<LocalizedUi>(true);
		foreach (LocalizedUi localizedUi in componentsInChildren)
		{
			localizedUi.ApplyLocalization();
		}
	}
}
