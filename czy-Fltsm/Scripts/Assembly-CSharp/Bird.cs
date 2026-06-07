using System;
using I2.Loc;
using PajamaLlama.Debugs;
using PajamaLlama.Math;
using UnityEngine;

[RequireComponent(typeof(BirdMovement))]
public class Bird : ActorBehaviour, ISelectable, IPersistentReference, ITooltipProvider, IPanelContext, IOutlineRenderControllerProvider
{
	public enum BirdState
	{
		Idle = 0,
		Sleeping = 1,
		WaitingForFood = 2,
		Eating = 3,
		WaitingForItems = 4,
		GettingItem = 5,
		ReturningItem = 6,
		GoingToBirdhouse = 7,
		PerchingAround = 8,
		LeavingWorld = 9,
		CirclingTown = 10,
		LeavingBirdhouse = 11,
		PerchedOnBirdhouse = 12
	}

	[Space]
	[SerializeField]
	[Tooltip("Reference transform for carried item.")]
	private Transform _carriedItemParent;

	[Header("Timers")]
	[SerializeField]
	private Timer _eatingOffsetTimer = new Timer(0f, 1f);

	[SerializeField]
	private Timer _circlingTownTimer = new Timer(10f, 35f);

	[SerializeField]
	private Timer _perchingTimer = new Timer(200f, 900f);

	private Animator _animator;

	private WorldIconHandler _worldIconHandler;

	private OutlineRendererComponent _outlineRenderer;

	private BirdMovement _birdMovement;

	private FMODEventEmitter _fmodEventEmitter;

	private AttachableSlots _perchSpot;

	private static Timer _hungryAlertTimer;

	private static Timer _stuckTimer;

	private Vector3 _positionToCircle;

	private Vector3 _targetPerchablePosition;

	private Item _reservedItem;

	private Transform _carriedItemTransform;

	public BirdDescriptor Descriptor { get; protected set; }

	public BirdProperties Properties => Descriptor.Properties;

	public override string Name => Descriptor.Name;

	public BirdHouse BirdHouse { get; private set; }

	public bool CurrentlyEating { get; private set; }

	public float EatTimer { get; private set; }

	public bool ItemPickedUp { get; private set; }

	public Perchable TargetPerchable { get; private set; }

	public Vector3 OutsideWorldTarget { get; private set; }

	public int PortraitIndex { get; private set; }

	public bool CanBeRescued { get; private set; }

	public Inventory Inventory { get; private set; }

	public BirdState State { get; private set; }

	public bool IsFed { get; private set; }

	public bool IsLeaving => Happiness == 0;

	public SelectionLink SelectionLink { get; private set; }

	public int Happiness { get; private set; } = 4;

	public int HappinessMaxValue { get; private set; }

	public Sprite HappinessIcon { get; private set; }

	public Animator Animator => _animator;

	public int PersistentIndex { get; set; } = -1;

	public override PanelID PanelID => PanelID.AnimalPanel;

	public ObjectType ObjectType => ObjectType.Bird;

	public GameObject RelatedGameObject => base.gameObject;

	OutlineRenderController IOutlineRenderControllerProvider.OutlineController => GetComponentInChildren<OutlineRenderController>();

	private void Update()
	{
		ValidateBirdhouse();
		switch (State)
		{
		default:
			if (IsInPlayerCommunity() || !CanBeRescued)
			{
				ChangeAnimation(Activity.Sitting);
				break;
			}
			ChangeAnimation(Activity.Researching);
			if (_stuckTimer.CountDown())
			{
				AudioManager.Play(Properties.StuckAudio, base.transform);
				_stuckTimer.Reset();
			}
			break;
		case BirdState.PerchedOnBirdhouse:
			UpdateState();
			break;
		case BirdState.Sleeping:
			if (BirdHouse.State == BirdHouse.BirdHouseState.Sleeping)
			{
				ChangeAnimation(Activity.Sleeping);
				break;
			}
			_fmodEventEmitter.Stop();
			ChangeState(BirdState.WaitingForFood);
			break;
		case BirdState.GoingToBirdhouse:
			ChangeAnimation(Activity.Moving);
			if (_birdMovement.MoveTo(BirdHouse.BirdTarget.position))
			{
				ChangeState(BirdState.PerchedOnBirdhouse);
			}
			break;
		case BirdState.WaitingForFood:
			ChangeAnimation(Activity.Sitting);
			if (BirdHouse.State == BirdHouse.BirdHouseState.Sleeping)
			{
				ChangeState(BirdState.Sleeping);
			}
			if (BirdHouse.FoodStore > 0)
			{
				if (_eatingOffsetTimer.CountDown())
				{
					BirdHouse.ConsumeFood();
					IsFed = true;
					Happiness = HappinessMaxValue;
					_eatingOffsetTimer.Reset();
					ChangeState(BirdState.Eating);
				}
			}
			else if (_hungryAlertTimer.CountDown())
			{
				AudioManager.Play(Properties.HungryAudio, base.transform);
				_hungryAlertTimer.Reset();
			}
			break;
		case BirdState.Eating:
			ChangeAnimation(Activity.Eating);
			EatTimer += Time.deltaTime;
			if (EatTimer >= Properties.EatingDuration)
			{
				EatTimer = 0f;
				ChangeState(BirdState.PerchedOnBirdhouse);
			}
			break;
		case BirdState.WaitingForItems:
			ChangeAnimation(Activity.Sitting);
			if (BirdHouse.SalvageableItemAvailable(out _reservedItem))
			{
				ChangeState(BirdState.GettingItem);
			}
			else
			{
				UpdateState();
			}
			break;
		case BirdState.GettingItem:
			ChangeAnimation(Activity.Moving);
			Unperch();
			if (_reservedItem.Owner == null)
			{
				Debugger.Error($"Reserved item's owner was null for {Name}, resetting item.", this);
				_reservedItem = null;
			}
			else if (_birdMovement.MoveTo(_reservedItem.Owner.transform.position))
			{
				TransferItem(_reservedItem, _reservedItem.Inventory, Inventory, SubInventoryType.Storage);
				ItemPickedUp = true;
				ChangeState(BirdState.ReturningItem);
			}
			break;
		case BirdState.ReturningItem:
			ChangeAnimation(Activity.MovingWithItem);
			if (_birdMovement.MoveTo(BirdHouse.BirdTarget.position))
			{
				TransferItemToBirdhouse();
				UpdateState();
			}
			break;
		case BirdState.PerchingAround:
			if (_perchSpot == null)
			{
				if (TargetPerchable != null || FindAvailablePerchable())
				{
					ChangeAnimation(Activity.Moving);
					if (_birdMovement.MoveTo(_targetPerchablePosition))
					{
						ChangeAnimation(Activity.Sitting);
						_perchSpot = TargetPerchable.PerchSpots;
						_perchSpot.Attach(base.transform);
						_perchingTimer.Reset();
					}
				}
				else
				{
					ChangeState(BirdState.CirclingTown);
				}
			}
			else if (TimeManager.ReturnIsDayTime() && _perchingTimer.CountDown())
			{
				LeavePerchingSpot();
			}
			else
			{
				ChangeAnimation(Activity.Sitting);
			}
			break;
		case BirdState.LeavingWorld:
			ChangeAnimation(Activity.Moving);
			if (_birdMovement.MoveTo(OutsideWorldTarget))
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
			break;
		case BirdState.CirclingTown:
			ChangeAnimation(Activity.Moving);
			_birdMovement.CirclePoint(_positionToCircle);
			if ((_circlingTownTimer.CountDown() || !TimeManager.ReturnIsDayTime()) && FindAvailablePerchable())
			{
				ChangeState(BirdState.PerchingAround);
			}
			break;
		}
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.DayEnded, EndCycle);
		GameEventDispatcher.RemoveListener(GameEventType.BuildablePlaced, OnBuildablePlaced);
		if ((bool)TargetPerchable)
		{
			TargetPerchable.Deconstructed -= LeavePerchingSpot;
		}
		ClearBirdhouseListeners();
	}

	public void Initialize(BirdDescriptor descriptor, Community community, BirdPersistentData persistentData = null)
	{
		InitializeComponents();
		Descriptor = descriptor;
		if (_hungryAlertTimer == null)
		{
			_hungryAlertTimer = new Timer(Properties.HungryAudioCountdown.Minimum, Properties.HungryAudioCountdown.Maximum);
		}
		if (_stuckTimer == null)
		{
			_stuckTimer = new Timer(Properties.StuckAudioCountdown.Minimum, Properties.StuckAudioCountdown.Maximum);
		}
		_eatingOffsetTimer.Reset();
		Inventory.Initialize(Inventory.InventoryType);
		SelectionLink.SetObjectToSelect(base.gameObject, ObjectType.Bird);
		JoinCommunity(community, persistentData == null, persistentData != null);
		ApplyHappinessProperties();
		GameEventDispatcher.AddListener(GameEventType.BuildablePlaced, OnBuildablePlaced);
	}

	private void InitializeComponents()
	{
		Inventory = GetComponent<Inventory>();
		SelectionLink = GetComponentInChildren<SelectionLink>();
		_birdMovement = GetComponent<BirdMovement>();
		_animator = GetComponentInChildren<Animator>();
		_worldIconHandler = GetComponentInChildren<WorldIconHandler>(includeInactive: true);
		_outlineRenderer = GetComponent<OutlineRendererComponent>();
		_fmodEventEmitter = GetComponent<FMODEventEmitter>();
		Inventory.GetOrAddSubInventory(SubInventoryType.Storage, 1);
		_birdMovement.Initialize();
	}

	private void UpdateState()
	{
		if (!BirdHouse.Active && !ItemPickedUp)
		{
			ChangeState(BirdState.LeavingBirdhouse);
		}
		else if (BirdHouse.Moving && (State != BirdState.ReturningItem || _reservedItem == null) && _perchSpot == null)
		{
			ChangeState(BirdState.GoingToBirdhouse);
		}
		else if (BirdHouse.State == BirdHouse.BirdHouseState.Sleeping)
		{
			if (State == BirdState.PerchedOnBirdhouse)
			{
				ChangeState(BirdState.Sleeping);
			}
			else
			{
				ChangeState(BirdState.GoingToBirdhouse);
			}
		}
		else if (!IsFed)
		{
			ChangeState(BirdState.WaitingForFood);
		}
		else if (BirdHouse.SalvageableItemAvailable(out _reservedItem))
		{
			ChangeState(BirdState.GettingItem);
		}
		else if (State != BirdState.PerchedOnBirdhouse)
		{
			ChangeState(BirdState.GoingToBirdhouse);
		}
		else
		{
			ChangeState(BirdState.PerchedOnBirdhouse);
		}
	}

	private void ChangeState(BirdState birdState)
	{
		if (State != birdState)
		{
			State = birdState;
			switch (State)
			{
			case BirdState.Sleeping:
				ChangeAnimation(Activity.Sitting);
				TryToPerchOnBirdhouse();
				_fmodEventEmitter.Play(Properties.SleepingAudio);
				break;
			case BirdState.WaitingForFood:
			case BirdState.Eating:
			case BirdState.WaitingForItems:
			case BirdState.PerchedOnBirdhouse:
				ChangeAnimation(Activity.Sitting);
				TryToPerchOnBirdhouse();
				break;
			case BirdState.ReturningItem:
				ShowCarriedItem(_reservedItem);
				break;
			case BirdState.PerchingAround:
				UpdateHomelessIcon();
				UpdateBirdHousing();
				_perchingTimer.Reset();
				break;
			case BirdState.LeavingBirdhouse:
				LeaveBirdHouse();
				break;
			case BirdState.CirclingTown:
				_birdMovement.BegingCirclePoint();
				_circlingTownTimer.Reset();
				break;
			case BirdState.GettingItem:
			case BirdState.GoingToBirdhouse:
			case BirdState.LeavingWorld:
				break;
			}
		}
	}

	public void WorldStoppedMoving()
	{
		if (_perchSpot == null)
		{
			Reset();
			Vector3 position = base.transform.position;
			float num = Mathf.Clamp(base.transform.position.magnitude, 0f, GameManager.Settings.GameplaySettings.SwimmingRadius);
			base.transform.position = position.normalized * num;
		}
	}

	private void Reset()
	{
		if (State == BirdState.GettingItem && !ItemPickedUp)
		{
			ReleaseItem();
			ChangeState(BirdState.GoingToBirdhouse);
		}
	}

	public void JoinBirdHouse(BirdHouse birdHouse, bool restored = false)
	{
		if (birdHouse.AddBird(this))
		{
			SetBirdHouse(birdHouse);
			base.Community = BirdHouse.Buildable.Community;
			UpdateHomelessIcon();
			UpdateBirdHousing();
			ClearBirdhouseListeners();
			if (!restored)
			{
				Unperch();
				ChangeState(BirdState.GoingToBirdhouse);
			}
		}
	}

	public void LeaveBirdHouse(bool checkForNewBirdhouse = true)
	{
		BirdHouse.RemoveBird(this);
		SetBirdHouse(null);
		Unperch();
		ReleaseItem();
		ChangeState(BirdState.PerchingAround);
		if (checkForNewBirdhouse)
		{
			TryJoinBirdhouse();
			if (BirdHouse == null && IsInPlayerCommunity())
			{
				base.Community.BirdhousesUpdatedEvent += TryJoinBirdhouse;
			}
		}
	}

	public void JoinCommunity(Community community, bool showNotification = true, bool restored = false)
	{
		if (community == null)
		{
			return;
		}
		community.AddBird(this, showNotification);
		if (restored)
		{
			if (IsInPlayerCommunity())
			{
				if (BirdHouse == null)
				{
					community.BirdhousesUpdatedEvent += TryJoinBirdhouse;
					community.BirdsUpdatedEvent += TryJoinBirdhouse;
				}
				GameEventDispatcher.AddListener(GameEventType.DayEnded, EndCycle);
			}
		}
		else if (IsInPlayerCommunity())
		{
			if (FindAvailablePerchable())
			{
				ChangeState(BirdState.PerchingAround);
			}
			else
			{
				ChangeState(BirdState.CirclingTown);
			}
			TryJoinBirdhouse();
			UpdateBirdHousing();
			if (BirdHouse == null)
			{
				community.BirdhousesUpdatedEvent += TryJoinBirdhouse;
				community.BirdsUpdatedEvent += TryJoinBirdhouse;
			}
			GameEventDispatcher.AddListener(GameEventType.DayEnded, EndCycle);
		}
		else
		{
			ChangeState(BirdState.Idle);
		}
	}

	public void LeaveCommunity()
	{
		ClearBirdhouseListeners();
		GameEventDispatcher.RemoveListener(GameEventType.DayEnded, EndCycle);
		base.Community?.RemoveBird(this);
		UpdateHomelessIcon();
	}

	public void TryJoinBirdhouse()
	{
		if (BirdHouse != null)
		{
			ClearBirdhouseListeners();
			return;
		}
		BirdHouse birdHouse = null;
		foreach (BirdHouse birdHouse2 in base.Community.BirdHouses)
		{
			if (birdHouse2.HasVacancies())
			{
				if (birdHouse == null)
				{
					birdHouse = birdHouse2;
				}
				else if (Vector3.Distance(base.transform.position, birdHouse2.transform.position) < Vector3.Distance(base.transform.position, birdHouse.transform.position))
				{
					birdHouse = birdHouse2;
				}
			}
		}
		if (birdHouse != null)
		{
			JoinBirdHouse(birdHouse);
		}
		UpdateHomelessIcon();
	}

	private void UpdateHomelessIcon()
	{
		if (IsInPlayerCommunity() && BirdHouse == null)
		{
			_worldIconHandler.AddIcon(GameManager.Settings.AgentSettings.NoHousingIconProperties);
		}
		else
		{
			_worldIconHandler.RemoveIcon(GameManager.Settings.AgentSettings.NoHousingIconProperties);
		}
	}

	private void EndCycle(GameEvent gameEvent)
	{
		if ((bool)BirdHouse && IsFed)
		{
			IsFed = false;
			Happiness = HappinessMaxValue;
			return;
		}
		Happiness--;
		if (Happiness < 0)
		{
			SetFree();
		}
		new BirdEvent(GameEventType.BirdVitalsUpdated, this).Dispatch();
	}

	public void AskToFreeBird()
	{
		if (PopUpDialog.Instance.TryOpenPopUpDialog(GameManager.Settings.UISettings.FreeSeagullDialogProperties, null, this))
		{
			PopUpDialog.Instance.DialogFeedbackEvent.AddListener(SetFree);
		}
	}

	private void SetFree(bool setFree = true)
	{
		PopUpDialog.Instance.DialogFeedbackEvent.RemoveListener(SetFree);
		if (setFree)
		{
			if (State == BirdState.ReturningItem)
			{
				TransferItemToBirdhouse();
			}
			else if (State == BirdState.GettingItem)
			{
				ReleaseItem();
			}
			if (BirdHouse != null)
			{
				LeaveBirdHouse(checkForNewBirdhouse: false);
			}
			Happiness = 0;
			Unperch();
			LeaveCommunity();
			SendBirdAway();
			GameManager.UIManager.NotificationHandler.AddNotification(GameManager.Settings.UISettings.SeagullLeftNotification, base.gameObject, ObjectType.Bird);
		}
	}

	public void SendBirdAway()
	{
		if (OutsideWorldTarget == default(Vector3))
		{
			float num = GameManager.Settings.GameplaySettings.InteractionRadius + 20;
			Vector2 vector = UnityEngine.Random.insideUnitCircle.normalized * num;
			OutsideWorldTarget = vector.Vector3TopDown().SetY(20f);
		}
		ChangeState(BirdState.LeavingWorld);
	}

	public void UpdateBirdHousing()
	{
		if (!IsInPlayerCommunity())
		{
			return;
		}
		int num = 0;
		foreach (BirdHouse birdHouse in base.Community.BirdHouses)
		{
			num += birdHouse.BirdCapacity;
		}
	}

	private void TransferItemToBirdhouse()
	{
		if (_reservedItem != null)
		{
			AudioManager.Play(Properties.ItemDropAudio, base.transform);
			TransferItem(_reservedItem, Inventory, BirdHouse.Buildable.Inventory, SubInventoryType.Storage);
			BirdHouse.ReleaseItem(_reservedItem);
			_reservedItem = null;
		}
		else
		{
			Debug.LogException(new Exception($"Bird '{Descriptor.Name}' in state '{State}' is unable to TransferItemToBirdhouse. _reservedItem == null"));
		}
		ItemPickedUp = false;
		ShowCarriedItem(null);
	}

	private void TransferItem(Item item, InventoryBase from, InventoryBase to, SubInventoryType subInventory)
	{
		if (item != null)
		{
			Item item2 = from.TakeItem(item);
			if (item2 != item)
			{
				Debug.LogWarning("Transfer item and taken item mismatch!");
			}
			if (!to.AddItem(item2, subInventory))
			{
				Debug.LogWarning("Unable to add item to target inventory");
			}
		}
		else
		{
			Debug.LogException(new Exception($"Bird '{Descriptor.Name}' in state '{State}' is transferring a null reference"));
		}
	}

	private void ShowCarriedItem(Item item)
	{
		if (item == null && _carriedItemTransform != null)
		{
			UnityEngine.Object.Destroy(_carriedItemTransform.gameObject);
			_carriedItemTransform = null;
		}
		else if (item != null && _carriedItemTransform == null)
		{
			_carriedItemTransform = UnityEngine.Object.Instantiate(item.Properties.StorageVisualPrefab, _carriedItemParent).transform;
		}
	}

	private void ReleaseItem()
	{
		if (_reservedItem != null)
		{
			if (_reservedItem.Inventory == Inventory)
			{
				Debugger.Warning("Releasing item that the bird is already carrying.");
			}
			BirdHouse.ReleaseItem(_reservedItem);
			_reservedItem = null;
		}
	}

	public override void Rescue(Project project, Boat rescueBoat)
	{
		JoinCommunity(Community.PlayerCommunity);
		new BirdEvent(GameEventType.BirdRescue, this).Dispatch();
	}

	private void ChangeAnimation(Activity activity)
	{
		if (_animator.GetInteger("Activity") != (int)activity)
		{
			_animator.SetInteger("Activity", (int)activity);
			_animator.SetFloat("Offset", UnityEngine.Random.Range(0f, 1f));
		}
	}

	private void TryToPerchOnBirdhouse()
	{
		if (BirdHouse != null && _perchSpot != BirdHouse.PerchSpots)
		{
			_perchSpot = BirdHouse.PerchSpots;
			_perchSpot.Attach(base.transform);
		}
	}

	private void Unperch()
	{
		if (_perchSpot != null)
		{
			_perchSpot.Detach(base.transform, null);
			_perchSpot = null;
		}
		if (TargetPerchable != null)
		{
			TargetPerchable.PerchSpots.Unreserve(base.transform);
			TargetPerchable.Deconstructed -= LeavePerchingSpot;
			TargetPerchable = null;
		}
	}

	private void ValidateBirdhouse()
	{
		if (!(BirdHouse == null) && !BirdHouse.Active && State != BirdState.GettingItem && State != BirdState.ReturningItem)
		{
			UpdateState();
		}
	}

	private void ClearBirdhouseListeners()
	{
		if (base.Community != null)
		{
			base.Community.BirdhousesUpdatedEvent -= TryJoinBirdhouse;
			base.Community.BirdsUpdatedEvent -= TryJoinBirdhouse;
		}
	}

	public void SetBirdHouse(BirdHouse birdHouse)
	{
		if (BirdHouse != birdHouse)
		{
			BirdHouse = birdHouse;
			ApplyHappinessProperties();
			new BirdEvent(GameEventType.BirdHouseUpdated, this).Dispatch();
		}
	}

	private void ApplyHappinessProperties()
	{
		if ((bool)BirdHouse)
		{
			HappinessMaxValue = Properties.CyclesAllowedWithoutFood;
			HappinessIcon = Properties.FoodIcon;
		}
		else
		{
			HappinessMaxValue = Properties.CyclesAllowedWithoutHousing;
			HappinessIcon = Properties.HousingIcon;
		}
		Happiness = HappinessMaxValue;
	}

	public void OnUnderCursor()
	{
		if (IsInPlayerCommunity())
		{
			CursorManager.SetCursorState(CursorState.Select);
		}
		else
		{
			CursorManager.SetCursorState(CursorState.Rescue);
		}
	}

	public void OnShowTooltip()
	{
		if (IsInPlayerCommunity())
		{
			TooltipPanel.ShowTooltip(this);
		}
	}

	public void OnSelected(bool playSelectionSound)
	{
		GameManager.UIManager.DisplayPanel(this);
	}

	public void OnDeselected()
	{
		GameManager.UIManager.CloseDrifterPanel();
		_outlineRenderer.ResetHighlightOutline();
	}

	public string GetTooltip(TooltipBuilder tooltipBuilder)
	{
		return Name;
	}

	public void Restore(BirdPersistentData data)
	{
		IsFed = data.Fed;
		CurrentlyEating = data.CurrentlyEating;
		EatTimer = data.EatTimer;
		ItemPickedUp = data.ItemPickedUp;
		OutsideWorldTarget = data.OutsideWorldTarget;
		PortraitIndex = data.PortraitIndex;
		SetBirdHouse(data.Birdhouse);
		Happiness = Mathf.Clamp(data.Happiness, 0, HappinessMaxValue);
		data.Inventory?.Restore(Inventory, base.gameObject);
		_reservedItem = data.ReservedItem;
		ChangeState(data.State);
	}

	public void PopulateReferences(BirdPersistentData data)
	{
		if (BirdHouse != null)
		{
			data.Birdhouse = BirdHouse;
		}
		if (_reservedItem != null)
		{
			data.ReservedItem = _reservedItem;
		}
	}

	public IconProperties ReturnStateIcon()
	{
		switch (State)
		{
		default:
			return GameManager.Settings.AgentSettings.SeagullIdleIconProperties;
		case BirdState.Eating:
			return GameManager.Settings.AgentSettings.SeagullEatingIconProperties;
		case BirdState.GettingItem:
		case BirdState.ReturningItem:
			return GameManager.Settings.AgentSettings.SeagullSalvagingIconProperties;
		case BirdState.Sleeping:
			return GameManager.Settings.AgentSettings.SeagullSleepingIconProperties;
		case BirdState.GoingToBirdhouse:
			return GameManager.Settings.AgentSettings.SeagullMovingIconProperties;
		case BirdState.WaitingForFood:
			return GameManager.Settings.AgentSettings.SeagullHungryIconProperties;
		}
	}

	public IconProperties ReturnHappinessIcon()
	{
		if (Happiness <= 0)
		{
			return GameManager.Settings.AgentSettings.SeagullUnhappyIconProperties;
		}
		if (Happiness < HappinessMaxValue)
		{
			return GameManager.Settings.AgentSettings.SeagullNormalIconProperties;
		}
		return GameManager.Settings.AgentSettings.SeagullHappyIconProperties;
	}

	public LocalizedString ReturnTaskDescription()
	{
		switch (State)
		{
		default:
			return Properties.IdleStateDescription;
		case BirdState.Sleeping:
			return Properties.SleepingStateDescription;
		case BirdState.WaitingForFood:
			return Properties.WaitingForFoodStateDescription;
		case BirdState.Eating:
			return Properties.EatingStateDescription;
		case BirdState.WaitingForItems:
			return Properties.WaitingForItemStateDescription;
		case BirdState.GettingItem:
		case BirdState.ReturningItem:
			return Properties.SalvagingStateDescription;
		case BirdState.GoingToBirdhouse:
			return Properties.ReturningToTownStateDescription;
		case BirdState.LeavingWorld:
			return Properties.LeavingWorldStateDescription;
		}
	}

	private bool FindAvailablePerchable()
	{
		if (Perchable.TryReturnClosestPerchable(base.transform.position, out var closestPerchable) && closestPerchable.PerchSpots.Reserve(base.transform, out _targetPerchablePosition))
		{
			TargetPerchable = closestPerchable;
			TargetPerchable.Deconstructed += LeavePerchingSpot;
			return true;
		}
		return false;
	}

	private void LeavePerchingSpot()
	{
		Unperch();
		ChangeState(BirdState.CirclingTown);
		_positionToCircle = base.transform.position;
	}

	private void OnBuildablePlaced(GameEvent gameEvent)
	{
		if (State == BirdState.PerchingAround && _perchSpot != null && gameEvent is BuildableEvent buildableEvent && buildableEvent.Buildable.transform.position.IsInRange(base.transform.position, Properties.ScaredDistance))
		{
			LeavePerchingSpot();
		}
	}
}
