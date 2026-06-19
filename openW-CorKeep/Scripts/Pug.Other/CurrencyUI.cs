using System.Collections.Generic;
using I2.Loc;

public class CurrencyUI : UIelement
{
	public LocalizedString currencyTerm;

	public PugText currencyText;

	public override List<TextAndFormatFields> GetHoverStats(bool previewReinforced)
	{
		List<TextAndFormatFields> list = new List<TextAndFormatFields>();
		list.Add(new TextAndFormatFields
		{
			text = currencyTerm.mTerm,
			formatFields = new string[1] { Manager.saves.GetCoinAmount().ToString() }
		});
		return list;
	}

	protected override void LateUpdate()
	{
		base.LateUpdate();
		string text = Manager.saves.GetCoinAmount().ToString();
		if (text != currencyText.displayedTextString)
		{
			currencyText.Render(text);
		}
	}
}
