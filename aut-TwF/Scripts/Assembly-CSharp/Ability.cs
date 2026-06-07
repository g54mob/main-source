using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Localization;

public abstract class Ability : SerializedMonoBehaviour, ISavable
{
	public delegate void OnAbilityEnds(Ability ability, bool canceled);

	public delegate void OnAbilityLocked(Ability ability, bool locked);

	[SerializeField]
	private string id = "defaultID";

	[SerializeField]
	private LocalizedString abilityName;

	[SerializeField]
	private LocalizedString description;

	[SerializeField]
	private Sprite splash;

	private bool isActive;

	protected GameObject owner;

	protected AbilityManager abilityManager;

	private bool isLocked;

	private AbilityUnlockCondition[] unlockConditions;

	public string Id
	{
		get
		{
			return id;
		}
		protected set
		{
			id = value;
		}
	}

	public virtual string AbilityName
	{
		get
		{
			if (abilityName != null && !abilityName.IsEmpty)
			{
				return abilityName.GetLocalizedString();
			}
			return "-";
		}
	}

	public virtual string Description
	{
		get
		{
			if (description != null && !description.IsEmpty)
			{
				return description.GetLocalizedString();
			}
			return "-";
		}
	}

	public Sprite Splash => splash;

	public AbilityManager AbilityManager
	{
		get
		{
			return abilityManager;
		}
		protected set
		{
			abilityManager = value;
		}
	}

	public virtual bool IsLocked
	{
		get
		{
			return isLocked;
		}
		set
		{
			isLocked = value;
			this.onAbilityLocked?.Invoke(this, IsLocked);
		}
	}

	public bool IsActive
	{
		get
		{
			return isActive;
		}
		private set
		{
			isActive = value;
		}
	}

	public event OnAbilityEnds onAbilityEnds;

	public event OnAbilityLocked onAbilityLocked;

	protected virtual void Awake()
	{
		owner = base.transform.parent.parent.gameObject;
		AbilityManager = owner.GetComponent<AbilityManager>();
		unlockConditions = GetComponents<AbilityUnlockCondition>();
		AbilityUnlockCondition[] array = unlockConditions;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].onConditionAccomplished += OnUnlockConditionChanged;
		}
	}

	protected virtual void Start()
	{
	}

	protected bool CanActivate_Internal()
	{
		if (IsLocked)
		{
			return false;
		}
		return true;
	}

	protected bool StartAbility_Internal()
	{
		if (CanActivate_Internal())
		{
			IsActive = true;
			return true;
		}
		return false;
	}

	protected void EndAbility_Internal(bool canceled = false)
	{
		IsActive = false;
		this.onAbilityEnds?.Invoke(this, canceled);
	}

	private void CheckUnlockConditions()
	{
		if (unlockConditions == null || unlockConditions.Length == 0)
		{
			return;
		}
		AbilityUnlockCondition[] array = unlockConditions;
		for (int i = 0; i < array.Length; i++)
		{
			if (!array[i].Accomplished)
			{
				IsLocked = true;
				return;
			}
		}
		IsLocked = false;
	}

	private void OnUnlockConditionChanged(bool accomplished)
	{
		if ((isLocked && accomplished) || (!isLocked && !accomplished))
		{
			CheckUnlockConditions();
		}
	}

	public virtual void OnSave()
	{
	}

	public virtual void OnPreLoad()
	{
	}

	public virtual void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
	}
}
