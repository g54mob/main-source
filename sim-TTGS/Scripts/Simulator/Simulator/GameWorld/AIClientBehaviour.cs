using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace Simulator.GameWorld
{
	public class AIClientBehaviour : AIBehaviour
	{
		[SerializeField]
		[ReadOnly(false, false)]
		private EClientState m_clientState;

		[SerializeField]
		[ReadOnly(false, false)]
		private int m_maxProductToBuy;

		[SerializeField]
		[ReadOnly(false, false)]
		private float m_maxMoneyToSpend;

		[SerializeField]
		[ReadOnly(false, false)]
		private int m_maxStandToVisit;

		private ClientCharacter m_clientCharacter;

		protected List<Vector2Int> m_visitedStands;

		protected int m_currentBuyIterationLeft;

		public ClientCharacter ClientCharacter => m_clientCharacter;

		public bool InsideShop { get; private set; }

		public EClientState ClientState
		{
			get
			{
				return m_clientState;
			}
			protected set
			{
				m_clientState = value;
			}
		}

		public int MaxProductToBuy
		{
			get
			{
				return m_maxProductToBuy;
			}
			private set
			{
				m_maxProductToBuy = value;
			}
		}

		public int MaxStandToVisit
		{
			get
			{
				return m_maxStandToVisit;
			}
			private set
			{
				m_maxStandToVisit = value;
			}
		}

		public float MaxMoneyToSpend
		{
			get
			{
				return ScoreSettings.MaxMoneyToSpendOnScoreChanged.GetComputedValue(m_maxMoneyToSpend);
			}
			private set
			{
				m_maxMoneyToSpend = value;
			}
		}

		public override void Init(int id)
		{
			base.Init(id);
			base.NavAgent.transform.SetPositionAndRotation(base.Controller.Controllable.Position, base.Controller.Controllable.Rotation);
			DetermineWhetherToEnterShop();
			InitNavAgent();
		}

		public override void Load(int phase, AISaveState state)
		{
			if (phase == 1)
			{
				base.NavAgent.transform.SetPositionAndRotation(state.position, state.rotation);
				InitNavAgent();
				if (state is SaveClass_Clients.ClientState clientState)
				{
					InsideShop = clientState.insideShop;
					if (InsideShop)
					{
						World.Shop.ClientEnter(this);
					}
					ClientState = clientState.clientState;
					if (clientState.shoppingBagContent.IsValid())
					{
						ClientCharacter.ShoppingBag.Fill(clientState.shoppingBagContent);
					}
					else if (ClientState == EClientState.CHECKING_OUT)
					{
						ClientCharacter.ShoppingBag.Show();
					}
					MaxProductToBuy = clientState.maxProductToBuy;
					MaxMoneyToSpend = clientState.maxMoneyToSpend;
					m_visitedStands = new List<Vector2Int>(clientState.visitedStands);
					ClientCharacter.ShoppingBag.transform.SetPositionAndRotation(clientState.shoppingBagPosition, clientState.shoppingBagRotation);
					m_currentBuyIterationLeft = clientState.currentBuyIterationLeft;
				}
			}
			base.Load(phase, state);
		}

		protected virtual void DetermineWhetherToEnterShop()
		{
			float num = World.ClientManager.EnteringShopPercentage;
			if (World.Shop.ContainsSameModel(ClientCharacter))
			{
				num = -1f;
			}
			if (Random.value < num)
			{
				GoToShop();
			}
			else
			{
				GoAutoDestroy();
			}
		}

		protected virtual void InitNavAgent()
		{
			base.NavAgent.speed = AIClientSettings.Speed;
			base.NavAgent.acceleration = AIClientSettings.Acceleration;
			base.NavAgent.angularSpeed = AIClientSettings.AngularSpeed;
			base.NavAgent.avoidancePriority = Random.Range(0, 50);
			base.NavAgent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
		}

		public virtual SaveClass_Clients.ClientState GetSaveClientState()
		{
			return new SaveClass_Clients.ClientState(this, m_clientCharacter)
			{
				visitedStands = ((m_visitedStands != null) ? new List<Vector2Int>(m_visitedStands) : null),
				currentBuyIterationLeft = m_currentBuyIterationLeft
			};
		}

		protected void GoToShop()
		{
			base.Destination = World.AINavigation.GetShopDoorOutsidePoint();
			base.State = EAIBehaviourState.WALKING;
			ClientState = EClientState.GOING_TO_SHOP;
		}

		protected virtual void OnArriveToShop()
		{
			if (!TimeController.IsDay || !World.Shop.CanAcceptNewClient(ClientCharacter))
			{
				GoAutoDestroy();
				return;
			}
			if (World.Shop.HasSpaceForNewClient())
			{
				EnterShop();
				return;
			}
			World.Shop.AddClientToQueue(this);
			ClientState = EClientState.WAITING_TO_ACCESS_SHOP;
			WaitFor(AIClientSettings.WaitInFrontOfShopTime.GetRandomInRange());
		}

		public void EnterShop()
		{
			base.Destination = World.AINavigation.GetShopDoorInsidePoint();
			base.State = EAIBehaviourState.WALKING;
			ClientState = EClientState.ENTERING_SHOP;
		}

		private void OnEnterShop()
		{
			World.Shop.ClientEnter(this);
			InitShoppingPlan();
			GoToNextStand();
			InsideShop = true;
		}

		protected void GoToExit()
		{
			base.Destination = World.AINavigation.GetShopDoorOutsidePoint();
			base.State = EAIBehaviourState.WALKING;
			ClientState = EClientState.GOING_TO_EXIT;
		}

		protected void ExitShop()
		{
			World.Shop.ClientExit(this, 50);
			InsideShop = false;
			GoAutoDestroy();
		}

		protected virtual void OnCouldNotAccessShop()
		{
			GoAutoDestroy();
		}

		public void GoAutoDestroy()
		{
			NavigationPoint randomSpawnPoint;
			do
			{
				randomSpawnPoint = World.AINavigation.GetRandomSpawnPoint();
			}
			while (Vector3.Distance(base.NavAgent.transform.position, randomSpawnPoint.Position) < 5f);
			base.Destination = randomSpawnPoint;
			base.State = EAIBehaviourState.WALKING;
			ClientState = EClientState.GOING_TO_AUTODESTROY;
		}

		protected override void OnEntersDestination()
		{
			base.OnEntersDestination();
			switch (ClientState)
			{
			case EClientState.GOING_TO_SHOP:
				OnArriveToShop();
				break;
			case EClientState.ENTERING_SHOP:
				OnEnterShop();
				break;
			case EClientState.GOING_TO_EXIT:
				ExitShop();
				break;
			case EClientState.GOING_TO_AUTODESTROY:
				World.ClientManager.DestroyClient(this);
				break;
			}
		}

		protected override void OnStopAtDestination()
		{
			base.OnStopAtDestination();
			switch (ClientState)
			{
			case EClientState.GOING_TO_PLACE_IN_STAND_LINE:
				base.State = EAIBehaviourState.WAITING_IN_LINE;
				break;
			case EClientState.GOING_TO_STAND_PLACE:
				ArriveAtStand();
				break;
			}
		}

		protected override void OnBlockedFromDestination()
		{
			base.OnBlockedFromDestination();
			if (!InsideShop)
			{
				GoAutoDestroy();
			}
			else if (ClientCharacter.ShoppingBag.ContentCount == 0)
			{
				if (base.CurrentStand != null)
				{
					QuitCurrentStandWithoutCallback();
				}
				GoToExit();
			}
			else
			{
				QuitCurrentStandWithoutComplete();
			}
		}

		protected override void OnFinishedWaiting()
		{
			base.OnFinishedWaiting();
			if (ClientState == EClientState.WAITING_TO_ACCESS_SHOP)
			{
				OnCouldNotAccessShop();
			}
		}

		protected override void OnActivityCompleted()
		{
			base.OnActivityCompleted();
			switch (ClientState)
			{
			case EClientState.BROWSING_SHELF:
				if (base.CurrentStand is ShelfStand shelfStand)
				{
					BuyFromShelfStand(shelfStand);
				}
				else
				{
					CompleteCurrentStand();
				}
				break;
			case EClientState.KILLING_TIME:
				CompleteCurrentStand();
				break;
			}
		}

		protected void InitShoppingPlan()
		{
			m_visitedStands = new List<Vector2Int>();
			MaxMoneyToSpend = AIClientSettings.MaxMoneyToSpend;
			MaxProductToBuy = AIClientSettings.MaxProductToBuy;
			MaxStandToVisit = AIClientSettings.MaxStandToVisit;
		}

		protected virtual bool CanStillShop()
		{
			if (ClientCharacter.ShoppingBag.ContentCount < MaxProductToBuy && ClientCharacter.ShoppingBag.GetContentValue() < MaxMoneyToSpend)
			{
				return m_visitedStands.Count < MaxStandToVisit;
			}
			return false;
		}

		public override void OnWaitInStandLine(Stand stand, NavigationPoint destination, int queueIndex)
		{
			base.OnWaitInStandLine(stand, destination, queueIndex);
			base.Destination = destination;
			base.State = EAIBehaviourState.WALKING;
			ClientState = EClientState.GOING_TO_PLACE_IN_STAND_LINE;
		}

		public override void OnAccessStand(Stand stand, NavigationPoint destination, int placeIndex)
		{
			base.OnAccessStand(stand, destination, placeIndex);
			base.Destination = destination;
			base.State = EAIBehaviourState.WALKING;
			ClientState = EClientState.GOING_TO_STAND_PLACE;
		}

		protected override void OnArriveAtStand(Stand stand)
		{
			switch (base.CurrentStand.Type)
			{
			case EStandType.CHECKOUT:
				base.State = EAIBehaviourState.ACTIVE;
				ClientState = EClientState.CHECKING_OUT;
				break;
			case EStandType.SHELF:
				if (CanStillShop() && base.CurrentStand is ShelfStand shelfStand && InitShelfStandBuyProcess(shelfStand))
				{
					ClientState = EClientState.BROWSING_SHELF;
					DoActivityFor(AIClientSettings.WaitBetweenBuy);
				}
				else
				{
					ClientState = EClientState.KILLING_TIME;
					DoActivityFor(AIClientSettings.WaitWithoutBuy);
				}
				break;
			}
		}

		protected override void OnQuitStand(Stand stand, bool completed)
		{
			base.OnQuitStand(stand, completed);
			if (completed && stand.Type == EStandType.CHECKOUT)
			{
				OnCheckedOut();
			}
			else
			{
				GoToNextStand();
			}
		}

		protected override void OnCurrentStandActivated(bool active)
		{
			base.OnCurrentStandActivated(active);
			if (active)
			{
				base.Destination = base.CurrentStand.GetDestination(this);
			}
			if (!active && base.CurrentStand.Type == EStandType.SHELF)
			{
				QuitCurrentStandWithoutComplete();
			}
		}

		protected bool TryGetNextBuyStandToVisit(out Stand stand)
		{
			if (World.Shop.TryGetValidClientStandUnvisited(this, m_visitedStands, out stand))
			{
				return true;
			}
			stand = null;
			return false;
		}

		protected bool TryGetRandomBuyStand(out Stand stand)
		{
			if (World.Shop.TryGetAnyClientStand(out stand))
			{
				return true;
			}
			stand = null;
			return false;
		}

		protected void GoToNextStand()
		{
			Stand stand3;
			if (CanStillShop() && TryGetNextBuyStandToVisit(out var stand))
			{
				AccessStand(stand);
			}
			else if (ClientCharacter.ShoppingBag.ContentCount > 0)
			{
				Stand stand2;
				if (CanCheckout())
				{
					GoCheckout();
				}
				else if (TryGetRandomBuyStand(out stand2))
				{
					AccessStand(stand2);
				}
				else
				{
					GoCheckout();
				}
			}
			else if (!InsideShop && TryGetRandomBuyStand(out stand3))
			{
				AccessStand(stand3);
			}
			else
			{
				GoToExit();
			}
		}

		protected virtual bool InitShelfStandBuyProcess(ShelfStand shelfStand)
		{
			m_visitedStands.Add(shelfStand.ID);
			int num = 0;
			foreach (ShelfInteractable allShelfInteractable in shelfStand.GetAllShelfInteractables())
			{
				if (allShelfInteractable.HasBuyableProduct(out var productData) && (!productData.BuyOnce || !ClientCharacter.ShoppingBag.Contains(productData.UID)))
				{
					num++;
				}
			}
			if (num > 0)
			{
				m_currentBuyIterationLeft = AIClientSettings.GetBuyIterations(World.Shop.GetValidClientStandCount());
				return true;
			}
			m_currentBuyIterationLeft = 0;
			return false;
		}

		protected virtual void BuyFromShelfStand(ShelfStand shelfStand)
		{
			List<ShelfInteractable> list = shelfStand.GetAllShelfInteractables().ToList();
			for (int num = list.Count - 1; num >= 0; num--)
			{
				if (!list[num].HasBuyableProduct(out var productData) || (productData.BuyOnce && ClientCharacter.ShoppingBag.Contains(productData.UID)))
				{
					list.RemoveAt(num);
				}
			}
			if (list.IsValid())
			{
				ShelfInteractable random = list.GetRandom();
				ProductData currentProduct = random.CurrentProduct;
				float productPrice = PriceManager.GetProductPrice(currentProduct.UID);
				float proba = currentProduct.BuyCoeff * AIClientSettings.GetBuyProductProbability(productPrice / PriceManager.GetProductMarketPrice(currentProduct.UID));
				bool flag = false;
				while (!flag && m_currentBuyIterationLeft > 0)
				{
					flag = BuyProductOnShelfInteractable(random, proba);
					m_currentBuyIterationLeft--;
				}
				if (m_currentBuyIterationLeft > 0 && CanStillShop())
				{
					DoActivityFor(AIClientSettings.WaitBetweenBuy + AIModelSettings.TakeProductAnimDuration);
					return;
				}
				ClientState = EClientState.KILLING_TIME;
				DoActivityFor(flag ? AIModelSettings.TakeProductAnimDuration : 0.05f);
			}
			else
			{
				CompleteCurrentStand();
			}
		}

		protected bool BuyProductOnShelfInteractable(ShelfInteractable shelfInteractable, float proba)
		{
			if (Random.value < proba)
			{
				base.Controller.InputReceiver.OnAIInput_SecondaryInteraction(shelfInteractable);
				ClientCharacter.PickUpProduct();
				return true;
			}
			return false;
		}

		protected virtual bool CanCheckout()
		{
			return World.Shop.GetCheckoutStand().CanAccess(this);
		}

		protected void GoCheckout()
		{
			AccessStand(World.Shop.GetCheckoutStand());
		}

		public EPaymentMethod GetPaymentMethod()
		{
			List<EPaymentMethod> list = new List<EPaymentMethod>();
			foreach (var (ePaymentMethod2, num2) in AIClientSettings.GetPaymentMethodsWeight())
			{
				if (World.Shop.IsPaymentMethodAvailable(ePaymentMethod2))
				{
					for (int i = 0; i < num2; i++)
					{
						list.Add(ePaymentMethod2);
					}
				}
			}
			return list[Random.Range(0, list.Count)];
		}

		protected virtual void OnCheckedOut()
		{
			GoToExit();
		}

		public override bool TakeControlOfCharacter(AICharacter character)
		{
			if (OnTakeControlOfCharacter(character))
			{
				m_clientCharacter = base.Character as ClientCharacter;
				return m_clientCharacter != null;
			}
			return false;
		}
	}
}
