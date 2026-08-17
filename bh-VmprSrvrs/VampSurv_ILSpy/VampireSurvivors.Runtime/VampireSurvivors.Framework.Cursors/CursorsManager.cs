using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Graphics;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.Framework.Cursors;

public class CursorsManager : MonoBehaviour
{
	private GameObject _CursorIndicatorPrefab;

	private SignalBus _signalBus;

	private ObjectPool _cursorsPool;

	private bool _cursorsHidden;

	private readonly Dictionary<GameObject, CursorIndicator> _cursorIndicators;

	private void Construct(SignalBus signalBus)
	{
		_signalBus = signalBus;
	}

	public void Awake()
	{
		//IL_003b: Expected I4, but got I8
		//IL_00a7: Expected I4, but got I8
		//IL_01f8: Expected O, but got I4
		//IL_01f8: Expected O, but got I
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Expected O, but got Unknown
		//IL_07bc: Expected O, but got I
		//IL_030e: Expected O, but got I4
		//IL_030e: Expected O, but got I
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Expected O, but got Unknown
		//IL_07f5: Expected O, but got I
		//IL_0424: Expected O, but got I4
		//IL_0424: Expected O, but got I
		//IL_042d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0432: Expected O, but got Unknown
		//IL_0830: Expected O, but got I
		//IL_053a: Expected O, but got I4
		//IL_053a: Expected O, but got I
		//IL_0543: Unknown result type (might be due to invalid IL or missing references)
		//IL_0548: Expected O, but got Unknown
		//IL_0869: Expected O, but got I
		//IL_0650: Expected O, but got I4
		//IL_0650: Expected O, but got I
		//IL_0659: Unknown result type (might be due to invalid IL or missing references)
		//IL_065e: Expected O, but got Unknown
		//IL_08a2: Expected O, but got I
		//IL_0766: Expected O, but got I4
		//IL_0766: Expected O, but got I
		//IL_076f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0774: Expected O, but got Unknown
		//IL_08db: Expected O, but got I
		string text = ((UnityEngine.Object)_CursorIndicatorPrefab).GetName();
		ObjectPool cursorsPool = ObjectPool.Create(_CursorIndicatorPrefab, text, 10, -1);
		_cursorsPool = cursorsPool;
		ObjectPool cursorsPool2 = _cursorsPool;
		cursorsPool2._incrementalInstanceNames = true;
		ObjectPool cursorsPool3 = _cursorsPool;
		bool flag = cursorsPool3._003CInitialized_003Ek__BackingField;
		PopulateMethod populateMethod = (PopulateMethod)10;
		int num = -1;
		if (!flag)
		{
			cursorsPool3._003CInitialized_003Ek__BackingField = true;
			cursorsPool3.AutoFillName();
			cursorsPool3.Populate(cursorsPool3._defaultSize);
			populateMethod = PopulateMethod.Set;
			num = 0;
		}
		Action<UISignals.SpawnOffScreenCursorSignal> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A7C0");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v579 @ rbx_v4 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rbx_v5 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rbx_v5 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.SpawnOffScreenCursorSignal>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.SpawnOffScreenCursorSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rax_v21 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
		Action<UISignals.RemoveOffScreenCursorSignal> action3 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A8A0");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v796 @ rbx_v8 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rbx_v9 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rbx_v9 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj4 = null;
		Action<object> action4 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.RemoveOffScreenCursorSignal>)obj4)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.RemoveOffScreenCursorSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus2 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rax_v36 (System.Object)+10]");
		Type signalType2 = default(Type);
		signalBus2.SubscribeInternal(signalType2, (object)null, (object)0, callback);
		Action action5 = RefreshCursors;
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1007 @ rbx_v12 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rbx_v13 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rbx_v13 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj7 = null;
		Action<object> action6 = ((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.RefreshCursorsSignal>)obj7)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.RefreshCursorsSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj9 = default(object);
		object obj8 = obj9 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus3 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rax_v51 (System.Object)+10]");
		Type signalType3 = default(Type);
		signalBus3.SubscribeInternal(signalType3, (object)null, (object)0, callback);
		Action<UISignals.HideAllCursorsSignal> action7 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A980");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1216 @ rbx_v16 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rbx_v17 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rbx_v17 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj10 = null;
		Action<object> action8 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.HideAllCursorsSignal>)obj10)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.HideAllCursorsSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj12 = default(object);
		object obj11 = obj12 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus4 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rax_v66 (System.Object)+10]");
		Type signalType4 = default(Type);
		signalBus4.SubscribeInternal(signalType4, (object)null, (object)0, callback);
		Action<UISignals.HideCursorSignal> action9 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AA60");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1425 @ rbx_v20 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rbx_v21 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rbx_v21 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj13 = null;
		Action<object> action10 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.HideCursorSignal>)obj13)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.HideCursorSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj15 = default(object);
		object obj14 = obj15 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus5 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rax_v81 (System.Object)+10]");
		Type signalType5 = default(Type);
		signalBus5.SubscribeInternal(signalType5, (object)null, (object)0, callback);
		Action<UISignals.ShowCursorSignal> action11 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AB40");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1634 @ rbx_v24 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rbx_v25 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rbx_v25 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj16 = null;
		Action<object> action12 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.ShowCursorSignal>)obj16)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.ShowCursorSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj18 = default(object);
		object obj17 = obj18 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus6 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rax_v96 (System.Object)+10]");
		Type signalType6 = default(Type);
		signalBus6.SubscribeInternal(signalType6, (object)null, (object)0, callback);
	}

	protected void OnDestroy()
	{
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Expected O, but got Unknown
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ce: Expected O, but got Unknown
		//IL_0383: Unknown result type (might be due to invalid IL or missing references)
		//IL_0388: Expected O, but got Unknown
		//IL_043d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0442: Expected O, but got Unknown
		ObjectPool cursorsPool = _cursorsPool;
		if ((object)_cursorsPool != null && ((UnityEngine.Object)cursorsPool).m_CachedPtr != (IntPtr)0)
		{
			_cursorsPool.ReleaseAll();
			UnityEngine.Object.Destroy(_cursorsPool, 0f);
		}
		Action<UISignals.SpawnOffScreenCursorSignal> token = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A7C0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		_signalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		Action<UISignals.RemoveOffScreenCursorSignal> token2 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A8A0");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rbx_v8 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v582 @ rbx_v9 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType2 = default(Type);
		_signalBus.UnsubscribeInternal(signalType2, (object)null, (object)token2, throwIfMissing);
		Action<UISignals.HideAllCursorsSignal> token3 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A980");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v661 @ rbx_v12 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ rbx_v13 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType3 = default(Type);
		_signalBus.UnsubscribeInternal(signalType3, (object)null, (object)token3, throwIfMissing);
		Action token4 = RefreshCursors;
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v759 @ rbx_v16 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v776 @ rbx_v17 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj8 = default(object);
		object obj7 = obj8 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType4 = default(Type);
		_signalBus.UnsubscribeInternal(signalType4, (object)null, (object)token4, throwIfMissing);
		Action<UISignals.HideCursorSignal> token5 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AA60");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v855 @ rbx_v20 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v872 @ rbx_v21 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj10 = default(object);
		object obj9 = obj10 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType5 = default(Type);
		_signalBus.UnsubscribeInternal(signalType5, (object)null, (object)token5, throwIfMissing);
		Action<UISignals.ShowCursorSignal> token6 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AB40");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v951 @ rbx_v24 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v968 @ rbx_v25 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj12 = default(object);
		object obj11 = obj12 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType6 = default(Type);
		_signalBus.UnsubscribeInternal(signalType6, (object)null, (object)token6, throwIfMissing);
	}

	protected unsafe void LateUpdate()
	{
		//IL_009b: Expected F4, but got I4
		//IL_0648: Expected O, but got F4
		//IL_0666: Expected O, but got F4
		//IL_06ce: Expected O, but got Ref
		//IL_00dd: Expected O, but got I
		//IL_038d: Expected O, but got I
		//IL_054e: Expected O, but got I
		//IL_0405: Expected O, but got I
		//IL_019f: Expected O, but got I
		//IL_01ec: Expected O, but got I
		//IL_021e: Expected O, but got I
		//IL_05b2: Expected O, but got I
		//IL_0296: Expected O, but got I
		//IL_0478: Expected O, but got I
		//IL_05ff: Expected O, but got I
		//IL_04c5: Expected O, but got I
		//IL_034d->IL07dd: Incompatible stack heights: 8 vs 0
		//IL_0611->IL07dd: Incompatible stack heights: 14 vs 0
		//IL_04cf->IL07dd: Incompatible stack heights: 14 vs 0
		//IL_07bc->IL07dd: Incompatible stack heights: 16 vs 0
		GameManager core = GM.Core;
		if (!core._isGameRunning || _cursorsHidden)
		{
			return;
		}
		Dictionary<object, object>.Enumerator enumerator = default(Dictionary<object, object>.Enumerator);
		Vector3 vector = default(Vector3);
		Vector3 screenPosition = default(Vector3);
		float angle = default(float);
		float value = default(float);
		Vector3 value2 = default(Vector3);
		Vector3 screenPosition2 = default(Vector3);
		float value3 = default(float);
		Vector3 value4 = default(Vector3);
		float value5 = default(float);
		Vector3 value6 = default(Vector3);
		while (enumerator.MoveNext())
		{
			float num = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
			object obj = null;
			bool flag = 0 == 0;
			bool flag2 = ((UnityEngine.Object)num).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr = GameObject.get_transform_Injected(((UnityEngine.Object)num).m_CachedPtr);
			Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			bool flag3 = (object)transform == null;
			bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			bool flag5 = IsTargetVisible((Vector3)(&vector));
			bool flag6 = 0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rbx_v8 (System.Object)+50]");
			CursorData cursorData = (CursorData)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rbx_v8 (System.Object)+50]");
			bool flag7 = (nint)0 == 0;
			if (!cursorData.OnScreenPointAt)
			{
				if (!flag5)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rbx_v8 (System.Object)+10]");
					bool flag8 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rbx_v8 (System.Object)+10]");
					IntPtr gcHandlePtr2 = Component.get_gameObject_Injected((IntPtr)0);
					GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
					bool flag9 = (object)gameObject == null;
					gameObject.SetActive(value: true);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rbx_v8 (System.Object)+30]");
					SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha((SpriteRenderer)0, 0.75f);
					Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rbx_v8 (System.Object)+30]");
					bool flag10 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rbx_v8 (System.Object)+30]");
					((Renderer)0).SetMaterial(material);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rbx_v8 (System.Object)+50]");
					bool flag11 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rbx_v8 (System.Object)+50]");
					float cursorProportionOfScreenFromCenter = ((CursorData)0).CursorProportionOfScreenFromCenter;
					GetArrowIndicatorPositionAndAngle(ref screenPosition, ref angle, cursorProportionOfScreenFromCenter);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rbx_v8 (System.Object)+10]");
					bool flag12 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rbx_v8 (System.Object)+10]");
					IntPtr gcHandlePtr3 = Component.get_transform_Injected((IntPtr)0);
					Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rbx_v8 (System.Object)+30]");
					bool flag13 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rbx_v8 (System.Object)+30]");
					Transform transform3 = ((Component)0).transform;
					float z = angle * 57.29578f;
					Quaternion quaternion2 = Quaternion.Euler(0f, 0f, z);
					bool flag14 = (object)transform3 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3721 @ rax_v111 (UnityEngine.Transform)+10]");
					bool flag15 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3721 @ rax_v111 (UnityEngine.Transform)+10]");
					Transform.set_rotation_Injected((IntPtr)0, ref *(Quaternion*)(&value));
					bool flag16 = (object)transform2 == null;
					bool flag17 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rbx_v8 (System.Object)+10]");
					bool flag18 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rbx_v8 (System.Object)+10]");
					IntPtr gcHandlePtr4 = Component.get_gameObject_Injected((IntPtr)0);
					GameObject gameObject2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr4);
					bool flag19 = (object)gameObject2 == null;
					gameObject2.SetActive(value: false);
				}
			}
			else if (!flag5)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rbx_v8 (System.Object)+50]");
				bool flag20 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rbx_v8 (System.Object)+50]");
				float cursorProportionOfScreenFromCenter2 = ((CursorData)0).CursorProportionOfScreenFromCenter;
				GetArrowIndicatorPositionAndAngle(ref screenPosition2, ref angle, cursorProportionOfScreenFromCenter2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rbx_v8 (System.Object)+10]");
				bool flag21 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rbx_v8 (System.Object)+10]");
				IntPtr gcHandlePtr5 = Component.get_transform_Injected((IntPtr)0);
				Transform transform4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr5);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rbx_v8 (System.Object)+30]");
				bool flag22 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rbx_v8 (System.Object)+30]");
				Transform transform5 = ((Component)0).transform;
				float z = angle * 57.29578f;
				Quaternion quaternion3 = Quaternion.Euler(0f, 0f, z);
				bool flag23 = (object)transform5 == null;
				bool flag24 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
				Transform.set_rotation_Injected(((UnityEngine.Object)transform5).m_CachedPtr, ref *(Quaternion*)(&value3));
				bool flag25 = (object)transform4 == null;
				bool flag26 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
				Transform.set_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref value4);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rbx_v8 (System.Object)+30]");
				SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha((SpriteRenderer)0, 0.75f);
				Material material2 = MaterialManager.GetMaterial(MaterialType.Vfx);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rbx_v8 (System.Object)+30]");
				bool flag27 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rbx_v8 (System.Object)+30]");
				((Renderer)0).SetMaterial(material2);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rbx_v8 (System.Object)+50]");
				bool flag28 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rbx_v8 (System.Object)+10]");
				bool flag29 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rbx_v8 (System.Object)+10]");
				IntPtr gcHandlePtr6 = Component.get_transform_Injected((IntPtr)0);
				Transform transform6 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr6);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rbx_v8 (System.Object)+30]");
				bool flag30 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rbx_v8 (System.Object)+30]");
				Transform transform7 = ((Component)0).transform;
				Quaternion quaternion4 = Quaternion.Euler(0f, 0f, -90f);
				bool flag31 = (object)transform7 == null;
				bool flag32 = ((UnityEngine.Object)transform7).m_CachedPtr == (IntPtr)0;
				Transform.set_rotation_Injected(((UnityEngine.Object)transform7).m_CachedPtr, ref *(Quaternion*)(&value5));
				bool flag33 = (object)transform6 == null;
				bool flag34 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
				Transform.set_position_Injected(((UnityEngine.Object)transform6).m_CachedPtr, ref value6);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rbx_v8 (System.Object)+30]");
				SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha((SpriteRenderer)0, 1f);
				Material material3 = MaterialManager.GetMaterial(MaterialType.DefaultSprite);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rbx_v8 (System.Object)+30]");
				bool flag35 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rbx_v8 (System.Object)+30]");
				((Renderer)0).SetMaterial(material3);
				float z = -90f;
			}
		}
	}

	private void SpawnCursor(UISignals.SpawnOffScreenCursorSignal signal)
	{
		//IL_03cc: Expected O, but got I
		//IL_03dc: Expected O, but got I
		//IL_0330: Expected O, but got I
		//IL_0340: Expected O, but got I
		//IL_04a7->IL0410: Incompatible stack heights: 1 vs 0
		//IL_038c->IL0410: Incompatible stack heights: 1 vs 0
		//IL_02f0->IL0410: Incompatible stack heights: 1 vs 0
		//IL_03b1->IL0410: Incompatible stack heights: 1 vs 0
		//IL_0315->IL0410: Incompatible stack heights: 1 vs 0
		//IL_03fc->IL0410: Incompatible stack heights: 1 vs 0
		//IL_0360->IL0410: Incompatible stack heights: 1 vs 0
		if (_cursorIndicators != null)
		{
			int num = _cursorIndicators.FindEntry(signal.Target);
			if (num < 0)
			{
				goto IL_0149;
			}
			if (_cursorIndicators != null)
			{
				CursorIndicator cursorIndicator = _cursorIndicators.get_Item(signal.Target);
				if ((object)cursorIndicator != null)
				{
					CursorData cursorData = cursorIndicator._003CData_003Ek__BackingField;
					if (cursorIndicator._003CData_003Ek__BackingField != null)
					{
						cursorData._CursorInstanceReference = null;
						GameObject obj = cursorIndicator.gameObject;
						if ((object)((PoolableMonoBehaviour)cursorIndicator)._parentPool != null)
						{
							((PoolableMonoBehaviour)cursorIndicator)._parentPool.Release(obj);
							if (_cursorIndicators != null)
							{
								bool flag = ((Dictionary<object, object>)(object)_cursorIndicators).Remove((object)signal.Target);
								goto IL_0149;
							}
						}
					}
				}
			}
		}
		goto IL_0410;
		IL_04ac:
		Renderer renderer;
		bool flag2;
		renderer.enabled = flag2;
		return;
		IL_0410:
		throw new NullReferenceException();
		IL_0227:
		GameManager core = GM.Core;
		CursorIndicator objectComponent = default(CursorIndicator);
		if ((object)GM.Core != null && (object)signal.Target != null)
		{
			Transform transform = signal.Target.transform;
			if ((object)transform != null)
			{
				bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				if ((object)core._stage != null)
				{
					float2 position = default(float2);
					if (core._stage.ShouldShowCursor(position))
					{
						if ((object)objectComponent != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rax_v33 (VampireSurvivors.Framework.Cursors.CursorIndicator)+30]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rax_v33 (VampireSurvivors.Framework.Cursors.CursorIndicator)+30]");
								((Renderer)0).enabled = true;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rax_v33 (VampireSurvivors.Framework.Cursors.CursorIndicator)+38]");
								renderer = (Renderer)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rax_v33 (VampireSurvivors.Framework.Cursors.CursorIndicator)+38]");
								if ((nint)0 != 0)
								{
									flag2 = true;
									goto IL_04ac;
								}
							}
						}
					}
					else if ((object)objectComponent != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rax_v33 (VampireSurvivors.Framework.Cursors.CursorIndicator)+30]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rax_v33 (VampireSurvivors.Framework.Cursors.CursorIndicator)+30]");
							((Renderer)0).enabled = false;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rax_v33 (VampireSurvivors.Framework.Cursors.CursorIndicator)+38]");
							renderer = (Renderer)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rax_v33 (VampireSurvivors.Framework.Cursors.CursorIndicator)+38]");
							if ((nint)0 != 0)
							{
								flag2 = false;
								goto IL_04ac;
							}
						}
					}
				}
			}
		}
		goto IL_0410;
		IL_0149:
		if (_cursorIndicators != null)
		{
			if (((Dictionary<object, object>)(object)_cursorIndicators).TryGetValue((object)signal.Target, out object _))
			{
				goto IL_0227;
			}
			if ((object)_cursorsPool != null)
			{
				objectComponent = _cursorsPool.GetObjectComponent<CursorIndicator>();
				if ((object)objectComponent != null)
				{
					objectComponent.Init(signal.Data, signal.Target);
					if (_cursorIndicators != null)
					{
						bool flag4 = ((Dictionary<object, object>)(object)_cursorIndicators).TryInsert((object)signal.Target, (object)objectComponent, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
						goto IL_0227;
					}
				}
			}
		}
		goto IL_0410;
	}

	private void RemoveCursor(UISignals.RemoveOffScreenCursorSignal signal)
	{
		int num = _cursorIndicators.FindEntry((GameObject)signal);
		if (num >= 0)
		{
			CursorIndicator cursorIndicator = _cursorIndicators.get_Item((GameObject)signal);
			CursorData cursorData = cursorIndicator._003CData_003Ek__BackingField;
			cursorData._CursorInstanceReference = null;
			GameObject obj = cursorIndicator.gameObject;
			((PoolableMonoBehaviour)cursorIndicator)._parentPool.Release(obj);
			bool flag = ((Dictionary<object, object>)(object)_cursorIndicators).Remove((object)signal);
		}
	}

	private void HideCursor(UISignals.HideCursorSignal signal)
	{
		//IL_00f1->IL0070: Incompatible stack heights: 1 vs 0
		//IL_006f->IL006f: Incompatible stack heights: 1 vs 0
		if (_cursorIndicators != null)
		{
			if (!((Dictionary<object, object>)(object)_cursorIndicators).TryGetValue((object)signal, out object value))
			{
				return;
			}
			if (value != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ stack_8_v5 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ stack_8_v5 (System.Object)+10]");
				IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
				GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
				if ((object)gameObject != null)
				{
					gameObject.SetActive(value: false);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void ShowCursor(UISignals.ShowCursorSignal signal)
	{
		//IL_00f1->IL0070: Incompatible stack heights: 1 vs 0
		//IL_006f->IL006f: Incompatible stack heights: 1 vs 0
		if (_cursorIndicators != null)
		{
			if (!((Dictionary<object, object>)(object)_cursorIndicators).TryGetValue((object)signal, out object value))
			{
				return;
			}
			if (value != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ stack_8_v5 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ stack_8_v5 (System.Object)+10]");
				IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
				GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
				if ((object)gameObject != null)
				{
					gameObject.SetActive(value: true);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void HideAllCursors(UISignals.HideAllCursorsSignal signal)
	{
		Debug.Log("Hiding all cursors");
		_cursorsHidden = true;
		Dictionary<object, object>.Enumerator enumerator = default(Dictionary<object, object>.Enumerator);
		while (true)
		{
			if (!enumerator.MoveNext())
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
			object obj = null;
			if (false)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rbx_v7 (System.Object)+10]");
				if ((nint)0 == 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rbx_v7 (System.Object)+10]");
				IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
				GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
				gameObject.SetActive(value: false);
			}
		}
		UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(null);
		throw null;
	}

	private void UnHideCursors(UISignals.UnhideCursorsSignal signal)
	{
		//IL_00fd->IL00fd: Incompatible stack heights: 4 vs 0
		_cursorsHidden = false;
		Dictionary<object, object>.Enumerator enumerator = default(Dictionary<object, object>.Enumerator);
		while (enumerator.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
			GameObject gameObject = null;
			bool flag = 0 == 0;
			bool flag2 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
			GameObject gameObject2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
			bool flag3 = (object)gameObject2 == null;
			bool flag4 = ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
			GameObject.SetActive_Injected(((UnityEngine.Object)gameObject2).m_CachedPtr, true);
		}
	}

	private CursorIndicator SpawnCursorIndicator()
	{
		if ((object)_cursorsPool != null)
		{
			return _cursorsPool.GetObjectComponent<CursorIndicator>();
		}
		return (CursorIndicator)(object)new NullReferenceException();
	}

	private unsafe void PositionNearScreenEdge(CursorIndicator cursorIndicator, Vector3 targetPos)
	{
		//IL_0064: Invalid comparison between F4 and O
		//IL_011d: Expected native int or pointer, but got O
		//IL_0093: Invalid comparison between O and F4
		//IL_01c8: Expected I, but got O
		float proportionOfScreenFromCenter;
		if ((object)cursorIndicator != null)
		{
			CursorData cursorData = cursorIndicator._003CData_003Ek__BackingField;
			if (cursorIndicator._003CData_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1851B10F0");
				object obj = default(object);
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1851B10F0");
					object obj2 = default(object);
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.57f))
					{
						proportionOfScreenFromCenter = 0.38f;
						goto IL_0103;
					}
				}
				proportionOfScreenFromCenter = cursorData._cursorProportionOfScreenFromCenter;
				goto IL_0103;
			}
		}
		goto IL_00f7;
		IL_0103:
		float angle = default(float);
		GetArrowIndicatorPositionAndAngle(ref *(Vector3*)targetPos, ref angle, proportionOfScreenFromCenter);
		((Vector3*)(nint)targetPos)->z = 0f;
		Transform transform = cursorIndicator.transform;
		if ((object)cursorIndicator._CursorRenderer != null)
		{
			Transform transform2 = cursorIndicator._CursorRenderer.transform;
			Vector3 euler = default(Vector3);
			Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion _);
			bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			Quaternion value = default(Quaternion);
			Transform.set_rotation_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
			bool flag2 = ((CursorData)(object)transform).AnimationName == null;
			float value2 = default(float);
			Transform.set_position_Injected((IntPtr)((CursorData)(object)transform).AnimationName, ref *(Vector3*)(&value2));
			return;
		}
		goto IL_00f7;
		IL_00f7:
		throw new NullReferenceException();
	}

	private void PointAtTarget(CursorIndicator cursorIndicator, Vector3 targetPos)
	{
		if ((object)cursorIndicator != null && cursorIndicator._003CData_003Ek__BackingField != null)
		{
			Transform transform = cursorIndicator.transform;
			if ((object)cursorIndicator._CursorRenderer != null)
			{
				Transform transform2 = cursorIndicator._CursorRenderer.transform;
				Vector3 euler = default(Vector3);
				Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion _);
				bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Quaternion value = default(Quaternion);
				Transform.set_rotation_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
				bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value2 = default(Vector3);
				Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value2);
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void GenerateCursorsPool()
	{
		//IL_003b: Expected I4, but got I8
		string text = ((UnityEngine.Object)_CursorIndicatorPrefab).GetName();
		ObjectPool cursorsPool = ObjectPool.Create(_CursorIndicatorPrefab, text, 10, -1);
		_cursorsPool = cursorsPool;
		ObjectPool cursorsPool2 = _cursorsPool;
		cursorsPool2._incrementalInstanceNames = true;
		ObjectPool cursorsPool3 = _cursorsPool;
		if (!cursorsPool3._003CInitialized_003Ek__BackingField)
		{
			cursorsPool3._003CInitialized_003Ek__BackingField = true;
			cursorsPool3.AutoFillName();
			cursorsPool3.Populate(cursorsPool3._defaultSize);
		}
	}

	private static bool IsTargetVisible(Vector3 screenPosition)
	{
		//IL_02fa: Expected I4, but got O
		//IL_010b: Expected O, but got I4
		//IL_024a: Expected O, but got I4
		//IL_028b: Expected O, but got I4
		//IL_02bb: Expected O, but got I4
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Expected O, but got Unknown
		//IL_02d1: Expected O, but got I4
		//IL_03e8: Expected I4, but got O
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null && s_scene._renderer != null && (object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null && s_scene2._renderer != null && (object)GM.Core != null)
				{
					PhaserScene s_scene3 = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene != null)
					{
						bool flag = (nint)s_scene3._renderer < 0;
						bool flag2 = s_scene3._renderer == null;
						if (!flag2)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm0,xmm7\"");
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm1,xmm0\"");
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm2,xmm1\"");
							bool flag3 = !flag;
							bool flag4 = !flag2;
							object obj = flag4 & flag3;
							if ((object)GM.Core != null)
							{
								PhaserScene s_scene4 = ArcadePhysics.s_scene;
								if (ArcadePhysics.s_scene != null && s_scene4._renderer != null)
								{
									bool flag5 = (object)GM.Core == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm6,xmm7\"");
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm6,xmm0\"");
									if (!flag5)
									{
										PhaserScene s_scene5 = ArcadePhysics.s_scene;
										if (ArcadePhysics.s_scene != null)
										{
											bool flag6 = (nint)s_scene5._renderer < 0;
											object obj2 = (object)s_scene5._renderer ^ (object)s_scene5._renderer;
											object obj3 = (object)s_scene5._renderer & obj2;
											bool flag7 = (nint)obj3 < 0;
											bool flag8 = (nint)s_scene5._renderer < 0;
											bool flag9 = s_scene5._renderer == null;
											if (!flag9)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm0,xmm7\"");
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm1,xmm0\"");
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm2,xmm1\"");
												bool flag10 = !flag6;
												bool flag11 = !flag9;
												object obj4 = flag11 & flag10;
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm1,xmm7\"");
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm1,xmm0\"");
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,xmm3\"");
												bool flag12 = !flag6;
												bool flag13 = !flag9;
												object obj5 = flag13 & flag12;
												object obj6 = obj4 & obj5;
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm6,xmm8\"");
												bool flag14 = flag8 == flag7;
												object obj7 = !flag14;
												object obj8 = obj7 | flag9;
												object obj9 = 0;
												if (obj8 == null)
												{
													obj9 = obj6;
												}
												return (byte)(obj9 & obj) != 0;
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe static void GetArrowIndicatorPositionAndAngle(ref Vector3 screenPosition, ref float angle, float proportionOfScreenFromCenter = 0.45f)
	{
		//IL_0239->IL0188: Incompatible stack heights: 1 vs 0
		//IL_0260->IL0188: Incompatible stack heights: 1 vs 0
		//IL_0068->IL0188: Incompatible stack heights: 1 vs 0
		//IL_0090->IL0188: Incompatible stack heights: 1 vs 0
		//IL_0287->IL0188: Incompatible stack heights: 1 vs 0
		//IL_00c4->IL0188: Incompatible stack heights: 1 vs 0
		Camera main = Camera.main;
		if ((object)main != null)
		{
			Transform transform = main.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				object obj = screenPosition - ret;
				object obj3 = default(object);
				object obj4 = default(object);
				object obj2 = obj3 - obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
				ref float reference = ref *(float*)obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene != null)
					{
						PhaserScene.Renderer renderer = s_scene._renderer;
						if (s_scene._renderer != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
							if ((object)GM.Core != null)
							{
								PhaserScene s_scene2 = ArcadePhysics.s_scene;
								if (ArcadePhysics.s_scene != null)
								{
									PhaserScene.Renderer renderer2 = s_scene2._renderer;
									if (s_scene2._renderer != null)
									{
										float num = (float)obj2 * proportionOfScreenFromCenter;
										float num2 = angle * proportionOfScreenFromCenter;
										float num3 = num * renderer.width;
										float num4 = num2 * renderer2.height;
										float num5 = num3 + (float)ret;
										float num6 = num4 + (float)obj4;
										ref Vector3 reference2 = ref *(Vector3*)obj3;
										_ = 0;
										float num7 = num5 * 100f;
										float num8 = num6 * 100f;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
										reference2 = ref *(Vector3*)obj3;
										_ = 0;
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private static Vector2 GetPPURoundedPosition(Vector2 position)
	{
		float num = (float)position * 100f;
		object obj = default(object);
		float num2 = (float)obj * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
		Vector2 result = default(Vector2);
		return result;
	}

	private void RefreshCursors()
	{
		//IL_00cd: Expected O, but got I
		//IL_0103: Expected O, but got I
		//IL_010a->IL01d7: Incompatible stack heights: 9 vs 0
		Dictionary<object, object>.Enumerator enumerator = default(Dictionary<object, object>.Enumerator);
		float2 position = default(float2);
		while (enumerator.MoveNext())
		{
			Transform transform = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
			Transform transform2 = null;
			GameManager core = GM.Core;
			bool flag = (object)GM.Core == null;
			bool flag2 = 0 == 0;
			bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr = GameObject.get_transform_Injected(((UnityEngine.Object)transform).m_CachedPtr);
			Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			bool flag4 = (object)transform3 == null;
			bool flag5 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out Vector3 _);
			bool flag6 = (object)core._stage == null;
			bool flag7 = core._stage.ShouldShowCursor(position);
			bool flag8 = 0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rdi_v6 (UnityEngine.Transform)+30]");
			bool flag9 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rdi_v6 (UnityEngine.Transform)+30]");
			((Renderer)0).enabled = flag7;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rdi_v6 (UnityEngine.Transform)+38]");
			bool flag10 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rdi_v6 (UnityEngine.Transform)+38]");
			((Renderer)0).enabled = flag7;
		}
	}

	public CursorsManager()
	{
		Dictionary<GameObject, CursorIndicator> cursorIndicators = new Dictionary<GameObject, CursorIndicator>();
		_cursorIndicators = cursorIndicators;
	}
}
