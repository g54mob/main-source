using System;
using I2.Loc;
using UnityEngine;

[Serializable]
public class SelectBuildableObjective : QuestObjectiveBase, ILocalizationParamsManager
{
	[SerializeField]
	[HideInInspector]
	private string _name = "Select buildable";

	[SerializeField]
	private BuildableProperties _specificBuildable;

	public SelectBuildableObjective()
	{
	}

	public SelectBuildableObjective(SelectBuildableObjective other)
		: base(other)
	{
		_specificBuildable = other._specificBuildable;
	}

	public override bool IsCompleted()
	{
		if (!base.IsCompleted())
		{
			if (Selector.SelectedType == ObjectType.Buildable)
			{
				if (!(_specificBuildable == null))
				{
					if (Selector.Selection.ObjectToSelect.TryGetComponent<Buildable>(out var component))
					{
						return component.Properties == _specificBuildable;
					}
					return false;
				}
				return true;
			}
			return false;
		}
		return true;
	}

	public override void Initialize()
	{
		if (!InitializeIsCompleted())
		{
			GameEventDispatcher.AddListener(GameEventType.BuildableSelected, OnBuildableSelected);
		}
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.BuildableSelected, OnBuildableSelected);
	}

	private void OnBuildableSelected(GameEvent gameEvent)
	{
		if (gameEvent is BuildableEvent buildableEvent && (_specificBuildable == null || buildableEvent.BuildableProperties == _specificBuildable))
		{
			SetCompleted(completed: true);
		}
	}

	protected override string GetNonLocalizedDescription()
	{
		return "Select Buildable: " + ((_specificBuildable != null) ? _specificBuildable.Name : "Any");
	}

	public override string GetParameterValue(string param)
	{
		if (param == "BUILDING")
		{
			return (_specificBuildable != null) ? _specificBuildable.Name : "Any";
		}
		return base.GetParameterValue(param);
	}

	public override object Clone()
	{
		return new SelectBuildableObjective(this);
	}
}
