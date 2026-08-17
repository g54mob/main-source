using System;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Managers;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Localization;

public class InteractableSkeletonKingStatue : BaseInteractable
{
	public EnemyData enemyData;

	public LocalizedString interactString;

	public GameObject chargeFx;

	public GameObject explodeFx;

	private Enemy myEnemy;

	private bool done;

	private void Awake()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<Enemy, DamageContainer> b = OnEnemyDied;
		Delegate obj = Delegate.Combine(Enemy.A_EnemyDied, b);
		if ((object)obj == null)
		{
			Enemy.A_EnemyDied = (Action<Enemy, DamageContainer>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy, DamageContainer> action = default(Action<Enemy, DamageContainer>);
		if (action != null)
		{
			Enemy.A_EnemyDied = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<Enemy, DamageContainer>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<Enemy, DamageContainer>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private new void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<Enemy, DamageContainer> value = OnEnemyDied;
		Delegate obj = Delegate.Remove(Enemy.A_EnemyDied, value);
		if ((object)obj == null)
		{
			Enemy.A_EnemyDied = (Action<Enemy, DamageContainer>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy, DamageContainer> action = default(Action<Enemy, DamageContainer>);
		if (action != null)
		{
			Enemy.A_EnemyDied = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<Enemy, DamageContainer>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<Enemy, DamageContainer>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnEnemyDied(Enemy enemy, DamageContainer dc)
	{
		if (myEnemy == enemy)
		{
			bool flag = MyAchievements.TryUnlock("a_graveyard");
			MyPlayer instance = MyPlayer.Instance;
			Transform transform = base.transform;
			instance.minimapCameraScript.RemoveArrow(transform);
		}
	}

	public override bool Interact()
	{
		//IL_00f1: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172C91]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (!done)
		{
			done = true;
			if ((object)chargeFx != null)
			{
				chargeFx.SetActive(value: true);
				if ((object)chargeFx != null)
				{
					Transform transform = chargeFx.transform;
					if ((object)transform != null)
					{
						transform.parentInternal = null;
						Invoke("SpawnEnemy", 1f);
						return true;
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	private void SpawnEnemy()
	{
		explodeFx.SetActive(value: true);
		Transform transform = explodeFx.transform;
		transform.parentInternal = null;
		EnemyData enemyData = this.enemyData;
		Transform transform2 = base.transform;
		Vector3 position = transform2.position;
		Vector3 pos = default(Vector3);
		float extraSizeMultiplier = default(float);
		Enemy enemy = EnemyManager.Instance.SpawnBoss(enemyData.enemyName, 0, EEnemyFlag.Boss, pos, extraSizeMultiplier);
		myEnemy = enemy;
		Enemy enemy2 = myEnemy;
		enemy2.teleportTime = 0.01f;
		myEnemy.SetSwarmMultiplierHp(65f);
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
	}

	public override string GetInteractString()
	{
		if (interactString != null)
		{
			return interactString.GetLocalizedString();
		}
		return (string)(object)new NullReferenceException();
	}

	public InteractableSkeletonKingStatue()
	{
		showOutline = true;
		((MonoBehaviour)this)._002Ector();
	}
}
