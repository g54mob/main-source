using Client;
using Easing;
using Factory;
using Factory.Pools;
using Motorways.Audio;
using Motorways.Themes;
using UnityEngine;

namespace Motorways.Views
{
	public class PinView : MonoBehaviour, IView, IReusable
	{
		private enum AnimationState
		{
			None = 0,
			AppearingOnVehicle = 1,
			DisappearingFromVehicle = 2
		}

		[Dependency]
		private IAudioSystem _audioSystem;

		[Dependency]
		private MotorwaysThemeDatabase _themeDatabase;

		[SerializeField]
		private SpriteRenderer _pinCenter;

		private const float SizeOnVehicle = 0.4f;

		private const float ScaleInDuration = 0.6f;

		private const float ScaleOutDuration = 0.4f;

		private const float DisappearFromVehicleDelay = 0.2f;

		private AnimationState _animationState;

		private TweenFloat _transitionTween = new TweenFloat();

		private VehicleView _pickup;

		public void Reset()
		{
			_transitionTween.Stop();
			_animationState = AnimationState.None;
			_pickup = null;
			base.transform.localPosition = Vector3.zero;
			base.transform.localScale = Vector3.one;
		}

		public void AppearAtVehicle(VehicleView vehicle, DestinationView fromDestination)
		{
			_animationState = AnimationState.AppearingOnVehicle;
			_transitionTween.Start(0f, 0.4f, 0.4f, Easings.Functions.ElasticEaseOut);
			_pickup = vehicle;
			base.transform.localPosition = _pickup.transform.position;
			base.transform.localScale = Vector3.zero;
			_audioSystem.ScheduleEvent(AudioEvent.CreateVehicleEvent(AudioEventType.VehicleReceivesPin, vehicle, null, fromDestination));
			Theme theme = _themeDatabase.GetTheme() as Theme;
			_pinCenter.color = theme.GetBuildingColor(vehicle.groupIndex, ThemeComponentGroupTarget.BuildingTop);
		}

		public TickResult Tick(TimeInterval timeInterval, float stepAlpha)
		{
			if (_transitionTween.IsActive)
			{
				float num = _transitionTween.Tick(timeInterval.Delta);
				base.transform.localScale = new Vector3(num, num, 1f);
				if (!_transitionTween.IsActive)
				{
					switch (_animationState)
					{
					case AnimationState.AppearingOnVehicle:
						_animationState = AnimationState.DisappearingFromVehicle;
						_transitionTween.Start(base.transform.localScale.x, 0f, 0.4f, Easings.Functions.BackEaseIn, 0.2f);
						break;
					case AnimationState.DisappearingFromVehicle:
						return TickResult.Destroy;
					}
				}
			}
			if (_animationState == AnimationState.AppearingOnVehicle || _animationState == AnimationState.DisappearingFromVehicle)
			{
				base.transform.localPosition = _pickup.transform.position;
			}
			return TickResult.ContinueTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}
	}
}
