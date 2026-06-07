using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AreaShopUI : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _costText_WindIsland;

	[SerializeField]
	private GameObject _windIslandFrame_OFF;

	[SerializeField]
	private GameObject _windIslandFrame_ON;

	[SerializeField]
	private Button _buyWindIslandButton;

	[SerializeField]
	private TextMeshProUGUI _costText_DeepCave;

	[SerializeField]
	private GameObject _deepCaveFrame_OFF;

	[SerializeField]
	private GameObject _deepCaveFrame_ON;

	[SerializeField]
	private Button _buyDeepCaveButton;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			OnClickCloseButton();
		}
	}

	public void Show()
	{
		MonoSingleton<SoundManager>.Instance.PlaySFX(SFXType.SFX_PaperShow);
		UpdateUI(0L);
		base.gameObject.SetActive(value: true);
	}

	public void Hide()
	{
		base.gameObject.SetActive(value: false);
	}

	public void UpdateUI(long currentGold = 0L)
	{
		bool isUnlock_WindIsland = MonoSingleton<AreaManager>.Instance.IsUnlock_WindIsland;
		bool isUnlock_DeepCave = MonoSingleton<AreaManager>.Instance.IsUnlock_DeepCave;
		_buyWindIslandButton.gameObject.SetActive(!isUnlock_WindIsland);
		_buyDeepCaveButton.gameObject.SetActive(!isUnlock_DeepCave);
		_costText_WindIsland.text = NumberFormatter.FormatWithComma(MonoSingleton<AreaManager>.Instance.Cost_WindIsland) ?? "";
		bool flag = Wallet.Instance.HasEnoughGold(MonoSingleton<AreaManager>.Instance.Cost_WindIsland);
		_costText_WindIsland.color = (flag ? Color.white : Color.red);
		_windIslandFrame_OFF.SetActive(!flag);
		_windIslandFrame_ON.SetActive(flag);
		_costText_DeepCave.text = NumberFormatter.FormatWithComma(MonoSingleton<AreaManager>.Instance.Cost_DeepCave) ?? "";
		bool flag2 = Wallet.Instance.HasEnoughGold(MonoSingleton<AreaManager>.Instance.Cost_DeepCave);
		_costText_DeepCave.color = (flag2 ? Color.white : Color.red);
		_deepCaveFrame_OFF.SetActive(!flag2);
		_deepCaveFrame_ON.SetActive(flag2);
	}

	public void OnClickBuyWindIsland()
	{
		if (MonoSingleton<AreaManager>.Instance.BuyWindIsland())
		{
			UpdateUI(0L);
			Hide();
		}
	}

	public void OnClickBuyDeepCave()
	{
		if (MonoSingleton<AreaManager>.Instance.BuyDeepCave())
		{
			UpdateUI(0L);
			Hide();
		}
	}

	public void OnClickCloseButton()
	{
		Hide();
		MonoSingleton<SoundManager>.Instance.PlaySFX(SFXType.SFX_BTNCommon_Down);
	}
}
