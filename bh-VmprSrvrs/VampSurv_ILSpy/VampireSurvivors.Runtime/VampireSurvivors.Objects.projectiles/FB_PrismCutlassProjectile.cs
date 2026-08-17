using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class FB_PrismCutlassProjectile : Projectile
{
	private MultiTargetTween _scaleTween;

	private float2 _lastOwnerPosition;

	private SpriteAnimation _anim;

	private int _directionID;

	private Timer[] _timers;

	public bool MirrorFacingAngle;

	private static float2[] _directionVectors;

	private static string[] _directionNames;

	private static string[] _spriteNames;

	private static List<Sprite>[] s_directionSpritesCache;

	public static void ClearDirectionSpritesCache()
	{
		List<Sprite>[] array = new List<Sprite>[8];
		s_directionSpritesCache = array;
	}

	public int GetDirectionID(Vector2 direction)
	{
		//IL_0108: Expected I4, but got O
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		int num = 0;
		int num2 = 0;
		float num3 = -1f;
		object obj2 = default(object);
		while (true)
		{
			float2[] directionVectors = _directionVectors;
			if (num2 >= directionVectors.Length)
			{
				return num;
			}
			float2[] directionVectors2 = _directionVectors;
			if (num2 >= directionVectors2.Length)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rdx_v5 (Unity.Mathematics.float2[])+24+v53 @ rbx_v2 (System.Int32)*8]");
			object obj = obj2 * 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rdx_v5 (Unity.Mathematics.float2[])+20+v53 @ rbx_v2 (System.Int32)*8]");
			object obj3 = direction * 0;
			float num4 = (float)obj + (float)obj3;
			bool flag = !(num4 > num3);
			float num5 = num3;
			if (!flag)
			{
				num5 = num4;
			}
			bool flag2 = num4 > num3;
			int num6 = num2;
			if (!flag2)
			{
				num6 = num;
			}
			num2++;
			num = num6;
			num3 = num5;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (int)ex;
	}

	public List<Sprite> GetFramesForDirection(int directionID)
	{
		//IL_0073: Expected O, but got I4
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Expected O, but got Unknown
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Expected O, but got Unknown
		Weapon weapon = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		bool flag = characterController._characterType != CharacterType.FB_PROBO;
		string text = "PrismCutlass2-";
		if (!flag)
		{
			text = "PrismCutlass-";
		}
		List<Sprite> list = null;
		Sprite[] items = null;
		list._items = items;
		object obj = 0;
		while (true)
		{
			string[] spriteNames = _spriteNames;
			if ((nint)obj >= spriteNames.Length)
			{
				return list;
			}
			string[] directionNames = _directionNames;
			if (directionID >= directionNames.Length)
			{
				break;
			}
			string[] spriteNames2 = _spriteNames;
			if ((nint)obj >= spriteNames2.Length)
			{
				break;
			}
			string spriteName = text + directionNames[directionID] + "-" + spriteNames2[obj];
			Sprite sprite = SpriteManager.GetSprite(spriteName, "firstBlood", ignoreExtension: false);
			Sprite[] items2 = list._items;
			int version = list._version + 1;
			list._version = version;
			if (list._size >= items2.Length)
			{
				((List<object>)(object)list).AddWithResize((object)sprite);
				obj++;
				continue;
			}
			int num = list._size + 1;
			list._size = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			obj++;
		}
		return (List<Sprite>)(object)new IndexOutOfRangeException();
	}

	protected override void Awake()
	{
		//IL_0052: Expected O, but got I4
		base.Awake();
		GameObject gameObject = _renderer.gameObject;
		SpriteAnimation anim = gameObject.AddComponent<SpriteAnimation>();
		_anim = anim;
		SpriteAnimation anim2 = _anim;
		anim2._originalSpriteSize = (float2)1124073472;
		_ = 1124073472;
		Sprite sprite = SpriteManager.GetSprite("ProjectileSword", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0036: Expected O, but got I4
		//IL_005a: Expected O, but got I4
		//IL_005a: Expected O, but got I4
		//IL_00ca: Expected O, but got I
		//IL_00dc: Expected I4, but got I8
		//IL_010a: Expected O, but got I4
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Expected I4, but got Unknown
		//IL_05b5: Expected O, but got Ref
		//IL_05e8: Invalid comparison between F4 and I4
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Expected O, but got Unknown
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_063e: Expected F4, but got I4
		//IL_0648: Expected O, but got I4
		//IL_0651: Expected O, but got I4
		//IL_022d: Expected O, but got I4
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected O, but got Unknown
		//IL_06ba: Expected I4, but got O
		//IL_073a: Unknown result type (might be due to invalid IL or missing references)
		//IL_073f: Expected O, but got Unknown
		//IL_02a6: Expected O, but got I4
		//IL_0265: Expected I, but got O
		//IL_03bd: Expected I4, but got O
		//IL_0422: Expected I, but got O
		//IL_0487: Expected O, but got I4
		//IL_04c5: Expected O, but got I4
		//IL_0541: Expected F4, but got I4
		//IL_0541: Expected F4, but got O
		//IL_0541: Expected F4, but got I4
		//IL_0541: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		float2 lastOwnerPosition = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		_lastOwnerPosition = lastOwnerPosition;
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		BaseBody baseBody = body.setCircle(16f, (float?)(object)1, (float?)(object)1);
		_isCullable = false;
		ArcadeSprite arcadeSprite2 = setTint(16777215u);
		ArcadeSprite arcadeSprite3 = setAlpha(1f);
		Weapon weapon2 = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
		Vector2 vector = characterController._lastMovementDirection;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rax_v22 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
		object obj = 0;
		int num = (int)(index & 0x80000001L);
		if ((nint)characterController < 0)
		{
			object obj2 = num - 1;
			object obj3 = obj2 | -2;
			num = obj3 + 1;
		}
		if (num == 1)
		{
			vector = (Vector2)(vector ^ -0f);
			obj ^= -0f;
		}
		if (MirrorFacingAngle)
		{
			obj ^= -0f;
		}
		object obj4 = default(object);
		ApplyPlayerFacingVelocity((Vector3)(&obj4), rotate: false);
		base.angle = 0f;
		bool flag = 0 < (nint)vector;
		float num2 = 0f - (float)vector;
		bool flag2 = num2 == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		bool flag5 = flag4 & flag3;
		ArcadeSprite arcadeSprite4 = setFlipX(flag5);
		float num3 = -1f;
		float2 float6 = default(float2);
		float2 float5 = float6;
		float num4 = 0f;
		float? num5 = (float?)(object)0;
		float? num6 = (float?)(object)0;
		while (true)
		{
			float2[] directionVectors = _directionVectors;
			if ((nint)num6 >= directionVectors.Length)
			{
				break;
			}
			float2[] directionVectors2 = _directionVectors;
			Vector2 vector2 = vector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rdx_v61 (Unity.Mathematics.float2[])+20+v288 @ rdi_v10 (System.Nullable`1<System.Single>)*8]");
			object obj5 = vector2 * 0;
			object obj6 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rdx_v61 (Unity.Mathematics.float2[])+24+v288 @ rdi_v10 (System.Nullable`1<System.Single>)*8]");
			float5 = (float2)(obj6 * 0);
			num4 = (float)obj5 + (float)float5;
			bool flag6 = !(num4 > num3);
			float num7 = num3;
			if (!flag6)
			{
				num7 = num4;
			}
			bool flag7 = num4 > num3;
			float? num8 = num6;
			if (!flag7)
			{
				num8 = num5;
			}
			num6 = (float?)(object)((_003F?)num6 + 1);
			num3 = num7;
			num5 = num8;
		}
		List<Sprite>[] array = s_directionSpritesCache;
		bool flag8 = array[(object)num5] != null;
		object obj7 = 0;
		if (!flag8)
		{
			List<Sprite>[] array2 = s_directionSpritesCache;
			List<Sprite> framesForDirection = GetFramesForDirection((int)num5);
			if (framesForDirection != null)
			{
				nint num9 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj8 = default(object);
				if (obj8 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			array2[(object)num5] = framesForDirection;
			obj7 = 0;
		}
		string[] directionNames = _directionNames;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @187074010");
		object obj9 = default(object);
		bool flag9 = default(bool);
		bool flag10 = default(bool);
		Action action = default(Action);
		bool flag11 = default(bool);
		if (obj9 == null)
		{
			List<Sprite>[] array3 = s_directionSpritesCache;
			string[] directionNames2 = _directionNames;
			_anim.AddAnimation(directionNames2[(object)num5], array3[(object)num5], 10, flag9, flag10, action, flag11);
		}
		SpriteAnimation anim = _anim;
		((BaseSpriteAnimation)anim)._currentAnimation = null;
		List<Sprite>[] array4 = s_directionSpritesCache;
		List<Sprite> list = array4[(object)num5];
		if (list._size > 0)
		{
			Sprite[] items = list._items;
			ArcadeSprite arcadeSprite5 = setFrameIncludingOriginalSize(items[0], float6);
			_directionID = (int)num5;
			if (_scaleTween != null)
			{
				_scaleTween.Kill();
			}
			_scaleTween = null;
			TweenConfig tweenConfig = new TweenConfig();
			object[] array5 = new object[1];
			nint num10 = (nint)array5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj10 = default(object);
			if (obj10 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig.targets = array5;
				float num11 = _weapon.PArea();
				tweenConfig.scaleX = (float?)(object)1;
				float num12 = _weapon.PArea();
				tweenConfig.duration = 500f;
				tweenConfig.ease = Ease.OutCubic;
				tweenConfig.scaleY = (float?)(object)1;
				TweenCallback onComplete = FadeOut;
				tweenConfig.onComplete = onComplete;
				MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
				_scaleTween = scaleTween;
				PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Attack1, 100f, 10, 0f, (float?)(object)flag9, flag10 ? 1 : 0, (float)action, flag11, 1f);
				_spriteTrail.Reset();
				SpriteTrail spriteTrail = _spriteTrail.setVisible(b: true);
				return;
			}
			ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
			throw ex2;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new IndexOutOfRangeException();
	}

	private void FadeOut()
	{
		//IL_00a8: Expected I, but got O
		//IL_0155: Expected I, but got O
		//IL_025d: Expected I, but got O
		//IL_0202: Expected I, but got O
		//IL_02ba: Expected I, but got O
		string[] directionNames = _directionNames;
		int directionID = _directionID;
		_anim.SetAnimation(directionNames[directionID]);
		Timer[] timers = _timers;
		Action onComplete = delegate
		{
			//IL_0010: Expected O, but got I4
			setVelocity(0f, (float?)(object)0);
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.3f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		if (timer != null)
		{
			nint num = (nint)timers;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Timer[] timers2 = _timers;
		Action onComplete2 = DoSweepHit;
		Timer timer2 = Timers.Register(0.4f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		if (timer2 != null)
		{
			nint num2 = (nint)timers2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Timer[] timers3 = _timers;
		Action onComplete3 = StopSweepHit;
		Timer timer3 = Timers.Register(0.70000005f, onComplete3, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		if (timer3 != null)
		{
			nint num3 = (nint)timers3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Timer[] timers4 = _timers;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v595 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_PrismCutlassProjectile>)+370]");
		Action onComplete4 = new Action(this, (IntPtr)0);
		nint num4 = (nint)this;
		Timer timer4 = Timers.Register(1f, onComplete4, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		if (timer4 != null)
		{
			nint num5 = (nint)timers4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
	}

	private void DoSweepHit()
	{
		//IL_002f: Expected O, but got I4
		//IL_002f: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		BaseBody baseBody = body.setCircle(64f, (float?)(object)1, (float?)(object)1);
	}

	private void StopSweepHit()
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		BaseBody baseBody = body.setCircle(16f, (float?)(object)1, (float?)(object)1);
		SpriteTrail spriteTrail = _spriteTrail.setVisible(b: false);
	}

	public override void InternalUpdate()
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		BaseBody baseBody = body;
		object obj = float5 - _lastOwnerPosition;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.FB_PrismCutlassProjectile)+DC]");
		object obj3 = default(object);
		object obj2 = obj3 - 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rax_v5 (BaseBody)+74]");
		object obj4 = obj2 * 0;
		object obj5 = obj * (object)baseBody._velocity;
		object obj6 = obj5 + obj4;
		if ((nint)obj6 > 0)
		{
			float2 float6 = base.position;
			BaseBody baseBody2 = body;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185004360");
			object obj7 = default(object);
			obj6 = obj3 + obj7;
			float2 float7 = default(float2);
			base.position = float7;
		}
		_lastOwnerPosition = float5;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int num = default(int);
		ArcadeSprite arcadeSprite = setDepth(num);
		_spriteTrail.UpdateDepth();
	}

	public override void Despawn()
	{
		//IL_004b: Expected I, but got O
		//IL_012b: Expected O, but got I
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		_scaleTween = null;
		Timer[] timers = _timers;
		nint num = unchecked((nint)null);
		MultiTargetTween multiTargetTween = null;
		while ((nint)multiTargetTween < timers.Length)
		{
			Timer[] timers2 = _timers;
			if (timers2[num] != null && !timers2[num].IsDone)
			{
				Timer[] timers3 = _timers;
				timers3[num].Cancel();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			timers = _timers;
			num++;
			multiTargetTween = (MultiTargetTween)num;
		}
		base.Despawn();
	}

	protected override void OnDestroy()
	{
		//IL_004b: Expected I, but got O
		//IL_0050: Expected I, but got O
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		_scaleTween = null;
		Timer[] timers = _timers;
		nint num = unchecked((nint)null);
		for (nint num2 = unchecked((nint)null); num2 < timers.Length; num2 = num)
		{
			Timer[] timers2 = _timers;
			if (timers2[num] != null && !timers2[num].IsDone)
			{
				Timer[] timers3 = _timers;
				timers3[num].Cancel();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			timers = _timers;
			num++;
		}
		if (body != null)
		{
			BaseBody baseBody = body;
			baseBody._gameObject = null;
		}
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_0033: Expected F4, but got I4
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_EnemyHit, 150f, 5, 0f, volume, rate, detune, loop, 1f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null)
		{
			bool flag = TryFreeze(other);
		}
	}

	public FB_PrismCutlassProjectile()
	{
		Timer[] timers = new Timer[4];
		_timers = timers;
		base._002Ector();
	}

	static FB_PrismCutlassProjectile()
	{
		float2[] directionVectors = new float2[8];
		_ = 1065353216;
		_ = 0;
		_ = 1060439283;
		_ = 1060439283;
		_ = 0;
		_ = 1065353216;
		_ = 3207922931L;
		_ = 1060439283;
		_ = 3212836864L;
		_ = 0;
		_ = 3207922931L;
		_ = 3207922931L;
		_ = 0;
		_ = 3212836864L;
		_ = 1060439283;
		_ = 3207922931L;
		_directionVectors = directionVectors;
		string[] directionNames = new string[8];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		_directionNames = directionNames;
		string[] spriteNames = new string[10];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		_spriteNames = spriteNames;
		List<Sprite>[] array = new List<Sprite>[8];
		s_directionSpritesCache = array;
	}

	private void _003CFadeOut_003Eb__15_0()
	{
		//IL_0010: Expected O, but got I4
		setVelocity(0f, (float?)(object)0);
	}
}
