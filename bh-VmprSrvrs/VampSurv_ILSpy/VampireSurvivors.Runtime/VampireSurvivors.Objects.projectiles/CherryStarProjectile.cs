using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class CherryStarProjectile : Projectile
{
	private TrailRenderer _trail;

	protected List<float2> _positions;

	protected float _maxPositions = 400f;

	protected uint _color = 16711680u;

	private float2 _target;

	private List<float2> _targets;

	private bool _canUpdate;

	private Timer _bounceTimer;

	private CherryStarsWeapon _trueWeapon;

	private float _maxStars = 7f;

	private List<PhaserSprite> _stars1;

	private List<PhaserSprite> _stars2;

	private float _bouncedTimes;

	private float _sin;

	private float _cos;

	private int starIndex;

	protected unsafe override void Awake()
	{
		//IL_0083: Invalid comparison between F4 and I4
		//IL_020a: Invalid comparison between F4 and I4
		//IL_00a3: Expected O, but got I4
		//IL_0232: Expected O, but got I4
		//IL_00c0: Expected O, but got I4
		//IL_03f8: Expected O, but got I4
		//IL_0406: Expected O, but got I4
		//IL_0434: Expected I4, but got I8
		//IL_0442: Expected O, but got I4
		//IL_024f: Expected O, but got I4
		//IL_00dc: Expected O, but got I4
		//IL_026b: Expected O, but got I4
		//IL_0293: Expected O, but got Ref
		//IL_049c: Expected O, but got I4
		//IL_04aa: Expected O, but got I4
		//IL_04b8: Expected O, but got I4
		//IL_04e6: Expected I4, but got I8
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_01d9: Invalid comparison between F4 and O
		//IL_01e7: Expected F4, but got O
		//IL_0185: Expected O, but got I
		//IL_051d: Expected I, but got O
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_0387: Expected O, but got Unknown
		//IL_0391: Invalid comparison between F4 and O
		//IL_039f: Expected F4, but got O
		//IL_0333: Expected O, but got I
		//IL_0573: Expected O, but got I4
		//IL_0581: Expected O, but got I4
		//IL_058f: Expected O, but got I4
		//IL_05bd: Expected I4, but got I8
		base.Awake();
		_isCullable = false;
		List<float2> positions = new List<float2>();
		_positions = positions;
		List<float2> targets = new List<float2>();
		_targets = targets;
		List<PhaserSprite> stars = new List<PhaserSprite>();
		_stars1 = stars;
		List<PhaserSprite> stars2 = new List<PhaserSprite>();
		_stars2 = stars2;
		float maxStars = _maxStars;
		object[] items = default(object[]);
		if (_maxStars > 0f)
		{
			Vector2 vector = (Vector2)0;
			bool flag;
			do
			{
				PhaserWorld instance = PhaserWorld.Instance;
				PhaserSprite phaserSprite = instance.AddPhaserSprite((Vector2)0, "vfx", "2Spell4Blue");
				PhaserSprite phaserSprite2 = phaserSprite.setScale(1f, (float?)(object)1);
				PhaserSprite phaserSprite3 = phaserSprite2.setVisible(visible: false);
				PhaserSprite phaserSprite4 = phaserSprite3.setAlpha(0.65f);
				List<object> stars3 = (List<object>)(object)_stars1;
				int version = stars3._version + 1;
				stars3._version = version;
				items = stars3._items;
				if (stars3._size >= items.Length)
				{
					stars3.AddWithResize((object)phaserSprite4);
					PhaserSprite phaserSprite5 = (PhaserSprite)0;
				}
				else
				{
					int num = stars3._size + 1;
					stars3._size = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					PhaserSprite phaserSprite5 = phaserSprite4;
				}
				vector++;
				float maxStars2 = _maxStars;
				flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)maxStars2) > System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector);
				maxStars = (float)vector;
			}
			while (flag);
		}
		float maxStars3 = _maxStars;
		bool flag2 = !(_maxStars > 0f);
		object[] array = items;
		if (!flag2)
		{
			Vector2 vector2 = (Vector2)0;
			object obj = default(object);
			bool flag3;
			object obj2 = default(object);
			do
			{
				PhaserWorld instance2 = PhaserWorld.Instance;
				PhaserSprite phaserSprite6 = instance2.AddPhaserSprite((Vector2)0, "vfx", "2Spell4Red");
				PhaserSprite phaserSprite7 = phaserSprite6.setScale(1f, (float?)(object)1);
				Transform transform = phaserSprite7.transform;
				transform.localEulerAngles = (Vector3)(&obj);
				PhaserSprite phaserSprite8 = phaserSprite7.setVisible(visible: false);
				PhaserSprite phaserSprite9 = phaserSprite8.setAlpha(0.65f);
				List<object> stars4 = (List<object>)(object)_stars2;
				int version2 = stars4._version + 1;
				stars4._version = version2;
				array = stars4._items;
				if (stars4._size >= array.Length)
				{
					stars4.AddWithResize((object)phaserSprite9);
					PhaserSprite phaserSprite5 = (PhaserSprite)0;
				}
				else
				{
					int num2 = stars4._size + 1;
					stars4._size = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					PhaserSprite phaserSprite5 = phaserSprite9;
				}
				maxStars3 = _maxStars;
				vector2++;
				float maxStars4 = _maxStars;
				flag3 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)maxStars4) > System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector2);
				maxStars = (float)vector2;
				obj = obj2;
			}
			while (flag3);
		}
		TweenConfig tweenConfig = new TweenConfig();
		PhaserSprite[] targets2 = _stars1.ToArray();
		tweenConfig.targets = targets2;
		tweenConfig.angle = (float?)(object)1;
		tweenConfig.scaleX = (float?)(object)1;
		tweenConfig.duration = 1000f;
		tweenConfig.yoyo = true;
		tweenConfig.repeat = -1;
		tweenConfig.scaleY = (float?)(object)1;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		TweenConfig tweenConfig2 = new TweenConfig();
		PhaserSprite[] targets3 = _stars2.ToArray();
		tweenConfig2.targets = targets3;
		tweenConfig2.angle = (float?)(object)1;
		tweenConfig2.scaleX = (float?)(object)1;
		tweenConfig2.scaleY = (float?)(object)1;
		tweenConfig2.duration = 1039f;
		tweenConfig2.yoyo = true;
		tweenConfig2.repeat = -1;
		MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
		TweenConfig tweenConfig3 = new TweenConfig();
		object[] array2 = new object[1];
		nint num3 = (nint)array2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj3 = default(object);
		if (obj3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig3.targets = array2;
			tweenConfig3.angle = (float?)(object)1;
			tweenConfig3.scaleX = (float?)(object)1;
			tweenConfig3.scaleY = (float?)(object)1;
			tweenConfig3.duration = 1000f;
			tweenConfig3.yoyo = true;
			tweenConfig3.repeat = -1;
			MultiTargetTween multiTargetTween3 = Tweens.Add(tweenConfig3);
			TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_trail);
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_000e: Expected O, but got I4
		//IL_01b7: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_00e6: Expected O, but got I4
		//IL_00e6: Expected O, but got I4
		//IL_0105: Expected O, but got I4
		//IL_00ab: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		float? trueWeapon;
		if ((object)weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_0190;
		}
		nint num = (nint)typeof(CherryStarsWeapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.CherryStarsWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.CherryStarsWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rax_v25+FFFFFFF8+v67 @ rax_v20*8]");
			if (0 == (nint)typeof(CherryStarsWeapon))
			{
				obj3 = 1;
				goto IL_019f;
			}
		}
		obj3 = 0;
		goto IL_019f;
		IL_019f:
		bool flag = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)weapon;
		}
		goto IL_0190;
		IL_0190:
		_trueWeapon = (CherryStarsWeapon)trueWeapon;
		BaseBody baseBody = body.setCircle(9f, (float?)(object)1, (float?)(object)1);
		_isCullable = false;
		ArcadeSprite arcadeSprite = setScale(2f, (float?)(object)0);
		_color = 16777215u;
		TrailRenderer trailRenderer = RenderingExtensions.SetAlpha(_trail, 0.5f);
		ArcadeSprite arcadeSprite2 = setAlpha(1f);
		clearPositions();
		PickNewTarget();
		_canUpdate = true;
	}

	public override void Despawn()
	{
	}

	public void ForceDespawn()
	{
		if (_stars1 != null)
		{
			List<PhaserSprite>.Enumerator enumerator = default(List<PhaserSprite>.Enumerator);
			if (enumerator.MoveNext())
			{
				PhaserSprite phaserSprite = null;
				throw new NullReferenceException();
			}
			if (_stars2 != null)
			{
				List<PhaserSprite>.Enumerator enumerator2 = default(List<PhaserSprite>.Enumerator);
				if (enumerator2.MoveNext())
				{
					PhaserSprite phaserSprite = null;
					throw new NullReferenceException();
				}
				base.Despawn();
				return;
			}
		}
		throw new NullReferenceException();
	}

	public void PickNewTarget()
	{
		//IL_01f7: Expected O, but got F4
		//IL_023d: Expected O, but got F4
		//IL_0279: Expected O, but got F4
		//IL_0143: Expected O, but got F4
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Expected F4, but got Unknown
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Expected F4, but got Unknown
		//IL_02aa: Expected O, but got F4
		//IL_02c0: Expected O, but got I
		//IL_02d6: Expected O, but got I
		//IL_0139->IL0139: Incompatible stack heights: 1 vs 0
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float num = renderer.width;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		CherryStarsWeapon trueWeapon = _trueWeapon;
		if (renderer.width > renderer2.height)
		{
			num = renderer2.height;
		}
		float2 float5 = ((Equipment)trueWeapon)._003COwner_003Ek__BackingField.position;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num2 = (float)obj2 - 0.5f;
		CherryStarsWeapon trueWeapon2 = _trueWeapon;
		float num3 = num2 * num;
		float num4 = (float)float5 - num3;
		float2 float6 = ((Equipment)trueWeapon2)._003COwner_003Ek__BackingField.position;
		object obj3 = UnityEngine.Random.value;
		float num5 = num3 - 0.5f;
		float num6 = num5 * num;
		object obj4 = default(object);
		float num7 = num6 + (float)obj4;
		float2 float7 = default(float2);
		_targets.Add(float7);
		object obj5 = UnityEngine.Random.value;
		bool flag = !(0.3f > num3);
		float2 item = float7;
		if (!flag)
		{
			List<float2> targets = _targets;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rax_v45 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
			bool flag2 = (nint)0 <= (nint)2;
			item = float7;
			if (!flag2)
			{
				object obj6 = UnityEngine.Random.value;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rax_v45 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
				object obj7 = -3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rax_v45 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
				object obj8 = -2;
				if (num3 < 0.5f)
				{
					obj8 = obj7;
				}
				object obj9 = obj8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rax_v45 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
				bool flag3 = (nint)obj9 >= 0;
				base.position = float7;
				item = float7;
			}
		}
		_target = (float2)num4;
		float2 float8 = base.position;
		float2 float9 = base.position;
		float num8 = (float)obj4 - num7;
		((List<float2>)(object)this).Add(item);
		((List<float2>)(object)this).Add(item);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		float sin = num8 & 0;
		_sin = sin;
		((List<float2>)(object)this).Add(item);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		float cos = num8 & 0;
		_cos = cos;
	}

	protected override void OnUpdate()
	{
		//IL_0165: Invalid comparison between F4 and O
		//IL_0196: Invalid comparison between F4 and I
		//IL_013a: Invalid comparison between F4 and O
		//IL_01c7: Invalid comparison between F4 and I
		if (!_canUpdate)
		{
			return;
		}
		float2 float5 = base.position;
		CherryStarsWeapon trueWeapon = _trueWeapon;
		float2 float6 = ((Equipment)trueWeapon)._003COwner_003Ek__BackingField.position;
		object obj = default(object);
		object obj2 = default(object);
		double num = (double)obj - (double)obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm1,qword ptr [188A106E0h]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm0,xmm1\"");
		int sortingOrder = Convert.ToInt32(num);
		_trail.sortingOrder = sortingOrder;
		CherryStarsWeapon trueWeapon2 = _trueWeapon;
		float num2 = trueWeapon2.PSpeed();
		float deltaTime = PauseSystem.DeltaTime;
		double num3 = num * 0.5;
		double num4 = num3 * 0.009999999776482582;
		float num5 = deltaTime * (float)num4;
		float num6 = num5 * 1000f;
		float2 float7 = base.position;
		float num7 = num6 * _cos;
		float2 target = _target;
		if (target <= float7 != 0)
		{
			float num8 = (float)float7 - num7;
			float2 target2 = _target;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num8) >= System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref target2))
			{
				goto IL_0436;
			}
		}
		float num9 = (float)float7 + num7;
		float2 target3 = _target;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num9) > System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref target3))
		{
			goto IL_0177;
		}
		goto IL_0436;
		IL_01a8:
		float num11 = default(float);
		float num10 = (float)obj + num11;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.CherryStarProjectile)+EC]");
		if (num10 > 0f)
		{
			goto IL_01d9;
		}
		goto IL_0475;
		IL_01d9:
		float2 float8 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 000000018701B5EEh\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.CherryStarProjectile)+EC]");
		if (obj != null)
		{
			return;
		}
		List<PhaserSprite> stars = _stars1;
		int num12 = starIndex;
		if (starIndex < stars._size)
		{
			PhaserSprite[] items = stars._items;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
			PhaserSprite phaserSprite = items[num12].setVisible(visible: true);
			PhaserSprite phaserSprite2 = phaserSprite.setAlpha(0.65f);
			List<PhaserSprite> stars2 = _stars2;
			int num13 = starIndex;
			if (starIndex < stars2._size)
			{
				PhaserSprite[] items2 = stars2._items;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
				PhaserSprite phaserSprite3 = items2[num13].setVisible(visible: true);
				PhaserSprite phaserSprite4 = phaserSprite3.setAlpha(0.65f);
				int num14 = starIndex + 1;
				starIndex = num14;
				PickNewTarget();
				_canUpdate = false;
				if (_bounceTimer != null)
				{
					_bounceTimer.Cancel();
				}
				if (++_bouncedTimes < _maxStars)
				{
					StartTimer();
					return;
				}
				starIndex = 0;
				ExplodeAll();
				_bouncedTimes = 0f;
				clearPositions();
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_0475:
		float2 float9 = default(float2);
		base.position = float9;
		float2 float10 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 000000018701B5EEh\"");
		if ((object)float10 != (object)_target)
		{
			return;
		}
		goto IL_01d9;
		IL_0436:
		float2 float11 = base.position;
		num11 = num6 * _sin;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.CherryStarProjectile)+EC]");
		if (0 <= (nint)obj)
		{
			goto IL_0177;
		}
		goto IL_01a8;
		IL_0177:
		float num15 = (float)obj - num11;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.CherryStarProjectile)+EC]");
		if (num15 < 0f)
		{
			goto IL_01a8;
		}
		goto IL_0475;
	}

	public void MakeStar()
	{
		List<PhaserSprite> stars = _stars1;
		int num = starIndex;
		if (starIndex < stars._size)
		{
			PhaserSprite[] items = stars._items;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
			PhaserSprite phaserSprite = items[num].setVisible(visible: true);
			PhaserSprite phaserSprite2 = phaserSprite.setAlpha(0.65f);
			List<PhaserSprite> stars2 = _stars2;
			int num2 = starIndex;
			if (starIndex < stars2._size)
			{
				PhaserSprite[] items2 = stars2._items;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
				PhaserSprite phaserSprite3 = items2[num2].setVisible(visible: true);
				PhaserSprite phaserSprite4 = phaserSprite3.setAlpha(0.65f);
				int num3 = starIndex + 1;
				starIndex = num3;
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void CheckTimer()
	{
		if (_bounceTimer != null)
		{
			_bounceTimer.Cancel();
		}
		bool flag = !(++_bouncedTimes < _maxStars);
		CherryStarProjectile cherryStarProjectile = this;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 38 Invalid \"Jump target not found in method: 0x18701B820\"");
			CherryStarProjectile cherryStarProjectile2 = default(CherryStarProjectile);
			cherryStarProjectile = cherryStarProjectile2;
		}
		cherryStarProjectile.starIndex = 0;
		ExplodeAll();
		cherryStarProjectile._bouncedTimes = 0f;
		cherryStarProjectile.clearPositions();
	}

	public void StartTimer()
	{
		Action onComplete = delegate
		{
			TrailRenderer trailRenderer = RenderingExtensions.SetAlpha(_trail, 0.5f);
			_canUpdate = true;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer bounceTimer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_bounceTimer = bounceTimer;
	}

	public unsafe void ExplodeAll()
	{
		//IL_0736: Invalid comparison between F4 and I4
		//IL_0748: Expected F4, but got I4
		//IL_02b2: Expected I, but got O
		//IL_032a: Expected O, but got I4
		//IL_03b6: Expected I, but got O
		//IL_043c: Expected O, but got I4
		//IL_08ff: Expected I, but got O
		//IL_0915: Expected O, but got I
		//IL_091e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0923: Expected O, but got Unknown
		//IL_04c6: Expected I, but got O
		//IL_0949: Expected O, but got I4
		//IL_0960: Expected I, but got I8
		//IL_04af: Expected I, but got I8
		//IL_01e7: Expected O, but got I
		//IL_020d: Invalid comparison between F4 and I4
		//IL_021b: Expected F4, but got I4
		//IL_055f: Expected O, but got I4
		//IL_0602: Expected O, but got I4
		//IL_067b: Expected I, but got O
		//IL_0691: Expected O, but got I
		//IL_069a: Unknown result type (might be due to invalid IL or missing references)
		//IL_069f: Expected O, but got Unknown
		//IL_0708: Expected I, but got O
		//IL_09ab: Expected I, but got I8
		//IL_06f1: Expected I, but got I8
		//IL_004f->IL071a: Incompatible stack heights: 1 vs 0
		//IL_0893->IL071a: Incompatible stack heights: 1 vs 0
		//IL_0092->IL071a: Incompatible stack heights: 2 vs 0
		//IL_02f7->IL071a: Incompatible stack heights: 1 vs 0
		//IL_00c5->IL071a: Incompatible stack heights: 2 vs 0
		//IL_02d5->IL02d5: Incompatible stack heights: 2 vs 1
		//IL_07b7->IL071a: Incompatible stack heights: 3 vs 0
		//IL_0382->IL071a: Incompatible stack heights: 1 vs 0
		//IL_011e->IL071a: Incompatible stack heights: 4 vs 0
		//IL_08ed->IL071a: Incompatible stack heights: 2 vs 0
		//IL_0161->IL071a: Incompatible stack heights: 5 vs 0
		//IL_0194->IL071a: Incompatible stack heights: 5 vs 0
		//IL_03fb->IL071a: Incompatible stack heights: 2 vs 0
		//IL_03d9->IL03d9: Incompatible stack heights: 3 vs 2
		//IL_0810->IL071a: Incompatible stack heights: 6 vs 0
		//IL_01c3->IL071a: Incompatible stack heights: 6 vs 0
		//IL_050e->IL071a: Incompatible stack heights: 2 vs 0
		//IL_0238->IL0815: Incompatible stack heights: 6 vs 0
		//IL_023d->IL023d: Incompatible stack heights: 6 vs 0
		//IL_053a->IL071a: Incompatible stack heights: 2 vs 0
		//IL_05b1->IL071a: Incompatible stack heights: 2 vs 0
		//IL_05dd->IL071a: Incompatible stack heights: 2 vs 0
		float maxStars = _maxStars;
		bool flag = !(_maxStars > 0f);
		float num = 0f;
		int num2 = 0;
		if (flag)
		{
			goto IL_023d;
		}
		float2 pos = default(float2);
		bool flag9 = default(bool);
		while (true)
		{
			List<PhaserSprite> stars = _stars1;
			if (_stars1 == null)
			{
				break;
			}
			bool flag2 = num2 >= stars._size;
			PhaserSprite[] items = stars._items;
			if (stars._items == null)
			{
				break;
			}
			bool flag3 = num2 >= items.Length;
			if ((object)items[num2] == null)
			{
				break;
			}
			Transform transform = items[num2].transform;
			if ((object)transform == null)
			{
				break;
			}
			bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			List<PhaserSprite> stars2 = _stars1;
			if (_stars1 == null)
			{
				break;
			}
			bool flag5 = num2 >= stars2._size;
			PhaserSprite[] items2 = stars2._items;
			if (stars2._items == null)
			{
				break;
			}
			bool flag6 = num2 >= items2.Length;
			if ((object)items2[num2] == null)
			{
				break;
			}
			Transform transform2 = items2[num2].transform;
			if ((object)transform2 == null)
			{
				break;
			}
			bool flag7 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
			Weapon trueWeapon = _trueWeapon;
			if ((object)_trueWeapon == null)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ r8_v16 (VampireSurvivors.Objects.Weapons.Weapon)+178]");
			if ((nint)0 == 0)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ r8_v16 (VampireSurvivors.Objects.Weapons.Weapon)+178]");
			Projectile projectile = ((BulletPool)0).SpawnAt(pos, _trueWeapon, num2);
			num = _maxStars;
			int num3 = num2 + 1;
			bool flag8 = _maxStars > (float)num3;
			maxStars = num3;
			flag9 = flag9;
			num2 = num3;
			if (flag8)
			{
				continue;
			}
			goto IL_023d;
		}
		goto IL_071a;
		IL_071a:
		throw new NullReferenceException();
		IL_0972:
		float num4 = _maxStars * 50f;
		float num5 = num4 + 500f;
		Action action;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		float duration = num5 * 0.001f;
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration, action, null, isLooped: false, flag9, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		return;
		IL_0940:
		Transform transform3 = (Transform)24;
		TweenCallback tweenCallback;
		((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
		TweenConfig tweenConfig;
		tweenConfig.onComplete = tweenCallback;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		TweenConfig tweenConfig2 = new TweenConfig();
		if (_stars1 != null)
		{
			PhaserSprite[] targets = _stars1.ToArray();
			if (tweenConfig2 != null)
			{
				tweenConfig2.targets = targets;
				tweenConfig2.alpha = (float?)(object)1;
				tweenConfig2.duration = 500f;
				tweenConfig2.delay = 500f;
				MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
				TweenConfig tweenConfig3 = new TweenConfig();
				if (_stars2 != null)
				{
					PhaserSprite[] targets2 = _stars2.ToArray();
					if (tweenConfig3 != null)
					{
						tweenConfig3.targets = targets2;
						tweenConfig3.alpha = (float?)(object)1;
						tweenConfig3.duration = 500f;
						tweenConfig3.delay = 500f;
						MultiTargetTween multiTargetTween3 = Tweens.Add(tweenConfig3);
						action = null;
						nint num6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1053 @ r10_v15 (Il2CppMethodInfo)+8]");
						((Delegate)action).method_ptr = (IntPtr)0;
						((Delegate)action).method = (nint)__ldftn(CherryStarProjectile._003CExplodeAll_003Eb__25_0);
						((Delegate)action).m_target = this;
						((Delegate)action).method_code = (IntPtr)action;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1053 @ r10_v15 (Il2CppMethodInfo)+4C]");
						object obj = (nint)0 >> 4;
						object obj2 = obj & 1;
						nint num7;
						if (obj2 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1053 @ r10_v15 (Il2CppMethodInfo)+52]");
							if ((nint)0 == 0)
							{
								num7 = unchecked((nint)6447293664L);
								goto IL_0972;
							}
						}
						((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
						num7 = ((Delegate)action).method_ptr;
						goto IL_0972;
					}
				}
			}
		}
		goto IL_071a;
		IL_023d:
		TweenConfig tweenConfig4 = new TweenConfig();
		object[] array = new object[1];
		TrailRenderer trail = _trail;
		if ((object)_trail != null)
		{
			bool flag10 = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
			IntPtr material_Injected = Renderer.GetMaterial_Injected(((UnityEngine.Object)trail).m_CachedPtr);
			Material material = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Material>(material_Injected);
			if (array != null)
			{
				if ((object)material != null)
				{
					nint num8 = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj3 = default(object);
					bool flag11 = obj3 == null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if (tweenConfig4 != null)
				{
					tweenConfig4.targets = array;
					tweenConfig4.duration = 500f;
					tweenConfig4.alpha = (float?)(object)1;
					MultiTargetTween multiTargetTween4 = Tweens.Add(tweenConfig4);
					tweenConfig = new TweenConfig();
					object[] array2 = new object[1];
					Transform trail2 = (Transform)(object)_trail;
					if ((object)_trail != null)
					{
						bool flag12 = ((UnityEngine.Object)trail2).m_CachedPtr == (IntPtr)0;
						IntPtr material_Injected2 = Renderer.GetMaterial_Injected(((UnityEngine.Object)trail2).m_CachedPtr);
						Material material2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Material>(material_Injected2);
						if (array2 != null)
						{
							if ((object)material2 != null)
							{
								nint num9 = (nint)array2;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								object obj4 = default(object);
								bool flag13 = obj4 == null;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							if (tweenConfig != null)
							{
								tweenConfig.targets = array2;
								tweenConfig.duration = 500f;
								tweenConfig.delay = 500f;
								tweenConfig.alpha = (float?)(object)1;
								tweenCallback = null;
								nint num10 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ r10_v14 (Il2CppMethodInfo)+8]");
								((Delegate)tweenCallback).method_ptr = (IntPtr)0;
								((Delegate)tweenCallback).method = (nint)__ldftn(CherryStarProjectile._003CExplodeAll_003Eb__25_1);
								((Delegate)tweenCallback).m_target = this;
								((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ r10_v14 (Il2CppMethodInfo)+4C]");
								object obj5 = (nint)0 >> 4;
								object obj6 = obj5 & 1;
								nint num11;
								if (obj6 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ r10_v14 (Il2CppMethodInfo)+52]");
									if ((nint)0 == 0)
									{
										num11 = unchecked((nint)6447293664L);
										goto IL_0940;
									}
								}
								((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
								num11 = ((Delegate)tweenCallback).method_ptr;
								goto IL_0940;
							}
						}
					}
				}
			}
		}
		goto IL_071a;
	}

	protected void clearPositions()
	{
		List<float2> positions = new List<float2>();
		_positions = positions;
	}

	public float Approach(float start, float end, float shift)
	{
		if (!(end > start))
		{
			float num = start - shift;
			if (num < end)
			{
				num = end;
			}
			return num;
		}
		float num2 = start + shift;
		if (num2 > end)
		{
			num2 = end;
		}
		return num2;
	}

	public override void SetTarget(Transform target)
	{
	}

	public override void SetNullTarget()
	{
	}

	private void _003CStartTimer_003Eb__24_0()
	{
		TrailRenderer trailRenderer = RenderingExtensions.SetAlpha(_trail, 0.5f);
		_canUpdate = true;
	}

	private void _003CExplodeAll_003Eb__25_1()
	{
		TrailRenderer trail = _trail;
		bool flag = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 43 ConditionalJump @-1, v51 @ ZF_v5 (System.Boolean) --- -1 Nop");
		/*Error: End of method reached without returning.*/;
	}

	private void _003CExplodeAll_003Eb__25_0()
	{
		StartTimer();
	}
}
