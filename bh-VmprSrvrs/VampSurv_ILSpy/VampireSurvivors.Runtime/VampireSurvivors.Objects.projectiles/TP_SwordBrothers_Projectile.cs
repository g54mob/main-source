using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_SwordBrothers_Projectile : Projectile
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__13_4;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CInitProjectile_003Eb__13_4()
		{
		}
	}

	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public float angleUnit;

		public TP_SwordBrothers_Projectile _003C_003E4__this;
	}

	private sealed class _003C_003Ec__DisplayClass14_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals1;

		internal void _003CEmitBullets_003Eb__0()
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Expected O, but got Unknown
			//IL_010a: Expected I, but got O
			//IL_0118: Expected I, but got O
			//IL_0128: Expected O, but got I
			//IL_01a8: Expected O, but got I4
			//IL_0164: Expected O, but got I
			//IL_019a: Expected O, but got I4
			//IL_021e: Expected O, but got I
			//IL_0318: Expected O, but got I4
			_003C_003Ec__DisplayClass14_0 obj = CS_0024_003C_003E8__locals1;
			object obj2 = localIndex * obj.angleUnit;
			float angle = (float)obj2 - 180f;
			obj._003C_003E4__this.angle = angle;
			_003C_003Ec__DisplayClass14_0 obj3 = CS_0024_003C_003E8__locals1;
			TP_SwordBrothers_Projectile tP_SwordBrothers_Projectile = obj3._003C_003E4__this;
			tP_SwordBrothers_Projectile._displaySprite.angle = angle;
			_003C_003Ec__DisplayClass14_0 obj4 = CS_0024_003C_003E8__locals1;
			TP_SwordBrothers_Projectile tP_SwordBrothers_Projectile2 = obj4._003C_003E4__this;
			TP_SwordBrothers_Weapon trueWeapon = tP_SwordBrothers_Projectile2._trueWeapon;
			float2 position = ((Equipment)trueWeapon)._003COwner_003Ek__BackingField.position;
			Vector2 pos = default(Vector2);
			ArcadeSprite arcadeSprite = trueWeapon.FireOneProjectile(pos, 0);
			object item;
			float num2 = default(float);
			float num;
			if ((object)arcadeSprite == null)
			{
				item = null;
				num = num2;
				goto IL_0238;
			}
			nint num3 = (nint)arcadeSprite;
			nint num4 = (nint)typeof(TP_SwordBrothers_Firing_Projectile);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SwordBrothers_Firing_Projectile>)+130]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ r8_v11 (Il2CppClass<ArcadeSprite>)+130]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SwordBrothers_Firing_Projectile>)+130]");
			object obj7;
			if (num5 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ r8_v11 (Il2CppClass<ArcadeSprite>)+C8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v448 @ rax_v33+FFFFFFF8+v409 @ rax_v24*8]");
				if (0 == (nint)typeof(TP_SwordBrothers_Firing_Projectile))
				{
					obj7 = 1;
					goto IL_0369;
				}
			}
			obj7 = 0;
			goto IL_0369;
			IL_0238:
			_003C_003Ec__DisplayClass14_0 obj8 = CS_0024_003C_003E8__locals1;
			TP_SwordBrothers_Projectile tP_SwordBrothers_Projectile3 = obj8._003C_003E4__this;
			List<object> bullets = (List<object>)(object)tP_SwordBrothers_Projectile3.bullets;
			int version = bullets._version + 1;
			bullets._version = version;
			object[] items = bullets._items;
			if (bullets._size >= items.Length)
			{
				bullets.AddWithResize(item);
			}
			else
			{
				int size = bullets._size + 1;
				bullets._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			soundConfig.Detune = 1f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_SwordSimple, soundConfig, 50f, 1, time);
			return;
			IL_0369:
			bool flag = obj7 == null;
			ArcadeSprite arcadeSprite2 = null;
			if (!flag)
			{
				arcadeSprite2 = arcadeSprite;
			}
			bool flag2 = (object)arcadeSprite2 == null;
			item = arcadeSprite2;
			num = num2;
			if (!flag2)
			{
				_003C_003Ec__DisplayClass14_0 obj9 = CS_0024_003C_003E8__locals1;
				Transform cachedTrans = ((ArcadeSprite)obj9._003C_003E4__this).CachedTrans;
				Vector3 localEulerAngles = cachedTrans.localEulerAngles;
				arcadeSprite2.angle = localEulerAngles.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rbx_v9 (ArcadeSprite)+E0]");
				((PhaserSprite)0).angle = localEulerAngles.z;
				item = arcadeSprite2;
				num = localEulerAngles.z;
			}
			goto IL_0238;
		}
	}

	private MultiTargetTween _scaleTween;

	private float2 displayOffset;

	private MultiTargetTween _angleTween;

	private Sequence _windSequence;

	private TP_SwordBrothers_Weapon _trueWeapon;

	private List<TP_SwordBrothers_Firing_Projectile> bullets;

	private MultiTargetTween _alphaTween;

	private PhaserSprite _displaySprite;

	private float2 positionOffset;

	private float physOffsetRadius = 0.4f;

	private List<Timer> _bulletTimers;

	private Timer _shootTimer;

	protected override void Awake()
	{
		//IL_00cf: Expected O, but got I4
		//IL_01b8->IL0151: Incompatible stack heights: 1 vs 0
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		if ((object)_renderer != null)
		{
			_renderer.sprite = sprite;
			if ((object)_renderer != null)
			{
				_renderer.enabled = false;
				GameObject gameObject = base.gameObject;
				Vector2 pos = default(Vector2);
				PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Brothers01");
				if ((object)phaserSprite != null)
				{
					PhaserSprite displaySprite = phaserSprite.setOrigin(0.5f, (float?)(object)1);
					_displaySprite = displaySprite;
					if ((object)_displaySprite != null)
					{
						Transform transform = _displaySprite.transform;
						if ((object)transform != null)
						{
							bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Transform.SetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr, (IntPtr)0, true);
							if ((object)_displaySprite != null)
							{
								PhaserSprite phaserSprite2 = _displaySprite.setVisible(visible: false);
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_000e: Expected O, but got I4
		//IL_071a: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_00f6: Expected O, but got I4
		//IL_00f6: Expected O, but got I4
		//IL_010a: Expected O, but got I4
		//IL_0161: Expected O, but got I4
		//IL_01c4: Expected O, but got I4
		//IL_0236: Expected O, but got F4
		//IL_0275: Expected O, but got I4
		//IL_041b: Expected O, but got I4
		//IL_045b: Expected O, but got I4
		//IL_05db: Expected O, but got Ref
		base.InitProjectile(pool, weapon, index);
		float? trueWeapon;
		if ((object)weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_06f3;
		}
		nint num = (nint)typeof(TP_SwordBrothers_Weapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rdx_v60 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SwordBrothers_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ r8_v70 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rdx_v60 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SwordBrothers_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ r8_v70 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rax_v136+FFFFFFF8+v73 @ rax_v131*8]");
			if (0 == (nint)typeof(TP_SwordBrothers_Weapon))
			{
				obj3 = 1;
				goto IL_0702;
			}
		}
		obj3 = 0;
		goto IL_0702;
		IL_0702:
		bool flag = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)weapon;
		}
		goto IL_06f3;
		IL_06f3:
		_trueWeapon = (TP_SwordBrothers_Weapon)trueWeapon;
		_isCullable = false;
		BaseBody baseBody = body.setCircle(50f, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		physOffsetRadius = 0.8f;
		PhaserSprite phaserSprite = _displaySprite.setVisible(visible: true);
		_displaySprite.angle = 0f;
		PhaserSprite phaserSprite2 = _displaySprite.setScale(2f, (float?)(object)0);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			Weapon weapon2 = _weapon;
			float num4 = renderer.height + 1f;
			displayOffset = (float2)0;
			float2 float5 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			float num5 = -(float)Math.PI / 2f * physOffsetRadius;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			float num6 = -(float)Math.PI / 2f * physOffsetRadius;
			positionOffset = (float2)num5;
			float2 float6 = _displaySprite.position;
			float2 endValue = default(float2);
			base.position = endValue;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_SwordBrothers1, soundConfig, 200f, 2, time);
			Tween windSequence = _windSequence;
			if (_windSequence != null && windSequence._003Cactive_003Ek__BackingField)
			{
				TweenExtensions.Kill(_windSequence);
			}
			Sequence sequence = DOTween.Sequence();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			sequence.stringId = "DefaultGameTweenId";
			_windSequence = sequence;
			Sequence windSequence2 = _windSequence;
			DOGetter<Vector2> getter = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DFF0");
			DOSetter<Vector2> dOSetter = null;
			((TP_SwordBrothers_Projectile)(object)dOSetter)._003CInitProjectile_003Eb__13_1((Vector2)this);
			TweenerCore<Vector2, Vector2, VectorOptions> t = DOTween.To(getter, dOSetter, endValue, 0.5f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			bool flag2 = TweenSettingsExtensions.ValidateAddToSequence(_windSequence, (Tween)t, false);
			bool flag3 = !flag2;
			float num7 = 200f;
			object obj4 = 0;
			if (!flag3)
			{
				num7 = ((Tween)windSequence2).duration;
				Sequence sequence2 = Sequence.DoInsert(_windSequence, (Tween)t, ((Tween)windSequence2).duration);
				obj4 = 0;
			}
			Sequence windSequence3 = _windSequence;
			DOGetter<Vector3> dOGetter = null;
			Vector3 vector = _003CInitProjectile_003Eb__13_2();
			DOSetter<Vector3> dOSetter2 = null;
			((TP_SwordBrothers_Projectile)(object)dOSetter2)._003CInitProjectile_003Eb__13_3((Vector3)this);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D900");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			Tween tween = default(Tween);
			tween.stringId = "DefaultGameTweenId";
			Tween tween2 = TweenSettingsExtensions.SetDelay(tween, 0.2f);
			TweenCallback onComplete = _003C_003Ec._003C_003E9__13_4;
			if (_003C_003Ec._003C_003E9__13_4 == null)
			{
				onComplete = (_003C_003Ec._003C_003E9__13_4 = delegate
				{
				});
			}
			if (tween2 != null && tween2._003Cactive_003Ek__BackingField)
			{
				tween2.onComplete = onComplete;
			}
			if (TweenSettingsExtensions.ValidateAddToSequence(_windSequence, tween2, false))
			{
				Sequence sequence3 = Sequence.DoInsert(_windSequence, tween2, ((Tween)windSequence3).duration);
			}
			Sequence windSequence4 = _windSequence;
			Transform target = _displaySprite.transform;
			Vector3 vector2 = default(Vector3);
			TweenerCore<Quaternion, Vector3, QuaternionOptions> t2 = ShortcutExtensions.DOLocalRotate(target, (Vector3)(&vector2), 0.5f, RotateMode.FastBeyond360);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			TweenCallback tweenCallback = delegate
			{
				EmitBullets();
			};
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1498 @ rax_v62 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
			}
			if (TweenSettingsExtensions.ValidateAddToSequence(_windSequence, (Tween)t2, false))
			{
				Sequence sequence4 = Sequence.DoInsert(_windSequence, (Tween)t2, windSequence4.lastTweenInsertTime);
			}
			return;
		}
		throw new NullReferenceException();
	}

	public unsafe void EmitBullets()
	{
		//IL_01f2: Expected O, but got I4
		//IL_026d: Expected I, but got O
		//IL_0283: Expected O, but got I
		//IL_028c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Expected O, but got Unknown
		//IL_02fa: Expected I, but got O
		//IL_04ff: Expected I, but got I8
		//IL_02e3: Expected I, but got I8
		//IL_0418: Expected I, but got O
		//IL_042e: Expected O, but got I
		//IL_0437: Unknown result type (might be due to invalid IL or missing references)
		//IL_043c: Expected O, but got Unknown
		//IL_04aa: Expected I, but got O
		//IL_0594: Expected I, but got I8
		//IL_047d: Expected I, but got I8
		_003C_003Ec__DisplayClass14_0 obj = new _003C_003Ec__DisplayClass14_0();
		obj._003C_003E4__this = this;
		obj.angleUnit = -5.625f;
		List<TP_SwordBrothers_Firing_Projectile> list = bullets;
		if (bullets != null)
		{
			int version = list._version + 1;
			list._version = version;
			list._size = 0;
			if (list._size > 0)
			{
				Array.Clear(list._items, 0, list._size);
			}
		}
		List<TP_SwordBrothers_Firing_Projectile> list2 = new List<TP_SwordBrothers_Firing_Projectile>();
		bullets = list2;
		if (_bulletTimers != null)
		{
			List<Timer> bulletTimers = _bulletTimers;
			bool flag = false;
			bool flag2 = false;
			while ((flag2 ? 1 : 0) < bulletTimers._size)
			{
				List<Timer> bulletTimers2 = _bulletTimers;
				if ((flag ? 1 : 0) < bulletTimers2._size)
				{
					Timer[] items = bulletTimers2._items;
					if (items[flag ? 1u : 0u] != null)
					{
						items[flag ? 1u : 0u].Cancel();
					}
					bulletTimers = _bulletTimers;
					flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
					flag2 = flag;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
		}
		List<Timer> bulletTimers3 = new List<Timer>();
		_bulletTimers = bulletTimers3;
		object obj2 = 24;
		bool flag3 = false;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			_003C_003Ec__DisplayClass14_1 obj3 = new _003C_003Ec__DisplayClass14_1();
			obj3.CS_0024_003C_003E8__locals1 = obj;
			obj3.localIndex = (flag3 ? 1 : 0);
			Action action = null;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v838 @ r10_v5 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass14_1._003CEmitBullets_003Eb__0);
			((Delegate)action).m_target = obj3;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v838 @ r10_v5 (Il2CppMethodInfo)+4C]");
			object obj4 = (nint)0 >> 4;
			object obj5 = obj4 & 1;
			nint num2;
			if (obj5 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v838 @ r10_v5 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num2 = unchecked((nint)6447293664L);
					goto IL_04e8;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num2 = ((Delegate)action).method_ptr;
			goto IL_04e8;
			IL_04e8:
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			float num3 = (float)(flag3 ? 1 : 0) * 15.625f;
			float num4 = num3 + 1f;
			float duration = num4 * 0.001f;
			Timer item = Timers.Register(duration, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			List<object> bulletTimers4 = (List<object>)(object)_bulletTimers;
			int version2 = bulletTimers4._version + 1;
			bulletTimers4._version = version2;
			object[] items2 = bulletTimers4._items;
			if (bulletTimers4._size >= items2.Length)
			{
				bulletTimers4.AddWithResize((object)item);
			}
			else
			{
				int num5 = bulletTimers4._size + 1;
				bulletTimers4._size = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			flag3 = (byte)((flag3 ? 1u : 0u) + 1u) != 0;
		}
		while ((flag3 ? 1 : 0) < 65);
		Action action2 = null;
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v572 @ r10_v7 (Il2CppMethodInfo)+8]");
		((Delegate)action2).method_ptr = (IntPtr)0;
		((Delegate)action2).method = (nint)__ldftn(TP_SwordBrothers_Projectile.ShootBullets);
		((Delegate)action2).m_target = this;
		((Delegate)action2).method_code = (IntPtr)action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v572 @ r10_v7 (Il2CppMethodInfo)+4C]");
		object obj6 = (nint)0 >> 4;
		object obj7 = obj6 & 1;
		nint num7;
		if (obj7 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v572 @ r10_v7 (Il2CppMethodInfo)+52]");
			bool flag4 = (nint)0 == 0;
			num7 = unchecked((nint)6447293664L);
			if (flag4)
			{
				goto IL_057d;
			}
		}
		num7 = ((Delegate)action2).method_ptr;
		((Delegate)action2).method_code = (IntPtr)((Delegate)action2).m_target;
		goto IL_057d;
		IL_057d:
		((Delegate)action2).extra_arg = unchecked((nint)6447293568L);
		Timer shootTimer = Timers.Register(1.5000001f, action2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_shootTimer = shootTimer;
	}

	public override void InternalUpdate()
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		//IL_00d5: Expected O, but got F4
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_SwordBrothers_Projectile)+DC]");
		object obj2 = default(object);
		object obj = obj2 + 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		Transform transform = _displaySprite.transform;
		float num = transform.localEulerAngles.z - 90f;
		float num2 = num * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		float num3 = num2 * physOffsetRadius;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float num4 = num2 * physOffsetRadius;
		positionOffset = (float2)num3;
		float num5 = num4 + 0.16f;
		float2 float6 = _displaySprite.position;
		float2 float7 = default(float2);
		base.position = float7;
	}

	private void ShootBullets()
	{
		//IL_014b: Expected O, but got I4
		//IL_0038: Expected O, but got I4
		//IL_0041: Expected O, but got I4
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_SwordBrothers2, soundConfig, 200f, 2, time);
		List<TP_SwordBrothers_Firing_Projectile> list = bullets;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 < list._size)
			{
				List<TP_SwordBrothers_Firing_Projectile> list2 = bullets;
				if ((nint)obj >= list2._size)
				{
					break;
				}
				TP_SwordBrothers_Firing_Projectile[] items = list2._items;
				if ((object)items[obj] != null)
				{
					items[obj].ShootOff();
				}
				list = bullets;
				obj++;
				obj2 = obj;
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 176 Invalid \"Jump target not found in method: 0x187195F90\"");
			throw new NullReferenceException();
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void FadeOutAndDispose()
	{
		//IL_0169: Expected O, but got I4
		//IL_0184: Expected I, but got O
		DOGetter<Vector2> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DFF0");
		DOSetter<Vector2> dOSetter = null;
		((TP_SwordBrothers_Projectile)(object)dOSetter)._003CFadeOutAndDispose_003Eb__17_1((Vector2)this);
		Vector2 endValue = default(Vector2);
		TweenerCore<Vector2, Vector2, VectorOptions> t = DOTween.To(getter, dOSetter, endValue, 0.2f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Tween tween = TweenSettingsExtensions.SetDelay((Tween)t, 0.1f);
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] targets = new object[1];
		Tween tween2 = TweenSettingsExtensions.SetDelay((Tween)(object)this, 0.1f);
		if (tween2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = targets;
			tweenConfig.delay = 100f;
			tweenConfig.duration = 200f;
			tweenConfig.alpha = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v525 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SwordBrothers_Projectile>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num = (nint)this;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
			_alphaTween = alphaTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public override void Despawn()
	{
		//IL_0204: Expected O, but got I4
		//IL_020d: Expected O, but got I4
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Expected O, but got Unknown
		PhaserSprite phaserSprite = _displaySprite.setVisible(visible: false);
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_angleTween != null)
		{
			_angleTween.Kill();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		Tween windSequence = _windSequence;
		if (_windSequence != null && windSequence._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_windSequence);
		}
		if (_shootTimer != null)
		{
			_shootTimer.Cancel();
		}
		List<TP_SwordBrothers_Firing_Projectile> list = bullets;
		if (bullets != null)
		{
			int version = list._version + 1;
			list._version = version;
			list._size = 0;
			if (list._size > 0)
			{
				Array.Clear(list._items, 0, list._size);
			}
		}
		if (_bulletTimers != null)
		{
			List<Timer> bulletTimers = _bulletTimers;
			object obj = 0;
			object obj2 = 0;
			List<Timer> bulletTimers2;
			while (true)
			{
				bulletTimers2 = _bulletTimers;
				if ((nint)obj2 >= bulletTimers._size)
				{
					break;
				}
				if ((nint)obj < bulletTimers2._size)
				{
					Timer[] items = bulletTimers2._items;
					if (items[obj] != null)
					{
						items[obj].Cancel();
					}
					bulletTimers = _bulletTimers;
					obj++;
					obj2 = obj;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			if (bulletTimers2 != null)
			{
				int version2 = bulletTimers2._version + 1;
				bulletTimers2._version = version2;
				bulletTimers2._size = 0;
				if (bulletTimers2._size > 0)
				{
					Array.Clear(bulletTimers2._items, 0, bulletTimers2._size);
				}
			}
		}
		base.Despawn();
	}

	private Vector2 _003CInitProjectile_003Eb__13_0()
	{
		Vector2 result = default(Vector2);
		return result;
	}

	private void _003CInitProjectile_003Eb__13_1(Vector2 x)
	{
		displayOffset = x;
	}

	private unsafe Vector3 _003CInitProjectile_003Eb__13_2()
	{
		//IL_0094: Expected native int or pointer, but got O
		//IL_00a2: Expected native int or pointer, but got O
		if ((object)_displaySprite != null)
		{
			Transform transform = _displaySprite.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				float ret;
				Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
				Vector3 vector = default(Vector3);
				((Vector3*)(nint)vector)->x = ret;
				((Vector3*)(nint)vector)->z = 0f;
				return vector;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void _003CInitProjectile_003Eb__13_3(Vector3 x)
	{
		if ((object)_displaySprite != null)
		{
			Transform transform = _displaySprite.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				float value = default(float);
				Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void _003CInitProjectile_003Eb__13_5()
	{
		EmitBullets();
	}

	private Vector2 _003CFadeOutAndDispose_003Eb__17_0()
	{
		Vector2 result = default(Vector2);
		return result;
	}

	private void _003CFadeOutAndDispose_003Eb__17_1(Vector2 x)
	{
		displayOffset = x;
	}
}
