using DV.CabControls;
using DV.Game.Tutorial.ItemTracker;
using DV.Interaction;
using DV.InventorySystem;
using DV.Localization;
using DV.ServicePenalty;
using DV.ServicePenalty.UI;
using DV.Utils;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class CareerManagerDebtPayingStep : AQuickTutorialStep
	{
		private enum Prompt
		{
			None = 0,
			Up = 1,
			Down = 2,
			Confirm = 3,
			Cancel = 4,
			Print = 5,
			WalletDeposit = 6
		}

		private TutorialCareerManagerHandler handler;

		private CareerManagerInputHandler inputHandler;

		private bool invalid;

		private IDisplayScreen lastScreen;

		private int lastIndex;

		private bool lastValidPayScreen;

		private string locoID;

		private int targetFeeIndex;

		private Prompt prompt;

		private string message = "";

		private bool wasInWalletStep;

		private ItemPointer walletPointer;

		private ItemBase walletItem;

		private const int FEES_INDEX = 0;

		public CareerManagerDebtPayingStep(GameObject careerManagerGO, string debtID)
			: base("", null, Vector3.zero)
		{
			locoID = debtID;
			inputHandler = careerManagerGO.GetComponent<CareerManagerInputHandler>();
			handler = new TutorialCareerManagerHandler(careerManagerGO, debtID);
		}

		protected override void InternalMakeCurrent()
		{
			base.InternalMakeCurrent();
			invalid = false;
			walletItem = SingletonBehaviour<Inventory>.Instance.GetFirstItemByPrefabName("wallet");
			lastScreen = handler.ScreenSwitcher.CurrentScreen;
			lastIndex = handler.CurrentIndex;
			lastValidPayScreen = handler.IsValidPayScreen;
			_ = (handler.fees as CareerManagerFeesScreen).IndexOfFirstDisplayedEntry;
			targetFeeIndex = -1;
			for (int i = 0; i < SingletonBehaviour<CareerManagerDebtController>.Instance.NumberOfNonZeroPricedDebts; i++)
			{
				DisplayableDebt ithNonZeroDebt = SingletonBehaviour<CareerManagerDebtController>.Instance.GetIthNonZeroDebt(i);
				if (ithNonZeroDebt != null && ithNonZeroDebt.IsPayable && ithNonZeroDebt.ID == locoID)
				{
					targetFeeIndex = i;
					break;
				}
			}
			if (targetFeeIndex < 0)
			{
				Debug.LogError("Loco debt ID = '" + locoID + "' not found, nothing to do.");
				invalid = true;
			}
			handler.TutorialCareerManagerScreenUpdated += Handler_TutorialCareerManagerScreenUpdated;
		}

		protected override void InternalDeactivate()
		{
			base.InternalDeactivate();
			SingletonBehaviour<TutorialHelper>.Instance.HideTutorialFloatie();
			handler.TutorialCareerManagerScreenUpdated -= Handler_TutorialCareerManagerScreenUpdated;
			if (walletPointer != null)
			{
				walletPointer.Dispose();
				walletPointer = null;
			}
		}

		private void Handler_TutorialCareerManagerScreenUpdated(IDisplayScreen screen, string selection, int index, bool validPayScreen)
		{
			lastScreen = screen;
			lastIndex = index;
			lastValidPayScreen = validPayScreen;
		}

		protected override bool InternalCheck()
		{
			if (invalid)
			{
				return true;
			}
			bool flag = true;
			for (int i = 0; i < SingletonBehaviour<CareerManagerDebtController>.Instance.NumberOfNonZeroPricedDebts; i++)
			{
				DisplayableDebt ithNonZeroDebt = SingletonBehaviour<CareerManagerDebtController>.Instance.GetIthNonZeroDebt(i);
				if (ithNonZeroDebt != null && ithNonZeroDebt.IsPayable && ithNonZeroDebt.ID == locoID)
				{
					targetFeeIndex = i;
					flag = false;
					break;
				}
			}
			if (flag)
			{
				return true;
			}
			Prompt num = prompt;
			string text = message;
			if (lastScreen is CareerManagerFeePayingScreen)
			{
				CareerManagerFeePayingScreen careerManagerFeePayingScreen = lastScreen as CareerManagerFeePayingScreen;
				if (lastValidPayScreen)
				{
					if (careerManagerFeePayingScreen.cashReg.DepositedCash >= careerManagerFeePayingScreen.cashReg.GetTotalCost())
					{
						prompt = Prompt.Confirm;
						message = LocalizationAPI.L("tutorial/debt/confirm_transaction");
						if (wasInWalletStep)
						{
							if (walletPointer != null)
							{
								walletPointer.Dispose();
								walletPointer = null;
							}
							wasInWalletStep = false;
						}
					}
					else
					{
						prompt = Prompt.WalletDeposit;
						message = LocalizationAPI.L("tutorial/debt/insert_wallet");
						if (!wasInWalletStep)
						{
							if (walletPointer != null)
							{
								walletPointer.Dispose();
							}
							walletPointer = new ItemPointer(walletItem, null, ItemTracker.TargetZoneType.Hands, string.Empty);
							wasInWalletStep = true;
						}
					}
				}
				else
				{
					prompt = Prompt.Cancel;
					message = LocalizationAPI.L("tutorial/debt/cancel");
				}
			}
			else if (lastScreen == handler.fees)
			{
				if (lastIndex > targetFeeIndex - (handler.fees as CareerManagerFeesScreen).IndexOfFirstDisplayedEntry)
				{
					prompt = Prompt.Up;
					message = LocalizationAPI.L("tutorial/debt/select_loco", locoID);
				}
				else if (lastIndex < targetFeeIndex - (handler.fees as CareerManagerFeesScreen).IndexOfFirstDisplayedEntry)
				{
					prompt = Prompt.Down;
					message = LocalizationAPI.L("tutorial/debt/select_loco", locoID);
				}
				else
				{
					prompt = Prompt.Confirm;
					message = LocalizationAPI.L("tutorial/debt/confirm_to_pay");
				}
			}
			else if (lastScreen != handler.main)
			{
				prompt = Prompt.Cancel;
				message = LocalizationAPI.L("tutorial/debt/cancel");
			}
			else if (lastIndex > 0)
			{
				prompt = Prompt.Up;
				message = LocalizationAPI.L("tutorial/debt/select_fees");
			}
			else if (lastIndex < 0)
			{
				prompt = Prompt.Down;
				message = LocalizationAPI.L("tutorial/debt/select_fees");
			}
			else
			{
				prompt = Prompt.Confirm;
				message = LocalizationAPI.L("tutorial/debt/go_to_payment");
			}
			if (num != prompt || message != text)
			{
				switch (prompt)
				{
				case Prompt.Up:
					SingletonBehaviour<TutorialHelper>.Instance.ShowTutorialFloatie(message, inputHandler.upButtonGO.transform, Vector3.zero, localize: false);
					break;
				case Prompt.Down:
					SingletonBehaviour<TutorialHelper>.Instance.ShowTutorialFloatie(message, inputHandler.downButtonGO.transform, Vector3.zero, localize: false);
					break;
				case Prompt.Confirm:
					SingletonBehaviour<TutorialHelper>.Instance.ShowTutorialFloatie(message, inputHandler.confirmButtonGO.transform, Vector3.zero, localize: false);
					break;
				case Prompt.Cancel:
					SingletonBehaviour<TutorialHelper>.Instance.ShowTutorialFloatie(message, inputHandler.cancelButtonGO.transform, Vector3.zero, localize: false);
					break;
				case Prompt.Print:
					SingletonBehaviour<TutorialHelper>.Instance.ShowTutorialFloatie(message, inputHandler.printInfoButtonGO.transform, Vector3.zero, localize: false);
					break;
				case Prompt.WalletDeposit:
					SingletonBehaviour<TutorialHelper>.Instance.ShowTutorialFloatie(message, (lastScreen as CareerManagerFeePayingScreen).cashReg.GetComponent<ItemUseTarget>().targetColliders[0].transform, Vector3.zero, localize: false);
					break;
				default:
					SingletonBehaviour<TutorialHelper>.Instance.HideTutorialFloatie();
					break;
				}
			}
			return false;
		}
	}
}
