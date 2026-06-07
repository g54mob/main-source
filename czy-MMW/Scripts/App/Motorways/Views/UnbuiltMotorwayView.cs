using Client;
using Factory;
using Factory.Pools;
using UnityEngine;

namespace Motorways.Views
{
	public class UnbuiltMotorwayView : MonoBehaviour, IView, IThemeComponent, IReusable, TileView.IObserver, IReleasedFromScopeHandler
	{
		public GameObject interactionCircle;

		[Dependency]
		private IScope _scope;

		[Dependency]
		private VisualConstantsData _visualConstants;

		private UnbuiltMotorwayHandleView _handleView;

		private readonly TweenVector3 _interactionCirclePositionTween = new TweenVector3();

		private TileView _tileView;

		[Dependency]
		public City City { get; private set; }

		public void Initialize(TileView tileView, Vector2 position, Vector2 interactionCircleOffset, int number)
		{
			_tileView = tileView;
			_tileView.Subscribe(this);
			base.transform.localPosition = position;
			_handleView = GetComponentInChildren<UnbuiltMotorwayHandleView>();
			if (Diagnostics.Verify(_handleView != null, "No UnbuiltMotorwayHandleView found on object."))
			{
				_handleView.Initialize(_scope, number);
			}
			if (Diagnostics.Verify(interactionCircle != null, "InteractionCircle not found on UnbuiltMotorwayView."))
			{
				interactionCircle.transform.localPosition = interactionCircleOffset;
			}
		}

		public void OnReleasedFromScope(IScope scope)
		{
			if (_tileView != null)
			{
				_tileView.Unsubscribe(this);
			}
		}

		public void Reset()
		{
			City = null;
			_handleView = null;
			base.transform.localPosition = Vector3.zero;
			_interactionCirclePositionTween.Reset();
		}

		public TickResult Tick(TimeInterval timeInterval, float stepAlpha)
		{
			if (_handleView != null)
			{
				_handleView.Tick(timeInterval, stepAlpha);
			}
			if (_interactionCirclePositionTween.IsActive)
			{
				interactionCircle.transform.localPosition = _interactionCirclePositionTween.Tick(timeInterval.Delta);
			}
			return TickResult.ContinueTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}

		public void OnTileViewChanged(TileView changedTileView)
		{
			_interactionCirclePositionTween.Start(interactionCircle.transform.localPosition, changedTileView.InteractionCircleOffset, _visualConstants.InteractionCircleOffsetAdjustmentDuration, _visualConstants.InteractionCircleAndTrafficLightAdjustmentEasingFunction);
		}

		public void InitializeTheme(IThemeDatabase themeDatabase)
		{
			if (_handleView != null)
			{
				_handleView.InitializeTheme(themeDatabase);
			}
		}

		public void ApplyTheme(ITheme newTheme)
		{
			if (_handleView != null)
			{
				_handleView.ApplyTheme(newTheme);
			}
		}

		public ThemeBlendingResult ApplyBlendedTheme(ITheme oldTheme, ITheme newTheme, float progress)
		{
			if (_handleView != null)
			{
				_handleView.ApplyTheme(newTheme);
			}
			return ThemeBlendingResult.StopBlending;
		}

		public void ReleaseTheme(IThemeDatabase themeDatabase)
		{
			if (_handleView != null)
			{
				_handleView.ReleaseTheme(themeDatabase);
			}
		}
	}
}
