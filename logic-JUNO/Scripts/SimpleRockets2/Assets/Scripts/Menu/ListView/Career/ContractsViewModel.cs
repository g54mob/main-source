using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Career.Contracts;
using Assets.Scripts.Menu.Tutorial;
using Assets.Scripts.State;
using ModApi;
using ModApi.Audio;
using ModApi.Math;
using ModApi.Services.Purchasing;
using ModApi.Ui;
using UnityEngine;

namespace Assets.Scripts.Menu.ListView.Career
{
	public class ContractsViewModel : CareerViewModelBase
	{
		private const string RejectedFilterKeyword = "rejected";

		private ContractsDetails _details;

		public bool AllowChanges { get; private set; }

		public bool TutorialIsRunning
		{
			get
			{
				if (MenuTutorialPanelScript.CareerDialogStep < 3 && !MenuTutorialPanelScript.IsTutorialComplete)
				{
					return Game.Instance.GameState.Career.IsStock;
				}
				return false;
			}
		}

		public event EventHandler<EventArgs> ContractStatusChanged;

		public ContractsViewModel(bool allowChanges)
		{
			AllowChanges = allowChanges;
		}

		public override IEnumerator LoadItems()
		{
			yield return new WaitForEndOfFrame();
			base.NoItemsFoundMessage = "No contracts are available right now.\nCheck the Tech Tree and see if there is anything you can unlock.";
			GameState gameState = Game.Instance.GameState;
			gameState.Career.Contracts.PopulateContracts();
			List<Contract> list = (from x in gameState.Career.Contracts.All
				where !x.IsClosed
				orderby x.Priority descending, x.Difficulty
				select x).ToList();
			if (AllowChanges)
			{
				CreateCustomerIntros(gameState, list);
			}
			ContractContext contracts = gameState.Career.Contracts;
			contracts.NumContractsNotSeen = 0;
			if (contracts.Active.Count + contracts.Generated.Count >= 3 && gameState.Career.IsStock)
			{
				base.ListView.ShowNotification("Career.MaxAvailableContracts", "Unlock 'Novice Managers' in the tech tree to increase the max number of available contracts.");
			}
			foreach (Contract item in list)
			{
				if (Game.Instance.InAppPurchases.Features.CareerCustomer(item.Customer.Id).Unlocked)
				{
					AddContract(item);
				}
			}
			yield return new WaitForEndOfFrame();
		}

		public override void OnDeleteButtonClicked(ListViewItemScript selectedItem)
		{
			Contract contract = selectedItem?.ItemModel as Contract;
			MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			messageDialogScript.UseDangerButtonStyle = true;
			messageDialogScript.MessageText = "Do you want to reject this contract? Rejected contracts will not be shown again, but you can un-reject them at anytime by opening the context menu at the top right and toggling the Show Rejected filter.";
			messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
			{
				d.Close();
				contract.Status = ContractStatus.Rejected;
				foreach (Contract item in Game.Instance.GameState.Career.Contracts.All.Where((Contract x) => x.Name == contract.Name && x.Status == ContractStatus.Generated && x != contract).ToList())
				{
					Game.Instance.GameState.Career.Contracts.RemoveContract(item);
				}
				base.ListView.SelectedItem = null;
				selectedItem.FilterKeywords.Add("rejected");
				UpdateFlair(contract, selectedItem);
				base.ListView.ReloadItems();
				this.ContractStatusChanged?.Invoke(this, EventArgs.Empty);
			};
		}

		public override void OnListViewInitialized(ListViewScript listView)
		{
			base.OnListViewInitialized(listView);
			base.DoubleClickIsPrimaryClick = false;
			listView.Title = "CONTRACTS";
			listView.CanDelete = false;
			listView.PrimaryButtonText = "ACCEPT";
			listView.DisplayType = ListViewScript.ListViewDisplayType.SmallDialog;
			listView.DisablePrimaryButtonSound();
			_details = new ContractsDetails(base.ListView.ListViewDetails, this);
			listView.CreateFilter(false, "Show Rejected", "Shows the contracts that have been rejected", ListViewFilterType.Exclusive, false, "rejected").CloseContextMenuWhenClicked = true;
			if (AllowChanges)
			{
				listView.CreateContextMenuSeparator();
				listView.CreateContextMenuItem("Refresh Contracts", OnRefreshContractsClicked).CloseContextMenuWhenClicked = true;
				if (Device.IsUnityEditor || Game.Instance.GameState.Validator.IsItemAvailable("Cheats.CareerCheats"))
				{
					listView.CreateContextMenuSeparator();
					listView.CreateContextMenuItem("Reset Contract", OnResetContractClicked).CloseContextMenuWhenClicked = true;
					listView.CreateContextMenuItem("Re-Generate Selected", OnRegenerateContractClicked);
					listView.CreateContextMenuItem("Complete Selected", OnCompleteContractClicked);
					listView.CreateContextMenuItem("Un-Complete Selected", OnUnCompleteContractClicked);
				}
			}
		}

		public override void OnPrimaryButtonClicked(ListViewItemScript selectedItem)
		{
			if (AllowChanges)
			{
				object itemModel = selectedItem.ItemModel;
				Contract contract = itemModel as Contract;
				if (contract != null)
				{
					if (contract.Status == ContractStatus.Generated)
					{
						if (!TutorialIsRunning)
						{
							Game.Instance.GameState.Career.Contracts.AcceptContract(contract, Game.Instance.GameState.GetCurrentTime());
							base.RequiresSceneReload = Game.InDesignerScene;
							Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Career.ContractAccept);
						}
						else
						{
							Game.Instance.UserInterface.CreateMessageDialog().MessageText = "You cannot accept the contract yet. Please finish the tutorial first.";
						}
					}
					else if (contract.Status == ContractStatus.Active || contract.Status == ContractStatus.Failed)
					{
						MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
						messageDialogScript.UseDangerButtonStyle = true;
						messageDialogScript.CancelButtonText = "No";
						messageDialogScript.OkayButtonText = "Yes";
						messageDialogScript.MessageText = "Canceling this contract will cost <color=#e7515a>" + Units.GetMoneyString(contract.CancelCost) + "</color>.\n\nAre you sure you want to cancel this contract?";
						messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
						{
							d.Close();
							FlightStateData flightStateData = Game.Instance.GameState.LoadFlightStateData();
							Game.Instance.GameState.Career.Contracts.CancelContract(contract, flightStateData);
							flightStateData.Save();
							base.ListView.SelectedItem = null;
							Items.Remove(selectedItem);
							base.ListView.DeleteItem(selectedItem);
							base.ListView.ReloadItems();
							base.RequiresSceneReload = true;
							this.ContractStatusChanged?.Invoke(this, EventArgs.Empty);
							Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Career.ContractCancel);
						};
					}
					else if (contract.Status == ContractStatus.Rejected)
					{
						MessageDialogScript messageDialogScript2 = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
						messageDialogScript2.MessageText = "Confirm that you want to remove this contract from your rejection list. You may not see this exact same contract again, but you might start seeing more contracts like it.";
						messageDialogScript2.OkayClicked += delegate(MessageDialogScript d)
						{
							d.Close();
							RemoveContract(selectedItem, contract);
							base.ListView.ReloadItems();
							this.ContractStatusChanged?.Invoke(this, EventArgs.Empty);
						};
					}
					base.ListView.CanDelete = contract.CanReject && contract.Status == ContractStatus.Generated;
					Game.Instance.GameState.Career.Contracts.RefreshActiveContracts();
					UpdatePrimaryButton(contract);
					UpdateFlair(contract, selectedItem);
					this.ContractStatusChanged?.Invoke(this, EventArgs.Empty);
				}
				else if (selectedItem.ItemModel is Customer customer)
				{
					IInAppPurchaseFeatures<IInAppPurchaseFeature> features = Game.Instance.InAppPurchases.Features;
					if (features.IsFeatureUnlocked(features.CareerCustomer(customer.Id), "unlock this customer and their contracts."))
					{
						base.ListView.CanDelete = false;
						Game.Instance.GameState.Career.MarkCustomerAsMet(customer.Id);
						base.ListView.SelectedItem = null;
						Items.Remove(selectedItem);
						base.ListView.DeleteItem(selectedItem);
						Game.Instance.AudioPlayer.PlaySound(AudioLibrary.ButtonClicked);
					}
				}
			}
			else
			{
				Game.Instance.UserInterface.CreateMessageDialog("You cannot accept or cancel contracts while in the flight scene.");
			}
		}

		public void OnResetContractClicked(ContextMenuItemScript obj)
		{
			Contract contract = base.ListView.SelectedItem?.ItemModel as Contract;
			if (contract != null)
			{
				MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
				messageDialogScript.MessageText = "Are you sure you want to reset this contract? You will lose all progress on this contract.\n\nIt's not common that you will need to reset a contract, but it can be helpful in cases where a contract is attached to the wrong craft. ";
				messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
				{
					d.Close();
					contract.ResetStatus();
				};
			}
		}

		public override void UpdateDetails(ListViewItemScript item, Action completeCallback)
		{
			base.ListView.CanDelete = false;
			if (item != null)
			{
				if (item.ItemModel is Contract contract)
				{
					base.ListView.DetailsTitleText = contract.Name;
					base.ListView.CanDelete = contract.CanReject && contract.Status == ContractStatus.Generated;
					_details.UpdateDetails(contract);
					UpdatePrimaryButton(contract);
				}
				else if (item.ItemModel is Customer customer)
				{
					base.ListView.DetailsTitleText = customer.Name;
					_details.UpdateDetails(customer);
					base.ListView.PrimaryButtonStyle = ListViewScript.PrimaryButtonStyleType.Primary;
					base.ListView.PrimaryButtonText = customer.HelloText;
					base.ListView.PrimaryButtonEnabled = true;
				}
			}
			completeCallback?.Invoke();
		}

		private static void UpdateFlair(Contract contract, ListViewItemScript item)
		{
			if (contract.Status == ContractStatus.Rejected)
			{
				item.SetFlair(ListViewItemScript.FlairColorType.Warning, "Rejected");
			}
			else if (contract.Status == ContractStatus.Complete)
			{
				item.SetFlair(ListViewItemScript.FlairColorType.Success, "Completed");
			}
			else if (contract.Status == ContractStatus.Active || contract.Status == ContractStatus.Failed)
			{
				item.SetFlair(ListViewItemScript.FlairColorType.Primary, "Accepted");
			}
			else if (!string.IsNullOrEmpty(contract.FlairText))
			{
				item.SetFlair(ListViewItemScript.FlairColorType.Primary, contract.FlairText);
			}
			else if (contract.UnlockLocations.Count > 0)
			{
				item.SetFlair(ListViewItemScript.FlairColorType.Success, "LOCATION");
			}
			else
			{
				item.SetFlair(ListViewItemScript.FlairColorType.None, string.Empty);
			}
		}

		private void AddContract(Contract contract)
		{
			string text = ((contract.RewardResearchPoints > 0) ? $" | {contract.RewardResearchPoints}TP" : string.Empty);
			string text2 = Units.GetMoneyString(contract.RewardMoney + contract.RewardMoneyAdvance) + text + " | " + contract.DifficultyLabel;
			if (!Device.IsMobileBuild)
			{
				text2 = text2 + " | " + contract.Customer.Name;
			}
			string text3 = contract.Name;
			if (!string.IsNullOrEmpty(contract.Subtitle))
			{
				text3 = text3 + "  <color=#ffffffA0><size=75%>" + contract.Subtitle + "</size></color>";
			}
			ListViewItemScript listViewItemScript = base.ListView.CreateItem(text3, text2, contract, contract.Customer.SmallProfileImage, ListViewScript.SpriteLoadLocation.File);
			if (contract.Status == ContractStatus.Rejected)
			{
				listViewItemScript.FilterKeywords.Add("rejected");
			}
			listViewItemScript.Visible = false;
			UpdateFlair(contract, listViewItemScript);
		}

		private void CreateCustomerIntros(GameState gameState, List<Contract> pendingContracts)
		{
			List<Customer> list = new List<Customer>();
			foreach (Contract pendingContract in pendingContracts)
			{
				Customer customer = pendingContract.Customer;
				if (!gameState.Career.HasMetCustomer(customer.Id) && !list.Contains(customer))
				{
					list.Add(customer);
				}
			}
			foreach (Customer item in list)
			{
				string name = item.Name;
				ListViewItemScript listViewItemScript = base.ListView.CreateItem("You have a new customer", name, item, item.SmallProfileImage, ListViewScript.SpriteLoadLocation.File);
				listViewItemScript.StatusIcon = ListViewItemScript.StatusIconType.Exclamation;
				listViewItemScript.StatusIconColor = "White";
			}
		}

		private void OnCompleteContractClicked(ContextMenuItemScript obj)
		{
			if (base.ListView.SelectedItem?.ItemModel is Contract contract)
			{
				FlightStateData flightStateData = Game.Instance.GameState.LoadFlightStateData();
				contract.Status = ContractStatus.Complete;
				Game.Instance.GameState.Career.Contracts.CloseContract(contract, flightStateData);
				RefreshContracts();
				this.ContractStatusChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		private void OnRefreshContractsClicked(ContextMenuItemScript item)
		{
			MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			messageDialogScript.UseDangerButtonStyle = true;
			messageDialogScript.MessageText = "Would you like to refresh the current selection of contracts? This will not affect contracts that you have already accepted.";
			messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
			{
				d.Close();
				RefreshContracts();
			};
		}

		private void OnRegenerateContractClicked(ContextMenuItemScript obj)
		{
			if (base.ListView.SelectedItem?.ItemModel is Contract contract)
			{
				Game.Instance.GameState.Career.Contracts.RegenerateContract(contract);
			}
		}

		private void OnUnCompleteContractClicked(ContextMenuItemScript obj)
		{
			Contract contract = base.ListView.SelectedItem?.ItemModel as Contract;
			if (contract == null)
			{
				return;
			}
			Game.Instance.GameState.LoadFlightStateData();
			contract.Status = ContractStatus.Complete;
			foreach (Contract item in Game.Instance.GameState.Career.Contracts.All.Where((Contract x) => x.Id == contract.Id).ToList())
			{
				Game.Instance.GameState.Career.Contracts.RemoveContract(item);
			}
			OnRefreshContractsClicked(null);
			this.ContractStatusChanged?.Invoke(this, EventArgs.Empty);
		}

		private void RefreshContracts()
		{
			base.ListView.SelectedItem = null;
			ContractContext contracts = Game.Instance.GameState.Career.Contracts;
			List<Contract> list = new List<Contract>();
			foreach (Contract item in contracts.All)
			{
				if (item.Status == ContractStatus.Generated)
				{
					list.Add(item);
				}
			}
			foreach (Contract item2 in list)
			{
				contracts.RemoveContract(item2);
			}
			base.ListView.ReloadItems();
		}

		private void RemoveContract(ListViewItemScript selectedItem, Contract contract)
		{
			Game.Instance.GameState.Career.Contracts.RemoveContract(contract);
			base.ListView.SelectedItem = null;
			Items.Remove(selectedItem);
			base.ListView.DeleteItem(selectedItem);
		}

		private void UpdatePrimaryButton(Contract contract)
		{
			string primaryButtonText = "ACCEPT";
			bool primaryButtonEnabled = true;
			ListViewScript.PrimaryButtonStyleType primaryButtonStyle = ListViewScript.PrimaryButtonStyleType.Primary;
			if (contract.Status == ContractStatus.Rejected)
			{
				primaryButtonText = "UN-REJECT";
				primaryButtonEnabled = true;
			}
			else if (contract.Status == ContractStatus.Complete)
			{
				primaryButtonText = "COMPLETED";
				primaryButtonEnabled = false;
			}
			else if (contract.Status == ContractStatus.Active || contract.Status == ContractStatus.Failed)
			{
				primaryButtonText = "CANCEL";
				primaryButtonEnabled = true;
				primaryButtonStyle = ListViewScript.PrimaryButtonStyleType.Danger;
			}
			base.ListView.PrimaryButtonText = primaryButtonText;
			base.ListView.PrimaryButtonEnabled = primaryButtonEnabled;
			base.ListView.PrimaryButtonStyle = primaryButtonStyle;
		}
	}
}
