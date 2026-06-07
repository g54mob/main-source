using System.Collections.Generic;
using Factory;
using Factory.Pools;

public abstract class PlayerAction : IReusable
{
	public enum ObserverGreediness
	{
		AllowsNewActions = 0,
		BlocksNewActions = 1
	}

	public enum State
	{
		None = 0,
		Initialized = 1,
		Begun = 2,
		Cancelled = 3,
		Complete = 4
	}

	public static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("Action");

	[Dependency]
	protected InputState _inputState;

	[Dependency]
	protected PlayerActionController _actionController;

	private List<InputEventFilter> _inputFiltersToBlockNewActions = new List<InputEventFilter>();

	private List<InputEventFilter> _observedInputEventFilters = new List<InputEventFilter>();

	protected PlayerActionGroup _owningGroup;

	public float timeCreated;

	public virtual bool IsInterruptible => false;

	[Dependency]
	public IScope Scope { get; protected set; }

	public PlayerActionGroup OwningGroup
	{
		get
		{
			return _owningGroup;
		}
		set
		{
			_owningGroup = value;
		}
	}

	public State ActionState { get; protected set; }

	public InputEventSource InputSourceType => _owningGroup.InstigatingInputEvent.Source;

	public bool IsExclusive => OwningGroup.IsActionExclusive(this);

	public virtual void InitializeAction(PlayerActionGroup owningGroup, float timestamp)
	{
		OwningGroup = owningGroup;
		Diagnostics.Verify(owningGroup.AddAction(this), "Action {0} was not added to its owning group.", this);
		ActionState = State.Initialized;
	}

	public virtual void OnActionBegin(float timestamp)
	{
		timeCreated = timestamp;
		ActionState = State.Begun;
	}

	public virtual void OnActionComplete()
	{
		OwningGroup.RemoveAction(this);
		ActionState = State.Complete;
		ClearInputObserveFilters();
	}

	public virtual void OnActionCancel()
	{
		OwningGroup.RemoveAction(this);
		ActionState = State.Cancelled;
		ClearInputObserveFilters();
	}

	protected void ClearInputObserveFilters()
	{
		_observedInputEventFilters.Clear();
		_inputFiltersToBlockNewActions.Clear();
	}

	public virtual void Tick(float frameTime)
	{
	}

	public void MakeExclusive()
	{
		OwningGroup.MakeActionExclusive(this);
	}

	public bool ObservesInputEvent(InputEvent inputEvent)
	{
		foreach (InputEventFilter observedInputEventFilter in _observedInputEventFilters)
		{
			if (observedInputEventFilter.MatchesEvent(inputEvent))
			{
				return true;
			}
		}
		return false;
	}

	public bool BlocksNewActionsForInputEvent(InputEvent inputEvent)
	{
		foreach (InputEventFilter inputFiltersToBlockNewAction in _inputFiltersToBlockNewActions)
		{
			if (inputFiltersToBlockNewAction.MatchesEvent(inputEvent))
			{
				return true;
			}
		}
		return false;
	}

	protected void RegisterObserveInputEvent(InputEventFilter eventToObserve, ObserverGreediness inputGreediness)
	{
		if (!_observedInputEventFilters.Contains(eventToObserve))
		{
			_observedInputEventFilters.Add(eventToObserve);
			if (inputGreediness == ObserverGreediness.BlocksNewActions)
			{
				_inputFiltersToBlockNewActions.Add(eventToObserve);
			}
		}
	}

	public virtual void ObserveInput(float timestamp, InputEvent inputEvent, bool overUI)
	{
	}

	public virtual void Reset()
	{
		_owningGroup = null;
		timeCreated = 0f;
		_inputFiltersToBlockNewActions.Clear();
		_observedInputEventFilters.Clear();
		ActionState = State.None;
	}
}
