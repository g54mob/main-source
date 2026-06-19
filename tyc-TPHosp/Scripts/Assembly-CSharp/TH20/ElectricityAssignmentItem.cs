using I2.Loc;
using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ElectricityAssignmentItem : MonoBehaviour
	{
		[SerializeField]
		private Localize _titleText;

		[SerializeField]
		private TMP_Text _numberText;

		[SerializeField]
		private DynamicButton _addButton;

		[SerializeField]
		private DynamicButton _subtractButton;

		[SerializeField]
		private TooltipSpawner _textTooltip;

		[SerializeField]
		private TooltipSpawner _numberTooltip;

		private ChallengeElectricity.ElectricityType _electricityType;

		private ElectricityMenu _parentMenu;

		private ChallengeElectricity _challenge;

		public void Setup(ElectricityMenu parentMenu, ChallengeElectricity challenge, ChallengeElectricityConfig.ElectricityTypeEntry electricityTypeEntry)
		{
			_parentMenu = parentMenu;
			_challenge = challenge;
			_electricityType = electricityTypeEntry.Type;
			_titleText.SetTerm(electricityTypeEntry.AssignmentLocText);
			_addButton.onPrimaryDown.AddListener(OnAddButtonPressed);
			_subtractButton.onPrimaryDown.AddListener(OnSubtractButtonPressed);
			if (_textTooltip != null)
			{
				_textTooltip.SetDataProvider(TooltipDataProvider);
			}
			if (_numberTooltip != null)
			{
				_numberTooltip.SetDataProvider(TooltipDataProvider);
			}
			OnAllocatedElectricityChanged();
			_challenge.OnAllocatedElectricityChanged.AddListener(OnAllocatedElectricityChanged);
		}

		private void OnAllocatedElectricityChanged()
		{
			int electricityAllocation = _challenge.GetElectricityAllocation(_electricityType);
			_numberText.text = StringUtils.FormatInteger(electricityAllocation);
		}

		private void OnAddButtonPressed()
		{
			_challenge.IncrementAllocation(_electricityType);
		}

		private void OnSubtractButtonPressed()
		{
			_challenge.DecrementAllocation(_electricityType);
		}

		private void TooltipDataProvider(Tooltip tooltip)
		{
			if (_challenge != null)
			{
				if (_electricityType == ChallengeElectricity.ElectricityType.Applicants)
				{
					tooltip.Text = _challenge.Config.StaffApplicantTooltip.Translation;
				}
				else if (_electricityType == ChallengeElectricity.ElectricityType.PatientFlow)
				{
					tooltip.Text = _challenge.Config.PatientFlowTooltip.Translation;
				}
			}
		}

		private void Start()
		{
		}

		public void Destroy()
		{
			_challenge.OnAllocatedElectricityChanged.RemoveListener(OnAllocatedElectricityChanged);
			_addButton.onPrimaryDown.RemoveListener(OnAddButtonPressed);
			_subtractButton.onPrimaryDown.RemoveListener(OnSubtractButtonPressed);
		}
	}
}
