using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using I2.Loc;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class EME_Blood_BloodRage_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public EME_Blood_BloodRage_Weapon _003C_003E4__this;

		public BulletPool pool;
	}

	private sealed class _003C_003Ec__DisplayClass9_1
	{
		public Vector2 location;

		public int localIndex;

		public _003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals1;

		internal void _003CSpawnSpecialProjectiles_003Eb__0()
		{
			//IL_0131: Expected O, but got I4
			//IL_00a8->IL00fa: Incompatible stack heights: 1 vs 0
			//IL_00ca->IL00fa: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass9_0 obj = CS_0024_003C_003E8__locals1;
			if (CS_0024_003C_003E8__locals1 != null && (object)obj._003C_003E4__this != null)
			{
				GameObject gameObject = obj._003C_003E4__this.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj2 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj2 == null)
					{
						return;
					}
					_003C_003Ec__DisplayClass9_0 obj3 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null && obj3.pool != null)
					{
						float2 pos = default(float2);
						Projectile projectile = obj3.pool.SpawnAt(pos, obj3._003C_003E4__this, localIndex);
						return;
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	protected Projectile _BloodRageSpecialPrefab;

	protected BulletPool _bloodRageSpecialPool;

	protected readonly Dictionary<WeaponType, string> _glimmerNames;

	protected override void Awake()
	{
		base.Awake();
		((Equipment)this)._003CShowInRecap_003Ek__BackingField = false;
	}

	protected unsafe override void OnStart()
	{
		//IL_006e: Expected O, but got Ref
		base.OnStart();
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		string term = "weaponLang/{" + text + "}name";
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		bool flag = ((Dictionary<System.Int32Enum, object>)(object)_glimmerNames).TryInsert((System.Int32Enum)2384, (object)translation, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		SetupSpecialBulletPools();
	}

	private unsafe void AddGlimmerName(WeaponType glimmerWeaponType)
	{
		//IL_005c: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		string term = "weaponLang/{" + text + "}name";
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		bool flag = ((Dictionary<System.Int32Enum, object>)(object)_glimmerNames).TryInsert((System.Int32Enum)glimmerWeaponType, (object)translation, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
	}

	private unsafe string GetGlimmerName(WeaponType weaponType)
	{
		//IL_0033: Expected I4, but got O
		//IL_0058: Expected O, but got Ref
		if (_glimmerNames != null)
		{
			if (!((Dictionary<System.Int32Enum, object>)(object)_glimmerNames).TryGetValue((System.Int32Enum)weaponType, out object value))
			{
				object obj = default(object);
				object arg = (WeaponType)obj;
				System.ParamsArray paramsArray = new System.ParamsArray(arg);
				object obj2 = default(object);
				string message = string.FormatHelper((IFormatProvider)null, "Glimmer weapon types not configured correctly for weapon {0}", (System.ParamsArray)(&obj2));
				GameObject context = base.gameObject;
				Debug.LogWarning(message, context);
				return "Glimmer WeaponType not set";
			}
			return (string)value;
		}
		return (string)(object)new NullReferenceException();
	}

	public unsafe override void Fire(bool skipTriggers = false)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_0067: Invalid comparison between O and F4
		//IL_0092: Expected F4, but got O
		//IL_00f4: Expected I4, but got O
		//IL_0119: Expected O, but got Ref
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 vector = default(Vector2);
		Projectile projectile = base.FireOneProjectile(vector, 0, _targetTransform);
		float num = base.PInterval();
		float num2 = _lastFiringInterval - (float)vector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj = num2 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num3 = base.PInterval();
			_lastFiringInterval = (float)vector;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
		GameManager core = GM.Core;
		Stage stage = core._stage;
		if (!((Dictionary<System.Int32Enum, object>)(object)_glimmerNames).TryGetValue((System.Int32Enum)2384, out object value))
		{
			float2 float5 = default(float2);
			object arg = (WeaponType)float5;
			System.ParamsArray paramsArray = new System.ParamsArray(arg);
			object obj2 = default(object);
			string message = string.FormatHelper((IFormatProvider)null, "Glimmer weapon types not configured correctly for weapon {0}", (System.ParamsArray)(&obj2));
			GameObject context = base.gameObject;
			Debug.LogWarning(message, context);
			object obj3 = "Glimmer WeaponType not set";
		}
		else
		{
			object obj3 = value;
		}
		Tuple<string, WeaponType> glimmerNameAndType = null;
		_ = 2384;
		stage._glimmerManager.AddNewGlimmerTechniqueToShow(glimmerNameAndType);
	}

	public void DoBloodRage(float2 position)
	{
		float areaMul = default(float);
		SpawnSpecialProjectiles(position, _bloodRageSpecialPool, 2f, areaMul);
	}

	public unsafe void SpawnSpecialProjectiles(float2 position, BulletPool pool, float amountMul = 1f, float areaMul = 1f)
	{
		//IL_0056: Expected O, but got Ref
		//IL_005f: Expected I, but got O
		//IL_00aa: Invalid comparison between I4 and F4
		//IL_00cb: Expected F4, but got I4
		//IL_0481: Invalid comparison between F4 and I4
		//IL_0493: Expected F4, but got I4
		//IL_02a7: Expected O, but got I
		//IL_02c2: Expected I4, but got I8
		//IL_0563: Invalid comparison between F4 and I4
		//IL_02df: Invalid comparison between F4 and I4
		//IL_01df: Expected O, but got I
		//IL_023e: Expected O, but got I
		//IL_027f: Expected O, but got I
		//IL_052a->IL0556: Incompatible stack heights: 2 vs 0
		//IL_028d->IL02b5: Incompatible stack heights: 2 vs 0
		_003C_003Ec__DisplayClass9_0 obj = new _003C_003Ec__DisplayClass9_0();
		obj._003C_003E4__this = this;
		obj.pool = pool;
		float num = base.PArea();
		GameManager core = GM.Core;
		object obj2 = default(object);
		object obj3 = default(object);
		float maxRange = (float)obj2 * (float)obj3;
		float2 ret = default(float2);
		List<EnemyController> closestEnemiesSorted = core._stage.GetClosestEnemiesSorted((Vector3)(&ret), excludeDead: true, maxRange);
		nint num2 = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v623 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Blood_BloodRage_Weapon>)+408]");
		nint num3 = 0;
		float num4 = base.PAmount();
		float2 float5 = default(float2);
		float num5 = (float)float5 - 1f;
		float num6 = num5 * amountMul;
		if (!((float)closestEnemiesSorted._size > num6))
		{
			num6 = closestEnemiesSorted._size;
		}
		WeaponData currentWeaponData = _currentWeaponData;
		float num7 = currentWeaponData._003CrepeatInterval_003Ek__BackingField;
		float num8 = base.PInterval();
		float num9 = num6 + 1f;
		float num10 = (float)closestEnemiesSorted._size / num9;
		if (!(num10 > currentWeaponData._003CrepeatInterval_003Ek__BackingField))
		{
			num7 = num10;
		}
		List<Vector2> list = new List<Vector2>();
		bool flag = !(num6 > 0f);
		float num11 = 0f;
		float num13 = default(float);
		int num14;
		bool canPause;
		bool flag5;
		if (!flag)
		{
			bool flag4;
			do
			{
				bool flag2 = !(num11 < (float)closestEnemiesSorted._size);
				EnemyController[] items = closestEnemiesSorted._items;
				ArcadeSprite arcadeSprite = items[num11];
				Transform cachedTrans = ((ArcadeSprite)items[num11]).CachedTrans;
				bool flag3 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
				if (arcadeSprite.body != null)
				{
					BaseBody body = arcadeSprite.body;
					ArcadeTransform arcadeTransform = body._transform;
					arcadeTransform.position = ret;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v672 @ rax_v16 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v672 @ rax_v16 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v672 @ rax_v16 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				nint num12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rcx_v26+18]");
				if (num12 >= 0)
				{
					list.AddWithResize((Vector2)float5);
					num3 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v672 @ rax_v16 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
					object obj5 = (nint)0 + (nint)1;
					num3 = 0;
				}
				num11++;
				flag4 = num6 > num11;
				num10 = num11;
				num9 = num13;
			}
			while (flag4);
			num14 = 0;
			canPause = false;
			num9 = num13;
			Weapon weapon = (Weapon)num3;
			flag5 = false;
		}
		else
		{
			num14 = 0;
			canPause = false;
			Weapon weapon = (Weapon)num3;
			flag5 = false;
		}
		int num15 = -1986357120;
		Vector2 location = default(Vector2);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		while (true)
		{
			bool num16 = flag5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v672 @ rax_v16 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)(num16 ? 1 : 0) >= (nint)0)
			{
				break;
			}
			float num17 = (float)num14 * num7;
			Weapon weapon;
			if (!(num17 > 0f))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
				Projectile projectile = obj.pool.SpawnAt(float5, this, num14);
				num14++;
				num9 = num13;
				weapon = this;
				num15 = num14;
				flag5 = (byte)num14 != 0;
				continue;
			}
			_003C_003Ec__DisplayClass9_1 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass9_1();
			CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1 = obj;
			CS_0024_003C_003E8__locals8.localIndex = num14;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
			CS_0024_003C_003E8__locals8.location = location;
			Action onComplete = delegate
			{
				//IL_0131: Expected O, but got I4
				//IL_00a8->IL00fa: Incompatible stack heights: 1 vs 0
				//IL_00ca->IL00fa: Incompatible stack heights: 1 vs 0
				_003C_003Ec__DisplayClass9_0 obj6 = CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1;
				if (CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1 != null && (object)obj6._003C_003E4__this != null)
				{
					GameObject gameObject = obj6._003C_003E4__this.gameObject;
					if ((object)gameObject != null)
					{
						bool flag6 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
						object obj7 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
						if (obj7 == null)
						{
							return;
						}
						_003C_003Ec__DisplayClass9_0 obj8 = CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1;
						if (CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1 != null && obj8.pool != null)
						{
							float2 pos = default(float2);
							Projectile projectile2 = obj8.pool.SpawnAt(pos, obj8._003C_003E4__this, CS_0024_003C_003E8__locals8.localIndex);
							return;
						}
					}
				}
				throw new NullReferenceException();
			};
			float num18 = (float)num14 * num7;
			float duration = num18 * 0.001f;
			Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause);
			_lastShotTimer = lastShotTimer;
			num14++;
			num9 = num13;
			weapon = null;
			num15 = 0;
			flag5 = (byte)num14 != 0;
		}
	}

	private void SetupSpecialBulletPools()
	{
		//IL_0137: Expected I, but got O
		Projectile bloodRageSpecialPrefab = _BloodRageSpecialPrefab;
		if ((object)_BloodRageSpecialPrefab != null && ((UnityEngine.Object)bloodRageSpecialPrefab).m_CachedPtr != (IntPtr)0)
		{
			BulletPool bloodRageSpecialPool = new BulletPool(_BloodRageSpecialPrefab, 20);
			_bloodRageSpecialPool = bloodRageSpecialPool;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			ArcadePhysicsCallback collideCallback = OnBulletOverlapsEnemyDamagex2;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_bloodRageSpecialPool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Blood_BloodRage_Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider2 = physics2.add.overlap(_bloodRageSpecialPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
		}
	}

	protected bool OnBulletOverlapsEnemyDamagex2(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0159: Expected I4, but got O
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_0176;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									float num = base.PPower();
									float num2 = base.CalcCritMul();
									object obj2 = default(object);
									object obj = obj2 + obj2;
									float damage = (float)obj2 * (float)obj;
									base.DealDamage(component, damage);
								}
								goto IL_0176;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0176:
		return false;
	}

	public EME_Blood_BloodRage_Weapon()
	{
		Dictionary<WeaponType, string> glimmerNames = new Dictionary<WeaponType, string>();
		_glimmerNames = glimmerNames;
		base._002Ector();
	}
}
