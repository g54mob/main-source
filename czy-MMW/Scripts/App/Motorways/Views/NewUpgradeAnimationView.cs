using Client;
using Easing;
using Factory;
using Factory.Pools;
using Motorways.Themes;
using NaughtyAttributes;
using UnityEngine;

namespace Motorways.Views
{
	[RequireComponent(typeof(RectTransform))]
	public class NewUpgradeAnimationView : MonoBehaviour, IView, IReusable
	{
		private RectTransform _rect;

		private CanvasGroup _canvasGroup;

		private UpgradeIcon _upgradeIcon;

		private Vector2 _startScale;

		private Vector3 _startPosition;

		private RectTransform _endTransform;

		private float _lerp;

		private UpgradeType _upgradeType;

		[Dependency]
		private UpgradeBarClient _upgradeBar;

		private int _count = 1;

		private bool _isStartingPositionSet;

		[MinValue(float.Epsilon)]
		public float animationDuration = 0.6f;

		[Tooltip("The time between multiple instances of the animation when the player earns more than one upgrade at once.")]
		[MinValue(float.Epsilon)]
		public float animationSpacing = 0.2f;

		[SerializeField]
		private Easings.Functions _positionEasing;

		[SerializeField]
		private Easings.Functions _scaleEasing = Easings.Functions.SineEaseIn;

		private bool _hiding;

		private const int HideSpeed = 2;

		public UpgradeIcon UpgradeIcon => _upgradeIcon;

		public void OnEnable()
		{
			_rect = GetComponent<RectTransform>();
			_upgradeIcon = GetComponent<UpgradeIcon>();
			_canvasGroup = GetComponent<CanvasGroup>();
		}

		public void Reset()
		{
			base.transform.localPosition = Vector3.zero;
			base.transform.localScale = Vector3.one;
			_startScale = default(Vector2);
			_startPosition = default(Vector3);
			_lerp = 0f;
			_count = 1;
			_upgradeType = UpgradeType.Concrete;
			_isStartingPositionSet = false;
			_hiding = false;
		}

		public TickResult Tick(TimeInterval timeInterval, float stepAlpha)
		{
			if (!_isStartingPositionSet)
			{
				_startPosition = _rect.position;
				_isStartingPositionSet = true;
			}
			if (_lerp > 1f)
			{
				_lerp = 0f;
				_upgradeBar.AddToUpgradeButtonStack(_upgradeType, fromAnimation: true, _count);
				return TickResult.Destroy;
			}
			if (_lerp >= 0f)
			{
				_rect.position = Vector3.Lerp(_startPosition, _endTransform.position, Easings.Interpolate(_lerp, _positionEasing));
				_rect.sizeDelta = Vector2.Lerp(_startScale, _endTransform.sizeDelta, Easings.Interpolate(_lerp, _scaleEasing));
			}
			else if (_lerp < 0f)
			{
				_rect.position = _startPosition;
				_rect.sizeDelta = _startScale;
			}
			_lerp += timeInterval.Delta * (1f / animationDuration);
			return TickResult.ContinueTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}

		private void Update()
		{
			if (_hiding && _canvasGroup.alpha > 0f)
			{
				_canvasGroup.alpha -= Time.deltaTime * 2f;
			}
		}

		public void Hide()
		{
			_hiding = true;
		}

		public void Initialize(Vector2 startScale, RectTransform destination, Sprite sprite, UpgradeType upgradeType, Theme theme, float delay = 0f, int count = 1)
		{
			_canvasGroup.alpha = 1f;
			_upgradeType = upgradeType;
			_startScale = startScale;
			_rect.sizeDelta = _startScale;
			_upgradeIcon.iconRenderer.sprite = sprite;
			_endTransform = destination;
			_lerp = 0f - delay;
			_upgradeIcon.ApplyTheme(theme);
			base.transform.SetAsLastSibling();
			_count = count;
			_hiding = false;
		}
	}
}
