using Client;
using Factory;
using FixMath;
using Server;

public class Game : IControllerConnectionObserver, IReleasedFromScopeHandler
{
	[Dependency]
	protected IThemeDatabase _themeDatabase;

	[Dependency]
	protected ISimulation _simulation;

	[Dependency]
	protected IClient _view;

	private Fix64 _accumulatedTime = Fix64.Zero;

	protected TimeInterval _timeInterval = new TimeInterval();

	public static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("Game");

	[Dependency]
	public IScope Scope { get; private set; }

	public GameStartReason StartReason { get; private set; }

	public ISimulation Simulation => _simulation;

	public void Start(GameStartReason gameStartReason)
	{
		StartReason = gameStartReason;
		_themeDatabase.AddView(_view);
		_view.Start();
		_accumulatedTime = _simulation.Timestep;
	}

	public virtual void AddArbitraryAccumulatedTime(Fix64 additionalAccumulatedTime)
	{
		_accumulatedTime += additionalAccumulatedTime;
	}

	public virtual void OnGameStarted()
	{
		Scope.Get<IInputState>().SubscribeToControllerConnectionMessages(this);
	}

	public virtual void OnGameEnd(GameEndReason gameEndReason)
	{
		Scope.Get<IInputState>().UnsubscribeFromControllerConnectionMessages(this);
		Scope.Get<PlayerActionController>().GameEnded();
	}

	public virtual bool TrySave(GameJournalMotive motive)
	{
		return false;
	}

	public virtual void Tick(float frameTime)
	{
		_timeInterval.UnsyncedDelta = frameTime;
		_timeInterval.Delta = frameTime;
		AdjustTimeInterval(_timeInterval);
		_accumulatedTime += (Fix64)_timeInterval.UnpausedScaledDelta;
		while (_accumulatedTime >= _simulation.Timestep)
		{
			_simulation.Step();
			_accumulatedTime -= _simulation.Timestep;
		}
		float stepAlpha = (float)(_accumulatedTime / _simulation.Timestep);
		_view.Tick(_timeInterval, stepAlpha);
	}

	public virtual void SetPaused(bool isPaused)
	{
		Log.Info("{0} the simulation.", isPaused ? "Pausing" : "Resuming");
		_simulation.ScheduleCommand(SetPausedCommand.Create(Scope, isPaused));
		_timeInterval.IsPaused = isPaused;
	}

	public virtual void StopAudio()
	{
	}

	protected virtual void AdjustTimeInterval(TimeInterval timeInterval)
	{
	}

	public virtual void OnReleasedFromScope(IScope scope)
	{
		_themeDatabase.RemoveView(_view);
		StopAudio();
	}

	public virtual bool CanInteract()
	{
		return true;
	}

	public void OnControllerConnected(IController controller)
	{
		if (CanInteract())
		{
			controller.RegisterInputActionsForGame(Scope);
			controller.EnsureActionsAreRegistered(Scope);
		}
	}

	public void OnControllerDisconnected(IController controller)
	{
		if (typeof(IScopeObserver).IsAssignableFrom(controller.GetType()))
		{
			Scope.Unsubscribe((IScopeObserver)controller);
		}
	}

	public void SetTimeScale(TimeScale scale)
	{
		_timeInterval.Scale = scale;
	}

	public TimeScale GetTimeScale()
	{
		return _timeInterval.Scale;
	}
}
