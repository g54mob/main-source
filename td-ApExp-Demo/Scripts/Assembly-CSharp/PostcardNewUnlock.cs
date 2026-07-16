using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PostcardNewUnlock : MonoBehaviour
{
	[Header("UI Elements")]
	[SerializeField]
	private Image _iconImg;

	[SerializeField]
	private Image _borderImg;

	[SerializeField]
	private TextMeshProUGUI _nameTxt;

	[SerializeField]
	private TextMeshProUGUI _titleTxt;

	[SerializeField]
	private GameObject _stickyNoteImg;

	[SerializeField]
	public Button StickyNoteBtn;

	[SerializeField]
	private Image _mask;

	[Header("Misc")]
	[SerializeField]
	private List<Sprite> _borders;

	[SerializeField]
	private List<Sprite> _upgradeBorders;

	[SerializeField]
	private List<Sprite> _relicBorders;

	[SerializeField]
	private Sprite _regularMask;

	[SerializeField]
	private Sprite _upgradeMask;

	[SerializeField]
	private Sprite _relicMask;

	private string _unlockName;

	private string _unlockType;

	private void Start()
	{
		StickyNoteBtn.onClick.AddListener(delegate
		{
			GetComponent<Animator>().Play("StickyNotePeelOff");
		});
	}

	public void SetupNewUnlock(Sprite icon, string enhancementType, string name, Rarity rarity, bool isRevealed = false, Enhancement enh = null)
	{
		_iconImg.sprite = icon;
		_unlockType = enhancementType;
		_unlockName = name;
		if (enh != null && enh is EnhancementUpgrade enhancementUpgrade)
		{
			if (enhancementUpgrade.IsRelic)
			{
				_borderImg.sprite = _relicBorders[(int)rarity];
				_mask.sprite = _relicMask;
			}
			else
			{
				_borderImg.sprite = _upgradeBorders[(int)rarity];
				_mask.sprite = _upgradeMask;
			}
		}
		else
		{
			_borderImg.sprite = _borders[(int)rarity];
			_mask.sprite = _regularMask;
		}
		if (isRevealed)
		{
			RevealUnlock();
		}
	}

	public void RevealUnlock()
	{
		_stickyNoteImg.SetActive(value: false);
		_nameTxt.text = _unlockName;
		_titleTxt.text = _unlockType;
		Object.Destroy(StickyNoteBtn.gameObject);
	}
}
