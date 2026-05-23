#define ENABLE_DEBUG_WARNINGS
using Events;
using Unity.Jobs;
using UnityEngine;
using Utils;

public class ScheduleBatchedJobs : MonoBehaviour
{
	private const int JobManagersCount = 2;

	[SerializeField]
	private BaseEvent _cullingJobsScheduledEvent;

	[SerializeField]
	private BaseEvent _transformJobsScheduledEvent;

	private int _jobManagersCount = 2;

	private void Start()
	{
		_cullingJobsScheduledEvent.Register(OnJobsScheduled);
		_transformJobsScheduledEvent.Register(OnJobsScheduled);
	}

	private void OnDestroy()
	{
		_cullingJobsScheduledEvent.UnRegister(OnJobsScheduled);
		_transformJobsScheduledEvent.UnRegister(OnJobsScheduled);
	}

	private void LateUpdate()
	{
		if (_jobManagersCount != 2)
		{
			if (_jobManagersCount > 0)
			{
				this.LogWarning("Not all jobs were scheduled this frame. Please ensure each schedule event is called every frame even if it's manager's jobs weren't scheduled!", "LateUpdate", 35);
			}
			_jobManagersCount = 2;
		}
	}

	private void OnJobsScheduled()
	{
		_jobManagersCount--;
		if (_jobManagersCount == 0)
		{
			JobHandle.ScheduleBatchedJobs();
		}
	}
}
