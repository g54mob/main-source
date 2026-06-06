using LitMotion;
using LitMotion.Adapters;
using LitMotion.Extensions;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using ZLinq;
using ZLinq.Traversables;

public class StartMenu : MonoBehaviour
{
	[SerializeField]
	private RectTransform menuPanel;

	[SerializeField]
	private RectTransform startMenuButton;

	[SerializeField]
	private CanvasGroup canvasGroup;

	[SerializeField]
	private Vector3 scaleClosed = Vector3.zero;

	[SerializeField]
	private Vector3 scaleOpened = Vector3.one;

	[SerializeField]
	private float animationDuration = 0.2f;

	[SerializeField]
	private Ease animationEase = Ease.OutQuad;

	private bool _isOpen;

	private MotionHandle _handle;

	private void Awake()
	{
		menuPanel.localScale = scaleClosed;
		canvasGroup.alpha = 0f;
		using ValueEnumerator<OfComponentT<Descendants<TransformTraverser, Transform>, Button>, Button> valueEnumerator = base.transform.Descendants().OfComponent<Button>().GetEnumerator<OfComponentT<Descendants<TransformTraverser, Transform>, Button>, Button>();
		while (valueEnumerator.MoveNext())
		{
			valueEnumerator.Current.onClick.AddListener(Toggle);
		}
	}

	private void Update()
	{
		if (Mouse.current.leftButton.wasPressedThisFrame)
		{
			HandleGlobalClick();
		}
	}

	private void OnDestroy()
	{
		if (_handle.IsActive())
		{
			_handle.Cancel();
		}
	}

	public void Toggle()
	{
		Animate(!_isOpen);
	}

	public void Hide()
	{
		_isOpen = false;
		base.gameObject.SetActive(value: false);
	}

	private void HandleGlobalClick()
	{
		Vector2 screenPoint = Mouse.current.position.ReadValue();
		bool num = RectTransformUtility.RectangleContainsScreenPoint(menuPanel, screenPoint, UI.Registry.cameras.main);
		bool flag = RectTransformUtility.RectangleContainsScreenPoint(startMenuButton, screenPoint, UI.Registry.cameras.main);
		if (!num && !flag)
		{
			Animate(value: false);
		}
	}

	private void Animate(bool value)
	{
		if (_isOpen != value)
		{
			if (!_isOpen)
			{
				base.gameObject.SetActive(value: true);
			}
			_isOpen = value;
			if (_handle.IsActive())
			{
				_handle.Cancel();
			}
			canvasGroup.interactable = _isOpen;
			canvasGroup.blocksRaycasts = _isOpen;
			MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder = (_isOpen ? LMotion.Create(0f, 1f, animationDuration) : LMotion.Create(canvasGroup.alpha, 0f, animationDuration).WithOnComplete(delegate
			{
				base.gameObject.SetActive(value: false);
			}));
			MotionBuilder<Vector3, NoOptions, Vector3MotionAdapter> motionBuilder2 = (_isOpen ? LMotion.Create(scaleClosed, scaleOpened, animationDuration) : LMotion.Create(menuPanel.localScale, scaleClosed, animationDuration));
			_handle = LSequence.Create().Join(motionBuilder.WithEase(animationEase).BindToAlpha(canvasGroup)).Join(motionBuilder2.WithEase(animationEase).BindToLocalScale(menuPanel))
				.Run();
		}
	}
}
