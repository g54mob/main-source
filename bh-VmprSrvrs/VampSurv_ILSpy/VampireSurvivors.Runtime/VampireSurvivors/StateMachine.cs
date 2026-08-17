using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Doozy.Engine;
using UnityEngine;
using Zenject;

namespace VampireSurvivors;

public class StateMachine : MonoBehaviour
{
	public const string ENTER_DONE = "ENTER_DONE";

	private Action m_ExitStateEntered;

	private string _003CTransitionTriggerEvent_003Ek__BackingField;

	protected readonly Dictionary<Type, StateMachineState> instanceCache;

	protected Dictionary<Type, Dictionary<string, Type>> overallTransitionMap;

	protected StateMachineState currentState;

	protected Dictionary<string, Type> currentTransitionMap;

	protected DiContainer Container;

	public string TransitionTriggerEvent
	{
		get
		{
			return _003CTransitionTriggerEvent_003Ek__BackingField;
		}
		private set
		{
			_003CTransitionTriggerEvent_003Ek__BackingField = value;
		}
	}

	public StateMachineState CurrentState => currentState;

	public event Action ExitStateEntered
	{
		add
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 32;
			Delegate obj2 = this.m_ExitStateEntered;
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(Action);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 32;
			Delegate obj2 = this.m_ExitStateEntered;
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(Action);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	private void Construct(DiContainer container)
	{
		Container = container;
	}

	public unsafe void StartStateMachine<TInitialState>() where TInitialState : StateMachineState
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Ref, but got Unknown
		//IL_008e: Expected O, but got I4
		//IL_008e: Expected O, but got I
		//IL_00a0: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj3 = default(object);
		object key = obj3;
		ref object value = ref *(object*)(this + 72);
		bool flag = ((Dictionary<object, object>)(object)overallTransitionMap).TryGetValue(key, out value);
		Type type = null;
		bool flag2 = ((Dictionary<Type, Dictionary<string, Type>>)0).TryGetValue((Type)1, out System.Runtime.CompilerServices.Unsafe.As<object, Dictionary<string, Type>>(ref value));
		object obj4 = (flag2 ? 1 : 0) + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type type2 = default(Type);
		type = type2;
		SetCurrentState(type);
	}

	public virtual void Stop()
	{
		StateMachineState stateMachineState = currentState;
		if ((object)currentState != null && ((UnityEngine.Object)stateMachineState).m_CachedPtr != (IntPtr)0)
		{
			currentState.OnExit();
			currentState.enabled = false;
		}
		currentState = null;
		currentTransitionMap = null;
	}

	protected void ResetTransitionMap()
	{
		Stop();
		Dictionary<Type, Dictionary<string, Type>> dictionary = new Dictionary<Type, Dictionary<string, Type>>();
		overallTransitionMap = dictionary;
	}

	public void AddExitListener(Action listener)
	{
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		object obj = this + 32;
		Delegate obj2 = this.m_ExitStateEntered;
		while (true)
		{
			Delegate obj3 = Delegate.Combine(obj2, listener);
			bool flag = (object)obj3 == null;
			Delegate obj4 = null;
			if (!flag)
			{
				bool flag2 = (object)obj3.GetType() != typeof(Action);
				obj4 = null;
				if (!flag2)
				{
					obj4 = obj3;
				}
				if ((object)obj4 == null)
				{
					break;
				}
			}
			bool flag3 = obj2 == obj;
			Delegate obj5;
			if (obj2 == obj)
			{
				obj = obj4;
				obj5 = obj2;
			}
			else
			{
				obj5 = (Delegate)obj;
			}
			Delegate obj6 = obj2;
			if (!flag3)
			{
				obj6 = obj5;
			}
			bool flag4 = (object)obj6 != obj2;
			obj2 = obj6;
			if (!flag4)
			{
				return;
			}
		}
		throw new InvalidCastException();
	}

	public void RemoveExitListener(Action listener)
	{
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		object obj = this + 32;
		Delegate obj2 = this.m_ExitStateEntered;
		while (true)
		{
			Delegate obj3 = Delegate.Remove(obj2, listener);
			bool flag = (object)obj3 == null;
			Delegate obj4 = null;
			if (!flag)
			{
				bool flag2 = (object)obj3.GetType() != typeof(Action);
				obj4 = null;
				if (!flag2)
				{
					obj4 = obj3;
				}
				if ((object)obj4 == null)
				{
					break;
				}
			}
			bool flag3 = obj2 == obj;
			Delegate obj5;
			if (obj2 == obj)
			{
				obj = obj4;
				obj5 = obj2;
			}
			else
			{
				obj5 = (Delegate)obj;
			}
			Delegate obj6 = obj2;
			if (!flag3)
			{
				obj6 = obj5;
			}
			bool flag4 = (object)obj6 != obj2;
			obj2 = obj6;
			if (!flag4)
			{
				return;
			}
		}
		throw new InvalidCastException();
	}

	public virtual void ExitEntered()
	{
		Stop();
		Action exitStateEntered = this.m_ExitStateEntered;
		if (this.m_ExitStateEntered != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v13.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	protected unsafe void GoToState(Type state)
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected Ref, but got Unknown
		StateMachineState stateMachineState = currentState;
		if ((object)currentState != null && ((UnityEngine.Object)stateMachineState).m_CachedPtr != (IntPtr)0)
		{
			currentState.OnExit();
			currentState.enabled = false;
		}
		bool flag = ((Dictionary<object, object>)(object)overallTransitionMap).TryGetValue((object)state, out *(object*)(this + 72));
		SetCurrentState(state);
	}

	private unsafe void UpdateTransitionMap(Type state)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected Ref, but got Unknown
		bool flag = ((Dictionary<object, object>)(object)overallTransitionMap).TryGetValue((object)state, out *(object*)(this + 72));
	}

	protected virtual void SetCurrentState(Type stateType)
	{
		string text = stateType.ToString();
		string message = "Entering state : " + text;
		Debug.Log(message);
		StateMachineState stateInstance = GetStateInstance(stateType);
		currentState = stateInstance;
		currentState.enabled = true;
		currentState.OnEnter();
	}

	public unsafe virtual void FireEvent(string eventStr)
	{
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Expected Ref, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		if (currentTransitionMap == null)
		{
			StateMachineState stateMachineState = currentState;
			object message = (((object)currentState == null || ((UnityEngine.Object)stateMachineState).m_CachedPtr == (IntPtr)0) ? "No set state" : "No transitions set up");
			Debug.LogError(message);
		}
		if (!((Dictionary<object, object>)(object)currentTransitionMap).TryGetValue((object)eventStr, out object value))
		{
			StateMachineState stateMachineState2 = currentState;
			string text;
			object obj2;
			if ((object)currentState != null && ((UnityEngine.Object)stateMachineState2).m_CachedPtr != (IntPtr)0)
			{
				StateMachineState stateMachineState3 = currentState;
				object obj = stateMachineState3 + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
				text = "no transition for ";
				object obj3 = default(object);
				obj2 = obj3;
			}
			else
			{
				text = "no transition for ";
				obj2 = "null state";
			}
			string text2 = default(string);
			if (obj2 != null)
			{
				object obj4 = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v778 @ rdx_v19+168] (should have been resolved before IL gen)");
			}
			else
			{
				text2 = null;
			}
			string message2 = text + text2 + " and event " + eventStr;
			Debug.LogError(message2);
		}
		GameEventMessage.SendEvent(eventStr);
		_003CTransitionTriggerEvent_003Ek__BackingField = eventStr;
		if (value != null)
		{
			StateMachineState stateMachineState4 = currentState;
			if ((object)currentState != null && ((UnityEngine.Object)stateMachineState4).m_CachedPtr != (IntPtr)0)
			{
				currentState.OnExit();
				currentState.enabled = false;
			}
			bool flag = ((Dictionary<object, object>)(object)overallTransitionMap).TryGetValue(value, out *(object*)(this + 72));
			SetCurrentState((Type)value);
		}
		_003CTransitionTriggerEvent_003Ek__BackingField = null;
	}

	protected StateMachineState GetStateInstance(Type stateType)
	{
		//IL_0082: Expected I, but got O
		//IL_0090: Expected I, but got O
		//IL_00a0: Expected O, but got I
		//IL_0120: Expected O, but got I4
		//IL_00dc: Expected O, but got I
		//IL_0112: Expected O, but got I4
		//IL_01a4: Expected I, but got O
		//IL_01ce: Expected I, but got O
		//IL_01de: Expected O, but got I
		//IL_0278: Expected I, but got O
		//IL_021a: Expected O, but got I
		if (((Dictionary<object, object>)(object)instanceCache).TryGetValue((object)stateType, out object value))
		{
			goto IL_02a8;
		}
		GameObject gameObject = base.gameObject;
		Component component = gameObject.GetComponent(stateType);
		Component component2;
		nint num;
		if ((object)component == null)
		{
			component2 = null;
			num = 0;
			goto IL_02e1;
		}
		nint num2 = (nint)component;
		nint num3 = (nint)typeof(StateMachineState);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rdx_v17 (Il2CppClass<VampireSurvivors.StateMachineState>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ r9_v10 (Il2CppClass<UnityEngine.Component>)+130]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rdx_v17 (Il2CppClass<VampireSurvivors.StateMachineState>)+130]");
		object obj3;
		if (num4 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ r9_v10 (Il2CppClass<UnityEngine.Component>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v353 @ rax_v39+FFFFFFF8+v298 @ rax_v35*8]");
			if (0 == (nint)typeof(StateMachineState))
			{
				obj3 = 1;
				goto IL_02b2;
			}
		}
		obj3 = 0;
		goto IL_02b2;
		IL_02b2:
		bool flag = obj3 == null;
		component2 = null;
		num = num2;
		if (!flag)
		{
			component2 = component;
			num = num2;
		}
		goto IL_02e1;
		IL_02a8:
		return (StateMachineState)value;
		IL_02fe:
		object obj4;
		value = obj4;
		goto IL_025c;
		IL_02e1:
		if ((object)component2 != null)
		{
			bool flag2 = ((UnityEngine.Object)component2).m_CachedPtr != (IntPtr)0;
			value = component2;
			if (flag2)
			{
				goto IL_025c;
			}
		}
		GameObject gameObject2 = base.gameObject;
		Component component3 = gameObject2.Internal_AddComponentWithType(stateType);
		nint num5 = (nint)typeof(StateMachineState);
		bool flag3 = (object)component3 == null;
		obj4 = null;
		if (!flag3)
		{
			nint num6 = (nint)component3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rdx_v16 (Il2CppClass<VampireSurvivors.StateMachineState>)+130]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ r9_v9 (Il2CppClass<UnityEngine.Component>)+130]");
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rdx_v16 (Il2CppClass<VampireSurvivors.StateMachineState>)+130]");
			if (num7 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ r9_v9 (Il2CppClass<UnityEngine.Component>)+C8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rax_v28+FFFFFFF8+v217 @ rax_v27*8]");
				if (0 == (nint)typeof(StateMachineState))
				{
					obj4 = component3;
					num = num6;
					goto IL_02fe;
				}
			}
			return (StateMachineState)(object)new InvalidCastException();
		}
		goto IL_02fe;
		IL_025c:
		Container.Inject(value);
		nint num8 = (nint)value;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v528 @ rax_v18 (Il2CppClass<System.Object>)+178] (should have been resolved before IL gen)");
		bool flag4 = ((Dictionary<object, object>)(object)instanceCache).TryInsert((object)stateType, value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		goto IL_02a8;
	}

	protected unsafe void AddStateTransition<TFromState, TToState>(string eventStr) where TFromState : StateMachineState where TToState : StateMachineState
	{
		//IL_0047: Expected O, but got I4
		//IL_0047: Expected O, but got I
		//IL_0059: Expected O, but got I4
		//IL_00c7: Expected O, but got I4
		//IL_00c7: Expected O, but got I
		//IL_00d9: Expected O, but got I4
		//IL_0193: Expected O, but got I4
		//IL_0193: Expected O, but got I
		//IL_01a5: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ r8 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		IntPtr intPtr = default(IntPtr);
		bool flag = ((Dictionary<Type, Dictionary<string, Type>>)0).TryGetValue((Type)1, out *(Dictionary<string, Type>*)intPtr);
		object obj = (flag ? 1 : 0) + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		bool flag2 = overallTransitionMap == null;
		object obj2 = null;
		if (!flag2)
		{
			object key = default(object);
			Dictionary<string, Type> dictionary = default(Dictionary<string, Type>);
			if (!((Dictionary<object, object>)(object)overallTransitionMap).TryGetValue(key, out object value))
			{
				dictionary = new Dictionary<string, Type>();
				bool flag3 = ((Dictionary<Type, Dictionary<string, Type>>)0).TryGetValue((Type)1, out *(Dictionary<string, Type>*)(&value));
				object obj3 = (flag3 ? 1 : 0) + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
				object obj4 = default(object);
				object key2 = obj4;
				bool flag4 = overallTransitionMap == null;
				obj2 = null;
				if (flag4)
				{
					goto IL_01dc;
				}
				bool flag5 = ((Dictionary<object, object>)(object)overallTransitionMap).TryInsert(key2, (object)dictionary, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			}
			bool flag6 = dictionary == null;
			obj2 = null;
			if (!flag6)
			{
				int num = dictionary.FindEntry(eventStr);
				bool flag7 = num >= 0;
				obj2 = null;
				if (flag7)
				{
					string[] array = new string[5];
					throw new NullReferenceException();
				}
				obj2 = null;
				bool flag8 = ((Dictionary<Type, Dictionary<string, Type>>)0).TryGetValue((Type)1, out *(Dictionary<string, Type>*)null);
				object obj5 = (flag8 ? 1 : 0) + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
				object obj6 = default(object);
				obj2 = obj6;
				if (dictionary != null)
				{
					bool flag9 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)eventStr, obj2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
					return;
				}
			}
		}
		goto IL_01dc;
		IL_01dc:
		throw new NullReferenceException();
	}

	public StateMachine()
	{
		Dictionary<Type, StateMachineState> dictionary = new Dictionary<Type, StateMachineState>();
		instanceCache = dictionary;
		Dictionary<Type, Dictionary<string, Type>> dictionary2 = new Dictionary<Type, Dictionary<string, Type>>();
		overallTransitionMap = dictionary2;
	}
}
