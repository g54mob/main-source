using System.Collections.Generic;
using UnityEngine;
using __Project__.Scripts.Janitor;

public class JanitorManager : NoktaSingleton<JanitorManager>
{
	public float cleaningDuration;

	public List<Janitor> ActiveJanitor => null;

	public Garbage Garbage => null;

	public Dirt Dirt => null;

	public Dust GetActiveDust => null;

	public Garbage GetGarbage(Janitor janitor)
	{
		return null;
	}

	public Dirt GetDirt(Janitor janitor)
	{
		return null;
	}

	public List<Dust> ActiveDust()
	{
		return null;
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public GameObject SelectCleaningObject(Janitor janitor)
	{
		return null;
	}

	public bool IsAnyCleaningObject()
	{
		return false;
	}

	public GameObject SelectGarbageObject(Janitor janitor)
	{
		return null;
	}

	public void ResetOnDayFinish()
	{
	}
}
