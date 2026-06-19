using I2.Loc;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class HoverMenuHospitalPlot : HoverMenuRoomBase
	{
		[SerializeField]
		private TMP_Text _name;

		[SerializeField]
		private TMP_Text _costText;

		[SerializeField]
		private TMP_Text _challengeDescription;

		[SerializeField]
		private Color _daysRemainingColor = Color.white;

		[SerializeField]
		private Color _affordableColor = Color.white;

		[SerializeField]
		private Color _unaffordableColor = Color.red;

		private HospitalPlot _plot;

		private ObjectiveDefinition _plotChallenge;

		public override void Setup(Room room, Level level)
		{
			base.Setup(room, level);
			_plot = level.WorldState.GetHospitalPlotFromRoom(_room);
			_plotChallenge = (_plot.Definition.BuildObjective.NotNull() ? _plot.Definition.BuildObjective.Instance : null);
			if (_plot.Definition.BuildObjective.IsNull())
			{
				_name.text = _plot.Definition.NameLocalised.Translation;
			}
			else
			{
				_name.text = _plotChallenge.NameLocalised.Translation;
			}
			Update();
		}

		protected override void Update()
		{
			base.Update();
			if (_plot.Building)
			{
				int num = (int)(_plot.TimeLeftToBuild / GameAlgorithms.Config.SecondsPerDay) + 1;
				_costText.text = ScriptLocalization.Menu.Hover_HospitalPlot_DaysLeft_CS.Replace("{[DAYS]}", num.ToString());
				_costText.color = _daysRemainingColor;
				GameObjectUtils.SetActive(_costText.gameObject, isActive: true);
				GameObjectUtils.SetActive(_challengeDescription.gameObject, isActive: false);
				return;
			}
			if (_plot.Definition.BuildObjective.IsNull())
			{
				if (_plot.Bought && _plot.Definition.UseEnergyUI)
				{
					GameObjectUtils.SetActive(_costText.gameObject, isActive: false);
				}
				else
				{
					_costText.text = StringUtils.FormatCurrency(_plot.Definition.Cost);
					_costText.color = (base.Level.FinanceManager.CanAfford(_plot.Definition.Cost) ? _affordableColor : _unaffordableColor);
					GameObjectUtils.SetActive(_costText.gameObject, isActive: true);
				}
				GameObjectUtils.SetActive(_challengeDescription.gameObject, isActive: false);
				return;
			}
			string text = string.Empty;
			foreach (SubGoalDefinition subGoalDefinition in _plotChallenge.SubGoalDefinitions)
			{
				if (!text.IsNullOrEmpty())
				{
					text += "\n";
				}
				text += subGoalDefinition.GoalText(null);
			}
			_challengeDescription.text = text;
			GameObjectUtils.SetActive(_costText.gameObject, isActive: false);
			GameObjectUtils.SetActive(_challengeDescription.gameObject, isActive: true);
		}
	}
}
