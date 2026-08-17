using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Actors.Enemies;
using Assets.Scripts._Data.MapsAndStages;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Game.Other;
using Assets.Scripts.Game.Spawning;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.GoldAndMoney;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory__Items__Pickups.Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Managers;
using Assets.Scripts.MapGeneration;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Objects.Pooling;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.Saves___Serialization.Progression.Challenges;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using Assets.Scripts.Saves___Serialization.SaveFiles.Configs.ConfigSettingsTypes;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Assets.Scripts.UI.InGame.Rewards;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using Inventory__Items__Pickups;
using Inventory__Items__Pickups.Xp_and_Levels;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Pool;
using Utility;

public class EffectManager : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal EWeapon _003C_002Ecctor_003Eb__121_0(EWeapon w)
		{
			return w;
		}

		internal unsafe string _003C_002Ecctor_003Eb__121_1(EWeapon w)
		{
			//IL_000e: Expected O, but got Ref
			object obj = default(object);
			return ((Enum)(&obj)).ToString();
		}
	}

	private sealed class _003CDoSpawnRockets_003Ed__93 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float damage;

		public float procCoefficient;

		public string damageSource;

		public int num;

		private int _003Ci_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CDoSpawnRockets_003Ed__93(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_021b: Expected I4, but got I8
			//IL_0015: Expected O, but got I4
			//IL_0071: Expected I4, but got I8
			//IL_01ed: Expected I4, but got O
			//IL_016d: Expected O, but got Ref
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (flag)
				{
					_003C_003E1__state = -1;
					goto IL_023e;
				}
				if ((nint)obj != 1)
				{
					goto IL_01d9;
				}
				int num = _003Ci_003E5__2 + 1;
				_003Ci_003E5__2 = num;
			}
			else
			{
				_003Ci_003E5__2 = 0;
			}
			_003C_003E1__state = -1;
			if (_003Ci_003E5__2 >= this.num)
			{
				goto IL_01d9;
			}
			goto IL_023e;
			IL_023e:
			if (MyTime.paused)
			{
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			PoolManager instance = PoolManager.Instance;
			if ((object)PoolManager.Instance != null && instance.rocketPool != null)
			{
				GameObject gameObject = instance.rocketPool.Get();
				if ((object)gameObject != null)
				{
					Rocket component = gameObject.GetComponent<Rocket>();
					if ((object)MyPlayer.Instance != null)
					{
						Transform transform = MyPlayer.Instance.transform;
						if ((object)transform != null)
						{
							Vector3 position = transform.position;
							if ((object)component != null)
							{
								object obj2 = default(object);
								WeaponBase weaponBase = default(WeaponBase);
								bool useGenericPool = default(bool);
								string text = default(string);
								component.Set((Vector3)(&obj2), damage, procCoefficient, weaponBase, useGenericPool, text);
								if (MyRandom.random != null)
								{
									double num2 = MyRandom.random.NextDouble();
									float seconds = default(float);
									WaitForSeconds waitForSeconds = new WaitForSeconds(seconds);
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm1,xmm6\"");
									float num3 = 0f * 0.07f;
									seconds = num3 + 0.07f;
									_003C_003E2__current = waitForSeconds;
									_003C_003E1__state = 2;
									return true;
								}
							}
						}
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_01d9:
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			NotSupportedException ex = new NotSupportedException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}
	}

	private sealed class _003CExploderDeath_003Ed__71 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public EffectManager _003C_003E4__this;

		public Enemy enemy;

		private float _003CexplosionRadius_003E5__2;

		private float _003CinflationTime_003E5__3;

		private float _003Ctimer_003E5__4;

		private float _003CrotationSpeed_003E5__5;

		private Vector3 _003CdefaultScale_003E5__6;

		private Vector3 _003CdesiredScale_003E5__7;

		private float _003CrotationTimer_003E5__8;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CExploderDeath_003Ed__71(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0008: Expected O, but got Ref
			//IL_0082: Expected I4, but got I8
			//IL_082d: Expected I4, but got O
			//IL_001d: Expected O, but got I4
			//IL_006e: Expected I4, but got I8
			//IL_005a: Expected I4, but got I8
			//IL_04f5: Invalid comparison between I4 and F4
			//IL_0540: Expected F4, but got I4
			//IL_0a31: Expected O, but got I
			//IL_0a4e: Expected O, but got I
			//IL_0959: Expected I, but got O
			//IL_0146: Expected O, but got Ref
			//IL_0154: Expected O, but got Ref
			//IL_0558: Expected O, but got Ref
			//IL_04aa: Expected O, but got Ref
			//IL_01f4: Expected I4, but got I8
			//IL_062c: Expected O, but got Ref
			//IL_063a: Expected O, but got Ref
			//IL_0244: Expected O, but got I4
			//IL_0244: Expected O, but got I
			//IL_03a3: Expected O, but got F4
			//IL_0787: Expected O, but got Ref
			//IL_0320: Expected O, but got Ref
			object obj2 = default(object);
			object obj = (object)(&obj2);
			EffectManager effectManager = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj3 = _003C_003E1__state - 1;
				if (!flag)
				{
					if ((nint)obj3 != 1)
					{
						goto IL_0811;
					}
					_003C_003E1__state = -1;
					goto IL_0856;
				}
				_003C_003E1__state = -1;
				goto IL_08e2;
			}
			_003C_003E1__state = -1;
			if ((object)_003C_003E4__this != null && effectManager.currentlyExplodingEnemy != null)
			{
				bool flag2 = effectManager.currentlyExplodingEnemy.Add(this.enemy);
				if ((object)this.enemy != null)
				{
					this.enemy.MakeWhite();
					if ((object)this.enemy != null)
					{
						Vector3 feetPosition = this.enemy.GetFeetPosition();
						Quaternion rotation = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
						Vector3 position = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
						_ = Quaternion.identityQuaternion;
						_ = feetPosition.x;
						_ = feetPosition.z;
						GameObject gameObject = UnityEngine.Object.Instantiate(effectManager.americanExplosionEffectStart, position, rotation);
						_003CexplosionRadius_003E5__2 = 8f;
						_003CinflationTime_003E5__3 = 0.75f;
						_003CrotationSpeed_003E5__5 = 400f;
						int num = UnityEngine.Random.Range(0, 2);
						bool flag3 = num == 0;
						int num2 = 1;
						if (!flag3)
						{
							num2 = -1;
						}
						float num3 = (float)num2 * 400f;
						_003CrotationSpeed_003E5__5 = num3;
						if ((object)this.enemy != null)
						{
							Vector3 feetPosition2 = this.enemy.GetFeetPosition();
							PoolManager instance = PoolManager.Instance;
							if ((object)PoolManager.Instance != null && instance.warningSpherePool != null)
							{
								GameObject gameObject2 = UnityEngine.Object.Instantiate((GameObject)(object)instance.warningSpherePool, (Vector3)0, (Quaternion)0);
								if (!(gameObject2 != null))
								{
									goto IL_033c;
								}
								if ((object)gameObject2 != null)
								{
									gameObject2.SetActive(value: true);
									CircleWarning component = gameObject2.GetComponent<CircleWarning>();
									if ((object)component != null)
									{
										component.Set(_003CexplosionRadius_003E5__2, _003CinflationTime_003E5__3, null);
										Transform transform = gameObject2.transform;
										if ((object)transform != null)
										{
											_ = feetPosition2.x;
											Vector3 position2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
											_ = feetPosition2.z;
											transform.position = position2;
											goto IL_033c;
										}
									}
								}
							}
						}
					}
				}
			}
			goto IL_081f;
			IL_0b16:
			if ((object)this.enemy != null)
			{
				Transform transform2 = this.enemy.transform;
				float num4 = _003Ctimer_003E5__4;
				if (!(0f > _003Ctimer_003E5__4))
				{
					if (num4 > 1f)
					{
						num4 = 1f;
					}
				}
				else
				{
					num4 = 0f;
				}
				object obj4 = _003CdesiredScale_003E5__7 - _003CdefaultScale_003E5__6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (EffectManager+<ExploderDeath>d__71)+50]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (EffectManager+<ExploderDeath>d__71)+44]");
				object obj5 = num5 - 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (EffectManager+<ExploderDeath>d__71)+54]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (EffectManager+<ExploderDeath>d__71)+48]");
				object obj6 = num6 - 0;
				float num7 = (float)obj4 * num4;
				float num8 = (float)obj5 * num4;
				float num9 = (float)obj6 * num4;
				float num10 = num7 + (float)_003CdefaultScale_003E5__6;
				float num11 = num8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (EffectManager+<ExploderDeath>d__71)+44]");
				float num12 = num11 + 0f;
				float num13 = num9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (EffectManager+<ExploderDeath>d__71)+48]");
				float num14 = num13 + 0f;
				if ((object)transform2 != null)
				{
					Vector3 localScale = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
					transform2.localScale = localScale;
					_003C_003E2__current = null;
					_003C_003E1__state = 2;
					goto IL_0ad7;
				}
			}
			goto IL_081f;
			IL_081f:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_0811:
			return false;
			IL_033c:
			if ((object)this.enemy != null)
			{
				Transform transform3 = this.enemy.transform;
				if ((object)transform3 != null)
				{
					Vector3 localScale2 = transform3.localScale;
					_003CdefaultScale_003E5__6 = (Vector3)localScale2.x;
					_ = localScale2.z;
					_003CrotationTimer_003E5__8 = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (EffectManager+<ExploderDeath>d__71)+48]");
					float num15 = 0f * 1.5f;
					Vector3 vector = default(Vector3);
					_003CdesiredScale_003E5__7 = vector;
					goto IL_0856;
				}
			}
			goto IL_081f;
			IL_08e2:
			float num16 = MyTime.deltaTime / _003CinflationTime_003E5__3;
			float num17 = num16 + _003Ctimer_003E5__4;
			_003Ctimer_003E5__4 = num17;
			if ((_003CrotationTimer_003E5__8 = MyTime.deltaTime + _003CrotationTimer_003E5__8) > 0.1f)
			{
				if ((object)this.enemy != null)
				{
					Transform transform4 = this.enemy.transform;
					nint num18 = (nint)typeof(Vector3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v290 @ rcx_v36 (Il2CppClass<UnityEngine.Vector3>)+B8]");
					nint num19 = 0;
					_ = Vector3.upVector;
					float num20 = (float)Vector3.upVector * _003CrotationTimer_003E5__8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-15]");
					float num21 = 0f * _003CrotationTimer_003E5__8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ rdx_v23 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
					float num22 = 0f * _003CrotationTimer_003E5__8;
					float num23 = num20 * _003CrotationSpeed_003E5__5;
					float num24 = num21 * _003CrotationSpeed_003E5__5;
					float num25 = num22 * _003CrotationSpeed_003E5__5;
					if ((object)transform4 != null)
					{
						Vector3 eulers = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
						transform4.Rotate(eulers);
						_003CrotationTimer_003E5__8 = 0f;
						goto IL_0b16;
					}
				}
				goto IL_081f;
			}
			goto IL_0b16;
			IL_0856:
			if (!(1f > _003Ctimer_003E5__4))
			{
				if ((object)_003C_003E4__this != null && (object)this.enemy != null)
				{
					Transform transform5 = this.enemy.transform;
					if ((object)transform5 != null)
					{
						Vector3 position3 = transform5.position;
						Quaternion rotation2 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
						Vector3 position4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
						_ = Quaternion.identityQuaternion;
						_ = position3.x;
						_ = position3.z;
						GameObject gameObject3 = UnityEngine.Object.Instantiate(effectManager.americanExplosionEffect, position4, rotation2);
						if ((object)gameObject3 != null)
						{
							CombatExplosion component2 = gameObject3.GetComponent<CombatExplosion>();
							if ((object)component2 != null)
							{
								component2.radius = _003CexplosionRadius_003E5__2;
								Enemy enemy = this.enemy;
								if ((object)this.enemy != null && (object)enemy._003CenemyData_003Ek__BackingField != null)
								{
									float damage = enemy._003CenemyData_003Ek__BackingField.GetDamage();
									component2.playerDamage = damage;
									if ((object)this.enemy != null)
									{
										Transform transform6 = this.enemy.transform;
										if ((object)transform6 != null)
										{
											Vector3 localScale3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (EffectManager+<ExploderDeath>d__71)+48]");
											_ = 0;
											_ = _003CdefaultScale_003E5__6;
											transform6.localScale = localScale3;
											if ((object)this.enemy != null)
											{
												this.enemy.ReleaseToPool();
												if (effectManager.currentlyExplodingEnemy != null)
												{
													bool flag4 = ((HashSet<object>)(object)effectManager.currentlyExplodingEnemy).Remove((object)this.enemy);
													goto IL_0811;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			else
			{
				MyPlayer instance2 = MyPlayer.Instance;
				if ((object)MyPlayer.Instance != null)
				{
					PlayerInventory inventory = instance2.inventory;
					if (instance2.inventory != null && inventory.statusEffects != null)
					{
						if (!inventory.statusEffects.HasStatusEffect(EStatusEffect.TimeFreeze))
						{
							goto IL_08e2;
						}
						_003C_003E2__current = null;
						_003C_003E1__state = 1;
						goto IL_0ad7;
					}
				}
			}
			goto IL_081f;
			IL_0ad7:
			return true;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			NotSupportedException ex = new NotSupportedException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}
	}

	public GameObject nukePickup;

	public GameObject magnetPickup;

	public GameObject hastePickup;

	public GameObject ragePickup;

	public GameObject shieldPickup;

	public GameObject stonksPickup;

	public GameObject healthPickup;

	public GameObject playerDamage;

	public GameObject playerLandHard;

	public GameObject smokeHit;

	public GameObject goldSkeletonBreakEffect;

	public GameObject xpSkeletonBreakEffect;

	public GameObject pickupOrbFx;

	public GameObject chestPickup;

	public GameObject chestDiscard;

	public GameObject openChestNormal;

	public GameObject openChestGhost;

	public GameObject wuiFreeChest;

	public GameObject magnetFx;

	public GameObject electricPlugFx;

	public GameObject bananaQuest;

	public GameObject luckTomeQuest;

	public GameObject shotgunQuest;

	public GameObject katanaQuest;

	public GameObject campfire;

	public GameObject banishFx;

	public GameObject stealItemWui;

	public GameObject giveItemWui;

	public GameObject mirrorFx;

	public GameObject zapEffect;

	public GameObject desertStormFx;

	public GameObject tornado;

	public GameObject tumbleweed;

	public GameObject monkeCage;

	public GameObject monkeCageKey;

	public GameObject bushQuest;

	public GameObject banditQuest;

	public GameObject boomboxQuest;

	public GameObject presentQuest;

	public GameObject frogQuest1;

	public GameObject frogQuest2;

	public GameObject frogQuest3;

	public GameObject blindSphere;

	public GameObject floorIsLava;

	public GameObject gloveLightning;

	public GameObject glovePoison;

	public GameObject gloveBlood;

	public GameObject gloveCurse;

	public GameObject glovePower;

	public GameObject[] desertGraves;

	public GameObject lanternExplosion;

	public GameObject enemyHpBar;

	private List<EffectStat> effectStatsQueue;

	public static EffectManager Instance;

	private EffectPlayer playerDamageFx;

	private float nextBloodTimeReady;

	private float bloodCooldown = 0.1f;

	private string critText = "CRIT!";

	private string megaCritText = "MEGACRIT!";

	public HashSet<Enemy> currentlyExplodingEnemy;

	private AttackHit attackHit;

	private static readonly Dictionary<EWeapon, string> weaponNamesCache;

	public GameObject americanExplosionEffect;

	public GameObject americanExplosionEffectStart;

	private float baseChestDropChance;

	private float lastChestAtTime;

	private EffectPlayer electricPlugEffect;

	private EffectPlayer activeMirrorFx;

	private EffectPlayer activeZapFx;

	private DesertStorm desertStorm;

	public GameObject spawnedLuckTomeObject;

	public GameObject spawnedShotgunObject;

	public GameObject spawnedKatanaObject;

	private Dictionary<GameObject, ItemProjectile> activeGhostProjectiles;

	private bool hasSpawnedFirstEliteChest;

	private void Awake()
	{
		//IL_008e: Expected O, but got I4
		//IL_009c: Expected I, but got O
		//IL_00e2: Expected O, but got I4
		//IL_00f0: Expected I, but got O
		//IL_015d: Expected O, but got I4
		//IL_016b: Expected I, but got O
		//IL_01b1: Expected O, but got I4
		//IL_01bf: Expected I, but got O
		//IL_0254: Expected O, but got I4
		//IL_0262: Expected I, but got O
		//IL_02a8: Expected O, but got I4
		//IL_02b6: Expected I, but got O
		//IL_0323: Expected O, but got I4
		//IL_0331: Expected I, but got O
		//IL_0377: Expected O, but got I4
		//IL_0385: Expected I, but got O
		//IL_041a: Expected O, but got I4
		//IL_0428: Expected I, but got O
		//IL_046e: Expected O, but got I4
		//IL_047c: Expected I, but got O
		//IL_0511: Expected O, but got I4
		//IL_051f: Expected I, but got O
		//IL_0565: Expected O, but got I4
		//IL_0573: Expected I, but got O
		//IL_0608: Expected O, but got I4
		//IL_0616: Expected I, but got O
		//IL_065c: Expected O, but got I4
		//IL_066a: Expected I, but got O
		//IL_0907: Expected I, but got O
		//IL_0953: Expected O, but got I4
		//IL_095c: Expected I, but got O
		if (!(Instance == null))
		{
			GameObject obj = base.gameObject;
			UnityEngine.Object.Destroy(obj);
			return;
		}
		Instance = this;
		Action<Pickup> b = OnPickup;
		Delegate obj2 = Delegate.Combine(Pickup.A_PickupTriggered, b);
		Delegate obj3;
		object obj4;
		nint num;
		Delegate obj5;
		if ((object)obj2 == null)
		{
			Pickup.A_PickupTriggered = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Pickup> action = default(Action<Pickup>);
			bool flag = action == null;
			obj3 = obj2;
			obj4 = 0;
			num = (nint)typeof(Action<Pickup>);
			obj5 = null;
			if (flag)
			{
				goto IL_07bf;
			}
			Pickup.A_PickupTriggered = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj6 = default(object);
			bool flag2 = obj6 == null;
			obj3 = obj2;
			obj4 = 0;
			num = (nint)typeof(Action<Pickup>);
			obj5 = null;
			if (flag2)
			{
				goto IL_07ca;
			}
		}
		Action<PlayerHealth, DamageContainer, bool> b2 = new Action<object, object, bool>(OnDamage);
		Delegate obj7 = Delegate.Combine(PlayerHealth.A_TakeDamage, b2);
		if ((object)obj7 == null)
		{
			PlayerHealth.A_TakeDamage = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerHealth, DamageContainer, bool> action2 = default(Action<PlayerHealth, DamageContainer, bool>);
			bool flag3 = action2 == null;
			obj3 = obj7;
			obj4 = 0;
			num = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
			obj5 = null;
			if (flag3)
			{
				goto IL_0802;
			}
			PlayerHealth.A_TakeDamage = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj8 = default(object);
			bool flag4 = obj8 == null;
			obj3 = obj7;
			obj4 = 0;
			num = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
			obj5 = null;
			if (flag4)
			{
				goto IL_0812;
			}
		}
		Action<PlayerHealth, float, bool> b3 = new Action<object, float, bool>(OnHeal);
		Delegate obj9 = Delegate.Combine(PlayerHealth.A_Heal, b3);
		if ((object)obj9 == null)
		{
			PlayerHealth.A_Heal = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerHealth, float, bool> action3 = default(Action<PlayerHealth, float, bool>);
			bool flag5 = action3 == null;
			obj3 = obj9;
			obj4 = 0;
			num = (nint)typeof(Action<PlayerHealth, float, bool>);
			obj5 = null;
			if (flag5)
			{
				goto IL_0822;
			}
			PlayerHealth.A_Heal = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj10 = default(object);
			bool flag6 = obj10 == null;
			obj3 = obj9;
			obj4 = 0;
			num = (nint)typeof(Action<PlayerHealth, float, bool>);
			obj5 = null;
			if (flag6)
			{
				goto IL_0832;
			}
		}
		Action<Enemy, DamageContainer> b4 = OnEnemyDied;
		Delegate obj11 = Delegate.Combine(Enemy.A_EnemyDied, b4);
		if ((object)obj11 == null)
		{
			Enemy.A_EnemyDied = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy, DamageContainer> action4 = default(Action<Enemy, DamageContainer>);
			bool flag7 = action4 == null;
			obj3 = obj11;
			obj4 = 0;
			num = (nint)typeof(Action<Enemy, DamageContainer>);
			obj5 = null;
			if (flag7)
			{
				goto IL_086a;
			}
			Enemy.A_EnemyDied = action4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj12 = default(object);
			bool flag8 = obj12 == null;
			obj3 = obj11;
			obj4 = 0;
			num = (nint)typeof(Action<Enemy, DamageContainer>);
			obj5 = null;
			if (flag8)
			{
				goto IL_087a;
			}
		}
		Action<Enemy, DamageContainer> b5 = OnEnemyDamage;
		Delegate obj13 = Delegate.Combine(Enemy.A_Damage, b5);
		if ((object)obj13 == null)
		{
			Enemy.A_Damage = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy, DamageContainer> action5 = default(Action<Enemy, DamageContainer>);
			bool flag9 = action5 == null;
			obj3 = obj13;
			obj4 = 0;
			num = (nint)typeof(Action<Enemy, DamageContainer>);
			obj5 = null;
			if (flag9)
			{
				goto IL_088a;
			}
			Enemy.A_Damage = action5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj14 = default(object);
			bool flag10 = obj14 == null;
			obj3 = obj13;
			obj4 = 0;
			num = (nint)typeof(Action<Enemy, DamageContainer>);
			obj5 = null;
			if (flag10)
			{
				goto IL_089a;
			}
		}
		Action<EItem, bool> b6 = OnItemRemoved;
		Delegate obj15 = Delegate.Combine(ItemInventory.A_ItemRemoved, b6);
		if ((object)obj15 == null)
		{
			ItemInventory.A_ItemRemoved = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EItem, bool> action6 = default(Action<EItem, bool>);
			bool flag11 = action6 == null;
			obj3 = obj15;
			obj4 = 0;
			num = (nint)typeof(Action<EItem, bool>);
			obj5 = null;
			if (flag11)
			{
				goto IL_08aa;
			}
			ItemInventory.A_ItemRemoved = action6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj16 = default(object);
			bool flag12 = obj16 == null;
			obj3 = obj15;
			obj4 = 0;
			num = (nint)typeof(Action<EItem, bool>);
			obj5 = null;
			if (flag12)
			{
				goto IL_08ba;
			}
		}
		Action<EItem> b7 = OnItemAdded;
		Delegate obj17 = Delegate.Combine(ItemInventory.A_ItemAdded, b7);
		if ((object)obj17 == null)
		{
			ItemInventory.A_ItemAdded = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EItem> action7 = default(Action<EItem>);
			bool flag13 = action7 == null;
			obj3 = obj17;
			obj4 = 0;
			num = (nint)typeof(Action<EItem>);
			obj5 = null;
			if (flag13)
			{
				goto IL_08ca;
			}
			ItemInventory.A_ItemAdded = action7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj18 = default(object);
			bool flag14 = obj18 == null;
			obj3 = obj17;
			obj4 = 0;
			num = (nint)typeof(Action<EItem>);
			obj5 = null;
			if (flag14)
			{
				goto IL_08da;
			}
		}
		Action action8 = OnMapGenerationComplete;
		Delegate obj19 = Delegate.Combine(MapGenerationController.A_GenerationComplete, action8);
		if ((object)obj19 == null)
		{
			MapGenerationController.A_GenerationComplete = null;
			goto IL_0756;
		}
		bool flag15 = (object)obj19.GetType() != typeof(Action);
		Delegate obj20 = null;
		if (!flag15)
		{
			obj20 = obj19;
		}
		bool flag16 = (object)obj20 == null;
		nint num2 = (nint)typeof(Action);
		if (!flag16)
		{
			MapGenerationController.A_GenerationComplete = (Action)obj20;
			bool flag17 = (object)obj19.GetType() != typeof(Action);
			Delegate obj21 = null;
			if (!flag17)
			{
				obj21 = obj19;
			}
			if ((object)obj21 != null)
			{
				goto IL_0756;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		obj3 = action8;
		obj4 = 0;
		num = (nint)MapGenerationController.A_GenerationComplete;
		obj5 = obj19;
		goto IL_08da;
		IL_0822:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0812;
		IL_0832:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0822;
		IL_0756:
		List<EffectStat> list = new List<EffectStat>();
		effectStatsQueue = list;
		return;
		IL_07ca:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_07bf;
		IL_0802:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_07ca;
		IL_08ca:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_08ba;
		IL_08da:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_08ca;
		IL_08aa:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_089a;
		IL_08ba:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_08aa;
		IL_088a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_087a;
		IL_089a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_088a;
		IL_086a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0832;
		IL_087a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_086a;
		IL_0812:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0802;
		IL_07bf:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public unsafe void PlayerLandHard()
	{
		//IL_004d: Expected O, but got Ref
		//IL_004d: Expected O, but got Ref
		if (PlayerMovement.Instance != null)
		{
			Vector3 rbFeetPosition = PlayerMovement.Instance.GetRbFeetPosition();
			object obj = default(object);
			object obj2 = default(object);
			GameObject gameObject = UnityEngine.Object.Instantiate(playerLandHard, (Vector3)(&obj), (Quaternion)(&obj2));
			return;
		}
		throw new NullReferenceException();
	}

	private unsafe void OnDamage(PlayerHealth ph, DamageContainer dc, bool shieldDamage)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0036: Expected F4, but got I4
		//IL_0048: Expected F4, but got I4
		//IL_001f: Expected F4, but got I4
		//IL_009c: Expected O, but got I
		//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cb: Expected O, but got Unknown
		//IL_03dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e1: Expected O, but got Unknown
		//IL_03f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f7: Expected O, but got Unknown
		//IL_0575: Expected I, but got O
		//IL_05a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a8: Expected O, but got Unknown
		//IL_05b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bd: Expected O, but got Unknown
		//IL_0607: Invalid comparison between F4 and O
		//IL_00c9: Expected O, but got I
		//IL_00d9: Expected O, but got I
		//IL_00b4: Expected I, but got O
		//IL_0442: Expected O, but got I
		//IL_0147: Expected O, but got Ref
		//IL_0176: Expected O, but got Ref
		//IL_0184: Expected O, but got Ref
		//IL_022b: Expected O, but got Ref
		//IL_0273: Expected O, but got Ref
		//IL_0298: Expected O, but got Ref
		//IL_049a: Expected I, but got O
		//IL_0505: Expected O, but got Ref
		//IL_0513: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (shieldDamage)
		{
			float num = 1f;
			float num2 = 0f;
			float num3 = 1f;
		}
		else
		{
			float num = 0f;
			float num2 = 1f;
			float num3 = 0f;
		}
		_ = 1065353216;
		if (dc.element != EElement.Bleed)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-11]");
			Color color = (Color)0;
		}
		else
		{
			Color color = MyColorUtility.bleedColor;
		}
		if (dc.damageEffect == EDamageEffect.Poison)
		{
			Color color = MyColorUtility.poisonColor;
		}
		object obj3 = dc.direction ^ -0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [dc @ r8 (Assets.Scripts.Actors.DamageContainer)+14]");
		object obj4 = 0 ^ -0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [dc @ r8 (Assets.Scripts.Actors.DamageContainer)+18]");
		object obj5 = 0 ^ -0f;
		nint num4 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v530 @ rcx_v7 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num5 = 0;
		object obj6 = obj3 - (object)Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v531 @ rax_v7 (Il2CppStaticFields<UnityEngine.Vector3>)+4]");
		object obj7 = obj4 - 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v531 @ rax_v7 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		object obj8 = obj5 - 0;
		object obj9 = obj7 * obj7;
		object obj10 = obj6 * obj6;
		object obj11 = obj8 * obj8;
		object obj12 = obj9 + obj10;
		object obj13 = obj12 + obj11;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj13))
		{
			nint num6 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v567 @ rcx_v57 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num7 = 0;
			Vector3 forwardVector = Vector3.forwardVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v569 @ rax_v63 (Il2CppStaticFields<UnityEngine.Vector3>)+50]");
			object obj14 = 0;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-19]");
			object obj14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-21]");
			Vector3 forwardVector = (Vector3)0;
		}
		if (playerDamageFx == null)
		{
			MyPlayer player = GameManager.Instance.GetPlayer();
			Transform transform = player.transform;
			Vector3 position = transform.position;
			Vector3 forward = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
			Quaternion quaternion2 = Quaternion.LookRotation(forward);
			Quaternion rotation = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 17));
			Vector3 position2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
			_ = quaternion2.x;
			_ = position.x;
			_ = position.z;
			GameObject gameObject = UnityEngine.Object.Instantiate(playerDamage, position2, rotation);
			EffectPlayer component = gameObject.GetComponent<EffectPlayer>();
			playerDamageFx = component;
		}
		if (!(MyTime.time < nextBloodTimeReady))
		{
			float num8 = MyTime.time + bloodCooldown;
			nextBloodTimeReady = num8;
			Transform transform2 = playerDamageFx.transform;
			Transform transform3 = MyPlayer.Instance.transform;
			Vector3 position3 = transform3.position;
			Vector3 position4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
			_ = position3.x;
			_ = position3.z;
			transform2.position = position4;
			Transform transform4 = playerDamageFx.transform;
			Vector3 forward2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
			Quaternion quaternion3 = Quaternion.LookRotation(forward2);
			Quaternion rotation2 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 17));
			_ = quaternion3.x;
			transform4.rotation = rotation2;
			playerDamageFx.Play();
		}
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		CFVisualsSettings cfVisualsSettings = config.cfVisualsSettings;
		if (cfVisualsSettings.damage_numbers == 1)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rdi+1Ch]\"");
			int num9 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
			string text = ((int*)num9)->ToString();
			string text2 = "-" + text;
			Transform transform5 = MyPlayer.Instance.transform;
			Vector3 position5 = transform5.position;
			nint num10 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rax_v29 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num11 = 0;
			float num12 = position5.x + (float)Vector3.upVector;
			float num13 = position5.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v844 @ rcx_v28 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
			float num14 = num13 + 0f;
			float num15 = position5.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v844 @ rcx_v28 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
			float num16 = num15 + 0f;
			Vector3 position6 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
			Color color2 = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 17));
			int textSize = default(int);
			PopupText(text2, color2, position6, textSize);
		}
	}

	public unsafe void NewDamageNumbers(DamageContainer dc, Enemy enemy)
	{
		//IL_00e1: Expected O, but got Ref
		//IL_00e1: Expected O, but got Ref
		//IL_022f: Expected O, but got Ref
		//IL_022f: Expected O, but got Ref
		//IL_01bc: Expected O, but got I
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		CFVisualsSettings cfVisualsSettings = config.cfVisualsSettings;
		if (cfVisualsSettings.damage_numbers == 0)
		{
			return;
		}
		Color color = dc.GetColor();
		Transform transform = enemy.transform;
		Vector3 position = transform.position;
		DamageNumbers damageNumber = PoolManager.Instance.GetDamageNumber();
		Color color2 = default(Color);
		float num = default(float);
		int textSize = default(int);
		if (damageNumber != null)
		{
			damageNumber.SetDamage(dc.damage, (Color)(&color2), (Vector3)(&num), textSize);
		}
		string text;
		if (dc.damageEffect != EDamageEffect.Megacrit)
		{
			if (!dc.crit)
			{
				return;
			}
			text = critText;
			Transform transform2 = enemy.transform;
			Vector3 position2 = transform2.position;
			object obj = Vector3.upVector + Vector3.upVector;
			float num2 = (float)obj + position2.x;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED60]");
			color2 = (Color)0;
			num = num2;
		}
		else
		{
			text = megaCritText;
			Transform transform3 = enemy.transform;
			Vector3 position3 = transform3.position;
			object obj2 = Vector3.upVector + Vector3.upVector;
			float num3 = (float)obj2 + position3.x;
			color2 = MyColorUtility.critMegaColor;
			num = num3;
		}
		PopupText(text, (Color)(&color2), (Vector3)(&num), textSize);
	}

	public unsafe void PopupText(string text, Color color, Vector3 position, int textSize = 24)
	{
		//IL_004d: Expected O, but got Ref
		//IL_004d: Expected O, but got Ref
		DamageNumbers damageNumber = PoolManager.Instance.GetDamageNumber();
		if (damageNumber != null)
		{
			object obj = default(object);
			object obj2 = default(object);
			int textSize2 = default(int);
			damageNumber.SetDamage(text, (Color)(&obj), (Vector3)(&obj2), textSize2);
		}
	}

	public unsafe void PopupText(float damage, Color color, Vector3 position, int textSize = 24)
	{
		//IL_004d: Expected O, but got Ref
		//IL_004d: Expected O, but got Ref
		DamageNumbers damageNumber = PoolManager.Instance.GetDamageNumber();
		if (damageNumber != null)
		{
			object obj = default(object);
			object obj2 = default(object);
			int textSize2 = default(int);
			damageNumber.SetDamage(damage, (Color)(&obj), (Vector3)(&obj2), textSize2);
		}
	}

	public unsafe void PickupEffect()
	{
		//IL_009d: Expected O, but got Ref
		PoolManager instance = PoolManager.Instance;
		GameObject gameObject = instance.pickupeffectPool.Get();
		if (gameObject != null)
		{
			MyPlayer player = GameManager.Instance.GetPlayer();
			Transform transform = player.transform;
			Vector3 position = transform.position;
			gameObject.SetActive(value: true);
			Transform transform2 = gameObject.transform;
			float num = default(float);
			transform2.position = (Vector3)(&num);
		}
	}

	public unsafe void GoldBurstEffect(Vector3 position)
	{
		//IL_005d: Expected O, but got Ref
		PoolManager instance = PoolManager.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002620");
		UnityEngine.Object obj = default(UnityEngine.Object);
		if (obj != null)
		{
			((GameObject)obj).SetActive(true);
			Transform transform = ((GameObject)obj).transform;
			object obj2 = default(object);
			transform.position = (Vector3)(&obj2);
		}
	}

	private unsafe void OnEnemyDied(Enemy enemy, DamageContainer deathSource)
	{
		//IL_0008: Expected O, but got Ref
		//IL_03c6: Expected O, but got Ref
		//IL_03d4: Expected O, but got Ref
		//IL_0453: Expected O, but got I4
		//IL_0461: Expected O, but got Ref
		//IL_046f: Expected I4, but got O
		//IL_010f: Expected O, but got Ref
		//IL_0203: Expected F8, but got I4
		//IL_0239: Expected O, but got Ref
		//IL_0247: Expected O, but got Ref
		//IL_02a1: Expected O, but got I4
		//IL_04f9: Expected I, but got O
		//IL_02c6: Expected O, but got Ref
		//IL_02f4: Expected I4, but got F8
		//IL_0364: Unknown result type (might be due to invalid IL or missing references)
		//IL_0369: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = (object)(&obj2);
		CheckChestSpawn(enemy);
		MyPlayer player = GameManager.Instance.GetPlayer();
		if (player != null)
		{
			MyPlayer player2 = GameManager.Instance.GetPlayer();
			PlayerInventory inventory = player2.inventory;
			if (inventory.statusEffects.HasStatusEffect(EStatusEffect.Stonks))
			{
				Transform transform = enemy.transform;
				Vector3 position = transform.position;
				PoolManager instance = PoolManager.Instance;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002620");
				UnityEngine.Object obj3 = default(UnityEngine.Object);
				if (obj3 != null)
				{
					((GameObject)obj3).SetActive(true);
					Transform transform2 = ((GameObject)obj3).transform;
					_ = position.x;
					Vector3 position2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
					_ = position.z;
					transform2.position = position2;
				}
			}
			EnemyData enemyData = enemy._003CenemyData_003Ek__BackingField;
			if (enemyData.enemyName != EEnemy.GoldenSkeleton)
			{
				if (enemyData.enemyName != EEnemy.XpSkeleton)
				{
					return;
				}
				MyPlayer instance2 = MyPlayer.Instance;
				PlayerInventory inventory2 = instance2.inventory;
				PlayerXp playerXp = inventory2.playerXp;
				int num = XpUtility.XpToNextLevelTotal(playerXp.xp);
				bool flag = num >= 10;
				int num2 = 10;
				if (!flag)
				{
					num2 = num;
				}
				int num3 = num / num2;
				double num4 = Math.Ceiling(num3);
				Transform transform3 = enemy.transform;
				Vector3 position3 = transform3.position;
				Quaternion rotation = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
				Vector3 position4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
				_ = Quaternion.identityQuaternion;
				_ = position3.x;
				_ = position3.z;
				GameObject gameObject = UnityEngine.Object.Instantiate(xpSkeletonBreakEffect, position4, rotation);
				if (num2 <= 0)
				{
					return;
				}
				object obj4 = 0;
				bool useRandomOffsetPosition = default(bool);
				float pickupDelay = default(float);
				do
				{
					Transform transform4 = enemy.transform;
					Vector3 position5 = transform4.position;
					nint num5 = (nint)typeof(Vector3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rax_v56 (Il2CppClass<UnityEngine.Vector3>)+B8]");
					nint num6 = 0;
					float num7 = position5.x + (float)Vector3.upVector;
					float num8 = position5.y;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rcx_v42 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
					float num9 = num8 + 0f;
					float num10 = position5.z;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rcx_v42 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
					float num11 = num10 + 0f;
					Vector3 pos = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
					Pickup pickup = PickupManager.Instance.SpawnPickup(EPickup.Xp, pos, (int)num4, useRandomOffsetPosition, pickupDelay);
					if (pickup != null)
					{
						MyPlayer player3 = GameManager.Instance.GetPlayer();
						Transform target = player3.transform;
						pickup.StartFollowingPlayer(target);
					}
					obj4++;
				}
				while ((nint)obj4 < num2);
			}
			else
			{
				int chestPrice = MoneyUtility.GetChestPrice();
				Transform transform5 = enemy.transform;
				Vector3 position6 = transform5.position;
				Quaternion rotation2 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
				Vector3 position7 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
				_ = Quaternion.identityQuaternion;
				_ = position6.x;
				_ = position6.z;
				GameObject gameObject2 = UnityEngine.Object.Instantiate(goldSkeletonBreakEffect, position7, rotation2);
				Transform transform6 = enemy.transform;
				Vector3 position8 = transform6.position;
				_ = position8.z;
				int num12 = chestPrice >> 31;
				_ = position8.x;
				object obj5 = chestPrice - num12;
				Vector3 pos2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
				int amount = obj5 >> 1;
				MoneyUtility.SpawnMoney(amount, pos2);
			}
			return;
		}
		throw new NullReferenceException();
	}

	private unsafe void OnEnemyDamage(Enemy enemy, DamageContainer dc)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0446: Expected I, but got O
		//IL_051d: Expected O, but got Ref
		//IL_0285: Expected O, but got Ref
		//IL_02c2: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Transform transform2;
		if (dc.damageEffect != EDamageEffect.Execute)
		{
			if (dc.damageEffect != EDamageEffect.Bloodmark)
			{
				ObjectPool<GameObject> critEffectPool;
				if (dc.damageEffect != EDamageEffect.Megacrit)
				{
					if (!dc.crit)
					{
						return;
					}
					if (dc.damageEffect != EDamageEffect.Megacrit)
					{
						PoolManager instance = PoolManager.Instance;
						critEffectPool = instance.critEffectPool;
						goto IL_0202;
					}
				}
				PoolManager instance2 = PoolManager.Instance;
				critEffectPool = instance2.megaCritPool;
				goto IL_0202;
			}
			PoolManager instance3 = PoolManager.Instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002620");
			UnityEngine.Object obj3 = default(UnityEngine.Object);
			if (!(obj3 != null))
			{
				return;
			}
			((GameObject)obj3).SetActive(true);
			Transform transform = ((GameObject)obj3).transform;
			Vector3 centerPosition = enemy.GetCenterPosition();
			_ = centerPosition.x;
			_ = centerPosition.z;
			transform2 = transform;
		}
		else
		{
			PoolManager instance4 = PoolManager.Instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002620");
			UnityEngine.Object obj4 = default(UnityEngine.Object);
			if (!(obj4 != null))
			{
				return;
			}
			((GameObject)obj4).SetActive(true);
			Transform transform3 = ((GameObject)obj4).transform;
			Transform transform4 = enemy.transform;
			Vector3 position = transform4.position;
			nint num = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rax_v68 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num2 = 0;
			float num3 = (float)Vector3.upVector * 3f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rcx_v53 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
			float num4 = 0f * 3f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rcx_v53 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
			float num5 = 0f * 3f;
			float num6 = num3 + position.x;
			float num7 = num4 + position.y;
			float num8 = num5 + position.z;
			transform2 = transform3;
		}
		Transform transform5 = transform2;
		goto IL_050f;
		IL_0202:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002620");
		UnityEngine.Object obj5 = default(UnityEngine.Object);
		if (!(obj5 != null))
		{
			return;
		}
		((GameObject)obj5).SetActive(true);
		Transform transform6 = ((GameObject)obj5).transform;
		Transform transform7 = MyPlayer.Instance.transform;
		Vector3 position2 = transform7.position;
		Vector3 position3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		_ = position2.x;
		_ = position2.z;
		Vector3 vector = enemy.collider.ClosestPoint(position3);
		Vector3 position4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		_ = vector.x;
		_ = vector.z;
		transform6.position = position4;
		Transform transform8 = ((GameObject)obj5).transform;
		Transform transform9 = ((GameObject)obj5).transform;
		Vector3 position5 = transform9.position;
		Transform transform10 = enemy.transform;
		Vector3 position6 = transform10.position;
		Transform transform11 = ((GameObject)obj5).transform;
		Vector3 position7 = transform11.position;
		float num9 = position6.x - position7.x;
		float num10 = position6.y - position7.y;
		float num11 = position6.z - position7.z;
		float num12 = num9 * 0.5f;
		float num13 = num10 * 0.5f;
		float num14 = num11 * 0.5f;
		float num15 = num12 + position5.x;
		float num16 = num13 + position5.y;
		float num17 = num14 + position5.z;
		transform5 = transform8;
		goto IL_050f;
		IL_050f:
		Vector3 position8 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		transform5.position = position8;
	}

	public void ExploderEnemy(Enemy enemy)
	{
		_003CExploderDeath_003Ed__71 obj = new _003CExploderDeath_003Ed__71(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.enemy = enemy;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private IEnumerator ExploderDeath(Enemy enemy)
	{
		_003CExploderDeath_003Ed__71 obj = new _003CExploderDeath_003Ed__71(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.enemy = enemy;
		return obj;
	}

	public unsafe void OnHeal(PlayerHealth ph, float value, bool isShield)
	{
		//IL_0081: Expected O, but got Ref
		//IL_0081: Expected O, but got Ref
		if (!isShield)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm6\"");
			int num = default(int);
			string text = num.ToString();
			string text2 = "+" + text;
			Transform transform = MyPlayer.Instance.transform;
			Vector3 position = transform.position;
			object obj = default(object);
			object obj2 = default(object);
			int textSize = default(int);
			PopupText(text2, (Color)(&obj), (Vector3)(&obj2), textSize);
		}
	}

	public unsafe void EnemyHitEffect(Vector3 hitPos, Vector3 moveDir, bool hitEnemy, string source, GameObject weaponHitEffect, bool useSfx)
	{
		//IL_006e: Expected O, but got Ref
		//IL_0114: Expected I, but got O
		//IL_01d3: Invalid comparison between F4 and I4
		//IL_01fc: Expected O, but got I4
		//IL_0090: Expected O, but got Ref
		//IL_00ac: Expected O, but got Ref
		string text = default(string);
		GameObject hitPrefab = default(GameObject);
		AttackHit projectileHit = PoolManager.Instance.GetProjectileHit(text, hitPrefab);
		this.attackHit = projectileHit;
		if (this.attackHit != null)
		{
			Transform transform = this.attackHit.transform;
			float num = default(float);
			transform.position = (Vector3)(&num);
			Transform transform2 = this.attackHit.transform;
			nint num2 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rax_v16 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num3 = 0;
			float num4 = moveDir.x - (float)Vector3.zeroVector;
			object obj2 = default(object);
			object obj3 = default(object);
			object obj = obj2 - obj3;
			float num5 = moveDir.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v359 @ rcx_v14 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			float num6 = num5 - 0f;
			object obj4 = obj * obj;
			float num7 = num4 * num4;
			float num8 = num6 * num6;
			float num9 = (float)obj4 + num7;
			float num10 = num9 + num8;
			bool flag = 9.9999994E-11f < num10;
			float num11 = 9.9999994E-11f - num10;
			bool flag2 = num11 == 0f;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			object obj5 = flag4 & flag3;
			if (obj5 == null)
			{
				Quaternion quaternion2 = Quaternion.LookRotation((Vector3)(&num));
			}
			float num12 = default(float);
			transform2.rotation = (Quaternion)(&num12);
			AttackHit attackHit = this.attackHit;
			PoolManager instance = PoolManager.Instance;
			ObjectPool<GameObject> pool = instance.projectileHitPools.get_Item(text);
			attackHit.pool = pool;
			bool useSfx2 = default(bool);
			this.attackHit.Play(hitEnemy, useSfx2);
		}
	}

	public unsafe void EnemyHitEffect(Vector3 hitPos, Vector3 moveDir, bool hitEnemy, EWeapon eWeapon, GameObject weaponHitEffect, bool useSfx)
	{
		//IL_0035: Expected O, but got Ref
		//IL_0035: Expected O, but got Ref
		System.Int32Enum key = default(System.Int32Enum);
		object obj = ((Dictionary<System.Int32Enum, object>)(object)weaponNamesCache).get_Item(key);
		object obj2 = default(object);
		object obj3 = default(object);
		string source = default(string);
		GameObject weaponHitEffect2 = default(GameObject);
		bool useSfx2 = default(bool);
		EnemyHitEffect((Vector3)(&obj2), (Vector3)(&obj3), hitEnemy, source, weaponHitEffect2, useSfx2);
	}

	public unsafe void SpawnPickupOrb(EPickup ePickup, Vector3 position)
	{
		//IL_0018: Expected O, but got Ref
		//IL_0018: Expected O, but got Ref
		object obj = default(object);
		object obj2 = default(object);
		GameObject gameObject = UnityEngine.Object.Instantiate(pickupOrbFx, (Vector3)(&obj), (Quaternion)(&obj2));
		PickupOrb component = gameObject.GetComponent<PickupOrb>();
		component.Set(ePickup);
		PickupManager.Instance.CountAdd();
	}

	public unsafe CircleWarning WarningSphere(Vector3 position, float radius, float time, Action completeAction)
	{
		//IL_0105: Expected O, but got Ref
		PoolManager instance = PoolManager.Instance;
		CircleWarning circleWarning;
		if ((object)PoolManager.Instance != null && instance.warningSpherePool != null)
		{
			GameObject gameObject = instance.warningSpherePool.Get();
			if (!(gameObject != null))
			{
				circleWarning = null;
				goto IL_0127;
			}
			if ((object)gameObject != null)
			{
				gameObject.SetActive(value: true);
				circleWarning = gameObject.GetComponent<CircleWarning>();
				if ((object)circleWarning != null)
				{
					Action finishAction = default(Action);
					circleWarning.Set(radius, time, finishAction);
					Transform transform = gameObject.transform;
					if ((object)transform != null)
					{
						object obj = default(object);
						transform.position = (Vector3)(&obj);
						goto IL_0127;
					}
				}
			}
		}
		return (CircleWarning)(object)new NullReferenceException();
		IL_0127:
		return circleWarning;
	}

	public unsafe bool WarningTube(Vector3 position, Vector3 dir, float radius, float distance, float time, Action completeAction)
	{
		//IL_017e: Expected I4, but got O
		//IL_010a: Expected O, but got Ref
		//IL_0126: Expected O, but got Ref
		//IL_0154: Expected O, but got Ref
		PoolManager instance = PoolManager.Instance;
		if ((object)PoolManager.Instance != null && instance.warningTubePool != null)
		{
			GameObject gameObject = instance.warningTubePool.Get();
			if (!(gameObject != null))
			{
				return false;
			}
			if ((object)gameObject != null)
			{
				gameObject.SetActive(value: true);
				TubeWarning component = gameObject.GetComponent<TubeWarning>();
				if ((object)component != null)
				{
					float length = default(float);
					float time2 = default(float);
					Action completeAction2 = default(Action);
					component.Set(radius, length, time2, completeAction2);
					Transform transform = gameObject.transform;
					if ((object)transform != null)
					{
						float num = default(float);
						transform.position = (Vector3)(&num);
						Transform transform2 = gameObject.transform;
						Quaternion quaternion2 = Quaternion.LookRotation((Vector3)(&num));
						if ((object)transform2 != null)
						{
							transform2.rotation = (Quaternion)(&num);
							return true;
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe void CheckChestSpawn(Enemy enemy)
	{
		//IL_035e: Invalid comparison between I4 and F4
		//IL_014a: Expected F4, but got I4
		//IL_0262: Invalid comparison between I4 and F4
		//IL_0290: Expected O, but got I4
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Expected O, but got Unknown
		//IL_02fc: Expected O, but got I4
		//IL_0304: Unknown result type (might be due to invalid IL or missing references)
		//IL_0309: Expected O, but got Unknown
		//IL_01f2: Expected O, but got Ref
		//IL_0205: Expected O, but got Ref
		//IL_021c: Expected O, but got Ref
		//IL_0236: Expected O, but got Ref
		//IL_0236: Expected O, but got Ref
		UnityEngine.Object obj5;
		if (!enemy.IsBoss() || MapController.isFinalBossStage)
		{
			if (!hasSpawnedFirstEliteChest && enemy.IsElite() && !enemy.IsChallenge() && MapController.IsFirstStage())
			{
				hasSpawnedFirstEliteChest = true;
			}
			else
			{
				double num = MyRandom.random.NextDouble();
				float stat = PlayerStats.GetStat(EStat.PowerupChance);
				float num2 = MyTime.time - lastChestAtTime;
				float num3 = num2 / 420f;
				if (!(0f > num3))
				{
					if (num3 > 1f)
					{
						num3 = 1f;
					}
				}
				else
				{
					num3 = 0f;
				}
				if (0f > num3 || num3 > 1f)
				{
				}
				bool flag = enemy.IsElite();
				object obj = flag ^ flag;
				object obj2 = flag & obj;
				bool flag2 = (nint)obj2 < 0;
				bool flag3 = (flag ? 1 : 0) < (false ? 1 : 0);
				bool flag4 = !flag;
				if (!flag4)
				{
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm10\"");
				bool flag5 = flag3 == flag2;
				object obj3 = !flag5;
				object obj4 = obj3 | flag4;
				obj5 = null;
				if (obj4 != null)
				{
					goto IL_0179;
				}
				lastChestAtTime = MyTime.time;
			}
		}
		obj5 = openChestNormal;
		goto IL_0179;
		IL_0179:
		if (obj5 != null)
		{
			Vector3 headPosition = enemy.GetHeadPosition();
			if (!ChallengesTracker.HasChallengeModifier("no_items"))
			{
				Transform transform = MyPlayer.Instance.transform;
				Vector3 position = transform.position;
				float num4 = default(float);
				Vector3 vector = VectorExtensions.XZVector((Vector3)(&num4));
				Quaternion quaternion2 = Quaternion.LookRotation((Vector3)(&num4));
				Vector3 vector2 = RaycastUtility.RayToGround((Vector3)(&num4));
				object obj6 = default(object);
				GameObject gameObject = UnityEngine.Object.Instantiate((GameObject)obj5, (Vector3)(&num4), (Quaternion)(&obj6));
			}
		}
	}

	public unsafe void SpawnChest(GameObject chestPrefab, Vector3 pos)
	{
		//IL_0050: Expected O, but got Ref
		//IL_0063: Expected O, but got Ref
		//IL_007b: Expected O, but got Ref
		//IL_0095: Expected O, but got Ref
		//IL_0095: Expected O, but got Ref
		if (!ChallengesTracker.HasChallengeModifier("no_items"))
		{
			Transform transform = MyPlayer.Instance.transform;
			Vector3 position = transform.position;
			float num = default(float);
			Vector3 vector = VectorExtensions.XZVector((Vector3)(&num));
			Quaternion quaternion2 = Quaternion.LookRotation((Vector3)(&num));
			Vector3 vector2 = RaycastUtility.RayToGround((Vector3)(&num));
			object obj = default(object);
			GameObject gameObject = UnityEngine.Object.Instantiate(chestPrefab, (Vector3)(&num), (Quaternion)(&obj));
		}
	}

	public unsafe void SpawnChestForcePosition(GameObject chestPrefab, Vector3 pos)
	{
		//IL_0050: Expected O, but got Ref
		//IL_0063: Expected O, but got Ref
		//IL_007d: Expected O, but got Ref
		//IL_007d: Expected O, but got Ref
		if (!ChallengesTracker.HasChallengeModifier("no_items"))
		{
			Transform transform = MyPlayer.Instance.transform;
			Vector3 position = transform.position;
			float num = default(float);
			Vector3 vector = VectorExtensions.XZVector((Vector3)(&num));
			Quaternion quaternion2 = Quaternion.LookRotation((Vector3)(&num));
			object obj = default(object);
			GameObject gameObject = UnityEngine.Object.Instantiate(chestPrefab, (Vector3)(&num), (Quaternion)(&obj));
		}
	}

	private float GetChestDropChance(Enemy enemy)
	{
		//IL_015d: Invalid comparison between I4 and F4
		//IL_004a: Expected F4, but got I4
		//IL_00d6: Invalid comparison between I4 and F4
		//IL_0086: Expected F4, but got I4
		float stat = PlayerStats.GetStat(EStat.PowerupChance);
		float num = MyTime.time - lastChestAtTime;
		float num2 = num / 420f;
		if (!(0f > num2))
		{
			if (num2 > 1f)
			{
				num2 = 1f;
			}
		}
		else
		{
			num2 = 0f;
		}
		if (!(0f > num2))
		{
			if (num2 > 1f)
			{
				num2 = 1f;
			}
		}
		else
		{
			num2 = 0f;
		}
		float num3 = num2 + num2;
		bool flag = enemy.IsElite();
		bool flag2 = !flag;
		float num4 = 1f;
		if (!flag2)
		{
			num4 = 2f;
		}
		float num5 = stat * baseChestDropChance;
		float num6 = num5 * num3;
		return num6 * num4;
	}

	private float GetChestDropTimeMultiplier()
	{
		//IL_00e6: Invalid comparison between I4 and F4
		//IL_003c: Expected F4, but got I4
		//IL_0093: Invalid comparison between I4 and F4
		//IL_0080: Expected F4, but got I4
		float num = MyTime.time - lastChestAtTime;
		float num2 = num / 420f;
		if (!(0f > num2))
		{
			if (num2 > 1f)
			{
				num2 = 1f;
			}
		}
		else
		{
			num2 = 0f;
		}
		if (!(0f > num2))
		{
			if (num2 > 1f)
			{
				return 1f + 1f;
			}
		}
		else
		{
			num2 = 0f;
		}
		return num2 + num2;
	}

	private unsafe void OnItemRemoved(EItem item, bool showEffect)
	{
		//IL_0067: Expected O, but got Ref
		//IL_0067: Expected O, but got Ref
		//IL_00c1: Expected I4, but got I8
		if (showEffect)
		{
			Transform transform = MyPlayer.Instance.transform;
			Vector3 position = transform.position;
			Transform transform2 = MyPlayer.Instance.transform;
			Vector3 up = transform2.up;
			object obj = default(object);
			object obj2 = default(object);
			GameObject gameObject = UnityEngine.Object.Instantiate(chestPickup, (Vector3)(&obj), (Quaternion)(&obj2));
			ChestItem component = gameObject.GetComponent<ChestItem>();
			DataManager instance = DataManager.Instance;
			object itemData = ((Dictionary<System.Int32Enum, object>)(object)instance.itemData).get_Item((System.Int32Enum)item);
			component.Set((ItemData)itemData, -1);
		}
	}

	private unsafe void OnItemAdded(EItem item)
	{
		//IL_0062: Expected O, but got Ref
		//IL_0062: Expected O, but got Ref
		Transform transform = MyPlayer.Instance.transform;
		Vector3 position = transform.position;
		Transform transform2 = MyPlayer.Instance.transform;
		Vector3 up = transform2.up;
		object obj = default(object);
		object obj2 = default(object);
		GameObject gameObject = UnityEngine.Object.Instantiate(chestPickup, (Vector3)(&obj), (Quaternion)(&obj2));
		ChestItem component = gameObject.GetComponent<ChestItem>();
		DataManager instance = DataManager.Instance;
		object itemData = ((Dictionary<System.Int32Enum, object>)(object)instance.itemData).get_Item((System.Int32Enum)item);
		component.Set((ItemData)itemData, 1);
	}

	public unsafe void BanishItem(UnlockableBase unlockable)
	{
		//IL_0062: Expected O, but got Ref
		//IL_0062: Expected O, but got Ref
		Transform transform = MyPlayer.Instance.transform;
		Vector3 position = transform.position;
		Transform transform2 = MyPlayer.Instance.transform;
		Vector3 up = transform2.up;
		object obj = default(object);
		object obj2 = default(object);
		GameObject gameObject = UnityEngine.Object.Instantiate(banishFx, (Vector3)(&obj), (Quaternion)(&obj2));
		BanishItem component = gameObject.GetComponent<BanishItem>();
		component.Set(unlockable);
	}

	public void SpawnRockets(int num, float damage, float procCoefficient, string damageSource)
	{
		_003CDoSpawnRockets_003Ed__93 obj = new _003CDoSpawnRockets_003Ed__93(0);
		string damageSource2 = default(string);
		obj.damageSource = damageSource2;
		obj.damage = damage;
		obj.procCoefficient = procCoefficient;
		obj._003C_003E1__state = 0;
		obj.num = num;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private IEnumerator DoSpawnRockets(int num, float damage, float procCoefficient, string damageSource)
	{
		_003CDoSpawnRockets_003Ed__93 obj = new _003CDoSpawnRockets_003Ed__93(0);
		string damageSource2 = default(string);
		obj.damageSource = damageSource2;
		obj.damage = damage;
		obj.procCoefficient = procCoefficient;
		obj._003C_003E1__state = 0;
		obj.num = num;
		return obj;
	}

	public unsafe void MagnetEffect()
	{
		//IL_003d: Expected O, but got Ref
		//IL_003d: Expected O, but got Ref
		Transform transform = MyPlayer.Instance.transform;
		Vector3 position = transform.position;
		object obj = default(object);
		object obj2 = default(object);
		GameObject gameObject = UnityEngine.Object.Instantiate(magnetFx, (Vector3)(&obj), (Quaternion)(&obj2));
		Transform transform2 = gameObject.transform;
		Transform parentInternal = MyPlayer.Instance.transform;
		transform2.parentInternal = parentInternal;
	}

	public unsafe void ElectricalPlugEffect()
	{
		//IL_009c: Expected O, but got Ref
		if (!(electricPlugEffect == null))
		{
			electricPlugEffect.Play();
			return;
		}
		Transform parent = MyPlayer.Instance.transform;
		GameObject gameObject = UnityEngine.Object.Instantiate(electricPlugFx, parent);
		EffectPlayer component = gameObject.GetComponent<EffectPlayer>();
		electricPlugEffect = component;
		Transform transform = electricPlugEffect.transform;
		object obj = default(object);
		transform.localPosition = (Vector3)(&obj);
	}

	public unsafe void SpawnMirrorFx(Vector3 pos, Vector3 dir, float size)
	{
		//IL_003d: Expected O, but got Ref
		//IL_0059: Expected O, but got Ref
		//IL_0059: Expected O, but got Ref
		//IL_00ba: Expected O, but got Ref
		//IL_00d7: Expected O, but got Ref
		//IL_00ed: Expected O, but got Ref
		//IL_0113: Expected O, but got Ref
		float x = default(float);
		float x2 = default(float);
		if (!(activeMirrorFx == null))
		{
			activeMirrorFx.Play();
		}
		else
		{
			Quaternion quaternion2 = Quaternion.LookRotation((Vector3)(&x));
			GameObject gameObject = UnityEngine.Object.Instantiate(mirrorFx, (Vector3)(&x), (Quaternion)(&x2));
			EffectPlayer component = gameObject.GetComponent<EffectPlayer>();
			activeMirrorFx = component;
			x2 = quaternion2.x;
			x = pos.x;
		}
		Transform transform = activeMirrorFx.transform;
		transform.position = (Vector3)(&x);
		Transform transform2 = activeMirrorFx.transform;
		Quaternion quaternion3 = Quaternion.LookRotation((Vector3)(&x));
		transform2.rotation = (Quaternion)(&x2);
		Transform transform3 = activeMirrorFx.transform;
		transform3.localScale = (Vector3)(&x);
	}

	public unsafe void ZapEffect(Vector3 pos)
	{
		//IL_0056: Expected O, but got Ref
		//IL_0056: Expected O, but got Ref
		//IL_00a9: Expected O, but got Ref
		float x = default(float);
		if (!(activeZapFx == null))
		{
			activeZapFx.Play();
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1817E0E00");
			quaternion quaternion2 = default(quaternion);
			object obj = default(object);
			GameObject gameObject = UnityEngine.Object.Instantiate(zapEffect, (Vector3)(&quaternion2), (Quaternion)(&obj));
			EffectPlayer component = gameObject.GetComponent<EffectPlayer>();
			activeZapFx = component;
			x = pos.x;
		}
		Transform transform = activeZapFx.transform;
		transform.position = (Vector3)(&x);
	}

	public DesertStorm GetDesertStorm()
	{
		if (desertStorm == null)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(desertStormFx);
			if ((object)gameObject == null)
			{
				return (DesertStorm)(object)new NullReferenceException();
			}
			gameObject.SetActive(value: false);
			DesertStorm component = gameObject.GetComponent<DesertStorm>();
			desertStorm = component;
		}
		return desertStorm;
	}

	public void SpawnTornadoes(int amount)
	{
		//IL_000e: Expected O, but got I4
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		if (amount > 0)
		{
			object obj = 0;
			do
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(tornado);
				obj++;
			}
			while ((nint)obj < amount);
		}
	}

	public void SpawnTumbleWeeds(int amount)
	{
		//IL_000e: Expected O, but got I4
		//IL_016e: Expected I, but got O
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_018f: Expected I, but got O
		if (amount <= 0)
		{
			return;
		}
		object obj = 0;
		UnityEngine.Object obj3 = default(UnityEngine.Object);
		do
		{
			PoolManager instance = PoolManager.Instance;
			ObjectPool<GameObject> tumbleweedPool = instance.tumbleweedPool;
			UnityEngine.Object obj2;
			if ((nint)tumbleweedPool.m_FreshlyReleased <= 0)
			{
				List<GameObject> list = tumbleweedPool.m_List;
				if (list._size != 0)
				{
					int index = list._size - 1;
					GameObject gameObject = tumbleweedPool.m_List.get_Item(index);
					int index2 = list._size - 1;
					((List<object>)(object)tumbleweedPool.m_List).RemoveAt(index2);
					obj2 = gameObject;
				}
				else
				{
					Func<GameObject> createFunc = tumbleweedPool.m_CreateFunc;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v222 @ rax_v20 (System.Func`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
					int num = tumbleweedPool._003CCountAll_003Ek__BackingField + 1;
					tumbleweedPool._003CCountAll_003Ek__BackingField = num;
					obj2 = obj3;
				}
			}
			else
			{
				obj2 = tumbleweedPool.m_FreshlyReleased;
				tumbleweedPool.m_FreshlyReleased = null;
			}
			Action<GameObject> actionOnGet = tumbleweedPool.m_ActionOnGet;
			if (tumbleweedPool.m_ActionOnGet != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v313 @ rax_v10 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
			}
			bool flag = obj2 != null;
			bool flag2 = !flag;
			nint num2 = unchecked((nint)null);
			if (!flag2)
			{
				((GameObject)obj2).SetActive(true);
				num2 = unchecked((nint)null);
			}
			obj++;
		}
		while ((nint)obj < amount);
	}

	public unsafe void TrySpawnLuckQuest(Vector3 pos)
	{
		//IL_005c: Expected O, but got Ref
		//IL_005c: Expected O, but got Ref
		if (spawnedLuckTomeObject == null)
		{
			Transform transform = luckTomeQuest.transform;
			Quaternion rotation = transform.rotation;
			object obj = default(object);
			object obj2 = default(object);
			GameObject gameObject = UnityEngine.Object.Instantiate(luckTomeQuest, (Vector3)(&obj), (Quaternion)(&obj2));
			spawnedLuckTomeObject = gameObject;
		}
	}

	public unsafe void TrySpawnShotgunQuest(Vector3 pos)
	{
		//IL_005c: Expected O, but got Ref
		//IL_005c: Expected O, but got Ref
		if (spawnedShotgunObject == null)
		{
			Transform transform = shotgunQuest.transform;
			Quaternion rotation = transform.rotation;
			object obj = default(object);
			object obj2 = default(object);
			GameObject gameObject = UnityEngine.Object.Instantiate(shotgunQuest, (Vector3)(&obj), (Quaternion)(&obj2));
			spawnedShotgunObject = gameObject;
		}
	}

	public unsafe void TrySpawnKatanaQuest(Vector3 pos)
	{
		//IL_005c: Expected O, but got Ref
		//IL_005c: Expected O, but got Ref
		if (spawnedKatanaObject == null)
		{
			Transform transform = katanaQuest.transform;
			Quaternion rotation = transform.rotation;
			object obj = default(object);
			object obj2 = default(object);
			GameObject gameObject = UnityEngine.Object.Instantiate(katanaQuest, (Vector3)(&obj), (Quaternion)(&obj2));
			spawnedKatanaObject = gameObject;
		}
	}

	public unsafe void TakeItem(UnlockableBase data, Transform target, Vector3 targetOffset, float hoverTime = 1f, float moveTime = 1f, float scale = 1f)
	{
		//IL_0050: Expected O, but got Ref
		GameObject gameObject = UnityEngine.Object.Instantiate(stealItemWui);
		StealWeaponWui component = gameObject.GetComponent<StealWeaponWui>();
		object obj = default(object);
		float hoverTime2 = default(float);
		float moveTime2 = default(float);
		float scale2 = default(float);
		bool useScaleDown = default(bool);
		component.Set(data, target, (Vector3)(&obj), hoverTime2, moveTime2, scale2, useScaleDown);
	}

	public void GiveItem(UnlockableBase data)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(giveItemWui);
		ReturnWeaponWui component = gameObject.GetComponent<ReturnWeaponWui>();
		component.Set(data);
	}

	private unsafe void OnMapGenerationComplete()
	{
		//IL_05f9: Expected I, but got O
		//IL_0074: Expected I, but got O
		//IL_063a: Expected O, but got Ref
		//IL_0681: Expected F4, but got I4
		//IL_0681: Expected O, but got Ref
		//IL_00a7: Expected O, but got Ref
		//IL_00ee: Expected F4, but got I4
		//IL_00ee: Expected O, but got Ref
		//IL_08a9: Expected F4, but got O
		//IL_075c: Expected I, but got O
		//IL_010e: Expected I, but got O
		//IL_014f: Expected O, but got Ref
		//IL_0196: Expected F4, but got I4
		//IL_0196: Expected O, but got Ref
		//IL_06be: Expected O, but got Ref
		//IL_06db: Expected O, but got Ref
		//IL_1393: Expected I, but got O
		//IL_13cf: Expected O, but got I
		//IL_13ec: Expected O, but got I
		//IL_1410: Unknown result type (might be due to invalid IL or missing references)
		//IL_1415: Expected O, but got Unknown
		//IL_079d: Expected O, but got Ref
		//IL_07e4: Expected F4, but got I4
		//IL_07e4: Expected O, but got Ref
		//IL_0707: Expected O, but got Ref
		//IL_01d8: Expected O, but got Ref
		//IL_01e6: Expected O, but got Ref
		//IL_08ee: Expected F4, but got O
		//IL_0822: Expected O, but got Ref
		//IL_083f: Expected O, but got Ref
		//IL_024a: Expected O, but got Ref
		//IL_0267: Expected O, but got Ref
		//IL_1516: Expected O, but got Ref
		//IL_1530: Expected O, but got Ref
		//IL_0929: Expected F4, but got O
		//IL_0931: Expected F4, but got O
		//IL_093a: Expected F4, but got I4
		//IL_0868: Expected O, but got Ref
		//IL_0298: Expected O, but got Ref
		//IL_02a6: Expected I, but got O
		//IL_02c4: Expected O, but got Ref
		//IL_0309: Expected O, but got Ref
		//IL_1120: Expected I, but got O
		//IL_1590: Expected I, but got O
		//IL_0f6c: Expected I, but got O
		//IL_145d: Expected O, but got Ref
		//IL_1477: Expected O, but got Ref
		//IL_1493: Expected O, but got Ref
		//IL_1160: Expected O, but got Ref
		//IL_116e: Expected O, but got Ref
		//IL_11c8: Expected F4, but got I4
		//IL_0983: Expected O, but got Ref
		//IL_09ca: Expected F4, but got I4
		//IL_09ca: Expected O, but got Ref
		//IL_0583: Expected O, but got Ref
		//IL_0fac: Expected O, but got Ref
		//IL_0fba: Expected O, but got Ref
		//IL_1014: Expected F4, but got I4
		//IL_0b75: Expected F4, but got I4
		//IL_0b7f: Expected F4, but got I4
		//IL_1609: Invalid comparison between F4 and I4
		//IL_0a07: Expected O, but got Ref
		//IL_0a15: Expected O, but got Ref
		//IL_1051: Expected O, but got Ref
		//IL_105f: Expected O, but got Ref
		//IL_0e1b: Expected F4, but got I4
		//IL_0e24: Expected F4, but got I4
		//IL_1203: Expected O, but got I4
		//IL_162d: Invalid comparison between F4 and I4
		//IL_0b92: Expected I, but got O
		//IL_155a: Expected I, but got O
		//IL_1665: Expected I, but got O
		//IL_1673: Expected O, but got Ref
		//IL_168e: Expected O, but got Ref
		//IL_0a82: Expected O, but got Ref
		//IL_0ab0: Invalid comparison between F4 and I4
		//IL_0abf: Expected F4, but got O
		//IL_0ac9: Expected F4, but got O
		//IL_10b9: Expected O, but got Ref
		//IL_0e48: Expected O, but got I4
		//IL_0e50: Invalid comparison between F4 and O
		//IL_0bd2: Expected O, but got Ref
		//IL_0be0: Expected O, but got Ref
		//IL_0c3a: Expected F4, but got I4
		//IL_0c3a: Expected F4, but got I4
		//IL_12be: Expected O, but got Ref
		//IL_12cc: Expected O, but got Ref
		//IL_0e74: Expected I4, but got F4
		//IL_0e93: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e98: Expected I4, but got Unknown
		//IL_0c88: Expected O, but got Ref
		//IL_0cac: Expected O, but got Ref
		//IL_15d7: Expected I, but got O
		//IL_0ce8: Expected O, but got Ref
		//IL_0db0: Invalid comparison between F4 and I4
		object obj = default(object);
		bool flag = (byte)(&obj) != 0;
		((bool*)(flag ? 1 : 0))->m_value = false;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		Vector3 upVector = default(Vector3);
		int layerMask = default(int);
		ref Vector3 normal = default(ref Vector3);
		int attempts = default(int);
		bool onlyUseGroundLayer = default(bool);
		if (!MyAchievements.IsAchievementDone("a_monke"))
		{
			MapData mapData = MapController._003CcurrentMap_003Ek__BackingField;
			if (mapData.eMap == EMap.Forest)
			{
				nint num = (nint)typeof(MapInfo);
				GameManager instance = GameManager.Instance;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v821 @ rdx_v100 (Il2CppClass<Assets.Scripts.MapGeneration.MapInfo>)+B8]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
				Vector3 size = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 128));
				_ = MapInfo.mapSize;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1656 @ rax_v234 (Il2CppStaticFields<Assets.Scripts.MapGeneration.MapInfo>)+2C]");
				_ = 0;
				bool debug = default(bool);
				Vector3 objectSpawnPosition = SpawnPositions.GetObjectSpawnPosition((Vector3)(&upVector), size, 0.5f, layerMask, out normal, attempts, onlyUseGroundLayer, debug, (byte)(&obj) != 0, 100f);
				GameManager instance2 = GameManager.Instance;
				nint num3 = (nint)typeof(MapInfo);
				_ = objectSpawnPosition.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1848 @ rcx_v183 (Il2CppClass<Assets.Scripts.MapGeneration.MapInfo>)+B8]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
				bool canSpawnInWater = (byte)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj, 16)) != 0;
				Vector3 center = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 128));
				_ = MapInfo.mapCenter;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1850 @ rax_v239 (Il2CppStaticFields<Assets.Scripts.MapGeneration.MapInfo>)+20]");
				_ = 0;
				bool debug2 = default(bool);
				Vector3 objectSpawnPosition2 = SpawnPositions.GetObjectSpawnPosition(center, (Vector3)(&upVector), 4f, layerMask, out normal, attempts, onlyUseGroundLayer, debug2, canSpawnInWater, 100f);
				nint num5 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v874 @ rax_v243 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num6 = 0;
				object obj2 = Vector3.upVector + Vector3.upVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1948 @ rcx_v188 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1948 @ rcx_v188 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
				object obj3 = num7 + 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1948 @ rcx_v188 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
				nint num8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1948 @ rcx_v188 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
				object obj4 = num8 + 0;
				float num9 = (float)obj2 + objectSpawnPosition.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (System.Boolean)-6C]");
				object obj5 = obj3 + 0;
				float num10 = (float)obj4 + objectSpawnPosition.z;
				Transform transform = monkeCageKey.transform;
				Quaternion rotation = transform.rotation;
				Quaternion rotation2 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 80));
				Vector3 position = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 128));
				_ = rotation.x;
				GameObject gameObject = UnityEngine.Object.Instantiate(monkeCageKey, position, rotation2);
				Transform transform2 = monkeCage.transform;
				Quaternion rotation3 = transform2.rotation;
				Quaternion rotation4 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 80));
				_ = rotation3.x;
				GameObject gameObject2 = UnityEngine.Object.Instantiate(monkeCage, (Vector3)(&upVector), rotation4);
				Transform transform3 = gameObject2.transform;
				float angle = UnityEngine.Random.Range(0f, 360f);
				transform3.Rotate((Vector3)(&upVector), angle, Space.World);
				nint num11 = (nint)typeof(MapInfo);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2749 @ rax_v254 (Il2CppClass<Assets.Scripts.MapGeneration.MapInfo>)+B8]");
				nint num12 = 0;
				object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 128));
				float num13 = (float)MapInfo.mapCenter - objectSpawnPosition2.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2750 @ rcx_v200 (Il2CppStaticFields<Assets.Scripts.MapGeneration.MapInfo>)+20]");
				float num14 = 0f - objectSpawnPosition2.z;
				_ = 0;
				object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 112));
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
				Vector3 forward = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 128));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2758 @ rax_v255+8]");
				_ = 0;
				Quaternion quaternion2 = Quaternion.LookRotation(forward, (Vector3)(&upVector));
				_ = 3217625051L;
				Vector3 euler = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 128));
				_ = 0;
				Quaternion quaternion3 = Quaternion.Internal_FromEulerRad(euler);
				Transform transform4 = gameObject2.transform;
				float num15 = quaternion3.w * quaternion2.x;
				float num16 = quaternion3.z * quaternion2.y;
				float num17 = quaternion3.x * quaternion2.w;
				float num18 = quaternion3.y * quaternion2.w;
				float num19 = num17 + num15;
				float num20 = quaternion3.z * quaternion2.w;
				float num21 = quaternion3.y * quaternion2.z;
				float num22 = num19 + num16;
				float num23 = quaternion3.x * quaternion2.z;
				float num24 = num22 - num21;
				float num25 = quaternion3.w * quaternion2.y;
				float num26 = num18 + num25;
				float num27 = quaternion3.z * quaternion2.x;
				float num28 = quaternion3.z * quaternion2.z;
				float num29 = num26 + num23;
				float num30 = quaternion3.y * quaternion2.x;
				float num31 = quaternion3.y * quaternion2.y;
				float num32 = num29 - num27;
				float num33 = quaternion3.w * quaternion2.z;
				float num34 = quaternion3.w * quaternion2.w;
				float num35 = num20 + num33;
				float num36 = quaternion3.x * quaternion2.x;
				float num37 = quaternion3.x * quaternion2.y;
				float num38 = num34 - num36;
				float num39 = num35 + num30;
				float num40 = num38 - num31;
				float num41 = num39 - num37;
				float num42 = num40 - num28;
				Quaternion rotation5 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 80));
				transform4.rotation = rotation5;
				upVector = Vector3.upVector;
			}
		}
		MapData mapData2 = MapController._003CcurrentMap_003Ek__BackingField;
		if (mapData2.eMap == EMap.Forest)
		{
			nint num43 = (nint)typeof(MapInfo);
			GameManager instance3 = GameManager.Instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v823 @ rdx_v89 (Il2CppClass<Assets.Scripts.MapGeneration.MapInfo>)+B8]");
			nint num44 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
			bool canSpawnInWater2 = (byte)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj, 32)) != 0;
			Vector3 center2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 128));
			_ = MapInfo.mapCenter;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1660 @ rax_v208 (Il2CppStaticFields<Assets.Scripts.MapGeneration.MapInfo>)+20]");
			_ = 0;
			bool debug3 = default(bool);
			Vector3 objectSpawnPosition3 = SpawnPositions.GetObjectSpawnPosition(center2, (Vector3)(&upVector), 2f, layerMask, out normal, attempts, onlyUseGroundLayer, debug3, canSpawnInWater2, 100f);
			Transform transform5 = bushQuest.transform;
			Quaternion rotation6 = transform5.rotation;
			Quaternion rotation7 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 80));
			_ = rotation6.x;
			GameObject gameObject3 = UnityEngine.Object.Instantiate(bushQuest, (Vector3)(&upVector), rotation7);
			Transform transform6 = gameObject3.transform;
			float angle2 = UnityEngine.Random.Range(0f, 360f);
			transform6.Rotate((Vector3)(&upVector), angle2);
			upVector = Vector3.upVector;
		}
		MapData mapData3 = MapController._003CcurrentMap_003Ek__BackingField;
		if (mapData3.eMap == EMap.Desert)
		{
			nint num45 = (nint)typeof(MapInfo);
			GameManager instance4 = GameManager.Instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v824 @ rdx_v78 (Il2CppClass<Assets.Scripts.MapGeneration.MapInfo>)+B8]");
			nint num46 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
			bool canSpawnInWater3 = (byte)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 48)) != 0;
			Vector3 center3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 128));
			_ = MapInfo.mapCenter;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1929 @ rax_v184 (Il2CppStaticFields<Assets.Scripts.MapGeneration.MapInfo>)+20]");
			_ = 0;
			bool debug4 = default(bool);
			Vector3 objectSpawnPosition4 = SpawnPositions.GetObjectSpawnPosition(center3, (Vector3)(&upVector), 3f, layerMask, out normal, attempts, onlyUseGroundLayer, debug4, canSpawnInWater3, 100f);
			Transform transform7 = banditQuest.transform;
			Quaternion rotation8 = transform7.rotation;
			Quaternion rotation9 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 80));
			_ = rotation8.x;
			GameObject gameObject4 = UnityEngine.Object.Instantiate(banditQuest, (Vector3)(&upVector), rotation9);
			Transform transform8 = gameObject4.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (System.Boolean)-30]");
			_ = 0;
			Vector3 forward2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 128));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (System.Boolean)-28]");
			_ = 0;
			float num47 = default(float);
			Quaternion quaternion4 = Quaternion.LookRotation(forward2, (Vector3)(&num47));
			Quaternion rotation10 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 80));
			_ = quaternion4.x;
			transform8.rotation = rotation10;
			upVector = Vector3.upVector;
		}
		bool flag2 = MyAchievements.IsAchievementDone("a_boombox");
		float num48 = (float)upVector;
		if (!flag2)
		{
			MapData mapData4 = MapController._003CcurrentMap_003Ek__BackingField;
			bool flag3 = mapData4.eMap != EMap.Forest;
			num48 = (float)upVector;
			if (!flag3)
			{
				int achievementTargetValue = MyAchievements.GetAchievementTargetValue("a_boombox");
				bool flag4 = achievementTargetValue <= 0;
				num48 = (float)upVector;
				float num49 = (float)upVector;
				float num50 = 0f;
				if (!flag4)
				{
					bool debug5 = default(bool);
					bool flag5;
					do
					{
						nint num51 = (nint)typeof(MapInfo);
						GameManager instance5 = GameManager.Instance;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v825 @ rdx_v67 (Il2CppClass<Assets.Scripts.MapGeneration.MapInfo>)+B8]");
						nint num52 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
						bool canSpawnInWater4 = (byte)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj, 48)) != 0;
						Vector3 center4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 128));
						_ = MapInfo.mapCenter;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2490 @ rax_v161 (Il2CppStaticFields<Assets.Scripts.MapGeneration.MapInfo>)+20]");
						_ = 0;
						Vector3 objectSpawnPosition5 = SpawnPositions.GetObjectSpawnPosition(center4, (Vector3)(&num49), 2f, layerMask, out normal, attempts, onlyUseGroundLayer, debug5, canSpawnInWater4, 100f);
						Transform transform9 = boomboxQuest.transform;
						Quaternion rotation11 = transform9.rotation;
						Quaternion rotation12 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 64));
						Vector3 position2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 96));
						_ = rotation11.x;
						_ = objectSpawnPosition5.x;
						_ = objectSpawnPosition5.z;
						GameObject gameObject5 = UnityEngine.Object.Instantiate(boomboxQuest, position2, rotation12);
						Transform transform10 = gameObject5.transform;
						nint num53 = (nint)typeof(Vector3);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v898 @ rcx_v132 (Il2CppClass<UnityEngine.Vector3>)+B8]");
						nint num54 = 0;
						float angle3 = UnityEngine.Random.Range(0f, 360f);
						_ = Vector3.upVector;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v798 @ rdx_v74 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
						_ = 0;
						Vector3 axis = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 112));
						transform10.Rotate(axis, angle3, Space.World);
						num50++;
						flag5 = num50 < (float)achievementTargetValue;
						num48 = (float)MapInfo.mapSize;
						num49 = (float)MapInfo.mapSize;
					}
					while (flag5);
				}
			}
		}
		if (CharacterMenu.selectedCharacter == ECharacter.Calcium)
		{
			MapData mapData5 = MapController._003CcurrentMap_003Ek__BackingField;
			if (mapData5.eMap == EMap.Desert)
			{
				RunConfig runConfig = MapController.runConfig;
				if (runConfig.mapTierIndex >= 1)
				{
					List<GameObject> list = new List<GameObject>();
					GameObject[] array = desertGraves;
					float num55 = 0f;
					bool debug6 = default(bool);
					int num61 = default(int);
					for (float num56 = 0f; num56 < (float)array.Length; num56 = num55)
					{
						nint num57 = (nint)typeof(MapInfo);
						GameManager instance6 = GameManager.Instance;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v826 @ rdx_v47 (Il2CppClass<Assets.Scripts.MapGeneration.MapInfo>)+B8]");
						nint num58 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
						bool canSpawnInWater5 = (byte)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj, 64)) != 0;
						Vector3 size2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 112));
						Vector3 center5 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 96));
						_ = MapInfo.mapSize;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2770 @ rax_v120 (Il2CppStaticFields<Assets.Scripts.MapGeneration.MapInfo>)+2C]");
						_ = 0;
						_ = MapInfo.mapCenter;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2770 @ rax_v120 (Il2CppStaticFields<Assets.Scripts.MapGeneration.MapInfo>)+20]");
						_ = 0;
						Vector3 objectSpawnPosition6 = SpawnPositions.GetObjectSpawnPosition(center5, size2, 2f, layerMask, out normal, attempts, onlyUseGroundLayer, debug6, canSpawnInWater5, 200f, 1f);
						GameObject[] array2 = desertGraves;
						Transform transform11 = array2[num55].transform;
						Quaternion rotation13 = transform11.rotation;
						Quaternion rotation14 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 64));
						_ = rotation13.x;
						GameObject gameObject6 = UnityEngine.Object.Instantiate(array2[num55], (Vector3)(&num48), rotation14);
						Transform transform12 = gameObject6.transform;
						nint num59 = (nint)typeof(Vector3);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v905 @ rcx_v99 (Il2CppClass<UnityEngine.Vector3>)+B8]");
						nint num60 = 0;
						float angle4 = UnityEngine.Random.Range(0f, 360f);
						_ = Vector3.upVector;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v805 @ rdx_v55 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
						_ = 0;
						Vector3 axis2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 128));
						transform12.Rotate(axis2, angle4, Space.World);
						int version = list._version + 1;
						list._version = version;
						GameObject[] items = list._items;
						if (list._size >= items.Length)
						{
							((List<object>)(object)list).AddWithResize((object)gameObject6);
						}
						else
						{
							int size3 = list._size + 1;
							list._size = size3;
							items[num61] = gameObject6;
						}
						if (num55 != 0f)
						{
							gameObject6.SetActive(value: false);
						}
						array = desertGraves;
						num55++;
						num48 = objectSpawnPosition6.x;
					}
					float num62 = 0f;
					for (float num63 = 0f; num63 < (float)list._size; num63 = num62)
					{
						GameObject[] array3 = desertGraves;
						object obj8 = array3.Length - 1;
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num62) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8))
						{
							GameObject gameObject7 = list.get_Item((int)num62);
							InteractableDesertGrave component = gameObject7.GetComponent<InteractableDesertGrave>();
							int index = (int)(num62 + 1);
							GameObject gameObject8 = list.get_Item(index);
							ShrineSpawnAnimation component2 = gameObject8.GetComponent<ShrineSpawnAnimation>();
							float num56 = (float)component + 136f;
							component.nextShrine = component2;
						}
						num62++;
					}
				}
			}
		}
		if (!MyAchievements.IsAchievementDone("a_santaHat"))
		{
			MapData mapData6 = MapController._003CcurrentMap_003Ek__BackingField;
			if (mapData6.eMap == EMap.Forest)
			{
				nint num64 = (nint)typeof(MapInfo);
				GameManager instance7 = GameManager.Instance;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v827 @ rdx_v26 (Il2CppClass<Assets.Scripts.MapGeneration.MapInfo>)+B8]");
				nint num65 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
				bool canSpawnInWater6 = (byte)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 32)) != 0;
				Vector3 size4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 112));
				Vector3 center6 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 96));
				_ = MapInfo.mapSize;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2587 @ rax_v72 (Il2CppStaticFields<Assets.Scripts.MapGeneration.MapInfo>)+2C]");
				_ = 0;
				_ = MapInfo.mapCenter;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2587 @ rax_v72 (Il2CppStaticFields<Assets.Scripts.MapGeneration.MapInfo>)+20]");
				_ = 0;
				bool debug7 = default(bool);
				Vector3 objectSpawnPosition7 = SpawnPositions.GetObjectSpawnPosition(center6, size4, 3f, layerMask, out normal, attempts, onlyUseGroundLayer, debug7, canSpawnInWater6, 100f);
				Transform transform13 = banditQuest.transform;
				Quaternion rotation15 = transform13.rotation;
				Quaternion rotation16 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 64));
				Vector3 position3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 112));
				_ = rotation15.x;
				_ = objectSpawnPosition7.x;
				_ = objectSpawnPosition7.z;
				GameObject gameObject9 = UnityEngine.Object.Instantiate(presentQuest, position3, rotation16);
				Transform transform14 = gameObject9.transform;
				nint num66 = (nint)typeof(Vector3);
				Vector3 upwards = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 112));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (System.Boolean)-20]");
				_ = 0;
				Vector3 forward3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 96));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1 (System.Boolean)-18]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2993 @ rcx_v65 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num67 = 0;
				_ = Vector3.upVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2994 @ rax_v83 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
				_ = 0;
				Quaternion quaternion5 = Quaternion.LookRotation(forward3, upwards);
				Quaternion rotation17 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 64));
				_ = quaternion5.x;
				transform14.rotation = rotation17;
			}
		}
		MapData mapData7 = MapController._003CcurrentMap_003Ek__BackingField;
		if (mapData7.eMap == EMap.Forest)
		{
			nint num68 = (nint)typeof(MapInfo);
			GameManager instance8 = GameManager.Instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v828 @ rdx_v14 (Il2CppClass<Assets.Scripts.MapGeneration.MapInfo>)+B8]");
			nint num69 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
			bool canSpawnInWater7 = (byte)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj, 80)) != 0;
			Vector3 size5 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 112));
			Vector3 center7 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 96));
			_ = MapInfo.mapSize;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2591 @ rax_v40 (Il2CppStaticFields<Assets.Scripts.MapGeneration.MapInfo>)+2C]");
			_ = 0;
			_ = MapInfo.mapCenter;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2591 @ rax_v40 (Il2CppStaticFields<Assets.Scripts.MapGeneration.MapInfo>)+20]");
			_ = 0;
			bool debug8 = default(bool);
			Vector3 objectSpawnPosition8 = SpawnPositions.GetObjectSpawnPosition(center7, size5, 2f, layerMask, out normal, attempts, onlyUseGroundLayer, debug8, canSpawnInWater7, 100f);
			bool flag6 = MapController.index == 0;
			UnityEngine.Object obj10;
			if (!flag6)
			{
				object obj9 = MapController.index - 1;
				obj10 = (flag6 ? frogQuest2 : (((nint)obj9 == 1) ? frogQuest3 : null));
			}
			else
			{
				obj10 = frogQuest1;
			}
			if (obj10 != null)
			{
				Transform transform15 = ((GameObject)obj10).transform;
				Quaternion rotation18 = transform15.rotation;
				Quaternion rotation19 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 64));
				Vector3 position4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 112));
				_ = rotation18.x;
				_ = objectSpawnPosition8.x;
				_ = objectSpawnPosition8.z;
				GameObject gameObject10 = UnityEngine.Object.Instantiate((GameObject)obj10, position4, rotation19);
			}
		}
	}

	public unsafe void SpawnGhostProjectile(float damage, float duration, string damageSource)
	{
		//IL_0110: Expected F4, but got O
		//IL_0110: Expected F4, but got O
		//IL_0110: Expected O, but got Ref
		PoolManager instance = PoolManager.Instance;
		GameObject gameObject = instance.ghostPool.Get();
		if (gameObject != null)
		{
			if (!activeGhostProjectiles.ContainsKey(gameObject))
			{
				ItemProjectile component = gameObject.GetComponent<ItemProjectile>();
				((Dictionary<object, object>)(object)activeGhostProjectiles).set_Item((object)gameObject, (object)component);
			}
			gameObject.SetActive(value: true);
			ItemProjectile itemProjectile = activeGhostProjectiles.get_Item(gameObject);
			Transform transform = MyPlayer.Instance.transform;
			Vector3 position = transform.position;
			PoolManager instance2 = PoolManager.Instance;
			object obj = default(object);
			string damageSource2 = default(string);
			ObjectPool<GameObject> projectilePool = default(ObjectPool<GameObject>);
			int projectileIndex = default(int);
			int totalProjectiles = default(int);
			itemProjectile.Set((Vector3)(&obj), damage, 1f, damageSource2, projectilePool, projectileIndex, totalProjectiles, (float)damageSource, (float)instance2.ghostPool);
		}
		else
		{
			int count = activeGhostProjectiles.Count;
			if (count > 0)
			{
				int num = MyRandom.random.Next(0, count);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180706AC0");
				ItemProjectile itemProjectile2 = default(ItemProjectile);
				itemProjectile2.AddDamage(damage);
			}
		}
	}

	public void AttachEnemyHpBar(Enemy enemy)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(enemyHpBar);
		EnemyHpBar component = gameObject.GetComponent<EnemyHpBar>();
		component.enemy = enemy;
	}

	private void OnDestroy()
	{
		//IL_0768: Expected O, but got I4
		//IL_0776: Expected I, but got O
		//IL_00cf: Expected O, but got I4
		//IL_00dd: Expected I, but got O
		//IL_014a: Expected O, but got I4
		//IL_0158: Expected I, but got O
		//IL_019e: Expected O, but got I4
		//IL_01ac: Expected I, but got O
		//IL_0241: Expected O, but got I4
		//IL_024f: Expected I, but got O
		//IL_0295: Expected O, but got I4
		//IL_02a3: Expected I, but got O
		//IL_0310: Expected O, but got I4
		//IL_031e: Expected I, but got O
		//IL_0364: Expected O, but got I4
		//IL_0372: Expected I, but got O
		//IL_0407: Expected O, but got I4
		//IL_0415: Expected I, but got O
		//IL_045b: Expected O, but got I4
		//IL_0469: Expected I, but got O
		//IL_04fe: Expected O, but got I4
		//IL_050c: Expected I, but got O
		//IL_0552: Expected O, but got I4
		//IL_0560: Expected I, but got O
		//IL_05f5: Expected O, but got I4
		//IL_0603: Expected I, but got O
		//IL_0649: Expected O, but got I4
		//IL_0657: Expected I, but got O
		//IL_0673: Expected I, but got O
		//IL_08c9: Expected O, but got I4
		//IL_08df: Expected I, but got O
		//IL_090d: Expected O, but got I4
		//IL_0923: Expected I, but got O
		if (!(Instance == this))
		{
			return;
		}
		Action<Pickup> value = OnPickup;
		Delegate obj = Delegate.Remove(Pickup.A_PickupTriggered, value);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			Pickup.A_PickupTriggered = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Pickup> action = default(Action<Pickup>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				obj2 = obj;
				obj3 = 0;
				num = (nint)typeof(Action<Pickup>);
				obj4 = null;
				goto IL_0946;
			}
			Pickup.A_PickupTriggered = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			obj2 = obj;
			obj3 = 0;
			num2 = (nint)typeof(Action<Pickup>);
			obj4 = null;
			if (flag)
			{
				goto IL_0786;
			}
		}
		Action<PlayerHealth, DamageContainer, bool> value2 = new Action<object, object, bool>(OnDamage);
		Delegate obj6 = Delegate.Remove(PlayerHealth.A_TakeDamage, value2);
		if ((object)obj6 == null)
		{
			PlayerHealth.A_TakeDamage = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerHealth, DamageContainer, bool> action2 = default(Action<PlayerHealth, DamageContainer, bool>);
			bool flag2 = action2 == null;
			obj2 = obj6;
			obj3 = 0;
			num2 = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
			obj4 = null;
			if (flag2)
			{
				goto IL_07b9;
			}
			PlayerHealth.A_TakeDamage = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			obj2 = obj6;
			obj3 = 0;
			num2 = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
			obj4 = null;
			if (flag3)
			{
				goto IL_07c9;
			}
		}
		Action<PlayerHealth, float, bool> value3 = new Action<object, float, bool>(OnHeal);
		Delegate obj8 = Delegate.Remove(PlayerHealth.A_Heal, value3);
		if ((object)obj8 == null)
		{
			PlayerHealth.A_Heal = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerHealth, float, bool> action3 = default(Action<PlayerHealth, float, bool>);
			bool flag4 = action3 == null;
			obj2 = obj8;
			obj3 = 0;
			num2 = (nint)typeof(Action<PlayerHealth, float, bool>);
			obj4 = null;
			if (flag4)
			{
				goto IL_07d9;
			}
			PlayerHealth.A_Heal = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag5 = obj9 == null;
			obj2 = obj8;
			obj3 = 0;
			num2 = (nint)typeof(Action<PlayerHealth, float, bool>);
			obj4 = null;
			if (flag5)
			{
				goto IL_07e9;
			}
		}
		Action<Enemy, DamageContainer> value4 = OnEnemyDied;
		Delegate obj10 = Delegate.Remove(Enemy.A_EnemyDied, value4);
		if ((object)obj10 == null)
		{
			Enemy.A_EnemyDied = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy, DamageContainer> action4 = default(Action<Enemy, DamageContainer>);
			bool flag6 = action4 == null;
			obj2 = obj10;
			obj3 = 0;
			num2 = (nint)typeof(Action<Enemy, DamageContainer>);
			obj4 = null;
			if (flag6)
			{
				goto IL_0821;
			}
			Enemy.A_EnemyDied = action4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj11 = default(object);
			bool flag7 = obj11 == null;
			obj2 = obj10;
			obj3 = 0;
			num = (nint)typeof(Action<Enemy, DamageContainer>);
			obj4 = null;
			if (flag7)
			{
				goto IL_0831;
			}
		}
		Action<Enemy, DamageContainer> value5 = OnEnemyDamage;
		Delegate obj12 = Delegate.Remove(Enemy.A_Damage, value5);
		if ((object)obj12 == null)
		{
			Enemy.A_Damage = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy, DamageContainer> action5 = default(Action<Enemy, DamageContainer>);
			bool flag8 = action5 == null;
			obj2 = obj12;
			obj3 = 0;
			num = (nint)typeof(Action<Enemy, DamageContainer>);
			obj4 = null;
			if (flag8)
			{
				goto IL_0849;
			}
			Enemy.A_Damage = action5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj13 = default(object);
			bool flag9 = obj13 == null;
			obj2 = obj12;
			obj3 = 0;
			num = (nint)typeof(Action<Enemy, DamageContainer>);
			obj4 = null;
			if (flag9)
			{
				goto IL_0859;
			}
		}
		Action<EItem, bool> value6 = OnItemRemoved;
		Delegate obj14 = Delegate.Remove(ItemInventory.A_ItemRemoved, value6);
		if ((object)obj14 == null)
		{
			ItemInventory.A_ItemRemoved = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EItem, bool> action6 = default(Action<EItem, bool>);
			bool flag10 = action6 == null;
			obj2 = obj14;
			obj3 = 0;
			num = (nint)typeof(Action<EItem, bool>);
			obj4 = null;
			if (flag10)
			{
				goto IL_0869;
			}
			ItemInventory.A_ItemRemoved = action6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj15 = default(object);
			bool flag11 = obj15 == null;
			obj2 = obj14;
			obj3 = 0;
			num = (nint)typeof(Action<EItem, bool>);
			obj4 = null;
			if (flag11)
			{
				goto IL_0879;
			}
		}
		Action<EItem> value7 = OnItemAdded;
		Delegate obj16 = Delegate.Remove(ItemInventory.A_ItemAdded, value7);
		if ((object)obj16 == null)
		{
			ItemInventory.A_ItemAdded = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EItem> action7 = default(Action<EItem>);
			bool flag12 = action7 == null;
			obj2 = obj16;
			obj3 = 0;
			num = (nint)typeof(Action<EItem>);
			obj4 = null;
			if (flag12)
			{
				goto IL_0889;
			}
			ItemInventory.A_ItemAdded = action7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj17 = default(object);
			bool flag13 = obj17 == null;
			obj2 = obj16;
			obj3 = 0;
			num = (nint)typeof(Action<EItem>);
			obj4 = null;
			if (flag13)
			{
				goto IL_0899;
			}
		}
		num = (nint)MapGenerationController.A_GenerationComplete;
		Action action8 = OnMapGenerationComplete;
		Delegate obj18 = Delegate.Remove(MapGenerationController.A_GenerationComplete, action8);
		if ((object)obj18 == null)
		{
			MapGenerationController.A_GenerationComplete = null;
			return;
		}
		bool flag14 = (object)obj18.GetType() != typeof(Action);
		Delegate obj19 = null;
		if (!flag14)
		{
			obj19 = obj18;
		}
		bool flag15 = (object)obj19 == null;
		obj2 = action8;
		obj3 = 0;
		obj4 = obj18;
		nint num3 = (nint)typeof(Action);
		if (flag15)
		{
			goto IL_0936;
		}
		MapGenerationController.A_GenerationComplete = (Action)obj19;
		bool flag16 = (object)obj18.GetType() != typeof(Action);
		Delegate obj20 = null;
		if (!flag16)
		{
			obj20 = obj18;
		}
		bool flag17 = (object)obj20 == null;
		obj2 = action8;
		obj3 = 0;
		obj4 = obj18;
		nint num4 = (nint)typeof(Action);
		if (!flag17)
		{
			return;
		}
		goto IL_0946;
		IL_07d9:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_07c9;
		IL_0786:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0821:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_07e9;
		IL_0946:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0936;
		IL_0869:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0859;
		IL_07e9:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_07d9;
		IL_0879:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0869;
		IL_0899:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0889;
		IL_0889:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0879;
		IL_07b9:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0786;
		IL_0831:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0821;
		IL_0859:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0849;
		IL_0849:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0831;
		IL_0936:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0899;
		IL_07c9:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_07b9;
	}

	private void OnPickup(Pickup pickup)
	{
		//IL_0018: Expected O, but got I4
		//IL_0042: Expected O, but got I8
		//IL_005c: Expected O, but got I8
		object obj = pickup.ePickup + -2;
		if ((nint)obj <= 7)
		{
			object obj2 = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rdx_v1+500A88+v53 @ rax_v4*4]");
			object obj3 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v71 @ rcx_v3 (should have been resolved before IL gen)");
		}
	}

	public EffectManager()
	{
		HashSet<Enemy> hashSet = (HashSet<Enemy>)(object)new HashSet<object>();
		((HashSet<object>)(object)hashSet)._002Ector();
		currentlyExplodingEnemy = hashSet;
		baseChestDropChance = 0.0005f;
		Dictionary<GameObject, ItemProjectile> dictionary = new Dictionary<GameObject, ItemProjectile>();
		activeGhostProjectiles = dictionary;
		base._002Ector();
	}

	unsafe static EffectManager()
	{
		Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(EWeapon));
		Array values = Enum.GetValues(typeFromHandle);
		IEnumerable<System.Int32Enum> source = Enumerable.Cast<System.Int32Enum>(values);
		Func<EWeapon, EWeapon> keySelector = (EWeapon w) => w;
		Func<EWeapon, string> func = delegate
		{
			//IL_000e: Expected O, but got Ref
			object obj = default(object);
			return ((Enum)(&obj)).ToString();
		};
		func._002Ector((object)_003C_003Ec._003C_003E9, (IntPtr)(nint)__ldftn(_003C_003Ec._003C_002Ecctor_003Eb__121_1));
		Dictionary<System.Int32Enum, object> dictionary = Enumerable.ToDictionary(source, (Func<System.Int32Enum, System.Int32Enum>)(object)keySelector, (Func<System.Int32Enum, object>)(object)func);
		weaponNamesCache = (Dictionary<EWeapon, string>)(object)dictionary;
	}
}
