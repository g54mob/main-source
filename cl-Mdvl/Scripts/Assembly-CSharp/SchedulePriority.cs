using System;
using UnityEngine;

[Serializable]
public class SchedulePriority
{
	[SerializeField]
	private float basePriority;

	[SerializeField]
	private SchedulerJob[] jobs;

	public float Priority => basePriority;

	public SchedulerJob[] Jobs => jobs;
}
