using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public TMP_Text ButtonText;

	public Image BarLeft;

	public Image BarRight;

	public Sprite NormalImage;

	public Sprite HoverImage;

	public bool PlayOnHover = true;

	private RectTransform _textRect;

	private RectTransform _leftRect;

	private RectTransform _rightRect;

	private float _leftOriginalWidth;

	private float _rightOriginalWidth;

	private Tween _leftTween;

	private Tween _rightTween;

	private Tween _textTween;

	private void Start()
	{
		_textRect = ButtonText.GetComponent<RectTransform>();
		_leftRect = BarLeft.GetComponent<RectTransform>();
		_rightRect = BarRight.GetComponent<RectTransform>();
		_leftOriginalWidth = _leftRect.sizeDelta.x;
		_rightOriginalWidth = _rightRect.sizeDelta.x;
		_leftRect.sizeDelta = new Vector2(0f, _leftRect.sizeDelta.y);
		_rightRect.sizeDelta = new Vector2(0f, _rightRect.sizeDelta.y);
	}

	private void Update()
	{
	}

	private void OnDisable()
	{
		StopBarAnimation();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		GlobalSfx2Controller.Instance.PlayOneWithPitch(SoundManager.SoundTypeEnum.ui_button2_hover);
		StartBarAnimation();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		StopBarAnimation();
	}

	private void StartBarAnimation()
	{
		if (_leftTween != null)
		{
			_leftTween.Kill();
		}
		if (_rightTween != null)
		{
			_rightTween.Kill();
		}
		if (_textTween != null)
		{
			_textTween.Kill();
		}
		_leftTween = null;
		_rightTween = null;
		_textTween = null;
		_textTween = _textRect.DOScale(new Vector3(1.1f, 1.1f, 1f), 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
		_leftRect.sizeDelta = new Vector2(0f, _leftRect.sizeDelta.y);
		_rightRect.sizeDelta = new Vector2(0f, _rightRect.sizeDelta.y);
		BarLeft.gameObject.SetActive(value: true);
		BarRight.gameObject.SetActive(value: true);
		_leftTween = _leftRect.DOSizeDelta(new Vector2(_leftOriginalWidth, _leftRect.sizeDelta.y), 0.2f);
		_rightTween = _rightRect.DOSizeDelta(new Vector2(_rightOriginalWidth, _rightRect.sizeDelta.y), 0.2f);
		GetComponent<Image>().sprite = HoverImage;
	}

	private void StopBarAnimation()
	{
		if (!(_textRect == null))
		{
			if (_leftTween != null)
			{
				_leftTween.Kill();
			}
			if (_rightTween != null)
			{
				_rightTween.Kill();
			}
			if (_textTween != null)
			{
				_textTween.Kill();
			}
			_leftTween = null;
			_rightTween = null;
			_textTween = null;
			_textRect.localScale = new Vector3(1f, 1f, 1f);
			_leftTween = _leftRect.DOSizeDelta(new Vector2(0f, _leftRect.sizeDelta.y), 0.1f);
			_rightTween = _rightRect.DOSizeDelta(new Vector2(0f, _rightRect.sizeDelta.y), 0.1f);
			GetComponent<Image>().sprite = NormalImage;
		}
	}
}
