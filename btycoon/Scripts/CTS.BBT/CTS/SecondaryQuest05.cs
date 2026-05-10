using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class SecondaryQuest05 : SecondaryQuest
	{
		private ResearchPointGainGoal _researchPointGoal;

		[SerializeField]
		private int _targetResearchPointValue;

		[SerializeField]
		[QuestEntryPopup]
		private int _researchPointEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _targetResearchPoint;

		[SerializeField]
		[VariablePopup(false)]
		private string _researchPoint;

		[SerializeField]
		private LocalizedString _bark01;

		private ResearchPointSellGoal _pointSellGoal;

		[SerializeField]
		private int _targetpointSellValue;

		[SerializeField]
		[QuestEntryPopup]
		private int _pointSellEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _targetpointSell;

		[SerializeField]
		[VariablePopup(false)]
		private string _pointSell;

		[SerializeField]
		private LocalizedString _bark02;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_researchPoint);
			ResetVariableTo0(_pointSell);
		}

		protected override void StopObservingObjectives()
		{
			_researchPointGoal?.CleanStopObserving();
			_pointSellGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_targetResearchPoint, _targetResearchPointValue);
			DialogueLua.SetVariable(_targetpointSell, _targetpointSellValue);
			_researchPointGoal = new ResearchPointGainGoal(this, _researchPointEntry, _researchPoint, _targetResearchPoint);
			_researchPointGoal?.StartObserving(delegate
			{
				Barks.BarkAnyWorker(_bark01);
			});
			_pointSellGoal = new ResearchPointSellGoal(this, _pointSellEntry, _pointSell, _targetpointSell);
			_pointSellGoal?.StartObserving(delegate
			{
				Barks.BarkAnyWorker(_bark02);
			});
		}
	}
}
