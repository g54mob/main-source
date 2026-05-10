using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HotbarUI : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI bankName;

	[SerializeField]
	private Image lockImage;

	[SerializeField]
	private Sprite lockedSprite;

	[SerializeField]
	private Sprite unlockedSprite;

	private void Start()
	{
		LTFunctionLibrary.GetLTPlayerController().onHotbarBankChanged += OnHotbarBankChanged;
	}

	private void OnEnable()
	{
		UpdateInfo();
	}

	private void UpdateInfo()
	{
		bankName.text = (LTFunctionLibrary.GetLTPlayerController().GetHotbarCurrentBank() + 1).ToString();
		lockImage.sprite = (LTFunctionLibrary.GetLTPlayerController().LTHUD.IsHotbarDragLocked ? lockedSprite : unlockedSprite);
	}

	private void OnHotbarBankChanged(int obj)
	{
		UpdateInfo();
	}

	public void OnPreviousBankPressed()
	{
		LTFunctionLibrary.GetLTPlayerController().SetPreviousHotbarBank();
	}

	public void OnNextBankPressed()
	{
		LTFunctionLibrary.GetLTPlayerController().SetNextHotbarBank();
	}

	public void OnLockPressed()
	{
		LTFunctionLibrary.GetLTPlayerController().LTHUD.IsHotbarDragLocked = !LTFunctionLibrary.GetLTPlayerController().LTHUD.IsHotbarDragLocked;
		UpdateInfo();
	}
}
