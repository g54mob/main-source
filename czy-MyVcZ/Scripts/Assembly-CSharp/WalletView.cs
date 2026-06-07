using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _currentGoldText;

	[SerializeField]
	private ObjectPool _goldFXPool;

	private float horizontalOffset = 10f;

	public void UpdateGoldText(long currentGold)
	{
		_currentGoldText.text = NumberFormatter.FormatWithComma(currentGold);
	}

	public void PlayIncomeFX(long income)
	{
		float x = Random.Range(0f - horizontalOffset, horizontalOffset);
		WalletViewIncomeFX component = _goldFXPool.GetObj().GetComponent<WalletViewIncomeFX>();
		component.SetIncomeText(income);
		component.GetRectTransform().anchoredPosition = new Vector2(x, 0f);
	}
}
