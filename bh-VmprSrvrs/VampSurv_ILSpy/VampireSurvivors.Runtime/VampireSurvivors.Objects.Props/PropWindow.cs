using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Stages;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Props;

public class PropWindow : Destructible
{
	private Stage _stage;

	private bool _hasFired;

	private void Construct(Stage stage)
	{
		_stage = stage;
	}

	public override void Init(PropType destructibleType)
	{
		base.Init(destructibleType);
		base._003CIsStationary_003Ek__BackingField = true;
		_hasFired = false;
		float2 float5 = base.position;
		PlayerOptionsData config = _playerOptions.Config;
		if (config._003CSelectedInverse_003Ek__BackingField)
		{
			PlayerOptionsData config2 = _playerOptions.Config;
			if (config2._003CVisuallyInvertStages_003Ek__BackingField)
			{
				base.angle = 180f;
			}
		}
		float2 float6 = default(float2);
		base.position = float6;
	}

	protected override void OnDestroyed()
	{
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected O, but got Unknown
		//IL_00f7: Invalid comparison between F4 and O
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Expected O, but got Unknown
		//IL_0160: Invalid comparison between F4 and O
		//IL_017e: Invalid comparison between F4 and I4
		//IL_01a7: Expected O, but got I4
		//IL_025a: Expected I, but got O
		//IL_0262: Expected I, but got O
		//IL_0272: Expected O, but got I
		//IL_02f2: Expected O, but got I4
		//IL_02ae: Expected O, but got I
		//IL_02e4: Expected O, but got I4
		//IL_0319: Expected O, but got I
		//IL_035f: Expected O, but got I
		//IL_0416->IL039b: Incompatible stack heights: 1 vs 0
		//IL_0109->IL049c: Incompatible stack heights: 2 vs 0
		//IL_01bf->IL049c: Incompatible stack heights: 2 vs 0
		//IL_01de->IL039b: Incompatible stack heights: 2 vs 0
		//IL_0218->IL039b: Incompatible stack heights: 2 vs 0
		//IL_0247->IL049c: Incompatible stack heights: 2 vs 0
		//IL_04b5->IL049c: Incompatible stack heights: 2 vs 0
		//IL_0497->IL049c: Incompatible stack heights: 2 vs 0
		//IL_034a->IL049c: Incompatible stack heights: 2 vs 0
		//IL_037f->IL039b: Incompatible stack heights: 2 vs 0
		//IL_039b->IL049c: Incompatible stack heights: 2 vs 0
		if (_hasFired)
		{
			return;
		}
		GameSessionData gameSessionData = _gameSessionData;
		_hasFired = true;
		Stage stage;
		object obj11;
		if (_gameSessionData != null && (object)gameSessionData._activeCharacter != null)
		{
			Transform transform = gameSessionData._activeCharacter.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				Transform transform2 = base.transform;
				if ((object)transform2 != null)
				{
					bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 ret2);
					Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
					object obj = default(object);
					float num = (float)obj * 2f;
					object obj2 = ret2 - ret;
					float num2 = num * 0.5f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
					object obj3 = obj2 & 0;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
					{
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v627 @ rax_v29 (UnityEngine.Bounds)+10]");
					float num3 = 0f * 2f;
					object obj5 = default(object);
					object obj6 = default(object);
					object obj4 = obj5 - obj6;
					float num4 = num3 * 0.5f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
					object obj7 = obj4 & 0;
					bool flag3 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num4) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7);
					float num5 = num4 - (float)obj7;
					bool flag4 = num5 == 0f;
					bool flag5 = !flag3;
					bool flag6 = !flag4;
					object obj8 = flag6 & flag5;
					if (obj8 == null)
					{
						return;
					}
					if (_playerOptions != null)
					{
						_playerOptions.IncreaseDestroyedPropCount(_destructibleType);
						stage = _stage;
						if ((object)_stage != null)
						{
							BackgroundManager fancyBg = stage._fancyBg;
							if ((object)stage._fancyBg == null)
							{
								return;
							}
							nint num6 = (nint)typeof(Background5);
							nint num7 = (nint)fancyBg;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Stages.Background5>)+130]");
							object obj9 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundManager>)+130]");
							nint num8 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Stages.Background5>)+130]");
							if (num8 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundManager>)+C8]");
								object obj10 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v754 @ rax_v51+FFFFFFF8+v740 @ rax_v35*8]");
								if (0 == (nint)typeof(Background5))
								{
									obj11 = 1;
									goto IL_0450;
								}
							}
							obj11 = 0;
							goto IL_0450;
						}
					}
				}
			}
		}
		goto IL_039b;
		IL_0450:
		bool flag7 = obj11 == null;
		BackgroundManager backgroundManager = null;
		if (!flag7)
		{
			backgroundManager = stage._fancyBg;
		}
		if ((object)backgroundManager != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rbx_v11 (VampireSurvivors.Objects.Stages.BackgroundManager)+190]");
			Transform transform3 = (Transform)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rbx_v11 (VampireSurvivors.Objects.Stages.BackgroundManager)+190]");
			if ((nint)0 != 0 && ((UnityEngine.Object)transform3).m_CachedPtr != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rbx_v11 (VampireSurvivors.Objects.Stages.BackgroundManager)+190]");
				object obj12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rbx_v11 (VampireSurvivors.Objects.Stages.BackgroundManager)+190]");
				if ((nint)0 != 0)
				{
					object obj13 = obj12;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v681 @ r10_v3+4D8] (should have been resolved before IL gen)");
					return;
				}
				goto IL_039b;
			}
			return;
		}
		return;
		IL_039b:
		throw new NullReferenceException();
	}

	public PropWindow()
	{
		//IL_0036: Expected I, but got O
		_hp = 1f;
		base._maxHp = 1f;
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
