using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class TickLoop
{
	public enum UpdateResult
	{
		Complete = 0,
		NotComplete = 1,
		Pause = 2
	}

	private bool playing;

	private ICollection<Module> executionSortedModules;

	private bool[] tickUpdateStatus;

	private float elapsedUpdateTime;

	private int tickNumber;

	private float fixedTimeStep;

	private Gadget gadget;

	private IEnumerator tickExecution;

	private Stopwatch deltaTimeStopwatch;

	private Stopwatch timeStopwatch;

	public float deltaTime { get; private set; }

	public float time { get; private set; }

	private float maxRunTime => 0f;

	public float ticksPerSecond
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public TickLoop(Gadget gadget, float ticksPerSecond)
	{
	}

	public void Start()
	{
	}

	public void Stop()
	{
	}

	public void Pause()
	{
	}

	public void Resume()
	{
	}

	public bool Update()
	{
		return false;
	}

	private IEnumerable ExecuteTick()
	{
		return null;
	}
}
