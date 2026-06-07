using System.Collections.Generic;
using UnityEngine;

public class StatisticTableController : ActiveComponent
{
	private Dictionary<string, StatisticFieldController> fields;

	private StatisticFieldController[] holders;

	private HashSet<string> statsObjects;

	protected override void OnInit()
	{
		base.OnInit();
		fields = new Dictionary<string, StatisticFieldController>();
		holders = base.gameObject.GetComponentsInChildren<StatisticFieldController>();
		StatisticFieldController[] array = holders;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].gameObject.SetActive(value: false);
		}
		fields["empty"] = holders[0];
		fields["object"] = holders[2];
		fields["car"] = holders[3];
		fields["wall"] = holders[5];
		foreach (KeyValuePair<string, StatisticFieldController> field in fields)
		{
			field.Value.gameObject.SetActive(value: true);
			field.Value.Init(CarObjectTree.bigCarObjectSprite[field.Key]);
		}
	}

	public void Init(string statList)
	{
		base.Init();
		statsObjects = new HashSet<string>();
		string[] array = statList.Split(';');
		foreach (string item in array)
		{
			statsObjects.Add(item);
		}
		foreach (StatisticFieldController value in fields.Values)
		{
			value.SetColor(StatisticFieldController.greyColor);
		}
	}

	public void SetPrecision(string name, float precision)
	{
		StatisticFieldController statisticFieldController = fields[name];
		if (statsObjects.Contains(name))
		{
			statisticFieldController.SetColor(Color.white);
			statisticFieldController.SetPrecision(precision);
		}
	}
}
