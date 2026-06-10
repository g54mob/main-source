using System;
using UnityEngine;

[Serializable]
public class SchedulerJob
{
	[SerializeField]
	private float priority;

	[SerializeField]
	private string[] goals;

	public float Priority => priority;

	public string[] Goals => goals;
}
