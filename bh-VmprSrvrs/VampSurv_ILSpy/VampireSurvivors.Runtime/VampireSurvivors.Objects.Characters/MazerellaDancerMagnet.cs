using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using Zenject;

namespace VampireSurvivors.Objects.Characters;

public class MazerellaDancerMagnet : MonoBehaviour
{
	private struct VacuumedPickup
	{
		public Pickup Pickup;

		public float Speed;

		public bool Collected;

		public void SetSpeed(float speed)
		{
			Speed = speed;
		}

		public void SetCollected(bool isCollected)
		{
			Collected = isCollected;
		}
	}

	private class ValuePickupSpawner(int maxPickupsToSpawn, Action<Vector2, float, Action<Pickup>> spawnPickupAction, Action<Pickup> startPickupSpawnTweenAction)
	{
		private readonly int _maxPickupsToSpawn = maxPickupsToSpawn;

		private readonly Action<Vector2, float, Action<Pickup>> _spawnPickupAction = spawnPickupAction;

		private readonly Action<Pickup> _startPickupSpawnTweenAction = startPickupSpawnTweenAction;

		private float _valueCollected;

		private float _valuePerPickupSpawned;

		public void IncreaseValueCollected(int amount)
		{
			float valueCollected = (float)amount + _valueCollected;
			_valueCollected = valueCollected;
		}

		public int CalculateNumberOfPickupsToSpawn()
		{
			//IL_000c: Invalid comparison between F4 and I4
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Expected I4, but got Unknown
			//IL_005a: Expected F4, but got I4
			int maxPickupsToSpawn = default(int);
			if (_valueCollected < (float)_maxPickupsToSpawn)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
			}
			else
			{
				maxPickupsToSpawn = _maxPickupsToSpawn;
			}
			int num = (int)(_valueCollected / maxPickupsToSpawn);
			_valuePerPickupSpawned = num;
			return maxPickupsToSpawn;
		}

		private int CountPickupsToSpawnBasedOnValueCollected()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 15 Invalid \"Jump target not found in method: 0x181B937E0\"");
			return _maxPickupsToSpawn;
		}

		public bool SpawnPickup(Vector3 spawnPosition)
		{
			//IL_000b: Invalid comparison between I4 and F4
			//IL_0097: Expected I4, but got O
			if (0f < _valueCollected)
			{
				if (_valuePerPickupSpawned > _valueCollected)
				{
					_valuePerPickupSpawned = _valueCollected;
				}
				Action<Vector2, float, Action<Pickup>> spawnPickupAction = _spawnPickupAction;
				if (_spawnPickupAction != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v37 @ r8_v1 (System.Action`3<UnityEngine.Vector2, System.Single, System.Action`1<VampireSurvivors.Objects.Pickups.Pickup>>)+18] (should have been resolved before IL gen)");
					float valueCollected = _valueCollected - _valuePerPickupSpawned;
					_valueCollected = valueCollected;
					return true;
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			return false;
		}
	}

	private sealed class _003C_003Ec__DisplayClass28_0
	{
		public Pickup pickupItem;

		internal bool _003COnDancerMagnetOverlapsPickup_003Eb__0(VacuumedPickup vacuumedPickup)
		{
			//IL_013d: Expected O, but got I4
			//IL_0157: Expected O, but got I4
			//IL_00ea: Expected I4, but got O
			Pickup pickup = vacuumedPickup.Pickup;
			Pickup pickup2 = pickupItem;
			bool flag = (object)pickupItem == null;
			bool flag2 = (object)vacuumedPickup.Pickup == null;
			object obj = flag2 & flag;
			bool flag3 = obj == null;
			object obj2 = !flag3;
			if (obj2 == null)
			{
				if ((object)pickupItem != null)
				{
					if ((object)vacuumedPickup.Pickup != null)
					{
						object obj3 = (object)vacuumedPickup.Pickup - (object)pickupItem;
						return obj3 == null;
					}
					return ((UnityEngine.Object)pickup2).m_CachedPtr == (IntPtr)0;
				}
				if ((object)vacuumedPickup.Pickup != null)
				{
					return ((UnityEngine.Object)pickup).m_CachedPtr == (IntPtr)0;
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			return true;
		}
	}

	private sealed class _003C_003Ec__DisplayClass34_0
	{
		public MazerellaDancerMagnet _003C_003E4__this;

		public Pickup pickup;

		internal void _003CStartPickupSpawnTween_003Eb__0()
		{
			//IL_0081: Expected I, but got O
			//IL_0089: Expected I, but got O
			//IL_0099: Expected O, but got I
			//IL_0119: Expected O, but got I4
			//IL_00d5: Expected O, but got I
			//IL_010b: Expected O, but got I4
			//IL_0189: Expected I, but got O
			//IL_0191: Expected I, but got O
			//IL_01a1: Expected O, but got I
			//IL_0221: Expected O, but got I4
			//IL_01dd: Expected O, but got I
			//IL_0213: Expected O, but got I4
			_003C_003E4__this.SetPickupInteractionsActive(this.pickup, active: true);
			Pickup pickup = this.pickup;
			BaseBody body = pickup.body;
			body._enable = true;
			Pickup pickup2 = this.pickup;
			if ((object)this.pickup == null)
			{
				return;
			}
			nint num = (nint)typeof(PickupWeapon);
			nint num2 = (nint)pickup2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
			object obj3;
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rax_v23+FFFFFFF8+v163 @ rax_v8*8]");
				if (0 == (nint)typeof(PickupWeapon))
				{
					obj3 = 1;
					goto IL_026a;
				}
			}
			obj3 = 0;
			goto IL_026a;
			IL_028c:
			object obj4;
			bool flag = obj4 == null;
			PickupRelic pickupRelic = null;
			if (!flag)
			{
				pickupRelic = (PickupRelic)this.pickup;
			}
			if ((object)pickupRelic != null)
			{
				pickupRelic.StartFloatTween();
				pickupRelic.SetVfxVisible(visible: true);
				pickupRelic.SpawnCursor();
				((Pickup)pickupRelic)._003CAutoSafeXY_003Ek__BackingField = true;
			}
			return;
			IL_026a:
			bool flag2 = obj3 == null;
			PickupWeapon pickupWeapon = null;
			if (!flag2)
			{
				pickupWeapon = (PickupWeapon)this.pickup;
			}
			if ((object)pickupWeapon != null)
			{
				pickupWeapon.ResumeFloat();
				pickupWeapon.SetVfxVisible(visible: true);
				((Pickup)pickupWeapon)._003CAutoSafeXY_003Ek__BackingField = true;
				return;
			}
			if ((object)this.pickup == null)
			{
				return;
			}
			nint num4 = (nint)typeof(PickupRelic);
			nint num5 = (nint)pickup2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Items.PickupRelic>)+130]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r9_v5 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Items.PickupRelic>)+130]");
			if (num6 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r9_v5 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ rax_v17+FFFFFFF8+v262 @ rax_v10*8]");
				if (0 == (nint)typeof(PickupRelic))
				{
					obj4 = 1;
					goto IL_028c;
				}
			}
			obj4 = 0;
			goto IL_028c;
		}
	}

	private ArcadeSprite _magnet;

	private float _magnetRadius;

	private float _maxPickupVacuumSpeed;

	private float _pickupVacuumAcceleration;

	private float _pickupSpawnRadius = 1f;

	private float _maxExtraPickupSpawnDistance = 0.4f;

	private float _spawnTweenDuration = 0.5f;

	private int _maxGemsToSpawn = 20;

	private int _maxCoinsToSpawn = 20;

	private int _maxFrozenSoulsToSpawn = 20;

	private bool _isEnabled;

	private int _numberOfPickupsToSpawn;

	private int _spawningPickupIndex;

	private ValuePickupSpawner _gemSpawner;

	private ValuePickupSpawner _coinsSpawner;

	private ValuePickupSpawner _frozenSoulSpawner;

	private readonly List<Pickup> _collectedPickups;

	private readonly List<VacuumedPickup> _vacuumedPickups;

	private float _deltaTimeCounter;

	private Action m_OnAllPickupsSpawned;

	private SfxType[] stealSounds;

	public event Action OnAllPickupsSpawned
	{
		add
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 136;
			Delegate obj2 = this.m_OnAllPickupsSpawned;
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(Action);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 136;
			Delegate obj2 = this.m_OnAllPickupsSpawned;
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(Action);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	private bool IsPickupMoney(ItemType itemType)
	{
		//IL_000e: Expected O, but got I4
		//IL_003f: Expected O, but got I4
		object obj = itemType - 2;
		if ((nint)obj <= 3)
		{
			return true;
		}
		object obj2 = itemType - 41;
		return obj2 == null;
	}

	private bool IsIgnoredItemType(ItemType pickupType)
	{
		//IL_000e: Expected O, but got I4
		//IL_0069: Expected O, but got I4
		object obj = pickupType - 21;
		if ((nint)obj <= 59)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"bt rcx,rax\"");
			if ((nint)obj < 59)
			{
				return true;
			}
		}
		object obj2 = pickupType - 228;
		return obj2 == null;
	}

	public void InitMagnet(Transform enemyTransform)
	{
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected O, but got Unknown
		//IL_0145: Expected O, but got I4
		//IL_0145: Expected O, but got I4
		//IL_02d5: Expected O, but got I
		//IL_0460->IL03ed: Incompatible stack heights: 1 vs 0
		//IL_0487->IL03ed: Incompatible stack heights: 1 vs 0
		//IL_0084->IL03ed: Incompatible stack heights: 1 vs 0
		//IL_00a6->IL03ed: Incompatible stack heights: 1 vs 0
		//IL_00ec->IL03ed: Incompatible stack heights: 1 vs 0
		//IL_0123->IL03ed: Incompatible stack heights: 1 vs 0
		//IL_04ae->IL03ed: Incompatible stack heights: 1 vs 0
		//IL_0178->IL03ed: Incompatible stack heights: 1 vs 0
		//IL_04d5->IL03ed: Incompatible stack heights: 1 vs 0
		//IL_01b5->IL03ed: Incompatible stack heights: 1 vs 0
		//IL_01ff->IL03ed: Incompatible stack heights: 1 vs 0
		//IL_022e->IL03ed: Incompatible stack heights: 1 vs 0
		//IL_0265->IL03ed: Incompatible stack heights: 1 vs 0
		if ((object)enemyTransform != null)
		{
			bool flag = ((UnityEngine.Object)enemyTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)enemyTransform).m_CachedPtr, out Vector3 _);
			if ((object)_magnet != null)
			{
				GameObject gameObject = _magnet.gameObject;
				Vector2 pos = default(Vector2);
				SpriteRenderer spriteRenderer = RenderingExtensions.AddSprite(gameObject, pos, "vfx", "WhiteDot");
				float num = _magnetRadius * 100f;
				PhaserScene s_scene = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null)
				{
					Factory add = s_scene.add;
					if (s_scene.add != null && add._world != null)
					{
						PhaserGameObject phaserGameObject = add._world.enableBody(_magnet);
						ArcadeSprite magnet = _magnet;
						if ((object)_magnet != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
							object obj = num ^ 0;
							if (magnet.body != null)
							{
								BaseBody baseBody = magnet.body.setCircle(num, (float?)(object)1, (float?)(object)1);
								PhaserScene s_scene2 = ArcadePhysics.s_scene;
								if (ArcadePhysics.s_scene != null)
								{
									ArcadePhysics physics = s_scene2.physics;
									if ((object)s_scene2.physics != null)
									{
										PhysicsManager sInstance = PhysicsManager._sInstance;
										if (PhysicsManager._sInstance != null)
										{
											ArcadePhysicsCallback arcadePhysicsCallback = OnDancerMagnetOverlapsPickup;
											if (physics.add != null)
											{
												ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
												CallbackContext callbackContext = default(CallbackContext);
												Collider collider = physics.add.overlap(_magnet, sInstance._pickupGroup, arcadePhysicsCallback, processCallback, callbackContext);
												if (collider != null)
												{
													Collider collider2 = collider.setName("Dancer Magnet > Pickups");
													if ((object)spriteRenderer != null)
													{
														spriteRenderer.enabled = false;
														List<VacuumedPickup> vacuumedPickups = _vacuumedPickups;
														if (_vacuumedPickups != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rcx_v30 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.MazerellaDancerMagnet+VacuumedPickup>)+1C]");
															_ = (nint)0 + (nint)1;
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rcx_v30 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.MazerellaDancerMagnet+VacuumedPickup>)+18]");
															bool flag2 = (nint)0 <= (nint)0;
															ArcadePhysicsCallback arcadePhysicsCallback2 = arcadePhysicsCallback;
															if (!flag2)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rcx_v30 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.MazerellaDancerMagnet+VacuumedPickup>)+10]");
																nint num2 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rcx_v30 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.MazerellaDancerMagnet+VacuumedPickup>)+18]");
																Array.Clear((Array)num2, 0, 0);
																arcadePhysicsCallback2 = null;
															}
															Action<Vector2, float, Action<Pickup>> spawnPickupAction = null;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB2BD0");
															ValuePickupSpawner gemSpawner = new ValuePickupSpawner(startPickupSpawnTweenAction: StartPickupSpawnTween, maxPickupsToSpawn: _maxGemsToSpawn, spawnPickupAction: spawnPickupAction);
															_gemSpawner = gemSpawner;
															Action<Vector2, float, Action<Pickup>> spawnPickupAction2 = null;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB2BD0");
															ValuePickupSpawner coinsSpawner = new ValuePickupSpawner(startPickupSpawnTweenAction: StartPickupSpawnTween, maxPickupsToSpawn: _maxCoinsToSpawn, spawnPickupAction: spawnPickupAction2);
															_coinsSpawner = coinsSpawner;
															Action<Vector2, float, Action<Pickup>> spawnPickupAction3 = null;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB2BD0");
															ValuePickupSpawner frozenSoulSpawner = new ValuePickupSpawner(startPickupSpawnTweenAction: StartPickupSpawnTween, maxPickupsToSpawn: _maxFrozenSoulsToSpawn, spawnPickupAction: spawnPickupAction3);
															_frozenSoulSpawner = frozenSoulSpawner;
															_isEnabled = true;
															return;
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
				}
			}
		}
		throw new NullReferenceException();
	}

	public void DisableMagnet()
	{
		_isEnabled = false;
	}

	public void Cleanup()
	{
		//IL_00eb: Expected O, but got I
		List<Pickup> collectedPickups = _collectedPickups;
		int version = collectedPickups._version + 1;
		collectedPickups._version = version;
		collectedPickups._size = 0;
		if (collectedPickups._size > 0)
		{
			Array.Clear(collectedPickups._items, 0, collectedPickups._size);
		}
		List<VacuumedPickup> vacuumedPickups = _vacuumedPickups;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rcx_v5 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.MazerellaDancerMagnet+VacuumedPickup>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rcx_v5 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.MazerellaDancerMagnet+VacuumedPickup>)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rcx_v5 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.MazerellaDancerMagnet+VacuumedPickup>)+10]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rcx_v5 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.MazerellaDancerMagnet+VacuumedPickup>)+18]");
			Array.Clear((Array)num, 0, 0);
		}
		this.m_OnAllPickupsSpawned = null;
	}

	private unsafe bool OnDancerMagnetOverlapsPickup(CallbackContext context, ArcadeColliderType magnet, ArcadeColliderType pickup)
	{
		//IL_05ab: Expected I4, but got O
		//IL_005a: Expected I, but got O
		//IL_0062: Expected I, but got O
		//IL_0072: Expected O, but got I
		//IL_00f2: Expected O, but got I4
		//IL_00ae: Expected O, but got I
		//IL_00e4: Expected O, but got I4
		//IL_0146: Expected O, but got I4
		//IL_0243: Expected O, but got I
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Expected O, but got Unknown
		//IL_02b8: Expected O, but got I
		//IL_0610: Expected O, but got I4
		//IL_02a3: Expected O, but got I8
		//IL_0307: Expected I, but got O
		//IL_030f: Expected I, but got O
		//IL_031f: Expected O, but got I
		//IL_039f: Expected O, but got I4
		//IL_035b: Expected O, but got I
		//IL_0391: Expected O, but got I4
		//IL_0592: Expected O, but got Ref
		//IL_0435: Expected I, but got O
		//IL_043d: Expected I, but got O
		//IL_044d: Expected O, but got I
		//IL_04cd: Expected O, but got I4
		//IL_03f1: Expected O, but got I
		//IL_0489: Expected O, but got I
		//IL_04bf: Expected O, but got I4
		_003C_003Ec__DisplayClass28_0 obj = new _003C_003Ec__DisplayClass28_0();
		if (!_isEnabled)
		{
			goto IL_0597;
		}
		if (obj == null)
		{
			goto IL_059d;
		}
		ArcadeColliderType pickupItem;
		if (pickup == null)
		{
			pickupItem = null;
			goto IL_05d3;
		}
		nint num = (nint)typeof(Pickup);
		nint num2 = (nint)pickup;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rdx_v22 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ r8_v29 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rdx_v22 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
		object obj4;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ r8_v29 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v386 @ rax_v62+FFFFFFF8+v330 @ rax_v57*8]");
			if (0 == (nint)typeof(Pickup))
			{
				obj4 = 1;
				goto IL_05e5;
			}
		}
		obj4 = 0;
		goto IL_05e5;
		IL_0500:
		SetPickupInteractionsActive(obj.pickupItem, active: false);
		if (pickup != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B54E0");
			object obj5 = default(object);
			if (obj5 != null)
			{
				_ = 0;
				if (_vacuumedPickups != null)
				{
					Pickup pickup2 = default(Pickup);
					_vacuumedPickups.Add((VacuumedPickup)(&pickup2));
					goto IL_0597;
				}
			}
		}
		goto IL_059d;
		IL_05d3:
		obj.pickupItem = (Pickup)pickupItem;
		Func<VacuumedPickup, bool> predicate;
		if ((object)obj.pickupItem != null)
		{
			Pickup pickupItem2 = obj.pickupItem;
			object obj6 = pickupItem2._003CPickupType_003Ek__BackingField - 21;
			if ((nint)obj6 <= 59)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"bt rdx,rax\"");
				if ((nint)obj6 < 59)
				{
					goto IL_0597;
				}
			}
			if (pickupItem2._003CPickupType_003Ek__BackingField != ItemType.TP_MERCHANT_LIBRARIAN)
			{
				Pickup pickupItem3 = obj.pickupItem;
				if (!pickupItem3._goToPlayer && !pickupItem3._003CDisableGet_003Ek__BackingField)
				{
					predicate = null;
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r10_v3 (Il2CppMethodInfo)+8]");
					_ = 0;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r10_v3 (Il2CppMethodInfo)+4C]");
					object obj7 = (nint)0 >> 4;
					object obj8 = obj7 & 1;
					object obj9;
					if (obj8 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r10_v3 (Il2CppMethodInfo)+52]");
						if ((nint)0 == 1)
						{
							obj9 = 6447978640L;
							goto IL_0607;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v486 @ rax_v12 (System.Func`2<VampireSurvivors.Objects.Characters.MazerellaDancerMagnet+VacuumedPickup, System.Boolean>)+10]");
					obj9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v486 @ rax_v12 (System.Func`2<VampireSurvivors.Objects.Characters.MazerellaDancerMagnet+VacuumedPickup, System.Boolean>)+20]");
					_ = 0;
					goto IL_0607;
				}
			}
		}
		goto IL_0597;
		IL_0597:
		return false;
		IL_0607:
		object obj10 = 24;
		_ = 6447978512L;
		if (Enumerable.Any(_vacuumedPickups, predicate))
		{
			goto IL_0597;
		}
		Pickup pickupItem4 = obj.pickupItem;
		if ((object)obj.pickupItem == null)
		{
			goto IL_0500;
		}
		nint num5 = (nint)typeof(PickupWeapon);
		nint num6 = (nint)pickupItem4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v614 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v615 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v614 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
		object obj13;
		if (num7 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v615 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
			object obj12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v693 @ rax_v46+FFFFFFF8+v616 @ rax_v31*8]");
			if (0 == (nint)typeof(PickupWeapon))
			{
				obj13 = 1;
				goto IL_0640;
			}
		}
		obj13 = 0;
		goto IL_0640;
		IL_0662:
		object obj14;
		bool flag = obj14 == null;
		PickupRelic pickupRelic = null;
		if (!flag)
		{
			pickupRelic = (PickupRelic)obj.pickupItem;
		}
		if ((object)pickupRelic != null)
		{
			pickupRelic.StopFloatTween();
			pickupRelic.SetVfxVisible(visible: false);
		}
		goto IL_0500;
		IL_0640:
		bool flag2 = obj13 == null;
		Pickup pickup3 = null;
		if (!flag2)
		{
			pickup3 = obj.pickupItem;
		}
		if ((object)pickup3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v632 @ rdi_v7 (VampireSurvivors.Objects.Pickups.Pickup)+210]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v632 @ rdi_v7 (VampireSurvivors.Objects.Pickups.Pickup)+210]");
				TweenExtensions.Kill((Tween)0);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @187344AD0");
		}
		else if ((object)obj.pickupItem != null)
		{
			nint num8 = (nint)typeof(PickupRelic);
			nint num9 = (nint)pickupItem4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v636 @ r8_v18 (Il2CppClass<VampireSurvivors.Objects.Items.PickupRelic>)+130]");
			object obj15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v630 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v636 @ r8_v18 (Il2CppClass<VampireSurvivors.Objects.Items.PickupRelic>)+130]");
			if (num10 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v630 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
				object obj16 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v819 @ rax_v39+FFFFFFF8+v772 @ rax_v33*8]");
				if (0 == (nint)typeof(PickupRelic))
				{
					obj14 = 1;
					goto IL_0662;
				}
			}
			obj14 = 0;
			goto IL_0662;
		}
		goto IL_0500;
		IL_05e5:
		bool flag3 = obj4 == null;
		pickupItem = null;
		if (!flag3)
		{
			pickupItem = pickup;
		}
		goto IL_05d3;
		IL_059d:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public unsafe void UpdateVacuumedPickups()
	{
		//IL_0008: Expected O, but got Ref
		//IL_003b: Expected I, but got O
		//IL_0040: Expected I, but got O
		//IL_009b: Expected O, but got I
		//IL_00ce: Expected O, but got I
		//IL_00eb: Expected O, but got I
		//IL_0101: Expected O, but got I
		//IL_0759: Expected O, but got I
		//IL_078c: Expected O, but got I
		//IL_07a9: Expected O, but got I
		//IL_07bf: Expected O, but got I
		//IL_017d: Invalid comparison between F4 and I
		//IL_0196: Expected F4, but got I
		//IL_01a6: Expected O, but got I
		//IL_089b: Expected O, but got I4
		//IL_08eb: Expected O, but got I
		//IL_0900: Expected O, but got I
		//IL_01f5: Expected O, but got F4
		//IL_026d: Expected O, but got Ref
		//IL_0962: Expected O, but got I
		//IL_0397: Expected O, but got I
		//IL_05b9: Expected O, but got I
		//IL_05c1: Expected I, but got O
		//IL_0607: Expected O, but got I
		//IL_045f: Expected O, but got I
		//IL_0498: Expected I, but got O
		//IL_04a0: Expected I, but got O
		//IL_04b0: Expected O, but got I
		//IL_04ec: Expected O, but got I
		//IL_054f: Expected O, but got I
		//IL_02bb->IL08d3: Incompatible stack heights: 1 vs 0
		//IL_0985->IL08d3: Incompatible stack heights: 1 vs 0
		//IL_068a->IL068a: Incompatible stack heights: 1 vs 0
		//IL_09e0->IL08d3: Incompatible stack heights: 1 vs 0
		//IL_0440->IL08d3: Incompatible stack heights: 1 vs 0
		//IL_047f->IL08d3: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (!_isEnabled)
		{
			return;
		}
		List<VacuumedPickup> vacuumedPickups = _vacuumedPickups;
		if (_vacuumedPickups != null)
		{
			nint num = unchecked((nint)null);
			nint num2 = unchecked((nint)null);
			float num7 = default(float);
			Vector3 value = default(Vector3);
			object obj8 = default(object);
			float time = default(float);
			object obj19 = default(object);
			object obj20 = default(object);
			while (true)
			{
				List<VacuumedPickup> vacuumedPickups2 = _vacuumedPickups;
				nint intPtr = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rax_v15 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.MazerellaDancerMagnet+VacuumedPickup>)+18]");
				Component component;
				Vector3 position;
				Vector3 position2;
				ValuePickupSpawner valuePickupSpawner;
				float num17;
				float num13;
				if (intPtr < 0)
				{
					if (_vacuumedPickups == null)
					{
						break;
					}
					nint intPtr2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rbx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.MazerellaDancerMagnet+VacuumedPickup>)+18]");
					if (intPtr2 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rbx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.MazerellaDancerMagnet+VacuumedPickup>)+10]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rbx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.MazerellaDancerMagnet+VacuumedPickup>)+10]");
						if ((nint)0 == 0)
						{
							break;
						}
						object obj4 = num + 2;
						object obj5 = obj4 + obj4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rcx_v20+v932 @ rax_v32*8]");
						component = (Component)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rcx_v20+8+v932 @ rax_v32*8]");
						object obj6 = (nint)0 >> 32;
						if (obj6 == null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rcx_v20+v932 @ rax_v32*8]");
							if ((nint)0 == 0)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ xmm6_v9 (UnityEngine.Component)+28]");
							if ((nint)0 != 0)
							{
								float maxPickupVacuumSpeed = _maxPickupVacuumSpeed;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rcx_v20+8+v932 @ rax_v32*8]");
								bool flag = !(maxPickupVacuumSpeed > 0f);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rcx_v20+8+v932 @ rax_v32*8]");
								float num3 = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rcx_v20+v932 @ rax_v32*8]");
								Component component2 = (Component)0;
								if (!flag)
								{
									float deltaTime = PauseSystem.DeltaTime;
									float num4 = deltaTime * _pickupVacuumAcceleration;
									float num5 = num4;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rcx_v20+8+v932 @ rax_v32*8]");
									float num6 = num5 + 0f;
									num3 = num6;
									component2 = (Component)num7;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rcx_v20+v932 @ rax_v32*8]");
								Transform transform = ((Component)0).transform;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rcx_v20+v932 @ rax_v32*8]");
								Transform transform2 = ((Component)0).transform;
								if ((object)transform2 == null)
								{
									break;
								}
								position = transform2.position;
								Transform transform3 = base.transform;
								if ((object)transform3 == null)
								{
									break;
								}
								position2 = transform3.position;
								float deltaTime2 = PauseSystem.DeltaTime;
								float num8 = deltaTime2 * num3;
								object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2E70");
								bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rcx_v20+v932 @ rax_v32*8]");
								Transform transform4 = ((Component)0).transform;
								Vector3 position3 = transform4.position;
								Transform transform5 = base.transform;
								if ((object)transform5 == null)
								{
									break;
								}
								Vector3 position4 = transform5.position;
								float num9 = position3.x - position4.x;
								float num10 = (float)obj8 - num7;
								float num11 = position3.z - position4.z;
								float num12 = num9 * num9;
								num13 = num10 * num10;
								float num14 = num11 * num11;
								float num15 = num12 + num13;
								float num16 = num15 + num14;
								bool flag3 = !(0.01f > num16);
								num17 = num7;
								if (flag3)
								{
									goto IL_096b;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ xmm6_v9 (UnityEngine.Component)+F8]");
								object obj9 = -2;
								if ((nint)obj9 > 3)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ xmm6_v9 (UnityEngine.Component)+F8]");
									if ((nint)0 != 41)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ xmm6_v9 (UnityEngine.Component)+F8]");
										if ((nint)0 != 6)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ xmm6_v9 (UnityEngine.Component)+F8]");
											if ((nint)0 != 204)
											{
												if (_collectedPickups == null)
												{
													break;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA3FE0");
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ xmm6_v9 (UnityEngine.Component)+28]");
												object obj10 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ xmm6_v9 (UnityEngine.Component)+28]");
												if ((nint)0 == 0)
												{
													break;
												}
												_ = 0;
												nint num18 = (nint)typeof(PickupRelic);
												nint num19 = (nint)component;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1336 @ rdx_v35 (Il2CppClass<VampireSurvivors.Objects.Items.PickupRelic>)+130]");
												object obj11 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1334 @ r8_v18 (Il2CppClass<UnityEngine.Component>)+130]");
												nint num20 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1336 @ rdx_v35 (Il2CppClass<VampireSurvivors.Objects.Items.PickupRelic>)+130]");
												if (num20 >= 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1334 @ r8_v18 (Il2CppClass<UnityEngine.Component>)+C8]");
													object obj12 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1341 @ rax_v69+FFFFFFF8+v1340 @ rax_v68*8]");
													if (0 == (nint)typeof(PickupRelic))
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rcx_v20+v932 @ rax_v32*8]");
														if ((nint)0 != 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rcx_v20+v932 @ rax_v32*8]");
															((PickupRelic)0).HideCursor();
														}
													}
												}
												goto IL_098a;
											}
											valuePickupSpawner = _frozenSoulSpawner;
										}
										else
										{
											valuePickupSpawner = _gemSpawner;
										}
										goto IL_09be;
									}
								}
								valuePickupSpawner = _coinsSpawner;
								goto IL_09be;
							}
						}
						goto IL_068a;
					}
					goto IL_08a9;
				}
				bool flag4 = (nint)_vacuumedPickups < 0;
				if (_vacuumedPickups == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rbx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.MazerellaDancerMagnet+VacuumedPickup>)+18]");
				nint num21 = -1;
				if (flag4)
				{
					return;
				}
				while (true)
				{
					List<VacuumedPickup> vacuumedPickups3 = _vacuumedPickups;
					if (_vacuumedPickups == null)
					{
						break;
					}
					nint intPtr3 = num21;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rax_v19 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.MazerellaDancerMagnet+VacuumedPickup>)+18]");
					bool flag5;
					if (intPtr3 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rax_v19 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.MazerellaDancerMagnet+VacuumedPickup>)+10]");
						object obj13 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rax_v19 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.MazerellaDancerMagnet+VacuumedPickup>)+10]");
						if ((nint)0 == 0)
						{
							break;
						}
						object obj14 = num21 + 2;
						object obj15 = obj14 + obj14;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v391 @ rcx_v16+v1060 @ rax_v22*8]");
						object obj16 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v391 @ rcx_v16+8+v1060 @ rax_v22*8]");
						object obj17 = (nint)0 >> 32;
						if (obj17 == null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v391 @ rcx_v16+v1060 @ rax_v22*8]");
							if ((nint)0 == 0)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ xmm1_v10+28]");
							flag5 = (nint)0 < (nint)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ xmm1_v10+28]");
							if ((nint)0 != 0)
							{
								goto IL_0882;
							}
						}
						flag5 = (nint)_vacuumedPickups < 0;
						if (_vacuumedPickups == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18000A5A0");
						goto IL_0882;
					}
					goto IL_08a9;
					IL_0882:
					num21--;
					object obj18 = !flag5;
					if (obj18 == null)
					{
						return;
					}
				}
				break;
				IL_08a9:
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				break;
				IL_068a:
				vacuumedPickups = _vacuumedPickups;
				num++;
				if (_vacuumedPickups == null)
				{
					break;
				}
				num2 = num;
				continue;
				IL_098a:
				SfxType sfxType = VampireSurvivors.App.Tools.Extensions.PickRnd(stealSounds);
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
				{
					Rate = 1f
				};
				float value2 = UnityEngine.Random.value;
				_ = 0;
				float num22 = value2 - 0.5f;
				_ = 1056964608;
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+80]");
				soundConfig.Volume = (float?)(object)0;
				num17 = num22 * 200f;
				soundConfig.Detune = num17;
				PlaySoundResult playSoundResult = SoundManager.PlaySound(sfxType, soundConfig, 200f, 5, time);
				num13 = 200f;
				goto IL_096b;
				IL_09be:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
				if (valuePickupSpawner == null)
				{
					break;
				}
				float valueCollected = (float)obj19 + valuePickupSpawner._valueCollected;
				valuePickupSpawner._valueCollected = valueCollected;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rcx_v20+v932 @ rax_v32*8]");
				SetPickupInteractionsActive((Pickup)0, active: true);
				nint num23 = (nint)component;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1328 @ rax_v58 (Il2CppClass<UnityEngine.Component>)+368] (should have been resolved before IL gen)");
				goto IL_098a;
				IL_096b:
				if (_vacuumedPickups == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805F8A40");
				value = (Vector3)obj20;
				float x = position2.x;
				float x2 = position.x;
				goto IL_068a;
			}
		}
		throw new NullReferenceException();
	}

	public void UpdatePickUpLocations()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0305: Unknown result type (might be due to invalid IL or missing references)
		//IL_030a: Expected O, but got Unknown
		//IL_01fd->IL014b: Incompatible stack heights: 1 vs 0
		//IL_0324->IL014b: Incompatible stack heights: 10 vs 0
		//IL_014a->IL0329: Incompatible stack heights: 10 vs 0
		float deltaTime = PauseSystem.DeltaTime;
		List<Pickup> collectedPickups = _collectedPickups;
		float num = deltaTime + deltaTime;
		float deltaTimeCounter = num + _deltaTimeCounter;
		_deltaTimeCounter = deltaTimeCounter;
		if (_collectedPickups != null)
		{
			object obj = 0;
			object obj2 = 0;
			Vector3 value = default(Vector3);
			while (true)
			{
				if ((nint)obj2 < collectedPickups._size)
				{
					List<Pickup> collectedPickups2 = _collectedPickups;
					if (_collectedPickups == null)
					{
						break;
					}
					float num2 = (float)Math.PI * 2f / (float)collectedPickups2._size;
					float num3 = num2 * (float)obj;
					float num4 = num3 + _deltaTimeCounter;
					bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
					IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
					Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
					if ((object)transform == null)
					{
						break;
					}
					bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
					List<Pickup> collectedPickups3 = _collectedPickups;
					bool flag3 = _collectedPickups == null;
					bool flag4 = (nint)obj >= collectedPickups3._size;
					Pickup[] items = collectedPickups3._items;
					bool flag5 = collectedPickups3._items == null;
					bool flag6 = (nint)obj >= items.Length;
					Transform transform2 = (Transform)(object)items[obj];
					bool flag7 = (object)items[obj] == null;
					bool flag8 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					IntPtr gcHandlePtr2 = Component.get_transform_Injected(((UnityEngine.Object)transform2).m_CachedPtr);
					Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
					bool flag9 = (object)transform3 == null;
					bool flag10 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
					Transform.set_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value);
					collectedPickups = _collectedPickups;
					obj++;
					if (_collectedPickups == null)
					{
						break;
					}
					obj2 = obj;
					continue;
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	public void SetupPickupsToSpawnOnDeath()
	{
		//IL_0017: Invalid comparison between F4 and I4
		//IL_0069: Invalid comparison between F4 and I4
		//IL_00b3: Invalid comparison between F4 and I4
		ValuePickupSpawner gemSpawner = _gemSpawner;
		_numberOfPickupsToSpawn = 0;
		int num;
		if (gemSpawner._valueCollected < (float)gemSpawner._maxPickupsToSpawn)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
			int num2 = default(int);
			num = num2;
		}
		else
		{
			num = gemSpawner._maxPickupsToSpawn;
		}
		float valuePerPickupSpawned = gemSpawner._valueCollected / (float)num;
		gemSpawner._valuePerPickupSpawned = valuePerPickupSpawned;
		ValuePickupSpawner coinsSpawner = _coinsSpawner;
		_numberOfPickupsToSpawn = num;
		int maxPickupsToSpawn = default(int);
		if (coinsSpawner._valueCollected < (float)coinsSpawner._maxPickupsToSpawn)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
		}
		else
		{
			maxPickupsToSpawn = coinsSpawner._maxPickupsToSpawn;
		}
		int num3 = num + maxPickupsToSpawn;
		float valuePerPickupSpawned2 = coinsSpawner._valueCollected / (float)maxPickupsToSpawn;
		coinsSpawner._valuePerPickupSpawned = valuePerPickupSpawned2;
		ValuePickupSpawner frozenSoulSpawner = _frozenSoulSpawner;
		_numberOfPickupsToSpawn = num3;
		int maxPickupsToSpawn2 = default(int);
		if (frozenSoulSpawner._valueCollected < (float)frozenSoulSpawner._maxPickupsToSpawn)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
		}
		else
		{
			maxPickupsToSpawn2 = frozenSoulSpawner._maxPickupsToSpawn;
		}
		int num4 = maxPickupsToSpawn2 + num3;
		float valuePerPickupSpawned3 = frozenSoulSpawner._valueCollected / (float)maxPickupsToSpawn2;
		frozenSoulSpawner._valuePerPickupSpawned = valuePerPickupSpawned3;
		List<Pickup> collectedPickups = _collectedPickups;
		_numberOfPickupsToSpawn = num4;
		int numberOfPickupsToSpawn = num4 + collectedPickups._size;
		_numberOfPickupsToSpawn = numberOfPickupsToSpawn;
	}

	public void SpawnPickups()
	{
		//IL_0036: Invalid comparison between I4 and F4
		//IL_007b: Invalid comparison between I4 and F4
		//IL_00c0: Invalid comparison between I4 and F4
		//IL_014c->IL031e: Incompatible stack heights: 1 vs 0
		//IL_008a->IL00d7: Incompatible stack heights: 2 vs 1
		//IL_00d7->IL00d7: Incompatible stack heights: 3 vs 1
		//IL_0203->IL031e: Incompatible stack heights: 3 vs 0
		//IL_0217->IL031e: Incompatible stack heights: 3 vs 0
		//IL_01df->IL031e: Incompatible stack heights: 3 vs 0
		if (_numberOfPickupsToSpawn > 0)
		{
			ValuePickupSpawner valuePickupSpawner = _gemSpawner;
			Transform transform = base.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
			if (!(0f < valuePickupSpawner._valueCollected))
			{
				valuePickupSpawner = _coinsSpawner;
				Transform transform2 = base.transform;
				bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
				if (!(0f < valuePickupSpawner._valueCollected))
				{
					valuePickupSpawner = _frozenSoulSpawner;
					Transform transform3 = base.transform;
					bool flag3 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out ret);
					if (!(0f < valuePickupSpawner._valueCollected))
					{
						List<Pickup> collectedPickups = _collectedPickups;
						if (_spawningPickupIndex < collectedPickups._size)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							ArcadeSprite arcadeSprite = default(ArcadeSprite);
							arcadeSprite.CheckRenderer();
							arcadeSprite._spriteRenderer.enabled = true;
							StartPickupSpawnTween((Pickup)arcadeSprite);
							int spawningPickupIndex = _spawningPickupIndex + 1;
							_spawningPickupIndex = spawningPickupIndex;
						}
						else
						{
							Action onAllPickupsSpawned = this.m_OnAllPickupsSpawned;
							if (this.m_OnAllPickupsSpawned != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v633.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
							}
						}
						return;
					}
				}
			}
			if (valuePickupSpawner._valuePerPickupSpawned > valuePickupSpawner._valueCollected)
			{
				valuePickupSpawner._valuePerPickupSpawned = valuePickupSpawner._valueCollected;
			}
			Action<Vector2, float, Action<Pickup>> spawnPickupAction = valuePickupSpawner._spawnPickupAction;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v194 @ r8_v4 (System.Action`3<UnityEngine.Vector2, System.Single, System.Action`1<VampireSurvivors.Objects.Pickups.Pickup>>)+18] (should have been resolved before IL gen)");
			float valueCollected = valuePickupSpawner._valueCollected - valuePickupSpawner._valuePerPickupSpawned;
			valuePickupSpawner._valueCollected = valueCollected;
		}
		else
		{
			Action onAllPickupsSpawned2 = this.m_OnAllPickupsSpawned;
			if (this.m_OnAllPickupsSpawned != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v58.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	private unsafe void StartPickupSpawnTween(Pickup pickup)
	{
		//IL_001d: Expected I, but got O
		//IL_0032: Expected O, but got I
		//IL_03b2: Expected O, but got I
		//IL_0093: Expected I, but got I8
		//IL_00d1: Expected I, but got I8
		//IL_0208: Expected O, but got I
		//IL_0318: Expected O, but got Ref
		//IL_0157->IL0354: Incompatible stack heights: 1 vs 0
		//IL_01ce->IL0354: Incompatible stack heights: 1 vs 0
		//IL_025a->IL0354: Incompatible stack heights: 1 vs 0
		//IL_0293->IL0354: Incompatible stack heights: 1 vs 0
		//IL_0353->IL0353: Incompatible stack heights: 5 vs 1
		_003C_003Ec__DisplayClass34_0 CS_0024_003C_003E8__locals20 = new _003C_003Ec__DisplayClass34_0();
		if (CS_0024_003C_003E8__locals20 != null)
		{
			CS_0024_003C_003E8__locals20._003C_003E4__this = this;
			nint num = (nint)typeof(_003C_003Ec__DisplayClass34_0);
			Pickup pickup2 = default(Pickup);
			CS_0024_003C_003E8__locals20.pickup = pickup2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
				num = unchecked((nint)6573110936L);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v407 @ rax_v27 (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj2 == null)
				{
					MissingMethodException ex2 = new MissingMethodException();
					throw ex2;
				}
				num = unchecked((nint)6573110936L);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v440 @ rax_v30 (should have been resolved before IL gen)");
			float num2 = 0f * ((float)Math.PI / 180f);
			Transform transform = base.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C6C6E0");
				if (!(num2 > 1E-05f))
				{
				}
				object obj3 = default(object);
				float num3 = (float)obj3 * _pickupSpawnRadius;
				Pickup pickup3 = CS_0024_003C_003E8__locals20.pickup;
				if ((object)CS_0024_003C_003E8__locals20.pickup == null || ((UnityEngine.Object)pickup3).m_CachedPtr == (IntPtr)0)
				{
					return;
				}
				if ((object)CS_0024_003C_003E8__locals20.pickup != null)
				{
					GameObject gameObject = CS_0024_003C_003E8__locals20.pickup.gameObject;
					if ((object)gameObject == null || ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0)
					{
						return;
					}
					Component pickup4 = CS_0024_003C_003E8__locals20.pickup;
					if ((object)CS_0024_003C_003E8__locals20.pickup != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rax_v54 (UnityEngine.Component)+28]");
						if ((nint)0 == 0)
						{
							return;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rax_v54 (UnityEngine.Component)+28]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1106 @ rcx_v43+40]");
						if ((nint)0 != 0)
						{
							return;
						}
						GameObject gameObject2 = CS_0024_003C_003E8__locals20.pickup.gameObject;
						if ((object)gameObject2 != null)
						{
							Transform transform2 = gameObject2.transform;
							Transform transform3 = base.transform;
							if ((object)transform3 != null)
							{
								Vector3 position = transform3.position;
								bool flag2 = (object)transform2 == null;
								bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								float value = default(float);
								Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&value));
								bool flag4 = (object)CS_0024_003C_003E8__locals20.pickup == null;
								GameObject gameObject3 = CS_0024_003C_003E8__locals20.pickup.gameObject;
								bool flag5 = (object)gameObject3 == null;
								Transform target = gameObject3.transform;
								TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOMove(target, (Vector3)(&ret), _spawnTweenDuration);
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
								TweenCallback tweenCallback = delegate
								{
									//IL_0081: Expected I, but got O
									//IL_0089: Expected I, but got O
									//IL_0099: Expected O, but got I
									//IL_0119: Expected O, but got I4
									//IL_00d5: Expected O, but got I
									//IL_010b: Expected O, but got I4
									//IL_0189: Expected I, but got O
									//IL_0191: Expected I, but got O
									//IL_01a1: Expected O, but got I
									//IL_0221: Expected O, but got I4
									//IL_01dd: Expected O, but got I
									//IL_0213: Expected O, but got I4
									CS_0024_003C_003E8__locals20._003C_003E4__this.SetPickupInteractionsActive(CS_0024_003C_003E8__locals20.pickup, active: true);
									Pickup pickup5 = CS_0024_003C_003E8__locals20.pickup;
									BaseBody body = pickup5.body;
									body._enable = true;
									Pickup pickup6 = CS_0024_003C_003E8__locals20.pickup;
									if ((object)CS_0024_003C_003E8__locals20.pickup == null)
									{
										return;
									}
									nint num4 = (nint)typeof(PickupWeapon);
									nint num5 = (nint)pickup6;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
									object obj5 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
									nint num6 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
									object obj7;
									if (num6 >= 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
										object obj6 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rax_v23+FFFFFFF8+v163 @ rax_v8*8]");
										if (0 == (nint)typeof(PickupWeapon))
										{
											obj7 = 1;
											goto IL_026a;
										}
									}
									obj7 = 0;
									goto IL_026a;
									IL_028c:
									object obj8;
									bool flag6 = obj8 == null;
									PickupRelic pickupRelic = null;
									if (!flag6)
									{
										pickupRelic = (PickupRelic)CS_0024_003C_003E8__locals20.pickup;
									}
									if ((object)pickupRelic != null)
									{
										pickupRelic.StartFloatTween();
										pickupRelic.SetVfxVisible(visible: true);
										pickupRelic.SpawnCursor();
										((Pickup)pickupRelic)._003CAutoSafeXY_003Ek__BackingField = true;
									}
									return;
									IL_026a:
									bool flag7 = obj7 == null;
									PickupWeapon pickupWeapon = null;
									if (!flag7)
									{
										pickupWeapon = (PickupWeapon)CS_0024_003C_003E8__locals20.pickup;
									}
									if ((object)pickupWeapon != null)
									{
										pickupWeapon.ResumeFloat();
										pickupWeapon.SetVfxVisible(visible: true);
										((Pickup)pickupWeapon)._003CAutoSafeXY_003Ek__BackingField = true;
										return;
									}
									if ((object)CS_0024_003C_003E8__locals20.pickup == null)
									{
										return;
									}
									nint num7 = (nint)typeof(PickupRelic);
									nint num8 = (nint)pickup6;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Items.PickupRelic>)+130]");
									object obj9 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r9_v5 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
									nint num9 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Items.PickupRelic>)+130]");
									if (num9 >= 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r9_v5 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
										object obj10 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ rax_v17+FFFFFFF8+v262 @ rax_v10*8]");
										if (0 == (nint)typeof(PickupRelic))
										{
											obj8 = 1;
											goto IL_028c;
										}
									}
									obj8 = 0;
									goto IL_028c;
								};
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049B5D0");
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void SetPickupInteractionsActive(Pickup pickup, bool active)
	{
		//IL_00e3: Expected O, but got I
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected O, but got Unknown
		//IL_00f1: Expected I, but got O
		bool flag2 = default(bool);
		bool flag = (byte)((flag2 ? 1u : 0u) ^ 1u) != 0;
		pickup._003CDisableGet_003Ek__BackingField = flag;
		bool flag3 = (byte)((flag2 ? 1u : 0u) ^ 1u) != 0;
		pickup._003CIgnoreMadGroove_003Ek__BackingField = flag3;
		GameManager core = GM.Core;
		SignalBus signalBus;
		if (!flag2)
		{
			signalBus = core._signalBus;
			GameObject gameObject = pickup.gameObject;
		}
		else
		{
			signalBus = core._signalBus;
			GameObject gameObject2 = pickup.gameObject;
		}
		Type type = (Type)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type type2 = default(Type);
		type = type2;
		object obj3 = default(object);
		object signal = (IntPtr)obj3;
		bool requireDeclaration = default(bool);
		signalBus.InternalFire(type, signal, (object)null, requireDeclaration);
	}

	public MazerellaDancerMagnet()
	{
		List<Pickup> collectedPickups = new List<Pickup>();
		_collectedPickups = collectedPickups;
		List<VacuumedPickup> vacuumedPickups = new List<VacuumedPickup>();
		_vacuumedPickups = vacuumedPickups;
		SfxType[] array = new SfxType[2];
		_ = 525;
		_ = 526;
		stealSounds = array;
	}
}
