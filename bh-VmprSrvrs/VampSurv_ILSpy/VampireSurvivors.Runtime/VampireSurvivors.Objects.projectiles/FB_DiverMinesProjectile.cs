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
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class FB_DiverMinesProjectile : Projectile
{
	private enum ScreenEdge
	{
		None,
		Top,
		Bottom,
		Left,
		Right
	}

	private bool _anticlockwiseSpin;

	private bool _hasHitAnything;

	private Timer _explosionTimer;

	private ScreenEdge _screenEdge;

	private float2 _lastVelocity;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("fx_diversmine1", "FirstBlood");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("fx_diversmine", 1, 4, "firstBlood", num);
		GameObject gameObject = _renderer.gameObject;
		SpriteAnimation spriteAnimation = gameObject.AddComponent<SpriteAnimation>();
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		spriteAnimation.AddAnimation("idle", animationFrames, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_01a3: Expected O, but got I4
		//IL_002a: Expected O, but got I4
		//IL_002a: Expected O, but got I4
		//IL_00a5: Expected O, but got Ref
		//IL_017c: Expected F4, but got I4
		//IL_017c: Expected F4, but got I4
		//IL_017c: Expected F4, but got O
		//IL_017c: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		BaseBody baseBody = body.setCircle(12f, (float?)(object)1, (float?)(object)1);
		bool anticlockwiseSpin = ((Equipment)weapon)._003COwner_003Ek__BackingField.flipX;
		_anticlockwiseSpin = anticlockwiseSpin;
		BaseBody baseBody2 = body;
		_hasHitAnything = false;
		_screenEdge = ScreenEdge.None;
		baseBody2._enable = true;
		ArcadeSprite arcadeSprite2 = setVisible(visible: true);
		object obj = default(object);
		ApplyPlayerFacingVelocity((Vector3)(&obj), rotate: false);
		if (_explosionTimer != null)
		{
			_explosionTimer.Cancel();
		}
		float num = _weapon.PDuration();
		Action onComplete = DoExplode;
		object obj2 = default(object);
		float duration = (float)obj2 * 0.001f;
		bool flag = default(bool);
		MonoBehaviour monoBehaviour = default(MonoBehaviour);
		int num2 = default(int);
		TimerType timerType = default(TimerType);
		Timer explosionTimer = Timers.Register(duration, onComplete, null, isLooped: false, flag, monoBehaviour, num2, timerType, isOnlineTimer: false, canPause: false);
		_explosionTimer = explosionTimer;
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_HomingShot, 100f, 12, 0f, (float?)(object)flag, (float)monoBehaviour, num2, (byte)timerType != 0, 1f);
	}

	private void DoExplode()
	{
		//IL_0033: Expected F4, but got I4
		//IL_00d4: Expected O, but got I4
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_Explosion1, 500f, 12, 0f, volume, rate, detune, loop, 1f);
		float2 pos = base.position;
		float num = _weapon.PArea();
		ArcadeSprite arcadeSprite = _weapon.SpawnExplosionAt(pos, 0, 1, 0f);
		if ((object)arcadeSprite != null && ((UnityEngine.Object)arcadeSprite).m_CachedPtr != (IntPtr)0)
		{
			float num2 = _weapon.PArea();
			ArcadeSprite arcadeSprite2 = arcadeSprite.setScale(2f, (float?)(object)0);
		}
		Despawn();
	}

	public override void InternalUpdate()
	{
		//IL_0182: Expected I, but got O
		//IL_0168: Expected I4, but got I8
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
		Vector3 localEulerAngles = cachedTrans.localEulerAngles;
		float deltaTime = PauseSystem.DeltaTime;
		float num = ((!_anticlockwiseSpin) ? 1f : (-1f));
		nint num2 = (nint)this;
		float projectileSpeed = base.ProjectileSpeed;
		float num3 = deltaTime * 360f;
		float num4 = num3 * num;
		float num5 = num4 * deltaTime;
		float num6 = localEulerAngles.z - num5;
		base.angle = num6;
		bool flag = !_hasHitAnything;
		BaseBody baseBody = body;
		float deltaTime2;
		float num7;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003DD0");
			deltaTime2 = PauseSystem.DeltaTime;
			object obj = 0.016f & -2147483649L;
			if ((nint)obj <= 2139095040)
			{
				bool flag2 = !(0.016f > deltaTime2);
				num7 = 0.016f;
				if (flag2)
				{
					goto IL_0201;
				}
			}
			num7 = deltaTime2;
			goto IL_0201;
		}
		float deltaTime3 = PauseSystem.DeltaTime;
		float num8 = deltaTime3 * -4f;
		float num9 = num8;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rdi_v2 (BaseBody)+74]");
		float num10 = num9 + 0f;
		baseBody._velocity = baseBody._velocity;
		goto IL_022c;
		IL_022c:
		BaseBody baseBody2 = body;
		_lastVelocity = baseBody2._velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rax_v9 (BaseBody)+74]");
		_ = 0;
		ArcadeSprite arcadeSprite = setDepth(-1000);
		_spriteTrail.UpdateDepth();
		return;
		IL_0201:
		bool flag3 = _anticlockwiseSpin;
		float num11 = -1f;
		if (!flag3)
		{
			num11 = 1f;
		}
		float projectileSpeed2 = base.ProjectileSpeed;
		float num12 = num7 * 16f;
		float num13 = num12 * num11;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rdi_v2 (BaseBody)+74]");
		float rotation = 0f - num13;
		Vector2 vector = SetVelocityFromRotation(rotation, deltaTime2);
		goto IL_022c;
	}

	private void LateUpdate()
	{
		HandleScreenEdges();
	}

	private unsafe void HandleScreenEdges()
	{
		//IL_0048: Expected O, but got I
		//IL_024f: Expected O, but got Ref
		//IL_0186: Expected O, but got Ref
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		BaseBody baseBody = body;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ r8_v2 (BaseBody)+5C]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ r8_v2 (BaseBody)+54]");
		object obj = num + 0;
		object obj3 = default(object);
		object obj2 = obj3 + obj3;
		ScreenEdge screenEdge = ((System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) && _screenEdge != ScreenEdge.Top) ? ScreenEdge.Top : ScreenEdge.None);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ r8_v2 (BaseBody)+54]");
		if ((nint)obj3 > 0 && _screenEdge != ScreenEdge.Bottom)
		{
			screenEdge = ScreenEdge.Bottom;
		}
		BaseBody baseBody2 = body;
		object obj4 = obj3 + (object)renderer.playArea;
		object obj5 = baseBody2._size + baseBody2._position;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) && _screenEdge != ScreenEdge.Right)
		{
			screenEdge = ScreenEdge.Right;
		}
		BaseBody baseBody3 = body;
		ArcadeRect playArea = renderer.playArea;
		float2 obj6 = baseBody3._position;
		ArcadeRect arcadeRect = default(ArcadeRect);
		if (System.Runtime.CompilerServices.Unsafe.As<ArcadeRect, UIntPtr>(ref playArea) > System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref obj6) && _screenEdge != ScreenEdge.Left)
		{
			screenEdge = ScreenEdge.Left;
		}
		else if (screenEdge == ScreenEdge.None)
		{
			if (_screenEdge != ScreenEdge.None)
			{
				StickToScreenEdge(_screenEdge, (ArcadeRect)(&arcadeRect));
			}
			return;
		}
		StickToScreenEdge(screenEdge, (ArcadeRect)(&arcadeRect));
	}

	private void StickToScreenEdge(ScreenEdge nextEdge, ArcadeRect playArea)
	{
		//IL_000e: Expected O, but got I4
		//IL_024d: Expected O, but got I
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		//IL_02e0: Expected O, but got F4
		//IL_0214: Expected O, but got F4
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_018a: Expected O, but got F4
		object obj = nextEdge - 1;
		bool flag = nextEdge == ScreenEdge.Top;
		BaseBody baseBody;
		float num4;
		float2 normal;
		float2 float5 = default(float2);
		if (!flag)
		{
			object obj2 = obj - 1;
			if (!flag)
			{
				object obj3 = obj2 - 1;
				if (!flag)
				{
					if ((nint)obj3 == 1)
					{
						baseBody = body;
						object obj4 = baseBody._size + baseBody._position;
						float num = playArea.width + playArea.x;
						float num2 = (float)obj4 - num;
						float num3 = num2 * 0f;
						num4 = num2 * -1f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rdx_v3 (BaseBody)+54]");
						float num5 = 0f + num3;
						normal = float5;
						goto IL_02bf;
					}
					return;
				}
				BaseBody baseBody2 = body;
				float num6 = playArea.x - (float)baseBody2._position;
				float num7 = num6 + (float)baseBody2._position;
				float num8 = num6 * 0f;
				float num9 = num8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v6 (BaseBody)+54]");
				float num10 = num9 + 0f;
				baseBody2._position = (float2)num7;
				normal = float5;
			}
			else
			{
				BaseBody baseBody3 = body;
				float num11 = playArea.y;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rcx_v4 (BaseBody)+54]");
				float num12 = num11 - 0f;
				float num13 = num12;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rcx_v4 (BaseBody)+54]");
				float num14 = num13 + 0f;
				float num15 = num12 * 0f;
				float num16 = num15 + (float)baseBody3._position;
				baseBody3._position = (float2)num16;
				normal = float5;
			}
			goto IL_02e5;
		}
		baseBody = body;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rdx_v3 (BaseBody)+5C]");
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rdx_v3 (BaseBody)+54]");
		object obj5 = num17 + 0;
		float num18 = playArea.height + playArea.y;
		float num19 = (float)obj5 - num18;
		float num20 = num19 * -1f;
		num4 = num19 * 0f;
		float num21 = num20;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rdx_v3 (BaseBody)+54]");
		float num22 = num21 + 0f;
		normal = float5;
		goto IL_02bf;
		IL_02bf:
		float num23 = num4 + (float)baseBody._position;
		baseBody._position = (float2)num23;
		goto IL_02e5;
		IL_02e5:
		StickToWall(normal);
		_screenEdge = nextEdge;
		_hasHitAnything = true;
	}

	private bool HitsTop(ArcadeRect playArea)
	{
		//IL_00c1: Expected I4, but got O
		//IL_0046: Expected O, but got I
		//IL_0067: Invalid comparison between O and F4
		//IL_0085: Invalid comparison between F4 and I4
		BaseBody baseBody = body;
		if (body != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ r8_v1 (BaseBody)+5C]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ r8_v1 (BaseBody)+54]");
			object obj = num + 0;
			float num2 = playArea.height + playArea.y;
			bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2);
			float num3 = (float)obj - num2;
			bool flag2 = num3 == 0f;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			return flag4 & flag3;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private bool HitsBottom(ArcadeRect playArea)
	{
		//IL_00a5: Expected I4, but got O
		//IL_003e: Invalid comparison between F4 and I
		//IL_0069: Invalid comparison between F4 and I4
		BaseBody baseBody = body;
		if (body != null)
		{
			float y = playArea.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rax_v1 (BaseBody)+54]");
			bool flag = y < 0f;
			float num = playArea.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rax_v1 (BaseBody)+54]");
			float num2 = num - 0f;
			bool flag2 = num2 == 0f;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			return flag4 & flag3;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private bool HitsRight(ArcadeRect playArea)
	{
		//IL_00bb: Expected I4, but got O
		//IL_0061: Invalid comparison between O and F4
		//IL_007f: Invalid comparison between F4 and I4
		BaseBody baseBody = body;
		if (body != null)
		{
			object obj = baseBody._size + baseBody._position;
			float num = playArea.width + playArea.x;
			bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num);
			float num2 = (float)obj - num;
			bool flag2 = num2 == 0f;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			return flag4 & flag3;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private bool HitsLeft(ArcadeRect playArea)
	{
		//IL_009f: Expected I4, but got O
		//IL_003b: Invalid comparison between F4 and O
		//IL_0063: Invalid comparison between F4 and I4
		BaseBody baseBody = body;
		if (body != null)
		{
			float x = playArea.x;
			float2 obj = baseBody._position;
			bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x) < System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref obj);
			float num = playArea.x - (float)baseBody._position;
			bool flag2 = num == 0f;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			return flag4 & flag3;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private void StickToWall(float2 normal)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_006f: Expected O, but got F4
		bool flag = !_anticlockwiseSpin;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj = normal ^ 0;
		float num = (flag ? 1f : (-1f));
		object obj2 = default(object);
		float num2 = (float)obj2 * num;
		float num3 = (float)obj * num;
		float projectileSpeed = base.ProjectileSpeed;
		ArcadeSprite sprite = _sprite;
		float num4 = num2 * num;
		float num5 = num3 * num;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = (float2)num4;
		BaseBody baseBody2 = body;
		_lastVelocity = baseBody2._velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v7 (BaseBody)+74]");
		_ = 0;
	}

	public override void OnHasHitWallPhaser(PhaserTile tile)
	{
		//IL_004b: Expected O, but got I
		BaseBody baseBody = body;
		_hasHitAnything = true;
		object obj = baseBody._velocity - _lastVelocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ rax_v1 (BaseBody)+74]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.FB_DiverMinesProjectile)+E8]");
		object obj2 = num - 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018706251Ch\"");
		if (obj == null)
		{
			bool flag = obj2 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018706251Ch\"");
			if (flag)
			{
				return;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186252410");
		float2 normal = default(float2);
		StickToWall(normal);
		if (_screenEdge != ScreenEdge.None)
		{
			if (_anticlockwiseSpin)
			{
			}
			float2 float5 = base.position;
			base.position = normal;
			_screenEdge = ScreenEdge.None;
		}
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		DoExplode();
	}

	public override void Despawn()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		if (_explosionTimer != null)
		{
			_explosionTimer.Cancel();
		}
		_explosionTimer = null;
		base.Despawn();
	}
}
