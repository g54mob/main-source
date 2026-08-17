using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Objects.Pooling;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemCactus : ItemBase
{
	private float damagePerAmount = 5f;

	private int numProjectilesPerAmount = 2;

	private float damage;

	private int numProjectiles;

	public static string damageSource;

	private List<Vector3> projectileDirections;

	protected static readonly RaycastHit[] raycastBuffer;

	protected override void OnInitOrAmountChanged()
	{
		//IL_0011: Expected O, but got I4
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected I4, but got Unknown
		object obj = numProjectilesPerAmount * amount;
		int num = obj + 1;
		numProjectiles = num;
		float num2 = (float)amount * damagePerAmount;
		damage = num2;
	}

	public override void Init()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<PlayerHealth, DamageContainer, bool> b = new Action<object, object, bool>(OnTakeDamage);
		Delegate obj = Delegate.Combine(PlayerHealth.A_TakeDamage, b);
		if ((object)obj == null)
		{
			PlayerHealth.A_TakeDamage = (Action<PlayerHealth, DamageContainer, bool>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<PlayerHealth, DamageContainer, bool> action = default(Action<PlayerHealth, DamageContainer, bool>);
		if (action != null)
		{
			PlayerHealth.A_TakeDamage = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public override void Cleanup()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<PlayerHealth, DamageContainer, bool> value = new Action<object, object, bool>(OnTakeDamage);
		Delegate obj = Delegate.Remove(PlayerHealth.A_TakeDamage, value);
		if ((object)obj == null)
		{
			PlayerHealth.A_TakeDamage = (Action<PlayerHealth, DamageContainer, bool>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<PlayerHealth, DamageContainer, bool> action = default(Action<PlayerHealth, DamageContainer, bool>);
		if (action != null)
		{
			PlayerHealth.A_TakeDamage = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private unsafe void OnTakeDamage(PlayerHealth ph, DamageContainer dc, bool isShieldDamage)
	{
		//IL_00ab: Expected O, but got Ref
		//IL_07c1: Expected O, but got Ref
		//IL_07d2: Expected O, but got Ref
		//IL_07d2: Expected O, but got Ref
		//IL_0102: Expected O, but got Ref
		//IL_0287: Expected O, but got I
		//IL_02ed: Expected O, but got I
		//IL_078e: Expected F4, but got I4
		//IL_07a0: Expected O, but got Ref
		//IL_030d: Expected O, but got I
		//IL_031d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0322: Expected O, but got Unknown
		//IL_02c5: Expected O, but got Ref
		//IL_0195: Expected O, but got Ref
		//IL_0608: Unknown result type (might be due to invalid IL or missing references)
		//IL_060d: Expected O, but got Unknown
		//IL_0366: Expected O, but got I4
		//IL_03f6: Expected O, but got Ref
		//IL_03f6: Expected O, but got Ref
		//IL_040b: Expected O, but got Ref
		//IL_041e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0423: Expected O, but got Unknown
		//IL_06fd: Expected O, but got Ref
		//IL_0529: Unknown result type (might be due to invalid IL or missing references)
		//IL_052e: Expected O, but got Unknown
		//IL_053e: Expected O, but got I
		//IL_0485: Expected O, but got I4
		//IL_0485: Expected O, but got F4
		//IL_04d7: Expected O, but got Ref
		//IL_0503: Expected O, but got I4
		//IL_0503: Expected O, but got F4
		//IL_0503: Expected O, but got Ref
		//IL_0503: Expected O, but got Ref
		float stat = PlayerStats.GetStat(EStat.Thorns);
		PoolManager instance = PoolManager.Instance;
		GameObject gameObject = instance.cactusPool.Get();
		float x = default(float);
		float num = default(float);
		if (gameObject != null)
		{
			Transform transform = gameObject.transform;
			Transform transform2 = MyPlayer.Instance.transform;
			Vector3 position = transform2.position;
			transform.position = (Vector3)(&x);
			Transform transform3 = gameObject.transform;
			MyPlayer instance2 = MyPlayer.Instance;
			Transform transform4 = instance2.playerRenderer.transform;
			Quaternion rotation = transform4.rotation;
			transform3.rotation = (Quaternion)(&num);
			ParticleSystem component = gameObject.GetComponent<ParticleSystem>();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181565C70");
			int num2 = numProjectiles;
			if (numProjectiles >= 3)
			{
				if (num2 > 40)
				{
					num2 = 40;
				}
			}
			else
			{
				num2 = 3;
			}
			ParticleSystem.EmissionModule emissionModule = default(ParticleSystem.EmissionModule);
			ParticleSystem.Burst burst = emissionModule.GetBurst(0);
			ParticleSystem.MinMaxCurve minMaxCurve = num2;
			ParticleSystem.Burst burst2 = default(ParticleSystem.Burst);
			ParticleSystemCurveMode particleSystemCurveMode = default(ParticleSystemCurveMode);
			burst2.count = (ParticleSystem.MinMaxCurve)(&particleSystemCurveMode);
			ParticleSystem.Burst burst3 = default(ParticleSystem.Burst);
			emissionModule.SetBurst(0, (ParticleSystem.Burst)(&burst3));
		}
		List<Vector3> list = projectileDirections;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ rcx_v10 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		MyPlayer instance3 = MyPlayer.Instance;
		Transform transform5 = instance3.playerRenderer.transform;
		Vector3 forward = transform5.forward;
		Vector3 up = transform5.up;
		int num3 = numProjectiles;
		if (numProjectiles >= 2)
		{
			if (num3 > 50)
			{
				num3 = 50;
			}
		}
		else
		{
			num3 = 2;
		}
		float num4 = 360f / (float)num3;
		Enemy enemy = null;
		float num5 = default(float);
		float x2 = default(float);
		do
		{
			float angle = (float)enemy * num4;
			Quaternion quaternion = Quaternion.AngleAxis(angle, (Vector3)(&x));
			Vector3 vector = (Quaternion)(&num) * (Vector3)(&num5);
			List<Vector3> list2 = projectileDirections;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rcx_v19 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rcx_v19 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rcx_v19 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rdx_v11+18]");
			if (num6 >= 0)
			{
				list2.AddWithResize((Vector3)(&x2));
				x2 = vector.x;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rcx_v19 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				object obj2 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rcx_v19 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				object obj3 = (nint)0 * (nint)2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rcx_v19 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				object obj4 = 0 + obj3;
				_ = vector.x;
				_ = vector.z;
			}
			enemy = (Enemy)(enemy + 1);
		}
		while ((nint)enemy < num3);
		float baseDamage = damage + stat;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18114D740");
		Enemy enemy2 = null;
		RaycastHit raycastHit = (RaycastHit)0;
		x = up.x;
		List<Vector3>.Enumerator enumerator = default(List<Vector3>.Enumerator);
		float num8 = default(float);
		int num9 = default(int);
		object obj6 = default(object);
		float num10 = default(float);
		Vector3 zeroVector = default(Vector3);
		bool useSfx = default(bool);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
				Component instance4 = MyPlayer.Instance;
				if ((object)MyPlayer.Instance == null)
				{
					break;
				}
				Transform transform6 = MyPlayer.Instance.transform;
				if ((object)transform6 != null)
				{
					Vector3 position2 = transform6.position;
					instance4 = GameManager.Instance;
					if ((object)GameManager.Instance != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
						int num7 = Physics.SphereCastNonAlloc((Vector3)(&num5), 0.5f, (Vector3)(&x2), raycastBuffer, num8, num9);
						Enemy enemy3 = null;
						Vector3 vector2 = (Vector3)(&num5);
						while ((nint)enemy3 < num7)
						{
							RaycastHit[] array = raycastBuffer;
							bool flag = raycastBuffer == null;
							instance4 = (Component)vector2;
							if (!flag)
							{
								object obj5 = enemy3 * 44;
								Collider collider = raycastHit.collider;
								bool flag2 = (object)EnemyManager.Instance == null;
								instance4 = (Component)(&raycastHit);
								if (!flag2)
								{
									bool enemy4 = EnemyManager.Instance.GetEnemy(collider, out enemy2);
									bool flag3 = !enemy4;
									vector2 = (Vector3)EnemyManager.Instance;
									if (!flag3)
									{
										DamageContainer damageContainer = WeaponUtility.GetDamageContainer(null, baseDamage, 0.5f, damageSource, (Vector3)num8, (Enemy)num9);
										bool flag4 = (object)enemy2 == null;
										instance4 = enemy2;
										if (flag4)
										{
											throw new NullReferenceException();
										}
										enemy2.DamageFromPlayerOther(damageContainer);
										bool flag5 = (object)enemy2 == null;
										instance4 = enemy2;
										if (flag5)
										{
											throw new NullReferenceException();
										}
										Vector3 centerPosition = enemy2.GetCenterPosition();
										instance4 = (Component)(&obj6);
										if ((object)EffectManager.Instance == null)
										{
											throw new NullReferenceException();
										}
										EffectManager.Instance.EnemyHitEffect((Vector3)(&num10), (Vector3)(&zeroVector), hitEnemy: true, (string)num8, (GameObject)num9, useSfx);
										zeroVector = Vector3.zeroVector;
										vector2 = (Vector3)EffectManager.Instance;
									}
									enemy3 = (Enemy)(enemy3 + 1);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1426 @ rcx_v45+20+v1371 @ rdx_v27 (UnityEngine.RaycastHit[])]");
									raycastHit = (RaycastHit)0;
									continue;
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						continue;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			enumerator.Dispose();
			return;
		}
		throw new NullReferenceException();
	}

	public ItemCactus(ItemInventory itemInventoryRef)
	{
		List<Vector3> list = new List<Vector3>();
		projectileDirections = list;
		base._002Ector(itemInventoryRef);
	}

	public override void Tick()
	{
	}

	public override void PreAttack(DamageContainer dc, StatComponents itemAttackModifier)
	{
	}

	public override bool HasPreAttackProc()
	{
		return false;
	}

	public override void ProcOnHitEffects(DamageContainer dc)
	{
	}

	public override bool HasOnHitEffectProc()
	{
		return false;
	}

	public override string GetDescription(LocalizedString localizedString)
	{
		//IL_01ba: Expected O, but got I
		//IL_0079: Expected O, but got I4
		//IL_0087: Expected I, but got O
		//IL_009d: Expected I, but got O
		//IL_00b6: Expected O, but got I
		//IL_00de: Expected O, but got I
		//IL_00e6: Expected I, but got O
		//IL_01eb: Expected O, but got I
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected I, but got Unknown
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		string text = EnumUtility.EnumToReadable(EStat.Thorns);
		if (text == null)
		{
			text = "";
		}
		bool flag = dictionary == null;
		IntPtr intPtr = default(IntPtr);
		object obj = (nint)intPtr;
		object obj2 = "stat1";
		nint num = 3;
		if (!flag)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"stat1", (object)text);
			object[] array = new object[1];
			bool flag2 = array == null;
			obj = text;
			obj2 = 1;
			num = (nint)typeof(object[]);
			if (!flag2)
			{
				nint num2 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rdx_v9 (Il2CppClass<System.Object[]>)+40]");
				dictionary.Add((string)0, text);
				object obj3 = default(object);
				bool flag3 = obj3 == null;
				obj = text;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rdx_v9 (Il2CppClass<System.Object[]>)+40]");
				obj2 = 0;
				num = (nint)dictionary;
				if (flag3)
				{
					((Dictionary<string, object>)num).Add((string)obj2, obj);
					object obj4 = default(object);
					throw obj4;
				}
				if (array.Length <= 0)
				{
					return (string)(object)new IndexOutOfRangeException();
				}
				num = (nint)(array + 32);
				array[0] = dictionary;
				bool flag4 = localizedString == null;
				obj = text;
				obj2 = dictionary;
				if (!flag4)
				{
					return localizedString.GetLocalizedString(array);
				}
			}
		}
		throw new NullReferenceException();
	}

	unsafe static ItemCactus()
	{
		//IL_0018: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		damageSource = text;
		RaycastHit[] array = new RaycastHit[1];
		raycastBuffer = array;
	}
}
