using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_PunchProjectile_Guayim : Projectile
{
	private sealed class _003CWaitForParticlesToFinish_003Ed__21(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public EME_PunchProjectile_Guayim _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0038: Expected I4, but got I8
			//IL_0153: Expected O, but got I4
			//IL_00c1->IL00ed: Incompatible stack heights: 4 vs 3
			//IL_00ed->IL0173: Incompatible stack heights: 4 vs 3
			EME_PunchProjectile_Guayim eME_PunchProjectile_Guayim = _003C_003E4__this;
			if (_003C_003E1__state <= 1)
			{
				_003C_003E1__state = -1;
				bool flag = (object)_003C_003E4__this == null;
				object guayimPunchingVFX = eME_PunchProjectile_Guayim.guayimPunchingVFX;
				bool flag2 = (object)eME_PunchProjectile_Guayim.guayimPunchingVFX == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rsi_v2 (System.Object)+10]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rsi_v2 (System.Object)+10]");
				object obj = ParticleSystem.IsAlive_Injected((IntPtr)0, true);
				if (obj == null)
				{
					bool flag4 = (object)eME_PunchProjectile_Guayim.guayimDustVFX == null;
					if (!eME_PunchProjectile_Guayim.guayimDustVFX.IsAlive())
					{
						eME_PunchProjectile_Guayim._isCullable = true;
						((Projectile)_003C_003E4__this).Despawn();
						return false;
					}
				}
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private ParticleSystem guayimPunchingVFX;

	private ParticleSystem guayimDustVFX;

	private float radius = 15f;

	private const float GUAYIM_DURATION = 5000f;

	private SpriteRenderer _guayimPlayerSpriteRenderer;

	private Vector3 _guayimPunchingScale;

	private Vector3 _guayimDustScale;

	private Vector3 _guayimPunchingPosition;

	private Vector3 _guayimDustPosition;

	private EnemyController _strongestEnemy;

	private Timer _hitboxTimer;

	private Timer _expireTimer;

	protected unsafe override void Awake()
	{
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Expected O, but got Unknown
		//IL_033e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0343: Expected O, but got Unknown
		//IL_0367: Expected O, but got I
		//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cb: Expected O, but got Unknown
		//IL_03ef: Expected O, but got I
		//IL_044e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0453: Expected O, but got Unknown
		//IL_0477: Expected O, but got I
		//IL_04d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04db: Expected O, but got Unknown
		//IL_04ff: Expected O, but got I
		//IL_015b->IL0277: Incompatible stack heights: 1 vs 0
		//IL_038e->IL0277: Incompatible stack heights: 1 vs 0
		//IL_0180->IL0180: Incompatible stack heights: 1 vs 0
		//IL_01fc->IL0277: Incompatible stack heights: 1 vs 0
		//IL_0416->IL0277: Incompatible stack heights: 2 vs 0
		//IL_0232->IL0277: Incompatible stack heights: 2 vs 0
		//IL_049e->IL0277: Incompatible stack heights: 3 vs 0
		//IL_0268->IL0277: Incompatible stack heights: 3 vs 0
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		object obj2 = default(object);
		if ((object)_renderer != null)
		{
			_renderer.sprite = sprite;
			SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_renderer, 2f);
			if ((object)_renderer != null)
			{
				_renderer.enabled = false;
				SpriteRenderer guayimPlayerSpriteRenderer = _guayimPlayerSpriteRenderer;
				if ((object)_guayimPlayerSpriteRenderer != null && ((UnityEngine.Object)guayimPlayerSpriteRenderer).m_CachedPtr != (IntPtr)0)
				{
					goto IL_0180;
				}
				SpriteRenderer cachedTransform = (SpriteRenderer)(object)_cachedTransform;
				if ((object)_cachedTransform != null)
				{
					_ = 0;
					_ = 0;
					bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
					object obj = obj2 - 48;
					Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out *(Vector3*)obj);
					GameObject gameObject = base.gameObject;
					Vector2 pos = default(Vector2);
					SpriteRenderer component = RenderingExtensions.AddSprite(gameObject, pos, "Emeralds_VFX", "Guayim_Background_VFX");
					SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(component, 0.25f);
					if ((object)spriteRenderer2 != null)
					{
						spriteRenderer2.enabled = false;
						_guayimPlayerSpriteRenderer = spriteRenderer2;
						goto IL_0180;
					}
				}
			}
		}
		goto IL_0277;
		IL_0277:
		throw new NullReferenceException();
		IL_0180:
		if ((object)guayimPunchingVFX != null)
		{
			Transform transform = guayimPunchingVFX.transform;
			if ((object)transform != null)
			{
				_ = 0;
				_ = 0;
				bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				object obj3 = obj2 - 48;
				Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-30]");
				_guayimPunchingScale = (Vector3)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-28]");
				_ = 0;
				if ((object)guayimDustVFX != null)
				{
					Transform transform2 = guayimDustVFX.transform;
					if ((object)transform2 != null)
					{
						_ = 0;
						_ = 0;
						bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						object obj4 = obj2 - 48;
						Transform.get_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)obj4);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-30]");
						_guayimDustScale = (Vector3)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-28]");
						_ = 0;
						if ((object)guayimPunchingVFX != null)
						{
							Transform transform3 = guayimPunchingVFX.transform;
							if ((object)transform3 != null)
							{
								_ = 0;
								_ = 0;
								bool flag4 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
								object obj5 = obj2 - 48;
								Transform.get_localPosition_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out *(Vector3*)obj5);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-30]");
								_guayimPunchingPosition = (Vector3)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-28]");
								_ = 0;
								if ((object)guayimPunchingVFX != null)
								{
									Transform transform4 = guayimPunchingVFX.transform;
									if ((object)transform4 != null)
									{
										_ = 0;
										_ = 0;
										bool flag5 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
										object obj6 = obj2 - 48;
										Transform.get_localPosition_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out *(Vector3*)obj6);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-30]");
										_guayimDustPosition = (Vector3)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-28]");
										_ = 0;
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0277;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		base.InitProjectile(pool, weapon, index);
		EnemyController strongestTarget = GetStrongestTarget();
		_strongestEnemy = strongestTarget;
		EnemyController strongestEnemy = _strongestEnemy;
		if ((object)_strongestEnemy != null && ((UnityEngine.Object)strongestEnemy).m_CachedPtr != (IntPtr)0)
		{
			SetupMechanics();
			SetupVFX();
			SetupTimers();
		}
		else
		{
			Despawn();
		}
	}

	public unsafe override void InternalUpdate()
	{
		//IL_027a->IL0200: Incompatible stack heights: 1 vs 0
		//IL_0087->IL0200: Incompatible stack heights: 1 vs 0
		//IL_02d3->IL0200: Incompatible stack heights: 2 vs 0
		//IL_00b3->IL0200: Incompatible stack heights: 2 vs 0
		//IL_00e2->IL0200: Incompatible stack heights: 2 vs 0
		//IL_01b2->IL0200: Incompatible stack heights: 7 vs 0
		//IL_03d1->IL0200: Incompatible stack heights: 8 vs 0
		//IL_0415->IL01f3: Incompatible stack heights: 9 vs 7
		Weapon weapon = _weapon;
		if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			Transform transform = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				if ((object)_guayimPlayerSpriteRenderer != null)
				{
					Sprite sprite = _guayimPlayerSpriteRenderer.sprite;
					if ((object)sprite != null)
					{
						bool flag2 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
						float2 ret2;
						Sprite.get_bounds_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out *(Bounds*)(&ret2));
						Weapon weapon2 = _weapon;
						if ((object)_weapon != null && (object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
						{
							Transform transform2 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.transform;
							if ((object)transform2 != null)
							{
								bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
								bool flag4 = (object)_guayimPlayerSpriteRenderer == null;
								Transform transform3 = _guayimPlayerSpriteRenderer.transform;
								bool flag5 = (object)transform3 == null;
								bool flag6 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
								Transform.set_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)(&ret2));
								bool flag7 = (object)_guayimPlayerSpriteRenderer == null;
								_guayimPlayerSpriteRenderer.enabled = true;
								Transform strongestEnemy = (Transform)(object)_strongestEnemy;
								if ((object)_strongestEnemy == null || ((UnityEngine.Object)strongestEnemy).m_CachedPtr == (IntPtr)0)
								{
									return;
								}
								Transform strongestEnemy2 = (Transform)(object)_strongestEnemy;
								if ((object)_strongestEnemy != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rax_v68 (UnityEngine.Transform)+260]");
									if ((nint)0 != 0)
									{
										_strongestEnemy = null;
										return;
									}
									bool flag8 = ((UnityEngine.Object)strongestEnemy2).m_CachedPtr == (IntPtr)0;
									IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)strongestEnemy2).m_CachedPtr);
									Transform transform4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
									if ((object)transform4 != null)
									{
										bool flag9 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
										Transform.get_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out ret);
										float2 float5 = default(float2);
										base.position = float5;
										return;
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

	private void SetupMechanics()
	{
		//IL_00fe: Expected O, but got I4
		//IL_0073: Expected O, but got I4
		//IL_0073: Expected O, but got I4
		//IL_00c1: Expected O, but got I4
		_speed = 2f;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		ArcadeSprite arcadeSprite2 = setVisible(visible: true);
		_isCullable = false;
		float2 float5 = _strongestEnemy.position;
		base.position = float5;
		float num = _weapon.PArea();
		float num2 = radius + radius;
		object obj = default(object);
		float num3 = num2 * (float)obj;
		BaseBody baseBody = body.setCircle(num3, (float?)(object)0, (float?)(object)0);
		EnemyController strongestEnemy = _strongestEnemy;
		Vector2 vector = strongestEnemy._EnemyRenderer.size;
		float x = radius ^ -0f;
		BaseBody baseBody2 = body.setOffset(x, (float?)(object)1);
		BaseBody baseBody3 = body;
		baseBody3._enable = true;
	}

	private void SetupVFX()
	{
		EnemyController strongestEnemy = _strongestEnemy;
		Vector2 vector = strongestEnemy._EnemyRenderer.size;
		Transform transform = guayimPunchingVFX.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		Transform transform2 = guayimPunchingVFX.transform;
		bool flag2 = (object)transform2 == null;
		bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
		bool flag4 = (object)guayimDustVFX == null;
		Transform transform3 = guayimDustVFX.transform;
		bool flag5 = (object)transform3 == null;
		bool flag6 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
		Transform.set_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value);
		bool flag7 = (object)guayimDustVFX == null;
		Transform transform4 = guayimDustVFX.transform;
		bool flag8 = (object)transform4 == null;
		bool flag9 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref value2);
		bool flag10 = (object)guayimPunchingVFX == null;
		guayimPunchingVFX.Play(withChildren: true);
		bool flag11 = (object)guayimDustVFX == null;
		guayimDustVFX.Play(withChildren: true);
	}

	private void SetupTimers()
	{
		//IL_0135: Expected I, but got O
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		float hitBoxDelay = _weapon.HitBoxDelay;
		Action onComplete = delegate
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		};
		float num = hitBoxDelay * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer hitboxTimer = Timers.Register(num, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_hitboxTimer = hitboxTimer;
		float num2 = _weapon.PDuration();
		Weapon weapon = _weapon;
		float num3 = num * 5000f;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		characterController._classSupport.AddActiveMirrorOfTruth(1f, 0f, num3);
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_PunchProjectile_Guayim>)+370]");
		Action onComplete2 = new Action(this, (IntPtr)0);
		nint num4 = (nint)this;
		float duration = num3 * 0.001f;
		Timer expireTimer = Timers.Register(duration, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
	}

	private EnemyController GetStrongestTarget()
	{
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Expected O, but got Unknown
		//IL_0154: Expected O, but got I4
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected I4, but got Unknown
		//IL_0192: Expected F4, but got I4
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d7: Expected O, but got Unknown
		//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Expected O, but got Unknown
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fb: Expected I4, but got Unknown
		//IL_0310: Unknown result type (might be due to invalid IL or missing references)
		//IL_0315: Expected I4, but got Unknown
		Camera main = Camera.main;
		Bounds bounds = CameraExtensions.OrthographicBounds(main);
		object obj = default(object);
		float num = (float)obj * 2f;
		float num2 = num * 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v5 (UnityEngine.Bounds)+10]");
		float num3 = 0f * 2f;
		Weapon weapon = _weapon;
		float num4 = num3 * 0.5f;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		float x;
		if (characterController._isFlipped)
		{
			x = (float)bounds.m_Center - (float)obj;
		}
		else
		{
			object obj2 = (object)bounds.m_Center + obj;
			x = (float)obj2 - num2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v5 (UnityEngine.Bounds)+10]");
		object obj3 = obj - 0;
		Rectangle rectangle = new Rectangle();
		float num5 = num4 * 0.5f;
		rectangle._x = x;
		rectangle._width = num2;
		float y = num5 + (float)obj3;
		rectangle._height = num4;
		rectangle._y = y;
		List<EnemyController> allEnemiesInRectBounds = GetAllEnemiesInRectBounds(rectangle);
		if (allEnemiesInRectBounds != null && allEnemiesInRectBounds._size != 0)
		{
			bool flag = allEnemiesInRectBounds._size <= 0;
			EnemyController result = null;
			if (!flag)
			{
				object obj4 = -allEnemiesInRectBounds._size;
				int num6 = allEnemiesInRectBounds._size & obj4;
				bool flag2 = num6 < 0;
				bool flag3 = (nint)obj4 < 0;
				EnemyController enemyController = null;
				float num7 = 0f;
				EnemyController enemyController2 = null;
				bool flag4;
				EnemyController result2 = default(EnemyController);
				do
				{
					if (flag3 != flag2)
					{
						EnemyController[] items = allEnemiesInRectBounds._items;
						EnemyController enemyController3 = items[(object)enemyController2];
						if (!(num7 > enemyController3._maxHp))
						{
							num7 = enemyController3._maxHp;
							enemyController = enemyController3;
						}
						enemyController2 = (EnemyController)(enemyController2 + 1);
						object obj5 = enemyController2 - allEnemiesInRectBounds._size;
						int num8 = enemyController2 ^ allEnemiesInRectBounds._size;
						object obj6 = (object)enemyController2 ^ obj5;
						int num9 = num8 & obj6;
						flag2 = num9 < 0;
						flag3 = (nint)obj5 < 0;
						flag4 = (nint)enemyController2 < allEnemiesInRectBounds._size;
						result = enemyController;
						continue;
					}
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					return result2;
				}
				while (flag4);
			}
			return result;
		}
		return null;
	}

	private static List<EnemyController> GetAllEnemiesInRectBounds(Rectangle _rect)
	{
		//IL_00af: Expected O, but got I4
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Expected O, but got Unknown
		//IL_0280: Expected O, but got I4
		if (_rect == null)
		{
			return null;
		}
		List<EnemyController> list2;
		if ((object)GM.Core != null && (object)ArcadePhysics.s_instance != null)
		{
			float height = default(float);
			bool includeDynamic = default(bool);
			bool includeStatic = default(bool);
			Group specificGroup = default(Group);
			List<BaseBody> list = ArcadePhysics.s_instance.OverlapRect(_rect._x, _rect._y, _rect._width, height, includeDynamic, includeStatic, specificGroup);
			list2 = new List<EnemyController>();
			bool flag = (nint)list < 0;
			if (list != null)
			{
				object obj = list._size - 1;
				if (flag)
				{
					goto IL_028e;
				}
				while (true)
				{
					if ((nint)obj < list._size)
					{
						BaseBody[] items = list._items;
						if (list._items == null)
						{
							break;
						}
						BaseBody baseBody = items[obj];
						bool flag2 = items[obj] == null;
						Component component = (Component)(object)items[obj];
						if (!flag2)
						{
							component = baseBody._gameObject;
						}
						UnityEngine.Object obj2;
						if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
						{
							EnemyController component2 = component.GetComponent<EnemyController>();
							obj2 = component2;
						}
						else
						{
							obj2 = null;
						}
						bool flag3 = obj2;
						bool flag4 = (flag3 ? 1 : 0) < (false ? 1 : 0);
						if (flag3)
						{
							if ((object)obj2 == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rbx_v7 (UnityEngine.Object)+260]");
							flag4 = (nint)0 < (nint)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rbx_v7 (UnityEngine.Object)+260]");
							if ((nint)0 == 0)
							{
								flag4 = (nint)list2 < 0;
								if (list2 == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FE520");
							}
						}
						obj--;
						object obj3 = !flag4;
						if (obj3 != null)
						{
							continue;
						}
						goto IL_028e;
					}
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					break;
				}
			}
		}
		return (List<EnemyController>)(object)new NullReferenceException();
		IL_028e:
		return list2;
	}

	public override void Despawn()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
		guayimPunchingVFX.Stop();
		guayimPunchingVFX.Clear(withChildren: true);
		guayimDustVFX.Stop();
		guayimDustVFX.Clear(withChildren: true);
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		_003CWaitForParticlesToFinish_003Ed__21 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private IEnumerator WaitForParticlesToFinish()
	{
		_003CWaitForParticlesToFinish_003Ed__21 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void _003CSetupTimers_003Eb__17_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	private void _003C_003En__0()
	{
		base.Despawn();
	}
}
