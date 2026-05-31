using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AbilityButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	private Button _button;

	private Image _buttonImage;

	private TMP_Text _text;

	private Color _defaultColor;

	public GameObject Tooltip;

	public Ability.AbilityTypeEnum AbilityType;

	private Vector3 _originalScale;

	private Tween _expandTween;

	private void Awake()
	{
		_button = GetComponent<Button>();
		_buttonImage = GetComponent<Image>();
		_text = base.transform.Find("Text (TMP)").GetComponent<TMP_Text>();
		_defaultColor = _buttonImage.color;
	}

	private void Start()
	{
		_originalScale = base.transform.localScale;
		Tooltip.SetActive(value: false);
	}

	private void Update()
	{
		SetDisplay();
	}

	private void SetDisplay()
	{
		float delay = GetDelay();
		if (delay <= 0f)
		{
			_buttonImage.color = Color.white;
			_text.text = "";
			return;
		}
		_buttonImage.color = _defaultColor;
		_text.text = ((int)delay).ToString();
		if (delay >= 1000f)
		{
			_text.fontSize = 8f;
		}
		else
		{
			_text.fontSize = 11f;
		}
	}

	public void ProcessClick()
	{
		if (GameController.Instance.ExecuteAbility(AbilityType))
		{
			GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ui_ability_click);
		}
	}

	private float GetDelay()
	{
		return Ability.GetDelay(GameController.Instance.Abilities, AbilityType);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		_expandTween?.Kill();
		if (GetDelay() <= 0f)
		{
			GlobalSfx2Controller.Instance.PlayOneWithPitch(SoundManager.SoundTypeEnum.ui_ability_hover);
			_expandTween = base.transform.DOScale(_originalScale * 1.2f, 0.2f).SetEase(Ease.OutBack);
		}
		Tooltip.SetActive(value: true);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		_expandTween?.Kill();
		_expandTween = base.transform.DOScale(_originalScale, 0.2f).SetEase(Ease.InBack);
		Tooltip.SetActive(value: false);
	}
}
