using Client;
using Factory;
using Factory.Pools;
using Motorways.Audio;
using Motorways.Models;
using Motorways.Themes;
using UnityEngine;

namespace Motorways.Views
{
	public class TrafficLightView : MonoBehaviour, IView, TrafficLightModel.IObserver, TileView.IObserver, IThemeComponent, ICreatedInScopeHandler, IReleasedFromScopeHandler, IReusable
	{
		public static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("TrafficLightView");

		private TrafficLightModel _trafficLightModel;

		private TileView _tileView;

		[SerializeField]
		private InteractionCircleView _interactionCircleView;

		[Dependency]
		private IAudioSystem _audioSystem;

		[Dependency]
		private GameCamera _gameCamera;

		[Dependency]
		private VisualConstantsData _visualConstants;

		[Space(10f)]
		[EnumTypedArray(typeof(TileDirection))]
		[NonReorderable]
		public SpriteRenderer[] lightRenderers = new SpriteRenderer[8];

		[EnumTypedArray(typeof(TileDirection))]
		[NonReorderable]
		public Animator[] lightAnimators = new Animator[8];

		private Color _redLightColor;

		private Color _amberLightColor;

		private Color _greenLightColor;

		private static readonly int ActiveHash = Animator.StringToHash("Active");

		private static readonly int ChangeColorHash = Animator.StringToHash("ChangeColor");

		private readonly TweenVector3 _interactionCirclePositionTween = new TweenVector3();

		private readonly TweenVector3[] _trafficLightsOffsetsTweens = new TweenVector3[8]
		{
			new TweenVector3(),
			new TweenVector3(),
			new TweenVector3(),
			new TweenVector3(),
			new TweenVector3(),
			new TweenVector3(),
			new TweenVector3(),
			new TweenVector3()
		};

		private const string ChangeColor = "ChangeColor";

		private const string Active = "Active";

		[Dependency]
		public City City { get; private set; }

		public TrafficLightModel Model => _trafficLightModel;

		public void OnCreatedInScope(IScope scope)
		{
			Animator[] array = lightAnimators;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetBool(ActiveHash, value: false);
			}
		}

		public void OnReleasedFromScope(IScope scope)
		{
			if (_trafficLightModel != null)
			{
				_trafficLightModel.Unsubscribe(this);
				_trafficLightModel = null;
			}
			if (_tileView != null)
			{
				_tileView.Unsubscribe(this);
				_tileView = null;
			}
		}

		public void Reset()
		{
			_trafficLightModel = null;
			_tileView = null;
			City = null;
			base.transform.localPosition = Vector3.zero;
			Animator[] array = lightAnimators;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetBool(ActiveHash, value: false);
			}
			_interactionCirclePositionTween.Reset();
			TweenVector3[] trafficLightsOffsetsTweens = _trafficLightsOffsetsTweens;
			for (int i = 0; i < trafficLightsOffsetsTweens.Length; i++)
			{
				trafficLightsOffsetsTweens[i].Reset();
			}
			ReconfigurePermanenceVisibility();
		}

		public void ReconfigurePermanenceVisibility()
		{
			_interactionCircleView.SetPermanenceProgress(0f);
		}

		public void SetModel(TrafficLightModel model)
		{
			_trafficLightModel = model;
			_trafficLightModel.Subscribe(this);
			UpdateLights();
			AudioSystem.Instance.ScheduleEvent(AudioEvent.CreateEvent(-1.0, AudioEventType.UpgradePlaced, _gameCamera.GetPanFromWorld(_tileView.transform.position).x));
		}

		public void InitialiseInteractionCirclePosition(TileView tileView)
		{
			_tileView = tileView;
			tileView.Subscribe(this);
			_interactionCircleView.transform.localPosition = _tileView.InteractionCircleOffset;
			_interactionCirclePositionTween.Stop();
		}

		public TickResult Tick(TimeInterval timeInterval, float stepAlpha)
		{
			if (_interactionCirclePositionTween.IsActive)
			{
				_interactionCircleView.transform.localPosition = _interactionCirclePositionTween.Tick(timeInterval.Delta);
			}
			for (TileDirection tileDirection = TileDirection.North; tileDirection <= TileDirection.NorthWest; tileDirection++)
			{
				if (_trafficLightsOffsetsTweens[(int)tileDirection].IsActive)
				{
					GetLightInDirection(tileDirection).gameObject.transform.localPosition = _trafficLightsOffsetsTweens[(int)tileDirection].Tick(timeInterval.Delta);
				}
			}
			return TickResult.ContinueTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}

		private void UpdateLights()
		{
			if (_trafficLightModel == null)
			{
				return;
			}
			TileDirectionBitfield activePair = _trafficLightModel.ActivePair;
			for (TileDirection tileDirection = TileDirection.North; tileDirection <= TileDirection.NorthWest; tileDirection++)
			{
				SpriteRenderer lightInDirection = GetLightInDirection(tileDirection);
				Animator lightAnimatorInDirection = GetLightAnimatorInDirection(tileDirection);
				if (activePair[tileDirection])
				{
					lightAnimatorInDirection.SetBool(ActiveHash, value: true);
					if (_trafficLightModel.amberLightsOn)
					{
						lightAnimatorInDirection.SetTrigger(ChangeColorHash);
					}
					lightInDirection.color = (_trafficLightModel.amberLightsOn ? _amberLightColor : _greenLightColor);
				}
				else
				{
					lightAnimatorInDirection.SetBool(ActiveHash, value: false);
					lightInDirection.color = _redLightColor;
				}
			}
		}

		public SpriteRenderer GetLightInDirection(TileDirection direction)
		{
			return GetLightAnimatorInDirection(direction).GetComponent<SpriteRenderer>();
		}

		public Animator GetLightAnimatorInDirection(TileDirection direction)
		{
			return lightAnimators[(int)direction];
		}

		public void OnTileViewChanged(TileView changedTile)
		{
			_interactionCirclePositionTween.Start(_interactionCircleView.transform.localPosition, changedTile.InteractionCircleOffset, _visualConstants.InteractionCircleOffsetAdjustmentDuration, _visualConstants.InteractionCircleAndTrafficLightAdjustmentEasingFunction);
			if (changedTile.TrafficLightOffsets.Length >= 8)
			{
				for (TileDirection tileDirection = TileDirection.North; tileDirection <= TileDirection.NorthWest; tileDirection++)
				{
					if (changedTile.TrafficLightOffsets[(int)tileDirection] != Vector2.zero)
					{
						SpriteRenderer lightInDirection = GetLightInDirection(tileDirection);
						_trafficLightsOffsetsTweens[(int)tileDirection].Start(lightInDirection.gameObject.transform.localPosition, changedTile.TrafficLightOffsets[(int)tileDirection], _visualConstants.TrafficLightsOffsetAdjustmentDuration, _visualConstants.InteractionCircleAndTrafficLightAdjustmentEasingFunction);
					}
				}
			}
			_interactionCircleView.SetPermanenceProgress(City.Rules.RoadsBecomePermanentOverTime ? _visualConstants.DryingInteractionCircleFalloff.Evaluate((float)_tileView.Tile.TrafficLightPermanenceProgress) : 0f);
		}

		public void OnLanesChanged()
		{
			UpdateLights();
		}

		public void OnTrafficLightGreen(TrafficLightModel model, TileDirectionBitfield rightOfWay)
		{
			UpdateLights();
			_audioSystem.ScheduleEvent(AudioEvent.CreateTrafficLightEvent(AudioEventType.TrafficLightGreen, this, rightOfWay));
		}

		public void OnTrafficLightAmber(TrafficLightModel model)
		{
			UpdateLights();
			_audioSystem.ScheduleEvent(AudioEvent.CreateTrafficLightEvent(AudioEventType.TrafficLightAmber, this, TileDirectionBitfield.None));
		}

		public void InitializeTheme(IThemeDatabase themeDatabase)
		{
			_interactionCircleView.InitializeTheme(themeDatabase);
		}

		public void ApplyTheme(ITheme newTheme)
		{
			Theme theme = newTheme as Theme;
			if (theme != null)
			{
				_redLightColor = theme.GetColor(ThemedMaterialType.TrafficLightRed);
				_amberLightColor = theme.GetColor(ThemedMaterialType.TrafficLightAmber);
				_greenLightColor = theme.GetColor(ThemedMaterialType.TrafficLightGreen);
			}
			UpdateLights();
			_interactionCircleView.ApplyTheme(theme);
		}

		public ThemeBlendingResult ApplyBlendedTheme(ITheme oldTheme, ITheme newTheme, float progress)
		{
			return _interactionCircleView.ApplyBlendedTheme(oldTheme, newTheme, progress);
		}

		public void ReleaseTheme(IThemeDatabase themeDatabase)
		{
			_interactionCircleView.ReleaseTheme(themeDatabase);
		}
	}
}
