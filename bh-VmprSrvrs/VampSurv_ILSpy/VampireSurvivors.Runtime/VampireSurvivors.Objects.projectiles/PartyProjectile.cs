using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Events;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class PartyProjectile : Projectile
{
	private TrailRenderer _trail;

	private SpriteAnimation _SpriteAnimation;

	private Timer _expireTimer;

	private List<Transform> _positions;

	private uint _color;

	private float _saveVelX;

	private float _saveVelY;

	private List<float> _velMultipliersX;

	private List<float> _velMultipliersY;

	private List<float> _partyAngles;

	private PartyWeapon _trueWeapon;

	private MultiTargetTween _gravityTween;

	private Vector2 _leftVelocity;

	private Vector2 _rightVelocity;

	private float _bounceValue;

	private MultiTargetTween _angleTween;

	private List<int> _randomStartingFrame;

	private int _randomStartingIndex;

	private int _maxStartingFrame;

	private bool _canClearObjectsHit;

	private float _clearObjectTime;

	[NonSerialized]
	public float EnemiesHit;

	[NonSerialized]
	public List<Vector2> BouncePositions;

	[NonSerialized]
	public float SelfGravity;

	protected unsafe override void Awake()
	{
		//IL_0526: Expected O, but got F4
		//IL_0057: Expected O, but got I
		//IL_0067: Expected O, but got I
		//IL_00f1: Expected O, but got I
		//IL_0614: Expected O, but got F4
		//IL_0129: Expected O, but got I
		//IL_0139: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_01fc: Expected F4, but got I4
		//IL_028b: Expected O, but got I
		//IL_057e: Invalid comparison between F4 and I4
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cf: Expected O, but got Unknown
		//IL_02de: Expected O, but got I8
		//IL_02ef: Expected O, but got I4
		//IL_0309: Unknown result type (might be due to invalid IL or missing references)
		//IL_030e: Expected O, but got Unknown
		//IL_0341: Expected I, but got O
		//IL_059b: Expected O, but got F4
		//IL_05bd: Expected I4, but got I8
		//IL_0473: Expected O, but got I
		//IL_0483: Expected O, but got I
		//IL_04dc: Expected O, but got I
		base.Awake();
		WORLD_BOUNDS_EVENT wORLD_BOUNDS_EVENT = Bounce;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6950");
		int num = 0;
		WORLD_BOUNDS_EVENT wORLD_BOUNDS_EVENT2 = wORLD_BOUNDS_EVENT;
		List<float> s_world = (List<float>)(object)ArcadePhysics.s_world;
		float num3 = default(float);
		do
		{
			List<float> velMultipliersX = _velMultipliersX;
			object obj = UnityEngine.Random.value;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rbx_v9 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rbx_v9 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rbx_v9 (System.Collections.Generic.List`1<System.Single>)+18]");
			List<float> list = (List<float>)0;
			float num2 = num3 * 0.5f;
			float num4 = num2 + 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rbx_v9 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rdx_v17+18]");
			if (num5 >= 0)
			{
				velMultipliersX.AddWithResize(num4);
				float num6 = num4;
				list = velMultipliersX;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rbx_v9 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj3 = (nint)0 + (nint)1;
			}
			List<float> velMultipliersY = _velMultipliersY;
			object obj4 = UnityEngine.Random.value;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rbx_v10 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rbx_v10 (System.Collections.Generic.List`1<System.Single>)+10]");
			wORLD_BOUNDS_EVENT2 = (WORLD_BOUNDS_EVENT)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rbx_v10 (System.Collections.Generic.List`1<System.Single>)+18]");
			s_world = (List<float>)0;
			float num7 = num4 * 0.5f;
			num3 = num7 + 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rbx_v10 (System.Collections.Generic.List`1<System.Single>)+18]");
			if (0 >= (nint)((Delegate)wORLD_BOUNDS_EVENT2).invoke_impl)
			{
				velMultipliersY.AddWithResize(num3);
				float num6 = num3;
				s_world = velMultipliersY;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rbx_v10 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj5 = (nint)0 + (nint)1;
			}
			num++;
		}
		while (num < 12);
		List<float> partyAngles = new List<float>();
		_partyAngles = partyAngles;
		float num8 = 2f;
		do
		{
			List<float> partyAngles2 = _partyAngles;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rcx_v32 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rcx_v32 (System.Collections.Generic.List`1<System.Single>)+10]");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rcx_v32 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ r8_v17 (Il2CppMethodInfo)+18]");
			if (num10 >= 0)
			{
				partyAngles2.AddWithResize(num8);
				float num6 = num8;
				num9 = 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rcx_v32 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj6 = (nint)0 + (nint)1;
			}
			num8 += 2f;
		}
		while (num8 < 40f);
		VampireSurvivors.App.Tools.Extensions.Shuffle(_partyAngles);
		_partyAngles.Insert(0, 0f);
		Vector2 vector = (Vector2)(this + 296);
		_leftVelocity = (Vector2)3212836864L;
		_ = 1065353216;
		_rightVelocity = (Vector2)1065353216;
		_ = 1065353216;
		((Vector2*)vector)->Normalize();
		Vector2 vector2 = (Vector2)(this + 304);
		((Vector2*)vector2)->Normalize();
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num11 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1003 @ rcx_v40 (Il2CppClass<System.Collections.Generic.List`1<System.Single>>)+40]");
		((List<float>)(object)this).Insert(0, 0f);
		object obj7 = default(object);
		bool flag = obj7 == null;
		((List<float>)(object)array).Insert(0, 0f);
		tweenConfig.targets = array;
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object value = default(object);
		bool flag2 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"angle", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		tweenConfig.custom = dictionary;
		object obj8 = UnityEngine.Random.value;
		float num12 = num8 * 200f;
		tweenConfig.repeat = -1;
		float duration = num12 + 1000f;
		tweenConfig.duration = duration;
		MultiTargetTween angleTween = Tweens.Add(tweenConfig);
		_angleTween = angleTween;
		List<int> randomStartingFrame = new List<int>();
		_randomStartingFrame = randomStartingFrame;
		bool flag3 = _maxStartingFrame <= 0;
		int num13 = 0;
		if (!flag3)
		{
			do
			{
				List<int> randomStartingFrame2 = _randomStartingFrame;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rcx_v59 (System.Collections.Generic.List`1<System.Int32>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rcx_v59 (System.Collections.Generic.List`1<System.Int32>)+10]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rcx_v59 (System.Collections.Generic.List`1<System.Int32>)+18]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rcx_v59 (System.Collections.Generic.List`1<System.Int32>)+18]");
				nint num14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r8_v25+18]");
				if (num14 >= 0)
				{
					randomStartingFrame2.AddWithResize(num13);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rcx_v59 (System.Collections.Generic.List`1<System.Int32>)+18]");
					object obj11 = (nint)0 + (nint)1;
				}
				num13++;
			}
			while (num13 < _maxStartingFrame);
		}
		VampireSurvivors.App.Tools.Extensions.Shuffle(_randomStartingFrame);
	}

	public int GetRandomFrame()
	{
		//IL_004e: Expected O, but got I
		if (++_randomStartingIndex > _maxStartingFrame)
		{
			_randomStartingIndex = 0;
		}
		List<int> randomStartingFrame = _randomStartingFrame;
		int randomStartingIndex = _randomStartingIndex;
		int randomStartingIndex2 = _randomStartingIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		if ((nint)randomStartingIndex2 < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v7+20+v46 @ rax_v4 (System.Int32)*4]");
			return 0;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		int result = default(int);
		return result;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_000e: Expected O, but got I4
		//IL_06e8: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_06c1: Expected O, but got I8
		//IL_00ab: Expected O, but got I4
		//IL_028b: Expected O, but got I4
		//IL_028b: Expected O, but got I4
		//IL_02fe: Expected I, but got O
		//IL_036c: Expected I, but got O
		//IL_0432: Expected O, but got I4
		//IL_047a: Expected O, but got I4
		//IL_047a: Expected O, but got I4
		//IL_04b9: Expected I4, but got O
		//IL_0550: Expected O, but got I4
		//IL_05b3: Expected O, but got I4
		//IL_0583: Expected O, but got I4
		//IL_05ea: Expected O, but got I8
		//IL_0668: Expected I4, but got O
		//IL_0668: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		float? trueWeapon;
		if ((object)weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_06b4;
		}
		nint num = (nint)typeof(PartyWeapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v61 (Il2CppClass<VampireSurvivors.Objects.Weapons.PartyWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v52 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v61 (Il2CppClass<VampireSurvivors.Objects.Weapons.PartyWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v52 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v96+FFFFFFF8+v71 @ rax_v91*8]");
			if (0 == (nint)typeof(PartyWeapon))
			{
				obj3 = 1;
				goto IL_06d0;
			}
		}
		obj3 = 0;
		goto IL_06d0;
		IL_06d0:
		bool flag = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)weapon;
		}
		goto IL_06b4;
		IL_06b4:
		object obj4 = 6442450944L;
		_trueWeapon = (PartyWeapon)trueWeapon;
		int num4 = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("image_002_", 0, _maxStartingFrame, "vfx", num4);
		bool flag2 = default(bool);
		Action action = default(Action);
		bool flag3 = default(bool);
		_SpriteAnimation.AddAnimation("circle", animationFrames, 16, (byte)num4 != 0, flag2, action, flag3);
		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("image_003_", 0, _maxStartingFrame, "vfx", num4);
		_SpriteAnimation.AddAnimation("heart", animationFrames2, 16, (byte)num4 != 0, flag2, action, flag3);
		List<Sprite> animationFrames3 = SpriteManager.GetAnimationFrames("image_004_", 0, _maxStartingFrame, "vfx", num4);
		_SpriteAnimation.AddAnimation("star", animationFrames3, 16, (byte)num4 != 0, flag2, action, flag3);
		List<Sprite> animationFrames4 = SpriteManager.GetAnimationFrames("image_005_", 0, _maxStartingFrame, "vfx", num4);
		_SpriteAnimation.AddAnimation("triangle", animationFrames4, 16, (byte)num4 != 0, flag2, action, flag3);
		List<Sprite> animationFrames5 = SpriteManager.GetAnimationFrames("image_006_", 0, _maxStartingFrame, "vfx", num4);
		_SpriteAnimation.AddAnimation("rectangle", animationFrames5, 16, (byte)num4 != 0, flag2, action, flag3);
		EnemiesHit = 0f;
		BaseBody baseBody = base.body.setCircle(8f, (float?)(object)0, (float?)(object)0);
		_speed = 1f;
		SelfGravity = 0f;
		if (_gravityTween != null)
		{
			_gravityTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num5 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj5 = default(object);
		if (obj5 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Weapon weapon2 = _weapon;
			nint num6 = (nint)weapon2;
			float num7 = weapon2.PSpeed();
			object obj6 = default(object);
			float num8 = (float)obj6 * -6f;
			float num9 = num8 * 0.01f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag4 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"SelfGravity", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig.custom = dictionary;
			tweenConfig.duration = 300f;
			MultiTargetTween gravityTween = Tweens.Add(tweenConfig);
			_gravityTween = gravityTween;
			float num10 = _weapon.PArea();
			float xScale = num9 * 0.65f;
			ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)0);
			if (_expireTimer != null)
			{
				_expireTimer.Cancel();
			}
			setCollideWorldBounds(value: true, (float?)(object)1, (float?)(object)1);
			GameManager core = GM.Core;
			GameSessionData gameSessionData = core._gameSessionData;
			VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
			int num11 = (int)activeCharacter._worldBoxCollider;
			Body body = base.body.setBoundsRectangle(activeCharacter._worldBoxCollider);
			BaseBody baseBody2 = base.body;
			baseBody2._onWorldBounds = true;
			ArcadeSprite arcadeSprite2 = setAlpha(1f);
			List<Transform> positions = _positions;
			int version = positions._version + 1;
			positions._version = version;
			positions._size = 0;
			bool flag5 = positions._size <= 0;
			float? num12 = (float?)(object)1;
			if (!flag5)
			{
				Array.Clear(positions._items, 0, positions._size);
				num12 = (float?)(object)0;
				num11 = 0;
			}
			PartyWeapon trueWeapon2 = _trueWeapon;
			object obj7 = ((Equipment)trueWeapon2)._003CLevel_003Ek__BackingField - 1;
			if ((nint)obj7 <= 7)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ r15_v1+7031A20+v390 @ rax_v55*4]");
				object obj8 = 0 + 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v726 @ rcx_v58 (should have been resolved before IL gen)");
			}
			_bounceValue = 0.9f;
			float num13 = _weapon.PDuration();
			Action onComplete = FadeOutAndDispose;
			float duration = _bounceValue * 0.001f;
			Timer expireTimer = Timers.Register(duration, onComplete, null, isLooped: false, (byte)num4 != 0, (MonoBehaviour)flag2, (int)action, flag3 ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
			_expireTimer = expireTimer;
			SetupTrails();
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public void ClearObjectsHit()
	{
		if (_canClearObjectsHit)
		{
			_canClearObjectsHit = false;
			_clearObjectTime = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}

	public unsafe void SetType(int type)
	{
		//IL_0041: Expected O, but got I4
		//IL_0282: Expected I4, but got F4
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_01cc: Expected I4, but got F4
		//IL_009a: Expected I4, but got F4
		//IL_018f->IL018f: Incompatible stack heights: 1 vs 0
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4079]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag = type == 0;
		uint[] array;
		int colorIndex;
		bool num;
		if (!flag)
		{
			object obj = type - 1;
			PartyWeapon trueWeapon;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					if ((nint)obj2 != 1)
					{
						goto IL_018f;
					}
					int bounces = (int)_weapon.PAmount();
					_speed = 1.2f;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
					_bounces = bounces;
					_SpriteAnimation.SetAnimation("circle");
					trueWeapon = _trueWeapon;
					if (++trueWeapon._colorIndex >= trueWeapon._maxColors)
					{
						trueWeapon._colorIndex = 0;
					}
					array = trueWeapon.CircleColors;
				}
				else
				{
					_bounces = 0;
					int penetrating = (int)_weapon.PAmount();
					_speed = 1f;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
					_penetrating = penetrating;
					_SpriteAnimation.SetAnimation("triangle");
					trueWeapon = _trueWeapon;
					if (++trueWeapon._colorIndex >= trueWeapon._maxColors)
					{
						trueWeapon._colorIndex = 0;
					}
					array = trueWeapon.TriangleColors;
				}
			}
			else
			{
				_bounces = 1;
				int penetrating2 = (int)_weapon.PAmount();
				_speed = 0.8f;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
				_penetrating = penetrating2;
				_SpriteAnimation.SetAnimation("heart");
				trueWeapon = _trueWeapon;
				if (++trueWeapon._colorIndex >= trueWeapon._maxColors)
				{
					trueWeapon._colorIndex = 0;
				}
				array = trueWeapon.HeartColors;
			}
			colorIndex = trueWeapon._colorIndex;
			bool flag2 = trueWeapon._colorIndex >= array.Length;
			num = flag2;
		}
		else
		{
			_penetrating = 65535;
			_speed = 1f;
			_SpriteAnimation.SetAnimation("star");
			PartyWeapon trueWeapon2 = _trueWeapon;
			if (++trueWeapon2._colorIndex >= trueWeapon2._maxColors)
			{
				trueWeapon2._colorIndex = 0;
			}
			uint[] starColors = trueWeapon2.StarColors;
			colorIndex = trueWeapon2._colorIndex;
			bool flag3 = trueWeapon2._colorIndex >= starColors.Length;
			num = flag3;
			array = starColors;
		}
		_color = array[colorIndex];
		ArcadeSprite arcadeSprite = setTint(array[colorIndex]);
		goto IL_018f;
		IL_018f:
		TrailRenderer trail = _trail;
		bool flag4 = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
		float value = default(float);
		TrailRenderer.set_endColor_Injected(((UnityEngine.Object)trail).m_CachedPtr, ref *(Color*)(&value));
		bool flag5 = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
		float value2 = default(float);
		TrailRenderer.set_startColor_Injected(((UnityEngine.Object)trail).m_CachedPtr, ref *(Color*)(&value2));
	}

	public void PickType()
	{
		int[] array = new int[4] { 0, 1, 2, 3 };
		int seed = default(int);
		System.Random random = new System.Random(seed);
		seed = System.Random.GenerateSeed();
		random._002Ector(seed);
		int num = random.Next(0, array.Length);
		SetType(array[num]);
	}

	public override void OnHasHitWallPhaser(PhaserTile tile)
	{
		//IL_004b: Expected O, but got I4
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_020d: Expected O, but got I4
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Expected O, but got Unknown
		//IL_00b1: Expected O, but got I4
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		//IL_013b: Expected O, but got I4
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected O, but got Unknown
		//IL_019b: Expected O, but got F4
		int num = tile._data & 8;
		bool flag = num == 0;
		bool flag2 = num < 0;
		bool flag3 = !flag2;
		object obj = !flag;
		object obj2 = flag3 & obj;
		float num3;
		if (obj2 == null)
		{
			int num2 = tile._data & 4;
			bool flag4 = num2 == 0;
			bool flag5 = num2 < 0;
			bool flag6 = !flag5;
			object obj3 = !flag4;
			object obj4 = flag6 & obj3;
			if (obj4 == null)
			{
				num3 = _bounceValue;
				goto IL_01a7;
			}
		}
		num3 = _bounceValue ^ -0f;
		goto IL_01a7;
		IL_01a7:
		float saveVelX = _saveVelX * num3;
		_saveVelX = saveVelX;
		int num4 = tile._data & 1;
		bool flag7 = num4 == 0;
		bool flag8 = num4 < 0;
		bool flag9 = !flag8;
		object obj5 = !flag7;
		object obj6 = flag9 & obj5;
		float num6;
		if (obj6 == null)
		{
			int num5 = tile._data & 2;
			bool flag10 = num5 == 0;
			bool flag11 = num5 < 0;
			bool flag12 = !flag11;
			object obj7 = !flag10;
			object obj8 = flag12 & obj7;
			if (obj8 == null)
			{
				num6 = _bounceValue;
				goto IL_0228;
			}
		}
		num6 = _bounceValue ^ -0f;
		goto IL_0228;
		IL_0228:
		float saveVelY = _saveVelY * num6;
		_saveVelY = saveVelY;
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = (float2)_saveVelX;
		ClearObjectsHit();
	}

	public override void SetTarget(Transform target)
	{
		//IL_0176: Expected I, but got O
		//IL_0186: Expected O, but got I
		//IL_0124: Expected O, but got I
		//IL_031e: Expected F4, but got O
		//IL_0204: Expected I, but got O
		//IL_0241: Expected O, but got I
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Expected O, but got Unknown
		PartyWeapon trueWeapon = _trueWeapon;
		bool flag = !trueWeapon.FrontFiring;
		Weapon weapon = _weapon;
		bool flag3;
		if (!flag)
		{
			bool flag2 = ((Equipment)weapon)._003COwner_003Ek__BackingField.flipX;
			flag3 = (byte)((flag2 ? 1u : 0u) ^ 1u) != 0;
		}
		else
		{
			flag3 = ((Equipment)weapon)._003COwner_003Ek__BackingField.flipX;
		}
		float num = ((!flag3) ? ((float)Math.PI * 2f / 3f) : 6.806784f);
		Weapon weapon2 = _weapon;
		if (!weapon2.IsHoming)
		{
			List<float> partyAngles = _partyAngles;
			int indexInWeapon = _indexInWeapon;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ r8_v10 (System.Collections.Generic.List`1<System.Single>)+18]");
			int num2 = (int)((nint)indexInWeapon % (nint)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ r8_v10 (System.Collections.Generic.List`1<System.Single>)+18]");
			if ((nint)num2 < (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ r8_v10 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj = 0;
				float projectileSpeed = base.ProjectileSpeed;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rcx_v40+20+v84 @ rdx_v22 (System.Int32)*4]");
				float num3 = 0f * ((float)Math.PI / 180f);
				float rotation = num3 + num;
				float speed = default(float);
				Vector2 vector = SetVelocityFromRotation(rotation, speed);
			}
			else
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
		}
		else
		{
			nint num4 = (nint)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v361 @ rax_v54 (Il2CppClass<VampireSurvivors.Objects.Projectiles.PartyProjectile>)+3B0]");
			List<float> partyAngles = (List<float>)0;
			Transform transform = base.AimForNearestEnemy(rotate: false);
		}
		BaseBody baseBody = body;
		Transform transform2 = base.transform;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		Vector3 axis = default(Vector3);
		Quaternion.AngleAxis_Injected((float)this, ref axis, out Quaternion _);
		bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Quaternion value = default(Quaternion);
		Transform.set_rotation_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
		int seed = default(int);
		System.Random random = new System.Random(seed);
		seed = System.Random.GenerateSeed();
		random._002Ector(seed);
		BaseBody baseBody2 = body;
		List<float> velMultipliersX = _velMultipliersX;
		nint num5 = (nint)random;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v867 @ rax_v45 (Il2CppClass<UnityEngine.Transform>)+198] (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ rbp_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		object obj2 = default(object);
		bool flag5 = (nint)obj2 >= 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ rbp_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v507 @ rcx_v33+18]");
		bool flag6 = (nint)obj2 >= 0;
		float2 velocity = baseBody2._velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v507 @ rcx_v33+20+v505 @ rax_v46*4]");
		float2 velocity2 = velocity * 0;
		baseBody2._velocity = velocity2;
	}

	private void Bounce(Body b, bool up, bool down, bool left, bool right)
	{
		if (b == body)
		{
			ClearObjectsHit();
		}
	}

	private unsafe void SetupTrails()
	{
		//IL_01ec->IL0152: Incompatible stack heights: 2 vs 0
		//IL_00d3->IL0152: Incompatible stack heights: 2 vs 0
		//IL_011e->IL0152: Incompatible stack heights: 2 vs 0
		//IL_023c->IL0152: Incompatible stack heights: 3 vs 0
		float saturationMax = default(float);
		float valueMin = default(float);
		float valueMax = default(float);
		float alphaMin = default(float);
		Color color = UnityEngine.Random.ColorHSV(0f, 1f, 0.35f, saturationMax, valueMin, valueMax, alphaMin, 0.35f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		if ((object)_trail != null)
		{
			_trail.time = 0.2f;
			TrailRenderer trail = _trail;
			if ((object)_trail != null)
			{
				bool flag = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
				float value = default(float);
				TrailRenderer.set_endColor_Injected(((UnityEngine.Object)trail).m_CachedPtr, ref *(Color*)(&value));
				bool flag2 = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
				float value2 = default(float);
				TrailRenderer.set_startColor_Injected(((UnityEngine.Object)trail).m_CachedPtr, ref *(Color*)(&value2));
				if ((object)_trail != null)
				{
					_trail.endWidth = 0.02f;
					_trail.startWidth = 0.02f;
					Sprite sprite = default(Sprite);
					RenderingExtensions.SetMaterialToPackedSpriteInternal((Renderer)_trail, sprite, true);
					if ((object)_trail != null)
					{
						Material material = ((Renderer)_trail).GetMaterial();
						RenderingExtensions.SetAlpha(material, 0.6f);
						Renderer trail2 = _trail;
						if ((object)_trail != null)
						{
							bool flag3 = ((UnityEngine.Object)trail2).m_CachedPtr == (IntPtr)0;
							TrailRenderer.Clear_Injected(((UnityEngine.Object)trail2).m_CachedPtr);
							if ((object)_trail != null)
							{
								_trail.emitting = true;
								TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_trail);
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void FadeOutAndDispose()
	{
		//IL_0148: Expected I, but got O
		Material material = ((Renderer)_trail).GetMaterial();
		TweenerCore<Color, Color, ColorOptions> tweenerCore = ShortcutExtensions.DOFade(material, 0f, 0.1f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleSprite.DOFade(_renderer, 0f, 0.1f);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v417 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.PartyProjectile>)+370]");
		TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
		nint num = (nint)this;
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Weapon weapon = _weapon;
		if (weapon._explodeOnExpire)
		{
			float2 pos = base.position;
			Projectile projectile = weapon.SpawnExplosionAt(pos, 0, 1, 0f);
		}
	}

	public override void Despawn()
	{
		_expireTimer.Cancel();
		base.Despawn();
	}

	public override void InternalUpdate()
	{
		//IL_003c: Expected O, but got I4
		//IL_00f8: Expected F4, but got O
		//IL_0146: Expected F4, but got I
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		int num = renderer.pixelHeight >> 31;
		object obj = renderer.pixelHeight - num;
		object obj2 = obj >> 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int sortingOrder = default(int);
		_renderer.sortingOrder = sortingOrder;
		_trail.sortingOrder = sortingOrder;
		float deltaTime = PauseSystem.DeltaTime;
		float num2 = (_clearObjectTime = deltaTime + _clearObjectTime);
		float hitBoxDelay = _trueWeapon.HitBoxDelay;
		bool flag = num2 < hitBoxDelay;
		bool canClearObjectsHit = !flag;
		_canClearObjectsHit = canClearObjectsHit;
		BaseBody baseBody = body;
		float saveVelX = (float)baseBody._velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187032E5Dh\"");
		if ((object)baseBody._velocity == null)
		{
			saveVelX = _saveVelX;
		}
		_saveVelX = saveVelX;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rax_v16 (BaseBody)+74]");
		float saveVelY = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187032E7Eh\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rax_v16 (BaseBody)+74]");
		if ((nint)0 == 0)
		{
			saveVelY = _saveVelY;
		}
		_saveVelY = saveVelY;
		float num3 = SelfGravity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rax_v16 (BaseBody)+74]");
		float num4 = num3 + 0f;
	}

	private void ClearPositions()
	{
		List<Transform> positions = _positions;
		int version = positions._version + 1;
		positions._version = version;
		positions._size = 0;
		if (positions._size > 0)
		{
			Array.Clear(positions._items, 0, positions._size);
		}
	}

	protected override void OnHasHitAnObject(IDamageable target)
	{
		OnHasHitAnObjectLogic(target, triggerHit: true);
	}

	protected override void OnHasHitAnotherPlayerObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 2 Invalid \"Jump target not found in method: 0x187032F50\"");
	}

	private void OnHasHitAnObjectLogic(IDamageable target, bool triggerHit)
	{
		//IL_0113: Expected O, but got F4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		if (_bounces <= 0)
		{
			if (triggerHit && --_penetrating <= 0)
			{
				FadeOutAndDispose();
			}
			return;
		}
		float saveVelY = _saveVelY * -1f;
		int bounces = _bounces - 1;
		_bounces = bounces;
		float num = (_saveVelX *= -1f);
		_saveVelY = saveVelY;
		BaseBody baseBody = body;
		baseBody._velocity = (float2)num;
		ClearObjectsHit();
	}

	public PartyProjectile()
	{
		List<Transform> positions = new List<Transform>();
		_positions = positions;
		_color = 16711680u;
		_velMultipliersX = new List<float>();
		_velMultipliersY = new List<float>();
		_bounceValue = 0.9f;
		_maxStartingFrame = 23;
		BouncePositions = new List<Vector2>();
		SelfGravity = -1.8f;
		base._002Ector();
	}
}
