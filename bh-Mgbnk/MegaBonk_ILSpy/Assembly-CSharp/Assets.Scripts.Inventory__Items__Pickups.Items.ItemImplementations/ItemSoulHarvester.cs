using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Objects.Pooling;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemSoulHarvester : ItemBase
{
	private string damageSource;

	public const int maxProjectiles = 100;

	private int numProjectiles;

	private float damageMultiplier;

	private float range;

	private Dictionary<GameObject, ItemProjectile> projectileLookup;

	public override void Init()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<Enemy> b = OnEnemyDied;
		Delegate obj = Delegate.Combine(Enemy.A_EnemyReleasedFromPool, b);
		if ((object)obj == null)
		{
			Enemy.A_EnemyReleasedFromPool = (Action<Enemy>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy> action = default(Action<Enemy>);
		if (action != null)
		{
			Enemy.A_EnemyReleasedFromPool = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<Enemy>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<Enemy>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public override void Cleanup()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<Enemy> value = OnEnemyDied;
		Delegate obj = Delegate.Remove(Enemy.A_EnemyReleasedFromPool, value);
		if ((object)obj == null)
		{
			Enemy.A_EnemyReleasedFromPool = (Action<Enemy>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy> action = default(Action<Enemy>);
		if (action != null)
		{
			Enemy.A_EnemyReleasedFromPool = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<Enemy>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<Enemy>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	protected override void OnInitOrAmountChanged()
	{
		//IL_000c: Expected F4, but got I4
		damageMultiplier = amount;
	}

	private float GetDamage()
	{
		MyPlayer instance = MyPlayer.Instance;
		float num = instance.baseDamage * damageMultiplier;
		float num2 = num * 1.75f;
		return num2 - 9f;
	}

	private unsafe void OnEnemyDied(Enemy enemy)
	{
		//IL_0067: Expected O, but got I4
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Expected O, but got Unknown
		//IL_019b: Expected F4, but got O
		//IL_019b: Expected F4, but got O
		//IL_019b: Expected O, but got Ref
		if (numProjectiles <= 0)
		{
			return;
		}
		object obj = 0;
		float num3 = default(float);
		string text = default(string);
		ObjectPool<GameObject> projectilePool = default(ObjectPool<GameObject>);
		int projectileIndex = default(int);
		int totalProjectiles = default(int);
		do
		{
			Transform transform = enemy.transform;
			Vector3 position = transform.position;
			PoolManager instance = PoolManager.Instance;
			GameObject gameObject = instance.angrySoulPool.Get();
			if (gameObject != null)
			{
				gameObject.SetActive(value: true);
				if (!projectileLookup.ContainsKey(gameObject))
				{
					ItemProjectile component = gameObject.GetComponent<ItemProjectile>();
					((Dictionary<object, object>)(object)projectileLookup).Add((object)gameObject, (object)component);
				}
				ItemProjectile itemProjectile = projectileLookup.get_Item(gameObject);
				MyPlayer instance2 = MyPlayer.Instance;
				float num = instance2.baseDamage * damageMultiplier;
				float num2 = num * 1.75f;
				float damage = num2 - 9f;
				PoolManager instance3 = PoolManager.Instance;
				itemProjectile.Set((Vector3)(&num3), damage, 0.85f, text, projectilePool, projectileIndex, totalProjectiles, (float)damageSource, (float)instance3.angrySoulPool);
			}
			obj++;
		}
		while ((nint)obj < numProjectiles);
	}

	private unsafe void SpawnProjectile(Vector3 pos)
	{
		//IL_0116: Expected F4, but got O
		//IL_0116: Expected F4, but got O
		//IL_0116: Expected O, but got Ref
		PoolManager instance = PoolManager.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002620");
		UnityEngine.Object obj = default(UnityEngine.Object);
		if (obj != null)
		{
			((GameObject)obj).SetActive(true);
			if (!projectileLookup.ContainsKey((GameObject)obj))
			{
				ItemProjectile component = ((GameObject)obj).GetComponent<ItemProjectile>();
				((Dictionary<object, object>)(object)projectileLookup).Add((object)obj, (object)component);
			}
			ItemProjectile itemProjectile = projectileLookup.get_Item((GameObject)obj);
			MyPlayer instance2 = MyPlayer.Instance;
			float num = instance2.baseDamage * damageMultiplier;
			float num2 = num * 1.75f;
			float damage = num2 - 9f;
			PoolManager instance3 = PoolManager.Instance;
			object obj2 = default(object);
			string text = default(string);
			ObjectPool<GameObject> projectilePool = default(ObjectPool<GameObject>);
			int projectileIndex = default(int);
			int totalProjectiles = default(int);
			itemProjectile.Set((Vector3)(&obj2), damage, 0.85f, text, projectilePool, projectileIndex, totalProjectiles, (float)damageSource, (float)instance3.angrySoulPool);
		}
	}

	public override void Tick()
	{
	}

	public unsafe ItemSoulHarvester(ItemInventory itemInventoryRef)
	{
		//IL_0036: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		damageSource = text;
		numProjectiles = 2;
		range = 50f;
		Dictionary<GameObject, ItemProjectile> dictionary = (Dictionary<GameObject, ItemProjectile>)(object)new Dictionary<object, object>(100);
		((Dictionary<object, object>)(object)dictionary)._002Ector(100);
		projectileLookup = dictionary;
		base._002Ector(itemInventoryRef);
	}

	public override void ProcOnHitEffects(DamageContainer dc)
	{
	}

	public override bool HasOnHitEffectProc()
	{
		return false;
	}

	public override void PreAttack(DamageContainer dc, StatComponents itemAttackModifier)
	{
	}

	public override bool HasPreAttackProc()
	{
		return false;
	}

	protected override Dictionary<string, object> GetLocalizationKeys()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		string value = $"{arg}";
		if (dictionary != null)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)value);
			return dictionary;
		}
		return (Dictionary<string, object>)(object)new NullReferenceException();
	}
}
