using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour, ISavable
{
	public delegate void OnAbilityAdded(Ability ability);

	public delegate void OnLocalUsedAbilityAdded(string abilityId);

	public delegate void OnAbilityQueuedEvent(Ability ability, int position);

	public delegate void OnCurrentAbilityChanged(Ability currentAbilit);

	[SerializeField]
	[Savable("autoAttackAbility", true, false)]
	private AutoAttack autoAttackAbility;

	[SerializeField]
	private List<Ability> baseAbilities;

	[SerializeField]
	[Tooltip("Max queue size. -1 = infinite")]
	private int maxQueueSize = -1;

	[Savable("abilities", true, false)]
	private List<Ability> abilities = new List<Ability>();

	private ActiveAbility currentAbility;

	private Transform abilitiesParent;

	private AbilityQueue abilityQueue;

	private List<string> localUsedAbilitiesIds;

	private Character character;

	private CombatComponent combatComponent;

	private StatsComponent statsComponent;

	private TeamComponent teamComponent;

	private TowerAnimationComponent animationComponent;

	public Character Character
	{
		get
		{
			return character;
		}
		private set
		{
			character = value;
		}
	}

	public CombatComponent CombatComponent
	{
		get
		{
			return combatComponent;
		}
		private set
		{
			combatComponent = value;
		}
	}

	public StatsComponent StatsComponent
	{
		get
		{
			return statsComponent;
		}
		private set
		{
			statsComponent = value;
		}
	}

	public TeamComponent TeamComponent
	{
		get
		{
			return teamComponent;
		}
		private set
		{
			teamComponent = value;
		}
	}

	public TowerAnimationComponent AnimationComponent
	{
		get
		{
			return animationComponent;
		}
		private set
		{
			animationComponent = value;
		}
	}

	public ActiveAbility CurrentAbility
	{
		get
		{
			return currentAbility;
		}
		protected set
		{
			currentAbility = value;
			this.onCurrentAbilityChanged?.Invoke(currentAbility);
		}
	}

	public event OnAbilityAdded onAbilityAdded;

	public event OnAbilityAdded onAbilityRemoved;

	public event OnLocalUsedAbilityAdded onLocalUsedAbilityAdded;

	public event OnAbilityQueuedEvent onAbilityQueued;

	public event OnAbilityQueuedEvent onAbilityDequeued;

	public event OnCurrentAbilityChanged onCurrentAbilityChanged;

	private void Awake()
	{
		Character = GetComponent<Character>();
		CombatComponent = GetComponent<CombatComponent>();
		StatsComponent = GetComponent<StatsComponent>();
		TeamComponent = GetComponent<TeamComponent>();
		AnimationComponent = GetComponent<TowerAnimationComponent>();
		localUsedAbilitiesIds = new List<string>();
		abilitiesParent = new GameObject().transform;
		abilitiesParent.SetParent(base.gameObject.transform);
		abilitiesParent.name = "Abilities";
		abilityQueue = new AbilityQueue();
		abilityQueue.MaxQueueSize = maxQueueSize;
		abilityQueue.onAbilityQueued += OnAbilityQueued;
		abilityQueue.onAbilityDequeued += OnAbilityDequeued;
		CreateBaseAbilities();
		if ((bool)CombatComponent)
		{
			CombatComponent.onDie += OnEntityDies;
		}
	}

	private void Start()
	{
		if ((bool)TeamComponent)
		{
			TeamComponent.onTeamChanged += OnEntityTeamChanged;
		}
	}

	private void OnDestroy()
	{
	}

	private void CreateBaseAbilities()
	{
		if ((bool)autoAttackAbility)
		{
			AddAbility(autoAttackAbility);
		}
		else
		{
			abilities.Add(null);
		}
		foreach (Ability baseAbility in baseAbilities)
		{
			AddAbility(baseAbility);
		}
	}

	public List<Ability> GetAllAbilities(bool includeAutoattack = true)
	{
		List<Ability> list = new List<Ability>(abilities);
		if (list.Count > 0 && (!includeAutoattack || !list[0]))
		{
			list.RemoveAt(0);
		}
		return list;
	}

	public Ability AddAbility(Ability abilityPrefab, bool checkUnique = false)
	{
		if (checkUnique)
		{
			foreach (Ability allAbility in GetAllAbilities())
			{
				if (allAbility.Id == abilityPrefab.Id)
				{
					return null;
				}
			}
		}
		Ability ability = null;
		if ((bool)abilityPrefab)
		{
			ability = Object.Instantiate(abilityPrefab, abilitiesParent);
		}
		if ((bool)ability)
		{
			if ((bool)autoAttackAbility && ability.Id == autoAttackAbility.Id)
			{
				if (abilities.Count > 0)
				{
					RemoveAbility(abilities[0]);
				}
				abilities.Insert(0, ability);
			}
			else
			{
				abilities.Add(ability);
			}
			ability.onAbilityLocked += OnAbilityLocked;
			this.onAbilityAdded?.Invoke(ability);
		}
		return ability;
	}

	public void RemoveAbility(Ability ability)
	{
		if ((bool)ability && ability.transform.parent == abilitiesParent)
		{
			abilities.Remove(ability);
			if ((bool)autoAttackAbility && ability.Id == autoAttackAbility.Id)
			{
				abilities.Insert(0, null);
			}
			abilityQueue.RemoveAbility(ability);
			this.onAbilityRemoved?.Invoke(ability);
			Object.Destroy(ability.gameObject);
		}
	}

	public void RemoveAbility(int index)
	{
		if (abilities.Count > index)
		{
			RemoveAbility(abilities[index]);
		}
	}

	public void RemoveAllAbilities()
	{
		for (int num = abilities.Count - 1; num >= 0; num--)
		{
			RemoveAbility(num);
		}
	}

	public ActiveAbility GetAutoAttackAbility()
	{
		if (abilities.Count > 0)
		{
			return abilities[0] as ActiveAbility;
		}
		return null;
	}

	public Ability GetAbility(int position)
	{
		if (position >= 0 && position < abilities.Count)
		{
			return abilities[position];
		}
		return null;
	}

	public Ability GetAbilityById(string abilityId)
	{
		foreach (Ability allAbility in GetAllAbilities())
		{
			if (allAbility.Id == abilityId)
			{
				return allAbility;
			}
		}
		return null;
	}

	public int GetAbilityIndex(Ability ability)
	{
		for (int i = 0; i < abilities.Count; i++)
		{
			if (abilities[i].gameObject == ability.gameObject)
			{
				return i;
			}
		}
		return -1;
	}

	public bool UseAutoAttackAbility(CombatComponent target)
	{
		UseAbility(GetAutoAttackAbility(), new FActiveAbilityInputData(target, Vector3.zero));
		return true;
	}

	public bool UseAbility(ActiveAbility ability, FActiveAbilityInputData inputData)
	{
		if ((bool)CurrentAbility)
		{
			return false;
		}
		if ((bool)ability && ability.StartAbility(inputData))
		{
			CurrentAbility = ability;
			if (CurrentAbility.IsActive)
			{
				CurrentAbility.onAbilityEnds += OnCurrentAbilityEnds;
			}
			else
			{
				OnCurrentAbilityEnds(CurrentAbility, canceled: false);
			}
			return true;
		}
		UseNextQueuedAbility();
		return false;
	}

	public bool UseAbility(int position, FActiveAbilityInputData inputData)
	{
		ActiveAbility activeAbility = GetAbility(position) as ActiveAbility;
		if ((bool)activeAbility)
		{
			return UseAbility(activeAbility, inputData);
		}
		return false;
	}

	public void QueueAbility(ActiveAbility ability, FActiveAbilityInputData inputData)
	{
		if ((bool)ability)
		{
			if (!CurrentAbility)
			{
				UseAbility(ability, inputData);
			}
			else if (ability.CanQueue())
			{
				abilityQueue.AddAbility(new QueuedAbility(ability, inputData));
			}
		}
	}

	public void DequeueAbility(ActiveAbility ability)
	{
		abilityQueue.RemoveAbility(ability);
	}

	public void DequeueAbilityAtPosition(int position)
	{
		abilityQueue.RemoveAbilityAtPosition(position);
	}

	private bool UseNextQueuedAbility()
	{
		if (!abilityQueue.IsEmpty())
		{
			QueuedAbility queuedAbility = abilityQueue.ConsumeAbility();
			UseAbility(queuedAbility.ability, queuedAbility.inputData);
			return true;
		}
		return false;
	}

	public List<Ability> GetQueuedAbilities()
	{
		return abilityQueue.GetAbilities();
	}

	public void AddLocalUsedAbility(string id)
	{
		if (localUsedAbilitiesIds.AddUnique(id))
		{
			this.onLocalUsedAbilityAdded?.Invoke(id);
		}
	}

	public bool HasUsedLocalAbility(string id)
	{
		return localUsedAbilitiesIds.Contains(id);
	}

	private void OnCurrentAbilityEnds(Ability ability, bool canceled)
	{
		if ((bool)CurrentAbility)
		{
			CurrentAbility.onAbilityEnds -= OnCurrentAbilityEnds;
			CurrentAbility = null;
			UseNextQueuedAbility();
		}
	}

	private void OnEntityDies(CombatComponent combatComponent)
	{
		abilityQueue.EmptyQueue();
		if ((bool)CurrentAbility)
		{
			currentAbility.CancelAbility();
		}
	}

	private void OnEntityTeamChanged(int newTeam, int oldTeam)
	{
		abilityQueue.EmptyQueue();
		currentAbility?.CancelAbility();
	}

	private void OnAbilityLocked(Ability ability, bool isLocked)
	{
		if (isLocked)
		{
			abilityQueue.RemoveAbility(ability);
		}
	}

	private void OnAbilityQueued(QueuedAbility qAbility, int position)
	{
		this.onAbilityQueued?.Invoke(qAbility.ability, position);
	}

	private void OnAbilityDequeued(QueuedAbility qAbility, int position)
	{
		this.onAbilityDequeued?.Invoke(qAbility.ability, position);
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
