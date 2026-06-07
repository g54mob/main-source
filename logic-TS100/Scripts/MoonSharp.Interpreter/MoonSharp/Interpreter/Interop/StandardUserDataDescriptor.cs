using System;
using System.Linq;
using System.Reflection;
using MoonSharp.Interpreter.Interop.BasicDescriptors;
using MoonSharp.Interpreter.Interop.Converters;

namespace MoonSharp.Interpreter.Interop
{
	public class StandardUserDataDescriptor : DispatchingUserDataDescriptor
	{
		public InteropAccessMode AccessMode { get; private set; }

		public StandardUserDataDescriptor(Type type, InteropAccessMode accessMode, string friendlyName = null)
			: base(type, friendlyName)
		{
			if (accessMode == InteropAccessMode.NoReflectionAllowed)
			{
				throw new ArgumentException("Can't create a StandardUserDataDescriptor under a NoReflectionAllowed access mode");
			}
			if (Script.GlobalOptions.Platform.IsRunningOnAOT())
			{
				accessMode = InteropAccessMode.Reflection;
			}
			if (accessMode == InteropAccessMode.Default)
			{
				accessMode = UserData.DefaultAccessMode;
			}
			AccessMode = accessMode;
			FillMemberList();
		}

		private void FillMemberList()
		{
			Type type = base.Type;
			InteropAccessMode accessMode = AccessMode;
			if (AccessMode == InteropAccessMode.HideMembers)
			{
				return;
			}
			ConstructorInfo[] constructors = type.GetConstructors(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (ConstructorInfo methodBase in constructors)
			{
				AddMember("__new", MethodMemberDescriptor.TryCreateIfVisible(methodBase, AccessMode));
			}
			if (type.IsValueType)
			{
				AddMember("__new", new ValueTypeDefaultCtorMemberDescriptor(type));
			}
			MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (MethodInfo methodInfo in methods)
			{
				MethodMemberDescriptor methodMemberDescriptor = MethodMemberDescriptor.TryCreateIfVisible(methodInfo, AccessMode);
				if (methodMemberDescriptor == null || !MethodMemberDescriptor.CheckMethodIsCompatible(methodInfo, false))
				{
					continue;
				}
				string name = methodInfo.Name;
				if (methodInfo.IsSpecialName && (methodInfo.Name == "op_Explicit" || methodInfo.Name == "op_Implicit"))
				{
					name = methodInfo.ReturnType.GetConversionMethodName();
				}
				AddMember(name, methodMemberDescriptor);
				foreach (string metaNamesFromAttribute in methodInfo.GetMetaNamesFromAttributes())
				{
					AddMetaMember(metaNamesFromAttribute, methodMemberDescriptor);
				}
			}
			PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (PropertyInfo propertyInfo in properties)
			{
				if (!propertyInfo.IsSpecialName && !propertyInfo.GetIndexParameters().Any())
				{
					AddMember(propertyInfo.Name, PropertyMemberDescriptor.TryCreateIfVisible(propertyInfo, AccessMode));
				}
			}
			FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (FieldInfo fieldInfo in fields)
			{
				if (!fieldInfo.IsSpecialName)
				{
					AddMember(fieldInfo.Name, FieldMemberDescriptor.TryCreateIfVisible(fieldInfo, AccessMode));
				}
			}
			EventInfo[] events = type.GetEvents(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (EventInfo eventInfo in events)
			{
				if (!eventInfo.IsSpecialName)
				{
					AddMember(eventInfo.Name, EventMemberDescriptor.TryCreateIfVisible(eventInfo, AccessMode));
				}
			}
			Type[] nestedTypes = type.GetNestedTypes(BindingFlags.Public | BindingFlags.NonPublic);
			foreach (Type type2 in nestedTypes)
			{
				if (type2.IsNestedPublic || type2.GetCustomAttributes(typeof(MoonSharpUserDataAttribute), true).Length > 0)
				{
					UserData.RegisterType(type2, AccessMode);
					AddDynValue(type2.Name, UserData.CreateStatic(type2));
				}
			}
			if (base.Type.IsArray)
			{
				int arrayRank = base.Type.GetArrayRank();
				ParameterDescriptor[] array = new ParameterDescriptor[arrayRank];
				ParameterDescriptor[] array2 = new ParameterDescriptor[arrayRank + 1];
				for (int num = 0; num < arrayRank; num++)
				{
					array[num] = (array2[num] = new ParameterDescriptor("idx" + num, typeof(int)));
				}
				array2[arrayRank] = new ParameterDescriptor("value", base.Type.GetElementType());
				AddMember("set_Item", new ObjectCallbackMemberDescriptor("set_Item", ArrayIndexerSet, array2));
				AddMember("get_Item", new ObjectCallbackMemberDescriptor("get_Item", ArrayIndexerGet, array));
			}
			else if (base.Type == typeof(Array))
			{
				AddMember("set_Item", new ObjectCallbackMemberDescriptor("set_Item", ArrayIndexerSet));
				AddMember("get_Item", new ObjectCallbackMemberDescriptor("get_Item", ArrayIndexerGet));
			}
		}

		private int[] BuildArrayIndices(CallbackArguments args, int count)
		{
			int[] array = new int[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = args.AsInt(i, "userdata_array_indexer");
			}
			return array;
		}

		private object ArrayIndexerSet(object arrayObj, ScriptExecutionContext ctx, CallbackArguments args)
		{
			Array array = (Array)arrayObj;
			int[] indices = BuildArrayIndices(args, args.Count - 1);
			DynValue value = args[args.Count - 1];
			Type elementType = array.GetType().GetElementType();
			object value2 = ScriptToClrConversions.DynValueToObjectOfType(value, elementType, null, false);
			array.SetValue(value2, indices);
			return DynValue.Void;
		}

		private object ArrayIndexerGet(object arrayObj, ScriptExecutionContext ctx, CallbackArguments args)
		{
			Array array = (Array)arrayObj;
			int[] indices = BuildArrayIndices(args, args.Count);
			return array.GetValue(indices);
		}
	}
}
