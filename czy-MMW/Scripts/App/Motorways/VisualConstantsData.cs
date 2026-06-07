using System;
using System.Collections.Generic;
using Easing;
using JetBrains.Annotations;
using Motorways.Themes;
using Motorways.Utility;
using NaughtyAttributes;
using Screens;
using UnityEngine;
using UnityEngine.Serialization;

namespace Motorways
{
	[CreateAssetMenu(menuName = "Motorways/VisualConstants")]
	public class VisualConstantsData : ScriptableObject
	{
		[SerializeField]
		[Tooltip("The icons players can pick to associate with profiles.")]
		private Sprite[] _profileIconOptions;

		public const int MaxProfileColors = 6;

		private const string InGameMessagesGroup = "In-game Messages";

		[FoldoutGroup("In-game Messages")]
		public Easings.Functions InGameMessageAppearEasingFunction;

		[FoldoutGroup("In-game Messages")]
		public float InGameMessageAppearEasingDuration = 0.6f;

		[FoldoutGroup("In-game Messages")]
		public Sprite InGameMessageDismissIcon;

		[FoldoutGroup("In-game Messages")]
		public Sprite InGameMessageQueuedIcon;

		private const string InGameErrorMessagesGroup = "In-game Error Messages";

		[FoldoutGroup("In-game Error Messages")]
		public float RepeatRecentErrorTimeWindow = 5f;

		[Tooltip("If you repeat an error this meany times within the recent error time window, it will show a text message as well.")]
		[FoldoutGroup("In-game Error Messages")]
		public int RepeatRecentErrorCount = 3;

		[FoldoutGroup("In-game Error Messages")]
		public float TimeAfterIconAppearsWhenNotificationAppears = 1f;

		private const string AlertIndicators = "Alert Indicators";

		[FoldoutGroup("Alert Indicators")]
		public ThemedMaterialType BuildingEchoAlertColor = ThemedMaterialType.Dark;

		[FoldoutGroup("Alert Indicators")]
		public ThemedMaterialType UpgradeAlertColor = ThemedMaterialType.Dark;

		private const string DestinationPinTiming = "Destination Pin Timing";

		[FoldoutGroup("Destination Pin Timing")]
		[MinValue(0)]
		[Tooltip("Delay between visually adding new pins to the same destination. A value of 0 means a pin will always appear the moment the simulation adds a pin.")]
		public float CooldownTimeBetweenNewPins = 0.5f;

		[FoldoutGroup("Destination Pin Timing")]
		[Tooltip("Delay before we visibly add a pin after one is removed. Zero means it will appear instantly.")]
		[MinValue(0)]
		public float PostponementForNewPinsAfterPinRemoved = 2f;

		[MinValue(0)]
		[Tooltip("Delay before we visibly add an overflow pin after big-pinning. Zero means it will appear instantly.")]
		[FoldoutGroup("Destination Pin Timing")]
		public float PostponementForOverflowPinsAfterBigPin = 2f;

		[FoldoutGroup("Destination Pin Timing")]
		[MinValue(0)]
		[Tooltip("What value does the big pin timer have to be at before we show the big pin? The lower this is the more you risk the timer pin rapidly animating in and out if the destination is hovering around its maximum pin count.")]
		public float MinOvercrowdingTimeBeforeTimerPin = 0.2f;

		private const string TransitionIntoGame = "Transition Into Game";

		[FoldoutGroup("Transition Into Game")]
		public AnimationCurve FirstPartTransitionInEaseCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

		[FoldoutGroup("Transition Into Game")]
		public AnimationCurve SecondPartTransitionInEaseCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

		[FoldoutGroup("Transition Into Game")]
		public AnimationCurve FirstPartTransitionOutEaseCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

		[FoldoutGroup("Transition Into Game")]
		public AnimationCurve SecondPartTransitionOutEaseCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

		[FoldoutGroup("Transition Into Game")]
		[Slider(0, 1)]
		public float PercentageOfDurationToUseForInitialMovement = 0.5f;

		[FoldoutGroup("Transition Into Game")]
		public Vector2 MapSelectScreenExitOffset = new Vector2(100f, 0f);

		[FoldoutGroup("Transition Into Game")]
		public Vector2 MapSelectScreenEntryOffset = new Vector2(0f, 100f);

		[FoldoutGroup("Transition Into Game")]
		public Vector2 MapSelectScreenEntryStartHandle = new Vector2(0f, 0f);

		[FoldoutGroup("Transition Into Game")]
		public Vector2 MapSelectScreenEntryEndHandle = new Vector2(0f, 0f);

		private const string RoadAnimation = "Road Animation";

		[FoldoutGroup("Road Animation")]
		public float AppearDuration = 1f;

		[FoldoutGroup("Road Animation")]
		public AnimationCurve OutlineAppearCurve;

		[FoldoutGroup("Road Animation")]
		public AnimationCurve InnerAppearCurve;

		[FoldoutGroup("Road Animation")]
		public float DisappearDuration = 0.2f;

		[FoldoutGroup("Road Animation")]
		public AnimationCurve DisappearCurve;

		[FoldoutGroup("Road Animation")]
		[Tooltip("How long it takes a dead end to emerge from a connection that is mothballed or removed.")]
		public float DeadEndEmergeDuration = 0.2f;

		[FoldoutGroup("Road Animation")]
		public Easings.Functions DeadEndEmergeEasingFunction;

		[Tooltip("How long it takes a dead end to collapse into the connection that replaces it.")]
		[FoldoutGroup("Road Animation")]
		public float DeadEndCollapseDuration = 0.2f;

		[FoldoutGroup("Road Animation")]
		public Easings.Functions DeadEndCollapseEasingFunction;

		[FoldoutGroup("Road Animation")]
		[Tooltip("How long it takes a dead end that is being edited to assume its manual distortion.")]
		public float DeadEndEditDistortionStartDuration = 0.2f;

		[FoldoutGroup("Road Animation")]
		public Easings.Functions DeadEndEditDistortionStartEasingFunction;

		[Tooltip("How long it takes a dead end that is being manually distorted to return to its natural state if the distortion is cancelled.")]
		[FoldoutGroup("Road Animation")]
		public float DeadEndEditDistortionReturnDuration = 0.2f;

		[FoldoutGroup("Road Animation")]
		public Easings.Functions DeadEndEditDistortionReturnEasingFunction;

		[FoldoutGroup("Road Animation")]
		public float RoadDrawingStepDistance = 1.65f;

		[FoldoutGroup("Road Animation")]
		public float DiagonalRoadDrawingStepDistance = 1.65f;

		[FoldoutGroup("Road Animation")]
		public float InteractionCircleOffsetAdjustmentDuration = 0.1f;

		[FoldoutGroup("Road Animation")]
		public float TrafficLightsOffsetAdjustmentDuration = 0.1f;

		[FoldoutGroup("Road Animation")]
		public Easings.Functions InteractionCircleAndTrafficLightAdjustmentEasingFunction;

		private const string RoadPermanence = "Road Permanence";

		[FoldoutGroup("Road Permanence")]
		public AnimationCurve DryingRoadFalloff;

		[FoldoutGroup("Road Permanence")]
		public AnimationCurve DryingMotorwayHazardStripesFalloff;

		[FoldoutGroup("Road Permanence")]
		public AnimationCurve DryingTunnelFalloff;

		[FoldoutGroup("Road Permanence")]
		public float MaxDryingTunnelOpacity;

		[FoldoutGroup("Road Permanence")]
		public AnimationCurve DryingInteractionCircleFalloff;

		private const string UpgradeBar = "Upgrade Bar";

		[FoldoutGroup("Upgrade Bar")]
		[Tooltip("This is the space between each item in the upgrade list")]
		public float UpgradeBarSeparationPadding;

		[Tooltip("This is the space between each item in the upgrade list with a count over 1")]
		[FoldoutGroup("Upgrade Bar")]
		public float UpgradeBarSeparationPaddingWithCount;

		[Tooltip("this is an extra bit of padding right side of the concrete button")]
		[FoldoutGroup("Upgrade Bar")]
		public float UpgradeBarRightSeparationPadding;

		[FoldoutGroup("Upgrade Bar")]
		[Tooltip("This is an extra bit of padding left side of the concrete button")]
		public float UpgradeBarLeftInactiveSeparationPadding;

		private const string Themes = "Themes";

		[FoldoutGroup("Themes")]
		public ColorGroup[] AvailableColorfulColorBlindColorGroups;

		[FoldoutGroup("Themes")]
		public ColorGroup[] AvailableDarkColorBlindColorGroups;

		private const string VehicleHeadlights = "Vehicle Headlights";

		[Tooltip("The time it will take most vehicles to turn their headlights on/off after a day/night mode change")]
		[Min(0f)]
		[FoldoutGroup("Vehicle Headlights")]
		public float MeanVehicleHeadlightResponseTime = 5f;

		[Tooltip("How spread out times are from the mean. Low values mean most response times will be around the mean, higher values mean they will be more spread out.")]
		[Min(0f)]
		[FoldoutGroup("Vehicle Headlights")]
		public float StandardDeviationVehicleHeadlightResponseTime = 1f;

		private const string Trains = "Trains";

		[FoldoutGroup("Trains")]
		[Min(0f)]
		[Tooltip("How far away the train shadow is offset from the train")]
		public float TrainShadowOffset = 0.5f;

		[Min(0f)]
		[FoldoutGroup("Trains")]
		[Tooltip("How long in game time the transition between the front/back headlights takes when a train switches direction")]
		public float TrainHeadlightSwitchTransitionTime = 0.5f;

		[FoldoutGroup("Trains")]
		public Easings.Functions TrainHeadlightSwitchTransitionEasingFunction;

		[FoldoutGroup("Trains")]
		[Min(0f)]
		[Tooltip("How long in game time the train headlights take to turn on/off when toggling day/night mode")]
		public float TrainHeadlightDayNightTransitionTime = 0.5f;

		[FoldoutGroup("Trains")]
		public Easings.Functions TrainHeadlightDayNightTransitionEasingFunction;

		private const string ControllerSpeed = "Controller Speed";

		[FoldoutGroup("Controller Speed")]
		public AnimationCurve ControllerAccelerationCurve;

		[Tooltip("A 0->1 curve that determines how much to use the ControllerAcclerationCurve over camera zoom.")]
		[FoldoutGroup("Controller Speed")]
		public AnimationCurve BaseControllerSpeedOverZoom;

		[FoldoutGroup("Controller Speed")]
		public float BaseControllerSpeed = 0.185f;

		private const string ControllerCamera = "Controller Camera";

		[FoldoutGroup("Controller Camera")]
		public bool ShowGridOnZoom = true;

		[FoldoutGroup("Controller Camera")]
		public List<float> ZoomLevelsCameraMin = new List<float>();

		[FoldoutGroup("Controller Camera")]
		[Tooltip("This needs to have the same number of elements as ZoomLevelsCameraMin as it will correspond with those indexes")]
		public List<float> PanningSpeedPerZoomLevel = new List<float>();

		[FoldoutGroup("Controller Speed")]
		public float[] ControllerSpeedSensitivityOptions = new float[5] { 0.3f, 0.5f, 1f, 1.5f, 2f };

		private const string ButtonColors = "Button Colours";

		[FoldoutGroup("Button Colours")]
		public Color NormalTabButtonColor = new Color(0.5921569f, 0.7450981f, 0.7490196f, 1f);

		[FoldoutGroup("Button Colours")]
		public Color EndlessTabButtonColor = new Color(0.9137256f, 0.7450981f, 0.7960785f, 1f);

		[FoldoutGroup("Button Colours")]
		public Color ExpertTabButtonColor = new Color(0.937255f, 37f / 51f, 0.5372549f, 1f);

		[FoldoutGroup("Button Colours")]
		public Color CreativeTabButtonColor = new Color(0.537255f, 0.7554902f, 0.4372549f, 1f);

		private const string ExpertPermanentRoads = "Expert Permanent Roads";

		[FoldoutGroup("Expert Permanent Roads")]
		[OnValueChanged("OnExpertPermanentRoadFadeLengthChangedCallback")]
		[Slider(0.01f, 1f)]
		public float ExpertPermanentRoadsFadeLength = 0.25f;

		[Slider(0f, 1f)]
		[FoldoutGroup("Expert Permanent Roads")]
		public float ExpertPermanentRoadsFadeDuration = 0.25f;

		[OnValueChanged("OnExpertRemoveHarshAnglesChangedCallback")]
		[FoldoutGroup("Expert Permanent Roads")]
		public bool RemoveHarshAngles = true;

		[FoldoutGroup("Expert Permanent Roads")]
		[OnValueChanged("OnExpertPermanenceDebugViewOpacityChangedCallback")]
		[Slider(0f, 1f)]
		public float PermanenceDebugViewOpacity;

		[Slider(0, 250)]
		[OnValueChanged("OnExpertPermanenceDebugZoneIndexChangedCallback")]
		[FoldoutGroup("Expert Permanent Roads")]
		public int PermanenceDebugViewZoneIndex;

		private const string Rails = "Rails";

		[FoldoutGroup("Rails")]
		public float RailWidth = 0.1f;

		[FoldoutGroup("Rails")]
		public float RailNotchWidth = 0.2f;

		[FoldoutGroup("Rails")]
		public float RailNotchLength = 0.6f;

		[FoldoutGroup("Rails")]
		public float RailEndLength = 1.4f;

		[FoldoutGroup("Rails")]
		public float RailNotchCornerRadius = 0.02f;

		private const string BoatPaths = "BoatPaths";

		[FoldoutGroup("BoatPaths")]
		public float BoatPathWidth = 0.1f;

		[FoldoutGroup("BoatPaths")]
		public float BoatPathDashLength = 0.1f;

		[FoldoutGroup("BoatPaths")]
		public float BoatPathDashGapLength = 0.3f;

		[FoldoutGroup("BoatPaths")]
		public int BoatPathCardinalDegreesCorrection = 4;

		private const string BoatVFX = "Boat VFX";

		[FoldoutGroup("Boat VFX")]
		public float boatMaximumRippleEmission = 6f;

		[FoldoutGroup("Boat VFX")]
		public float boatRippleEmissionStopFactor = 2f;

		[FoldoutGroup("Boat VFX")]
		public float boatRippleSpeed = 35f;

		[FoldoutGroup("Boat VFX")]
		public float boatLightBlinkTime = 1f;

		[FoldoutGroup("Boat VFX")]
		public float boatShadowPivotDistance = 0.6f;

		[FoldoutGroup("Boat VFX")]
		[FormerlySerializedAs("boatTrailFadeInDelay")]
		public float boatTrailDistanceFromTargetFadeIn = 4f;

		[FoldoutGroup("Boat VFX")]
		public float boatTrailDistanceFromTargetVisible = 1f;

		[FoldoutGroup("Boat VFX")]
		public float boatNormalTrailRendererTime = 0.8f;

		[FoldoutGroup("Boat VFX")]
		public float boatDoubleSpeedTrailRendererTime = 0.6f;

		[FoldoutGroup("Boat VFX")]
		public float boatGifCaptureTrailRendererTime = 0.2f;

		[FoldoutGroup("Boat VFX")]
		public float boatMovementBobbingAmplitude = 0.2f;

		[FoldoutGroup("Boat VFX")]
		public float boatMovementBobbingPeriod = 1f;

		[FoldoutGroup("Boat VFX")]
		public float boatMovementBobbingForwardsAmplitude = 0.2f;

		[FoldoutGroup("Boat VFX")]
		public float boatMovementLookAheadDistance = 2f;

		private const string CinematicMode = "Cinematic Mode";

		[FoldoutGroup("Cinematic Mode")]
		public float MaximumDurationOnIdleCar = 10f;

		[FoldoutGroup("Cinematic Mode")]
		public float WaitDurationBetweenCompletedJourneyAndNewAgent = 4f;

		[FoldoutGroup("Cinematic Mode")]
		public float MaximumDurationOnTrain = 120f;

		[FoldoutGroup("Cinematic Mode")]
		public float MinimumDurationOnTrain = 60f;

		[FoldoutGroup("Cinematic Mode")]
		public float ChanceToSelectTrain = 0.1f;

		[FoldoutGroup("Cinematic Mode")]
		public float DistanceAtWhichToLowerChanceToSelectTrain = 30f;

		[Tooltip("How quickly does this accelerate towards the next agent?")]
		[FoldoutGroup("Cinematic Mode")]
		public float CinematicCameraAccelerationWhenChangingAgent = 0.05f;

		[FoldoutGroup("Cinematic Mode")]
		public float CinematicCameraMoveSpeed = 10f;

		[FoldoutGroup("Cinematic Mode")]
		public float CinematicCameraZoomSpeed = 6f;

		[FoldoutGroup("Cinematic Mode")]
		public float CinematicCameraSpringDuration = 0.45f;

		[FoldoutGroup("Cinematic Mode")]
		public Easings.Functions CinematicCameraEasingFunction = Easings.Functions.QuarticEaseOut;

		[FoldoutGroup("Cinematic Mode")]
		public float CinematicTransitionOutBlurSpeed = 0.5f;

		private const string iCloudFaqLink = "iCloud Faq Link";

		[FoldoutGroup("iCloud Faq Link")]
		public string iCloudLinkString;

		public int ProfileIconCount => _profileIconOptions.Length;

		public event Action OnExpertPermanenceDebugZoneIndexChanged;

		public event Action OnExpertPermanenceDebugViewOpacityChanged;

		public event Action OnExpertRemoveHarshAnglesChanged;

		public event Action OnExpertPermanentRoadFadeLengthChanged;

		public Sprite GetProfileIcon(int iconIndex)
		{
			if (_profileIconOptions == null || _profileIconOptions.Length == 0)
			{
				return null;
			}
			if (!Diagnostics.Verify(iconIndex >= 0, "Index {0} is invalid!", iconIndex) || !Diagnostics.Verify(iconIndex < ProfileIconCount, "Trying to get an icon for {0} when we only have {1}", iconIndex, ProfileIconCount))
			{
				iconIndex = 0;
			}
			return _profileIconOptions[iconIndex];
		}

		public Vector3 GetCameraPositionForTransitionToGame(ScreenTransition transition, float transitionInPercentage, CityDefinition city)
		{
			float num = 1f / PercentageOfDurationToUseForInitialMovement;
			if (transitionInPercentage < PercentageOfDurationToUseForInitialMovement)
			{
				float t = FirstPartTransitionInEaseCurve.Evaluate(transitionInPercentage * num);
				Vector2 inPoint = transition.spline.inPoint;
				return (Vector2)Vector3.Lerp(b: inPoint + MapSelectScreenExitOffset, a: inPoint, t: t);
			}
			float num2 = 1f / (1f - PercentageOfDurationToUseForInitialMovement);
			Vector2 outPoint = transition.spline.outPoint;
			Vector2 vector = outPoint + city.cameraZoom.cameraEntryPosition;
			return Spline.EvaluateBezier(SecondPartTransitionInEaseCurve.Evaluate((transitionInPercentage - PercentageOfDurationToUseForInitialMovement) * num2), vector, vector, city.cameraZoom.cameraEntrySplineHandle + outPoint, outPoint);
		}

		public Vector3 GetCameraPositionForTransitionFromGame(ScreenTransition transition, float transitionInPercentage, Vector2 cameraPosition, Vector2 cameraHandle)
		{
			float num = 1f - PercentageOfDurationToUseForInitialMovement;
			if (transitionInPercentage > num)
			{
				float num2 = 1f / PercentageOfDurationToUseForInitialMovement;
				Vector2 outPoint = transition.spline.outPoint;
				Vector2 vector = outPoint + MapSelectScreenEntryOffset;
				float time = (transitionInPercentage - num) * num2;
				return Spline.EvaluateBezier(SecondPartTransitionOutEaseCurve.Evaluate(time), vector, vector + MapSelectScreenEntryStartHandle, MapSelectScreenEntryEndHandle + outPoint, outPoint);
			}
			float num3 = 1f / num;
			Vector2 inPoint = transition.spline.inPoint;
			Vector2 vector2 = inPoint + cameraPosition;
			return Spline.EvaluateBezier(FirstPartTransitionOutEaseCurve.Evaluate(transitionInPercentage * num3), inPoint, inPoint + cameraHandle, vector2, vector2);
		}

		[UsedImplicitly]
		public void OnExpertPermanenceDebugZoneIndexChangedCallback()
		{
			this.OnExpertPermanenceDebugZoneIndexChanged?.Invoke();
		}

		[UsedImplicitly]
		private void OnExpertPermanenceDebugViewOpacityChangedCallback()
		{
			this.OnExpertPermanenceDebugViewOpacityChanged?.Invoke();
		}

		[UsedImplicitly]
		private void OnExpertRemoveHarshAnglesChangedCallback()
		{
			this.OnExpertRemoveHarshAnglesChanged?.Invoke();
		}

		[UsedImplicitly]
		private void OnExpertPermanentRoadFadeLengthChangedCallback()
		{
			this.OnExpertPermanentRoadFadeLengthChanged?.Invoke();
		}

		private void OnValidate()
		{
			if (ControllerSpeedSensitivityOptions.Length != 5)
			{
				Debug.LogWarning("ControllerSpeedSensitivityOptions supports exactly 5 options");
				Array.Resize(ref ControllerSpeedSensitivityOptions, 5);
			}
		}
	}
}
