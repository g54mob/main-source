using UnityEngine;

public class ReadyUpOptionSimple : ReadyUpOption
{
	[field: SerializeField]
	public ReadyUpOptionsSimple ReadyUpOptionType { get; protected set; }

	[field: SerializeField]
	protected float LocalizationDisplayValue { get; set; }

	protected new void Awake()
	{
		base.Awake();
		base.LocalizationString.Arguments = new object[1] { base.Value };
		base.DescriptionTxt.text = base.LocalizationString.GetLocalizedString();
	}

	public override void ApplyOption()
	{
		switch (ReadyUpOptionType)
		{
		case ReadyUpOptionsSimple.ScrapGain:
			ResourceManager.Instance.Scrap.AddValue(base.Value, ignoreModifiers: true);
			readyUpWindow.ScrapGainTxt.gameObject.SetActive(value: true);
			base.LocalizationString.Arguments = new object[1] { LocalizationDisplayValue };
			readyUpWindow.ScrapGainTxt.text = base.LocalizationString.GetLocalizedString();
			break;
		case ReadyUpOptionsSimple.AmmoGain:
			ResourceManager.Instance.Ammo.AddValue(base.Value, ignoreModifiers: true);
			readyUpWindow.AmmoGainTxt.gameObject.SetActive(value: true);
			base.LocalizationString.Arguments = new object[1] { LocalizationDisplayValue };
			readyUpWindow.AmmoGainTxt.text = base.LocalizationString.GetLocalizedString();
			break;
		case ReadyUpOptionsSimple.BossDamage:
			EnemyManager.Instance.BossDmgMult += base.Value / 10f;
			readyUpWindow.BossDamageGainTxt.gameObject.SetActive(value: true);
			base.LocalizationString.Arguments = new object[1] { LocalizationDisplayValue };
			readyUpWindow.BossDamageGainTxt.text = base.LocalizationString.GetLocalizedString();
			break;
		}
	}

	public override void CardBurned()
	{
		base.CardBurned();
		Object.Destroy(base.gameObject);
	}
}
