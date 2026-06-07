using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public abstract class GameplayEffectData : ScriptableObject, ISavable
{
	public enum EEndDurationPolicy
	{
		RemoveEffect = 0,
		RemoveStacks = 1
	}

	[Header("Info")]
	[SerializeField]
	[Savable("id", true, false)]
	private string id;

	private string displayName;

	[SerializeField]
	private LocalizedString defaultDisplayName;

	[SerializeField]
	private LocalizedString description;

	[SerializeField]
	private Sprite icon;

	[SerializeField]
	[Tooltip("Max Stacks == 0 -> infinite")]
	private int maxStacks = 1;

	[SerializeField]
	private bool hideToPlayer = true;

	[Header("Duration")]
	[SerializeField]
	private bool hasDuration;

	[SerializeField]
	private float duration;

	[SerializeField]
	private bool refreshDurationOnAddStacks = true;

	[SerializeField]
	private EEndDurationPolicy endDurationPolicy;

	[SerializeField]
	private int stacksToRemove = 1;

	[Header("Tick")]
	[SerializeField]
	private bool hasTickTime;

	[SerializeField]
	private float tickTime;

	[Header("Save")]
	[SerializeField]
	private bool savable;

	public virtual string DisplayName
	{
		get
		{
			if (string.IsNullOrEmpty(displayName) && defaultDisplayName != null && !defaultDisplayName.IsEmpty)
			{
				return defaultDisplayName.GetLocalizedString();
			}
			return displayName;
		}
		set
		{
			displayName = value;
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

	public string Id => id;

	public Sprite Icon
	{
		get
		{
			return icon;
		}
		set
		{
			icon = value;
		}
	}

	public int MaxStacks
	{
		get
		{
			return maxStacks;
		}
		protected set
		{
			maxStacks = value;
		}
	}

	public bool HideToPlayer => hideToPlayer;

	public bool RefreshDurationOnAddStacks
	{
		get
		{
			return refreshDurationOnAddStacks;
		}
		protected set
		{
			refreshDurationOnAddStacks = value;
		}
	}

	public bool HasDuration
	{
		get
		{
			return hasDuration;
		}
		protected set
		{
			hasDuration = value;
		}
	}

	public float Duration
	{
		get
		{
			return duration;
		}
		protected set
		{
			duration = value;
		}
	}

	public bool HasTickTime
	{
		get
		{
			return hasTickTime;
		}
		protected set
		{
			hasTickTime = value;
		}
	}

	public float TickTime
	{
		get
		{
			return tickTime;
		}
		protected set
		{
			tickTime = value;
		}
	}

	public EEndDurationPolicy EndDurationPolicy
	{
		get
		{
			return endDurationPolicy;
		}
		protected set
		{
			endDurationPolicy = value;
		}
	}

	public int StacksToRemove
	{
		get
		{
			return stacksToRemove;
		}
		protected set
		{
			stacksToRemove = value;
		}
	}

	public bool Savable => savable;

	private void SetNameAsID()
	{
		id = base.name;
	}

	public abstract GameplayEffect InstantiateEffect();

	protected virtual bool ShowNameInInspector()
	{
		return true;
	}

	protected virtual bool ShowDescriptionInInspector()
	{
		return true;
	}

	protected virtual bool ShowDurationInInspector()
	{
		return true;
	}

	protected virtual bool ShowTickInInspector()
	{
		return true;
	}

	protected virtual bool ShowMaxStacksInInspector()
	{
		return true;
	}

	public void OnSave()
	{
	}

	public void OnPreLoad()
	{
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
	}
}
