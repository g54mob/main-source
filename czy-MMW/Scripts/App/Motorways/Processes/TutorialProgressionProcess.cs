using System;
using System.Collections.Generic;
using Client;
using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Actions;
using Motorways.Models;
using Motorways.Views;
using Popups;
using Server;
using UnityEngine;

namespace Motorways.Processes
{
	public class TutorialProgressionProcess : IProcess, IReusable, InputState.IObserver, IReleasedFromScopeHandler
	{
		[Flags]
		public enum TutorialType
		{
			None = 0,
			Mobile = 1,
			Desktop = 4,
			TV = 8
		}

		private struct MessageData
		{
			private enum AnchorType
			{
				Screen = 0,
				World = 1,
				UI = 2
			}

			private AnchorType _anchorType;

			public StringId messageString;

			public int? intParameter;

			public Vector3 position;

			public TileDirection direction;

			public bool force;

			public UIMessageAnchor uiAnchor;

			public CameraLayer cameraLayer;

			public bool IsScreenAnchored => _anchorType == AnchorType.Screen;

			public bool IsWorldAnchored => _anchorType == AnchorType.World;

			public bool IsUIAnchored => _anchorType == AnchorType.UI;

			public MessageData(StringId messageString, Vector3 offset, CameraLayer cameraLayer = CameraLayer.Default, bool force = false, int? intParameter = null)
			{
				this.messageString = messageString;
				position = offset;
				direction = TileDirection.None;
				this.force = force;
				_anchorType = AnchorType.Screen;
				uiAnchor = UIMessageAnchor.None;
				this.cameraLayer = cameraLayer;
				this.intParameter = intParameter;
			}

			public MessageData(StringId messageString, Vector3 position, TileDirection direction, bool force = false)
			{
				this.messageString = messageString;
				this.position = position;
				this.direction = direction;
				this.force = force;
				_anchorType = AnchorType.World;
				uiAnchor = UIMessageAnchor.None;
				cameraLayer = CameraLayer.Default;
				intParameter = null;
			}

			public MessageData(StringId messageString, UIMessageAnchor uiMessageAnchor, Vector2 offset)
			{
				this.messageString = messageString;
				uiAnchor = uiMessageAnchor;
				position = offset;
				direction = TileDirection.None;
				force = false;
				_anchorType = AnchorType.UI;
				cameraLayer = CameraLayer.Default;
				intParameter = null;
			}
		}

		public enum TutorialMarker
		{
			InitialMarker = 0,
			InputControlsTaught = 1,
			BasicsLearnt = 2,
			DemandCollectedFromNewHouseColor = 3,
			BeganBridgeStage = 4,
			BeganTrafficLightStage = 5,
			BeganRoundaboutStage = 6,
			BeganMotorwayStage = 7,
			BeganBigPinStage = 8,
			BeganUpgradeChoiceStage = 9,
			BigPinsAllowed = 10
		}

		public class TutorialStep
		{
			public string Id { get; }

			public string Description { get; }

			public string StageShortName { get; set; }

			public Func<string> DebugText { get; private set; }

			public Func<bool> DoesClockTick { get; private set; } = () => true;

			public Func<bool> IsStepOver { get; private set; }

			public Action<Fix64> IdlePromptAnimationHandler { get; private set; }

			public List<IdleHint> IdleHints { get; } = new List<IdleHint>();

			public Action<Fix64> IdleMessageAnimationHandler { get; private set; }

			public Func<bool> ShouldRegressStep { get; private set; }

			public Action<bool> OnStepStart { get; private set; }

			public Action OnStepComplete { get; private set; }

			public Action DesignerConstantsUpdateHandler { get; private set; }

			public TutorialStep(string id, string description = null)
			{
				Id = id;
				Description = description;
			}

			public TutorialStep ClockTicksWhile(Func<bool> clockTickCheck)
			{
				DoesClockTick = clockTickCheck;
				return this;
			}

			public TutorialStep StepOverWhen(Func<bool> stepOverCheck)
			{
				IsStepOver = stepOverCheck;
				return this;
			}

			public TutorialStep WhenStepStarts(Action<bool> onStartHandler)
			{
				OnStepStart = onStartHandler;
				return this;
			}

			public TutorialStep WhenStepStarts(Action onStartHandler)
			{
				OnStepStart = delegate
				{
					onStartHandler();
				};
				return this;
			}

			public TutorialStep StepRegressesWhen(Func<bool> stepRegressCheck)
			{
				ShouldRegressStep = stepRegressCheck;
				return this;
			}

			public TutorialStep WhenStepEnds(Action onCompleteHandler)
			{
				OnStepComplete = onCompleteHandler;
				return this;
			}

			public TutorialStep AddIdleHint(IdleHint idleHint)
			{
				IdleHints.Add(idleHint);
				return this;
			}

			public TutorialStep SetIdlePromptHandler(Action<Fix64> idleAnimation)
			{
				IdlePromptAnimationHandler = idleAnimation;
				return this;
			}

			public TutorialStep SetIdleMessageHandler(Action<Fix64> idleAnimation)
			{
				IdleMessageAnimationHandler = idleAnimation;
				return this;
			}

			public TutorialStep SetDesignerConstantsUpdateHandler(Action constantsUpdateHandler)
			{
				DesignerConstantsUpdateHandler = constantsUpdateHandler;
				return this;
			}

			public TutorialStep SetDebugText(Func<string> debugText)
			{
				DebugText = debugText;
				return this;
			}
		}

		private int _roadCountAfterDrawStep;

		private int _roadCountBeforeWaitUntilDeleteModeEnabled;

		private int _concreteCountAtStartOfTutorial;

		private Fix64 _drawRoadHintAnimationTimer = Fix64.Zero;

		public const int TutorialEndWeek = 6;

		private const float MinimumTimeForDismissibleMessages = 2f;

		private int _currentStepIndex;

		[Dependency]
		private IScope _scope;

		[Dependency]
		private TutorialConstantsData _tutorialConstants;

		[Dependency]
		private City _city;

		[Dependency]
		private ISimulation _simulation;

		[Dependency]
		private ClockModel _clock;

		[Dependency]
		private ScoreModel _score;

		[Dependency]
		private Pathfinder _pathfinder;

		[Dependency]
		private InputState _inputState;

		[Dependency]
		private UpgradeDatabaseModel _upgradeDatabase;

		[Dependency]
		private PopupStack _popups;

		[Dependency]
		private ActivePlayer _player;

		[Dependency]
		private PlayerActionController _playerActionController;

		[Dependency]
		private CameraView _cameraView;

		[Dependency]
		private ScreenStack _screenStack;

		[Dependency]
		private ViewClient _viewClient;

		[Serialize(false, null)]
		private GameUIScreen _gameUI;

		[Serialize(false, null)]
		private CameraView _camera;

		public bool hadInput;

		private IndicatorAnimationView _idleTapAnimationView;

		private bool _isInTutorial;

		private int _scoreToFinishTutorial;

		[Serialize(false, null)]
		private GameRules _rules;

		private Fix64 _clockSpeedMultiplier;

		private bool _isProgressing;

		private ConfirmationPopup _currentPopup;

		private bool _hasShownAlternateDrawModeTogglePopup;

		private Fix64 _timeSpentInStep = Fix64.Zero;

		private Fix64 _timeSpentNotProgressing = Fix64.Zero;

		private float _unscaledMessageTimer;

		private Vector2Int _currentControllerPosition;

		private bool _controllerIsDrawingRoads;

		private TutorialBuilder _tutorial;

		[Serialize(false, null)]
		private readonly List<IndicatorAnimationView> _animatorViews = new List<IndicatorAnimationView>();

		[Serialize(false, null)]
		private AnchoredMessageModel currentMessage;

		[Serialize(false, null)]
		private MessageData? _nextMessage;

		private static readonly Fix64 ClockDecelerationMultiplier = (Fix64)5L;

		private static readonly Fix64 ClockAccelerationMultiplier = (Fix64)1L;

		private static readonly Fix64 DelayBeforeIdleAnimation = (Fix64)10f;

		private static readonly Fix64 DelayBeforeIdleMessage = (Fix64)0.5f;

		private bool _skipTimeForDismissibleMessages;

		private int _numberOfVehiclesThatHaveLeftAMotorway;

		private readonly List<VehicleModel> _vehiclesOnMotorway = new List<VehicleModel>();

		private int _numberOfVehiclesThatHaveLeftARoundabout;

		private readonly List<VehicleModel> _vehiclesOnRoundabout = new List<VehicleModel>();

		public const int NoDemandLimit = -1;

		private readonly Dictionary<TutorialIdentifier, int> _demandLimits = new Dictionary<TutorialIdentifier, int>();

		private bool _enteredDeleteMode = true;

		private bool _exitedDeleteMode = true;

		private RoadDrawMode _previousRoadDrawMode;

		private IdleHint _connectHousesIdleMessage;

		private bool _connectHouseIdleMessageHasBeenDismissed;

		private Fix64 _tapIndexTimer = Fix64.Zero;

		private Fix64 _dragIndicatorTimer = Fix64.Zero;

		private StringId ClockStringId => _inputState.CurrentDeviceInputType switch
		{
			DeviceInputType.Mouse => StringId.Tutorial_ClockIntroduction_Mouse, 
			DeviceInputType.Remote => StringId.Tutorial_ClockIntroduction_Remote, 
			DeviceInputType.Controller => StringId.Tutorial_ClockIntroduction_Controller, 
			_ => StringId.Tutorial_ClockIntroduction, 
		};

		public string CurrentStage { get; private set; }

		public string CurrentStageShortName { get; private set; }

		public TutorialMarker LastReachedMarker { get; private set; }

		public Fix64 ClockSpeedMultiplier => _clockSpeedMultiplier;

		private Vector3 CurrentControllerWorldPosition => _currentControllerPosition.ToVector3() * 2f;

		public bool HasPlayerMothballedARoad { get; private set; }

		public bool ShowNoConcreteErrorMessage { get; private set; } = true;

		public bool HasVisibleMessage => currentMessage != null;

		public TutorialStep CurrentStep
		{
			get
			{
				if (_tutorial.Steps == null || _tutorial.Steps.Count <= 0 || _currentStepIndex >= _tutorial.Steps.Count)
				{
					return null;
				}
				return _tutorial.Steps[_currentStepIndex];
			}
		}

		public int CurrentStepIndex => _currentStepIndex;

		public int StageCount => _tutorial.Steps.Count;

		public bool IsInputBlocked => _playerActionController.TutorialBlockInputFlag;

		private void AddBigPinStage()
		{
			_tutorial.StartStage("Upgrade Big Pin", "UBP");
			_tutorial.AddStep(new TutorialStep("EnsureZoomedOut").ClockTicksWhile(() => false).StepOverWhen(() => !_camera.IsFocussedIn));
			_tutorial.AddStep(new TutorialStep("Small delay").ClockTicksWhile(() => true).StepOverWhen(() => RequireTimePassed(1f)));
			_tutorial.AddStep(new TutorialStep("FirstOvercrowdingMessage").ClockTicksWhile(() => false).WhenStepStarts((Action)delegate
			{
				PrepareForDismissibleMessage();
				SetNextMessageAnchoredToScreen(StringId.Tutorial_OvercrowdingTwo_02, _tutorialConstants.UnanchoredMessageOffset);
			}).StepOverWhen(HadInputAndMessageSpentMinimumTime)
				.WhenStepEnds(RestorePlayerControl));
			_tutorial.AddStep(new TutorialStep("Small delay").ClockTicksWhile(() => true).StepOverWhen(() => RequireTimePassed(1f)));
			_tutorial.AddStep(new TutorialStep("SecondOvercrowdingMessage").ClockTicksWhile(() => false).WhenStepStarts((Action)delegate
			{
				PrepareForDismissibleMessage();
				SetNextMessageAnchoredToScreen(StringId.Tutorial_OvercrowdingThree_02, _tutorialConstants.UnanchoredMessageOffset);
			}).StepOverWhen(HadInputAndMessageSpentMinimumTime)
				.WhenStepEnds(RestorePlayerControl));
			_tutorial.AddStep(new TutorialStep("EnsureZoomedOut_2").ClockTicksWhile(() => false).StepOverWhen(() => !_camera.IsFocussedIn));
			_tutorial.AddStep(new TutorialStep("AddDemandToBigPinDestination").ClockTicksWhile(() => true).WhenStepStarts((Action)delegate
			{
				LimitGeneratedDemandForDestination(TutorialIdentifier.BigPinDestination, 10);
				SetTotalDemandOnDestination(TutorialIdentifier.BigPinDestination, 10);
			}).StepOverWhen(() => RequireTimePassed(3f)));
			_tutorial.AddStep(new TutorialStep("EnsureZoomedOut_3").ClockTicksWhile(() => false).StepOverWhen(() => !_camera.IsFocussedIn));
			_tutorial.AddStep(new TutorialStep("SpeedUpOvercrowdTimer", "Advance clock so player can respond to surge.").ClockTicksWhile(() => _clock.Day <= 30).WhenStepStarts((Action)delegate
			{
				DestinationModel destinationById = GetDestinationById(TutorialIdentifier.BigPinDestination);
				Fix64 overcrowdingTime = Fix64.Max(Fix64.Max(destinationById.CurrentFrame.OvercrowdingTime, destinationById.NextFrame.OvercrowdingTime), Fix64Consts.OneHalf);
				destinationById.CurrentFrame.OvercrowdingTime = overcrowdingTime;
				destinationById.NextFrame.OvercrowdingTime = overcrowdingTime;
			}).StepOverWhen(() => true));
			_tutorial.AddStep(new TutorialStep("OvercrowdingMessage").ClockTicksWhile(() => _clock.Day <= 30).WhenStepStarts(delegate(bool stepAlreadyComplete)
			{
				if (!stepAlreadyComplete)
				{
					DestinationModel destinationById = GetDestinationById(TutorialIdentifier.BigPinDestination);
					Fix64 overcrowdingTime = Fix64.Max(Fix64.Max(destinationById.CurrentFrame.OvercrowdingTime, destinationById.NextFrame.OvercrowdingTime), Fix64Consts.OneHalf);
					destinationById.CurrentFrame.OvercrowdingTime = overcrowdingTime;
					destinationById.NextFrame.OvercrowdingTime = overcrowdingTime;
					SetNextMessageAnchoredToScreen(StringId.Tutorial_OvercrowdingFour, _tutorialConstants.UnanchoredMessageOffset);
				}
			}).StepOverWhen(() => RequireAllHousesAndDestinationsInGroupToBeConnected(2) || !GetDestinationById(TutorialIdentifier.BigPinDestination).IsOvercrowding)
				.WhenStepEnds(delegate
				{
					RemoveAllPerDestinationDemandLimits();
				}));
			_tutorial.AddStep(new TutorialStep("WaitToClearBigPin").ClockTicksWhile(() => _clock.Day <= 30).StepOverWhen(() => !GetDestinationById(TutorialIdentifier.BigPinDestination).IsOvercrowding && RequireTimePassed(15f)));
		}

		private void DrawRoadHintAnimationHandler(Fix64 timestep, Vector2 from, Vector2 to, float delayBeforeReplay)
		{
			if (_drawRoadHintAnimationTimer <= Fix64.Zero)
			{
				IndicatorAnimationView indicatorAnimationView = AddDragIndicator(from, to);
				_drawRoadHintAnimationTimer = indicatorAnimationView.Duration + (Fix64)delayBeforeReplay;
			}
			else
			{
				_drawRoadHintAnimationTimer -= timestep;
			}
		}

		private void AddDrawDeleteStage()
		{
			SetDrawModeToggleVisibility(isVisible: false);
			_tutorial.StartStage("Draw/Delete", "DD");
			_tutorial.AddRealtimeDelay(0.5f, clockTicks: false);
			_tutorial.AddStep(new TutorialStep("WelcomeMessage").ClockTicksWhile(() => false).WhenStepStarts((Action)delegate
			{
				PrepareForDismissibleMessage();
				SetNextMessageAnchoredToScreen(StringId.Tutorial_Welcome, _tutorialConstants.UnanchoredMessageOffset);
			}).StepOverWhen(HadInputAndMessageSpentMinimumTime));
			_tutorial.AddRealtimeDelay(2.5f, clockTicks: false);
			_tutorial.AddStep(new TutorialStep("WelcomeMessage2").ClockTicksWhile(() => false).WhenStepStarts((Action)delegate
			{
				PrepareForDismissibleMessage();
				SetNextMessageAnchoredToScreen(StringId.Tutorial_Welcome_02, _tutorialConstants.UnanchoredMessageOffset);
			}).StepOverWhen(HadInputAndMessageSpentMinimumTime)
				.WhenStepEnds(delegate
				{
					_concreteCountAtStartOfTutorial = _upgradeDatabase.GetAvailableUpgradeCount(UpgradeType.Concrete);
					RestorePlayerControl();
				}));
			_tutorial.AddRealtimeDelay(2f, clockTicks: false);
			_tutorial.AddStep(new TutorialStep("Setup").ClockTicksWhile(() => false).WhenStepStarts((Action)delegate
			{
				SetDrawModeToggleVisibility(isVisible: false);
				_gameUI.SetUpgradeBarVisibility(visible: true);
				ShowNoConcreteErrorMessage = false;
			}).StepOverWhen(() => true));
			switch (_inputState.CurrentDeviceInputType)
			{
			case DeviceInputType.Touch:
				AddTouchSteps_DrawDelete();
				break;
			case DeviceInputType.Mouse:
				AddMouseSteps_DrawDelete();
				break;
			case DeviceInputType.Controller:
				AddControllerSteps_DrawDelete();
				break;
			case DeviceInputType.Remote:
				AddRemoteSteps_DrawDelete();
				break;
			}
			_tutorial.AddMarker(TutorialMarker.InputControlsTaught);
		}

		private void AddControllerSteps_DrawDelete()
		{
			_tutorial.AddStep(new TutorialStep("PromptToDraw_OneRoad").ClockTicksWhile(() => false).StepOverWhen(() => RoadCountGreaterThanOrEqualTo((int)((float)_concreteCountAtStartOfTutorial * 0.6f))).WhenStepStarts(delegate(bool isStepOver)
			{
				if (!isStepOver)
				{
					StringId messageString = (_player.IsTapDrawEnabled ? StringId.Tutorial_PromptToStartDrawRoad_ControllerTap : StringId.Tutorial_PromptToStartDrawRoad_Controller);
					SetNextMessageAnchoredToScreen(messageString, _tutorialConstants.UnanchoredMessageOffset);
				}
			})
				.AddIdleHint(new IdleHint().SetDelayBeforeShowing(0.5f).SetShowHintHandler(delegate(Fix64 timestep)
				{
					DrawRoadHintAnimationHandler(timestep, _tutorialConstants.DrawRoadIdleHintStartPosition, _tutorialConstants.DrawRoadIdleHintEndPosition, 0f);
				}).AddCondition(() => RoadCountIs(0)))
				.WhenStepEnds(delegate
				{
					_drawRoadHintAnimationTimer = Fix64.Zero;
					_roadCountAfterDrawStep = GetRoadCount();
				})
				.SetDebugText(() => $"Road Count: {GetRoadCount()}/{_concreteCountAtStartOfTutorial}"));
			_tutorial.AddStep(new TutorialStep("WaitBeforeDeletePrompt").ClockTicksWhile(() => false).StepOverWhen(() => RequireTimePassed(0.5f)));
			_tutorial.AddStep(new TutorialStep("PromptToDelete_Controller", "Tell the player how to delete roads.").ClockTicksWhile(() => false).StepOverWhen(() => _roadCountAfterDrawStep - GetRoadCount() >= 1 && _enteredDeleteMode && _exitedDeleteMode).SetDebugText(delegate
			{
				int num = _roadCountAfterDrawStep - GetRoadCount();
				return $"Deleted Roads {num}, current roads {GetRoadCount()}";
			})
				.WhenStepStarts(delegate(bool isStepOver)
				{
					if (!isStepOver)
					{
						StringId messageString = (_player.IsTapDrawEnabled ? StringId.Tutorial_PromptToDeleteRoad_ControllerTap : StringId.Tutorial_PromptToDeleteRoad_Controller);
						SetNextMessageAnchoredToScreen(messageString, _tutorialConstants.UnanchoredMessageOffset);
					}
					_roadCountAfterDrawStep = GetRoadCount();
				})
				.WhenStepEnds(delegate
				{
					_simulation.IsPaused = false;
				}));
			_tutorial.AddStep(new TutorialStep("PromptToDeleteAllRoads_Controller").ClockTicksWhile(() => false).StepOverWhen(() => RoadCountIs(0)).WhenStepStarts(delegate(bool isStepOver)
			{
				if (!isStepOver)
				{
					SetNextMessageAnchoredToScreen(StringId.Tutorial_DeleteAllRoads, _tutorialConstants.UnanchoredMessageOffset);
				}
			}));
			_tutorial.AddStep(new TutorialStep("WaitBeforeTapDrawFTUX").ClockTicksWhile(() => false).StepOverWhen(() => RequireTimePassed(0.5f)));
			ShowControllerTapDrawFtux();
		}

		private void AddRemoteSteps_DrawDelete()
		{
			_tutorial.AddStep(new TutorialStep("PromptToDraw_OneRoad").ClockTicksWhile(() => false).StepOverWhen(() => _controllerIsDrawingRoads).WhenStepStarts(delegate(bool isStepOver)
			{
				if (!isStepOver)
				{
					SetNextMessageAnchoredToWorld(StringId.Tutorial_PromptToStartDrawRoad_Remote, _tutorialConstants.DrawRoadIdleHintStartPosition, TileDirection.North, force: true);
					AddHighlightPositionIndicator(_tutorialConstants.DrawRoadIdleHintStartPosition);
				}
			})
				.WhenStepEnds(delegate
				{
					_drawRoadHintAnimationTimer = Fix64.Zero;
					_roadCountAfterDrawStep = GetRoadCount();
				})
				.SetDebugText(() => $"Road Count: {GetRoadCount()}/{_concreteCountAtStartOfTutorial}"));
			_tutorial.AddStep(new TutorialStep("PromptToDraw_DragCursor").ClockTicksWhile(() => false).StepOverWhen(() => RoadCountGreaterThanOrEqualTo(1)).WhenStepStarts((Action)delegate
			{
				_dragIndicatorTimer = Fix64.Zero;
				Vector2 vector = _tutorialConstants.DrawRoadIdleHintEndPosition;
				if (Mathf.Abs(CurrentControllerWorldPosition.x - _tutorialConstants.DrawRoadIdleHintStartPosition.x) > 4f)
				{
					vector = _tutorialConstants.DrawRoadIdleHintStartPosition;
				}
				SetNextMessageAnchoredToWorld(StringId.Tutorial_PromptToFinishDrawRoad_Remote, vector, TileDirection.North, force: true);
				AddHighlightPositionIndicator(vector);
			})
				.AddIdleHint(new IdleHint().AddCondition(() => _controllerIsDrawingRoads).SetDelayBeforeShowing(2f).SetShowHintHandler(delegate(Fix64 timestep)
				{
					Vector2 vector = _tutorialConstants.DrawRoadIdleHintEndPosition;
					if (Mathf.Abs(CurrentControllerWorldPosition.x - _tutorialConstants.DrawRoadIdleHintStartPosition.x) > 4f)
					{
						vector = _tutorialConstants.DrawRoadIdleHintStartPosition;
					}
					DragIndicatorBetween(CurrentControllerWorldPosition, vector, timestep);
				}))
				.WhenStepEnds(delegate
				{
					_dragIndicatorTimer = Fix64.Zero;
					_drawRoadHintAnimationTimer = Fix64.Zero;
					_roadCountAfterDrawStep = GetRoadCount();
				})
				.StepRegressesWhen(() => !_controllerIsDrawingRoads && !RoadCountGreaterThanOrEqualTo(_concreteCountAtStartOfTutorial))
				.SetDebugText(() => $"Road Count: {GetRoadCount()}/{_concreteCountAtStartOfTutorial}"));
			_tutorial.AddStep(new TutorialStep("WaitBeforeDeletePrompt").ClockTicksWhile(() => false).StepOverWhen(() => RequireTimePassed(0.5f)));
			_tutorial.AddStep(new TutorialStep("PromptToDelete_Remote", "Tell the player how to delete roads.").ClockTicksWhile(() => false).StepOverWhen(() => _roadCountAfterDrawStep > GetRoadCount()).WhenStepStarts(delegate(bool isStepOver)
			{
				SetDrawModeToggleVisibility(isVisible: true);
				if (!isStepOver)
				{
					SetNextMessageAnchoredToScreen(StringId.Tutorial_PromptToDeleteRoad_Remote, _tutorialConstants.UnanchoredMessageOffset);
				}
			})
				.SetDebugText(() => $"Deleted Road Count: {_roadCountAfterDrawStep - GetRoadCount()}, Entered Delete Mode: {_enteredDeleteMode}, Exited Delete Mode: {_exitedDeleteMode}"));
			_tutorial.AddStep(new TutorialStep("PromptToDeleteAllRoads_Remote").ClockTicksWhile(() => false).StepOverWhen(() => RoadCountIs(0)).WhenStepStarts(delegate(bool isStepOver)
			{
				if (!isStepOver)
				{
					SetNextMessageAnchoredToScreen(StringId.Tutorial_DeleteAllRoads, _tutorialConstants.UnanchoredMessageOffset);
				}
			}));
			_tutorial.AddStep(new TutorialStep("WaitBeforeExitDeletePrompt").ClockTicksWhile(() => false).StepOverWhen(() => RequireTimePassed(0.5f)));
			_tutorial.AddStep(new TutorialStep("PromptToExitDeleteMode_Remote").ClockTicksWhile(() => false).StepOverWhen(() => _exitedDeleteMode).WhenStepStarts(delegate(bool isStepOver)
			{
				if (!isStepOver)
				{
					SetNextMessageAnchoredToScreen(StringId.Tutorial_TapExitBuildMode_Remote, _tutorialConstants.UnanchoredMessageOffset);
				}
			}));
		}

		private void AddMouseSteps_DrawDelete()
		{
			_tutorial.AddStep(new TutorialStep("PromptToDraw_OneRoad").ClockTicksWhile(() => false).StepOverWhen(() => RoadCountGreaterThanOrEqualTo((int)((float)_concreteCountAtStartOfTutorial * 0.6f))).WhenStepStarts(delegate(bool isStepOver)
			{
				if (!isStepOver)
				{
					SetNextMessageAnchoredToScreen(StringId.Tutorial_PromptToDrawRoad_Mouse, _tutorialConstants.UnanchoredMessageOffset);
				}
			})
				.AddIdleHint(new IdleHint().SetDelayBeforeShowing(0.5f).SetShowHintHandler(delegate(Fix64 timestep)
				{
					DrawRoadHintAnimationHandler(timestep, _tutorialConstants.DrawRoadIdleHintStartPosition, _tutorialConstants.DrawRoadIdleHintEndPosition, 0f);
				}).AddCondition(() => RoadCountIs(0)))
				.WhenStepEnds(delegate
				{
					_drawRoadHintAnimationTimer = Fix64.Zero;
					_roadCountAfterDrawStep = GetRoadCount();
				})
				.SetDebugText(() => $"Road Count: {GetRoadCount()}/{_concreteCountAtStartOfTutorial}"));
			_tutorial.AddStep(new TutorialStep("WaitBeforeDeletePrompt").ClockTicksWhile(() => false).StepOverWhen(() => RequireTimePassed(0.5f)));
			_tutorial.AddStep(new TutorialStep("PromptToDelete_Mouse", "Tell the player how to delete roads.").ClockTicksWhile(() => false).StepOverWhen(delegate
			{
				if (_player.IsDrawModeToggleEnabled)
				{
					return true;
				}
				return _roadCountAfterDrawStep - GetRoadCount() >= 1 && _enteredDeleteMode && _exitedDeleteMode;
			}).SetDebugText(delegate
			{
				int num = _roadCountAfterDrawStep - GetRoadCount();
				return $"Deleted Roads {num}, current roads {GetRoadCount()}";
			})
				.WhenStepStarts(delegate(bool isStepOver)
				{
					if (!isStepOver)
					{
						SetNextMessageAnchoredToScreen(StringId.Tutorial_PromptToDeleteRoad_Mouse, _tutorialConstants.UnanchoredMessageOffset);
					}
					_roadCountAfterDrawStep = GetRoadCount();
				})
				.WhenStepEnds(delegate
				{
					_simulation.IsPaused = false;
				})
				.AddIdleHint(new IdleHint().SetDelayBeforeShowing(15f).SetShowHintHandler((Action)delegate
				{
					if (_currentPopup == null && !_hasShownAlternateDrawModeTogglePopup && !_player.IsDrawModeToggleEnabled)
					{
						_hasShownAlternateDrawModeTogglePopup = true;
						_simulation.IsPaused = true;
						_currentPopup = _popups.PushConfirmationPopup<ConfirmationPopup>(StringId.Options_Game_DrawDeleteToggle, delegate
						{
							_currentPopup = null;
						}, delegate
						{
							_currentPopup = null;
							_player.IsDrawModeToggleEnabled = true;
							SetDrawModeToggleVisibility(isVisible: true);
						}, StringId.FTUX_Accessibility_DrawModeToggleDescription);
					}
				})));
			_tutorial.AddStep(new TutorialStep("WaitBeforeDrawDeleteFTUX").ClockTicksWhile(() => false).StepOverWhen(() => RequireTimePassed(0.5f)));
			ShowDrawModeFtuxPopup();
			_tutorial.AddStep(new TutorialStep("RecordRoadCountBeforeWaitUntilDeleteModeEnabled").ClockTicksWhile(() => false).StepOverWhen(() => true).WhenStepEnds(delegate
			{
				_roadCountBeforeWaitUntilDeleteModeEnabled = GetRoadCount();
			}));
			_tutorial.AddStep(new TutorialStep("WaitUntilDeleteModeEnabled_DrawModeToggleModeEnabled").ClockTicksWhile(() => false).StepOverWhen(() => !_player.IsDrawModeToggleEnabled || ((GetRoadCount() < _roadCountBeforeWaitUntilDeleteModeEnabled || _roadCountBeforeWaitUntilDeleteModeEnabled == 0) && _gameUI.CurrentRoadDrawMode == RoadDrawMode.Remove)).WhenStepStarts(delegate(bool isStepOver)
			{
				if (_player.IsDrawModeToggleEnabled)
				{
					SetDrawModeToggleVisibility(isVisible: true);
				}
				if (!isStepOver)
				{
					SetNextMessageAnchoredToScreen(StringId.Tutorial_PromptToDeleteRoad_MouseToggle, _tutorialConstants.UnanchoredMessageOffset);
				}
			})
				.AddIdleHint(new IdleHint().SetShowHintHandler((Action)delegate
				{
					_gameUI.drawModeToggle.Pulse();
				})));
			_tutorial.AddStep(new TutorialStep("PromptToDeleteAllRoads_Mouse").ClockTicksWhile(() => false).StepOverWhen(() => RoadCountIs(0)).WhenStepStarts(delegate(bool isStepOver)
			{
				if (!isStepOver)
				{
					SetNextMessageAnchoredToScreen(StringId.Tutorial_DeleteAllRoads, _tutorialConstants.UnanchoredMessageOffset);
				}
			}));
			_tutorial.AddStep(new TutorialStep("ExitDeleteMode_DrawDeleteMouse").ClockTicksWhile(() => false).StepOverWhen(() => !_player.IsDrawModeToggleEnabled || _gameUI.CurrentRoadDrawMode == RoadDrawMode.Add).WhenStepStarts(delegate(bool isStepOver)
			{
				if (!isStepOver)
				{
					SetNextMessageAnchoredToScreen(StringId.Tutorial_TapExitBuildMode_MouseToggle, _tutorialConstants.UnanchoredMessageOffset);
				}
			})
				.AddIdleHint(new IdleHint().SetShowHintHandler((Action)delegate
				{
					_gameUI.drawModeToggle.Pulse();
				})));
		}

		private void ShowControllerTapDrawFtux()
		{
			_tutorial.AddStep(new TutorialStep("TapDrawFTUX", "Ask if player wants to use tap draw on controller.").ClockTicksWhile(() => false).WhenStepStarts((Action)delegate
			{
				StringId mainPromptStringId = StringId.TapDrawToggle;
				if (!_player.IsTapDrawEnabled && !_hasShownAlternateDrawModeTogglePopup)
				{
					_hasShownAlternateDrawModeTogglePopup = true;
					_simulation.IsPaused = true;
					_currentPopup = _popups.PushConfirmationPopup<ConfirmationPopup>(mainPromptStringId, delegate
					{
						_currentPopup = null;
					}, delegate
					{
						_currentPopup = null;
						_player.IsTapDrawEnabled = true;
					}, StringId.FTUX_Accessibility_DrawDeleteHoldOrTapDescription);
				}
			}).WhenStepEnds(delegate
			{
				_simulation.IsPaused = false;
			})
				.StepOverWhen(() => _currentPopup == null));
			_tutorial.AddStep(new TutorialStep("Wait_AfterDrawModeFTUX", "Wait a little so next delete prompt doesn't pop in immediately").ClockTicksWhile(() => false).StepOverWhen(() => RequireTimePassed(1f)));
		}

		private void ShowDrawModeFtuxPopup()
		{
			if (!FeatureToggle.IsFeatureEnabled(Feature.FTUX_Accessibility))
			{
				return;
			}
			_tutorial.AddStep(new TutorialStep("DrawModeFTUX", "Ask if player wants to use draw mode toggle.").ClockTicksWhile(() => false).WhenStepStarts((Action)delegate
			{
				if (!_player.IsDrawModeToggleEnabled && !_hasShownAlternateDrawModeTogglePopup)
				{
					_hasShownAlternateDrawModeTogglePopup = true;
					_simulation.IsPaused = true;
					_currentPopup = _popups.PushConfirmationPopup<ConfirmationPopup>(StringId.DrawModeToggle, delegate
					{
						_currentPopup = null;
					}, delegate
					{
						_currentPopup = null;
						_player.IsDrawModeToggleEnabled = true;
						SetDrawModeToggleVisibility(isVisible: true);
					}, StringId.FTUX_Accessibility_DrawModeToggleDescription);
				}
			}).WhenStepEnds(delegate
			{
				_simulation.IsPaused = false;
			})
				.StepOverWhen(() => _currentPopup == null));
			_tutorial.AddStep(new TutorialStep("Wait_AfterDrawModeFTUX", "Wait a little so next delete prompt doesn't pop in immediately").ClockTicksWhile(() => false).StepOverWhen(() => RequireTimePassed(1f)));
		}

		private void AddTouchSteps_DrawDelete()
		{
			_tutorial.AddStep(new TutorialStep("EditMode", "Enter edit mode.").ClockTicksWhile(() => false).StepOverWhen(() => _camera.IsFocussedIn).WhenStepStarts((Action)delegate
			{
				SetNextMessageAnchoredToScreen(StringId.Tutorial_TapEnterBuildMode_Touch, _tutorialConstants.UnanchoredMessageOffset);
			}));
			_tutorial.AddStep(new TutorialStep("PromptToDrawRoad").ClockTicksWhile(() => false).StepOverWhen(() => RoadCountGreaterThanOrEqualTo(_concreteCountAtStartOfTutorial)).WhenStepStarts(delegate(bool isStepOver)
			{
				if (!isStepOver)
				{
					SetNextMessageAnchoredToScreen(StringId.Tutorial_PromptToDrawRoad_Touch, _tutorialConstants.UnanchoredMessageOffset);
				}
			})
				.StepRegressesWhen(() => !_camera.IsFocussedIn)
				.AddIdleHint(new IdleHint().SetDelayBeforeShowing(0.5f).SetShowHintHandler(delegate(Fix64 timestep)
				{
					DrawRoadHintAnimationHandler(timestep, _tutorialConstants.DrawRoadIdleHintStartPosition, _tutorialConstants.DrawRoadIdleHintEndPosition, 0f);
				}).AddCondition(() => RoadCountIs(0)))
				.WhenStepEnds(delegate
				{
					_drawRoadHintAnimationTimer = Fix64.Zero;
					_roadCountAfterDrawStep = GetRoadCount();
				})
				.SetDebugText(() => $"Road Count: {GetRoadCount()}/{_concreteCountAtStartOfTutorial}"));
			_tutorial.AddStep(new TutorialStep("WaitBeforeDeletePrompt").ClockTicksWhile(() => false).StepOverWhen(() => RequireTimePassed(0.5f)).StepRegressesWhen(() => !_camera.IsFocussedIn));
			_tutorial.AddStep(new TutorialStep("WaitUntilDeleteModeEnabled_DrawModeToggleModeEnabled").ClockTicksWhile(() => false).StepOverWhen(() => _gameUI.CurrentRoadDrawMode == RoadDrawMode.Remove && GetRoadCount() < _roadCountAfterDrawStep).WhenStepStarts(delegate(bool isStepOver)
			{
				SetDrawModeToggleVisibility(isVisible: true);
				if (!isStepOver)
				{
					SetNextMessageAnchoredToScreen(StringId.Tutorial_PromptToDeleteRoad_Touch, _tutorialConstants.UnanchoredMessageOffset);
				}
			})
				.AddIdleHint(new IdleHint().SetShowHintHandler((Action)delegate
				{
					_gameUI.drawModeToggle.Pulse();
				}))
				.StepRegressesWhen(() => !_camera.IsFocussedIn));
			_tutorial.AddStep(new TutorialStep("PromptToDeleteAllRoads").ClockTicksWhile(() => false).StepOverWhen(() => RoadCountIs(0)).WhenStepStarts(delegate(bool isStepOver)
			{
				if (!isStepOver)
				{
					SetNextMessageAnchoredToScreen(StringId.Tutorial_DeleteAllRoads, _tutorialConstants.UnanchoredMessageOffset);
				}
			})
				.StepRegressesWhen(() => _gameUI.CurrentRoadDrawMode != RoadDrawMode.Remove));
			_tutorial.AddStep(new TutorialStep("ShowHowToExitDrawMode").ClockTicksWhile(() => false).StepOverWhen(() => !_camera.IsFocussedIn).WhenStepStarts(delegate(bool isStepOver)
			{
				if (!isStepOver)
				{
					SetNextMessageAnchoredToScreen(StringId.Tutorial_TapExitBuildMode_Touch, _tutorialConstants.UnanchoredMessageOffset);
				}
			})
				.StepRegressesWhen(() => RoadCountGreaterThanOrEqualTo(1)));
		}

		private void AddEndStage()
		{
			_tutorial.AddRealtimeDelay(2f, clockTicks: false);
			_tutorial.StartStage("End", "E");
			_tutorial.AddMarker(TutorialMarker.BigPinsAllowed);
			_tutorial.AddStep(new TutorialStep("ScoreRequirementMessage").ClockTicksWhile(() => false).StepOverWhen(HadInputAndMessageSpentMinimumTime).WhenStepStarts((Action)delegate
			{
				_scoreToFinishTutorial = Mathf.RoundToInt((float)(_score.Score + _tutorialConstants.AdditionalScoreToGet) / (float)_tutorialConstants.AdditionalScoreToGetRounding) * _tutorialConstants.AdditionalScoreToGetRounding;
				PrepareForDismissibleMessage();
				SetNextMessageAnchoredToScreen(StringId.Tutorial_ScoretoComplete, _tutorialConstants.UnanchoredMessageOffset, CameraLayer.Default, force: false, _scoreToFinishTutorial);
			})
				.WhenStepEnds(RestorePlayerControl));
			AddGameEndWeeklyUpgradeScreen(6, UpgradeType.TrafficLight, 20, UpgradeType.Roundabout, 20);
			AddGameEndWeeklyUpgradeScreen(7, UpgradeType.Bridge, 20, UpgradeType.Roundabout, 20);
			AddGameEndWeeklyUpgradeScreen(8, UpgradeType.TrafficLight, 20, UpgradeType.Motorway, 10);
			_tutorial.AddStep(new TutorialStep("GameOverScreen_TutorialEnd").StepOverWhen(() => true).WhenStepStarts((Action)delegate
			{
				UnregisterActions();
				_inputState.Unsubscribe(this);
				_screenStack.PushScreen(ScreenStack.MotorwaysScreen.GameOver, delegate(GameOverScreen gameOverScreen)
				{
					DestinationView destinationView = _scope.Get<ViewIndex>().GetDestinationView(GetDestinationById(TutorialIdentifier.FirstDestination));
					gameOverScreen.focusPoint = destinationView.transform.position;
				}, additive: true, _scope);
			}));
		}

		private void AddGameEndWeeklyUpgradeScreen(int week, UpgradeType mainUpgrade, int mainConcrete, UpgradeType alternateUpgrade, int alternateConcrete)
		{
			_tutorial.AddStep(new TutorialStep("GameOverWeeekUpgrade_Week" + week).StepOverWhen(() => _clock.Week >= week || _score.Score >= _scoreToFinishTutorial).WhenStepEnds(delegate
			{
				if (_score.Score < _scoreToFinishTutorial)
				{
					SetNextUpgrades(mainUpgrade, mainConcrete, alternateUpgrade, alternateConcrete);
				}
			}));
			_tutorial.AddStep(new TutorialStep("AddFixedOrderPendingUpgrades").ClockTicksWhile(() => true).StepOverWhen(() => UpgradeScreenIsVisible() || _score.Score >= _scoreToFinishTutorial));
			_tutorial.AddStep(new TutorialStep("WaitForPlayerToChooseUpgrade").ClockTicksWhile(() => false).StepOverWhen(() => _upgradeDatabase.pendingUpgradeChoices.Count <= 0).WhenStepStarts((Action)delegate
			{
				if (_score.Score < _scoreToFinishTutorial)
				{
					SetNextMessageAnchoredToScreen(StringId.Tutorial_SecondUpgrade, _tutorialConstants.UpgradeScreenMessageOffset, CameraLayer.Overlay, force: true);
				}
			})
				.WhenStepEnds(delegate
				{
					if (_score.Score < _scoreToFinishTutorial)
					{
						ClearCurrentMessage();
					}
				}));
		}

		private void AddIntroduceClockStage()
		{
			_tutorial.AddStep(new TutorialStep("WaitBeforeMakingClockVisible").StepOverWhen(() => RequireTimePassed(2f)));
			_tutorial.AddStep(new TutorialStep("MakeClockVisible").ClockTicksWhile(() => true).WhenStepStarts((Action)delegate
			{
				_gameUI.SetClockVisibility(visible: true);
			}).StepOverWhen(() => RequireTimePassed(2f)));
			_tutorial.AddStep(new TutorialStep("ClockIntroMessage").ClockTicksWhile(() => true).WhenStepStarts((Action)delegate
			{
				SetNextMessageAnchoredToScreen(ClockStringId, _tutorialConstants.UnanchoredMessageOffset);
			}).StepOverWhen(() => _gameUI.TimeButtonsVisible)
				.AddIdleHint(new IdleHint().SetShowHintHandler((Action)delegate
				{
					_scope.Get<GameUIScreen>().PulseClock();
				})));
			_tutorial.AddStep(new TutorialStep("DelayAfterClockMessage").StepOverWhen(() => RequireTimePassed(5f)).ClockTicksWhile(() => true));
		}

		private void AddLearnBasicsStage()
		{
			_tutorial.StartStage("Learn Basics", "LB");
			_tutorial.AddStep(new TutorialStep("FirstHouse").ClockTicksWhile(() => true).StepOverWhen(() => HouseHasSpawned(TutorialIdentifier.FirstHouse)).WhenStepStarts((Action)delegate
			{
				SetAllInputBlocked(blocked: true);
			}));
			_tutorial.AddStep(new TutorialStep("FirstDestination").ClockTicksWhile(() => true).StepOverWhen(() => DestinationHasSpawned(TutorialIdentifier.FirstDestination)).WhenStepEnds(delegate
			{
				ShowNoConcreteErrorMessage = true;
				LimitGeneratedDemandForDestination(TutorialIdentifier.FirstDestination, 0);
			}));
			switch (_inputState.CurrentDeviceInputType)
			{
			case DeviceInputType.Touch:
				AddTouchSteps_LearnBasics();
				break;
			case DeviceInputType.Controller:
				AddControllerSteps_LearnBasics();
				break;
			case DeviceInputType.Remote:
				AddRemoteSteps_LearnBasics();
				break;
			default:
				AddMouseSteps_LearnBasics();
				break;
			}
			_tutorial.AddStep(new TutorialStep("DeleteReminder_Wait", "Wait for a bit before showing delete reminder.").ClockTicksWhile(() => _clock.Hour < 23).StepOverWhen(() => RequireHouseConnectedToDestination(TutorialIdentifier.FirstHouse, TutorialIdentifier.FirstDestination) || RequireTimePassed(2f)));
			_tutorial.AddStep(new TutorialStep("DeleteReminder", "Remind player how to delete if they have no concrete remaining for a time.").ClockTicksWhile(() => _clock.Hour < 23).StepOverWhen(() => RequireHouseConnectedToDestination(TutorialIdentifier.FirstHouse, TutorialIdentifier.FirstDestination)).WhenStepStarts(delegate(bool isStepOver)
			{
				if (!isStepOver)
				{
					SetNextMessageAnchoredToScreen(StringId.Tutorial_EarlyDeleteMode, _tutorialConstants.UnanchoredMessageOffset);
				}
			})
				.AddIdleHint(_connectHousesIdleMessage));
			_tutorial.AddStep(new TutorialStep("AddDemand", "Add single demand and delay for an hour").ClockTicksWhile(() => false).StepOverWhen(RealtimeTimerFinished).WhenStepStarts((Action)delegate
			{
				StartRealtimeTimer(4f);
				AddDemandToDestination(TutorialIdentifier.FirstDestination, 1);
				_simulation.IsPaused = true;
			}));
			_tutorial.AddStep(new TutorialStep("ExplainPin").ClockTicksWhile(() => false).StepOverWhen(HadInputAndMessageSpentMinimumTime).WhenStepStarts((Action)delegate
			{
				PrepareForDismissibleMessage();
				SetNextMessageAnchoredToScreen(StringId.Tutorial_DemandIntroduction_02, _tutorialConstants.UnanchoredMessageOffset);
				AddHighlightPositionIndicator(GetFirstDestinationPinPosition());
			})
				.WhenStepEnds(delegate
				{
					_simulation.IsPaused = false;
					RestorePlayerControl();
				}));
			_tutorial.AddStep(new TutorialStep("WaitForCar", "Waiting for car to reach destination.").ClockTicksWhile(() => false).StepOverWhen(() => _simulation.GetModels<DestinationModel>()[0].TotalDemand == 0).AddIdleHint(_connectHousesIdleMessage));
			_tutorial.AddStep(new TutorialStep("Score").ClockTicksWhile(() => false).StepOverWhen(HadInputAndMessageSpentMinimumTime).WhenStepStarts((Action)delegate
			{
				PrepareForDismissibleMessage();
				SetNextMessageAnchoredToScreen(StringId.Tutorial_ScoreIntroduction, _tutorialConstants.UnanchoredMessageOffset);
			})
				.WhenStepEnds(RestorePlayerControl)
				.AddIdleHint(new IdleHint().SetShowHintHandler((Action)delegate
				{
					_gameUI.ScoreButton.animator.SetTrigger(GameUIScreen.ScorePulseAnimatorTrigger);
				})));
			_tutorial.AddMarker(TutorialMarker.BasicsLearnt);
		}

		private void AddMouseSteps_LearnBasics()
		{
			_tutorial.AddStep(new TutorialStep("Connecting_Mouse", "Show how to connect house to destination.").ClockTicksWhile(() => _clock.Hour < 8).WhenStepStarts((Action)delegate
			{
				SetAllInputBlocked(blocked: false);
				_gameUI.SetUpgradeBarVisibility(visible: true);
			}).StepOverWhen(() => RequireHouseConnectedToDestination(TutorialIdentifier.FirstHouse, TutorialIdentifier.FirstDestination))
				.AddIdleHint(new IdleHint().SetDelayBeforeShowing(5f).SetShowHintHandler(delegate(Fix64 timestep)
				{
					DragIndicatorBetween(GetHouseById(TutorialIdentifier.FirstHouse), GetDestinationById(TutorialIdentifier.FirstDestination), timestep);
				}))
				.AddIdleHint(new IdleHint().AddCondition(() => _upgradeDatabase.HasUpgradeAvailable(UpgradeType.Concrete)).SetDelayBeforeShowing(10f).SetShowHintHandler((Action)delegate
				{
					SetNextMessageAnchoredToScreen(StringId.Tutorial_ConnectRoad_Mouse, _tutorialConstants.UnanchoredMessageOffset, CameraLayer.Default, force: true);
				})
					.SetHideHintHandler(delegate
					{
						ClearCurrentMessageIf(StringId.Tutorial_ConnectRoad_Mouse);
					})));
		}

		private void AddControllerSteps_LearnBasics()
		{
			_tutorial.AddStep(new TutorialStep("Connecting_Controller", "Show how to connect house to destination.").ClockTicksWhile(() => _clock.Hour < 8).WhenStepStarts((Action)delegate
			{
				SetAllInputBlocked(blocked: false);
				_gameUI.SetUpgradeBarVisibility(visible: true);
			}).StepOverWhen(() => RequireHouseConnectedToDestination(TutorialIdentifier.FirstHouse, TutorialIdentifier.FirstDestination))
				.AddIdleHint(new IdleHint().SetDelayBeforeShowing(5f).SetShowHintHandler(delegate(Fix64 timestep)
				{
					DragIndicatorBetween(GetHouseById(TutorialIdentifier.FirstHouse), GetDestinationById(TutorialIdentifier.FirstDestination), timestep);
				}))
				.AddIdleHint(new IdleHint().AddCondition(() => _upgradeDatabase.HasUpgradeAvailable(UpgradeType.Concrete)).SetDelayBeforeShowing(10f).SetShowHintHandler((Action)delegate
				{
					SetNextMessageAnchoredToScreen(GetDrawString(), _tutorialConstants.UnanchoredMessageOffset, CameraLayer.Default, force: true);
				})
					.SetHideHintHandler(delegate
					{
						ClearCurrentMessageIf(GetDrawString());
					})));
			StringId GetDrawString()
			{
				if (!_player.IsTapDrawEnabled)
				{
					return StringId.Tutorial_ConnectRoad_Controller;
				}
				return StringId.Tutorial_ConnectRoad_ControllerTap;
			}
		}

		private void AddRemoteSteps_LearnBasics()
		{
			_tutorial.AddStep(new TutorialStep("Connecting_Controller", "Show how to connect house to destination.").ClockTicksWhile(() => _clock.Hour < 8).WhenStepStarts((Action)delegate
			{
				SetAllInputBlocked(blocked: false);
				_gameUI.SetUpgradeBarVisibility(visible: true);
			}).StepOverWhen(() => RequireHouseConnectedToDestination(TutorialIdentifier.FirstHouse, TutorialIdentifier.FirstDestination))
				.AddIdleHint(new IdleHint().SetDelayBeforeShowing(5f).SetShowHintHandler(delegate(Fix64 timestep)
				{
					DragIndicatorBetween(GetHouseById(TutorialIdentifier.FirstHouse), GetDestinationById(TutorialIdentifier.FirstDestination), timestep);
				}))
				.AddIdleHint(new IdleHint().AddCondition(() => _upgradeDatabase.HasUpgradeAvailable(UpgradeType.Concrete)).SetDelayBeforeShowing(10f).SetShowHintHandler((Action)delegate
				{
					SetNextMessageAnchoredToScreen(StringId.Tutorial_ConnectRoad_Remote, _tutorialConstants.UnanchoredMessageOffset, CameraLayer.Default, force: true);
				})
					.SetHideHintHandler(delegate
					{
						ClearCurrentMessageIf(StringId.Tutorial_ConnectRoad_Remote);
					})));
		}

		private void AddTouchSteps_LearnBasics()
		{
			_gameUI.SetDrawButtonsHiddenByTutorial(hidden: false);
			_tutorial.AddStep(new TutorialStep("Connecting_Touch", "Show how to connect house to destination.").ClockTicksWhile(() => _clock.Hour < 8).WhenStepStarts((Action)delegate
			{
				SetAllInputBlocked(blocked: false);
				_gameUI.SetUpgradeBarVisibility(visible: true);
			}).StepOverWhen(() => RequireHouseConnectedToDestination(TutorialIdentifier.FirstHouse, TutorialIdentifier.FirstDestination))
				.AddIdleHint(new IdleHint().AddCondition(() => !_camera.IsFocussedIn).SetDelayBeforeShowing(10f).SetShowHintHandler(delegate(Fix64 timestep)
				{
					TouchEnterDrawModeIndicator(timestep);
					SetNextMessageAnchoredToScreen(StringId.Tutorial_TapEnterBuildMode_Touch, new Vector2(0f, 0.7f));
				})
					.SetHideHintHandler(delegate
					{
						ClearCurrentMessageIf(StringId.Tutorial_TapEnterBuildMode_Touch);
					}))
				.AddIdleHint(new IdleHint().AddCondition(() => _camera.IsFocussedIn).SetDelayBeforeShowing(5f).SetShowHintHandler(delegate(Fix64 timestep)
				{
					DragIndicatorBetween(GetHouseById(TutorialIdentifier.FirstHouse), GetDestinationById(TutorialIdentifier.FirstDestination), timestep);
				}))
				.AddIdleHint(new IdleHint().AddCondition(() => _camera.IsFocussedIn).AddCondition(() => _upgradeDatabase.HasUpgradeAvailable(UpgradeType.Concrete)).SetDelayBeforeShowing(15f)
					.SetShowHintHandler((Action)delegate
					{
						SetNextMessageAnchoredToScreen(StringId.Tutorial_ConnectRoad_Touch, _tutorialConstants.UnanchoredMessageOffset, CameraLayer.Default, force: true);
					})
					.SetHideHintHandler(delegate
					{
						ClearCurrentMessageIf(StringId.Tutorial_ConnectRoad_Touch);
					})));
		}

		private void AddLearnBasicsPracticeStage()
		{
			_tutorial.StartStage("LearnBasics_Practice", "LBP");
			_tutorial.AddStep(new TutorialStep("WaitForSecondHouseSpawn").ClockTicksWhile(() => true).StepOverWhen(() => HouseHasSpawned(TutorialIdentifier.SecondHouse)).WhenStepStarts((Action)delegate
			{
				UpgradePackageDefinition upgradePackage = new UpgradePackageDefinition
				{
					amount = 12,
					type = UpgradeType.Concrete
				};
				_upgradeDatabase.ApplyUpgradePackage(upgradePackage, freeUpgrade: true);
			}));
			_tutorial.AddStep(new TutorialStep("WaitTillSecondHouseConnected").ClockTicksWhile(() => false).StepOverWhen(() => RequireAllHousesAndDestinationsInGroupToBeConnected(0)).WhenStepEnds(delegate
			{
				SetTotalDemandOnDestination(TutorialIdentifier.FirstDestination, 3);
				LimitGeneratedDemandForDestination(TutorialIdentifier.FirstDestination, 3);
			})
				.AddIdleHint(_connectHousesIdleMessage));
			_tutorial.AddStep(new TutorialStep("WaitForAwkwardDrivewayHouseSpawn").ClockTicksWhile(() => true).StepOverWhen(() => HouseHasSpawned(TutorialIdentifier.AwkwardDrivewayHouse)));
			_tutorial.AddStep(new TutorialStep("WaitTillAwkwardDrivewayHouseRealigned").ClockTicksWhile(() => false).StepOverWhen(delegate
			{
				HouseModel houseById = GetHouseById(TutorialIdentifier.AwkwardDrivewayHouse);
				return (houseById != null && !houseById.tileModel.Tile.HasTwoLaneRoadInDirection(TileDirection.East)) ? true : false;
			}).WhenStepStarts((Action)delegate
			{
				SetNextMessageAnchoredToScreen(StringId.Tutorial_ReorientHouse, _tutorialConstants.UnanchoredMessageOffset);
			})
				.WhenStepEnds(delegate
				{
					SetTotalDemandOnDestination(TutorialIdentifier.FirstDestination, 3);
					LimitGeneratedDemandForDestination(TutorialIdentifier.FirstDestination, 3);
				})
				.AddIdleHint(new IdleHint().SetShowHintHandler(delegate(Fix64 timestep)
				{
					Vector3 housePosition = GetHousePosition(TutorialIdentifier.AwkwardDrivewayHouse);
					DragIndicatorBetween(housePosition, housePosition + new Vector3(0f, 4f), timestep);
				})));
			_tutorial.AddStep(new TutorialStep("WaitForAwkwardHouseConnected").ClockTicksWhile(() => false).StepOverWhen(() => RequireAllHousesAndDestinationsInGroupToBeConnected(0)).AddIdleHint(_connectHousesIdleMessage));
			_tutorial.AddStep(new TutorialStep("WaitForDiagonalHouseSpawn").ClockTicksWhile(() => true).StepOverWhen(() => HouseHasSpawned(TutorialIdentifier.DiagonalHouse)));
			_tutorial.AddStep(new TutorialStep("WaitTillDiagonalHouseConnected").ClockTicksWhile(() => false).StepOverWhen(() => RequireAllHousesAndDestinationsInGroupToBeConnected(0)).WhenStepEnds(delegate
			{
				SetTotalDemandOnDestination(TutorialIdentifier.FirstDestination, 4);
				RemoveMaximumGeneratedDemandLimitForDestination(TutorialIdentifier.FirstDestination);
			})
				.AddIdleHint(_connectHousesIdleMessage));
		}

		private void AddSecondColorStage()
		{
			_tutorial.StartStage("SecondColor", "SC");
			_tutorial.AddStep(new TutorialStep("WaitForNewColor").ClockTicksWhile(() => true).StepOverWhen(() => DestinationHasSpawned(TutorialIdentifier.SecondColorDestination) && HouseHasSpawned(TutorialIdentifier.SecondColorHouse)).WhenStepEnds(delegate
			{
				LimitGeneratedDemandForDestination(TutorialIdentifier.SecondColorDestination, 1);
				AddDemandToDestination(TutorialIdentifier.SecondColorDestination, 1);
			}));
			_tutorial.AddStep(new TutorialStep("WaitForVehicleToCollectDemand").ClockTicksWhile(() => false).StepOverWhen(() => DestinationDemandEquals(TutorialIdentifier.SecondColorDestination, 0)).WhenStepEnds(delegate
			{
				SetTotalDemandOnDestination(TutorialIdentifier.SecondColorDestination, 1);
			})
				.AddIdleHint(_connectHousesIdleMessage));
			_tutorial.AddMarker(TutorialMarker.DemandCollectedFromNewHouseColor);
			if (_inputState.CurrentDeviceInputType == DeviceInputType.Touch)
			{
				_tutorial.AddRealtimeDelay(15f, clockTicks: true);
				_tutorial.AddStep(new TutorialStep("TeachPan_Touch").ClockTicksWhile(() => false).StepOverWhen(() => _cameraView.IsPlayerPanning).WhenStepStarts((Action)delegate
				{
					SetNextMessageAnchoredToScreen(StringId.Tutorial_TouchTwoFingerPan_02, _tutorialConstants.UnanchoredMessageOffset);
				}));
			}
			Fix64 justBeforeWeek = (Fix64)139.16666666666669;
			_tutorial.AddStep(new TutorialStep("WaitForLastHouseToBeConnected").ClockTicksWhile(() => _clock.Time < justBeforeWeek).StepOverWhen(() => RequireHouseConnectedToDestinationWithSameGroup(TutorialIdentifier.LastHouseBeforeBridgeUpgrade)).WhenStepEnds(delegate
			{
				SetTotalDemandOnDestination(TutorialIdentifier.SecondColorDestination, 3);
			})
				.AddIdleHint(_connectHousesIdleMessage));
			_tutorial.AddStep(new TutorialStep("WaitBeforeUpgradeScreen").ClockTicksWhile(() => _clock.Time < justBeforeWeek).StepOverWhen(() => RequireTimePassed(20f)).StepRegressesWhen(() => !RequireHouseConnectedToDestinationWithSameGroup(TutorialIdentifier.LastHouseBeforeBridgeUpgrade))
				.AddIdleHint(_connectHousesIdleMessage));
		}

		private void AddSetupBigPinStage()
		{
			_tutorial.StartStage("Setup Big Pin", "SBP");
			_tutorial.AddMarker(TutorialMarker.BeganBigPinStage);
			_tutorial.AddStep(new TutorialStep("WaitForLastSpawnBeforeBigPin").StepOverWhen(() => HouseHasSpawned(TutorialIdentifier.LastHouseBeforeBigPin)));
		}

		private void AddSetupMotorwayStage()
		{
			_tutorial.StartStage("Setup Motorway", "SM");
			_tutorial.AddMarker(TutorialMarker.BeganMotorwayStage);
			_tutorial.AddStep(new TutorialStep("WaitForFirstHouseBeforeMotorwayToBeConnected").ClockTicksWhile(() => !HouseHasSpawnedAndHasDestinationToTravelTo(TutorialIdentifier.SetupMotorway_FirstHouse)).StepOverWhen(() => RequireHouseConnectedToDestinationWithSameGroup(TutorialIdentifier.SetupMotorway_FirstHouse)));
			Fix64 justBeforeWeek = (Fix64)419.1666666666667;
			_tutorial.AddStep(new TutorialStep("WaitForLastHouseToSpawn").ClockTicksWhile(() => _clock.Time < justBeforeWeek).StepOverWhen(() => HouseHasSpawned(TutorialIdentifier.SetupMotorway_LastHouse)).StepRegressesWhen(() => !RequireHouseConnectedToDestinationWithSameGroup(TutorialIdentifier.SetupMotorway_FirstHouse))
				.AddIdleHint(_connectHousesIdleMessage));
			_ = (Fix64)420.0;
			_tutorial.AddStep(new TutorialStep("GiveTimeToConnectHouses").ClockTicksWhile(() => _clock.Time < justBeforeWeek).StepOverWhen(() => RequireTimePassed(10f)).StepRegressesWhen(() => !RequireHouseConnectedToDestinationWithSameGroup(TutorialIdentifier.SetupMotorway_FirstHouse))
				.AddIdleHint(_connectHousesIdleMessage));
		}

		private void AddSetupRoundaboutStage()
		{
			_tutorial.StartStage("Setup Roundabout", "SR");
			_tutorial.AddMarker(TutorialMarker.BeganRoundaboutStage);
			_tutorial.AddStep(new TutorialStep("WaitForFirstHouseToBeConnected").ClockTicksWhile(() => !HouseHasSpawnedAndHasDestinationToTravelTo(TutorialIdentifier.SetupRoundabout_FirstHouse)).StepOverWhen(() => RequireHouseConnectedToDestinationWithSameGroup(TutorialIdentifier.SetupRoundabout_FirstHouse)).AddIdleHint(_connectHousesIdleMessage));
			Fix64 justBeforeWeek = (Fix64)559.1666666666667;
			_tutorial.AddStep(new TutorialStep("WaitForLastHouseToSpawn").ClockTicksWhile(() => _clock.Time < justBeforeWeek).StepOverWhen(() => HouseHasSpawned(TutorialIdentifier.SetupRoundabout_LastHouse)).StepRegressesWhen(() => !RequireHouseConnectedToDestinationWithSameGroup(TutorialIdentifier.SetupRoundabout_FirstHouse)));
			_tutorial.AddStep(new TutorialStep("GiveTimeToConnectHouses").ClockTicksWhile(() => _clock.Time < justBeforeWeek).StepOverWhen(() => RequireTimePassed(10f)).StepRegressesWhen(() => !RequireHouseConnectedToDestinationWithSameGroup(TutorialIdentifier.SetupRoundabout_FirstHouse)));
		}

		public Fix64 TimeAtStartOfWeek(int week)
		{
			return (Fix64)(week * 189);
		}

		private void AddSetupTrafficLightStage()
		{
			_tutorial.StartStage("Setup Traffic Light", "STL");
			_tutorial.AddMarker(TutorialMarker.BeganTrafficLightStage);
			_tutorial.AddStep(new TutorialStep("WaitForFirstHouseToBeConnected").ClockTicksWhile(() => !HouseHasSpawnedAndHasDestinationToTravelTo(TutorialIdentifier.SetupTrafficLight_FirstHouse)).StepOverWhen(() => RequireHouseConnectedToDestinationWithSameGroup(TutorialIdentifier.SetupTrafficLight_FirstHouse)).AddIdleHint(_connectHousesIdleMessage));
			if (FeatureToggle.IsFeatureEnabled(Feature.FTUX_Accessibility))
			{
				_tutorial.AddStep(new TutorialStep("DelayBeforeColorblindPrompt").ClockTicksWhile(() => true).StepOverWhen(() => RequireTimePassed(1f)));
				_tutorial.AddStep(new TutorialStep("ColorblindPrompt").ClockTicksWhile(() => false).WhenStepStarts((Action)delegate
				{
					if (!_player.IsColorblindModeEnabled)
					{
						_simulation.IsPaused = true;
						_currentPopup = _popups.PushConfirmationPopup<ConfirmationPopup>(StringId.ColorblindMode, delegate
						{
							_currentPopup = null;
						}, delegate
						{
							_currentPopup = null;
							_player.IsColorblindModeEnabled = true;
						}, StringId.FTUX_Accessibility_EnableColorblindModeDescription);
					}
				}).WhenStepEnds(delegate
				{
					_simulation.IsPaused = false;
				})
					.StepOverWhen(() => _currentPopup == null));
			}
			Fix64 justBeforeWeek = (Fix64)279.1666666666667;
			_tutorial.AddStep(new TutorialStep("WaitForLastHouseToSpawn").ClockTicksWhile(() => _clock.Time < justBeforeWeek).StepOverWhen(() => HouseHasSpawned(TutorialIdentifier.SetupTrafficLight_LastHouse)));
			_tutorial.AddStep(new TutorialStep("GiveTimeToConnectHouses").ClockTicksWhile(() => _clock.Time < justBeforeWeek).StepOverWhen(() => RequireTimePassed(10f)));
		}

		private void AddUpgradeBridgeStage()
		{
			_tutorial.StartStage("Upgrade Bridge (First Upgrade)", "BU");
			Fix64 startOfSecondWeek = (Fix64)140.0;
			_tutorial.AddMarker(TutorialMarker.BeganBridgeStage);
			_tutorial.AddStep(new TutorialStep("ExplainEndOfWeekScreen").ClockTicksWhile(() => false).StepOverWhen(() => HadInputAndMessageSpentMinimumTime()).WhenStepStarts((Action)delegate
			{
				PrepareForDismissibleMessage();
				SetNextMessageAnchoredToScreen(StringId.Tutorial_ExplainEndOfWeek, _tutorialConstants.UnanchoredMessageOffset, CameraLayer.Default, force: true);
			})
				.WhenStepEnds(RestorePlayerControl));
			_tutorial.AddStep(new TutorialStep("DelayBeforeUpgradeScreen").ClockTicksWhile(() => true).WhenStepStarts((Action)delegate
			{
				StartRealtimeTimer(3f);
			}).StepOverWhen(RealtimeTimerFinished));
			_tutorial.AddStep(new TutorialStep("AddFixedOrderPendingUpgrades").ClockTicksWhile(() => false).WhenStepStarts((Action)delegate
			{
				SetNextUpgrades(UpgradeType.Bridge, _tutorialConstants.DefaultConcreteForUpgradePair, UpgradeType.TrafficLight, _tutorialConstants.DefaultConcreteForUpgradePair, alternateOptionDisabled: true);
			}).StepOverWhen(UpgradeScreenIsVisible)
				.WhenStepEnds(delegate
				{
					SkipClockTo(startOfSecondWeek);
				}));
			_tutorial.AddStep(new TutorialStep("Realtime1SecondDelay").ClockTicksWhile(() => true).WhenStepStarts((Action)delegate
			{
				StartRealtimeTimer(1f);
			}).StepOverWhen(RealtimeTimerFinished));
			_tutorial.AddStep(new TutorialStep("AskPlayerToChooseBridge").ClockTicksWhile(() => true).StepOverWhen(() => _upgradeDatabase.pendingUpgradeChoices.Count <= 0).WhenStepStarts(delegate(bool isStepOver)
			{
				if (!isStepOver)
				{
					SetNextMessageAnchoredToScreen(StringId.Tutorial_ChooseTheBridge, _tutorialConstants.UpgradeScreenMessageOffset, CameraLayer.Overlay, force: true);
				}
			}));
			_tutorial.AddStep(new TutorialStep("WaitForHouseAcrossRiver").ClockTicksWhile(() => true).StepOverWhen(() => HouseHasSpawned(TutorialIdentifier.HouseAcrossRiver)));
			_tutorial.AddStep(new TutorialStep("ActionConnectHouseAcrossRiver").ClockTicksWhile(() => false).StepOverWhen(() => RequireExactUpgradeCount(UpgradeType.Bridge, 0) && RequireHouseConnectedToDestination(TutorialIdentifier.HouseAcrossRiver, TutorialIdentifier.SecondColorDestination)).WhenStepStarts((Action)delegate
			{
				_dragIndicatorTimer = Fix64.Zero;
			})
				.WhenStepEnds(delegate
				{
					SetTotalDemandOnDestination(TutorialIdentifier.SecondColorDestination, 5);
					RemoveMaximumGeneratedDemandLimitForDestination(TutorialIdentifier.SecondColorDestination);
				})
				.AddIdleHint(new IdleHint().SetDelayBeforeShowing(1f).SetShowHintHandler(delegate(Fix64 timestep)
				{
					DragIndicatorBetween(GetHouseById(TutorialIdentifier.HouseAcrossRiver), GetDestinationById(TutorialIdentifier.SecondColorDestination), timestep);
				}))
				.AddIdleHint(new IdleHint().SetDelayBeforeShowing(1f).SetShowHintHandler((Action)delegate
				{
					SetNextMessageAnchoredToScreen(StringId.Tutorial_DrawRoadAcrossWater, _tutorialConstants.UnanchoredMessageOffset, CameraLayer.Default, force: true);
				})));
		}

		private void AddUpgradeChoiceStage()
		{
			Fix64 startOfFifthWeek = (Fix64)700.0;
			_tutorial.AddStep(new TutorialStep("DelayBeforeUpgradeScreen").StepOverWhen(() => RequireTimePassed(20f)));
			_tutorial.AddMarker(TutorialMarker.BeganUpgradeChoiceStage);
			_tutorial.AddStep(new TutorialStep("ShowEndOfWeekScreen").ClockTicksWhile(() => false).StepOverWhen(UpgradeScreenIsVisible).WhenStepStarts((Action)delegate
			{
				SetNextUpgrades(UpgradeType.Bridge, 20, UpgradeType.Motorway, 10);
			})
				.WhenStepEnds(delegate
				{
					SkipClockTo(startOfFifthWeek);
				}));
			_tutorial.AddStep(new TutorialStep("ShowMessageAndWaitForPlayerToChooseUpgrade").ClockTicksWhile(() => false).StepOverWhen(() => _upgradeDatabase.pendingUpgradeChoices.Count <= 0).WhenStepStarts((Action)delegate
			{
				SetNextMessageAnchoredToScreen(StringId.Tutorial_SecondUpgrade, _tutorialConstants.UpgradeScreenMessageOffset, CameraLayer.Overlay, force: true);
			})
				.WhenStepEnds(ClearCurrentMessage));
		}

		private void AddUpgradeMotorwayStage()
		{
			_tutorial.StartStage("Upgrade Motorway", "UM");
			Fix64 startOfFourthWeek = (Fix64)420.0;
			_tutorial.AddStep(new TutorialStep("AddFixedOrderPendingUpgrades").ClockTicksWhile(() => false).WhenStepStarts((Action)delegate
			{
				SetNextUpgrades(UpgradeType.Motorway, _tutorialConstants.DefaultConcreteForUpgradePair, UpgradeType.Bridge, _tutorialConstants.DefaultConcreteForUpgradePair, alternateOptionDisabled: true);
			}).StepOverWhen(UpgradeScreenIsVisible)
				.WhenStepEnds(delegate
				{
					SkipClockTo(startOfFourthWeek);
				}));
			_tutorial.AddStep(new TutorialStep("AskPlayerToChooseMotorway").ClockTicksWhile(() => true).StepOverWhen(() => _upgradeDatabase.pendingUpgradeChoices.Count <= 0).WhenStepStarts(delegate(bool isStepOver)
			{
				if (!isStepOver)
				{
					SetNextMessageAnchoredToScreen(StringId.Tutorial_ChooseTheMotorway, _tutorialConstants.UpgradeScreenMessageOffset, CameraLayer.Overlay, force: true);
				}
			}));
			_tutorial.AddStep(new TutorialStep("WaitToTakeMotorway").ClockTicksWhile(() => false).StepOverWhen(() => RequireExactUpgradeCount(UpgradeType.Motorway, 0) || HasActiveAssetDragAction(GameUIButtonType.Motorway)).WhenStepStarts(delegate(bool isStepOver)
			{
				_scope.Get<NotificationView>().NotificationsEnabled = false;
				if (!isStepOver)
				{
					SetNextMessageAnchoredToScreen(StringId.Tutorial_Motorway_PlaceStart, _tutorialConstants.UnanchoredMessageOffset);
				}
			})
				.AddIdleHint(new IdleHint().SetShowHintHandler((Action)delegate
				{
					_gameUI.UpgradeBar.PulseUpgradeIcon(UpgradeType.Motorway);
				})));
			_tutorial.AddStep(new TutorialStep("TellPlayerHowToDragOutMotorway").ClockTicksWhile(() => false).StepOverWhen(HasPlacedMotorway).StepRegressesWhen(() => RequireExactUpgradeCount(UpgradeType.Motorway, 1))
				.WhenStepStarts(delegate(bool isStepOver)
				{
					if (!isStepOver)
					{
						SetNextMessageAnchoredToScreen(StringId.Tutorial_Motorway_PlaceEnd, _tutorialConstants.UnanchoredMessageOffset);
					}
				}));
			_tutorial.AddStep(new TutorialStep("GiveSomeTimeToEnsureConnected").ClockTicksWhile(() => true).WhenStepStarts((Action)delegate
			{
				StartRealtimeTimer(5f);
			}).StepOverWhen(() => RealtimeTimerFinished() || IsMotorwayConnectedToRoads()));
			_tutorial.AddStep(new TutorialStep("RequireTheMotorwayConnectedToEdges").ClockTicksWhile(() => false).StepOverWhen(IsMotorwayConnectedToRoads).StepRegressesWhen(() => RequireExactUpgradeCount(UpgradeType.Motorway, 1))
				.WhenStepStarts(delegate(bool isStepOver)
				{
					if (!isStepOver)
					{
						SetNextMessageAnchoredToScreen(StringId.Tutorial_Motorway_Roads, _tutorialConstants.UnanchoredMessageOffset);
					}
				})
				.WhenStepEnds(delegate
				{
					AddDemandToAllDestinations(1);
					SetTotalDemandOnDestination(TutorialIdentifier.UpgradeMotorway_Destination, 4);
					_scope.Get<NotificationView>().NotificationsEnabled = true;
				}));
			_tutorial.AddStep(new TutorialStep("WaitToSomeCarsToDriveOverMotorway").ClockTicksWhile(() => false).StepOverWhen(() => TripsOnMotorwaysGreaterThanOrEqualTo(3)).SetDebugText(() => $"# vehicles exited motorway: {_numberOfVehiclesThatHaveLeftAMotorway}/{3}"));
		}

		private void AddUpgradeRoundaboutStage()
		{
			_tutorial.StartStage("Upgrade Roundabout", "UR");
			Fix64 startOfWeekFive = (Fix64)560.0;
			_tutorial.AddStep(new TutorialStep("AddFixedOrderPendingUpgrades").ClockTicksWhile(() => false).WhenStepStarts((Action)delegate
			{
				SetNextUpgrades(UpgradeType.Roundabout, _tutorialConstants.DefaultConcreteForUpgradePair, UpgradeType.Bridge, _tutorialConstants.DefaultConcreteForUpgradePair, alternateOptionDisabled: true);
			}).StepOverWhen(UpgradeScreenIsVisible)
				.WhenStepEnds(delegate
				{
					SkipClockTo(startOfWeekFive);
				}));
			_tutorial.AddStep(new TutorialStep("AskPlayerToChooseRoundabout").ClockTicksWhile(() => false).StepOverWhen(() => _upgradeDatabase.pendingUpgradeChoices.Count <= 0).WhenStepStarts(delegate(bool isStepOver)
			{
				if (!isStepOver)
				{
					SetNextMessageAnchoredToScreen(StringId.Tutorial_ChooseTheRoundabout, _tutorialConstants.UpgradeScreenMessageOffset, CameraLayer.Overlay, force: true);
				}
			}));
			_tutorial.AddStep(new TutorialStep("WaitTillPlacedRoundabout").ClockTicksWhile(() => false).StepOverWhen(() => HasPlacedUpgrade(UpgradeType.Roundabout)).WhenStepStarts(delegate(bool isStepOver)
			{
				if (!isStepOver)
				{
					SetNextMessageAnchoredToScreen(StringId.Tutorial_DragRoundabout, _tutorialConstants.UnanchoredMessageOffset);
				}
			})
				.AddIdleHint(new IdleHint().SetShowHintHandler((Action)delegate
				{
					_gameUI.UpgradeBar.PulseUpgradeIcon(UpgradeType.Roundabout);
				})));
			_tutorial.AddStep(new TutorialStep("WaitToSomeCarsToDriveThroughRoundabout").ClockTicksWhile(() => false).StepOverWhen(() => TripsOnRoundaboutGreaterThanOrEqualTo(1)).SetDebugText(() => $"# vehicles exited roundabout: {_numberOfVehiclesThatHaveLeftARoundabout}/{1}")
				.StepRegressesWhen(() => RequireExactUpgradeCount(UpgradeType.Roundabout, 1))
				.AddIdleHint(new IdleHint().SetDelayBeforeShowing(40f).SetShowHintHandler((Action)delegate
				{
					SetNextMessageAnchoredToScreen(StringId.Tutorial_RoundaboutNoTripsHint, _tutorialConstants.UnanchoredMessageOffset);
				}).AddCondition(() => TripsOnRoundaboutGreaterThanOrEqualTo(0))));
		}

		private void AddUpgradeTrafficLightStage()
		{
			_tutorial.StartStage("Upgrade Traffic Light", "UTL");
			Fix64 startOfThirdWeek = (Fix64)280.0;
			_tutorial.AddStep(new TutorialStep("AddFixedOrderPendingUpgrades").ClockTicksWhile(() => false).WhenStepStarts((Action)delegate
			{
				SetNextUpgrades(UpgradeType.TrafficLight, _tutorialConstants.DefaultConcreteForUpgradePair, UpgradeType.Bridge, _tutorialConstants.DefaultConcreteForUpgradePair, alternateOptionDisabled: true);
			}).StepOverWhen(UpgradeScreenIsVisible)
				.WhenStepEnds(delegate
				{
					SkipClockTo(startOfThirdWeek);
				}));
			_tutorial.AddStep(new TutorialStep("AskPlayerToChooseTrafficLight").ClockTicksWhile(() => false).StepOverWhen(() => _upgradeDatabase.pendingUpgradeChoices.Count <= 0).WhenStepStarts(delegate(bool isStepOver)
			{
				if (!isStepOver)
				{
					SetNextMessageAnchoredToScreen(StringId.Tutorial_ChooseTheTrafficLight, _tutorialConstants.UpgradeScreenMessageOffset, CameraLayer.Overlay, force: true);
				}
			}));
			_tutorial.AddStep(new TutorialStep("Wait for traffic light to be taken.").ClockTicksWhile(() => false).StepOverWhen(() => RequireExactUpgradeCount(UpgradeType.TrafficLight, 0) || HasActiveAssetDragAction(GameUIButtonType.TrafficLight)).WhenStepStarts(delegate(bool isStepOver)
			{
				if (!isStepOver)
				{
					SetNextMessageAnchoredToScreen(StringId.Tutorial_TrafficLight_02, _tutorialConstants.UnanchoredMessageOffset);
				}
			})
				.AddIdleHint(new IdleHint().SetShowHintHandler((Action)delegate
				{
					_gameUI.UpgradeBar.PulseUpgradeIcon(UpgradeType.TrafficLight);
				})));
			Fix64 timeToPauseClock = (Fix64)285.0;
			_tutorial.AddStep(new TutorialStep("WaitForTrafficLightToBePlaced").ClockTicksWhile(() => _clock.Time < timeToPauseClock).StepOverWhen(HasPlacedTrafficLight).AddIdleHint(new IdleHint().SetShowHintHandler((Action)delegate
			{
				_gameUI.UpgradeBar.PulseUpgradeIcon(UpgradeType.TrafficLight);
			}))
				.WhenStepEnds(delegate
				{
					AddDemandToAllDestinations(2);
				}));
		}

		public void SetCurrentStage(string name, string shortName)
		{
			CurrentStage = name;
			CurrentStageShortName = shortName;
		}

		public void SetLastReachedMarker(TutorialMarker tutorialMarker)
		{
			LastReachedMarker = tutorialMarker;
		}

		private void Initialize()
		{
			_gameUI = _scope.Get<GameUIScreen>();
			_camera = _scope.Get<CameraView>();
			_gameUI.SetDrawButtonsHiddenByTutorial(hidden: true);
			_gameUI.SetDrawButtonsVisible(visible: false);
			_gameUI.SetTileHighlightsAllowed(allowed: false);
			_clockSpeedMultiplier = Fix64.Zero;
			_connectHousesIdleMessage = new IdleHint().SetDelayBeforeShowing(40f).SetShowHintHandler((Action)delegate
			{
				if (!HasVisibleMessage && !_connectHouseIdleMessageHasBeenDismissed)
				{
					PrepareForDismissibleMessage();
					AddMessageAnchoredToScreen(StringId.Tutorial_Error_UnconnectedHouses, _tutorialConstants.UnanchoredMessageOffset, CameraLayer.Default, null);
				}
				else if (!_connectHouseIdleMessageHasBeenDismissed && HasVisibleMessage && HadInputAndMessageSpentMinimumTime())
				{
					_connectHouseIdleMessageHasBeenDismissed = true;
					RestorePlayerControl();
					ClearCurrentMessageIf(StringId.Tutorial_Error_UnconnectedHouses);
				}
			}).SetProgressionHandler(delegate
			{
				_connectHouseIdleMessageHasBeenDismissed = false;
			});
			CreateStages();
			_inputState.Subscribe(this);
			RegisterActions();
			_player.SetNewContentSeen("NewControllerSchemePopup");
			_player.SetNewContentSeen("NewColorblindPopup");
		}

		public void Reset()
		{
			_gameUI = null;
			_camera = null;
			hadInput = false;
			_isInTutorial = false;
			_dragIndicatorTimer = Fix64.Zero;
			_rules = null;
			_clockSpeedMultiplier = Fix64Consts.Zero;
			_isProgressing = false;
			_currentStepIndex = 0;
			LastReachedMarker = TutorialMarker.InitialMarker;
			_timeSpentInStep = Fix64.Zero;
			_timeSpentNotProgressing = Fix64.Zero;
			_tutorial = null;
			_animatorViews.Clear();
			currentMessage = null;
			_nextMessage = null;
			_currentControllerPosition = default(Vector2Int);
			_controllerIsDrawingRoads = false;
			_unscaledMessageTimer = 0f;
			_skipTimeForDismissibleMessages = false;
			HasPlayerMothballedARoad = false;
			_tapIndexTimer = default(Fix64);
			_demandLimits.Clear();
			_numberOfVehiclesThatHaveLeftAMotorway = 0;
			_vehiclesOnMotorway.Clear();
			_numberOfVehiclesThatHaveLeftARoundabout = 0;
			_vehiclesOnRoundabout.Clear();
			_enteredDeleteMode = true;
			_exitedDeleteMode = true;
			_drawRoadHintAnimationTimer = Fix64.Zero;
			_hasShownAlternateDrawModeTogglePopup = false;
			_connectHousesIdleMessage = null;
			_scoreToFinishTutorial = 0;
			_roadCountAfterDrawStep = 0;
			_roadCountBeforeWaitUntilDeleteModeEnabled = 0;
			_concreteCountAtStartOfTutorial = 0;
			_connectHouseIdleMessageHasBeenDismissed = false;
			ShowNoConcreteErrorMessage = true;
		}

		private void CreateStages()
		{
			_tutorial = new TutorialBuilder(this);
			AddDrawDeleteStage();
			AddLearnBasicsStage();
			AddLearnBasicsPracticeStage();
			AddSecondColorStage();
			AddUpgradeBridgeStage();
			AddSetupTrafficLightStage();
			AddUpgradeTrafficLightStage();
			AddSetupMotorwayStage();
			AddUpgradeMotorwayStage();
			AddSetupRoundaboutStage();
			AddUpgradeRoundaboutStage();
			AddSetupBigPinStage();
			AddBigPinStage();
			AddUpgradeChoiceStage();
			AddIntroduceClockStage();
			AddEndStage();
		}

		public void Step(ISimulation simulation, Fix64 timestep)
		{
			if (_unscaledMessageTimer > 0f)
			{
				if (timestep == Fix64.Zero)
				{
					_unscaledMessageTimer -= Time.unscaledDeltaTime * (1f / (float)Simulation.DefaultTimestep);
				}
				else
				{
					_unscaledMessageTimer -= Time.unscaledDeltaTime * (1f / (float)timestep);
				}
			}
			if (!_isInTutorial && _rules != null)
			{
				return;
			}
			if (!_isInTutorial && _rules == null)
			{
				_rules = _city.Rules;
				_isInTutorial = _rules is TutorialGameRules;
				if (!_isInTutorial)
				{
					return;
				}
				Initialize();
				if (_currentStepIndex < _tutorial.Steps.Count)
				{
					TutorialStep tutorialStep = _tutorial.Steps[_currentStepIndex];
					tutorialStep.OnStepStart?.Invoke(tutorialStep.IsStepOver?.Invoke() ?? false);
				}
			}
			CheckForEnteringAndExitingDeleteMode();
			CheckIfVehicleLeftMotorway();
			CheckIfVehicleLeftRoundabout();
			_timeSpentInStep += timestep;
			if (_isProgressing && ClockSpeedMultiplier <= Fix64.One)
			{
				_clockSpeedMultiplier = Fix64.Clamp01(_clockSpeedMultiplier + timestep * ClockAccelerationMultiplier);
			}
			else if (!_isProgressing && ClockSpeedMultiplier >= Fix64.Zero)
			{
				_clockSpeedMultiplier = Fix64.Clamp01(_clockSpeedMultiplier - timestep * ClockDecelerationMultiplier);
			}
			if (_currentStepIndex < _tutorial.Steps.Count)
			{
				TutorialStep tutorialStep2 = _tutorial.Steps[_currentStepIndex];
				if (!_isProgressing)
				{
					_timeSpentNotProgressing += timestep;
				}
				_isProgressing = tutorialStep2.DoesClockTick();
				if (_timeSpentNotProgressing > DelayBeforeIdleMessage && tutorialStep2.IdleMessageAnimationHandler != null)
				{
					tutorialStep2.IdleMessageAnimationHandler(timestep);
				}
				else if (_timeSpentNotProgressing > DelayBeforeIdleAnimation)
				{
					tutorialStep2.IdlePromptAnimationHandler?.Invoke(timestep);
				}
				foreach (IdleHint idleHint in tutorialStep2.IdleHints)
				{
					bool flag = true;
					if (idleHint.ShowConditions != null)
					{
						foreach (Func<bool> showCondition in idleHint.ShowConditions)
						{
							flag &= showCondition();
						}
					}
					if (flag)
					{
						if (idleHint.idleTime <= idleHint.DelayBeforeShowing)
						{
							idleHint.idleTime += timestep;
						}
						else
						{
							idleHint.ShowHintHandler?.Invoke(timestep);
						}
					}
					else
					{
						idleHint.HideHintHandler?.Invoke();
						idleHint.idleTime = Fix64.Zero;
					}
				}
				if (Diagnostics.Verify(tutorialStep2.IsStepOver != null, "'{0}' must have a IsStepOver action", tutorialStep2.Id))
				{
					if (tutorialStep2.IsStepOver())
					{
						tutorialStep2.OnStepComplete?.Invoke();
						TransitionToStep(_currentStepIndex + 1);
					}
					else if (tutorialStep2.ShouldRegressStep != null && tutorialStep2.ShouldRegressStep())
					{
						TransitionToStep(_currentStepIndex - 1);
					}
				}
			}
			else
			{
				_isProgressing = true;
			}
			if (_nextMessage.HasValue)
			{
				MessageData value = _nextMessage.Value;
				if (value.force && HasVisibleMessage && !currentMessage.Message.Equals(value.messageString))
				{
					ClearCurrentMessage();
				}
				if (!HasVisibleMessage)
				{
					if (value.IsWorldAnchored)
					{
						AddMessageAnchoredToWorld(value.messageString, value.position, value.direction);
					}
					else if (value.IsUIAnchored)
					{
						AddMessageAnchoredToUI(value.messageString, value.uiAnchor, value.position);
					}
					else if (value.IsScreenAnchored)
					{
						AddMessageAnchoredToScreen(value.messageString, value.position, value.cameraLayer, value.intParameter);
					}
				}
			}
			CheckIfPlayerHasMothballedARoad(simulation);
			hadInput = false;
		}

		private void CheckForEnteringAndExitingDeleteMode()
		{
			if (_enteredDeleteMode && _exitedDeleteMode)
			{
				_enteredDeleteMode = _gameUI.CurrentRoadDrawMode == RoadDrawMode.Remove;
				_exitedDeleteMode = false;
			}
			switch (_previousRoadDrawMode)
			{
			case RoadDrawMode.Add:
				if (_gameUI.CurrentRoadDrawMode == RoadDrawMode.Remove)
				{
					_enteredDeleteMode = true;
				}
				break;
			case RoadDrawMode.Remove:
				if (_gameUI.CurrentRoadDrawMode == RoadDrawMode.Add)
				{
					_exitedDeleteMode = true;
				}
				break;
			}
			_previousRoadDrawMode = _gameUI.CurrentRoadDrawMode;
		}

		private void TransitionToStep(int newStepIndex)
		{
			foreach (IdleHint idleHint in _tutorial.Steps[_currentStepIndex].IdleHints)
			{
				idleHint.idleTime = Fix64.Zero;
				idleHint.StepProgressedHandler?.Invoke();
			}
			_timeSpentInStep = Fix64.Zero;
			_timeSpentNotProgressing = Fix64.Zero;
			_currentStepIndex = newStepIndex;
			ClearCurrentMessage();
			if (_currentStepIndex < _tutorial.Steps.Count)
			{
				TutorialStep tutorialStep = _tutorial.Steps[_currentStepIndex];
				if (tutorialStep.ShouldRegressStep != null && tutorialStep.ShouldRegressStep())
				{
					TransitionToStep(_currentStepIndex - 1);
				}
				else
				{
					tutorialStep.OnStepStart?.Invoke(tutorialStep.IsStepOver?.Invoke() ?? false);
				}
			}
		}

		private void CheckIfPlayerHasMothballedARoad(ISimulation simulation)
		{
			if (HasPlayerMothballedARoad)
			{
				return;
			}
			TilemapModel model = simulation.GetModel<TilemapModel>();
			ModelListEnumerator<TileModel> enumerator = simulation.GetModels<TileModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				TileModel current = enumerator.Current;
				TileDirectionBitfield twoLaneRoads = current.Tile.GetTwoLaneRoads(RoadState.Mothballed);
				if (twoLaneRoads.Count <= 0 || current.Tile.ContentType == TileContentType.House)
				{
					continue;
				}
				if (twoLaneRoads.Count == 1)
				{
					TileDirection direction = twoLaneRoads[0];
					Vector2Int adjacentCoordinates = TileUtilities.GetAdjacentCoordinates(current.Tile.Coordinates, direction);
					if (model.GetTileModel(adjacentCoordinates).Tile.ContentType == TileContentType.House)
					{
						continue;
					}
				}
				HasPlayerMothballedARoad = true;
				break;
			}
		}

		private bool HasPlacedUpgrade(UpgradeType upgradeType)
		{
			return upgradeType switch
			{
				UpgradeType.Bridge => _upgradeDatabase.GetUsedUpgradeCount(UpgradeType.Bridge) >= 1, 
				UpgradeType.Motorway => _simulation.GetModel<MotorwayModel>() != null, 
				UpgradeType.TrafficLight => _simulation.GetModel<TrafficLightModel>() != null, 
				UpgradeType.Roundabout => _upgradeDatabase.GetUsedUpgradeCount(UpgradeType.Roundabout) >= 1, 
				UpgradeType.Tunnel => _upgradeDatabase.GetUsedUpgradeCount(UpgradeType.Tunnel) >= 1, 
				_ => false, 
			};
		}

		private bool HasPlacedMotorway()
		{
			return _simulation.GetModel<MotorwayModel>() != null;
		}

		private bool IsMotorwayConnectedToRoads()
		{
			MotorwayModel model = _simulation.GetModel<MotorwayModel>();
			if (model != null && model.StartTile.Tile.GetTwoLaneRoadCount() >= 1)
			{
				return model.EndTile.Tile.GetTwoLaneRoadCount() >= 1;
			}
			return false;
		}

		private bool HasPlacedTrafficLight()
		{
			return _simulation.GetModel<TrafficLightModel>() != null;
		}

		public void SetControllerIsDrawingRoads(bool isDrawingRoad)
		{
			_controllerIsDrawingRoads = isDrawingRoad;
		}

		public void SetCurrentControllerCursor(Vector2Int position)
		{
			_currentControllerPosition = position;
		}

		public void ClearCurrentMessageIf(StringId stringId)
		{
			if (HasVisibleMessage && currentMessage.Message == stringId)
			{
				ClearCurrentMessage();
			}
		}

		public void ClearCurrentMessage()
		{
			if (HasVisibleMessage)
			{
				_simulation.RemoveModel(currentMessage);
				currentMessage = null;
				for (int i = 0; i < _animatorViews.Count; i++)
				{
					IndicatorAnimationView indicatorAnimationView = _animatorViews[i];
					IndicatorAnimationView.AnimationType animation = indicatorAnimationView.Animation;
					if (animation == IndicatorAnimationView.AnimationType.Highlight || animation == IndicatorAnimationView.AnimationType.Tap || animation == IndicatorAnimationView.AnimationType.Drag)
					{
						indicatorAnimationView.OnAnimationRelease();
						_viewClient.MarkViewForRemoval(indicatorAnimationView);
						_animatorViews.RemoveAt(i);
						i--;
					}
				}
			}
			_nextMessage = null;
		}

		public void TemporarilyHideMessage()
		{
			if (HasVisibleMessage)
			{
				_simulation.RemoveModel(currentMessage);
				currentMessage = null;
			}
		}

		private void SetNextMessageAnchoredToScreen(StringId messageString, Vector2 screenOffset, CameraLayer cameraLayer = CameraLayer.Default, bool force = false, int? intParameter = null)
		{
			_nextMessage = new MessageData(messageString, screenOffset, cameraLayer, force, intParameter);
		}

		private void AddMessageAnchoredToScreen(StringId messageString, Vector2 screenOffset, CameraLayer cameraLayer, int? intParameter)
		{
			if (!HasVisibleMessage)
			{
				AnchoredMessageModel anchoredMessageModel = _simulation.Scope.Get<AnchoredMessageModel>();
				anchoredMessageModel.InitializeWithScreenAnchor(messageString, screenOffset, cameraLayer, intParameter);
				if (_playerActionController.TutorialBlockInputFlag)
				{
					anchoredMessageModel.ShowDismissArrow = true;
				}
				_simulation.AddModel(anchoredMessageModel);
				currentMessage = anchoredMessageModel;
			}
		}

		private void SetNextMessageAnchoredToWorld(StringId messageString, Vector3 position, TileDirection direction = TileDirection.North, bool force = false)
		{
			_nextMessage = new MessageData(messageString, position, direction, force);
		}

		private void AddMessageAnchoredToWorld(StringId messageString, Vector3 position, TileDirection direction = TileDirection.North)
		{
			if (!HasVisibleMessage)
			{
				AnchoredMessageModel anchoredMessageModel = _simulation.Scope.Get<AnchoredMessageModel>();
				anchoredMessageModel.InitializeWithWorldAnchor(messageString, position, direction);
				if (_playerActionController.TutorialBlockInputFlag)
				{
					anchoredMessageModel.ShowDismissArrow = true;
				}
				_simulation.AddModel(anchoredMessageModel);
				currentMessage = anchoredMessageModel;
			}
		}

		private void SetNextMessageAnchoredToUI(StringId messageString, UIMessageAnchor uiMessageAnchor, Vector2? offsetParam = null)
		{
			Vector2 offset = offsetParam ?? new Vector2(0.5f, 0.5f);
			_nextMessage = new MessageData(messageString, uiMessageAnchor, offset);
		}

		private void AddMessageAnchoredToUI(StringId messageString, UIMessageAnchor uiMessageAnchor, Vector2? offsetParam = null)
		{
			Vector2 uiAnchorPivot = offsetParam ?? new Vector2(0.5f, 0.5f);
			if (!HasVisibleMessage)
			{
				AnchoredMessageModel anchoredMessageModel = _simulation.Scope.Get<AnchoredMessageModel>();
				anchoredMessageModel.InitializeWithUIAnchor(messageString, uiMessageAnchor, uiAnchorPivot);
				if (_playerActionController.TutorialBlockInputFlag)
				{
					anchoredMessageModel.ShowDismissArrow = true;
				}
				_simulation.AddModel(anchoredMessageModel);
				currentMessage = anchoredMessageModel;
			}
		}

		private void AddDemandToDestination(TutorialIdentifier identifier, int amount)
		{
			DestinationModel destinationById = GetDestinationById(identifier);
			if (destinationById != null)
			{
				for (int i = 0; i < amount; i++)
				{
					destinationById.unassignedDemand.Add(destinationById.GroupIndex);
				}
			}
		}

		private void SetTotalDemandOnDestination(TutorialIdentifier identifier, int amount)
		{
			DestinationModel destinationById = GetDestinationById(identifier);
			if (destinationById != null)
			{
				int num = Math.Max(amount - destinationById.TotalDemand, 0);
				for (int i = 0; i < num; i++)
				{
					destinationById.unassignedDemand.Add(destinationById.GroupIndex);
				}
			}
		}

		private void AddDemandToAllDestinations(int amount)
		{
			ModelListEnumerator<DestinationModel> enumerator = _simulation.GetModels<DestinationModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				DestinationModel current = enumerator.Current;
				for (int i = 0; i < amount; i++)
				{
					current.unassignedDemand.Add(current.GroupIndex);
				}
			}
		}

		private void TouchEnterDrawModeIndicator(Fix64 timestep)
		{
			DoTapIndicator(new Vector3(-22f, -4f), timestep);
		}

		private void SetNextUpgrades(UpgradeType mainOption, int mainConcrete, UpgradeType alternateOption, int alternateConcrete, bool alternateOptionDisabled = false)
		{
			_upgradeDatabase.AddPendingUpgradeChoice(new UpgradeChoice
			{
				choices = 
				{
					new UpgradePackageDefinition
					{
						type = mainOption,
						amount = 1,
						additionalConcrete = mainConcrete
					},
					new UpgradePackageDefinition
					{
						type = alternateOption,
						amount = 1,
						additionalConcrete = alternateConcrete
					}
				},
				disabledOptions = (alternateOptionDisabled ? DisabledUpgradeOptions.Option2 : DisabledUpgradeOptions.None)
			});
		}

		private IndicatorAnimationView AddDragIndicator(Vector3 start, Vector3 end)
		{
			IndicatorAnimationView indicatorAnimationView = _scope.Get<IndicatorAnimationView>();
			indicatorAnimationView.Initialize(IndicatorAnimationView.AnimationType.Drag, start, end);
			_viewClient.AddView(indicatorAnimationView);
			_animatorViews.Add(indicatorAnimationView);
			return indicatorAnimationView;
		}

		private void DoTapIndicator(Vector3 position, Fix64 timestep)
		{
			if (_tapIndexTimer <= Fix64.Zero)
			{
				if (_idleTapAnimationView != null)
				{
					_idleTapAnimationView.OnAnimationRelease();
					_viewClient.MarkViewForRemoval(_idleTapAnimationView);
					_animatorViews.Remove(_idleTapAnimationView);
				}
				_idleTapAnimationView = _simulation.Scope.Get<IndicatorAnimationView>();
				_idleTapAnimationView.Initialize(IndicatorAnimationView.AnimationType.Tap, position);
				_viewClient.AddView(_idleTapAnimationView);
				_animatorViews.Add(_idleTapAnimationView);
				_tapIndexTimer = Fix64Consts.One;
			}
			else
			{
				_tapIndexTimer -= timestep;
			}
		}

		private IndicatorAnimationView AddHighlightPositionIndicator(Vector3 position)
		{
			IndicatorAnimationView indicatorAnimationView = _simulation.Scope.Get<IndicatorAnimationView>();
			indicatorAnimationView.Initialize(IndicatorAnimationView.AnimationType.Highlight, position);
			_viewClient.AddView(indicatorAnimationView);
			_animatorViews.Add(indicatorAnimationView);
			return indicatorAnimationView;
		}

		private void DragIndicatorBetween(HouseModel houseModel, DestinationModel destinationModel, Fix64 timestep)
		{
			DragIndicatorBetween(GetHouseDrivewayPosition(houseModel), GetDestinationDrivewayPosition(destinationModel), timestep);
		}

		private void DragIndicatorBetween(Vector3 start, Vector3 end, Fix64 timestep)
		{
			if (_dragIndicatorTimer <= Fix64.Zero)
			{
				IndicatorAnimationView indicatorAnimationView = AddDragIndicator(start, end);
				_dragIndicatorTimer = indicatorAnimationView.Duration;
			}
			else
			{
				_dragIndicatorTimer -= timestep;
			}
		}

		private Vector3 GetHouseDrivewayPosition(HouseModel houseModel)
		{
			return (houseModel.tileModel.Coordinates + TileUtilities.GetVectorForDirection(houseModel.DrivewayLane.connection.output.direction)) * 2f;
		}

		private Vector3 GetFirstDestinationPinPosition()
		{
			DestinationModel destinationById = GetDestinationById(TutorialIdentifier.FirstDestination);
			DestinationView destinationView = _simulation.Scope.Get<ViewIndex>().GetDestinationView(destinationById);
			if (Diagnostics.Verify(destinationView != null))
			{
				return destinationView.GetPositionOfPin(0);
			}
			return Vector3.zero;
		}

		private Vector3 GetHousePosition(TutorialIdentifier identifier)
		{
			ModelList<HouseModel> models = _simulation.GetModels<HouseModel>();
			for (int i = 0; i < models.Count; i++)
			{
				if (models[i].TutorialIdentifier == identifier)
				{
					return GetHousePosition(i);
				}
			}
			return Vector3.zero;
		}

		private Vector3 GetHousePosition(int houseIndex)
		{
			ModelList<HouseModel> models = _simulation.GetModels<HouseModel>();
			houseIndex = Math.Min(houseIndex, models.Count - 1);
			if (houseIndex < 0)
			{
				return new Vector3(0f, 0f);
			}
			return new Vector3(models[houseIndex].tileModel.Coordinates.x, models[houseIndex].tileModel.Coordinates.y) * 2f + new Vector3(0.05f, 0.05f, 0f);
		}

		private Vector3 GetDestinationDrivewayPosition(DestinationModel destination)
		{
			if (destination.Carpark.entranceAtBottomRight)
			{
				return (destination.Carpark.BottomRightDrivewayTileCoordinates * 2).ToVector3() + new Vector3(0.5f, 0.5f);
			}
			return (destination.Carpark.TopLeftDrivewayTileCoordinates * 2).ToVector3() + new Vector3(0.05f, 0.05f);
		}

		private bool RequireHouseConnectedToDestinationWithSameGroup(TutorialIdentifier houseId)
		{
			HouseModel houseById = GetHouseById(houseId);
			if (houseById == null)
			{
				return false;
			}
			ModelListEnumerator<DestinationModel> enumerator = _simulation.GetModels<DestinationModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				DestinationModel current = enumerator.Current;
				if (current.GroupIndex == houseById.GroupIndex && _pathfinder.CreatePath(houseById.DrivewayLane, current.Carpark.entranceLanes, allowMothballedLaneUse: true) != null)
				{
					return true;
				}
			}
			return false;
		}

		private bool RequireHouseConnectedToDestination(TutorialIdentifier houseId, TutorialIdentifier destinationId)
		{
			HouseModel houseById = GetHouseById(houseId);
			DestinationModel destinationById = GetDestinationById(destinationId);
			if (destinationById == null || !destinationById.isActive || destinationById.Carpark == null || destinationById.Carpark.entranceLanes.Count == 0)
			{
				return false;
			}
			if (!Diagnostics.Verify(houseById.DrivewayLane != null, "HouseModel should always have a driveway."))
			{
				return false;
			}
			return _pathfinder.AreLanesConnected(houseById.DrivewayLane, destinationById.Carpark.entranceLanes, allowMothballedLaneUsage: true);
		}

		private bool RequireAllHousesAndDestinationsInGroupToBeConnected(int groupIndex)
		{
			bool flag = false;
			bool flag2 = false;
			ModelListEnumerator<DestinationModel> enumerator = _simulation.GetModels<DestinationModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				DestinationModel current = enumerator.Current;
				if (!current.isActive || current.Carpark == null || current.Carpark.entranceLanes.Count == 0 || current.GroupIndex != groupIndex)
				{
					continue;
				}
				flag = true;
				ModelListEnumerator<HouseModel> enumerator2 = _simulation.GetModels<HouseModel>().GetEnumerator();
				while (enumerator2.MoveNext())
				{
					HouseModel current2 = enumerator2.Current;
					if (current2.GroupIndex == groupIndex)
					{
						flag2 = true;
						if (Diagnostics.Verify(current2.DrivewayLane != null, "HouseModel should always have a driveway.") && !_pathfinder.AreLanesConnected(current2.DrivewayLane, current.Carpark.entranceLanes, allowMothballedLaneUsage: true))
						{
							return false;
						}
					}
				}
			}
			return flag && flag2;
		}

		private bool RoadCountIs(int requiredRoadCount)
		{
			return GetRoadCount() == requiredRoadCount;
		}

		private bool RoadCountGreaterThanOrEqualTo(int requiredRoadCount)
		{
			return GetRoadCount() >= requiredRoadCount;
		}

		private bool HouseHasSpawned(TutorialIdentifier identifier)
		{
			ModelListEnumerator<HouseModel> enumerator = _simulation.GetModels<HouseModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.TutorialIdentifier == identifier)
				{
					return true;
				}
			}
			return false;
		}

		private bool HouseHasSpawnedAndHasDestinationToTravelTo(TutorialIdentifier tutorialIdentifier)
		{
			HouseModel houseById = GetHouseById(tutorialIdentifier);
			if (houseById == null)
			{
				return false;
			}
			ModelListEnumerator<DestinationModel> enumerator = _simulation.GetModels<DestinationModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.GroupIndex == houseById.GroupIndex)
				{
					return true;
				}
			}
			return false;
		}

		private bool DestinationHasSpawned(TutorialIdentifier identifier)
		{
			ModelListEnumerator<DestinationModel> enumerator = _simulation.GetModels<DestinationModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.TutorialIdentifier == identifier)
				{
					return true;
				}
			}
			return false;
		}

		public int GetGeneratedDemandLimitForDestination(TutorialIdentifier identifier)
		{
			if (!_demandLimits.ContainsKey(identifier))
			{
				return -1;
			}
			return _demandLimits[identifier];
		}

		private void RemoveAllPerDestinationDemandLimits()
		{
			_demandLimits.Clear();
		}

		private void LimitGeneratedDemandForDestination(TutorialIdentifier identifier, int maxDemand)
		{
			if (Diagnostics.Verify(maxDemand >= 0, "Demand limit for destination must be >= 0"))
			{
				if (_demandLimits.ContainsKey(identifier))
				{
					_demandLimits[identifier] = maxDemand;
				}
				else
				{
					_demandLimits.Add(identifier, maxDemand);
				}
			}
		}

		private void RemoveMaximumGeneratedDemandLimitForDestination(TutorialIdentifier identifier)
		{
			if (_demandLimits.ContainsKey(identifier))
			{
				_demandLimits.Remove(identifier);
			}
		}

		private DestinationModel GetDestinationById(TutorialIdentifier identifier)
		{
			ModelListEnumerator<DestinationModel> enumerator = _simulation.GetModels<DestinationModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				DestinationModel current = enumerator.Current;
				if (current.TutorialIdentifier == identifier)
				{
					return current;
				}
			}
			Diagnostics.FailAssert($"Could not find destination with tutorial identifier: {identifier}");
			return null;
		}

		private bool DestinationDemandEquals(TutorialIdentifier identifier, int demand)
		{
			DestinationModel destinationById = GetDestinationById(identifier);
			if (destinationById != null && destinationById.TotalDemand == demand)
			{
				return true;
			}
			return false;
		}

		private HouseModel GetHouseById(TutorialIdentifier identifier)
		{
			ModelListEnumerator<HouseModel> enumerator = _simulation.GetModels<HouseModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				HouseModel current = enumerator.Current;
				if (current.TutorialIdentifier == identifier)
				{
					return current;
				}
			}
			return null;
		}

		public bool RequireTimePassed(float seconds)
		{
			return _timeSpentInStep >= (Fix64)seconds;
		}

		public void StartRealtimeTimer(float seconds)
		{
			_unscaledMessageTimer = seconds;
		}

		public bool RealtimeTimerFinished()
		{
			return _unscaledMessageTimer <= 0f;
		}

		private bool RequireExactUpgradeCount(UpgradeType upgrade, int numRequired)
		{
			return _upgradeDatabase.GetAvailableUpgradeCount(upgrade) == numRequired;
		}

		private bool HasActiveAssetDragAction(GameUIButtonType upgrade)
		{
			foreach (PlayerActionGroup activeGroup in _playerActionController.ActiveGroups)
			{
				if (activeGroup.InstigatingInputEvent is MotorwaysUIInputEvent motorwaysUIInputEvent && motorwaysUIInputEvent.UIButtonType == upgrade)
				{
					return true;
				}
			}
			return false;
		}

		private bool HadInputAndMessageSpentMinimumTime()
		{
			if (hadInput)
			{
				return _unscaledMessageTimer <= 0f;
			}
			return false;
		}

		private void RestorePlayerControl()
		{
			_playerActionController.TutorialBlockInputFlag = false;
		}

		private void PrepareForDismissibleMessage()
		{
			_playerActionController.TutorialBlockInputFlag = true;
			if (_skipTimeForDismissibleMessages)
			{
				_unscaledMessageTimer = 0f;
			}
			else
			{
				_unscaledMessageTimer = 2f;
			}
		}

		public static TutorialType TutorialTypeForInputType(DeviceInputType inputType)
		{
			switch (inputType)
			{
			case DeviceInputType.Mouse:
				return TutorialType.Desktop;
			case DeviceInputType.Remote:
			case DeviceInputType.Controller:
				return TutorialType.TV;
			case DeviceInputType.Touch:
				return TutorialType.Mobile;
			default:
				return TutorialType.None;
			}
		}

		public void OnReleasedFromScope(IScope scope)
		{
			_playerActionController.TutorialBlockInputFlag = false;
			UnregisterActions();
			if (_gameUI != null)
			{
				_gameUI.SetDrawButtonsHiddenByTutorial(hidden: false);
				_gameUI.SetTileHighlightsAllowed(allowed: true);
			}
			_inputState.Unsubscribe(this);
		}

		private void RegisterActions()
		{
			IScope toScope = _scope.ParentScope ?? _scope;
			_playerActionController.RegisterAction(InputEventFilter.CreateMouseEventFilter(19, InputEventButtonState.JustDown), AdvanceTutorialAction.Create, toScope, ignorePollingAxis: true);
			_playerActionController.RegisterAction(InputEventFilter.CreateMouseEventFilter(20, InputEventButtonState.JustDown), AdvanceTutorialAction.Create, toScope, ignorePollingAxis: true);
			_playerActionController.RegisterAction(InputEventFilter.CreateTouchEventFilter(0, InputEventButtonState.JustDown), AdvanceTutorialAction.Create, toScope, ignorePollingAxis: true);
			_playerActionController.RegisterAction(InputEventFilter.CreateKeyboardEventFilter(2, InputEventButtonState.JustDown), AdvanceTutorialAction.Create, toScope, ignorePollingAxis: true);
			_playerActionController.RegisterAction(InputEventFilter.CreateKeyboardEventFilter(16, InputEventButtonState.JustDown), AdvanceTutorialAction.Create, toScope, ignorePollingAxis: true);
			_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(17, InputEventButtonState.JustDown), AdvanceTutorialAction.Create, toScope, ignorePollingAxis: true);
			_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(18, InputEventButtonState.JustDown), AdvanceTutorialAction.Create, toScope, ignorePollingAxis: true);
			_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(2, InputEventButtonState.JustDown), AdvanceTutorialAction.Create, toScope, ignorePollingAxis: true);
			_playerActionController.RegisterAction(InputEventFilter.CreateGenericEventFilter(16, InputEventButtonState.JustDown), AdvanceTutorialAction.Create, toScope, ignorePollingAxis: true);
			_playerActionController.RegisterAction(InputEventFilter.CreateRemoteEventFilter(2, InputEventButtonState.JustDown), AdvanceTutorialAction.Create, toScope, ignorePollingAxis: true);
		}

		public void UnregisterActions()
		{
			_playerActionController.UnregisterAction<AdvanceTutorialAction>();
		}

		public void SkipTutorial()
		{
			_currentStepIndex = _tutorial.Steps.Count;
			UnregisterActions();
		}

		public void OnCurrentDeviceInputTypeChanged(DeviceInputType newInputType)
		{
			if (_currentStepIndex < _tutorial.Steps.Count)
			{
				UnregisterActions();
				int count = _tutorial.Steps.Count;
				Initialize();
				if (LastReachedMarker >= TutorialMarker.InputControlsTaught)
				{
					_currentStepIndex += _tutorial.Steps.Count - count;
				}
				else
				{
					ClearCurrentMessage();
					_currentStepIndex = 0;
				}
				_simulation.IsPaused = false;
				SetAllInputBlocked(blocked: false);
			}
		}

		public TutorialStep StageAt(int index)
		{
			if (_tutorial.Steps == null || _tutorial.Steps.Count <= 0 || index >= _tutorial.Steps.Count)
			{
				return null;
			}
			return _tutorial.Steps[index];
		}

		private void SkipClockTo(Fix64 justBeforeFirstWeek)
		{
			_clock.NextFrame.time = justBeforeFirstWeek;
			_clock.NextFrame.expansionTime = justBeforeFirstWeek;
		}

		private void CheckIfVehicleLeftRoundabout()
		{
			if (!HasPlacedUpgrade(UpgradeType.Roundabout))
			{
				return;
			}
			ModelListEnumerator<VehicleModel> enumerator = _simulation.GetModels<VehicleModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				VehicleModel current = enumerator.Current;
				if (!_vehiclesOnRoundabout.Contains(current))
				{
					RoadTileConnection connection = current.CurrentFrame.lane.connection;
					if (connection.input.type == RoadType.Roundabout && connection.output.type == RoadType.Roundabout)
					{
						_vehiclesOnRoundabout.Add(current);
					}
				}
			}
			for (int num = _vehiclesOnRoundabout.Count - 1; num >= 0; num--)
			{
				if (_vehiclesOnRoundabout[num].CurrentFrame.lane.connection.input.type != RoadType.Roundabout)
				{
					_numberOfVehiclesThatHaveLeftARoundabout++;
					_vehiclesOnRoundabout.RemoveAt(num);
				}
			}
		}

		private void CheckIfVehicleLeftMotorway()
		{
			if (!HasPlacedMotorway())
			{
				return;
			}
			ModelListEnumerator<VehicleModel> enumerator = _simulation.GetModels<VehicleModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				VehicleModel current = enumerator.Current;
				if (!_vehiclesOnMotorway.Contains(current))
				{
					RoadTileConnection connection = current.CurrentFrame.lane.connection;
					if (connection.input.type == RoadType.Motorway && connection.output.type == RoadType.Motorway)
					{
						_vehiclesOnMotorway.Add(current);
					}
				}
			}
			for (int num = _vehiclesOnMotorway.Count - 1; num >= 0; num--)
			{
				if (_vehiclesOnMotorway[num].CurrentFrame.lane.connection.input.type != RoadType.Motorway)
				{
					_numberOfVehiclesThatHaveLeftAMotorway++;
					_vehiclesOnMotorway.RemoveAt(num);
				}
			}
		}

		private bool TripsOnMotorwaysGreaterThanOrEqualTo(int tripCount)
		{
			return _numberOfVehiclesThatHaveLeftAMotorway >= tripCount;
		}

		private bool TripsOnRoundaboutGreaterThanOrEqualTo(int tripCount)
		{
			return _numberOfVehiclesThatHaveLeftARoundabout >= tripCount;
		}

		public void SetDrawModeToggleVisibility(bool isVisible)
		{
			_gameUI.SetDrawButtonsHiddenByTutorial(!isVisible);
			_gameUI.SetDrawButtonsVisible(isVisible);
		}

		public void SetAllInputBlocked(bool blocked)
		{
			_playerActionController.TutorialBlockInputFlag = blocked;
		}

		public int GetRoadCount()
		{
			int num = 0;
			ModelListEnumerator<TileModel> enumerator = _simulation.GetModels<TileModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				TileModel current = enumerator.Current;
				num += current.Tile.GetTwoLaneRoadCount();
			}
			if (num > 0)
			{
				return num / 2;
			}
			return 0;
		}

		public bool UpgradeScreenIsVisible()
		{
			return _screenStack.GetTopActiveScreenType() == ScreenStack.MotorwaysScreen.Upgrade;
		}
	}
}
