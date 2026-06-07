using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class CollectionDetailPanel : MonoBehaviour, ILocalable
{
	[SerializeField]
	private TextMeshProUGUI _nameText;

	[SerializeField]
	private TextMeshProUGUI _incomeText;

	[SerializeField]
	private TextMeshProUGUI _descText;

	[SerializeField]
	private Image _animalIcon;

	[SerializeField]
	private Image _animalIconShadow;

	[SerializeField]
	private Button _adoptButton;

	[SerializeField]
	private TextMeshProUGUI _adoptCostText;

	[SerializeField]
	private GameObject _adoptButtonFrame_ON;

	[SerializeField]
	private GameObject _adoptButtonFrame_OFF;

	[SerializeField]
	private Button _editButton;

	[SerializeField]
	private TextMeshProUGUI _editCostText;

	[SerializeField]
	private GameObject _editButtonFrame_ON;

	[SerializeField]
	private GameObject _editButtonFrame_OFF;

	[SerializeField]
	private GameObject _adoptGO;

	private Animal _animal;

	private bool _isTweening;

	private void OnEnable()
	{
		LocaleHelper.SubscribeLocaleChanged(OnLocaleChanged);
	}

	private void OnDisable()
	{
		LocaleHelper.UnsubscribeLocaleChanged(OnLocaleChanged);
	}

	public void Show(Animal animal)
	{
		_animal = animal;
		_animal.OnNameChanged += UpdateNameText;
		if (_animal.IsCollected)
		{
			if (_animal.Name == string.Empty)
			{
				_nameText.text = LocaleHelper.Get(_animal.AnimalData.NameLocalKey);
			}
			else
			{
				UpdateNameText(_animal.Name);
			}
		}
		else
		{
			UpdateNameText("???");
		}
		_incomeText.text = string.Format("+{0}/{1}{2}", NumberFormatter.FormatWithComma(_animal.GetIncome()), animal.GetIncomeInterval(), LocaleHelper.Get("INCOME_SEC"));
		_descText.text = LocaleHelper.Get(_animal.AnimalData.DescLocalKey);
		_animalIcon.sprite = Resources.Load<Sprite>(_animal.AnimalData.IconPath);
		_animalIconShadow.sprite = Resources.Load<Sprite>(_animal.AnimalData.IconShadowPath);
		_adoptCostText.text = NumberFormatter.FormatWithComma(_animal.AnimalData.AdoptCost) ?? "";
		_editCostText.text = NumberFormatter.FormatWithComma(_animal.AnimalData.EditCost) ?? "";
		UpdateDetailPanel(Wallet.Instance.CurrentGold);
		base.gameObject.SetActive(value: true);
	}

	public void Hide()
	{
		_animal.OnNameChanged -= UpdateNameText;
		_animal = null;
		base.gameObject.SetActive(value: false);
	}

	private void UpdateNameText(string name)
	{
		_nameText.text = name;
	}

	public void SetUnlock()
	{
		_animalIcon.gameObject.SetActive(value: true);
		_animalIconShadow.gameObject.SetActive(value: false);
		_adoptButton.gameObject.SetActive(value: false);
		_editButton.gameObject.SetActive(value: true);
	}

	public void SetLock()
	{
		_animalIcon.gameObject.SetActive(value: false);
		_animalIconShadow.gameObject.SetActive(value: true);
		_adoptButton.gameObject.SetActive(value: true);
		_editButton.gameObject.SetActive(value: false);
	}

	public void UpdateDetailPanel(long currentGold)
	{
		UpdateState();
	}

	public void UpdateDetailPanel(Animal animal)
	{
		UpdateState();
	}

	public void UpdateState()
	{
		if (_animal == null)
		{
			return;
		}
		if (_animal.IsCollected)
		{
			SetUnlock();
		}
		else
		{
			SetLock();
		}
		bool flag = Wallet.Instance.HasEnoughGold(_animal.AnimalData.EditCost);
		_editCostText.color = (flag ? Color.white : Color.red);
		_editButtonFrame_OFF.SetActive(!flag);
		_editButtonFrame_ON.SetActive(flag);
		bool flag2 = Wallet.Instance.HasEnoughGold(_animal.AnimalData.AdoptCost);
		_adoptCostText.color = (flag2 ? Color.white : Color.red);
		_adoptButtonFrame_OFF.SetActive(!flag2);
		_adoptButtonFrame_ON.SetActive(flag2);
		if (flag2)
		{
			if (!_isTweening)
			{
				_isTweening = true;
				_adoptGO.transform.localScale = Vector3.one;
				_adoptGO.transform.DOScale(1.1f, 0.5f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo)
					.SetLink(_adoptGO, LinkBehaviour.KillOnDisable);
			}
		}
		else
		{
			if (_isTweening)
			{
				_adoptGO.transform.DOKill();
				_isTweening = false;
			}
			_adoptGO.transform.localScale = Vector3.one;
		}
	}

	public void OnClickAdoptButton()
	{
		if (_animal != null)
		{
			AnimalManager.Instance.AdoptAnimal(_animal);
		}
	}

	public void OnClickEditButton()
	{
		if (_animal != null)
		{
			AnimalManager.Instance.EditAnimal(_animal);
		}
	}

	public void OnLocaleChanged(Locale locale)
	{
		if (_animal != null)
		{
			_nameText.text = LocaleHelper.Get(_animal.AnimalData.NameLocalKey);
			_descText.text = LocaleHelper.Get(_animal.AnimalData.DescLocalKey);
		}
	}
}
