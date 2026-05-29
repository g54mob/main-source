using CTS.Core.Pooling;

namespace CTS.BBT.AI
{
	public class ActionHubDisposeBody : AgentHubAction
	{
		private readonly AgentActionPickUpBody _pickUpBodyAction;

		private readonly AgentActionPickUpBodyBag _pickUpBagAction;

		private readonly WorkerActionMorgueBodyDrop _morgueDropAction;

		private readonly AgentActionPickBodyBagFromMorgue _pickBagMorgue;

		private AgentAction _disposalAction;

		private bool _morgueFound;

		private StationMorgue _morgueSelected;

		private bool _machineFound;

		private IBodyDisposalMachine _machineSelected;

		public Customer Body { get; private set; }

		public DeadBodyData BodyData { get; private set; }

		public BodyBag BodyBag
		{
			get
			{
				return _pickUpBagAction.Bag;
			}
			set
			{
				_pickUpBagAction.Item = new PooledRef<Item>(value);
			}
		}

		public bool CanDropInMorgue => _morgueDropAction != null;

		public bool UseAssignation { get; set; }

		private ActionHubDisposeBody(bool allowMorgue)
		{
			if (allowMorgue)
			{
				_morgueDropAction = new WorkerActionMorgueBodyDrop(null);
				AddScoredAction(_morgueDropAction, CalculateScoreMorgue);
			}
		}

		public ActionHubDisposeBody(Customer customer, bool allowMorgue)
			: this(allowMorgue)
		{
			Body = customer;
			BodyData = new DeadBodyData(Body);
			_pickUpBodyAction = new AgentActionPickUpBody(customer);
			_pickUpBodyAction.OnActionCancelled += OnPickupBodyCancelled;
			BodyBag.WrappingInBodyBag += OnBodyBagWrapped;
			AddScoredAction(_pickUpBodyAction, CalculatePickUpBody);
			_pickUpBagAction = new AgentActionPickUpBodyBag(null);
			AddScoredAction(_pickUpBagAction, CalculatePickUpBodyBag);
		}

		public ActionHubDisposeBody(BodyBag bodyBag, bool allowMorgue)
			: this(allowMorgue)
		{
			BodyData = bodyBag.BodyData;
			_pickUpBagAction = new AgentActionPickUpBodyBag(bodyBag);
			AddScoredAction(_pickUpBagAction, CalculatePickUpBodyBag);
		}

		public ActionHubDisposeBody(StationMorgue morgue, DeadBodyData bodyData)
			: this(allowMorgue: false)
		{
			BodyData = bodyData;
			_pickUpBagAction = new AgentActionPickUpBodyBag(null);
			AddScoredAction(_pickUpBagAction, CalculatePickUpBodyBag);
			_pickBagMorgue = new AgentActionPickBodyBagFromMorgue(bodyData, morgue);
			_pickBagMorgue.BodyBagCreated += OnBodyBagCreated;
			AddScoredAction(_pickBagMorgue, CalculateGrabFromMorgue);
		}

		private void OnBodyBagCreated(BodyBag obj)
		{
			BodyBag = obj;
			_pickBagMorgue.BodyBagCreated -= OnBodyBagCreated;
			RemoveAction(_pickBagMorgue);
		}

		private void OnBodyBagWrapped(BodyBag bodyBag, Customer agent)
		{
			if (!(agent != Body))
			{
				BodyBag = bodyBag;
				BodyBag.WrappingInBodyBag -= OnBodyBagWrapped;
			}
		}

		private void OnPickupBodyCancelled(AgentAction obj)
		{
			if ((object)BodyBag != null)
			{
				if (_pickUpBodyAction.Body.ContextualFSM.CurrentState is ContextualStateDead contextualStateDead)
				{
					contextualStateDead.ClearChore();
				}
				RemoveAction(_pickUpBodyAction);
				_pickUpBodyAction.OnActionCancelled -= OnPickupBodyCancelled;
			}
		}

		protected override bool ShouldBeConsideredCompleted(Agent agent)
		{
			if (CanDropInMorgue && BodyData.IsInAnyMorgue())
			{
				return true;
			}
			if (!BodyBag)
			{
				return false;
			}
			return !BodyData.IsInAnyBodyBag();
		}

		protected override bool CanAnyActionBePerformed(Agent agent)
		{
			BodyBag bodyBag = BodyBag;
			if ((object)bodyBag != null && bodyBag.IsHeld && !agent.ObjectHolding.IsHolding(bodyBag))
			{
				return false;
			}
			if (agent is Worker worker && UseAssignation)
			{
				StationMorgue stationMorgue = BodyData.CurrentMorgue();
				if ((object)stationMorgue != null)
				{
					if (!stationMorgue.CanBodyBeDiscardedByWorker(BodyData, worker))
					{
						return false;
					}
				}
				else if ((bool)BodyBag)
				{
					if (!BodyBag.CanBeDiscardedInMachineByWorker(worker))
					{
						if (!CanDropInMorgue)
						{
							return false;
						}
						if (!BodyBag.CanBeDiscardedInMorgueByWorker(worker))
						{
							return false;
						}
					}
				}
				else if (!Body.CanBeDiscardedInMachineByWorker(worker))
				{
					if (!CanDropInMorgue)
					{
						return false;
					}
					if (!Body.CanBeDiscardedInMorgueByWorker(worker))
					{
						return false;
					}
				}
			}
			else if (BodyData.IsInAnyMorgue())
			{
				if (!_pickBagMorgue.Morgue.CanBodyBeDiscarded(BodyData))
				{
					return false;
				}
			}
			else if ((bool)BodyBag)
			{
				if (!BodyBag.CanBeDiscardedInMachine())
				{
					if (!CanDropInMorgue)
					{
						return false;
					}
					if (!BodyBag.CanBeDiscardedInMorgue())
					{
						return false;
					}
				}
			}
			else if (!Body.CanBeDiscardedInMachine())
			{
				if (!CanDropInMorgue)
				{
					return false;
				}
				if (!Body.CanBeDiscardedInMorgue())
				{
					return false;
				}
			}
			return base.CanAnyActionBePerformed(agent);
		}

		protected override void PreCheck(Agent agent)
		{
			base.PreCheck(agent);
			_machineFound = false;
			if (_morgueDropAction != null)
			{
				_morgueDropAction.Morgue = agent.GetNearestAvailableMorgue();
				_morgueSelected = _morgueDropAction.Morgue;
				_morgueFound = (object)_morgueSelected != null;
				if (_morgueFound)
				{
					return;
				}
			}
			if ((bool)BodyBag)
			{
				FindMachine();
			}
			void FindMachine()
			{
				IBodyDisposalMachine nearestBodyDisposalMachineInMorgueAssignation = BodyBag.GetNearestBodyDisposalMachineInMorgueAssignation();
				_machineFound = nearestBodyDisposalMachineInMorgueAssignation != null;
				if (nearestBodyDisposalMachineInMorgueAssignation != _machineSelected)
				{
					if (_disposalAction != null)
					{
						RemoveAction(_disposalAction);
						_disposalAction = null;
					}
					_machineSelected = nearestBodyDisposalMachineInMorgueAssignation;
					if (_machineSelected != null)
					{
						_disposalAction = _machineSelected.GetAction();
						AddScoredAction(_disposalAction, CalculateScoreDrop);
					}
				}
			}
		}

		private int CalculatePickUpBody(Agent agent)
		{
			if ((object)BodyBag == null)
			{
				return 100;
			}
			return -1;
		}

		private int CalculatePickUpBodyBag(Agent agent)
		{
			BodyBag bodyBag = BodyBag;
			if ((object)bodyBag == null)
			{
				return -1;
			}
			if (bodyBag.IsHeld)
			{
				return -1;
			}
			return 90;
		}

		private int CalculateScoreDrop(Agent agent)
		{
			BodyBag bodyBag = BodyBag;
			if ((object)bodyBag == null)
			{
				return -1;
			}
			if (!_machineFound)
			{
				return -1;
			}
			if (!_machineSelected.CanBeUsedToDisposeBody(agent, BodyData))
			{
				return -1;
			}
			if (!agent.ObjectHolding.IsHolding(bodyBag))
			{
				return -1;
			}
			return 130;
		}

		private int CalculateScoreMorgue(Agent agent)
		{
			BodyBag bodyBag = BodyBag;
			if ((object)bodyBag == null)
			{
				return -1;
			}
			if (!_morgueFound || _morgueSelected.IsFull)
			{
				return -1;
			}
			if (!agent.ObjectHolding.IsHolding(bodyBag))
			{
				return -1;
			}
			return 120;
		}

		private int CalculateGrabFromMorgue(Agent agent)
		{
			if ((object)BodyBag != null)
			{
				return -1;
			}
			StationMorgue stationMorgue = BodyData.CurrentMorgue();
			if ((object)stationMorgue == null)
			{
				return -1;
			}
			if (stationMorgue.DeadBodyCount < stationMorgue.MaxBodies)
			{
				return -1;
			}
			return 150;
		}
	}
}
