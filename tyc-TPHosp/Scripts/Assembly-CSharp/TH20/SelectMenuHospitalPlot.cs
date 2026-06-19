using I2.Loc;
using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SelectMenuHospitalPlot : SelectMenuRoomBase
	{
		private HospitalPlot _plot;

		[SerializeField]
		private GameObject _buildingPanel;

		[SerializeField]
		private TMP_Text _nameBuilding;

		[SerializeField]
		private TMP_Text _timeToBuild;

		[SerializeField]
		private GameObject _buyPanel;

		[SerializeField]
		private DynamicButton _buyButton;

		[SerializeField]
		private TMP_Text _nameBuy;

		[SerializeField]
		private TMP_Text _info;

		[SerializeField]
		private TMP_Text _cost;

		[SerializeField]
		private TMP_Text _prerequisites;

		[SerializeField]
		private Color _affordableColor = Color.white;

		[SerializeField]
		private Color _unaffordableColor = Color.red;

		[SerializeField]
		private GameObject _challengePanel;

		[SerializeField]
		private DynamicButton _startChallengeButton;

		[SerializeField]
		private TMP_Text _challengeTitle;

		[SerializeField]
		private TMP_Text _challengeDescription;

		[SerializeField]
		private GameObject _energyPanel;

		[SerializeField]
		private TMP_Text _energyNameText;

		[SerializeField]
		private TMP_Text _energyCostText;

		[SerializeField]
		private TMP_Text _energyGeneratedText;

		[SerializeField]
		private DynamicButton _energybuyButton;

		private GameObject _assignedBuyPanel;

		private TMP_Text _assignedCostText;

		private DynamicButton _assignedBuyButton;

		private TMP_Text _assignedNameText;

		private ObjectiveDefinition _plotChallenge;

		public override void Setup(Room room, Level level)
		{
			base.Setup(room, level);
			_plot = level.WorldState.GetHospitalPlotFromRoom(room);
			_plotChallenge = (_plot.Definition.BuildObjective.NotNull() ? _plot.Definition.BuildObjective.Instance : null);
			_assignedBuyPanel = _buyPanel;
			_assignedCostText = _cost;
			_assignedBuyButton = _buyButton;
			_assignedNameText = _nameBuy;
			if (_plotChallenge != null)
			{
				if (IsPlotChallengeAvailable())
				{
					_startChallengeButton.onPrimaryDown.AddListener(StartChallengePressed);
				}
				else
				{
					_startChallengeButton.interactable = false;
					ButtonAnimator componentInChildren = _startChallengeButton.GetComponentInChildren<ButtonAnimator>();
					if (componentInChildren != null)
					{
						componentInChildren.CurrentState = ButtonAnimator.State.Unselectable;
					}
				}
				bool flag = base.Level.LevelScriptManager.IsObjectiveActive(_plotChallenge);
				GameObjectUtils.SetActive(_startChallengeButton.gameObject, !flag);
			}
			if (_energyPanel != null && _plot != null && _plot.Definition.UseEnergyUI)
			{
				GameObjectUtils.SetActive(_energyPanel, isActive: true);
				GameObjectUtils.SetActive(_buyPanel, isActive: false);
				_assignedBuyPanel = _energyPanel;
				_assignedCostText = _energyCostText;
				_assignedBuyButton = _energybuyButton;
				_assignedNameText = _energyNameText;
				if (_energyGeneratedText != null)
				{
					_energyGeneratedText.text = StringUtils.FormatInteger(_plot.Definition.EnergyUnitsGenerated, prefixPlus: true);
				}
				_energybuyButton.onPrimaryDown.AddListener(BuyButtonPressed);
			}
			else
			{
				_buyButton.onPrimaryDown.AddListener(BuyButtonPressed);
			}
			Update();
		}

		private bool IsPlotChallengeAvailable()
		{
			if (!_plot.Definition.Available(base.Level))
			{
				return false;
			}
			if (base.Level.LevelScriptManager.IsObjectiveActive(_plotChallenge))
			{
				return false;
			}
			int num = 0;
			foreach (HospitalPlot hospitalPlot in base.Level.WorldState.HospitalPlots)
			{
				if (hospitalPlot.ChallengeActive)
				{
					num++;
				}
			}
			return num < GameAlgorithms.Config.MaxPlotChallenges;
		}

		public override void CloseMenu()
		{
			base.CloseMenu();
			base.Level.HospitalHUDManager.ShowHospitalFootprint(null);
		}

		protected override void Update()
		{
			base.Update();
			if (_plot.HospitalMap == null)
			{
				CloseMenu();
				return;
			}
			if (_plot.Building)
			{
				int num = (int)(_plot.TimeLeftToBuild / GameAlgorithms.Config.SecondsPerDay) + 1;
				_nameBuilding.text = _plot.Definition.NameLocalised.Translation;
				_timeToBuild.text = ScriptLocalization.Menu.Hover_HospitalPlot_DaysLeft_CS.Replace("{[DAYS]}", num.ToString());
				GameObjectUtils.SetActive(_assignedBuyPanel, isActive: false);
				GameObjectUtils.SetActive(_buildingPanel, isActive: true);
				GameObjectUtils.SetActive(_challengePanel, isActive: false);
			}
			else
			{
				bool flag = _plot.Definition.Available(base.Level);
				bool flag2 = false;
				if (!_plot.Definition.BuildObjective.IsNull())
				{
					foreach (SubGoalDefinition subGoalDefinition in _plot.Definition.BuildObjective.Instance.SubGoalDefinitions)
					{
						if (subGoalDefinition is SubGoalDefinitionReachWaveObjectivesHordeWave)
						{
							flag2 = true;
							break;
						}
					}
				}
				if (_plot.Definition.BuildObjective.IsNull() || (base.Level.IsSandbox() && flag2))
				{
					int num2 = _plot.HospitalMap.FloorPlan.TileCount * MathUtils.Square(2);
					int num3 = (int)(_plot.Definition.TimeToBuild / GameAlgorithms.Config.SecondsPerDay) + 1;
					bool flag3 = base.Level.FinanceManager.CanAfford(_plot.Definition.Cost);
					_assignedNameText.text = _plot.Definition.NameLocalised.Translation;
					string select_HospitalPlot_CS = ScriptLocalization.Menu.Select_HospitalPlot_CS;
					select_HospitalPlot_CS = select_HospitalPlot_CS.Replace("{[DAYS]}", num3.ToString());
					select_HospitalPlot_CS = select_HospitalPlot_CS.Replace("{[SIZE]}", num2.ToString());
					_info.text = select_HospitalPlot_CS;
					_assignedCostText.text = StringUtils.FormatCurrency(_plot.Definition.Cost);
					_assignedCostText.color = (flag3 ? _affordableColor : _unaffordableColor);
					_prerequisites.text = ((!flag) ? _plot.Definition.GetPrerequisiteText() : "");
					_prerequisites.color = (flag ? _affordableColor : _unaffordableColor);
					GameObjectUtils.SetActive(_assignedBuyPanel, isActive: true);
					GameObjectUtils.SetActive(_buildingPanel, isActive: false);
					GameObjectUtils.SetActive(_challengePanel, isActive: false);
					GameObjectUtils.SetInteractable(_assignedBuyButton, flag && flag3);
				}
				else
				{
					string text = string.Empty;
					if (!flag)
					{
						text = _plot.Definition.GetPrerequisiteText();
					}
					else
					{
						foreach (SubGoalDefinition subGoalDefinition2 in _plotChallenge.SubGoalDefinitions)
						{
							if (!text.IsNullOrEmpty())
							{
								text += "\n";
							}
							text += subGoalDefinition2.GoalText(null);
						}
					}
					_challengeTitle.text = _plotChallenge.NameLocalised.Translation;
					_challengeDescription.text = text;
					_challengeDescription.color = (flag ? _affordableColor : _unaffordableColor);
					GameObjectUtils.SetActive(_assignedBuyPanel, isActive: false);
					GameObjectUtils.SetActive(_buildingPanel, isActive: false);
					GameObjectUtils.SetActive(_challengePanel, isActive: true);
				}
			}
			if (!IsClosing())
			{
				base.Level.HospitalHUDManager.ShowHospitalFootprint(_plot);
			}
		}

		private void BuyButtonPressed()
		{
			_plot.Buy();
			CloseMenu();
		}

		private void StartChallengePressed()
		{
			_plot.StartChallenge();
			CloseMenu();
		}
	}
}
