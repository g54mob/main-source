using System;
using System.Runtime.Serialization;
using UnityEngine.Events;

[Serializable]
public class DailyReportTableData
{
	public float Gained;

	[OptionalField(VersionAdded = 2)]
	public float Ingredients;

	public float Lost;

	[NonSerialized]
	public UnityEvent ValueUpdatedEvent;

	public DailyReportTableData()
	{
		ValueUpdatedEvent = new UnityEvent();
	}

	public DailyReportTableData(DailyReportTableData data)
	{
		Gained = data.Gained;
		Ingredients = data.Ingredients;
		Lost = data.Lost;
		ValueUpdatedEvent = new UnityEvent();
	}

	public DailyReportTableData(float gained, float ingredients, float lost)
	{
		Gained = gained;
		Ingredients = ingredients;
		Lost = lost;
		ValueUpdatedEvent = new UnityEvent();
	}

	public void AddGained(float value)
	{
		Gained += value;
		ValueUpdatedEvent.Invoke();
	}

	public void AddIngredient(float value)
	{
		Ingredients += value;
		ValueUpdatedEvent.Invoke();
	}

	public void AddLost(float value)
	{
		Lost += value;
		ValueUpdatedEvent.Invoke();
	}
}
