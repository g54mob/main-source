using TMPro;
using UnityEngine;

public class WalletViewIncomeFX : ObjectPoolObj
{
	[SerializeField]
	private TextMeshProUGUI _incomeText;

	[SerializeField]
	private RectTransform _rectTransform;

	public void SetIncomeText(long income)
	{
		_incomeText.text = $"+{income}";
	}

	public RectTransform GetRectTransform()
	{
		return _rectTransform;
	}

	public override void BackTrans()
	{
		base.BackTrans();
		_rectTransform.anchoredPosition = Vector2.zero;
	}
}
