using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Gh.Tk
{
	public class Patron : Actor
	{
		public static HashSet<Patron> AllPatrons;

		[PersistenceOptIn]
		public bool hasVisitedTavernSign;

		[Header("Particles/Effects")]
		public GameObject Satisfaction_Plus;

		public GameObject Satisfaction_Minus;

		public GameObject Temperature_Cold;

		public GameObject Temperature_Hot;

		public GameObject payMoneyEffect;

		public GameObject hotheadEffect;

		private PatienceStat _patienceStat;

		[PersistenceOptIn]
		private bool _wasHotheadEffectVisible;

		private GameObject _hotheadParticleInstance;

		[PersistenceOptIn]
		public bool isExiting;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private IngredientTemplate _mainItemOrdered;

		[PersistenceOptIn]
		public int MainItemPrice;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private IngredientTemplate _sideItemOrdered;

		[PersistenceOptIn]
		public int SideItemPrice;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public GameItem Luggage;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public GameItem PersonalBelongings;

		public GameObject singingParticlePrefab;

		[PersistenceOptIn]
		private Dictionary<string, int> _entertainerListenCounts;

		private static int _listenTimesBeforeFeedback;

		protected override int DefaultComponentCollectionSize => 0;

		public new PatronData Data
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool IsCurrentlyVisiting => false;

		public float Patience
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool ShouldStayWhenTavernCloses => false;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public ActorBehaviour LastActiveBehaviour { get; private set; }

		[PersistenceOptIn]
		public bool IsOrderOnTheWay { get; set; }

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public bool WasHaggledSuccessfullyForPrice { get; set; }

		public IngredientTemplate MainItemOrdered
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public IngredientTemplate SideItemOrdered
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public bool SideItemDelivered { get; set; }

		public bool IsLeavingOrGoingToBed => false;

		public bool IsLeaving => false;

		[PersistenceOptIn]
		public float LastPlacateAttempt { get; set; }

		public void ToggleHotHeadEffectVisual(bool visible)
		{
		}

		public void LogItemPurchasedForTavernStats(Ingredient item)
		{
		}

		public void Buy(Ingredient mainItem, Ingredient sideItem)
		{
		}

		public int Pay(int price, string category, string reasonKey)
		{
			return 0;
		}

		public void PlayPayMoneyEffect(int amount)
		{
		}

		public void SetPatienceMeterValue(float value)
		{
		}

		public float GetPatienceMeterValue()
		{
			return 0f;
		}

		public override void Awake()
		{
		}

		public override void Start()
		{
		}

		private void UpdatePriorityVisual()
		{
		}

		public override void AbortAllJobs()
		{
		}

		protected override Job GetNextJob()
		{
			return null;
		}

		public override void Init()
		{
		}

		protected override void InitNavigation()
		{
		}

		public override void InvalidateActorModel()
		{
		}

		public void OnOrderRemoved()
		{
		}

		internal void CancelOrder()
		{
		}

		public FullfillOrder_Job GetOrder(string desire)
		{
			return null;
		}

		private IngredientTemplate SelectPreferredConsumable(string itemCategory, bool optional = false, string itemTypeRestriction = null)
		{
			return null;
		}

		public override void RestoreState(IDataStore data)
		{
		}

		public override void OnDestroy()
		{
		}

		public void AddLuggage()
		{
		}

		public void RemoveLuggage()
		{
		}

		public void AddPersonalBelongings()
		{
		}

		public void RemovePersonalBelongings()
		{
		}

		public void GoHomeOrGoToBed()
		{
		}

		public bool ShouldSleepInTavern()
		{
			return false;
		}

		public void FailAllNotDoneAIComponents()
		{
		}

		public void UpdatePreferredRoom()
		{
		}

		public void ReturnRoomKey()
		{
		}

		public void KickOut()
		{
		}

		private bool AreAllNonOptionalNeedsMet()
		{
			return false;
		}

		private bool TryCreateLeaveGiftBoxJob(out Job job)
		{
			job = null;
			return false;
		}

		internal override void RaiseAiComponentAddedEvent(AiComponent item)
		{
		}

		internal override void RaiseAiComponentRemovedEvent(AiComponent item)
		{
		}

		protected override void ChangeModel(string model)
		{
		}

		public override void MarkToDestroy()
		{
		}

		internal override void RestartAI(bool withRestartAnimation = true)
		{
		}

		public void GiveEntertainerFeedback(EntertainerProfile profile)
		{
		}

		private float CalculateAbsoluteFeedbackValue(float baseValue, int divergence)
		{
			return 0f;
		}

		private void CreateSatisfactionEffect(bool isPositive, bool largeEffect)
		{
		}

		public void RatePropOnFire()
		{
		}

		public void RateEvacuation()
		{
		}

		public void RateFireEscape()
		{
		}

		public void RateService()
		{
		}

		public void RateTavern()
		{
		}

		private void SaveSatisfactionDataToHistory()
		{
		}

		public void Rate(object target)
		{
		}

		private void RateIngredient(Ingredient ingredient)
		{
		}

		private void RateProp(Prop prop)
		{
		}

		public void RatePrice(Ingredient ingredient, SatisfactionStatBase stat = null)
		{
		}

		public void RatePrice(Prop prop)
		{
		}

		private int RatePrice(IPatronRatable target, StringBuilder details)
		{
			return 0;
		}

		public void RatePrice(Bed bed, SatisfactionStatBase stat)
		{
		}

		public float GenerateTotalRating(Prop target)
		{
			return 0f;
		}

		public int GetReaction(Entertainer entertainer)
		{
			return 0;
		}
	}
}
