using System;
using System.Collections.Generic;
using System.Reflection;
using Cpp2ILInjected;

namespace Doozy.Engine;

public class Message
{
	public delegate void OnMessageHandleDelegate(Type callerType, Type handlerType, Type messageType, string messageName, string handlerMethodName);

	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public Delegate callback;

		internal bool _003CUnregisterListener_003Eb__0(Delegate x)
		{
			//IL_0135: Expected I4, but got O
			if ((object)x != null)
			{
				MethodInfo methodImpl = x.GetMethodImpl();
				if ((object)callback != null)
				{
					MethodInfo methodImpl2 = callback.GetMethodImpl();
					if ((object)methodImpl != methodImpl2 && ((object)methodImpl == null || (object)methodImpl2 == null || !methodImpl.Equals(methodImpl2)))
					{
						return false;
					}
					Delegate obj = callback;
					if ((object)callback != null)
					{
						object obj2 = x.m_target - obj.m_target;
						return obj2 == null;
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private const string TYPELESS_MESSAGE_PREFIX = "typeless ";

	private static readonly Dictionary<string, List<Delegate>> Handlers;

	public static OnMessageHandleDelegate OnMessageHandle;

	protected Message()
	{
	}

	public static void AddListener(string messageName, Action callback)
	{
		string messageName2 = "typeless " + messageName;
		RegisterListener(messageName2, callback);
	}

	public static void AddListener<T>(Action<T> callback) where T : Message
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj4 = default(object);
		object obj3 = obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v162 @ rdx_v3+168] (should have been resolved before IL gen)");
		string messageName = default(string);
		RegisterListener(messageName, callback);
	}

	public static void AddListener<T>(string messageName, Action<T> callback) where T : Message
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ r8 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj3 = default(object);
		string text = default(string);
		if (obj3 != null)
		{
			object obj4 = obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v175 @ rdx_v6+168] (should have been resolved before IL gen)");
		}
		else
		{
			text = null;
		}
		string messageName2 = text + messageName;
		RegisterListener(messageName2, callback);
	}

	public static void RemoveListener(string messageName, Action callback)
	{
		string messageName2 = "typeless " + messageName;
		UnregisterListener(messageName2, callback);
	}

	public static void RemoveListener<T>(Action<T> callback) where T : Message
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj4 = default(object);
		object obj3 = obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v162 @ rdx_v3+168] (should have been resolved before IL gen)");
		string messageName = default(string);
		UnregisterListener(messageName, callback);
	}

	public static void RemoveListener<T>(string messageName, Action<T> callback) where T : Message
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ r8 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj3 = default(object);
		string text = default(string);
		if (obj3 != null)
		{
			object obj4 = obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v175 @ rdx_v6+168] (should have been resolved before IL gen)");
		}
		else
		{
			text = null;
		}
		string messageName2 = text + messageName;
		UnregisterListener(messageName2, callback);
	}

	public static void Send(string messageName)
	{
		string messageName2 = "typeless " + messageName;
		SendMessage<Message>(messageName2, null);
	}

	public static void Send<T>(T message) where T : Message
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj4 = default(object);
		object obj3 = obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v166 @ rdx_v3+168] (should have been resolved before IL gen)");
		string messageName = default(string);
		SendMessage(messageName, message);
	}

	public static void Send<T>(string messageName, T message) where T : Message
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ r8 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj3 = default(object);
		string text = default(string);
		if (obj3 != null)
		{
			object obj4 = obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v179 @ rdx_v6+168] (should have been resolved before IL gen)");
		}
		else
		{
			text = null;
		}
		string text2 = text + messageName;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 131 Invalid \"Jump target not found in method: 0x18309F360\"");
	}

	private static void RegisterListener(string messageName, Delegate callback)
	{
		if ((object)callback != null)
		{
			int num = Handlers.FindEntry(messageName);
			if (num < 0)
			{
				List<Delegate> value = new List<Delegate>();
				bool flag = ((Dictionary<object, object>)(object)Handlers).TryInsert((object)messageName, (object)value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			}
			List<Delegate> list = Handlers.get_Item(messageName);
			List<Delegate> list2 = ((Dictionary<string, List<Delegate>>)(object)list).get_Item((string)(object)callback);
		}
		else
		{
			DDebug.LogError("Failed to add listener because the given callback is null!");
		}
	}

	private static void UnregisterListener(string messageName, Delegate callback)
	{
		_003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass15_0();
		CS_0024_003C_003E8__locals5.callback = callback;
		int num = Handlers.FindEntry(messageName);
		if (num < 0)
		{
			return;
		}
		List<Delegate> list = Handlers.get_Item(messageName);
		Predicate<Delegate> match = delegate(Delegate x)
		{
			//IL_0135: Expected I4, but got O
			if ((object)x != null)
			{
				MethodInfo methodImpl = x.GetMethodImpl();
				if ((object)CS_0024_003C_003E8__locals5.callback != null)
				{
					MethodInfo methodImpl2 = CS_0024_003C_003E8__locals5.callback.GetMethodImpl();
					if ((object)methodImpl != methodImpl2 && ((object)methodImpl == null || (object)methodImpl2 == null || !methodImpl.Equals(methodImpl2)))
					{
						return false;
					}
					Delegate callback2 = CS_0024_003C_003E8__locals5.callback;
					if ((object)CS_0024_003C_003E8__locals5.callback != null)
					{
						object obj2 = x.m_target - callback2.m_target;
						return obj2 == null;
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		};
		Delegate obj = list.Find(match);
		if ((object)obj != null)
		{
			bool flag = ((List<object>)(object)list).Remove((object)obj);
		}
	}

	private static void SendMessage<T>(string messageName, T e) where T : Message
	{
		//IL_0098: Expected O, but got I4
		//IL_00ad: Expected O, but got I4
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected O, but got Unknown
		//IL_011c: Expected O, but got I4
		//IL_011c: Expected O, but got I
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected O, but got Unknown
		//IL_01be: Expected O, but got I
		//IL_019f: Expected I, but got O
		//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ff: Expected O, but got Unknown
		//IL_0317: Expected O, but got I
		//IL_034f: Expected O, but got I
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Expected O, but got Unknown
		//IL_0230: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ r8 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		int num = Handlers.FindEntry(messageName);
		if (num < 0)
		{
			return;
		}
		List<Delegate> list = Handlers.get_Item(messageName);
		Delegate[] array = list.ToArray();
		object obj = 0;
		nint num2 = 0;
		nint num3 = 0;
		object obj2 = 0;
		object obj6 = default(object);
		object obj7 = default(object);
		object obj9 = default(object);
		while (true)
		{
			if ((nint)obj2 >= array.Length)
			{
				return;
			}
			Delegate obj3 = array[obj];
			object obj4 = obj3 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			List<Delegate> list2 = ((Dictionary<string, List<Delegate>>)0).get_Item((string)1);
			object obj5 = list2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			num3 = 1;
			if (obj6 != obj7)
			{
				object obj8 = obj3 + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
				Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(Action));
				bool flag = obj9 != typeFromHandle;
				num3 = unchecked((nint)null);
				if (flag)
				{
					goto IL_02f1;
				}
			}
			Type typeFromHandle2 = Type.GetTypeFromHandle((RuntimeTypeHandle)0);
			Type typeFromHandle3 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(Message));
			if ((object)typeFromHandle2 != typeFromHandle3)
			{
				List<Delegate> list3 = ((Dictionary<string, List<Delegate>>)(object)obj3).get_Item((string)0);
				if (list3 == null)
				{
					throw new InvalidCastException();
				}
				List<Delegate> list4 = ((Dictionary<string, List<Delegate>>)(object)obj3).get_Item((string)0);
				if (list4 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v46 (System.Collections.Generic.List`1<System.Delegate>)+28]");
					num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v686._size (System.Int32) (should have been resolved before IL gen)");
					obj++;
					num3 = (nint)e;
					obj2 = obj;
					continue;
				}
				throw new InvalidCastException();
			}
			bool flag2 = (object)obj3.GetType() != typeof(Action);
			Delegate obj10 = null;
			if (!flag2)
			{
				obj10 = obj3;
			}
			if ((object)obj10 == null)
			{
				break;
			}
			bool flag3 = (object)obj3.GetType() != typeof(Action);
			Delegate obj11 = null;
			if (!flag3)
			{
				obj11 = obj3;
			}
			num3 = obj11.method;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v678.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			goto IL_02f1;
			IL_02f1:
			obj++;
			obj2 = obj;
		}
		throw new InvalidCastException();
	}

	static Message()
	{
		Dictionary<string, List<Delegate>> handlers = new Dictionary<string, List<Delegate>>();
		Handlers = handlers;
	}
}
