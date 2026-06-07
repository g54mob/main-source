using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	[SerializeField]
	private WalletView _walletView;

	[SerializeField]
	private CollectionView _collectionView;

	[SerializeField]
	private UnlockView _unlockView;

	[SerializeField]
	private AdoptView _adoptView;

	[SerializeField]
	private FocusView _focusView;

	[SerializeField]
	private SettingView _settingView;

	[SerializeField]
	private Button _collectionButton;

	[SerializeField]
	private Button _settingButton;

	[SerializeField]
	private Button _areaShopButton;

	[SerializeField]
	private GameObject _allUIBlock;

	[SerializeField]
	private Animator _bottomViewAnimator;

	[SerializeField]
	private AreaShopUI _areaShopUI;

	[SerializeField]
	private CampShopUI _campShopUI;

	[SerializeField]
	private Button _campShopButton;

	[SerializeField]
	private Button _costumeButton;

	[SerializeField]
	private CostumeUI _costumeUI;

	public WalletView WalletView => _walletView;

	public CollectionView CollectionView => _collectionView;

	public FocusView FocusView => _focusView;

	public AreaShopUI AreaShopUI => _areaShopUI;

	public CampShopUI CampShopUI => _campShopUI;

	public CostumeUI CostumeUI => _costumeUI;

	public void Init()
	{
		SetFocusableAnimal(null);
	}

	public void ShowAdoptView(Animal animal)
	{
		_adoptView.Show(animal);
	}

	public void ShowUnlockView(Animal animal)
	{
		_unlockView.Show(animal, ShowAdoptView);
	}

	public void ShowAllUIBlock()
	{
		_allUIBlock.SetActive(value: true);
	}

	public void HideAllUIBlock()
	{
		_allUIBlock.SetActive(value: false);
	}

	public void OnClickCollectionButton()
	{
		_collectionView.Show();
	}

	public void OnClickSettingButton()
	{
		MonoSingleton<SoundManager>.Instance.PlaySFX(SFXType.SFX_BTNCommon_Up);
		_settingView.Show();
	}

	public void OnClickFocusStartButton()
	{
		MonoSingleton<SoundManager>.Instance.PlaySFX(SFXType.SFX_BTNCommon_Up);
		if (!_focusView.HasFocusableAnimal())
		{
			MonoSingleton<ToastManager>.Instance.ShowToast(LocaleHelper.Get("TOAST_NOANIMAL_NEARBY"));
		}
		else
		{
			_focusView.Show();
		}
	}

	public void OnClickFocusExitButton()
	{
		MonoSingleton<SoundManager>.Instance.PlaySFX(SFXType.SFX_BTNCommon_Down);
		_focusView.Hide();
	}

	public void SetFocusableAnimal(AnimalPrefab animalPrefab)
	{
		_focusView.SetFocusableAnimal(animalPrefab);
		SetFocusStartButtonAlpha(_focusView.HasFocusableAnimal());
	}

	public void HideBottomButtons(AnimalPrefab animalPrefab)
	{
		_collectionButton.gameObject.SetActive(value: false);
		_settingButton.gameObject.SetActive(value: false);
	}

	public void ShowBottomButtons()
	{
		_collectionButton.gameObject.SetActive(value: true);
		_settingButton.gameObject.SetActive(value: true);
	}

	public void SetFocusStartButtonAlpha(bool hasFocusableAnimal)
	{
	}

	public void HideBottomButtons()
	{
		_collectionButton.gameObject.SetActive(value: false);
	}

	public void UnlockCollectionButton()
	{
		_collectionButton.gameObject.SetActive(value: true);
		_bottomViewAnimator.SetTrigger("CollectionInit");
	}

	public void UnlockFocusButton()
	{
	}

	public void SetFalseUIInteractable()
	{
		_collectionButton.interactable = false;
		_settingButton.interactable = false;
		_areaShopButton.interactable = false;
		_campShopButton.interactable = false;
		_costumeButton.interactable = false;
	}

	public void SetTrueUIInteractable()
	{
		_collectionButton.interactable = true;
		_settingButton.interactable = true;
		_areaShopButton.interactable = true;
		_campShopButton.interactable = true;
		_costumeButton.interactable = true;
	}

	public void OnClickAreaShopButton()
	{
		_areaShopUI.Show();
	}

	public void ShowAreaShopUI()
	{
		_areaShopUI.Show();
	}

	public void HideAreaShopUI()
	{
		_areaShopUI.Hide();
	}

	public void OnClickCampShopButton()
	{
		_campShopUI.Show();
	}

	public void OnClickCostumeButton()
	{
		_costumeUI.Show();
	}
}
