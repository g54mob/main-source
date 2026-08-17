using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_PunchProjectile : Projectile
{
	private SpriteRenderer groundVFX;

	private ParticleSystem punchVFX;

	private ParticleSystem dustVFX;

	private ParticleEventCall dustVFXparticleEventCall;

	private float Radius = 25f;

	private const float FRONT_OFFSET = 30f;

	private bool flipVerticalVFX;

	private Vector3 _punchScale;

	private Vector3 _dustScale;

	private Timer _hitboxTimer;

	private Timer _expireTimer;

	private float _totalTime = 200f;

	private float _elapsedTime;

	private bool _showVFX;

	private bool _cachedFlipX;

	protected override void Awake()
	{
		//IL_00f2->IL0091: Incompatible stack heights: 1 vs 0
		//IL_0082->IL0091: Incompatible stack heights: 1 vs 0
		base.Awake();
		if ((object)punchVFX != null)
		{
			Transform transform = punchVFX.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				_punchScale = ret;
				_ = 0;
				if ((object)dustVFX != null)
				{
					Transform transform2 = dustVFX.transform;
					if ((object)transform2 != null)
					{
						bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Transform.get_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
						_dustScale = ret;
						_ = 0;
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_00db: Expected O, but got I4
		//IL_00fe: Expected O, but got I4
		//IL_00fe: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		SpriteTextures.SpriteTexturesBase spriteTexturesBase = SpriteTextures.Base;
		if (spriteTexturesBase.Unitycircle != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F5AB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			Sprite sprite = SpriteManager.GetSprite("UnityCircle", "UnityCircle");
			groundVFX.sprite = sprite;
			float num = _weapon.PArea();
			object obj = default(object);
			float radius = (float)obj * Radius;
			_speed = 2f;
			_isCullable = false;
			ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
			BaseBody baseBody = body.setCircle(radius, (float?)(object)1, (float?)(object)1);
			Weapon weapon2 = _weapon;
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
			_cachedFlipX = characterController._isFlipped;
			SetupVFX();
			if (_hitboxTimer != null)
			{
				_hitboxTimer.Cancel();
			}
			float hitBoxDelay = _weapon.HitBoxDelay;
			Action onComplete = delegate
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			};
			float duration = hitBoxDelay * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer hitboxTimer = Timers.Register(duration, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_hitboxTimer = hitboxTimer;
			BaseBody baseBody2 = body;
			baseBody2._enable = false;
			_elapsedTime = 0f;
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			_showVFX = config._003CFlashingVFXEnabled_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 540 Invalid \"Jump target not found in method: 0x187230850\"");
		}
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		UpdatePosition();
	}

	private void UpdatePosition()
	{
		//IL_01be: Invalid comparison between I4 and F4
		//IL_0114: Expected F4, but got I4
		float deltaTime = PauseSystem.DeltaTime;
		Weapon weapon = _weapon;
		float num = deltaTime * 1000f;
		float num2 = (_elapsedTime = num + _elapsedTime) / _totalTime;
		if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			Transform transform = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				if (_cachedFlipX)
				{
				}
				Transform transform2 = base.transform;
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
				bool flag2 = (object)transform2 == null;
				bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
				bool flag4 = (object)punchVFX == null;
				Transform transform3 = punchVFX.transform;
				bool flag5 = (object)transform3 == null;
				bool flag6 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
				Vector3 value2 = default(Vector3);
				Transform.set_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value2);
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void SetupMechanics()
	{
		//IL_004b: Expected O, but got I4
		//IL_006e: Expected O, but got I4
		//IL_006e: Expected O, but got I4
		float num = _weapon.PArea();
		object obj = default(object);
		float radius = (float)obj * Radius;
		_speed = 2f;
		_isCullable = false;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		BaseBody baseBody = body.setCircle(radius, (float?)(object)1, (float?)(object)1);
		Weapon weapon = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		_cachedFlipX = characterController._isFlipped;
	}

	private void SetupTimers()
	{
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		float hitBoxDelay = _weapon.HitBoxDelay;
		Action onComplete = delegate
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		};
		float duration = hitBoxDelay * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer hitboxTimer = Timers.Register(duration, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_hitboxTimer = hitboxTimer;
	}

	private void SetupVFX()
	{
		//IL_0059: Expected O, but got I4
		//IL_02a7: Expected I, but got O
		//IL_02e7: Expected I4, but got I8
		//IL_0204: Expected I4, but got I8
		//IL_0268->IL0205: Incompatible stack heights: 1 vs 0
		//IL_0371->IL0205: Incompatible stack heights: 9 vs 0
		//IL_01b5->IL0205: Incompatible stack heights: 9 vs 0
		PhaserScene s_scene = ArcadePhysics.s_scene;
		if (ArcadePhysics.s_scene != null)
		{
			PhaserScene.Renderer renderer = s_scene._renderer;
			if (s_scene._renderer != null)
			{
				int num = renderer.pixelHeight >> 31;
				object obj = renderer.pixelHeight - num;
				object obj2 = obj >> 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
				if ((object)groundVFX != null)
				{
					Transform transform = groundVFX.transform;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rax_v45 (UnityEngine.Transform)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rax_v45 (UnityEngine.Transform)+10]");
					Vector3 value = default(Vector3);
					Transform.set_localPosition_Injected((IntPtr)0, ref value);
					Transform transform2 = groundVFX.transform;
					if ((object)_weapon != null)
					{
						float num2 = _weapon.PArea();
						bool flag2 = (object)transform2 == null;
						bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Vector3 value2 = default(Vector3);
						Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
						nint num3 = (nint)groundVFX;
						bool flag4 = (object)groundVFX == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v585 @ rbx_v20 (Il2CppStaticFields<UnityEngine.Vector3>)+10]");
						bool flag5 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v585 @ rbx_v20 (Il2CppStaticFields<UnityEngine.Vector3>)+10]");
						Renderer.set_sortingOrder_Injected((IntPtr)0, -1998);
						bool flag6 = (object)punchVFX == null;
						Transform transform3 = punchVFX.transform;
						bool flag7 = (object)_weapon == null;
						float num4 = _weapon.PArea();
						bool flag8 = (object)transform3 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v765 @ rax_v66 (UnityEngine.Transform)+10]");
						bool flag9 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v765 @ rax_v66 (UnityEngine.Transform)+10]");
						Transform.set_localScale_Injected((IntPtr)0, ref value);
						if (_showVFX)
						{
						}
						if ((object)dustVFX != null)
						{
							Transform transform4 = dustVFX.transform;
							if ((object)_weapon != null)
							{
								float num5 = _weapon.PArea();
								bool flag10 = (object)transform4 == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rax_v72 (UnityEngine.Transform)+10]");
								bool flag11 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rax_v72 (UnityEngine.Transform)+10]");
								Transform.set_localScale_Injected((IntPtr)0, ref value2);
								RenderingExtensions.SetDepth(dustVFX, -1997);
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void PlayPunch()
	{
		//IL_0030: Expected I, but got O
		//IL_01a0: Expected O, but got I4
		//IL_01ee: Expected F4, but got I4
		//IL_02f0->IL01f3: Incompatible stack heights: 6 vs 0
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_PunchProjectile>)+370]");
		Action onComplete = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		bool flag = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer = Timers.Register(0.3f, onComplete, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
		if ((object)punchVFX != null)
		{
			Transform transform = punchVFX.transform;
			if ((object)transform != null)
			{
				bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				if (flipVerticalVFX && !_cachedFlipX)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-A0), the output could be wrong!");
					Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 269 ConditionalJump @-1, v599 @ ZF_v20 (System.Boolean) --- -1 Nop");
					Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 360 ConditionalJump @-1, v600 @ ZF_v26 (System.Boolean) --- -1 Nop");
					Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 173 ConditionalJump @-1, v313 @ ZF_v14 (System.Boolean) --- -1 Nop");
					Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 255 ConditionalJump @-1, v564 @ ZF_v19 (System.Boolean) --- -1 Nop");
					Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 305 ConditionalJump @-1, v638 @ ZF_v22 (System.Boolean) --- -1 Nop");
					Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 347 ConditionalJump @-1, v601 @ ZF_v25 (System.Boolean) --- -1 Nop");
					/*Error: End of method reached without returning.*/;
				}
				bool flag3 = (object)punchVFX == null;
				Transform transform2 = punchVFX.transform;
				bool flag4 = (object)transform2 == null;
				bool flag5 = ((Delegate)(object)transform2).method_ptr == (IntPtr)0;
				Transform.set_localScale_Injected(((Delegate)(object)transform2).method_ptr, ref ret);
				BaseBody baseBody = body;
				bool flag6 = body == null;
				baseBody._enable = true;
				bool flag7 = (object)punchVFX == null;
				ParticleEventCall component = punchVFX.GetComponent<ParticleEventCall>();
				if ((object)component != null)
				{
					component._eventCalled = false;
				}
				if ((object)punchVFX != null)
				{
					punchVFX.Play(withChildren: true);
					SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
					soundConfig.Rate = 1f;
					soundConfig.Volume = (float?)(object)1;
					soundConfig.Rate = 2f;
					float detune = (float)_indexInWeapon * -100f;
					soundConfig.Detune = detune;
					PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_Punch1, soundConfig, 100f, 2, flag ? 1 : 0);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public void SetFlipDirection(bool flip)
	{
		flipVerticalVFX = flip;
	}

	public void EnableGroundVFX()
	{
		groundVFX.enabled = _showVFX;
	}

	public override void Despawn()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
		groundVFX.enabled = false;
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if ((object)punchVFX != null)
		{
			punchVFX.Stop();
		}
		if ((object)dustVFX != null)
		{
			dustVFX.Stop();
		}
		if ((object)punchVFX != null)
		{
			punchVFX.Clear(withChildren: true);
		}
		if ((object)dustVFX != null)
		{
			dustVFX.Clear(withChildren: true);
		}
		_isCullable = true;
		base.Despawn();
	}

	private void DespawnAfterParticlesStopped()
	{
		if ((object)punchVFX != null)
		{
			punchVFX.Clear(withChildren: true);
		}
		if ((object)dustVFX != null)
		{
			dustVFX.Clear(withChildren: true);
		}
		_isCullable = true;
		base.Despawn();
	}

	private void FinishDespawn()
	{
		if ((object)punchVFX != null)
		{
			punchVFX.Clear(withChildren: true);
		}
		if ((object)dustVFX != null)
		{
			dustVFX.Clear(withChildren: true);
		}
		_isCullable = true;
		base.Despawn();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && _weapon.HasActiveArcanaOfType(ArcanaType.T19_FIRE))
		{
			Weapon weapon = _weapon;
			GameManager gameMan = weapon._gameMan;
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			gameMan._arcanaManager.TriggerFireExplosion(pos);
		}
	}

	private void _003CSetupTimers_003Eb__20_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}
}
