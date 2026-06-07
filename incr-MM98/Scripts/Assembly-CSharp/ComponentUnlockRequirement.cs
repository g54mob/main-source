using System;
using R3;
using UnityEngine;

public class ComponentUnlockRequirement : MonoBehaviour
{
	public readonly struct Requirement : IEquatable<Requirement>
	{
		public readonly RequirementType Type;

		public readonly double Value;

		public Requirement(RequirementType type, double value)
		{
			Type = type;
			Value = value;
		}

		public bool Equals(Requirement other)
		{
			if (Type == other.Type)
			{
				return Value.Equals(other.Value);
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is Requirement other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine((int)Type, Value);
		}
	}

	public enum RequirementType
	{
		Time = 0,
		Players = 1,
		Cash = 2,
		Load = 3,
		Ping = 4,
		Bugs = 5,
		Fans = 6,
		Data = 7,
		NotImplemented = 8
	}

	[SerializeField]
	private RequirementType requirement;

	[SerializeField]
	private double value;

	[SerializeField]
	private bool skipWithoutTutorial;

	private IDisposable _subscription;

	private Requirement _requirement;

	private void Start()
	{
		_requirement = new Requirement(requirement, value);
		if (DebugMode.SkipComponentUnlock || (skipWithoutTutorial && !Database.State.Studio.Tutorial.Value) || Database.State.Metrics.ComponentsUnlocked.Contains(_requirement))
		{
			UnityEngine.Object.Destroy(this);
			return;
		}
		base.gameObject.SetActive(value: false);
		switch (requirement)
		{
		case RequirementType.Time:
			RegisterCondition(Database.State.Game.Time);
			break;
		case RequirementType.Players:
			RegisterCondition(Database.State.Resources.Players);
			break;
		case RequirementType.Cash:
			RegisterCondition(Database.State.Resources.MoneyLifetime);
			break;
		case RequirementType.Load:
			RegisterCondition(Database.State.Resources.Load);
			break;
		case RequirementType.Ping:
			RegisterCondition(Database.State.Resources.Ping);
			break;
		case RequirementType.Bugs:
			RegisterCondition(Database.State.Resources.Bugs);
			break;
		case RequirementType.Fans:
			RegisterCondition(Database.State.Prestige.Fans);
			break;
		case RequirementType.Data:
			RegisterCondition(Database.State.Prestige.Data);
			break;
		case RequirementType.NotImplemented:
			base.gameObject.SetActive(value: false);
			break;
		}
	}

	private void RegisterCondition(Observable<double> source)
	{
		_subscription = source.Where((double x) => x > value).Take(1).Subscribe(delegate
		{
			HandleConditionMet();
		});
	}

	private void RegisterCondition(Observable<float> source)
	{
		_subscription = source.Where((float x) => (double)x > value).Take(1).Subscribe(delegate
		{
			HandleConditionMet();
		});
	}

	private void HandleConditionMet()
	{
		base.gameObject.SetActive(value: true);
		Database.State.Metrics.ComponentsUnlocked.Add(_requirement);
		UnityEngine.Object.Destroy(this);
	}

	private void OnDestroy()
	{
		_subscription?.Dispose();
	}
}
