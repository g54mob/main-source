using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_DarkRift2_SkullProjectile : Projectile
{
	private TrailRenderer _Trail;

	private const float Radius = 32f;

	private const float Percentage = 0.125f;

	private const float SpeedModifier = 35f;

	private float _deltaTime;

	private float _outwardSpeed;

	private TP_DarkRift2_Weapon _trueWeapon;

	private float _cachedScale;

	private Timer _expireTimer;

	private Timer _trailTimer;

	protected override void Awake()
	{
		//IL_0285->IL01e8: Incompatible stack heights: 1 vs 0
		base.Awake();
		SpriteTextures.SpriteTexturesBase spriteTexturesBase = SpriteTextures.Base;
		if (SpriteTextures.Base != null && spriteTexturesBase.Vfx != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
			if ((object)_renderer != null)
			{
				_renderer.sprite = sprite;
				if ((object)_renderer != null)
				{
					_renderer.enabled = false;
					SpriteTextures.SpriteTexturesThosepeople thosepeople = SpriteTextures.Thosepeople;
					if (SpriteTextures.Thosepeople != null && thosepeople.Thosepeople != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A14C1]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						Sprite sprite2 = SpriteManager.GetSprite("TP_VFX_DarkRift_Skull", "ThosePeople");
						RenderingExtensions.SetMaterialToPackedSpriteInternal((Renderer)_Trail, sprite2, true);
						SpriteRenderer trail = (SpriteRenderer)(object)_Trail;
						if ((object)_Trail != null)
						{
							bool flag = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
							Renderer.set_sortingOrder_Injected(((UnityEngine.Object)trail).m_CachedPtr, 1);
							if ((object)_Trail != null)
							{
								_Trail.emitting = false;
								TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_Trail);
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I4, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_000e: Expected O, but got I4
		//IL_0306: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0112: Expected O, but got I4
		//IL_0112: Expected O, but got I4
		//IL_0127: Expected O, but got I4
		//IL_0252: Expected I, but got O
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		float? trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_02df;
		}
		nint num = (nint)typeof(TP_DarkRift2_Weapon);
		int num2 = (int)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v25 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_DarkRift2_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r9_v10 (System.Int32)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v25 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_DarkRift2_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r9_v10 (System.Int32)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rax_v42+FFFFFFF8+v68 @ rax_v37*8]");
			if (0 == (nint)typeof(TP_DarkRift2_Weapon))
			{
				obj3 = 1;
				goto IL_02ee;
			}
		}
		obj3 = 0;
		goto IL_02ee;
		IL_02ee:
		bool flag = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)_weapon;
		}
		goto IL_02df;
		IL_02df:
		_trueWeapon = (TP_DarkRift2_Weapon)trueWeapon;
		float num4 = _trueWeapon.PArea();
		float num5 = default(float);
		if (!(num5 > 1f))
		{
			_cachedScale = 1f;
			_isCullable = false;
		}
		BaseBody baseBody = body.setCircle(32f, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite = setScale(_cachedScale, (float?)(object)0);
		_Trail.emitting = true;
		_Trail.widthMultiplier = 0f;
		if (_trailTimer != null)
		{
			_trailTimer.Cancel();
		}
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer trailTimer = Timers.Register(1f, null, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_trailTimer = trailTimer;
		if ((object)_trueWeapon != null)
		{
			_outwardSpeed = 0f;
			float deltaTime = (float)_indexInWeapon * ((float)Math.PI * 2f / 3f);
			_deltaTime = deltaTime;
			if (_expireTimer != null)
			{
				_expireTimer.Cancel();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v535 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_DarkRift2_SkullProjectile>)+370]");
			Action onComplete = new Action(this, (IntPtr)0);
			nint num6 = (nint)this;
			Timer expireTimer = Timers.Register(5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_expireTimer = expireTimer;
			return;
		}
		throw new NullReferenceException();
	}

	public void InitTrail()
	{
		_Trail.emitting = true;
		_Trail.widthMultiplier = 0f;
		if (_trailTimer != null)
		{
			_trailTimer.Cancel();
		}
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer trailTimer = Timers.Register(1f, null, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_trailTimer = trailTimer;
	}

	public void InitMovement()
	{
		_outwardSpeed = 0f;
		float deltaTime = (float)_indexInWeapon * ((float)Math.PI * 2f / 3f);
		_deltaTime = deltaTime;
	}

	public override void InternalUpdate()
	{
		UpdateMovement();
		if (_trailTimer != null)
		{
			Timer trailTimer = _trailTimer;
			float timeElapsed = _trailTimer.GetTimeElapsed();
			float num = timeElapsed / trailTimer._003CDuration_003Ek__BackingField;
			float num2 = num * _cachedScale;
			float widthMultiplier = num2 * 0.5f;
			_Trail.widthMultiplier = widthMultiplier;
		}
	}

	private void UpdateMovement()
	{
		if ((object)_weapon != null)
		{
			float num = _weapon.PSpeed();
			float deltaTime = PauseSystem.DeltaTime;
			object obj = default(object);
			float num2 = (float)obj * 35f;
			Weapon weapon = _weapon;
			float num3 = deltaTime * num2;
			float num4 = num3 * 0.125f;
			float deltaTime2 = num4 + _deltaTime;
			_deltaTime = deltaTime2;
			if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
			{
				Transform transform = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
					bool flag2 = (object)_weapon == null;
					float num5 = _weapon.PSpeed();
					float num6 = _deltaTime * 1.2f;
					bool flag3 = !(1f < num6);
					float num7 = 1f;
					if (!flag3)
					{
						num7 = num6;
					}
					float deltaTime3 = PauseSystem.DeltaTime;
					object cachedTransform = _cachedTransform;
					float num8 = deltaTime3 * num7;
					float outwardSpeed = num8 + _outwardSpeed;
					_outwardSpeed = outwardSpeed;
					bool flag4 = (object)_cachedTransform == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rdi_v8 (System.Object)+10]");
					bool flag5 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rdi_v8 (System.Object)+10]");
					Transform.set_position_Injected((IntPtr)0, ref ret);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void UpdateTrail()
	{
		if (_trailTimer != null)
		{
			Timer trailTimer = _trailTimer;
			float timeElapsed = _trailTimer.GetTimeElapsed();
			float num = timeElapsed / trailTimer._003CDuration_003Ek__BackingField;
			float num2 = num * _cachedScale;
			float widthMultiplier = num2 * 0.5f;
			_Trail.widthMultiplier = widthMultiplier;
		}
	}

	public override void Despawn()
	{
		if ((object)_Trail != null)
		{
			_Trail.emitting = false;
			TrailRenderer trail = _Trail;
			if ((object)_Trail != null)
			{
				bool flag = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
				TrailRenderer.Clear_Injected(((UnityEngine.Object)trail).m_CachedPtr);
				if (_expireTimer != null)
				{
					_expireTimer.Cancel();
				}
				if (_trailTimer != null)
				{
					_trailTimer.Cancel();
				}
				base.Despawn();
				return;
			}
		}
		throw new NullReferenceException();
	}
}
