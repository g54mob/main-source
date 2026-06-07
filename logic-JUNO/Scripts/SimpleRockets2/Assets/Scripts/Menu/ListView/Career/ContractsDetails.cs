using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Career.Contracts;
using Assets.Scripts.Career.Contracts.Requirements;
using ModApi.Math;
using ModApi.Scenes.Parameters;

namespace Assets.Scripts.Menu.ListView.Career
{
	public class ContractsDetails
	{
		private DetailsTextScript _advanceText;

		private Contract _contract;

		private DetailsTextScript _contractId;

		private DetailsImageScript _customer;

		private DetailsTextScript _customerName;

		private DetailsTextScript _deadline;

		private DetailsTextScript _description;

		private List<DetailsTextScript> _details = new List<DetailsTextScript>();

		private DetailsWidgetGroup _detailsGroup;

		private DetailsWidgetGroup _detailsRequirements;

		private DetailsWidgetGroup _detailsTutorial;

		private DetailsTextScript _expiration;

		private DetailsTextScript _locationsText;

		private DetailsTextScript _moneyText;

		private DetailsTextScript _researchText;

		private DetailsWidgetGroup _rewardsGroup;

		public ContractsDetails(ListViewDetailsScript listViewDetails, ContractsViewModel viewModel)
		{
			ContractsDetails contractsDetails = this;
			_customer = listViewDetails.Widgets.AddImage();
			_description = listViewDetails.Widgets.AddText("Description");
			_detailsTutorial = listViewDetails.Widgets.AddGroup();
			_detailsTutorial.AddHeader("TUTORIAL");
			_detailsTutorial.AddText("This contract has a tutorial! You're so lucky!");
			_detailsTutorial.AddButton("START TUTORIAL").Clicked = delegate
			{
				if (viewModel.AllowChanges && !viewModel.TutorialIsRunning)
				{
					if (contractsDetails._contract.Status == ContractStatus.Generated)
					{
						Game.Instance.GameState.Career.Contracts.AcceptContract(contractsDetails._contract, Game.Instance.GameState.GetCurrentTime());
					}
					if (contractsDetails._contract.IsActive)
					{
						Game.Instance.GameState.Save();
						Game.Instance.SceneManager.LoadDesigner(new DesignSceneLoadParameters
						{
							TutorialId = contractsDetails._contract.DesignerTutorialId
						});
					}
					else
					{
						Game.Instance.UserInterface.CreateMessageDialog("You must accept this contract before you can start the tutorial.");
					}
				}
				else
				{
					Game.Instance.UserInterface.CreateMessageDialog("You cannot start a tutorial while in the flight scene or while the menu tutorial is running.");
				}
			};
			_detailsRequirements = listViewDetails.Widgets.AddGroup();
			_detailsRequirements.AddHeader("REQUIREMENTS");
			_deadline = listViewDetails.Widgets.AddText(string.Empty);
			_rewardsGroup = listViewDetails.Widgets.AddGroup();
			_rewardsGroup.AddHeader("REWARDS");
			_locationsText = _rewardsGroup.AddText(string.Empty);
			_advanceText = _rewardsGroup.AddText(string.Empty);
			_moneyText = _rewardsGroup.AddText(string.Empty);
			_researchText = _rewardsGroup.AddText(string.Empty);
			_detailsGroup = listViewDetails.Widgets.AddGroup();
			_detailsGroup.AddHeader("DETAILS");
			_expiration = _detailsGroup.AddText(string.Empty);
			_contractId = _detailsGroup.AddText(string.Empty);
			_customerName = _detailsGroup.AddText(string.Empty);
		}

		public void UpdateDetails(Contract contract)
		{
			_contract = contract;
			_customer.Visible = false;
			_description.Text = contract.Description;
			_detailsTutorial.Visible = !string.IsNullOrEmpty(contract.DesignerTutorialId);
			_detailsRequirements.Visible = true;
			int num = 0;
			ContractRequirement[] array = contract.Requirements.Where((ContractRequirement x) => x.ListedInMenu && !string.IsNullOrWhiteSpace(x.Description)).ToArray();
			for (num = 0; num < array.Length; num++)
			{
				while (_details.Count <= num)
				{
					_details.Add(_detailsRequirements.AddText(string.Empty));
				}
				ContractRequirement contractRequirement = array[num];
				_details[num].gameObject.SetActive(value: true);
				_details[num].Text = "• " + contractRequirement.Description;
			}
			for (; num < _details.Count; num++)
			{
				_details[num].gameObject.SetActive(value: false);
			}
			double currentTime = (Game.InFlightScene ? Game.Instance.FlightScene.FlightState.Time : Game.Instance.GameState.GetCurrentTime());
			_deadline.Visible = false;
			if (contract.DeadlineLength > 0)
			{
				_deadline.Visible = true;
				_deadline.Text = $"• Must be completed within {contract.GetDaysUntilDeadline(currentTime):n1} days";
			}
			_rewardsGroup.Visible = true;
			_locationsText.Visible = contract.UnlockLocations.Count > 0;
			if (_locationsText.Visible)
			{
				if (contract.UnlockLocations.Count == 1)
				{
					_locationsText.Text = "• Unlocks new location: " + string.Join(", ", contract.UnlockLocations);
				}
				else
				{
					_locationsText.Text = "• Unlocks new locations: " + string.Join(", ", contract.UnlockLocations);
				}
			}
			_advanceText.Text = "• Signing Bonus: " + Units.GetMoneyString(contract.RewardMoneyAdvance);
			_advanceText.Visible = contract.RewardMoneyAdvance > 0;
			_moneyText.Text = "• Money: " + Units.GetMoneyString(contract.RewardMoney);
			_researchText.Visible = contract.RewardResearchPoints > 0;
			_researchText.Text = $"• Tech Points: {contract.RewardResearchPoints}TP";
			if (contract.RewardCrewMoney > 0)
			{
				DetailsTextScript moneyText = _moneyText;
				moneyText.Text = moneyText.Text + " + " + Units.GetMoneyString(contract.RewardCrewMoney) + " if crewed";
			}
			if (contract.RewardCrewResearch > 0)
			{
				if (!_researchText.Visible)
				{
					_researchText.Visible = true;
					_researchText.Text = $"• Tech Points if crewed: {contract.RewardCrewResearch}TP";
				}
				else
				{
					_researchText.Text += $" + {contract.RewardCrewResearch}TP if crewed";
				}
			}
			_detailsGroup.Visible = true;
			_contractId.Text = $"• Contract #{contract.ContractNumber}";
			_customerName.Text = "• Customer: " + contract.Customer.Name;
			_expiration.Visible = false;
			if (contract.Status == ContractStatus.Generated && contract.ExpirationLength > 0)
			{
				_expiration.Visible = true;
				_expiration.Text = $"• Can no longer be accepted after {contract.GetDaysUntilExpiration(currentTime):n1} days";
			}
		}

		public void UpdateDetails(Customer customer)
		{
			_contract = null;
			_customer.Visible = true;
			_customer.ImagePath = customer.LargeProfileImage;
			_customer.SetSize(200);
			_description.Text = customer.LongBio;
			_detailsRequirements.Visible = false;
			_detailsGroup.Visible = false;
			_rewardsGroup.Visible = false;
			_detailsTutorial.Visible = false;
		}
	}
}
