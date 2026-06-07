using UnityEngine;

public abstract class AbilityUnlockCondition : MonoBehaviour
{
	public delegate void OnConditionAccomplished(bool isAccomplished);

	protected Ability ability;

	private bool accomplished;

	[SerializeField]
	private bool invertCondition;

	public bool Accomplished
	{
		get
		{
			return accomplished;
		}
		set
		{
			accomplished = (InvertCondition ? (!value) : value);
			this.onConditionAccomplished?.Invoke(accomplished);
		}
	}

	public bool InvertCondition
	{
		get
		{
			return invertCondition;
		}
		set
		{
			invertCondition = value;
		}
	}

	public event OnConditionAccomplished onConditionAccomplished;

	protected virtual void Awake()
	{
		ability = GetComponent<Ability>();
	}

	protected virtual void Start()
	{
		CheckCondition();
	}

	protected abstract void CheckCondition();
}
