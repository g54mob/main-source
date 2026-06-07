using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DV.Booklets;
using DV.CabControls;
using DV.Printers;
using TMPro;
using UnityEngine;

namespace DV.CashRegister
{
	public class CashRegisterWithModules : CashRegisterBase
	{
		[Header("Cash Register Modules")]
		public CashRegisterModule[] registerModules;

		[Header("Buttons")]
		public GameObject buyButtonGO;

		public GameObject cancelButtonGO;

		private ButtonBase buyButton;

		private ButtonBase cancelButton;

		[Header("Text")]
		public float goodByeTextDuration = 1.5f;

		public TextMeshPro cashText;

		public TextMeshPro totalText;

		public TextMeshPro infoText;

		[SerializeField]
		private bool hasTransactionProcessingText;

		private PrinterController printerController;

		private CashRegisterWithModulesTextController textController;

		private bool isProcessingTransaction;

		public override bool IsProcessingTransaction
		{
			get
			{
				return isProcessingTransaction;
			}
			set
			{
				if (isProcessingTransaction == value)
				{
					return;
				}
				isProcessingTransaction = value;
				if (hasTransactionProcessingText)
				{
					if (isProcessingTransaction || TotalUnitsInBasket() > 0f)
					{
						textController.UpdateInfoText();
					}
					else
					{
						textController.DisplayGoodbyeText();
					}
				}
			}
		}

		protected override void Awake()
		{
			base.Awake();
			printerController = GetComponent<PrinterController>();
			if (printerController == null)
			{
				Debug.LogError("PrinterController component isn't attached to CashRegisterWithModules!", this);
			}
			textController = new CashRegisterWithModulesTextController(this, cashText, totalText, infoText, goodByeTextDuration);
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			textController.UpdateAllTexts();
			StartCoroutine(WireUpButtons());
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			StopAllCoroutines();
			textController.Clear();
			SetupListeners(on: false);
			Cancel();
		}

		private void SetupListeners(bool on)
		{
			CashRegisterModule[] array;
			if (on)
			{
				buyButton.Used += OnBuyPressed;
				cancelButton.Used += Cancel;
				base.CashAdded += OnDepositedUpdated;
				base.CashRemoved += OnDepositedUpdated;
				array = registerModules;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].OnUnitsToBuyChanged += OnUnitsToBuyChanged;
				}
				return;
			}
			if (buyButton != null)
			{
				buyButton.Used -= OnBuyPressed;
			}
			if (cancelButton != null)
			{
				cancelButton.Used -= Cancel;
			}
			base.CashAdded -= OnDepositedUpdated;
			base.CashRemoved -= OnDepositedUpdated;
			array = registerModules;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].OnUnitsToBuyChanged -= OnUnitsToBuyChanged;
			}
		}

		private IEnumerator WireUpButtons()
		{
			while ((buyButton = buyButtonGO.GetComponent<ButtonBase>()) == null)
			{
				yield return null;
			}
			while ((cancelButton = cancelButtonGO.GetComponent<ButtonBase>()) == null)
			{
				yield return null;
			}
			SetupListeners(on: true);
		}

		private void OnDepositedUpdated()
		{
			textController.UpdateCashText();
			textController.UpdateInfoText();
		}

		private void OnUnitsToBuyChanged()
		{
			textController.UpdateTotalCostText();
			textController.UpdateInfoText();
		}

		public override double GetTotalCost()
		{
			double num = 0.0;
			CashRegisterModule[] array = registerModules;
			foreach (CashRegisterModule cashRegisterModule in array)
			{
				if (cashRegisterModule == null)
				{
					Debug.LogError("Register module is null. This should not happen", this);
				}
				else
				{
					num += cashRegisterModule.GetTotalPrice();
				}
			}
			return num;
		}

		public override float TotalUnitsInBasket()
		{
			float num = 0f;
			CashRegisterModule[] array = registerModules;
			foreach (CashRegisterModule cashRegisterModule in array)
			{
				if (cashRegisterModule == null)
				{
					Debug.LogError("Register module is null. This should not happen", this);
				}
				else
				{
					num += cashRegisterModule.GetTotalUnitsInBasket();
				}
			}
			return num;
		}

		private void OnBuyPressed()
		{
			Buy();
		}

		public override bool Buy()
		{
			bool flag = base.Buy();
			if (flag)
			{
				List<CashRegisterModule> list = registerModules.Where((CashRegisterModule r) => r.GetAllNonZeroPurchaseData().Count > 0).ToList();
				if (list.Count > 0)
				{
					BookletCreator.CreateCashRegisterReceipt(list, printerController.spawnAnchor.position, printerController.spawnAnchor.rotation, WorldMover.OriginShiftParent);
					printerController.Print(ignoreCooldown: true);
				}
				else
				{
					Debug.LogError("There were no CashRegisterModules with UnitsToBuy > 0. Something is wrong!");
				}
				CashRegisterModule[] array = registerModules;
				for (int num = 0; num < array.Length; num++)
				{
					array[num].GetBoughtResource();
				}
				OnUnitsToBuyChanged();
				if (!hasTransactionProcessingText)
				{
					textController.DisplayGoodbyeText();
				}
			}
			return flag;
		}

		public override void Cancel()
		{
			base.Cancel();
			CashRegisterModule[] array = registerModules;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].CancelShopping();
			}
			OnUnitsToBuyChanged();
		}
	}
}
