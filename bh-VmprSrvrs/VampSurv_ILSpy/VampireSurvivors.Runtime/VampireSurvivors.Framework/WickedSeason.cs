using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using VampireSurvivors.Data;
using Zenject;

namespace VampireSurvivors.Framework;

public class WickedSeason
{
	private SignalBus _signalBus;

	private bool _hasWickedSeason;

	private float _seasonTime;

	private float _seasonDuration;

	private int _seasonIndex;

	private float _curse;

	private float _growth;

	private float _luck;

	private float _greed;

	private readonly List<string> _wickedSeasonAttributes;

	private List<string> _seasonColors;

	private List<string> _seasonIcons;

	private readonly List<SfxType> _seasonSfx;

	public float SeasonDuration => _seasonDuration;

	public float Curse => _curse;

	public float Growth => _growth;

	public float Luck => _luck;

	public float Greed => _greed;

	public void Init(SignalBus signalBus)
	{
		_signalBus = signalBus;
	}

	public void Update()
	{
		//IL_0271: Expected O, but got I4
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Expected O, but got Unknown
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected O, but got Unknown
		//IL_0391: Expected I, but got O
		//IL_01bb: Expected O, but got I
		//IL_01d7: Expected O, but got I4
		//IL_020d: Expected F4, but got I4
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		if ((_seasonTime = num + _seasonTime) > _seasonDuration)
		{
			List<string> wickedSeasonAttributes = _wickedSeasonAttributes;
			int num2 = _seasonIndex + 1;
			_seasonTime = 0f;
			_seasonIndex = num2;
			if (num2 >= wickedSeasonAttributes._size)
			{
				_seasonIndex = 0;
			}
			List<string> seasonColors = _seasonColors;
			if (_seasonIndex < seasonColors._size)
			{
				List<string> seasonIcons = _seasonIcons;
				if (_seasonIndex < seasonIcons._size)
				{
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v679 @ rbx_v6 (Il2CppMethodInfo)+38]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
					}
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rsi_v6 (Il2CppMethodInfo)+38]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
					object obj2 = default(object);
					object obj = obj2 + 32;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
					Type type = default(Type);
					Type signalType = type;
					object obj3 = default(object);
					object signal = (IntPtr)obj3;
					bool flag = default(bool);
					_signalBus.InternalFire(signalType, signal, (object)null, flag);
					List<SfxType> seasonSfx = _seasonSfx;
					int seasonIndex = _seasonIndex;
					int seasonIndex2 = _seasonIndex;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rcx_v28 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
					if ((nint)seasonIndex2 < (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rcx_v28 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
						object obj4 = 0;
						SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
						soundConfig.Volume = (float?)(object)1;
						soundConfig.Rate = 1f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rcx_v29+20+v222 @ rax_v25 (System.Int32)*4]");
						PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.None, soundConfig, 150f, 3, flag ? 1 : 0);
						goto IL_0216;
					}
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			return;
		}
		goto IL_0216;
		IL_0216:
		_growth = 1f;
		_luck = 1f;
		_curse = 1f;
		_greed = 1f;
		bool flag2 = _seasonIndex == 0;
		if (!flag2)
		{
			object obj5 = _seasonIndex - 1;
			if (!flag2)
			{
				object obj6 = obj5 - 1;
				if (!flag2)
				{
					if ((nint)obj6 == 1)
					{
						_greed = 2f;
					}
				}
				else
				{
					_luck = 2f;
				}
			}
			else
			{
				_growth = 2f;
			}
		}
		else
		{
			_curse = 2f;
		}
		GameManager core = GM.Core;
		core._stage.CalculateEnemySpeed();
	}

	public WickedSeason()
	{
		//IL_0796: Expected O, but got I
		//IL_07f0: Expected O, but got I
		//IL_09b8: Expected O, but got I
		//IL_085a: Expected O, but got I
		//IL_09e0: Expected O, but got I
		//IL_08c4: Expected O, but got I
		//IL_0a08: Expected O, but got I
		//IL_092e: Expected O, but got I
		_seasonTime = 10000f;
		_seasonDuration = 10000f;
		_curse = 1f;
		_growth = 1f;
		_luck = 1f;
		_greed = 1f;
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"curse");
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"growth");
		}
		else
		{
			int size2 = list._size + 1;
			list._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version3 = list._version + 1;
		list._version = version3;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"luck");
		}
		else
		{
			int size3 = list._size + 1;
			list._size = size3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list._version + 1;
		list._version = version4;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"greed");
		}
		else
		{
			int size4 = list._size + 1;
			list._size = size4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_wickedSeasonAttributes = list;
		List<string> list2 = new List<string>();
		int version5 = list2._version + 1;
		list2._version = version5;
		string[] items5 = list2._items;
		if (list2._size >= items5.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"0xff4488");
		}
		else
		{
			int size5 = list2._size + 1;
			list2._size = size5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version6 = list2._version + 1;
		list2._version = version6;
		string[] items6 = list2._items;
		if (list2._size >= items6.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"0x4488ff");
		}
		else
		{
			int size6 = list2._size + 1;
			list2._size = size6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version7 = list2._version + 1;
		list2._version = version7;
		string[] items7 = list2._items;
		if (list2._size >= items7.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"0x44ff88");
		}
		else
		{
			int size7 = list2._size + 1;
			list2._size = size7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version8 = list2._version + 1;
		list2._version = version8;
		string[] items8 = list2._items;
		if (list2._size >= items8.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"0xccff00");
		}
		else
		{
			int size8 = list2._size + 1;
			list2._size = size8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_seasonColors = list2;
		List<string> list3 = new List<string>();
		int version9 = list3._version + 1;
		list3._version = version9;
		string[] items9 = list3._items;
		if (list3._size >= items9.Length)
		{
			((List<object>)(object)list3).AddWithResize((object)"Curse.png");
		}
		else
		{
			int size9 = list3._size + 1;
			list3._size = size9;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version10 = list3._version + 1;
		list3._version = version10;
		string[] items10 = list3._items;
		if (list3._size >= items10.Length)
		{
			((List<object>)(object)list3).AddWithResize((object)"Crown.png");
		}
		else
		{
			int size10 = list3._size + 1;
			list3._size = size10;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version11 = list3._version + 1;
		list3._version = version11;
		string[] items11 = list3._items;
		if (list3._size >= items11.Length)
		{
			((List<object>)(object)list3).AddWithResize((object)"Clover.png");
		}
		else
		{
			int size11 = list3._size + 1;
			list3._size = size11;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version12 = list3._version + 1;
		list3._version = version12;
		string[] items12 = list3._items;
		if (list3._size >= items12.Length)
		{
			((List<object>)(object)list3).AddWithResize((object)"Mask.png");
		}
		else
		{
			int size12 = list3._size + 1;
			list3._size = size12;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_seasonIcons = list3;
		List<SfxType> list4 = new List<SfxType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v982 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v982 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v982 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rdx_v31+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list4).AddWithResize((System.Int32Enum)57);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v982 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 57;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v982 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v982 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v982 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rdx_v33+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list4).AddWithResize((System.Int32Enum)54);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v982 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 54;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v982 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v982 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v982 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v35+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list4).AddWithResize((System.Int32Enum)55);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v982 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 55;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v982 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v982 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v982 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rdx_v37+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list4).AddWithResize((System.Int32Enum)56);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v982 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 56;
		}
		_seasonSfx = list4;
	}
}
