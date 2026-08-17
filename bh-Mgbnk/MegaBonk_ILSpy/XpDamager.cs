using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Managers;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class XpDamager : MonoBehaviour
{
	public Pickup pickup;

	private bool isEnabled;

	private float damage;

	private float radius = 0.4f;

	private Vector3 dir;

	private static readonly RaycastHit[] _hits;

	private Vector3 lastPos;

	private Dictionary<Collider, float> enemyHitCooldowns;

	private float hitCooldown;

	private static string damageSource;

	private static DamageContainer reuseDc;

	private void OnEnable()
	{
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		ItemInventory itemInventory = inventory.itemInventory;
		bool flag = ((Dictionary<System.Int32Enum, object>)(object)itemInventory.items).ContainsKey((System.Int32Enum)31);
		isEnabled = flag;
		Pickup pickup = this.pickup;
		float num = (float)pickup.value * ItemShatteredWisdom.damage;
		damage = num;
	}

	private void Awake()
	{
		//IL_0085: Expected O, but got I4
		//IL_008e: Expected O, but got I4
		//IL_009c: Expected I, but got O
		Pickup pickup = this.pickup;
		Action<int> b = OnValueUpdated;
		Delegate obj = Delegate.Combine(pickup.A_ValueUpdated, b);
		if ((object)obj == null)
		{
			pickup.A_ValueUpdated = (Action<int>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<int> action = default(Action<int>);
		bool flag = action == null;
		object obj2 = 0;
		object obj3 = 0;
		nint num = (nint)typeof(Action<int>);
		Delegate obj4 = obj;
		if (!flag)
		{
			pickup.A_ValueUpdated = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			if (obj5 != null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			object obj6 = default(object);
			obj2 = obj6;
			object obj7 = default(object);
			obj3 = obj7;
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			Delegate obj8 = default(Delegate);
			obj4 = obj8;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnDestroy()
	{
		//IL_0085: Expected O, but got I4
		//IL_008e: Expected O, but got I4
		//IL_009c: Expected I, but got O
		Pickup pickup = this.pickup;
		Action<int> value = OnValueUpdated;
		Delegate obj = Delegate.Remove(pickup.A_ValueUpdated, value);
		if ((object)obj == null)
		{
			pickup.A_ValueUpdated = (Action<int>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<int> action = default(Action<int>);
		bool flag = action == null;
		object obj2 = 0;
		object obj3 = 0;
		nint num = (nint)typeof(Action<int>);
		Delegate obj4 = obj;
		if (!flag)
		{
			pickup.A_ValueUpdated = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			if (obj5 != null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			object obj6 = default(object);
			obj2 = obj6;
			object obj7 = default(object);
			obj3 = obj7;
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			Delegate obj8 = default(Delegate);
			obj4 = obj8;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnValueUpdated(int value)
	{
		Pickup pickup = this.pickup;
		float num = (float)pickup.value * ItemShatteredWisdom.damage;
		damage = num;
	}

	private void FixedUpdate()
	{
		if (isEnabled)
		{
			StepMovement();
		}
	}

	protected unsafe virtual void StepMovement()
	{
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_0098: Expected F4, but got O
		//IL_0098: Expected O, but got Ref
		//IL_00b7: Expected O, but got I4
		//IL_0160: Expected O, but got F4
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected O, but got Unknown
		Transform transform = base.transform;
		float num = transform.position.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (XpDamager)+48]");
		float num2 = num - 0f;
		Vector3 vector = default(Vector3);
		dir = vector;
		Transform transform2 = base.transform;
		Vector3 position = transform2.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		object obj = this + 52;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
		GameManager instance = GameManager.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
		object obj2 = default(object);
		object obj3 = default(object);
		int layerMask = default(int);
		int num3 = Physics.SphereCastNonAlloc((Ray)(&obj2), radius, _hits, (float)obj3, layerMask);
		bool flag = num3 <= 0;
		object obj4 = 0;
		if (!flag)
		{
			do
			{
				object obj5 = _hits + 32;
				object obj6 = obj4 * 44;
				RaycastHit raycastHit = (RaycastHit)(obj6 + obj5);
				Collider collider = ((RaycastHit*)raycastHit)->collider;
				HitEnemy(collider);
				obj4++;
			}
			while ((nint)obj4 < num3);
		}
		Transform transform3 = base.transform;
		Vector3 position2 = transform3.position;
		lastPos = (Vector3)position2.x;
		_ = position2.z;
	}

	private unsafe void HitEnemy(Collider collider)
	{
		//IL_0134: Expected I4, but got O
		//IL_0134: Expected O, but got Ref
		//IL_0134: Expected O, but got Ref
		if (enemyHitCooldowns.TryGetValue(collider, out var value))
		{
			float num = MyTime.time - value;
			if (hitCooldown > num)
			{
				return;
			}
		}
		if (EnemyManager.Instance.GetEnemy(collider, out var enemy) && !enemy.IsDead())
		{
			((Dictionary<object, float>)(object)enemyHitCooldowns).set_Item((object)collider, MyTime.time);
			Vector3 vector = default(Vector3);
			Enemy enemy2 = default(Enemy);
			DamageContainer damageContainer = WeaponUtility.GetDamageContainer(reuseDc, damage, ItemShatteredWisdom.procCoefficient, damageSource, vector, enemy2);
			reuseDc = damageContainer;
			enemy.DamageFromPlayerOther(reuseDc);
			Transform transform = base.transform;
			Vector3 position = transform.position;
			bool hitEnemy = enemy;
			object obj = default(object);
			Vector3 vector2 = default(Vector3);
			bool useSfx = default(bool);
			EffectManager.Instance.EnemyHitEffect((Vector3)(&obj), (Vector3)(&vector2), hitEnemy, (EWeapon)vector, (GameObject)(object)enemy2, useSfx);
		}
	}

	public XpDamager()
	{
		Dictionary<Collider, float> dictionary = (Dictionary<Collider, float>)(object)new Dictionary<object, float>(256);
		enemyHitCooldowns = dictionary;
		hitCooldown = 0.2f;
		base._002Ector();
	}

	unsafe static XpDamager()
	{
		//IL_005b: Expected O, but got Ref
		RaycastHit[] hits = new RaycastHit[EnemyManager.maxNumEnemiesPooled];
		_hits = hits;
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		damageSource = text;
		DamageContainer damageContainer = new DamageContainer(1f, damageSource);
		reuseDc = damageContainer;
	}
}
