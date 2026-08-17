using System;
using Cpp2ILInjected;

namespace Rewired.Internal;

public static class ControllerTemplateFactory
{
	private static readonly Type[] _defaultTemplateTypes;

	private static readonly Type[] _defaultTemplateInterfaceTypes;

	public static Type[] templateTypes => _defaultTemplateTypes;

	public static Type[] templateInterfaceTypes => _defaultTemplateInterfaceTypes;

	public static IControllerTemplate Create(Guid typeGuid, object payload)
	{
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Expected O, but got Unknown
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected O, but got Unknown
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Expected O, but got Unknown
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Expected O, but got Unknown
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Expected O, but got Unknown
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = obj2 - 32;
		object obj3 = obj2 - 16;
		_ = typeGuid._a;
		_ = GamepadTemplate.typeGuid;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1814D9800");
		object obj4 = default(object);
		if (obj4 == null)
		{
			object obj5 = obj2 - 16;
			object obj6 = obj2 - 32;
			_ = typeGuid._a;
			_ = RacingWheelTemplate.typeGuid;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1814D9800");
			object obj7 = default(object);
			if (obj7 == null)
			{
				object obj8 = obj2 - 16;
				object obj9 = obj2 - 32;
				_ = typeGuid._a;
				_ = HOTASTemplate.typeGuid;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1814D9800");
				object obj10 = default(object);
				if (obj10 == null)
				{
					object obj11 = obj2 - 16;
					object obj12 = obj2 - 32;
					_ = typeGuid._a;
					_ = FlightYokeTemplate.typeGuid;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1814D9800");
					object obj13 = default(object);
					if (obj13 == null)
					{
						object obj14 = obj2 - 16;
						object obj15 = obj2 - 32;
						_ = typeGuid._a;
						_ = FlightPedalsTemplate.typeGuid;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1814D9800");
						object obj16 = default(object);
						if (obj16 == null)
						{
							object obj17 = obj2 - 16;
							object obj18 = obj2 - 32;
							_ = typeGuid._a;
							_ = SixDofControllerTemplate.typeGuid;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1814D9800");
							object obj19 = default(object);
							if (obj19 == null)
							{
								return null;
							}
							return new SixDofControllerTemplate(payload);
						}
						return new FlightPedalsTemplate(payload);
					}
					return new FlightYokeTemplate(payload);
				}
				return new HOTASTemplate(payload);
			}
			return new RacingWheelTemplate(payload);
		}
		return new GamepadTemplate(payload);
	}

	static ControllerTemplateFactory()
	{
		//IL_0030: Expected O, but got I4
		//IL_0071: Expected I, but got O
		//IL_0081: Expected O, but got I
		//IL_00ff: Expected I, but got O
		//IL_010f: Expected O, but got I
		//IL_018d: Expected I, but got O
		//IL_019d: Expected O, but got I
		//IL_021b: Expected I, but got O
		//IL_022b: Expected O, but got I
		//IL_02a9: Expected I, but got O
		//IL_02b9: Expected O, but got I
		//IL_0337: Expected I, but got O
		//IL_0347: Expected O, but got I
		//IL_03d4: Expected O, but got I4
		//IL_0415: Expected I, but got O
		//IL_0425: Expected O, but got I
		//IL_04a3: Expected I, but got O
		//IL_04b3: Expected O, but got I
		//IL_0531: Expected I, but got O
		//IL_0541: Expected O, but got I
		//IL_05bf: Expected I, but got O
		//IL_05cf: Expected O, but got I
		//IL_064d: Expected I, but got O
		//IL_065d: Expected O, but got I
		//IL_06db: Expected I, but got O
		//IL_06eb: Expected O, but got I
		Type[] array = new Type[6];
		Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(GamepadTemplate));
		bool flag = array == null;
		object obj = 0;
		RuntimeTypeHandle typeFromHandle2 = (RuntimeTypeHandle)typeof(GamepadTemplate);
		if (!flag)
		{
			if ((object)typeFromHandle != null)
			{
				nint num = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rdx_v89 (Il2CppClass<System.Type[]>)+40]");
				obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj2 = default(object);
				bool flag2 = obj2 == null;
				typeFromHandle2 = (RuntimeTypeHandle)typeFromHandle;
				if (flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
					Type type = default(Type);
					throw type;
				}
			}
			array[0] = typeFromHandle;
			Type typeFromHandle3 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(RacingWheelTemplate));
			if ((object)typeFromHandle3 != null)
			{
				nint num2 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rdx_v87 (Il2CppClass<System.Type[]>)+40]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj4 = default(object);
				bool flag3 = obj4 == null;
				Type type2 = typeFromHandle3;
				if (flag3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
					Type type3 = default(Type);
					throw type3;
				}
			}
			array[1] = typeFromHandle3;
			Type typeFromHandle4 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(HOTASTemplate));
			if ((object)typeFromHandle4 != null)
			{
				nint num3 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v513 @ rdx_v85 (Il2CppClass<System.Type[]>)+40]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj6 = default(object);
				bool flag4 = obj6 == null;
				Type type4 = typeFromHandle4;
				if (flag4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
					Type type5 = default(Type);
					throw type5;
				}
			}
			array[2] = typeFromHandle4;
			Type typeFromHandle5 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(FlightYokeTemplate));
			if ((object)typeFromHandle5 != null)
			{
				nint num4 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v577 @ rdx_v83 (Il2CppClass<System.Type[]>)+40]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj8 = default(object);
				bool flag5 = obj8 == null;
				Type type6 = typeFromHandle5;
				if (flag5)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
					Type type7 = default(Type);
					throw type7;
				}
			}
			array[3] = typeFromHandle5;
			Type typeFromHandle6 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(FlightPedalsTemplate));
			if ((object)typeFromHandle6 != null)
			{
				nint num5 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v638 @ rdx_v81 (Il2CppClass<System.Type[]>)+40]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj10 = default(object);
				bool flag6 = obj10 == null;
				Type type8 = typeFromHandle6;
				if (flag6)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
					Type type9 = default(Type);
					throw type9;
				}
			}
			array[4] = typeFromHandle6;
			Type typeFromHandle7 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(SixDofControllerTemplate));
			if ((object)typeFromHandle7 != null)
			{
				nint num6 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v729 @ rdx_v79 (Il2CppClass<System.Type[]>)+40]");
				object obj11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj12 = default(object);
				bool flag7 = obj12 == null;
				Type type10 = typeFromHandle7;
				if (flag7)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
					Type type11 = default(Type);
					throw type11;
				}
			}
			array[5] = typeFromHandle7;
			_defaultTemplateTypes = array;
			Type[] array2 = new Type[6];
			Type typeFromHandle8 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(IGamepadTemplate));
			bool flag8 = array2 == null;
			obj = 0;
			typeFromHandle2 = (RuntimeTypeHandle)typeof(IGamepadTemplate);
			if (!flag8)
			{
				if ((object)typeFromHandle8 != null)
				{
					nint num7 = (nint)array2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v831 @ rdx_v77 (Il2CppClass<System.Type[]>)+40]");
					object obj13 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					object obj14 = default(object);
					bool flag9 = obj14 == null;
					Type type12 = typeFromHandle8;
					if (flag9)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
						Type type13 = default(Type);
						throw type13;
					}
				}
				array2[0] = typeFromHandle8;
				Type typeFromHandle9 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(IRacingWheelTemplate));
				if ((object)typeFromHandle9 != null)
				{
					nint num8 = (nint)array2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v892 @ rdx_v75 (Il2CppClass<System.Type[]>)+40]");
					object obj15 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					object obj16 = default(object);
					bool flag10 = obj16 == null;
					Type type14 = typeFromHandle9;
					if (flag10)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
						Type type15 = default(Type);
						throw type15;
					}
				}
				array2[1] = typeFromHandle9;
				Type typeFromHandle10 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(IHOTASTemplate));
				if ((object)typeFromHandle10 != null)
				{
					nint num9 = (nint)array2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v970 @ rdx_v73 (Il2CppClass<System.Type[]>)+40]");
					object obj17 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					object obj18 = default(object);
					bool flag11 = obj18 == null;
					Type type16 = typeFromHandle10;
					if (flag11)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
						Type type17 = default(Type);
						throw type17;
					}
				}
				array2[2] = typeFromHandle10;
				Type typeFromHandle11 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(IFlightYokeTemplate));
				if ((object)typeFromHandle11 != null)
				{
					nint num10 = (nint)array2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v998 @ rdx_v71 (Il2CppClass<System.Type[]>)+40]");
					object obj19 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					object obj20 = default(object);
					bool flag12 = obj20 == null;
					Type type18 = typeFromHandle11;
					if (flag12)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
						Type type19 = default(Type);
						throw type19;
					}
				}
				array2[3] = typeFromHandle11;
				Type typeFromHandle12 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(IFlightPedalsTemplate));
				if ((object)typeFromHandle12 != null)
				{
					nint num11 = (nint)array2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1026 @ rdx_v69 (Il2CppClass<System.Type[]>)+40]");
					object obj21 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					object obj22 = default(object);
					bool flag13 = obj22 == null;
					Type type20 = typeFromHandle12;
					if (flag13)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
						Type type21 = default(Type);
						throw type21;
					}
				}
				array2[4] = typeFromHandle12;
				Type typeFromHandle13 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(ISixDofControllerTemplate));
				if ((object)typeFromHandle13 != null)
				{
					nint num12 = (nint)array2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1054 @ rdx_v67 (Il2CppClass<System.Type[]>)+40]");
					object obj23 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					object obj24 = default(object);
					bool flag14 = obj24 == null;
					Type type22 = typeFromHandle13;
					if (flag14)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
						object obj25 = default(object);
						throw obj25;
					}
				}
				array2[5] = typeFromHandle13;
				_defaultTemplateInterfaceTypes = array2;
				return;
			}
		}
		throw new NullReferenceException();
	}
}
