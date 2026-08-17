using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class FB_TimeWarpProjectile : Projectile
{
	private List<Sprite> _animationFrames;

	private float _animationProgress;

	private float _loopTimer;

	private Timer _hitboxTimer;

	private int FrameRate => 16;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_00b9: Expected O, but got I4
		//IL_00b9: Expected O, but got I4
		//IL_0031: Expected I4, but got O
		//IL_0111: Expected O, but got I4
		//IL_020c: Expected F4, but got I4
		base.InitProjectile(pool, weapon, index);
		float? num = default(float?);
		if (_animationFrames == null)
		{
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Time Warp-F", 1, 17, "firstBlood", (int)num);
			_animationFrames = animationFrames;
			num = num;
		}
		ArcadeSprite arcadeSprite = setAlpha(0.65f);
		Weapon weapon2 = _weapon;
		bool flag = ((Equipment)weapon2)._003COwner_003Ek__BackingField.flipX;
		ArcadeSprite arcadeSprite2 = setFlipX(flag);
		BaseBody baseBody = body;
		BaseBody baseBody2 = body.setCircle(64f, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody3 = body;
		baseBody3._enable = false;
		float num2 = (float)index + 4f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C46650");
		SetScaleToArea(num2);
		object obj = index + 100;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int num3 = default(int);
		ArcadeSprite arcadeSprite3 = setDepth(num3);
		_animationProgress = 0f;
		float num4 = _weapon.PDuration();
		float num5 = num2 * 0.5f;
		List<Sprite> animationFrames2 = _animationFrames;
		float loopTimer = num5 / 1000f;
		_loopTimer = loopTimer;
		if (animationFrames2._size > 0)
		{
			Sprite[] items = animationFrames2._items;
			float2 originalSize = default(float2);
			ArcadeSprite arcadeSprite4 = setFrameIncludingOriginalSize(items[0], originalSize);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_CrushShot, 1000f, 10, 0f, num, rate, detune, loop, 1f);
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public override void InternalUpdate()
	{
		//IL_02cd: Invalid comparison between I4 and F4
		//IL_005a: Expected F4, but got I4
		//IL_02ea: Invalid comparison between F4 and I4
		//IL_00f3: Invalid comparison between F4 and I4
		//IL_034d: Expected O, but got F4
		//IL_01f6: Expected O, but got I4
		//IL_01f6: Expected O, but got I4
		//IL_0275->IL0275: Incompatible stack heights: 1 vs 0
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si esi,xmm0\"");
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime + _animationProgress;
		float num2 = num - 0.5625f;
		float num3 = num2 + num2;
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
		if (num3 > 0f)
		{
			Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
			Vector3 localEulerAngles = cachedTrans.localEulerAngles;
			float deltaTime2 = PauseSystem.DeltaTime;
			float num4 = deltaTime2 * 1000f;
			float num5 = num4 * 0.2f;
			float num6 = ((!base.flipX) ? 1f : (-1f));
			float num7 = num5 * num3;
			float num8 = num7 * num6;
			float num9 = localEulerAngles.z - num8;
			base.angle = num9;
		}
		if (!(num < 0.875f) && !(_loopTimer < 0f))
		{
			_animationProgress = 0.875f;
			object obj = Time.deltaTime;
			float loopTimer = _loopTimer - _loopTimer;
			_loopTimer = loopTimer;
		}
		else
		{
			_animationProgress = num;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edi,xmm0\"");
		object obj2 = default(object);
		if ((nint)obj2 >= 3)
		{
			BaseBody baseBody = body;
			baseBody._enable = true;
			if ((nint)obj2 >= 11)
			{
				object obj3 = default(object);
				if ((nint)obj3 < 11)
				{
					OnCircleComplete();
				}
			}
			else
			{
				float num10 = _animationProgress - 0.1875f;
				float num11 = num10 + num10;
				bool flag = base.flipX;
				float num12 = -1f;
				if (!flag)
				{
					num12 = 1f;
				}
				float num13 = num11 * 360f;
				float num14 = num13 * num12;
				float num15 = num14 - 90f;
				float num16 = num15 * ((float)Math.PI / 180f);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				BaseBody baseBody2 = body.setCircle(32f, (float?)(object)1, (float?)(object)1);
			}
		}
		List<Sprite> animationFrames = _animationFrames;
		if ((nint)obj2 < animationFrames._size)
		{
			bool flag2 = (nint)obj2 >= animationFrames._size;
			Sprite[] items = animationFrames._items;
			float2 originalSize = default(float2);
			ArcadeSprite arcadeSprite = setFrameIncludingOriginalSize(items[obj2], originalSize);
		}
		else
		{
			Despawn();
		}
	}

	private void OnCircleComplete()
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		BaseBody baseBody = body;
		BaseBody baseBody2 = body.setCircle(64f, (float?)(object)1, (float?)(object)1);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
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

	private void LateUpdate()
	{
		//IL_0040: Expected O, but got I4
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		base.position = float5;
		object obj = _indexInWeapon + 100;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int num = default(int);
		ArcadeSprite arcadeSprite = setDepth(num);
	}

	private void InitAnimation()
	{
		int zeroPad = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Time Warp-F", 1, 17, "firstBlood", zeroPad);
		_animationFrames = animationFrames;
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_00ef: Invalid comparison between O and F4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj2 = default(object);
		if (obj2 == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rax_v6+10]");
		if ((nint)0 == 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		GameObject gameObject = default(GameObject);
		EnemyController component = gameObject.GetComponent<EnemyController>();
		object obj3 = default(object);
		if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0 && ((object)component._003CResDebuffs_003Ek__BackingField == null || System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f)) && !TryFreeze(component))
		{
			bool flag = component.DoDefang(1000f);
			if (!component._003CIsDefanged_003Ek__BackingField && component._003CSlow_003Ek__BackingField > 0.2f)
			{
				float num = component._003CSlow_003Ek__BackingField - 0.05f;
				component._003CSlow_003Ek__BackingField = num;
			}
		}
	}

	public override void Despawn()
	{
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		_hitboxTimer = null;
		base.Despawn();
	}

	private void _003COnCircleComplete_003Eb__8_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}
}
