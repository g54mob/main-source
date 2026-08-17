using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Characters;

public class CharacterControllerKeira : CharacterController
{
	private Image _HealthBar;

	private Image _HealthBarFill;

	private bool _isCharging;

	private float _chargeTime;

	private float _maxChargeTimeMS;

	private float _defaultChargeTimeMS;

	private Color ChargeColor;

	private Color ReadyColor;

	private List<WeaponType> spells;

	private Timer nextTriggeredSkillTimer;

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		Sprite unpackedSprite = SpriteManager.GetUnpackedSprite("UISquare");
		_HealthBarFill.sprite = unpackedSprite;
		_HealthBar.sprite = unpackedSprite;
		_chargeTime = 0f;
		_isCharging = false;
	}

	private unsafe void HideCharge()
	{
		//IL_0014: Expected O, but got Ref
		//IL_0037: Expected O, but got Ref
		//IL_005a: Expected O, but got Ref
		object obj = default(object);
		_HealthBarFill.color = (Color)(&obj);
		Color color = _HealthBar.color;
		_HealthBar.color = (Color)(&obj);
		Color color2 = _HealthBarFill.color;
		_HealthBarFill.color = (Color)(&obj);
		_isCharging = false;
	}

	private unsafe void ShowCharge()
	{
		//IL_0014: Expected O, but got Ref
		//IL_0037: Expected O, but got Ref
		//IL_005a: Expected O, but got Ref
		object obj = default(object);
		_HealthBarFill.color = (Color)(&obj);
		Color color = _HealthBar.color;
		_HealthBar.color = (Color)(&obj);
		Color color2 = _HealthBarFill.color;
		_HealthBarFill.color = (Color)(&obj);
		if (!_isCharging)
		{
			_isCharging = true;
		}
	}

	private unsafe void HighlightCharge()
	{
		//IL_0014: Expected O, but got Ref
		//IL_0037: Expected O, but got Ref
		//IL_005a: Expected O, but got Ref
		object obj = default(object);
		_HealthBarFill.color = (Color)(&obj);
		Color color = _HealthBar.color;
		_HealthBar.color = (Color)(&obj);
		Color color2 = _HealthBarFill.color;
		_HealthBarFill.color = (Color)(&obj);
		if (!_isCharging)
		{
			_isCharging = true;
		}
	}

	protected override void OnUpdate()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_031f: Invalid comparison between F4 and I4
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected O, but got Unknown
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_03d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d6: Expected O, but got Unknown
		//IL_033c: Expected O, but got F4
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Expected O, but got Unknown
		//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bd: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = obj2 - 95;
		base.OnUpdate();
		if (!(base._walked > 0f))
		{
			if (!(_chargeTime < _maxChargeTimeMS))
			{
				_chargeTime = 0f;
				Action onComplete = TriggerChargeSkill;
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				Timer timer = Timers.Register(0.060000002f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				nextTriggeredSkillTimer = timer;
				_maxChargeTimeMS = _defaultChargeTimeMS;
				object obj3 = UnityEngine.Random.value;
				float num = base.PLuck();
				float num2 = 0.060000002f * 0.1f;
				if (!(num2 < 0.060000002f))
				{
					float maxChargeTimeMS = _defaultChargeTimeMS * 0.1f;
					_maxChargeTimeMS = maxChargeTimeMS;
				}
				_HealthBarFill.fillAmount = 0f;
			}
			Color color = (Color)(obj + 39);
			_ = ChargeColor;
			_HealthBarFill.color = color;
			Color color2 = _HealthBar.color;
			Color color3 = (Color)(obj + 39);
			_ = 1051931443;
			_HealthBar.color = color3;
			Color color4 = _HealthBarFill.color;
			Color color5 = (Color)(obj + 39);
			_ = 1051931443;
			_HealthBarFill.color = color5;
			_isCharging = false;
		}
		else
		{
			float num3 = PauseSystem.DeltaTime;
			float num4 = num3 * 1000f;
			float num5 = base.PLuck();
			if (!(2.5f > num3))
			{
				num3 = 2.5f;
			}
			float num6 = num3 * num4;
			float fillAmount = (_chargeTime = num6 + _chargeTime) / _maxChargeTimeMS;
			_HealthBarFill.fillAmount = fillAmount;
			Image healthBarFill;
			if (!(_chargeTime < _maxChargeTimeMS))
			{
				healthBarFill = _HealthBarFill;
				Color readyColor = ReadyColor;
			}
			else
			{
				healthBarFill = _HealthBarFill;
				Color readyColor = ChargeColor;
			}
			Color color6 = (Color)(obj + 39);
			healthBarFill.color = color6;
			Color color7 = _HealthBar.color;
			Color color8 = (Color)(obj + 39);
			_ = 1065353216;
			_HealthBar.color = color8;
			Color color9 = _HealthBarFill.color;
			Color color10 = (Color)(obj + 39);
			_ = 1065353216;
			_HealthBarFill.color = color10;
			if (!_isCharging)
			{
				_isCharging = true;
			}
		}
	}

	private void TriggerChargeSkill()
	{
		//IL_0072: Expected I, but got O
		//IL_0094: Expected O, but got I
		CharacterWeaponsManager weaponsManager = base._weaponsManager;
		Predicate<Equipment> match = delegate(Equipment x)
		{
			//IL_0067: Expected I4, but got O
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Expected I4, but got Unknown
			if ((object)x != null)
			{
				List<WeaponType> list4 = spells;
				if (spells != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
					object obj2 = default(object);
					object obj = obj2 >> 31;
					return (byte)(obj ^ 1) != 0;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		};
		List<object> list = ((List<object>)(object)((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField).FindAll((Predicate<object>)match);
		List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
		while (enumerator.MoveNext())
		{
			List<Equipment> list2 = ((List<Equipment>)null).FindAll((Predicate<Equipment>)(object)typeof(IMillionaire));
			if (list2 != null)
			{
				nint num = (nint)this;
				base.OnRangedAttackAnim();
				float2 float5 = base.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterControllerKeira>)+6B0]");
				List<Equipment> list3 = ((List<Equipment>)(object)this).FindAll((Predicate<Equipment>)0);
			}
		}
	}

	public override void LevelUp()
	{
		//IL_00aa: Expected F4, but got O
		base.LevelUp();
		if (base._level == 30)
		{
			float2 float5 = base.position;
			float2 float6 = base.position;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			float num = renderer.height * 0.45f;
			object obj = default(object);
			float y = (float)obj - num;
			Vector2 pos = default(Vector2);
			float value = default(float);
			ItemType relicType = default(ItemType);
			bool validatePickups = default(bool);
			Pickup pickup = GM.Core.MakeStagePickup(pos, ItemType.WEAPON, WeaponType.ACADEMYBADGE, value, relicType, validatePickups);
			GameManager core = GM.Core;
			core._gizmoManager.ShowHighlightAt((float)float5, y);
		}
	}

	public CharacterControllerKeira()
	{
		//IL_0149: Expected O, but got F4
		//IL_0166: Expected O, but got F4
		//IL_0036: Expected O, but got I
		//IL_0090: Expected O, but got I
		//IL_0197: Expected O, but got I
		//IL_00fa: Expected O, but got I
		_maxChargeTimeMS = 10000f;
		_defaultChargeTimeMS = 10000f;
		ChargeColor = (Color)ColourHelper.HexToColor("FF8C00").r;
		ReadyColor = (Color)ColourHelper.HexToColor("FFFF00").r;
		List<WeaponType> list = new List<WeaponType>();
		list._002Ector();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rdx_v6+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)135);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 135;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rdx_v8+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)136);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 136;
		}
		spells = list;
		base._002Ector();
	}

	private bool _003CTriggerChargeSkill_003Eb__15_0(Equipment x)
	{
		//IL_0067: Expected I4, but got O
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected I4, but got Unknown
		if ((object)x != null)
		{
			List<WeaponType> list = spells;
			if (spells != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				object obj2 = default(object);
				object obj = obj2 >> 31;
				return (byte)(obj ^ 1) != 0;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}
}
