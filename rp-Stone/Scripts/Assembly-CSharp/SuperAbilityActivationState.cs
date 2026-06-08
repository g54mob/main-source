using UnityEngine;

public class SuperAbilityActivationState : MonoBehaviour
{
	public class State
	{
		private string _stateName;

		public static readonly State Starting = new State("Starting");

		public static readonly State Done = new State("Done");

		public State()
		{
			_stateName = "unnamed";
		}

		public State(string name)
		{
			_stateName = name;
		}

		public override string ToString()
		{
			return _stateName;
		}
	}

	public bool runGameClock;

	protected int stateElapsedTics;

	public string errorMessage { get; set; }

	public string abilityId { get; set; }

	public Item sourceItem { get; set; }

	public State currentState { get; private set; }

	public virtual bool CanActivate()
	{
		return true;
	}

	public virtual void Activate()
	{
		SetState(State.Starting);
	}

	public virtual bool IsDone()
	{
		return currentState == State.Done;
	}

	protected virtual void SetState(State newState)
	{
		currentState = newState;
		stateElapsedTics = 0;
	}

	public virtual void UpdateTic()
	{
		stateElapsedTics++;
	}

	public virtual void Draw(AsciiRenderProcedural r)
	{
	}

	protected float ComputeStatWithId(string searchId)
	{
		if (sourceItem != null)
		{
			WeaponActivatedAbility component = sourceItem.GetComponent<WeaponActivatedAbility>();
			if (component != null)
			{
				return component.ComputeStatWithId(searchId);
			}
		}
		return 0f;
	}

	protected ItemData.Ability FindAbilityWithId(string searchId)
	{
		if (sourceItem != null)
		{
			WeaponActivatedAbility component = sourceItem.GetComponent<WeaponActivatedAbility>();
			if (component != null)
			{
				return component.FindAbilityWithId(searchId);
			}
		}
		return null;
	}

	protected virtual void Awake()
	{
		sourceItem = base.gameObject.GetComponentInParent<Item>();
	}

	protected virtual void OnDestroy()
	{
	}
}
