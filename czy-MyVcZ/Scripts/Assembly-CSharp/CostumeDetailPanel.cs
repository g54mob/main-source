using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CostumeDetailPanel : MonoBehaviour
{
	[SerializeField]
	private Image _costumeIcon;

	[SerializeField]
	private TextMeshProUGUI _nameText;

	[SerializeField]
	private TextMeshProUGUI _descText;

	[SerializeField]
	private TextMeshProUGUI _buyCostText;

	[SerializeField]
	private Button _buyButton;

	[SerializeField]
	private Button _equipButton;

	[SerializeField]
	private GameObject _buyButtonDimd;

	[SerializeField]
	private GameObject _lockDimd;

	[SerializeField]
	private GameObject _conditionTextGO;

	[SerializeField]
	private CostumeBuyNoticeView _costumeBuyNoticeView;

	private CostumeID _costumeID;

	public void Init(CostumeID costumeID)
	{
		_costumeID = costumeID;
		MonoSingleton<CostumeManager>.Instance.OnBuyCostume += Handle_OnBuyCostume;
		MonoSingleton<CostumeManager>.Instance.OnEquipCostume += Handle_OnEquipCostume;
		Wallet.Instance.OnGoldChanged += Handle_OnGoldChanged;
		_costumeBuyNoticeView.Hide();
		UpdateUI();
	}

	public void Release()
	{
		MonoSingleton<CostumeManager>.Instance.OnBuyCostume -= Handle_OnBuyCostume;
		MonoSingleton<CostumeManager>.Instance.OnEquipCostume -= Handle_OnEquipCostume;
		Wallet.Instance.OnGoldChanged -= Handle_OnGoldChanged;
	}

	public void UpdateUI()
	{
		CostumeData costumeData = DataManager.Instance.GetCostumeData(_costumeID);
		_costumeIcon.sprite = Resources.Load<Sprite>(costumeData.IconPath);
		_nameText.text = LocaleHelper.Get(costumeData.NameLocalKey);
		_descText.text = LocaleHelper.Get(costumeData.DescLocalKey);
		_buyCostText.text = NumberFormatter.FormatWithComma(costumeData.BuyCost) ?? "";
		bool flag = MonoSingleton<CostumeManager>.Instance.CanBuyCostumeCondition(_costumeID);
		_conditionTextGO.SetActive(!flag);
		_lockDimd.SetActive(!flag);
		bool flag2 = Wallet.Instance.HasEnoughGold(costumeData.BuyCost);
		_buyButtonDimd.SetActive(!flag2);
		_buyCostText.color = (flag2 ? Color.white : Color.red);
		_buyButtonDimd.SetActive(!flag);
		bool flag3 = MonoSingleton<CostumeManager>.Instance.IsBuyCostume(_costumeID);
		_buyButton.gameObject.SetActive(!flag3);
		bool flag4 = MonoSingleton<CostumeManager>.Instance.IsEquippedCostume(_costumeID);
		_equipButton.gameObject.SetActive(flag3 && !flag4);
	}

	private void Handle_OnBuyCostume(CostumeID costumeID)
	{
		UpdateUI();
		_costumeBuyNoticeView.Hide();
		_costumeBuyNoticeView.Show(_costumeID);
	}

	private void Handle_OnEquipCostume(CostumeID costumeID)
	{
		UpdateUI();
	}

	private void Handle_OnGoldChanged(long gold)
	{
		UpdateUI();
	}

	public void OnClick_BuyButton()
	{
		MonoSingleton<CostumeManager>.Instance.BuyCostume(_costumeID);
	}

	public void OnClick_EquipButton()
	{
		MonoSingleton<CostumeManager>.Instance.EquipCostume(_costumeID);
	}
}
