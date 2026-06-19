using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FloraEffect : MonoBehaviour
{
	public TextMeshProUGUI floraEffectText;

	public Image raritySymbolSprite;

	public void SetText(string text, bool unlocked)
	{
		if (unlocked)
		{
			floraEffectText.text = text;
			floraEffectText.color = Color.white;
		}
		else
		{
			floraEffectText.color = Color.black;
			floraEffectText.text = TextUtil.GetHiddenString(text);
		}
	}

	public void SetRarity(Rarity r, bool unlocked)
	{
		FloraManager globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<FloraManager>(GlobalObject.FLORA_MANAGER);
		raritySymbolSprite.sprite = globalComponent.GetSymbolForRarity(r);
		if (unlocked)
		{
			raritySymbolSprite.color = Color.white;
		}
		else
		{
			raritySymbolSprite.color = Color.black;
		}
	}
}
