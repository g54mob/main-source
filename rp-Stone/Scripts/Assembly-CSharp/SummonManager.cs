using System.Collections.Generic;
using UnityEngine;

public class SummonManager : MonoBehaviour
{
	private readonly string PATH_PREFIX = "Summons/";

	public static SummonManager singleton { get; private set; }

	public void PreloadSummon(string id)
	{
		Utils.PreloadAsyncPrefab(PATH_PREFIX + id);
	}

	public bool HasSummonWithId(string id)
	{
		List<Summon> summons = GameStates.Singleton.level.Summons;
		for (int i = 0; i < summons.Count; i++)
		{
			Summon summon = summons[i];
			if (summon.Alive && summon.id == id)
			{
				return true;
			}
		}
		return false;
	}

	public Summon SummonAlly(string id, Weapon sourceWeapon)
	{
		string prefabPath = PATH_PREFIX + id;
		GameStates gameStates = GameStates.Singleton;
		Hero hero = gameStates.hero;
		if (gameStates.level.Summons.Count >= hero.maxSummons)
		{
			UnsummonOldest();
		}
		Summon component = Utils.InstantiatePrefab(prefabPath).GetComponent<Summon>();
		if (sourceWeapon != null)
		{
			component.sourceWeapon = sourceWeapon;
			component.owner = sourceWeapon.Owner;
		}
		component.PositionX = hero.PositionX + component.wakeupDistance;
		component.PositionY = hero.PositionY;
		component.PositionZ = hero.PositionZ;
		gameStates.level.AddCharacter(component);
		return component;
	}

	public void Unsummon(string id)
	{
		List<Summon> summons = GameStates.Singleton.level.Summons;
		for (int i = 0; i < summons.Count; i++)
		{
			Summon summon = summons[i];
			if (summon.Alive && summon.id == id)
			{
				summon.Die(Character.DeathReason.Custom);
				break;
			}
		}
	}

	public void UnsummonOldest()
	{
		List<Summon> summons = GameStates.Singleton.level.Summons;
		if (summons.Count > 0)
		{
			Summon summon = summons[0];
			if (summon.Alive)
			{
				summon.Die(Character.DeathReason.Custom);
			}
		}
	}

	private void HandleSummonDied(Summon summon)
	{
		Level level = GameStates.Singleton.level;
		level.Summons.Remove(summon);
		level.DeadSummons.Add(summon);
	}

	private void OnDestroy()
	{
		Summon.OnSummonDied -= HandleSummonDied;
	}

	private void Awake()
	{
		singleton = this;
		Summon.OnSummonDied += HandleSummonDied;
	}
}
