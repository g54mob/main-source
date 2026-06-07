using LitMotion;
using LitMotion.Extensions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UpgradeNodeGameFeel : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[Header("Hover Settings")]
	[SerializeField]
	private float hoverScale = 1.1f;

	[SerializeField]
	private float hoverDuration = 0.15f;

	[SerializeField]
	private Ease hoverEase = Ease.OutCubic;

	[Header("Click Settings")]
	[SerializeField]
	private float clickScalePunch = 0.15f;

	[SerializeField]
	private float clickDuration = 0.12f;

	[SerializeField]
	private Ease clickEase = Ease.OutQuad;

	[Header("Unlock Settings")]
	[SerializeField]
	private float unlockScalePunch = 0.2f;

	[SerializeField]
	private float unlockScaleDuration = 0.25f;

	[Header("Denied Settings")]
	[SerializeField]
	private float deniedRotationAngle = 7f;

	[SerializeField]
	private float deniedWiggleDuration = 0.08f;

	[SerializeField]
	private Ease deniedEase = Ease.InOutSine;

	[Header("Appear Settings")]
	[SerializeField]
	private float appearScaleStart = 0.3f;

	[SerializeField]
	private float appearScalePunch = 1.15f;

	[SerializeField]
	private float appearDuration = 0.3f;

	[SerializeField]
	private Ease appearEase = Ease.OutBack;

	private Button _button;

	private RectTransform _rectTransform;

	private Vector3 _originalScale = Vector3.one;

	private float _originalRotation;

	private bool _isUnlocked;

	private bool _isHovering;

	private MotionHandle _currentMotion;

	private void Awake()
	{
		_button = GetComponent<Button>();
		_rectTransform = GetComponent<RectTransform>();
		_originalScale = _rectTransform.localScale;
		_originalRotation = _rectTransform.localEulerAngles.z;
		_button.onClick.AddListener(OnButtonClick);
	}

	private void OnDestroy()
	{
		if (_currentMotion.IsActive())
		{
			_currentMotion.Cancel();
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (_button.interactable && !_isUnlocked)
		{
			_isHovering = true;
			AnimateHover(enter: true);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (_button.interactable && !_isUnlocked)
		{
			_isHovering = false;
			AnimateHover(enter: false);
		}
	}

	private void AnimateHover(bool enter)
	{
		if (_currentMotion.IsActive())
		{
			_currentMotion.Cancel();
		}
		Vector3 to = (enter ? (_originalScale * hoverScale) : _originalScale);
		_currentMotion = LMotion.Create(_rectTransform.localScale, to, hoverDuration).WithEase(hoverEase).BindToLocalScale(_rectTransform);
	}

	private void OnButtonClick()
	{
		if (!_isUnlocked)
		{
			AnimateClick();
		}
	}

	private void AnimateClick()
	{
		if (_currentMotion.IsActive())
		{
			_currentMotion.Cancel();
		}
		Vector3 vector = (_isHovering ? (_originalScale * hoverScale) : _originalScale);
		Vector3 vector2 = vector * (1f - clickScalePunch);
		_currentMotion = LMotion.Create(vector2, vector, clickDuration).WithEase(clickEase).BindToLocalScale(_rectTransform);
	}

	public void PlayUnlockAnimation()
	{
		if (!_isUnlocked)
		{
			_isUnlocked = true;
			if (_currentMotion.IsActive())
			{
				_currentMotion.Cancel();
			}
			Vector3 punchScale = _originalScale * (1f + unlockScalePunch);
			_currentMotion = LMotion.Create(_originalScale, punchScale, unlockScaleDuration * 0.5f).WithEase(Ease.OutQuad).WithOnComplete(delegate
			{
				LMotion.Create(punchScale, _originalScale, unlockScaleDuration * 0.5f).WithEase(Ease.InQuad).BindToLocalScale(_rectTransform);
			})
				.BindToLocalScale(_rectTransform);
		}
	}

	public void PlayDeniedAnimation()
	{
		if (_currentMotion.IsActive())
		{
			_currentMotion.Cancel();
		}
		Vector3 originalRotation = new Vector3(0f, 0f, _originalRotation);
		Vector3 leftRotation = new Vector3(0f, 0f, _originalRotation - deniedRotationAngle);
		Vector3 rightRotation = new Vector3(0f, 0f, _originalRotation + deniedRotationAngle);
		float wiggleDuration = deniedWiggleDuration;
		LMotion.Create(originalRotation, leftRotation, wiggleDuration).WithEase(deniedEase).WithOnComplete(delegate
		{
			LMotion.Create(leftRotation, rightRotation, wiggleDuration * 2f).WithEase(deniedEase).WithOnComplete(delegate
			{
				LMotion.Create(rightRotation, leftRotation, wiggleDuration * 2f).WithEase(deniedEase).WithOnComplete(delegate
				{
					LMotion.Create(leftRotation, originalRotation, wiggleDuration).WithEase(deniedEase).Bind(delegate(Vector3 rot)
					{
						_rectTransform.localEulerAngles = rot;
					});
				})
					.Bind(delegate(Vector3 rot)
					{
						_rectTransform.localEulerAngles = rot;
					});
			})
				.Bind(delegate(Vector3 rot)
				{
					_rectTransform.localEulerAngles = rot;
				});
		})
			.Bind(delegate(Vector3 rot)
			{
				_rectTransform.localEulerAngles = rot;
			});
	}

	public void PlayAppearAnimation()
	{
		if (!(_rectTransform == null))
		{
			if (_currentMotion.IsActive())
			{
				_currentMotion.Cancel();
			}
			_rectTransform.localScale = _originalScale * appearScaleStart;
			Vector3 punchScale = _originalScale * appearScalePunch;
			_currentMotion = LMotion.Create(_rectTransform.localScale, punchScale, appearDuration * 0.6f).WithEase(appearEase).WithOnComplete(delegate
			{
				LMotion.Create(punchScale, _originalScale, appearDuration * 0.4f).WithEase(Ease.OutQuad).BindToLocalScale(_rectTransform);
			})
				.BindToLocalScale(_rectTransform);
		}
	}

	public void ResetState()
	{
		_isUnlocked = false;
		_isHovering = false;
		if (_currentMotion.IsActive())
		{
			_currentMotion.Cancel();
		}
		_rectTransform.localScale = _originalScale;
		_rectTransform.localEulerAngles = new Vector3(0f, 0f, _originalRotation);
	}
}
