using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Weapons;

public class TP_SacredBeasts1_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass26_0
	{
		public TP_SacredBeasts1_Weapon _003C_003E4__this;

		public float alphaStart;

		public float scaleStart;

		internal void _003CPlayInvulAnimation_003Eb__0()
		{
			//IL_0040: Expected O, but got I4
			TP_SacredBeasts1_Weapon tP_SacredBeasts1_Weapon = _003C_003E4__this;
			PhaserSprite phaserSprite = tP_SacredBeasts1_Weapon._guardianSprite2.setAlpha(alphaStart);
			PhaserSprite phaserSprite2 = phaserSprite.setScale(scaleStart, (float?)(object)0);
		}

		internal void _003CPlayInvulAnimation_003Eb__1()
		{
			//IL_0040: Expected O, but got I4
			TP_SacredBeasts1_Weapon tP_SacredBeasts1_Weapon = _003C_003E4__this;
			PhaserSprite phaserSprite = tP_SacredBeasts1_Weapon._guardianSprite1.setAlpha(alphaStart);
			PhaserSprite phaserSprite2 = phaserSprite.setScale(scaleStart, (float?)(object)0);
		}

		internal void _003CPlayInvulAnimation_003Eb__2()
		{
			//IL_0040: Expected O, but got I4
			TP_SacredBeasts1_Weapon tP_SacredBeasts1_Weapon = _003C_003E4__this;
			PhaserSprite phaserSprite = tP_SacredBeasts1_Weapon._guardianSprite4.setAlpha(alphaStart);
			PhaserSprite phaserSprite2 = phaserSprite.setScale(scaleStart, (float?)(object)0);
		}

		internal void _003CPlayInvulAnimation_003Eb__3()
		{
			//IL_0040: Expected O, but got I4
			TP_SacredBeasts1_Weapon tP_SacredBeasts1_Weapon = _003C_003E4__this;
			PhaserSprite phaserSprite = tP_SacredBeasts1_Weapon._guardianSprite3.setAlpha(alphaStart);
			PhaserSprite phaserSprite2 = phaserSprite.setScale(scaleStart, (float?)(object)0);
		}
	}

	private sealed class _003C_003Ec__DisplayClass34_0
	{
		public TP_SacredBeasts1_Weapon _003C_003E4__this;

		public BulletPool pool;
	}

	private sealed class _003C_003Ec__DisplayClass34_1
	{
		public Vector2 __pos;

		public int localIndex;

		public _003C_003Ec__DisplayClass34_0 CS_0024_003C_003E8__locals1;

		internal void _003CFireProjectiles_003Eb__0()
		{
			//IL_0160: Expected O, but got I4
			//IL_00a8->IL0129: Incompatible stack heights: 1 vs 0
			//IL_00d7->IL0129: Incompatible stack heights: 1 vs 0
			//IL_00f9->IL0129: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass34_0 obj = CS_0024_003C_003E8__locals1;
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
					_003C_003Ec__DisplayClass34_0 obj3 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null)
					{
						TP_SacredBeasts1_Weapon tP_SacredBeasts1_Weapon = obj3._003C_003E4__this;
						if ((object)obj3._003C_003E4__this != null && (object)obj3._003C_003E4__this != null)
						{
							Vector2 pos = default(Vector2);
							Projectile projectile = obj3._003C_003E4__this.FireOneProjectile(pos, localIndex, tP_SacredBeasts1_Weapon._targetTransform);
							return;
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private BulletPool _standardPool;

	private BulletPool _retaliationPool;

	private bool _canRetaliate;

	private bool _canOverheal;

	private Timer _retaliationTimer;

	private Timer _overHealTimer;

	private float OverhealTriggerValue = 8f;

	private float OverhealDelay = 100f;

	private float RetaliationDelay = 1500f;

	private Timer _invulTimer;

	private bool _canInvul;

	private float invulDelay = 500f;

	private PhaserSprite _guardianSprite1;

	private PhaserSprite _guardianSprite2;

	private PhaserSprite _guardianSprite3;

	private PhaserSprite _guardianSprite4;

	private MultiTargetTween _guardianTween1;

	private MultiTargetTween _guardianTween2;

	private MultiTargetTween _guardianTween3;

	private MultiTargetTween _guardianTween4;

	private MultiTargetTween _guardianTween5;

	public int SlotNumber = 1;

	protected virtual bool hasInvulnerabilityBonus => false;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		Action<GameplaySignals.CharacterLostShieldSignal> action = null;
		((TP_SacredBeasts1_Weapon)(object)action).OnPlayerHitShield((GameplaySignals.CharacterLostShieldSignal)this);
		((TP_SacredBeasts1_Weapon)(object)_signalBus).OnPlayerHitShield((GameplaySignals.CharacterLostShieldSignal)action);
		Action<GameplaySignals.CharacterReceivedDamageSignal> action2 = null;
		((TP_SacredBeasts1_Weapon)(object)action2).OnPlayerHitDamage((GameplaySignals.CharacterReceivedDamageSignal)this);
		((TP_SacredBeasts1_Weapon)(object)_signalBus).OnPlayerHitDamage((GameplaySignals.CharacterReceivedDamageSignal)action2);
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		_canRetaliate = true;
		_canInvul = true;
		Action<float, float> b = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAE6B0");
		Delegate obj = Delegate.Combine(characterController2._onHpRecoveryCallback, b);
		Action<float, float> action3 = default(Action<float, float>);
		if ((object)obj == null)
		{
			action3 = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			if (action3 == null)
			{
				throw new InvalidCastException();
			}
		}
		characterController2._onHpRecoveryCallback = action3;
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Guardians_01");
		PhaserSprite phaserSprite2 = phaserSprite.setAlpha(0f);
		PhaserSprite phaserSprite3 = phaserSprite2.setDepth(3000);
		PhaserSprite guardianSprite = phaserSprite3.setBlendMode(BlendMode.Normal);
		_guardianSprite1 = guardianSprite;
		GameObject gameObject2 = base.gameObject;
		PhaserSprite phaserSprite4 = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "ThosePeople", "TP_VFX_Guardians_02");
		PhaserSprite phaserSprite5 = phaserSprite4.setAlpha(0f);
		PhaserSprite phaserSprite6 = phaserSprite5.setDepth(3000);
		PhaserSprite guardianSprite2 = phaserSprite6.setBlendMode(BlendMode.Normal);
		_guardianSprite2 = guardianSprite2;
		GameObject gameObject3 = base.gameObject;
		PhaserSprite phaserSprite7 = RenderingExtensions.AddPhaserSprite(gameObject3, pos, "ThosePeople", "TP_VFX_Guardians_03");
		PhaserSprite phaserSprite8 = phaserSprite7.setAlpha(0f);
		PhaserSprite phaserSprite9 = phaserSprite8.setDepth(3000);
		PhaserSprite guardianSprite3 = phaserSprite9.setBlendMode(BlendMode.Normal);
		_guardianSprite3 = guardianSprite3;
		GameObject gameObject4 = base.gameObject;
		PhaserSprite phaserSprite10 = RenderingExtensions.AddPhaserSprite(gameObject4, pos, "ThosePeople", "TP_VFX_Guardians_04");
		PhaserSprite phaserSprite11 = phaserSprite10.setAlpha(0f);
		PhaserSprite phaserSprite12 = phaserSprite11.setDepth(3000);
		PhaserSprite guardianSprite4 = phaserSprite12.setBlendMode(BlendMode.Normal);
		_guardianSprite4 = guardianSprite4;
		VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)this)._003COwner_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BCD0");
		VampireSurvivors.Objects.Characters.CharacterController characterController4 = ((Equipment)this)._003COwner_003Ek__BackingField;
		List<Weapon> heldShieldSlots = characterController4.HeldShieldSlots;
		SlotNumber = heldShieldSlots._size;
	}

	private void OnHpRecoveryCallback(float value, float rawValue)
	{
		//IL_0067: Expected O, but got I
		//IL_026a: Invalid comparison between F4 and I
		//IL_0291: Expected F4, but got I
		float num = rawValue - value;
		if (!(num > OverhealTriggerValue) || !_canOverheal)
		{
			return;
		}
		BulletPool projectilePool = _projectilePool;
		ObjectPool pool = projectilePool._pool;
		Dictionary<int, GameObject> aliveObjects = pool._aliveObjects;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rcx_v5 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+20]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rcx_v5 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+28]");
		object obj = num2 - 0;
		if ((nint)obj <= 0)
		{
			return;
		}
		_canOverheal = false;
		if (_overHealTimer != null)
		{
			_overHealTimer.Cancel();
		}
		Action onComplete = delegate
		{
			_canOverheal = true;
		};
		float duration = OverhealDelay * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer overHealTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_overHealTimer = overHealTimer;
		FireProjectiles(_standardPool);
		if (hasInvulnerabilityBonus && !(rawValue < 32f) && _canInvul)
		{
			_canInvul = false;
			if (_invulTimer != null)
			{
				_invulTimer.Cancel();
			}
			Action onComplete2 = delegate
			{
				_canInvul = true;
			};
			float duration2 = invulDelay * 0.001f;
			Timer invulTimer = Timers.Register(duration2, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_invulTimer = invulTimer;
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
			float num3 = 5000f - characterController._invincibilityTimer;
			float num4 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10FB4]");
			if (num4 < 0f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10FB4]");
				num3 = 0f;
			}
			PlayInvulAnimation(num3);
			((Equipment)this)._003COwner_003Ek__BackingField.SetInvulForMilliSeconds(num3);
		}
	}

	private void PlayInvulAnimation(float duration)
	{
		//IL_019c: Expected I, but got O
		//IL_020f: Expected O, but got I4
		//IL_021d: Expected O, but got I4
		//IL_02f5: Expected I, but got O
		//IL_035b: Expected O, but got I4
		//IL_0383: Expected O, but got I4
		//IL_045b: Expected I, but got O
		//IL_04d0: Expected O, but got I4
		//IL_04f8: Expected O, but got I4
		//IL_05d0: Expected I, but got O
		//IL_0646: Expected O, but got I4
		//IL_066e: Expected O, but got I4
		//IL_0746: Expected I, but got O
		//IL_079a: Expected I, but got O
		//IL_07ee: Expected I, but got O
		//IL_0842: Expected I, but got O
		//IL_08d2: Expected O, but got I4
		//IL_09a6->IL08f4: Incompatible stack heights: 1 vs 0
		//IL_00b4->IL08f4: Incompatible stack heights: 1 vs 0
		//IL_09f5->IL08f4: Incompatible stack heights: 2 vs 0
		//IL_00ea->IL08f4: Incompatible stack heights: 2 vs 0
		//IL_0a44->IL08f4: Incompatible stack heights: 3 vs 0
		//IL_0120->IL08f4: Incompatible stack heights: 3 vs 0
		//IL_01bf->IL01bf: Incompatible stack heights: 6 vs 5
		//IL_0318->IL0318: Incompatible stack heights: 8 vs 7
		//IL_047e->IL047e: Incompatible stack heights: 10 vs 9
		//IL_05f3->IL05f3: Incompatible stack heights: 12 vs 11
		//IL_0769->IL0769: Incompatible stack heights: 14 vs 13
		//IL_07bd->IL07bd: Incompatible stack heights: 14 vs 13
		//IL_0811->IL0811: Incompatible stack heights: 14 vs 13
		//IL_0865->IL0865: Incompatible stack heights: 14 vs 13
		_003C_003Ec__DisplayClass26_0 CS_0024_003C_003E8__locals16 = new _003C_003Ec__DisplayClass26_0();
		if (CS_0024_003C_003E8__locals16 != null)
		{
			CS_0024_003C_003E8__locals16._003C_003E4__this = this;
			float num = duration * 0.25f;
			bool flag = num > 350f;
			float num2 = 350f;
			if (!flag)
			{
				num2 = num;
			}
			CS_0024_003C_003E8__locals16.scaleStart = 4f;
			CS_0024_003C_003E8__locals16.alphaStart = 0.65f;
			if ((object)_guardianSprite2 != null)
			{
				Transform transform = _guardianSprite2.transform;
				if ((object)transform != null)
				{
					bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					if ((object)_guardianSprite1 != null)
					{
						Transform transform2 = _guardianSprite1.transform;
						if ((object)transform2 != null)
						{
							bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							Vector3 value2 = default(Vector3);
							Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
							if ((object)_guardianSprite4 != null)
							{
								Transform transform3 = _guardianSprite4.transform;
								if ((object)transform3 != null)
								{
									bool flag4 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
									Vector3 value3 = default(Vector3);
									Transform.set_localPosition_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value3);
									if ((object)_guardianSprite3 != null)
									{
										Transform transform4 = _guardianSprite3.transform;
										if ((object)transform4 != null)
										{
											bool flag5 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
											Vector3 value4 = default(Vector3);
											Transform.set_localPosition_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref value4);
											if (_guardianTween2 != null)
											{
												_guardianTween2.Kill();
											}
											TweenConfig tweenConfig = new TweenConfig();
											object[] array = new object[1];
											bool flag6 = array == null;
											if ((object)_guardianSprite2 != null)
											{
												nint num3 = (nint)array;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
												object obj = default(object);
												bool flag7 = obj == null;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											bool flag8 = tweenConfig == null;
											tweenConfig.targets = array;
											tweenConfig.duration = num2;
											tweenConfig.scale = (float?)(object)1;
											tweenConfig.alpha = (float?)(object)1;
											TweenCallback onStart = delegate
											{
												//IL_0040: Expected O, but got I4
												TP_SacredBeasts1_Weapon tP_SacredBeasts1_Weapon = CS_0024_003C_003E8__locals16._003C_003E4__this;
												PhaserSprite phaserSprite = tP_SacredBeasts1_Weapon._guardianSprite2.setAlpha(CS_0024_003C_003E8__locals16.alphaStart);
												PhaserSprite phaserSprite2 = phaserSprite.setScale(CS_0024_003C_003E8__locals16.scaleStart, (float?)(object)0);
											};
											tweenConfig.onStart = onStart;
											MultiTargetTween guardianTween = Tweens.Add(tweenConfig);
											_guardianTween2 = guardianTween;
											if (_guardianTween1 != null)
											{
												_guardianTween1.Kill();
											}
											TweenConfig tweenConfig2 = new TweenConfig();
											object[] array2 = new object[1];
											bool flag9 = array2 == null;
											if ((object)_guardianSprite1 != null)
											{
												nint num4 = (nint)array2;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
												object obj2 = default(object);
												bool flag10 = obj2 == null;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											bool flag11 = tweenConfig2 == null;
											tweenConfig2.targets = array2;
											tweenConfig2.scale = (float?)(object)1;
											tweenConfig2.duration = num2;
											tweenConfig2.delay = num2;
											tweenConfig2.alpha = (float?)(object)1;
											TweenCallback onStart2 = delegate
											{
												//IL_0040: Expected O, but got I4
												TP_SacredBeasts1_Weapon tP_SacredBeasts1_Weapon = CS_0024_003C_003E8__locals16._003C_003E4__this;
												PhaserSprite phaserSprite = tP_SacredBeasts1_Weapon._guardianSprite1.setAlpha(CS_0024_003C_003E8__locals16.alphaStart);
												PhaserSprite phaserSprite2 = phaserSprite.setScale(CS_0024_003C_003E8__locals16.scaleStart, (float?)(object)0);
											};
											tweenConfig2.onStart = onStart2;
											MultiTargetTween guardianTween2 = Tweens.Add(tweenConfig2);
											_guardianTween1 = guardianTween2;
											if (_guardianTween4 != null)
											{
												_guardianTween4.Kill();
											}
											TweenConfig tweenConfig3 = new TweenConfig();
											object[] array3 = new object[1];
											bool flag12 = array3 == null;
											if ((object)_guardianSprite4 != null)
											{
												nint num5 = (nint)array3;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
												object obj3 = default(object);
												bool flag13 = obj3 == null;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											bool flag14 = tweenConfig3 == null;
											tweenConfig3.targets = array3;
											float delay = num2 + num2;
											tweenConfig3.scale = (float?)(object)1;
											tweenConfig3.duration = num2;
											tweenConfig3.delay = delay;
											tweenConfig3.alpha = (float?)(object)1;
											TweenCallback onStart3 = delegate
											{
												//IL_0040: Expected O, but got I4
												TP_SacredBeasts1_Weapon tP_SacredBeasts1_Weapon = CS_0024_003C_003E8__locals16._003C_003E4__this;
												PhaserSprite phaserSprite = tP_SacredBeasts1_Weapon._guardianSprite4.setAlpha(CS_0024_003C_003E8__locals16.alphaStart);
												PhaserSprite phaserSprite2 = phaserSprite.setScale(CS_0024_003C_003E8__locals16.scaleStart, (float?)(object)0);
											};
											tweenConfig3.onStart = onStart3;
											MultiTargetTween guardianTween3 = Tweens.Add(tweenConfig3);
											_guardianTween4 = guardianTween3;
											if (_guardianTween3 != null)
											{
												_guardianTween3.Kill();
											}
											TweenConfig tweenConfig4 = new TweenConfig();
											object[] array4 = new object[1];
											bool flag15 = array4 == null;
											if ((object)_guardianSprite3 != null)
											{
												nint num6 = (nint)array4;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
												object obj4 = default(object);
												bool flag16 = obj4 == null;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											bool flag17 = tweenConfig4 == null;
											tweenConfig4.targets = array4;
											float delay2 = num2 * 3f;
											tweenConfig4.scale = (float?)(object)1;
											tweenConfig4.duration = num2;
											tweenConfig4.delay = delay2;
											tweenConfig4.alpha = (float?)(object)1;
											TweenCallback onStart4 = delegate
											{
												//IL_0040: Expected O, but got I4
												TP_SacredBeasts1_Weapon tP_SacredBeasts1_Weapon = CS_0024_003C_003E8__locals16._003C_003E4__this;
												PhaserSprite phaserSprite = tP_SacredBeasts1_Weapon._guardianSprite3.setAlpha(CS_0024_003C_003E8__locals16.alphaStart);
												PhaserSprite phaserSprite2 = phaserSprite.setScale(CS_0024_003C_003E8__locals16.scaleStart, (float?)(object)0);
											};
											tweenConfig4.onStart = onStart4;
											MultiTargetTween guardianTween4 = Tweens.Add(tweenConfig4);
											_guardianTween3 = guardianTween4;
											if (_guardianTween5 != null)
											{
												_guardianTween5.Kill();
											}
											TweenConfig tweenConfig5 = new TweenConfig();
											object[] array5 = new object[4];
											bool flag18 = array5 == null;
											if ((object)_guardianSprite1 != null)
											{
												nint num7 = (nint)array5;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
												object obj5 = default(object);
												bool flag19 = obj5 == null;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											if ((object)_guardianSprite2 != null)
											{
												nint num8 = (nint)array5;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
												object obj6 = default(object);
												bool flag20 = obj6 == null;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											if ((object)_guardianSprite3 != null)
											{
												nint num9 = (nint)array5;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
												object obj7 = default(object);
												bool flag21 = obj7 == null;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											if ((object)_guardianSprite4 != null)
											{
												nint num10 = (nint)array5;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
												object obj8 = default(object);
												bool flag22 = obj8 == null;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											bool flag23 = tweenConfig5 == null;
											tweenConfig5.targets = array5;
											tweenConfig5.duration = num2;
											float delay3 = num2 * 4f;
											tweenConfig5.delay = delay3;
											tweenConfig5.alpha = (float?)(object)1;
											MultiTargetTween guardianTween5 = Tweens.Add(tweenConfig5);
											_guardianTween5 = guardianTween5;
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
		throw new NullReferenceException();
	}

	private void OnPlayerHit()
	{
		//IL_0048: Expected O, but got I
		if (!_canRetaliate)
		{
			return;
		}
		BulletPool projectilePool = _projectilePool;
		ObjectPool pool = projectilePool._pool;
		Dictionary<int, GameObject> aliveObjects = pool._aliveObjects;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rcx_v5 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+20]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rcx_v5 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+28]");
		object obj = num - 0;
		if ((nint)obj > 0)
		{
			_canRetaliate = false;
			if (_retaliationTimer != null)
			{
				_retaliationTimer.Cancel();
			}
			Action onComplete = delegate
			{
				_canRetaliate = true;
			};
			float duration = RetaliationDelay * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer retaliationTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_retaliationTimer = retaliationTimer;
			FireProjectiles(_retaliationPool);
		}
	}

	public override void Cleanup()
	{
		base.Cleanup();
		_retaliationPool.Cleanup();
		_standardPool.Cleanup();
		if (_signalBus != null)
		{
			Action<GameplaySignals.CharacterLostShieldSignal> action = null;
			((TP_SacredBeasts1_Weapon)(object)action).OnPlayerHitShield((GameplaySignals.CharacterLostShieldSignal)this);
			((TP_SacredBeasts1_Weapon)(object)_signalBus).OnPlayerHitShield((GameplaySignals.CharacterLostShieldSignal)action);
		}
		if (_signalBus != null)
		{
			Action<GameplaySignals.CharacterReceivedDamageSignal> action2 = null;
			((TP_SacredBeasts1_Weapon)(object)action2).OnPlayerHitDamage((GameplaySignals.CharacterReceivedDamageSignal)this);
			((TP_SacredBeasts1_Weapon)(object)_signalBus).OnPlayerHitDamage((GameplaySignals.CharacterReceivedDamageSignal)action2);
		}
		if (_lastShotTimer != null)
		{
			_lastShotTimer.Cancel();
		}
		if (_retaliationTimer != null)
		{
			_retaliationTimer.Cancel();
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		bool flag = ((List<object>)(object)characterController.HeldShieldSlots).Remove((object)this);
	}

	protected override void OnStart()
	{
		//IL_00b0: Expected I, but got O
		//IL_0246: Expected I, but got O
		//IL_0141: Expected I, but got O
		//IL_02d7: Expected I, but got O
		base.OnStart();
		if (_retaliationPool != null)
		{
			goto IL_0179;
		}
		Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.TP_SACREDBEASTS1_BIRD);
		BulletPool retaliationPool = new BulletPool(projectilePrefab);
		_retaliationPool = retaliationPool;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			PhysicsManager physicsManager = core._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v725 @ r8_v20 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SacredBeasts1_Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider = physics.add.overlap(_retaliationPool, physicsManager._destructiblesGroup, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				ArcadePhysics physics2 = s_scene2.physics;
				GameManager core2 = GM.Core;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v771 @ r8_v23 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SacredBeasts1_Weapon>)+390]");
				ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num2 = (nint)this;
				Collider collider2 = physics2.add.overlap(_retaliationPool, core2.Enemies, collideCallback2, processCallback, callbackContext);
				goto IL_0179;
			}
		}
		goto IL_0310;
		IL_0310:
		throw new NullReferenceException();
		IL_0179:
		if (_standardPool != null)
		{
			return;
		}
		Projectile projectilePrefab2 = _projectileFactory.GetProjectilePrefab(WeaponType.TP_SACREDBEASTS1_BIRD);
		BulletPool standardPool = new BulletPool(projectilePrefab2);
		_standardPool = standardPool;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene3 = ArcadePhysics.s_scene;
			ArcadePhysics physics3 = s_scene3.physics;
			GameManager core3 = GM.Core;
			PhysicsManager physicsManager2 = core3._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v728 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SacredBeasts1_Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback3 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num3 = (nint)this;
			Collider collider3 = physics3.add.overlap(_standardPool, physicsManager2._destructiblesGroup, collideCallback3, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene4 = ArcadePhysics.s_scene;
				ArcadePhysics physics4 = s_scene4.physics;
				GameManager core4 = GM.Core;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v774 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SacredBeasts1_Weapon>)+350]");
				ArcadePhysicsCallback collideCallback4 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num4 = (nint)this;
				Collider collider4 = physics4.add.overlap(_standardPool, core4.Enemies, collideCallback4, processCallback, callbackContext);
				return;
			}
		}
		goto IL_0310;
	}

	private void OnPlayerHitDamage(GameplaySignals.CharacterReceivedDamageSignal signal)
	{
		//IL_00fa: Expected O, but got I4
		//IL_0114: Expected O, but got I4
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		bool flag = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
		bool flag2 = (object)signal == null;
		object obj = flag2 & flag;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		if (obj2 == null)
		{
			bool flag4;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				if ((object)signal != null)
				{
					object obj3 = (object)signal - (object)((Equipment)this)._003COwner_003Ek__BackingField;
					flag4 = obj3 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [signal @ rdx (VampireSurvivors.Signals.GameplaySignals+CharacterReceivedDamageSignal)+10]");
				flag4 = (nint)0 == 0;
			}
			if (!flag4)
			{
				return;
			}
		}
		OnPlayerHit();
	}

	private void OnPlayerHitShield(GameplaySignals.CharacterLostShieldSignal signal)
	{
		//IL_0113: Expected O, but got I4
		//IL_012d: Expected O, but got I4
		VampireSurvivors.Objects.Characters.CharacterController character = signal.Character;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		bool flag = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
		bool flag2 = (object)signal.Character == null;
		object obj = flag2 & flag;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		if (obj2 == null)
		{
			bool flag4;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				if ((object)signal.Character != null)
				{
					object obj3 = (object)signal.Character - (object)((Equipment)this)._003COwner_003Ek__BackingField;
					flag4 = obj3 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				flag4 = ((UnityEngine.Object)character).m_CachedPtr == (IntPtr)0;
			}
			if (!flag4)
			{
				return;
			}
		}
		OnPlayerHit();
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_0067: Invalid comparison between O and F4
		//IL_0092: Expected F4, but got O
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
	}

	public void FireStandardProjectiles()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 2 Invalid \"Jump target not found in method: 0x187460C90\"");
	}

	public void FireProjectiles(BulletPool pool)
	{
		//IL_00f6: Invalid comparison between F4 and I4
		_003C_003Ec__DisplayClass34_0 obj = new _003C_003Ec__DisplayClass34_0();
		obj._003C_003E4__this = this;
		obj.pool = pool;
		if (obj.pool == null)
		{
			obj.pool = _standardPool;
		}
		float num = base.PAmount();
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		WeaponData currentWeaponData = _currentWeaponData;
		object obj2 = default(object);
		if ((nint)obj2 <= 0)
		{
			return;
		}
		bool flag = false;
		object obj3 = default(object);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			_003C_003Ec__DisplayClass34_1 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass34_1();
			CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1 = obj;
			CS_0024_003C_003E8__locals8.localIndex = (flag ? 1 : 0);
			float num2 = (float)obj3 + 0.02f;
			CS_0024_003C_003E8__locals8.__pos = position;
			float num3 = (float)(flag ? 1 : 0) * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
			if (!(num3 > 0f))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
			}
			else
			{
				Action onComplete = delegate
				{
					//IL_0160: Expected O, but got I4
					//IL_00a8->IL0129: Incompatible stack heights: 1 vs 0
					//IL_00d7->IL0129: Incompatible stack heights: 1 vs 0
					//IL_00f9->IL0129: Incompatible stack heights: 1 vs 0
					_003C_003Ec__DisplayClass34_0 obj4 = CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1 != null && (object)obj4._003C_003E4__this != null)
					{
						GameObject gameObject = obj4._003C_003E4__this.gameObject;
						if ((object)gameObject != null)
						{
							bool flag2 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
							object obj5 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
							if (obj5 == null)
							{
								return;
							}
							_003C_003Ec__DisplayClass34_0 obj6 = CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1 != null)
							{
								TP_SacredBeasts1_Weapon tP_SacredBeasts1_Weapon = obj6._003C_003E4__this;
								if ((object)obj6._003C_003E4__this != null && (object)obj6._003C_003E4__this != null)
								{
									Vector2 pos = default(Vector2);
									Projectile projectile = obj6._003C_003E4__this.FireOneProjectile(pos, CS_0024_003C_003E8__locals8.localIndex, tP_SacredBeasts1_Weapon._targetTransform);
									return;
								}
							}
						}
					}
					throw new NullReferenceException();
				};
				float num4 = (float)(flag ? 1 : 0) * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
				float duration = num4 * 0.001f;
				Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_lastShotTimer = lastShotTimer;
			}
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
		}
		while ((nint)obj2 > (flag ? 1 : 0));
	}

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		PhaserSprite phaserSprite = _guardianSprite1.setVisible(visible);
		PhaserSprite phaserSprite2 = _guardianSprite2.setVisible(visible);
		PhaserSprite phaserSprite3 = _guardianSprite3.setVisible(visible);
		PhaserSprite phaserSprite4 = _guardianSprite4.setVisible(visible);
	}

	private void _003COnHpRecoveryCallback_003Eb__25_0()
	{
		_canOverheal = true;
	}

	private void _003COnHpRecoveryCallback_003Eb__25_1()
	{
		_canInvul = true;
	}

	private void _003COnPlayerHit_003Eb__27_0()
	{
		_canRetaliate = true;
	}
}
