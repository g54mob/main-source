using System.Collections;
using CTS.BBT;
using CTS.Core;
using CTS.UI;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

namespace CTS
{
	[RequireComponent(typeof(Button))]
	[RequireComponent(typeof(Image))]
	public class UI_OpenClose : MonoBehaviour
	{
		[SerializeField]
		private Image _cadenasImage;

		[SerializeField]
		private Sprite _closedCadenasSprite;

		[SerializeField]
		private Sprite _openedCadenasSprite;

		[SerializeField]
		private LocalizedString _tooltipOpenedText;

		[SerializeField]
		private LocalizedString _tooltipClosedText;

		[SerializeField]
		private Color _closedColor;

		[SerializeField]
		private Color _openColor;

		[SerializeField]
		private AnimationCurve _blinkColor;

		[SerializeField]
		private float _speedBlink;

		private Button _openCloseButton;

		private Image _buttonimage;

		private ToolTipsShower _tooltips;

		private void Awake()
		{
			_openCloseButton = GetComponent<Button>();
			_buttonimage = GetComponent<Image>();
			_tooltips = GetComponentInParent<ToolTipsShower>();
		}

		private void OnDisable()
		{
			_openCloseButton.onClick.RemoveListener(OnOpenCloseButtonClick);
			LevelParameters.OnBarOpenedStatusChanged -= OnBarOpenedStatusChanged;
		}

		private void OnEnable()
		{
			_openCloseButton.onClick.AddListener(OnOpenCloseButtonClick);
			LevelParameters.OnBarOpenedStatusChanged += OnBarOpenedStatusChanged;
			OnBarOpenedStatusChanged(CTSSingleton<LevelParameters>.Instance.IsOpen);
		}

		private void OnBarOpenedStatusChanged(bool open)
		{
			StopAllCoroutines();
			ChangeColor(_openColor, 1f);
			_cadenasImage.sprite = (open ? _openedCadenasSprite : _closedCadenasSprite);
			_tooltips.SetTootipsInfo(open ? _tooltipClosedText : _tooltipOpenedText);
			if (!open)
			{
				StartCoroutine(ChangeAlpha());
			}
		}

		public void OnOpenCloseButtonClick()
		{
			if (CTSSingleton<LevelParameters>.Instance == null)
			{
				Debug.LogError("LevelParameters instance not available.");
			}
			else
			{
				CTSSingleton<LevelParameters>.Instance.ToggleOpenStatus();
			}
		}

		private IEnumerator ChangeAlpha()
		{
			float currentTime = 0f;
			while (true)
			{
				currentTime += Time.unscaledDeltaTime * _speedBlink;
				if (currentTime > 1f)
				{
					currentTime -= 1f;
				}
				float alpha = Mathf.Clamp01(_blinkColor.Evaluate(currentTime));
				ChangeColor(_closedColor, alpha);
				yield return null;
			}
		}

		private void ChangeColor(Color currentColor, float alpha)
		{
			_buttonimage.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
		}
	}
}
