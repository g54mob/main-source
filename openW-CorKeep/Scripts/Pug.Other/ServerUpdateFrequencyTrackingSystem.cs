using Unity.Entities;
using UnityEngine;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(InitializationSystemGroup))]
public class ServerUpdateFrequencyTrackingSystem : SystemBase
{
	private const float LogIntervalSeconds = 60f;

	private const float MinAcceptableUpdatesPerSecond = 20f;

	private const float FrameTimeToleranceSeconds = 0.005f;

	private const float MaxAcceptableFrameTimeSeconds = 0.055f;

	private const int SlowFrameThreshold = 10;

	private int _totalFrames;

	private int _slowFrameCount;

	private float _worstFrameTime;

	private double _intervalStartTime;

	private bool _firstIntervalSkipped;

	[Preserve]
	protected override void OnCreate()
	{
		base.OnCreate();
		_firstIntervalSkipped = false;
		ResetCounters();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		float deltaTime = base.CheckedStateRef.WorldUnmanaged.Time.DeltaTime;
		_totalFrames++;
		if (deltaTime > 0.055f)
		{
			_slowFrameCount++;
			if (deltaTime > _worstFrameTime)
			{
				_worstFrameTime = deltaTime;
			}
		}
		double num = base.CheckedStateRef.WorldUnmanaged.Time.ElapsedTime - _intervalStartTime;
		if (num >= 60.0)
		{
			if (!_firstIntervalSkipped)
			{
				_firstIntervalSkipped = true;
			}
			else if (_slowFrameCount >= 10)
			{
				Debug.LogWarning("[ServerUpdateFrequencyTracker] Server performance warning: " + $"{_slowFrameCount} out of {_totalFrames} host frames exceeded the " + $"{55f:F0}ms frame budget " + $"({20f:F0} updates/s) in the last {num:F0}s. " + $"Worst frame: {_worstFrameTime * 1000f:F1}ms. " + "When the host cannot keep up with the target update rate, clients may experience extreme rubber banding, desynchronization, and other gameplay issues. Possible causes and suggestions: (1) The host machine may not be powerful enough — try hosting on a more powerful machine. (2) If you have mods installed, try disabling or uninstalling them to see if performance improves. (3) If this log contains other errors, those errors may be contributing to the slowdown — resolving them could help.");
			}
			ResetCounters();
		}
	}

	private void ResetCounters()
	{
		_totalFrames = 0;
		_slowFrameCount = 0;
		_worstFrameTime = 0f;
		_intervalStartTime = base.CheckedStateRef.WorldUnmanaged.Time.ElapsedTime;
	}

	[Preserve]
	public ServerUpdateFrequencyTrackingSystem()
	{
	}
}
