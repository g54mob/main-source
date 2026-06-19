using I2.Loc;
using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class IllnessesMenu2Row : IllnessesMenu2RowBase
	{
		[SerializeField]
		private Button _rowButton;

		[SerializeField]
		private TMP_Text _illnessText;

		[SerializeField]
		private TMP_Text _treatmentCostText;

		[SerializeField]
		private TooltipSpawner _illnessTooltip;

		[Header("TreatmentCost")]
		[SerializeField]
		private IntCellComparable _treatmentCostCellComparable;

		[Header("TreatmentRoom")]
		[SerializeField]
		private IntCellComparable _treatmentRoomIconCellComparable;

		[SerializeField]
		private Image _treatmentRoomIcon;

		[SerializeField]
		private TooltipSpawner _treatmentRoomIconTooltip;

		[Header("Reputation")]
		[SerializeField]
		private ProgressBarMaskable _reputationProgressBarMaskable;

		[SerializeField]
		private TooltipSpawner _reputationTooltip;

		[Header("TreamtentRateCount")]
		[SerializeField]
		private IntCellComparable _treatmentRateCellComparable;

		[SerializeField]
		private TMP_Text _treatmentRateText;

		[Header("CureCount")]
		[SerializeField]
		private IntCellComparable _cureCountCellComparable;

		[SerializeField]
		private TMP_Text _cureCountText;

		[Header("IneffectiveCount")]
		[SerializeField]
		private IntCellComparable _ineffectiveCountCellComparable;

		[SerializeField]
		private TMP_Text _ineffectiveCountText;

		[Header("FatalCount")]
		[SerializeField]
		private IntCellComparable _fatalCountCellComparable;

		[SerializeField]
		private TMP_Text _fatalCountText;

		[Header("RageQuit")]
		[SerializeField]
		private IntCellComparable _rageQuitCountCellComparable;

		[SerializeField]
		private TMP_Text _rageQuitCountText;

		[Header("RowHighlight")]
		[SerializeField]
		protected Image _rowBackground;

		[SerializeField]
		protected Sprite _rowAlternateBackground;

		private ResearchManager _researchManager;

		private GameplayStatsTracker _gameplayStatsTracker;

		private ReputationTracker _reputationTracker;

		private FinanceManager _financeManager;

		public IllnessDefinition illness { get; private set; }

		public void Setup(IllnessDefinition illnessDefinition, ResearchManager researchManager, GameplayStatsTracker gameplayStatsTracker, ReputationTracker reputationTracker, FinanceManager financeManager)
		{
			_researchManager = researchManager;
			_gameplayStatsTracker = gameplayStatsTracker;
			_reputationTracker = reputationTracker;
			_financeManager = financeManager;
			illness = illnessDefinition;
			if (_illnessTooltip != null)
			{
				_illnessTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					tooltip.Text = $"<b>{illness.Name.Translation}</b>\n{illness.Description.Translation}";
				});
			}
			if (_reputationTooltip != null)
			{
				_reputationTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					tooltip.Text = string.Format(ScriptLocalization.Inspector.Stat_IllnessReputation_CS, StringUtils.FormatPercentageValue(_reputationTracker.GetIllnessReputation(illness)));
				});
			}
			if (_treatmentRoomIconTooltip != null)
			{
				_treatmentRoomIconTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					RoomDefinition treatmentRoom = illness.GetTreatmentRoom(null, _researchManager);
					if (treatmentRoom != null)
					{
						tooltip.Text = treatmentRoom.GetLocalisedName();
					}
				});
			}
			Refresh();
		}

		public void Refresh()
		{
			if (_illnessText != null && _illnessText.text != illness.Name.Translation)
			{
				_illnessText.text = illness.Name.Translation;
			}
			RoomDefinition treatmentRoom = illness.GetTreatmentRoom(null, _researchManager);
			int treatmentCharge = _financeManager.GetTreatmentCharge(illness, treatmentRoom, _researchManager);
			_treatmentRoomIcon.overrideSprite = treatmentRoom.GetUnlockIcon();
			_treatmentRoomIconCellComparable.Value = treatmentRoom.LocalisedName.GetHashCode();
			_treatmentCostText.text = StringUtils.FormatCurrency(treatmentCharge);
			_treatmentCostCellComparable.Value = treatmentCharge;
			int numberOfCures = _gameplayStatsTracker.GetNumberOfCures(illness);
			int numberOfRageQuits = _gameplayStatsTracker.GetNumberOfRageQuits(illness);
			int numberOfFatalTreatments = _gameplayStatsTracker.GetNumberOfFatalTreatments(illness);
			int numberOfIneffectiveTreatments = _gameplayStatsTracker.GetNumberOfIneffectiveTreatments(illness);
			int num = numberOfCures + numberOfIneffectiveTreatments + numberOfFatalTreatments + numberOfRageQuits;
			if (num == 0)
			{
				_treatmentRateText.text = "-";
				_treatmentRateCellComparable.Value = 0;
			}
			else
			{
				int num2 = Mathf.FloorToInt(100f * (float)numberOfCures / (float)num);
				_treatmentRateText.text = $"{num2:0}%";
				_treatmentRateCellComparable.Value = num2;
			}
			_reputationProgressBarMaskable.SetProgressSmooth(_reputationTracker.GetIllnessReputation(illness));
			_cureCountCellComparable.Value = numberOfCures;
			_cureCountText.text = $"{numberOfCures:0}";
			_ineffectiveCountCellComparable.Value = numberOfIneffectiveTreatments;
			_ineffectiveCountText.text = $"{numberOfIneffectiveTreatments:0}";
			_fatalCountCellComparable.Value = numberOfFatalTreatments;
			_fatalCountText.text = $"{numberOfFatalTreatments:0}";
			_rageQuitCountCellComparable.Value = numberOfRageQuits;
			_rageQuitCountText.text = $"{numberOfRageQuits:0}";
		}

		public virtual void SetRowBackground(int rowNum)
		{
			if ((bool)_rowBackground)
			{
				_rowBackground.overrideSprite = ((rowNum % 2 == 1) ? _rowAlternateBackground : null);
			}
		}

		protected void Update()
		{
			Refresh();
		}
	}
}
