using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Events;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class HatProjectile : Projectile
{
	[NonSerialized]
	public float2 PosOffset;

	private List<HatType> _hatTypes;

	public float Acceleration;

	private float _accelerationOffset;

	private Vector2 _velocity;

	private MultiTargetTween _accelTween;

	private MultiTargetTween _scaleTween;

	private bool _followOwner;

	private HatWeapon _trueWeapon;

	private HatType _hatType;

	private int _moveDownCount;

	private Timer _triggerTimer;

	private Timer _accelTimer;

	private MultiTargetTween _moveTween;

	private float _hatLayerOffset;

	private bool _shouldSpin;

	protected override void Awake()
	{
		base.Awake();
		_bounceActivated = false;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0069: Expected I, but got O
		//IL_0071: Expected I, but got O
		//IL_0081: Expected O, but got I
		//IL_0101: Expected O, but got I4
		//IL_00bd: Expected O, but got I
		//IL_056a: Expected O, but got I4
		//IL_010e: Expected I4, but got O
		//IL_00f3: Expected O, but got I4
		//IL_0174: Expected O, but got I4
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_01be: Expected O, but got I4
		//IL_05c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ca: Expected O, but got Unknown
		//IL_05da: Unknown result type (might be due to invalid IL or missing references)
		//IL_05df: Expected O, but got Unknown
		//IL_022e: Expected O, but got I
		//IL_0243: Expected O, but got I
		//IL_0253: Expected O, but got I
		//IL_063b: Expected O, but got F4
		//IL_0670: Expected F4, but got O
		//IL_03dd: Expected O, but got I4
		//IL_0410: Invalid comparison between I4 and F4
		//IL_06b7: Expected O, but got I4
		//IL_0321: Expected O, but got I
		//IL_0459: Expected O, but got I
		//IL_0336: Expected O, but got I
		//IL_0346: Expected O, but got I
		//IL_04bf: Invalid comparison between F4 and I4
		//IL_0645->IL05a3: Incompatible stack heights: 1 vs 0
		//IL_034b->IL05e9: Incompatible stack heights: 2 vs 1
		//IL_0473->IL067e: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		BaseBody baseBody = body.setCircle(6f, (float?)(object)1, (float?)(object)1);
		bool flag;
		nint num;
		if ((object)weapon == null)
		{
			num = 1;
			flag = false;
			goto IL_0560;
		}
		nint num2 = (nint)typeof(HatWeapon);
		num = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ rdx_v43 (Il2CppClass<VampireSurvivors.Objects.Weapons.HatWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ rdx_v43 (Il2CppClass<VampireSurvivors.Objects.Weapons.HatWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v485 @ rax_v75+FFFFFFF8+v429 @ rax_v70*8]");
			if (0 == (nint)typeof(HatWeapon))
			{
				obj3 = 1;
				goto IL_056f;
			}
		}
		obj3 = 0;
		goto IL_056f;
		IL_056f:
		bool flag2 = obj3 == null;
		flag = false;
		if (!flag2)
		{
			flag = (byte)(int)weapon != 0;
		}
		goto IL_0560;
		IL_0560:
		_trueWeapon = (HatWeapon)flag;
		BaseBody baseBody2 = body;
		_isCullable = false;
		baseBody2._enable = false;
		Acceleration = 0f;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		object obj4 = renderer.pixelHeight + renderer.pixelHeight;
		object obj5 = obj4 - index;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int sortingOrder = default(int);
		_renderer.sortingOrder = sortingOrder;
		Weapon weapon2 = _weapon;
		_moveDownCount = index;
		PosOffset = (float2)0;
		_ = 1051931443;
		List<Vector2> headOffsets = ((Equipment)weapon2)._003COwner_003Ek__BackingField.GetHeadOffsets();
		if (headOffsets != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ rax_v23 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			bool flag3 = (nint)0 <= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ rax_v23 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rax_v58+20]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rax_v58+24]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ rax_v23 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)0 > (nint)1)
			{
				if (index == 0)
				{
					HatWeapon trueWeapon = _trueWeapon;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ rax_v23 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
					int dragogionRand = UnityEngine.Random.Range(0, 0);
					trueWeapon.DragogionRand = dragogionRand;
				}
				HatWeapon trueWeapon2 = _trueWeapon;
				int dragogionRand2 = trueWeapon2.DragogionRand;
				int dragogionRand3 = trueWeapon2.DragogionRand;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ rax_v23 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				bool flag4 = (nint)dragogionRand3 >= (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ rax_v23 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rcx_v44+20+v172 @ rax_v62 (System.Int32)*8]");
				obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rcx_v44+24+v172 @ rax_v62 (System.Int32)*8]");
				obj8 = 0;
			}
			float num4 = (float)obj7 * 0.01f;
			float num5 = (float)obj8 * 0.01f;
			float num6 = (float)PosOffset + num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.HatProjectile)+D4]");
			float num7 = 0f + num5;
			PosOffset = (float2)num6;
		}
		HatWeapon trueWeapon3 = _trueWeapon;
		PosOffset = PosOffset;
		object obj10 = _moveDownCount * _hatLayerOffset;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.HatProjectile)+D4]");
		object obj11 = 0 + obj10;
		float2 float5 = ((Equipment)trueWeapon3)._003COwner_003Ek__BackingField.position;
		float2 float6 = default(float2);
		base.position = float6;
		_followOwner = true;
		float num8 = _trueWeapon.PAmount();
		HatWeapon trueWeapon4 = _trueWeapon;
		int num9 = trueWeapon4.MaxHats;
		bool flag5 = trueWeapon4.MaxHats > (nint)float6;
		float2 float7 = float6;
		if (!flag5)
		{
			float7 = (float2)trueWeapon4.MaxHats;
		}
		bool flag6 = _moveDownCount <= 1;
		float num10 = (float)float7;
		HatType hatType;
		if (!flag6)
		{
			num9 = _moveDownCount;
			num10 = (float)float7 - 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187049EF4h\"");
			if ((float)_moveDownCount == num10)
			{
				hatType = HatType.TopHat;
				goto IL_067e;
			}
		}
		List<HatType> hatTypes = _hatTypes;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rbx_v12 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.HatType>)+18]");
		object obj12 = UnityEngine.Random.RandomRangeInt(0, 0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rbx_v12 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.HatType>)+18]");
		bool flag7 = (nint)obj12 >= 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rbx_v12 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.HatType>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rcx_v40+20+v176 @ rax_v53*4]");
		hatType = HatType.Normal;
		goto IL_067e;
		IL_067e:
		_hatType = hatType;
		setHatStats();
		HatWeapon trueWeapon5 = _trueWeapon;
		float num11 = _trueWeapon.PAmount();
		WeaponData currentWeaponData = ((Weapon)trueWeapon5)._currentWeaponData;
		float num12 = currentWeaponData._003CrepeatInterval_003Ek__BackingField * (float)num9;
		float num13 = _trueWeapon.PInterval();
		float num14;
		if (!(num12 > (float)num9))
		{
			WeaponData currentWeaponData2 = ((Weapon)trueWeapon5)._currentWeaponData;
			num14 = currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
		}
		else
		{
			float num15 = _trueWeapon.PInterval();
			float num16 = _trueWeapon.PAmount();
			float num17 = (float)num9 + 1f;
			num14 = (float)num9 / num17;
		}
		Action onComplete = delegate
		{
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Expected O, but got Unknown
			if (_moveDownCount != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.HatProjectile)+D4]");
				object obj14 = 0 - _hatLayerOffset;
				int moveDownCount = _moveDownCount - 1;
				_moveDownCount = moveDownCount;
				PosOffset = PosOffset;
			}
			else
			{
				if (_triggerTimer != null)
				{
					_triggerTimer.Cancel();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 46 Invalid \"Jump target not found in method: 0x18704A990\"");
			}
		};
		float duration = num14 * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer triggerTimer = Timers.Register(duration, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_triggerTimer = triggerTimer;
	}

	private void setHatStats()
	{
		//IL_0024: Expected O, but got I4
		//IL_0063: Expected O, but got I8
		//IL_007d: Expected O, but got I8
		//IL_0942: Expected O, but got I4
		int bounces = _weapon.PBounces();
		object obj = _hatType - 1;
		_bounces = bounces;
		_accelerationOffset = 1f;
		List<string> list = default(List<string>);
		if ((nint)obj <= 6)
		{
			object obj2 = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v361 @ r8_v77+704A8BC+v55 @ rcx_v11*4]");
			object obj3 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v364 @ rdx_v68 (should have been resolved before IL gen)");
		}
		else
		{
			list = new List<string>();
		}
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"hats_01");
		}
		else
		{
			int num = list._size + 1;
			list._size = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"hats_02");
		}
		else
		{
			int num2 = list._size + 1;
			list._size = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version3 = list._version + 1;
		list._version = version3;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"hats_03");
		}
		else
		{
			int num3 = list._size + 1;
			list._size = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list._version + 1;
		list._version = version4;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"hats_04");
		}
		else
		{
			int num4 = list._size + 1;
			list._size = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version5 = list._version + 1;
		list._version = version5;
		string[] items5 = list._items;
		if (list._size >= items5.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"hats_05");
		}
		else
		{
			int num5 = list._size + 1;
			list._size = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version6 = list._version + 1;
		list._version = version6;
		string[] items6 = list._items;
		if (list._size >= items6.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"hats_06");
		}
		else
		{
			int num6 = list._size + 1;
			list._size = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version7 = list._version + 1;
		list._version = version7;
		string[] items7 = list._items;
		if (list._size >= items7.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"hats_07");
		}
		else
		{
			int num7 = list._size + 1;
			list._size = num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version8 = list._version + 1;
		list._version = version8;
		string[] items8 = list._items;
		if (list._size >= items8.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"hats_08");
		}
		else
		{
			int num8 = list._size + 1;
			list._size = num8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version9 = list._version + 1;
		list._version = version9;
		string[] items9 = list._items;
		if (list._size >= items9.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"hats_09");
		}
		else
		{
			int num9 = list._size + 1;
			list._size = num9;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version10 = list._version + 1;
		list._version = version10;
		string[] items10 = list._items;
		if (list._size >= items10.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"hats_10");
		}
		else
		{
			int num10 = list._size + 1;
			list._size = num10;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version11 = list._version + 1;
		list._version = version11;
		string[] items11 = list._items;
		if (list._size >= items11.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"hats_11");
		}
		else
		{
			int num11 = list._size + 1;
			list._size = num11;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version12 = list._version + 1;
		list._version = version12;
		string[] items12 = list._items;
		if (list._size >= items12.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"hats_12");
		}
		else
		{
			int num12 = list._size + 1;
			list._size = num12;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version13 = list._version + 1;
		list._version = version13;
		string[] items13 = list._items;
		if (list._size >= items13.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"hats_13");
		}
		else
		{
			int num13 = list._size + 1;
			list._size = num13;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version14 = list._version + 1;
		list._version = version14;
		string[] items14 = list._items;
		if (list._size >= items14.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"hats_14");
		}
		else
		{
			int num14 = list._size + 1;
			list._size = num14;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		object obj4 = UnityEngine.Random.RandomRangeInt(0, list._size);
		bool flag = (nint)obj4 >= list._size;
		string[] items15 = list._items;
		Sprite sprite = SpriteManager.GetSprite(items15[obj4], "vfx");
		_renderer.sprite = sprite;
	}

	private void triggerHat()
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		if (_moveDownCount != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.HatProjectile)+D4]");
			object obj = 0 - _hatLayerOffset;
			int moveDownCount = _moveDownCount - 1;
			_moveDownCount = moveDownCount;
			PosOffset = PosOffset;
		}
		else
		{
			if (_triggerTimer != null)
			{
				_triggerTimer.Cancel();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 46 Invalid \"Jump target not found in method: 0x18704A990\"");
		}
	}

	private void moveHatDown()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.HatProjectile)+D4]");
		object obj = 0 - _hatLayerOffset;
		PosOffset = PosOffset;
	}

	private unsafe void FireHat()
	{
		//IL_0148: Expected I, but got O
		//IL_0243: Expected I, but got O
		//IL_02df: Expected O, but got I4
		//IL_0773: Expected I, but got O
		//IL_03d6: Expected O, but got I
		//IL_03e3: Expected O, but got Ref
		//IL_03ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f1: Expected O, but got Unknown
		//IL_0408: Unknown result type (might be due to invalid IL or missing references)
		//IL_040d: Expected O, but got Unknown
		//IL_0424: Unknown result type (might be due to invalid IL or missing references)
		//IL_0429: Expected O, but got Unknown
		//IL_050b: Invalid comparison between I4 and F4
		//IL_07d0: Expected O, but got I4
		//IL_06da: Expected O, but got I4
		//IL_06da: Expected O, but got I4
		//IL_0492: Expected O, but got Ref
		//IL_05f5: Expected O, but got I4
		//IL_05f5: Expected O, but got I4
		//IL_07a6->IL06e0: Incompatible stack heights: 1 vs 0
		//IL_047e->IL06e0: Incompatible stack heights: 1 vs 0
		//IL_0835->IL06e0: Incompatible stack heights: 1 vs 0
		//IL_05cc->IL06e0: Incompatible stack heights: 1 vs 0
		//IL_0864->IL06e0: Incompatible stack heights: 1 vs 0
		//IL_061e->IL06e0: Incompatible stack heights: 1 vs 0
		//IL_064d->IL06e0: Incompatible stack heights: 1 vs 0
		//IL_066c->IL06e0: Incompatible stack heights: 1 vs 0
		//IL_06ad->IL06e0: Incompatible stack heights: 1 vs 0
		BaseBody baseBody = base.body;
		_followOwner = false;
		if (base.body != null)
		{
			baseBody._enable = true;
			_shouldSpin = true;
			float num = (float)_indexInWeapon * 0.1f;
			float num2 = (Acceleration = num + _accelerationOffset);
			TweenConfig tweenConfig = new TweenConfig();
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			if (dictionary != null)
			{
				object value = default(object);
				bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"Acceleration", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				if (tweenConfig != null)
				{
					tweenConfig.custom = dictionary;
					if ((object)_trueWeapon != null)
					{
						float num3 = _trueWeapon.PDuration();
						tweenConfig.duration = num2;
						object[] array = new object[1];
						if (array != null)
						{
							nint num4 = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj = default(object);
							if (obj == null)
							{
								ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
								throw ex;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							tweenConfig.targets = array;
							tweenConfig.ease = Ease.InOutSine;
							TweenCallback onComplete = delegate
							{
								_shouldSpin = false;
								Action onComplete2 = delegate
								{
									Despawn();
								};
								bool useRealTime = default(bool);
								MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
								int repeat = default(int);
								TimerType type = default(TimerType);
								Timer accelTimer = Timers.Register(0.5f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
								_accelTimer = accelTimer;
							};
							tweenConfig.onComplete = onComplete;
							MultiTargetTween accelTween = Tweens.Add(tweenConfig);
							_accelTween = accelTween;
							TweenConfig tweenConfig2 = new TweenConfig();
							object[] array2 = new object[1];
							if (array2 != null)
							{
								if ((object)_sprite != null)
								{
									nint num5 = (nint)array2;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									object obj2 = default(object);
									if (obj2 == null)
									{
										ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
										throw ex2;
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								if (tweenConfig2 != null)
								{
									tweenConfig2.targets = array2;
									if ((object)_trueWeapon != null)
									{
										float num6 = _trueWeapon.PArea();
										tweenConfig2.scale = (float?)(object)1;
										if ((object)_trueWeapon != null)
										{
											float num7 = _trueWeapon.PDuration();
											float duration = num2 * 0.3f;
											tweenConfig2.ease = Ease.InOutSine;
											tweenConfig2.yoyo = true;
											tweenConfig2.duration = duration;
											MultiTargetTween scaleTween = Tweens.Add(tweenConfig2);
											_scaleTween = scaleTween;
											Dictionary<string, object> cachedTransform = (Dictionary<string, object>)(object)_cachedTransform;
											float2 float5 = base.position;
											bool flag2 = cachedTransform._buckets == null;
											Vector3 value2 = default(Vector3);
											Transform.set_position_Injected((IntPtr)cachedTransform._buckets, ref value2);
											Weapon weapon = _weapon;
											bool flag3 = !weapon.IsHoming;
											if (!weapon.IsHoming)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
												object obj3 = (nint)(&value2) >> 31;
												object obj4 = (ref *(_003F*)(&value2)) + (ref *(_003F*)obj3);
												object obj5 = obj4 * 2;
												object obj6 = obj4 + obj5;
												object obj7 = _indexInWeapon - obj6;
												if (!flag3)
												{
													object obj8 = obj7 - 1;
													if (!flag3)
													{
														if ((nint)obj8 != 1)
														{
															goto IL_04ab;
														}
														Weapon weapon2 = _weapon;
														if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField == null)
														{
															goto IL_06e0;
														}
														ApplyPlayerFacingVelocity((Vector3)(&value2));
													}
													else
													{
														Transform transform = base.AimForRandomEnemy();
													}
													goto IL_0782;
												}
											}
											goto IL_04ab;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_06e0;
		IL_06c5:
		setCollideWorldBounds(value: true, (float?)(object)1, (float?)(object)1);
		return;
		IL_04ab:
		Transform transform2 = base.AimForNearestEnemy();
		goto IL_0782;
		IL_0782:
		BaseBody baseBody2 = base.body;
		if (base.body != null)
		{
			_velocity = baseBody2._velocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rax_v57 (BaseBody)+74]");
			_ = 0;
			float num8 = (float)_indexInWeapon * 0.025f;
			float num9 = 0.25f - num8;
			SoundManager.SoundConfig soundConfig = default(SoundManager.SoundConfig);
			if (0f > num9 || 0 <= 2139095040)
			{
				soundConfig = new SoundManager.SoundConfig
				{
					Rate = 1f,
					Volume = (float?)(object)1
				};
				float detune = (float)_indexInWeapon * -200f;
				soundConfig.Detune = detune;
			}
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Jump14, soundConfig, 200f, 10, time);
			if (_bounces <= 0)
			{
				goto IL_07f4;
			}
			if (_bounceActivated)
			{
				goto IL_06c5;
			}
			_bounceActivated = true;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null && (object)s_scene.physics != null)
			{
				WORLD_BOUNDS_EVENT wORLD_BOUNDS_EVENT = Bounce;
				if (ArcadePhysics.s_world != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6950");
					setCollideWorldBounds(value: true, (float?)(object)1, (float?)(object)1);
					Weapon weapon3 = _weapon;
					if ((object)_weapon != null)
					{
						VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon3)._003COwner_003Ek__BackingField;
						if ((object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null && base.body != null)
						{
							Body body = base.body.setBoundsRectangle(characterController._worldBoxCollider);
							BaseBody baseBody3 = base.body;
							if (base.body != null)
							{
								baseBody3._onWorldBounds = true;
								goto IL_07f4;
							}
						}
					}
				}
			}
		}
		goto IL_06e0;
		IL_06e0:
		throw new NullReferenceException();
		IL_07f4:
		if (!_bounceActivated)
		{
			return;
		}
		goto IL_06c5;
	}

	public override void InternalUpdate()
	{
		//IL_0091: Expected O, but got F4
		//IL_0158->IL0110: Incompatible stack heights: 1 vs 0
		float num = (float)_velocity * Acceleration;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.HatProjectile)+EC]");
		float num2 = 0f * Acceleration;
		ArcadeSprite sprite = _sprite;
		if ((object)_sprite != null)
		{
			BaseBody baseBody = sprite.body;
			if (sprite.body != null)
			{
				baseBody._velocity = (float2)num;
				if (!_shouldSpin)
				{
					return;
				}
				Transform transform = base.transform;
				Transform transform2 = base.transform;
				if ((object)transform2 != null)
				{
					Vector3 localEulerAngles = transform2.localEulerAngles;
					Vector3 euler = default(Vector3);
					Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion _);
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Quaternion value = default(Quaternion);
					Transform.set_localRotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void LateUpdate()
	{
		//IL_0299->IL0209: Incompatible stack heights: 1 vs 0
		if (!_followOwner)
		{
			return;
		}
		HatWeapon trueWeapon = _trueWeapon;
		float2 float5;
		if ((object)_trueWeapon != null && (object)((Equipment)trueWeapon)._003COwner_003Ek__BackingField != null)
		{
			bool flag = ((Equipment)trueWeapon)._003COwner_003Ek__BackingField.flipX;
			HatWeapon trueWeapon2 = _trueWeapon;
			bool num;
			Vector3 ret;
			float2 float6 = default(float2);
			if (!flag)
			{
				if ((object)_trueWeapon != null)
				{
					ArcadeSprite arcadeSprite = ((Equipment)trueWeapon2)._003COwner_003Ek__BackingField;
					if ((object)((Equipment)trueWeapon2)._003COwner_003Ek__BackingField != null)
					{
						((ArcadeSprite)((Equipment)trueWeapon2)._003COwner_003Ek__BackingField).CheckRenderer();
						if ((object)arcadeSprite._spriteRenderer != null)
						{
							Transform transform = arcadeSprite._spriteRenderer.transform;
							if ((object)transform != null)
							{
								bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								num = flag2;
								Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
								float5 = float6;
								goto IL_028a;
							}
						}
					}
				}
			}
			else if ((object)_trueWeapon != null)
			{
				ArcadeSprite arcadeSprite2 = ((Equipment)trueWeapon2)._003COwner_003Ek__BackingField;
				if ((object)((Equipment)trueWeapon2)._003COwner_003Ek__BackingField != null)
				{
					((ArcadeSprite)((Equipment)trueWeapon2)._003COwner_003Ek__BackingField).CheckRenderer();
					if ((object)arcadeSprite2._spriteRenderer != null)
					{
						Transform transform2 = arcadeSprite2._spriteRenderer.transform;
						if ((object)transform2 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rax_v19 (UnityEngine.Transform)+10]");
							bool flag3 = (nint)0 == 0;
							num = flag3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rax_v19 (UnityEngine.Transform)+10]");
							Transform.get_position_Injected((IntPtr)0, out ret);
							float5 = float6;
							goto IL_028a;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_028a:
		base.position = float5;
	}

	public override void Despawn()
	{
		Transform transform = base.transform;
		Vector3 localEulerAngles = transform.localEulerAngles;
		if (_accelTween != null)
		{
			_accelTween.Kill();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_triggerTimer != null)
		{
			_triggerTimer.Cancel();
		}
		if (_accelTimer != null)
		{
			_accelTimer.Cancel();
		}
		base.Despawn();
	}

	private void Bounce(Body b, bool up, bool down, bool left, bool right)
	{
		//IL_0075: Expected O, but got F4
		//IL_0039: Expected O, but got I4
		//IL_0039: Expected O, but got I4
		if (b == body)
		{
			if (_bounces <= 0)
			{
				setCollideWorldBounds(value: false, (float?)(object)1, (float?)(object)1);
				return;
			}
			float num = (float)_velocity * -1f;
			int bounces = _bounces - 1;
			_bounces = bounces;
			_velocity = (Vector2)num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.HatProjectile)+EC]");
			float num2 = 0f * -1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}

	protected override void OnHasHitAnotherPlayerObject(IDamageable other)
	{
		//IL_001d: Expected I, but got O
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_0071: Expected O, but got I
		//IL_00a7: Expected O, but got I4
		BaseBody baseBody = body;
		Body b;
		if (body == null)
		{
			b = null;
			goto IL_00f5;
		}
		nint num = (nint)typeof(Body);
		nint num2 = (nint)baseBody;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ r8_v3 (Il2CppClass<Body>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ r9_v3 (Il2CppClass<BaseBody>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ r8_v3 (Il2CppClass<Body>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ r9_v3 (Il2CppClass<BaseBody>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v9+FFFFFFF8+v45 @ rax_v4*8]");
			if (0 == (nint)typeof(Body))
			{
				obj3 = 1;
				goto IL_0112;
			}
		}
		obj3 = 0;
		goto IL_0112;
		IL_0112:
		bool flag = obj3 == null;
		b = null;
		if (!flag)
		{
			b = (Body)body;
		}
		goto IL_00f5;
		IL_00f5:
		bool left = default(bool);
		bool right = default(bool);
		Bounce(b, up: false, down: false, left, right);
	}

	public override void OnHasHitWallPhaser(PhaserTile tile)
	{
		//IL_001d: Expected I, but got O
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_0071: Expected O, but got I
		//IL_00a7: Expected O, but got I4
		BaseBody baseBody = body;
		Body b;
		if (body == null)
		{
			b = null;
			goto IL_00f5;
		}
		nint num = (nint)typeof(Body);
		nint num2 = (nint)baseBody;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ r8_v3 (Il2CppClass<Body>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ r9_v3 (Il2CppClass<BaseBody>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ r8_v3 (Il2CppClass<Body>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ r9_v3 (Il2CppClass<BaseBody>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v9+FFFFFFF8+v45 @ rax_v4*8]");
			if (0 == (nint)typeof(Body))
			{
				obj3 = 1;
				goto IL_0112;
			}
		}
		obj3 = 0;
		goto IL_0112;
		IL_0112:
		bool flag = obj3 == null;
		b = null;
		if (!flag)
		{
			b = (Body)body;
		}
		goto IL_00f5;
		IL_00f5:
		bool left = default(bool);
		bool right = default(bool);
		Bounce(b, up: false, down: false, left, right);
	}

	protected override void OnHasHitAnObject(IDamageable target)
	{
		//IL_0073: Expected I, but got O
		//IL_007b: Expected I, but got O
		//IL_008b: Expected O, but got I
		//IL_010b: Expected O, but got I4
		//IL_00c7: Expected O, but got I
		//IL_00fd: Expected O, but got I4
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		BaseBody baseBody = body;
		Body b;
		if (body == null)
		{
			b = null;
			goto IL_0237;
		}
		nint num = (nint)typeof(Body);
		nint num2 = (nint)baseBody;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ r8_v7 (Il2CppClass<Body>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ r9_v6 (Il2CppClass<BaseBody>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ r8_v7 (Il2CppClass<Body>)+130]");
		object obj4;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ r9_v6 (Il2CppClass<BaseBody>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ rax_v36+FFFFFFF8+v263 @ rax_v31*8]");
			if (0 == (nint)typeof(Body))
			{
				obj4 = 1;
				goto IL_0262;
			}
		}
		obj4 = 0;
		goto IL_0262;
		IL_02c8:
		EnemyController component;
		float num4;
		component._003CKnockBack_003Ek__BackingField = num4;
		goto IL_02a6;
		IL_02a6:
		if (_hatType == HatType.PickleHaube)
		{
			float num5 = _weapon.PDuration();
			bool flag = component.Freeze(10f);
		}
		return;
		IL_0237:
		bool left = default(bool);
		bool right = default(bool);
		Bounce(b, up: false, down: false, left, right);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		GameObject gameObject = default(GameObject);
		component = gameObject.GetComponent<EnemyController>();
		if ((object)component == null || ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		if (_hatType != HatType.BowlerHat)
		{
			goto IL_02a6;
		}
		EnemyData currentEnemyData = component._currentEnemyData;
		num4 = currentEnemyData._003CmaxKnockback_003Ek__BackingField;
		if (!(currentEnemyData._003CmaxKnockback_003Ek__BackingField > 10f))
		{
			object obj5 = 10f & -2147483649L;
			if ((nint)obj5 <= 2139095040)
			{
				goto IL_02c8;
			}
		}
		num4 = 10f;
		goto IL_02c8;
		IL_0262:
		bool flag2 = obj4 == null;
		b = null;
		if (!flag2)
		{
			b = (Body)body;
		}
		goto IL_0237;
	}

	public HatProjectile()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_03d1: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_03f9: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_0421: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_0449: Expected O, but got I
		//IL_022a: Expected O, but got I
		//IL_0471: Expected O, but got I
		//IL_0294: Expected O, but got I
		//IL_0499: Expected O, but got I
		//IL_02fe: Expected O, but got I
		//IL_04c1: Expected O, but got I
		//IL_0368: Expected O, but got I
		//IL_04e3: Expected I, but got O
		List<HatType> list = new List<HatType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.HatType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.HatType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.HatType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.HatType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.HatType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.HatType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.HatType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)5);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.HatType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 5;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.HatType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.HatType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.HatType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)6);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.HatType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 6;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.HatType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.HatType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.HatType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)7);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.HatType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 7;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.HatType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.HatType>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.HatType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.HatType>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.HatType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.HatType>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.HatType>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rdx_v14+18]");
		if (num6 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)2);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.HatType>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.HatType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.HatType>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.HatType>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rdx_v16+18]");
		if (num7 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)3);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.HatType>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 3;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.HatType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.HatType>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.HatType>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rdx_v18+18]");
		if (num8 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)4);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.HatType>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 4;
		}
		_hatTypes = list;
		Acceleration = 1f;
		_accelerationOffset = 1.5f;
		nint num9 = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v674 @ rax_v19 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num10 = 0;
		_velocity = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v675 @ rcx_v24 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		_hatLayerOffset = 0.099999994f;
		base._002Ector();
	}

	private void _003CInitProjectile_003Eb__17_0()
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		if (_moveDownCount != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.HatProjectile)+D4]");
			object obj = 0 - _hatLayerOffset;
			int moveDownCount = _moveDownCount - 1;
			_moveDownCount = moveDownCount;
			PosOffset = PosOffset;
		}
		else
		{
			if (_triggerTimer != null)
			{
				_triggerTimer.Cancel();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 46 Invalid \"Jump target not found in method: 0x18704A990\"");
		}
	}

	private void _003CFireHat_003Eb__21_0()
	{
		_shouldSpin = false;
		Action onComplete = delegate
		{
			Despawn();
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer accelTimer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_accelTimer = accelTimer;
	}

	private void _003CFireHat_003Eb__21_1()
	{
		Despawn();
	}
}
