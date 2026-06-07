using System;
using System.Collections.Generic;
using Dhs5.Utility.Debuggers;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

namespace Simulator.GameWorld
{
	public class CashRegisterWorkshop : Workshop, IPlayerInputReceiver
	{
		public delegate void ClientCheckoutCallback(List<Product> products, float totalCost);

		public delegate void OnRemoveChangeReturnedCallback(ECashAmount cashAmount, bool hasRemainingChange);

		[Serializable]
		private struct Cash
		{
			public CashObject prefab;

			public Transform spawnPoint;
		}

		[Header("Main Components")]
		[SerializeField]
		private UI_CashRegister m_interface;

		[Header("Components")]
		[SerializeField]
		private POVCamera m_povCamera;

		[SerializeField]
		private CinemachineCamera m_cardMachineCamera;

		[SerializeField]
		private CashBox m_cashBox;

		[SerializeField]
		private CardMachine m_cardMachine;

		[Header("Shopping Bag")]
		[SerializeField]
		private Transform m_shoppingBagAnchor;

		[SerializeField]
		private Transform m_productsFallAnchor;

		[Header("Cash")]
		[SerializeField]
		private EnumValues<ECashAmount, Cash> m_cashObjectPrefabs;

		private Dictionary<ECashAmount, Stack<CashObject>> m_cashObjects;

		[Header("Input Hint")]
		[SerializeField]
		private DeviceInputHint m_inputHintPayment;

		private readonly List<Product> m_productsToCheck = new List<Product>();

		private readonly List<Product> m_checkedProducts = new List<Product>();

		private bool m_tookCash;

		private bool m_checkedAllProducts;

		public CardMachine CardMachine => m_cardMachine;

		public ClientCharacter CurrentlyCheckingOutCharacter { get; set; }

		public EPaymentMethod PaymentMethod { get; private set; }

		public int ItemsLeftToCheck => m_productsToCheck.Count;

		public CashBox CashBox => m_cashBox;

		public event Action ClientCollected;

		public static event ClientCheckoutCallback ClientCheckedOut;

		public event Action<Product> OnProductInteractedEvent;

		public static event Action<ECashAmount> OnAddChangeReturned;

		public static event OnRemoveChangeReturnedCallback OnRemoveChangeReturned;

		public event Action<ECashAmount> OnChangeReturned;

		public event Action<EPaymentMethod> OnCompleteCheckoutEvent;

		public IEnumerable<BoughtProductInfo> GetCheckoutProducts()
		{
			if (m_productsToCheck.IsValid())
			{
				foreach (Product item in m_productsToCheck)
				{
					yield return item.GetBoughtProductInfo();
				}
			}
			if (!m_checkedProducts.IsValid())
			{
				yield break;
			}
			foreach (Product checkedProduct in m_checkedProducts)
			{
				yield return checkedProduct.GetBoughtProductInfo();
			}
		}

		private void Awake()
		{
			InitCashObjects();
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			RecenterCamera();
			m_povCamera.SetEnable(enable: false);
			m_cardMachine.Validated += OnCardMachineValidated;
			InputManager.DeviceChanged += OnDeviceChanged;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			m_cardMachine.Validated -= OnCardMachineValidated;
			InputManager.DeviceChanged -= OnDeviceChanged;
		}

		public void Load(int phase, SaveClass_Furnitures.CashRegisterState state)
		{
			if (phase != 1)
			{
				return;
			}
			PaymentMethod = state.paymentMethod;
			if (!state.productsToCheckout.IsValid())
			{
				return;
			}
			Vector3 position = m_productsFallAnchor.position;
			foreach (BoughtProductInfo item in state.productsToCheckout)
			{
				if (item.Data != null)
				{
					Product product = World.ProductFactory.CreateProduct(item);
					product.MakeFallFrom(m_productsFallAnchor, position);
					position += Vector3.up * 0.05f;
					m_productsToCheck.Add(product);
				}
			}
			CashRegisterTransaction.CreateNew();
		}

		public void WelcomeLoadedCheckingOutCharacter()
		{
			AnchorShoppingBag(CurrentlyCheckingOutCharacter.ShoppingBag);
		}

		public void WelcomeClient(EPaymentMethod paymentMethod)
		{
			PaymentMethod = paymentMethod;
			EmptyShoppingBag(CurrentlyCheckingOutCharacter.ShoppingBag);
			EPaymentMethod paymentMethod2 = PaymentMethod;
			if (paymentMethod2 != EPaymentMethod.CASH)
			{
				_ = paymentMethod2 - 1;
				_ = 1;
			}
			else
			{
				m_tookCash = false;
			}
		}

		private void EmptyShoppingBag(ShoppingBag shoppingBag)
		{
			AnchorShoppingBag(shoppingBag);
			Vector3 position = m_productsFallAnchor.position;
			foreach (Product item in shoppingBag.Empty())
			{
				m_productsToCheck.Add(item);
				item.MakeFallFrom(m_productsFallAnchor, position);
				position += Vector3.up * 0.05f;
			}
			CashRegisterTransaction.CreateNew();
		}

		private void AnchorShoppingBag(ShoppingBag shoppingBag)
		{
			shoppingBag.AddConstraint(m_shoppingBagAnchor);
			shoppingBag.Open(open: true);
		}

		private void InitCashObjects()
		{
			m_cashObjects = new Dictionary<ECashAmount, Stack<CashObject>>();
			foreach (ECashAmount value in Enum.GetValues(typeof(ECashAmount)))
			{
				m_cashObjects[value] = new Stack<CashObject>();
			}
		}

		private void OnGetClientCash()
		{
			SetRandomCashAmount();
			m_tookCash = true;
			CurrentlyCheckingOutCharacter.ShowCash(show: false);
			m_interface.ShowChange();
			m_cashBox.Open(open: true);
			UpdateCashInputHint();
		}

		private void AddToChangeReturned(CashBoxElement cashBoxElement)
		{
			ECashAmount cashAmount = cashBoxElement.CashAmount;
			float amount = cashAmount.Value();
			CashRegisterTransaction.Current.AddToReturnedMoney(amount);
			m_interface.UpdateChangeReturned();
			CashObject component = UnityEngine.Object.Instantiate(m_cashObjectPrefabs[cashAmount].prefab, m_cashObjectPrefabs[cashAmount].spawnPoint).GetComponent<CashObject>();
			component.transform.position = GetCashSpawnPosition(cashAmount);
			m_cashObjects[cashAmount].Push(component);
			UpdateCashInputHint();
			CashRegisterWorkshop.OnAddChangeReturned?.Invoke(cashAmount);
			this.OnChangeReturned?.Invoke(cashAmount);
		}

		private void RemoveFromChangeReturned(ECashAmount cashAmount)
		{
			float num = cashAmount.Value();
			CashRegisterTransaction.Current.AddToReturnedMoney(0f - num);
			m_interface.UpdateChangeReturned();
			Stack<CashObject> cashObjects = GetCashObjects(cashAmount);
			UnityEngine.Object.Destroy(cashObjects.Pop().gameObject);
			UpdateCashInputHint();
			bool hasRemainingChange = cashObjects.Count > 0;
			CashRegisterWorkshop.OnRemoveChangeReturned?.Invoke(cashAmount, hasRemainingChange);
			this.OnChangeReturned?.Invoke(cashAmount);
		}

		private void SetRandomCashAmount()
		{
			if (UnityEngine.Random.value <= AIClientSettings.ProbabilityOfGivingExactAmountOfCashForPayment)
			{
				CashRegisterTransaction.Current.TakeExactMoney();
				return;
			}
			int random = AIClientSettings.MoneyReturnable.GetRandom();
			for (int i = random; !CashRegisterTransaction.Current.TakeMoney(i); i += random)
			{
			}
		}

		private void ClearCashObjects()
		{
			foreach (KeyValuePair<ECashAmount, Stack<CashObject>> cashObject in m_cashObjects)
			{
				Stack<CashObject> value = cashObject.Value;
				foreach (CashObject item in value)
				{
					UnityEngine.Object.Destroy(item.gameObject);
				}
				value.Clear();
			}
		}

		private Vector3 GetCashSpawnPosition(ECashAmount cashAmount)
		{
			Vector3 position = m_cashObjectPrefabs[cashAmount].spawnPoint.position;
			position.y += m_cashObjectPrefabs[cashAmount].prefab.Height * (float)GetCashObjects(cashAmount).Count;
			return position;
		}

		private Stack<CashObject> GetCashObjects(ECashAmount cashAmount)
		{
			return m_cashObjects[cashAmount];
		}

		private void UpdateCashInputHint()
		{
			if (!(m_inputHintPayment != null))
			{
				return;
			}
			CashRegisterTransaction transaction;
			bool flag = CashRegisterTransaction.HasCurrent(out transaction) && transaction.IsTransactionValid();
			m_inputHintPayment.enabled = flag;
			if (flag)
			{
				if (TransientManager<InputManager>.Instance.CurrentDevice == EInputDeviceType.GAMEPAD)
				{
					m_inputHintPayment.AddFlags(DeviceInputHint.EActionStates.GAMEPAD);
					m_inputHintPayment.RemoveFlagsAndRefreshInputHint(DeviceInputHint.EActionStates.KEYBOARD);
				}
				else
				{
					m_inputHintPayment.AddFlags(DeviceInputHint.EActionStates.KEYBOARD);
					m_inputHintPayment.RemoveFlagsAndRefreshInputHint(DeviceInputHint.EActionStates.GAMEPAD);
				}
			}
		}

		private void ValidatePayment()
		{
			if (CurrentlyCheckingOutCharacter != null && CashRegisterTransaction.HasCurrent(out var transaction) && m_checkedAllProducts && PaymentMethod == EPaymentMethod.CASH && m_tookCash)
			{
				if (transaction.IsTransactionValid())
				{
					OnCompleteCheckout(EPaymentMethod.CASH);
				}
				else
				{
					Debugger<EDebugCategory>.LogWarning(EDebugCategory.CASH_REGISTER, "Money returned amount is not correct, you returned " + CashRegisterTransaction.Current.MoneyReturned + " when you should return " + CashRegisterTransaction.Current.GetTotalMoneyToReturn(), 0);
				}
			}
		}

		private void ShowCardMachine(bool show)
		{
			if (m_cardMachine.IsActive != show)
			{
				if (show)
				{
					OnShowCardMachine();
				}
				else
				{
					OnHideCardMachine();
				}
				m_cardMachine.Show(show);
			}
		}

		private void OnShowCardMachine()
		{
			if (base.Controller.IsPlayer)
			{
				TransientManager<InputManager>.Instance.SetMap(InputManager.EMap.UI);
				m_cardMachineCamera.Priority = 1;
			}
		}

		private void OnHideCardMachine()
		{
			if (base.Controller.IsPlayer)
			{
				TransientManager<InputManager>.Instance.SetMap(InputManager.EMap.PLAYER);
				m_cardMachineCamera.Priority = 0;
			}
		}

		private void OnCardMachineValidated(float amount)
		{
			ShowCardMachine(show: false);
			CameraManager.PostBlendFinished += ValidateCardCheckoutPostBlend;
		}

		private void ValidateCardCheckoutPostBlend()
		{
			CameraManager.PostBlendFinished -= ValidateCardCheckoutPostBlend;
			OnCompleteCheckout(EPaymentMethod.CARD);
		}

		private void OnDeviceChanged(EInputDeviceType device)
		{
			UpdateCashInputHint();
		}

		private void OnProductInteracted(Product product)
		{
			CurrentlyCheckingOutCharacter.ShoppingBag.AddProduct(product);
			CashRegisterTransaction.Current.CheckProduct(product);
			m_interface.CheckProduct(product);
			m_productsToCheck.Remove(product);
			m_checkedProducts.Add(product);
			this.OnProductInteractedEvent?.Invoke(product);
			if (ItemsLeftToCheck == 0)
			{
				OnCheckedAllProducts();
			}
		}

		private void OnCheckedAllProducts()
		{
			switch (PaymentMethod)
			{
			case EPaymentMethod.CASH:
				CurrentlyCheckingOutCharacter.ShowCash(show: true);
				break;
			case EPaymentMethod.CARD:
				ShowCardMachine(show: true);
				break;
			case EPaymentMethod.PHONE:
				OnCompleteCheckout(EPaymentMethod.PHONE);
				break;
			}
			m_checkedAllProducts = true;
		}

		private void OnCompleteCheckout(EPaymentMethod paymentMethod)
		{
			float checkedProductsCost = CashRegisterTransaction.Current.CheckedProductsCost;
			m_checkedAllProducts = false;
			World.GameState.GainMoney(checkedProductsCost);
			World.GameState.TriggerXPRewardEvent(ESimulatorXPRewardEvent.CHECKOUT);
			foreach (Product checkedProduct in m_checkedProducts)
			{
				World.GameState.CheckoutProduct(checkedProduct);
			}
			CurrentlyCheckingOutCharacter.GetShoppingBagBack();
			CurrentlyCheckingOutCharacter = null;
			this.ClientCollected?.Invoke();
			CashRegisterWorkshop.ClientCheckedOut?.Invoke(m_checkedProducts, checkedProductsCost);
			CashRegisterTransaction.Clear();
			m_checkedProducts.Clear();
			m_productsToCheck.Clear();
			m_interface.Clear();
			m_cashBox.Open(open: false);
			ClearCashObjects();
			if (m_inputHintPayment != null)
			{
				m_inputHintPayment.enabled = false;
			}
			this.OnCompleteCheckoutEvent?.Invoke(paymentMethod);
		}

		public virtual void OnPlayerInput_Jump()
		{
			if (TransientManager<InputManager>.Instance.CurrentDevice == EInputDeviceType.KEYBOARD)
			{
				ValidatePayment();
			}
		}

		public void OnPlayerInput_Move(Vector3 moveInput)
		{
			if (!GameplayApplicationOptions.CashRegisterLockMovement && !(moveInput == Vector3.zero))
			{
				QuitWorkshop();
			}
		}

		public virtual void OnPlayerInput_Pause()
		{
			QuitWorkshop();
		}

		public virtual void OnPlayerInput_MainInteractTap(ISensable sensable)
		{
			if (sensable == null)
			{
				return;
			}
			if (!(sensable is Product product))
			{
				if (!(sensable is CashBoxElement cashBoxElement))
				{
					if (!(sensable is CashObject cashObject))
					{
						if (sensable is ClientCash)
						{
							OnGetClientCash();
						}
					}
					else
					{
						RemoveFromChangeReturned(cashObject.CashAmount);
					}
				}
				else
				{
					AddToChangeReturned(cashBoxElement);
				}
			}
			else
			{
				OnProductInteracted(product);
			}
		}

		public virtual void OnPlayerInput_SecondInteractTap(ISensable sensable)
		{
			if (sensable is CashBoxElement cashBoxElement && GetCashObjects(cashBoxElement.CashAmount).Count > 0)
			{
				RemoveFromChangeReturned(cashBoxElement.CashAmount);
			}
			if (sensable == null && TransientManager<InputManager>.Instance.CurrentDevice == EInputDeviceType.GAMEPAD)
			{
				ValidatePayment();
			}
		}

		public void OnPlayerInput_MainHoldProcessing(HoldInteraction holdInteraction, ISensable sensable)
		{
		}

		public void OnPlayerInput_MainHoldInteractStart(ISensable sensable)
		{
		}

		public void OnPlayerInput_MainHoldInteractStop(ISensable sensable)
		{
		}

		public void OnPlayerInput_MainHoldInteractCancel(ISensable sensable)
		{
		}

		public void OnPlayerInput_SecondHoldProcessing(HoldInteraction holdInteraction, ISensable sensable)
		{
		}

		public void OnPlayerInput_SecondHoldInteractStart(ISensable sensable)
		{
		}

		public void OnPlayerInput_SecondHoldInteractStop(ISensable sensable)
		{
		}

		public void OnPlayerInput_SecondHoldInteractCancel(ISensable sensable)
		{
		}

		public void OnPlayerInput_ThirdInteractTap(ISensable sensable)
		{
		}

		public void OnPlayerInput_NextDayHoldProcessing(HoldInteraction holdInteraction)
		{
		}

		public void OnPlayerInput_NextDayHoldStart()
		{
		}

		public void OnPlayerInput_NextDayHoldStop()
		{
		}

		public void OnPlayerInput_NextDayHoldCancel()
		{
		}

		public void OnPlayerInput_Crouch()
		{
		}

		public void OnPlayerInput_Look(Vector2 delta)
		{
		}

		public virtual void OnPlayerInput_SprintEnded()
		{
		}

		public virtual void OnPlayerInput_SprintStarted()
		{
		}

		public virtual void OnPlayerInput_Drop()
		{
		}

		public virtual void OnPlayerInput_Rotate(float rotateInput)
		{
		}

		public virtual void OnPlayerInput_OpenObject()
		{
		}

		public void OnLoseReceiver()
		{
		}

		protected override void OnControlledByPlayerPostBlend()
		{
			base.OnControlledByPlayerPostBlend();
			m_povCamera.SetEnable(enable: true);
		}

		public override void OnControlledBy(Controller controller)
		{
			base.OnControlledBy(controller);
			if (m_cardMachine.IsActive)
			{
				OnShowCardMachine();
			}
		}

		public override void OnUncontrolledBy(Controller controller)
		{
			base.OnUncontrolledBy(controller);
			m_povCamera.SetEnable(enable: false);
		}

		protected override bool CanQuitWorkshop()
		{
			return true;
		}

		protected override void OnQuitWorkshop()
		{
			base.OnQuitWorkshop();
			if (m_cardMachine.IsActive)
			{
				TransientManager<InputManager>.Instance.SetMap(InputManager.EMap.PLAYER);
				m_cardMachineCamera.Priority = 0;
			}
		}

		protected override void OnCameraDeactivated()
		{
			base.OnCameraDeactivated();
			RecenterCamera();
		}

		private void RecenterCamera()
		{
			m_povCamera.PanTilt.PanAxis.TriggerRecentering();
			m_povCamera.PanTilt.TiltAxis.TriggerRecentering();
		}

		private Vector3 GetRandomProductFallPosition()
		{
			Vector3 position = m_productsFallAnchor.position;
			return new Vector3(UnityEngine.Random.Range(-0.1f, 0.1f) + position.x, UnityEngine.Random.Range(-0.05f, 0.05f) + position.y, UnityEngine.Random.Range(-0.1f, 0.1f) + position.z);
		}
	}
}
