using System.Collections.Generic;
using Pathfinding;
using Pathfinding.RVO;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TaggedObject))]
public class Hp : MonoBehaviour, ISaveLoad
{
	[BalancingParameter(BalancingParameter.EType.Default)]
	public float maxHp;

	public bool getsKnockedOutInsteadOfDying;

	private bool elite;

	private float hp;

	private bool gotLoadedHpValue;

	private TaggedObject taggedObject;

	[Tooltip("The hight where enemies aim at and where hit indicators are spawned")]
	public float hitFeedbackHeight;

	[Tooltip("This child object is enabled when this unit is alive.")]
	public GameObject aliveVisuals;

	[Tooltip("This child object is enabled when this unit is knocked out.")]
	public GameObject knockedOutVisuals;

	public GameObject fxToSpawnOnDeath;

	public GameObject fxToSpawnOnRevive;

	public GameObject enemyToSpawnOnDeath;

	public Vector3 deathFxSpawnOffset;

	public Transform deathFxSpawnWithPosAndRotOf;

	[HideInInspector]
	public UnityEvent OnHpChange = new UnityEvent();

	[HideInInspector]
	public UnityEvent OnRevive = new UnityEvent();

	[HideInInspector]
	public UnityEvent OnHeal = new UnityEvent();

	[HideInInspector]
	public UnityEvent<bool> OnReceiveDamage = new UnityEvent<bool>();

	[HideInInspector]
	public UnityEvent OnKillOrKnockout = new UnityEvent();

	private AutoAttack[] autoAttacks;

	private ManualAttack[] manualAttacks;

	private PathfindMovement pathfindMovement;

	private RVOController rvoController;

	private PlayerMovement playerMovement;

	private NavmeshCut[] navmeshCut;

	private PlayerInteraction playerInteraction;

	public GameObject coin;

	public float coinSpawnOffset;

	public int coinCount;

	[SerializeField]
	private Weapon spwanAttackOnDeath;

	private float damageMultiplyer = 1f;

	private float healingMultiplyer = 1f;

	public bool invulnerable;

	private float hpOritinal;

	private bool initilaized;

	public bool Elite
	{
		get
		{
			return elite;
		}
		set
		{
			elite = value;
		}
	}

	public float HpValue => hp;

	public float HpPercentage
	{
		get
		{
			return hp / maxHp;
		}
		set
		{
			hp = maxHp * value;
		}
	}

	public bool KnockedOut => hp <= 0f;

	public TaggedObject TaggedObj => taggedObject;

	public AutoAttack[] AutoAttacks => autoAttacks;

	public PathfindMovement PathfindMovement => pathfindMovement;

	public Weapon SpwanAttackOnDeath
	{
		get
		{
			return spwanAttackOnDeath;
		}
		set
		{
			spwanAttackOnDeath = value;
		}
	}

	public float DamageMultiplyer
	{
		get
		{
			return damageMultiplyer;
		}
		set
		{
			damageMultiplyer = value;
		}
	}

	public bool Alive => hp >= 0f;

	public float HpOriginal
	{
		get
		{
			return hpOritinal;
		}
		set
		{
			hpOritinal = value;
		}
	}

	public void OnBeforeMainLoadPass(string guid)
	{
	}

	public void OnAfterMainLoadPass(string guid)
	{
	}

	public void OnLoad(string guid)
	{
		int value = 0;
		gotLoadedHpValue = MatchSaveLoadHandler.TryLoadValue(guid, base.gameObject.name + "_hp", ref value);
		hp = value;
	}

	public void OnSave(string guid)
	{
		MatchSaveLoadHandler.SaveValue(guid, base.gameObject.name + "_hp", Mathf.RoundToInt(hp));
	}

	public void ScaleHp(float _multiply)
	{
		hp *= _multiply;
		maxHp *= _multiply;
	}

	public void SetHpToMaxHp()
	{
		hp = maxHp;
	}

	private void Initialize()
	{
		if (!initilaized)
		{
			initilaized = true;
			playerInteraction = GetComponent<PlayerInteraction>();
			taggedObject = GetComponent<TaggedObject>();
			autoAttacks = GetComponents<AutoAttack>();
			manualAttacks = GetComponents<ManualAttack>();
			pathfindMovement = GetComponent<PathfindMovement>();
			rvoController = GetComponent<RVOController>();
			playerMovement = GetComponent<PlayerMovement>();
			navmeshCut = GetComponentsInChildren<NavmeshCut>();
			if (!gotLoadedHpValue)
			{
				taggedObject.AddTag(TagManager.ETag.AUTO_Alive);
			}
		}
	}

	private void Start()
	{
		Initialize();
		if (!gotLoadedHpValue)
		{
			Revive(callReviveEvent: false);
		}
		ActivateAndDeactivateChildrenAndCompements(hp > 0f);
		if (PerkManager.instance.HealingSpiritsActive && (bool)taggedObject && taggedObject.Tags.Contains(TagManager.ETag.PlayerOwned))
		{
			healingMultiplyer *= PerkManager.instance.healingSpirits_healMulti;
		}
	}

	private void ActivateAndDeactivateChildrenAndCompements(bool _alive)
	{
		Initialize();
		if ((bool)aliveVisuals)
		{
			aliveVisuals.SetActive(_alive);
		}
		if ((bool)knockedOutVisuals)
		{
			knockedOutVisuals.SetActive(!_alive);
		}
		if (autoAttacks.Length != 0)
		{
			AutoAttack[] array = autoAttacks;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].enabled = _alive;
			}
		}
		if (manualAttacks.Length != 0)
		{
			ManualAttack[] array2 = manualAttacks;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].enabled = _alive;
			}
		}
		if ((bool)pathfindMovement)
		{
			pathfindMovement.enabled = _alive;
			if (!_alive)
			{
				pathfindMovement.ClearCurrentPath();
			}
		}
		if ((bool)(Object)(object)rvoController)
		{
			((Behaviour)(object)rvoController).enabled = _alive;
		}
		if ((bool)playerMovement)
		{
			playerMovement.Dead = !_alive;
		}
		NavmeshCut[] array3 = navmeshCut;
		for (int i = 0; i < array3.Length; i++)
		{
			((Behaviour)(object)array3[i]).enabled = _alive;
		}
		if ((bool)playerInteraction)
		{
			playerInteraction.enabled = _alive;
		}
	}

	public void Revive(bool callReviveEvent = true, float healthPercentage = 1f)
	{
		Initialize();
		if (hp <= 0f)
		{
			if (callReviveEvent)
			{
				OnRevive.Invoke();
			}
			taggedObject.RemoveTag(TagManager.ETag.AUTO_KnockedOutAndHealOnDawn);
			taggedObject.AddTag(TagManager.ETag.AUTO_Alive);
			if ((bool)fxToSpawnOnRevive && callReviveEvent)
			{
				Object.Instantiate(fxToSpawnOnRevive, base.transform.position + deathFxSpawnOffset, fxToSpawnOnRevive.transform.rotation, null);
			}
			ActivateAndDeactivateChildrenAndCompements(_alive: true);
			hp = 0f;
		}
		else if (hp < maxHp)
		{
			OnHeal.Invoke();
		}
		hp += maxHp * healthPercentage;
		if (hp > maxHp)
		{
			hp = maxHp;
		}
		OnHpChange.Invoke();
	}

	public void MakeInvulerable(bool _infulerable)
	{
		invulnerable = _infulerable;
	}

	public void TakeDamageSelfDrained(float _amount)
	{
		bool flag = invulnerable;
		invulnerable = false;
		if (_amount >= hp)
		{
			_amount = hp - 1f;
		}
		TakeDamage(_amount, null, causedByPlayer: false, invokeFeedbackEvents: false);
		invulnerable = flag;
	}

	public bool TakeDamage(float _amount, TaggedObject _damageComingFrom = null, bool causedByPlayer = false, bool invokeFeedbackEvents = true)
	{
		if (hp <= 0f)
		{
			return false;
		}
		if (invulnerable)
		{
			return false;
		}
		if (_amount <= 0f)
		{
			Heal(0f - _amount);
			return false;
		}
		if ((bool)pathfindMovement)
		{
			pathfindMovement.GetAgroFromObject(_damageComingFrom);
		}
		hp -= _amount;
		if (invokeFeedbackEvents)
		{
			OnReceiveDamage.Invoke(causedByPlayer);
		}
		OnHpChange.Invoke();
		if (hp <= 0f)
		{
			OnKillOrKnockout.Invoke();
			if ((bool)fxToSpawnOnDeath)
			{
				if ((bool)deathFxSpawnWithPosAndRotOf)
				{
					Object.Instantiate(fxToSpawnOnDeath, deathFxSpawnWithPosAndRotOf.position + deathFxSpawnOffset, deathFxSpawnWithPosAndRotOf.rotation, null);
				}
				else
				{
					Object.Instantiate(fxToSpawnOnDeath, base.transform.position + deathFxSpawnOffset, fxToSpawnOnDeath.transform.rotation, null);
				}
			}
			if ((bool)enemyToSpawnOnDeath)
			{
				Spawn.AdjustEnemyParametersAfterSpawn(Object.Instantiate(enemyToSpawnOnDeath, base.transform.position, base.transform.rotation, null), elite);
			}
			if (getsKnockedOutInsteadOfDying)
			{
				taggedObject.RemoveTag(TagManager.ETag.AUTO_Alive);
				taggedObject.AddTag(TagManager.ETag.AUTO_KnockedOutAndHealOnDawn);
				ActivateAndDeactivateChildrenAndCompements(_alive: false);
			}
			else
			{
				Shrine.DeathOfUnitAt(base.transform.position, HpOriginal);
				Object.Destroy(base.gameObject);
			}
			if ((bool)coin)
			{
				for (int i = 0; i < coinCount; i++)
				{
					if (i >= 1)
					{
						Object.Instantiate(coin, base.transform.position + Vector3.up * coinSpawnOffset + Quaternion.Euler(0f, 45f * (float)i, 0f) * Vector3.forward * 2f, Quaternion.identity);
					}
					else
					{
						Object.Instantiate(coin, base.transform.position + Vector3.up * coinSpawnOffset, Quaternion.identity);
					}
				}
			}
			if ((bool)spwanAttackOnDeath)
			{
				spwanAttackOnDeath.Attack(base.transform.position, null, Vector3.zero, taggedObject, damageMultiplyer);
			}
			return true;
		}
		return false;
	}

	public void Heal(float _amount)
	{
		if (!(hp <= 0f) && !(_amount <= 0f))
		{
			hp += _amount * healingMultiplyer;
			if (hp > maxHp)
			{
				hp = maxHp;
			}
			OnHpChange.Invoke();
		}
	}

	public void SetHpTo(float _value)
	{
		hp = _value;
		OnHpChange.Invoke();
	}

	public static void ReviveAllUnitsWithTag(List<TagManager.ETag> _mustHaveTags, List<TagManager.ETag> _mayNotHaveTags, float _healthPercentage = 1f)
	{
		List<TaggedObject> list = new List<TaggedObject>();
		TagManager.instance.FindAllTaggedObjectsWithTags(list, _mustHaveTags, _mayNotHaveTags);
		for (int i = 0; i < list.Count; i++)
		{
			list[i].Hp.Revive(callReviveEvent: true, _healthPercentage);
		}
	}

	public static void SetAllUnitsWithTagInvulnerable(List<TagManager.ETag> _mustHaveTags, List<TagManager.ETag> _mayNotHaveTags, bool _invulnerable)
	{
		List<TaggedObject> list = new List<TaggedObject>();
		TagManager.instance.FindAllTaggedObjectsWithTags(list, _mustHaveTags, _mayNotHaveTags);
		for (int i = 0; i < list.Count; i++)
		{
			list[i].Hp.MakeInvulerable(_invulnerable);
		}
	}

	public static void MarkDestroyedBuildingsAsDontRevive(List<TagManager.ETag> _mustHaveTags, List<TagManager.ETag> _mayNotHaveTags, float _healthPercentage = 1f)
	{
		List<TaggedObject> list = new List<TaggedObject>();
		TagManager.instance.FindAllTaggedObjectsWithTags(list, _mustHaveTags, _mayNotHaveTags);
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].Tags.Contains(TagManager.ETag.AUTO_KnockedOutAndHealOnDawn))
			{
				list[i].GetComponentInParent<BuildSlot>().Interactor.OnKnockOut();
				if (!list[i].Tags.Contains(TagManager.ETag.AUTO_NoReviveNextMorning))
				{
					list[i].Tags.Add(TagManager.ETag.AUTO_NoReviveNextMorning);
				}
				else
				{
					list[i].Tags.Remove(TagManager.ETag.AUTO_NoReviveNextMorning);
				}
			}
		}
	}

	public static void KillAllUnitsWithTag(List<TagManager.ETag> _mustHaveTags, List<TagManager.ETag> _mayNotHaveTags)
	{
		List<TaggedObject> list = new List<TaggedObject>();
		TagManager.instance.FindAllTaggedObjectsWithTags(list, _mustHaveTags, _mayNotHaveTags);
		for (int i = 0; i < list.Count; i++)
		{
			list[i].Hp.TakeDamage(float.MaxValue);
		}
	}

	public static void ReviveAllKnockedOutPlayerUnitsAndBuildings()
	{
		if (!PerkManager.instance.DestructionGodActive)
		{
			List<TagManager.ETag> list = new List<TagManager.ETag>();
			List<TagManager.ETag> list2 = new List<TagManager.ETag>();
			list.Add(TagManager.ETag.PlayerOwned);
			list2.Add(TagManager.ETag.AUTO_NoReviveNextMorning);
			ReviveAllUnitsWithTag(list, list2);
			SetAllUnitsWithTagInvulnerable(list, list2, _invulnerable: true);
			return;
		}
		List<TagManager.ETag> list3 = new List<TagManager.ETag>();
		List<TagManager.ETag> mayNotHaveTags = new List<TagManager.ETag>();
		list3.Add(TagManager.ETag.PlayerOwned);
		list3.Add(TagManager.ETag.Building);
		MarkDestroyedBuildingsAsDontRevive(list3, mayNotHaveTags);
		List<TagManager.ETag> list4 = new List<TagManager.ETag>();
		mayNotHaveTags = new List<TagManager.ETag>();
		list4.Add(TagManager.ETag.PlayerOwned);
		mayNotHaveTags.Add(TagManager.ETag.Building);
		mayNotHaveTags.Add(TagManager.ETag.AUTO_NoReviveNextMorning);
		ReviveAllUnitsWithTag(list4, mayNotHaveTags);
		SetAllUnitsWithTagInvulnerable(list4, mayNotHaveTags, _invulnerable: true);
		mayNotHaveTags.Clear();
		mayNotHaveTags.Add(TagManager.ETag.AUTO_NoReviveNextMorning);
		list4.Add(TagManager.ETag.Building);
		ReviveAllUnitsWithTag(list4, mayNotHaveTags, PerkManager.instance.destructionGodHealthRegen);
		SetAllUnitsWithTagInvulnerable(list4, mayNotHaveTags, _invulnerable: true);
	}

	public static void KillAllEnemyUnits()
	{
		List<TagManager.ETag> list = new List<TagManager.ETag>();
		List<TagManager.ETag> mayNotHaveTags = new List<TagManager.ETag>();
		list.Add(TagManager.ETag.EnemyOwned);
		KillAllUnitsWithTag(list, mayNotHaveTags);
	}

	public static void KillAllPlayerUnits()
	{
		List<TagManager.ETag> list = new List<TagManager.ETag>();
		List<TagManager.ETag> mayNotHaveTags = new List<TagManager.ETag>();
		list.Add(TagManager.ETag.PlayerUnit);
		KillAllUnitsWithTag(list, mayNotHaveTags);
	}
}
