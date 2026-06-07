using System;
using Client;
using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Models;
using Motorways.Themes;
using Motorways.UI;
using Server;
using UnityEngine;
using UnityEngine.UI;

namespace Motorways.Views
{
	public class ScoreView : MonoBehaviour, IView, IReusable, IThemeComponent
	{
		public class Builder : IViewBuilder
		{
			public void CreateView(ViewClient client, ISimulation simulation, IModel model, Fix64 timestamp)
			{
				ScoreView scoreView = client.Scope.Get<ScoreView>();
				scoreView.Initialize(model as ScoreModel);
				client.AddView(scoreView);
			}
		}

		[Dependency]
		private IScope _scope;

		[Dependency]
		private City _city;

		[Dependency]
		private SimulationConstantsData _simulationConstantsData;

		[Dependency]
		private GameUIScreen _gameUIScreen;

		[Dependency]
		private ActivePlayer _player;

		[Dependency]
		private NotificationView _notificationView;

		[Dependency]
		private UpgradeDatabaseModel _upgradeDatabaseModel;

		public LocalizedTextUI scoreText;

		private ScoreModel _scoreModel;

		public const string EndlessMilestoneNci = "EndlessMilestoneFTUXMessage";

		private int _displayedScore = -1;

		private float _innerDesiredEndlessProgress;

		private float _outerDesiredEndlessProgress;

		public TouchButton scoreButton;

		public GameObject electiveUpgradeTicker;

		public Animator electiveUpgradeAnimator;

		public Image tickerMeshRenderer;

		private static readonly int InnerProgress = Shader.PropertyToID("_InnerProgress");

		private static readonly int OuterProgress = Shader.PropertyToID("_OuterProgress");

		private static readonly int OuterColor = Shader.PropertyToID("_OuterColor");

		private static readonly int InnerColor = Shader.PropertyToID("_InnerColor");

		public static readonly int UpgradeAvailableId = Animator.StringToHash("UpgradeAvailable");

		public static readonly int PlayerInterruptedId = Animator.StringToHash("PlayerInterrupted");

		[SerializeField]
		private ThemedMaterialType _tickerInnerColorType = ThemedMaterialType.DarkSecondary;

		[SerializeField]
		private ThemedMaterialType _tickerOuterColorType = ThemedMaterialType.Grey;

		[SerializeField]
		private float _innerTickerSpeed = 1f;

		[Tooltip("How much faster does the inner ticker go when the outer is complete?")]
		[SerializeField]
		private float _tickerCompleteSpeedMultiplier = 30f;

		[SerializeField]
		private float _outerTickerSpeed = 1f;

		[SerializeField]
		private FloatingElement _floatingElement;

		public ScoreModel ScoreModel
		{
			get
			{
				return _scoreModel;
			}
			set
			{
				_scoreModel = value;
			}
		}

		public FloatingElement FloatingElement => _floatingElement;

		public bool IsEfficiencyTickerVisuallyComplete => _innerDesiredEndlessProgress >= 1f;

		public event Action OnElectiveUpgradeButtonPressed;

		public event Action OnScoreButtonPressed;

		private void Initialize(ScoreModel scoreModel)
		{
			_scoreModel = scoreModel;
			SetupView();
		}

		public void SetupView()
		{
			electiveUpgradeTicker.SetActive(_city.Rules.ScoringMode == ScoringMode.EfficiencyMilestones);
			scoreButton.gameObject.SetActive(_city.Rules.ScoringMode == ScoringMode.Trips);
			if (_city.Rules.ScoringMode == ScoringMode.EfficiencyMilestones || _city.Rules.ScoringMode == ScoringMode.None)
			{
				scoreText.TextField.text = "";
			}
		}

		public void Reset()
		{
			_scoreModel = null;
			_displayedScore = -1;
			_innerDesiredEndlessProgress = 0f;
			_outerDesiredEndlessProgress = 0f;
			base.transform.localPosition = Vector3.zero;
			base.transform.localRotation = Quaternion.identity;
			base.transform.localScale = Vector3.one;
		}

		public TickResult Tick(TimeInterval timeInterval, float stepAlpha)
		{
			if (_city.Rules.ScoringMode == ScoringMode.Trips && _scoreModel.Score != _displayedScore)
			{
				_displayedScore = _scoreModel.Score;
				scoreText.LocString = StandaloneLocString.CreateLocalizedNumberString(_scope, _displayedScore);
			}
			if (_city.Rules.ScoringMode == ScoringMode.EfficiencyMilestones)
			{
				float num = (float)_scoreModel.EfficiencyScore;
				float num2 = (float)_city.Definition.GetEfficiencyMilestone(_scoreModel.CurrentEfficiencyMilestone, _simulationConstantsData.MilestoneIncreaseAfterPrecalculatedIntervals);
				float num3 = num / num2;
				if (_upgradeDatabaseModel.HasPendingUpgrades)
				{
					num3 = 1f;
				}
				if (num3 - _innerDesiredEndlessProgress > 0f)
				{
					float num4 = _innerTickerSpeed * timeInterval.ScaledDelta;
					if (_outerDesiredEndlessProgress >= 1f)
					{
						num4 *= _tickerCompleteSpeedMultiplier;
					}
					_innerDesiredEndlessProgress += num4;
				}
				else
				{
					_innerDesiredEndlessProgress = num3;
				}
				if (num3 - _outerDesiredEndlessProgress > 0f)
				{
					_outerDesiredEndlessProgress += _outerTickerSpeed * timeInterval.ScaledDelta;
				}
				else
				{
					_outerDesiredEndlessProgress = num3;
				}
				float value = ((_innerDesiredEndlessProgress >= 1f) ? 1.1f : _innerDesiredEndlessProgress);
				float value2 = ((_outerDesiredEndlessProgress >= 1f) ? 1.1f : _outerDesiredEndlessProgress);
				tickerMeshRenderer.material.SetFloat(InnerProgress, value);
				tickerMeshRenderer.material.SetFloat(OuterProgress, value2);
				if (IsEfficiencyTickerVisuallyComplete && !_player.HasSeenNewContent("EndlessMilestoneFTUXMessage"))
				{
					_notificationView.AddNotification(StringId.FTUX_Endless, 0f, () => _player.HasSeenNewContent("EndlessMilestoneFTUXMessage") || _scope.Get<ScreenStack>().GetTopActiveScreenType() != ScreenStack.MotorwaysScreen.InGame);
				}
				if (FeatureToggle.IsFeatureEnabled(Feature.EndlessEfficiencyText))
				{
					scoreText.TextField.text = $"{num:F2} / {num2}";
				}
			}
			return TickResult.ContinueTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}

		public void SetEfficiencyTickerAnimationsPaused(bool isPaused)
		{
			electiveUpgradeAnimator.speed = ((!isPaused) ? 1 : 0);
		}

		public void InitializeTheme(IThemeDatabase themeDatabase)
		{
		}

		public void ApplyTheme(ITheme theme)
		{
			if (theme is Theme theme2)
			{
				tickerMeshRenderer.material.SetColor(OuterColor, theme2.GetColor(_tickerOuterColorType));
				tickerMeshRenderer.material.SetColor(InnerColor, theme2.GetColor(_tickerInnerColorType));
			}
		}

		public ThemeBlendingResult ApplyBlendedTheme(ITheme oldTheme, ITheme newTheme, float progress)
		{
			Theme obj = oldTheme as Theme;
			Theme theme = oldTheme as Theme;
			Color color = obj.GetColor(_tickerOuterColorType);
			Color color2 = theme.GetColor(_tickerOuterColorType);
			tickerMeshRenderer.material.SetColor(OuterColor, Color.Lerp(color, color2, progress));
			color = obj.GetColor(_tickerInnerColorType);
			color2 = theme.GetColor(_tickerInnerColorType);
			tickerMeshRenderer.material.SetColor(InnerColor, Color.Lerp(color, color2, progress));
			if (!(color == color2))
			{
				return ThemeBlendingResult.ContinueBlending;
			}
			return ThemeBlendingResult.StopBlending;
		}

		public void ReleaseTheme(IThemeDatabase themeDatabase)
		{
		}

		public void ElectiveUpgradeButtonPressed()
		{
			this.OnElectiveUpgradeButtonPressed?.Invoke();
		}

		public void ScoreButtonPressed()
		{
			this.OnScoreButtonPressed?.Invoke();
		}
	}
}
