using System.Collections;
using DV.Utils;
using UnityEngine;

public class WorldTimeBasedEvents : SingletonBehaviour<WorldTimeBasedEvents>
{
	public WorldTimeBasedEventsProvider provider;

	private TimeBasedEvent[] events;

	private Coroutine coroutine;

	public new static string AllowAutoCreate => null;

	private void Start()
	{
		if (provider == null)
		{
			Debug.LogError("WorldTimeBasedEvents doesn't have a provider assigned, disabling itself.", this);
			base.enabled = false;
			return;
		}
		events = GetComponents<TimeBasedEvent>();
		float time = GetTime();
		TimeBasedEvent[] array = events;
		foreach (TimeBasedEvent obj in array)
		{
			obj.Initialize();
			obj.UpdateTime(time);
		}
		coroutine = StartCoroutine(CheckEvents());
	}

	private IEnumerator CheckEvents()
	{
		while (true)
		{
			yield return WaitFor.SecondsRealtime(1f);
			float time = GetTime();
			TimeBasedEvent[] array = events;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].UpdateTime(time);
			}
		}
	}

	private float GetTime()
	{
		return provider.GetTime();
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		TimeBasedEvent[] array = events;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Dispose();
		}
	}
}
