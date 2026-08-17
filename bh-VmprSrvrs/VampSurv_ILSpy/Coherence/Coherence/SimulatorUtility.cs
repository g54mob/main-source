using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using Coherence.Log;
using Coherence.Transport;
using Coherence.Utils;
using Cpp2ILInjected;
using UnityEngine;

namespace Coherence;

public static class SimulatorUtility
{
	public enum Type
	{
		Undefined,
		World,
		Rooms
	}

	private const string ArgumentPrefix = "--coherence";

	private static readonly Coherence.Log.Logger Logger;

	private static readonly string[] Args;

	public const string LocalRegionParameter = "local";

	public const string SimulatorTypeRoomsParameter = "rooms";

	public const string SimulatorTypeWorldParameter = "world";

	internal const string AuthTokenKeyword = "--coherence-auth-token";

	private static readonly Dictionary<string, string> ArgumentsDict;

	private static bool wantsToBehaveAsSimulator;

	public unsafe static Type SimulatorType
	{
		get
		{
			//IL_0059: Expected O, but got I4
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Expected O, but got Unknown
			//IL_0310: Expected I4, but got O
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Expected Ref, but got Unknown
			//IL_0182: Expected I8, but got I4
			//IL_018c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0191: Expected Ref, but got Unknown
			//IL_0265: Unknown result type (might be due to invalid IL or missing references)
			//IL_026a: Expected Ref, but got Unknown
			//IL_0281: Expected I8, but got I4
			//IL_028b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0290: Expected Ref, but got Unknown
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			if (commandLineArgs != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180507B80");
				object obj = default(object);
				if ((nint)obj != -1)
				{
					object obj2 = commandLineArgs.Length - 1;
					if (obj != obj2)
					{
						object obj3 = obj + 1;
						if ((nint)obj3 >= commandLineArgs.Length)
						{
							IndexOutOfRangeException ex = new IndexOutOfRangeException();
							return (Type)ex;
						}
						string text = commandLineArgs[obj3];
						object obj4 = "world";
						if ((object)commandLineArgs[obj3] == "world")
						{
							goto IL_02c4;
						}
						if (commandLineArgs[obj3] != null && "world" != null)
						{
							int stringLength = text._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ rdx_v6+10]");
							if ((nint)stringLength == 0)
							{
								ref byte first = ref *(byte*)(commandLineArgs[obj3] + 20);
								ulong length = (ulong)(text._stringLength + text._stringLength);
								if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("world" + 20), length))
								{
									goto IL_02c4;
								}
							}
						}
						object obj5 = "rooms";
						if ((object)commandLineArgs[obj3] == "rooms")
						{
							goto IL_02be;
						}
						if (commandLineArgs[obj3] != null && "rooms" != null)
						{
							int stringLength2 = text._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rdx_v9+10]");
							if ((nint)stringLength2 == 0)
							{
								ref byte first2 = ref *(byte*)(commandLineArgs[obj3] + 20);
								ulong length2 = (ulong)(text._stringLength + text._stringLength);
								if (System.SpanHelpers.SequenceEqual(ref first2, ref *(byte*)("rooms" + 20), length2))
								{
									goto IL_02be;
								}
							}
						}
					}
				}
				return Type.Undefined;
			}
			ArgumentNullException ex2 = new ArgumentNullException("array");
			throw ex2;
			IL_02be:
			return Type.Rooms;
			IL_02c4:
			return Type.World;
		}
	}

	public static string Region
	{
		get
		{
			string argument = GetArgument("--coherence-region");
			if (argument == null)
			{
				return GetArgument("--coherence-play-region");
			}
			return argument;
		}
	}

	public static string Ip => GetArgument("--coherence-ip");

	public unsafe static int Port
	{
		get
		{
			//IL_0033: Expected O, but got Ref
			string argument = GetArgument("--coherence-port");
			if (argument != null)
			{
				NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
				object obj = default(object);
				if (System.Number.TryParseInt32((ReadOnlySpan<char>)(&obj), NumberStyles.Integer, currentInfo, out int result))
				{
					return result;
				}
			}
			return 0;
		}
	}

	public static int RoomId
	{
		get
		{
			//IL_004c: Expected I4, but got I8
			string argument = GetArgument("--coherence-room-id");
			bool flag = ushort.TryParse(argument, out var result);
			int result2 = result;
			if (!flag)
			{
				result2 = -1;
			}
			return result2;
		}
	}

	public unsafe static ulong UniqueRoomId
	{
		get
		{
			//IL_005b: Expected I8, but got I4
			//IL_0033: Expected O, but got Ref
			string argument = GetArgument("--coherence-unique-room-id");
			if (argument != null)
			{
				NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
				object obj = default(object);
				if (System.Number.TryParseUInt64((ReadOnlySpan<char>)(&obj), NumberStyles.Integer, currentInfo, out ulong result))
				{
					return result;
				}
			}
			return 0uL;
		}
	}

	public unsafe static ulong WorldId
	{
		get
		{
			//IL_005b: Expected I8, but got I4
			//IL_0033: Expected O, but got Ref
			string argument = GetArgument("--coherence-world-id");
			if (argument != null)
			{
				NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
				object obj = default(object);
				if (System.Number.TryParseUInt64((ReadOnlySpan<char>)(&obj), NumberStyles.Integer, currentInfo, out ulong result))
				{
					return result;
				}
			}
			return 0uL;
		}
	}

	public unsafe static int HttpServerPort
	{
		get
		{
			//IL_005a: Expected I4, but got I8
			//IL_0033: Expected O, but got Ref
			string argument = GetArgument("--coherence-http-server-port");
			int result2;
			if (argument != null)
			{
				NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
				object obj = default(object);
				bool flag = System.Number.TryParseInt32((ReadOnlySpan<char>)(&obj), NumberStyles.Integer, currentInfo, out int result);
				result2 = result;
				if (flag)
				{
					goto IL_0090;
				}
			}
			result2 = -1;
			goto IL_0090;
			IL_0090:
			return result2;
		}
	}

	public static string AuthToken => GetArgument("--coherence-auth-token");

	internal static bool UseSharedCloudCredentials
	{
		get
		{
			string argument = GetArgument("--coherence-auth-token");
			if (argument != null && argument._stringLength > 0)
			{
				return true;
			}
			return false;
		}
	}

	public unsafe static bool IsCloudSimulator
	{
		get
		{
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Expected Ref, but got Unknown
			//IL_011a: Expected I8, but got I4
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			//IL_0129: Expected Ref, but got Unknown
			string argument = GetArgument("--coherence-auth-token");
			if (argument != null && argument._stringLength > 0)
			{
				string region = Region;
				object obj = "local";
				if ((object)region != "local")
				{
					if (region != null && "local" != null)
					{
						int stringLength = region._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rdx_v2+10]");
						if ((nint)stringLength == 0)
						{
							ref byte first = ref *(byte*)(region + 20);
							ulong length = (ulong)(region._stringLength + region._stringLength);
							bool flag = System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("local" + 20), length);
							return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
						}
					}
					return true;
				}
				return false;
			}
			return false;
		}
	}

	public unsafe static List<string> RoomTags
	{
		get
		{
			//IL_025b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0260: Expected I, but got Unknown
			//IL_0122: Expected O, but got I4
			//IL_012b: Expected O, but got I4
			//IL_022c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0231: Expected O, but got Unknown
			//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ec: Expected O, but got Unknown
			List<string> list = new List<string>();
			string argument = GetArgument("--coherence-room-tags");
			if (argument != null && argument._stringLength > 0)
			{
				char* inputPtr = (char*)(nint)(argument + 20);
				byte[] bytes = Convert.FromBase64CharPtr(inputPtr, argument._stringLength);
				Encoding uTF = Encoding.UTF8;
				if (uTF == null)
				{
					goto IL_0265;
				}
				string text = uTF.GetString(bytes);
				if (text != null && text._stringLength > 0)
				{
					string[] array = text.Split(' ');
					bool flag = array == null;
					object obj = 0;
					object obj2 = 0;
					if (flag)
					{
						goto IL_0265;
					}
					while ((nint)obj2 < array.Length)
					{
						if (list != null)
						{
							int version = list._version + 1;
							list._version = version;
							string[] items = list._items;
							if (list._items != null)
							{
								if (list._size >= items.Length)
								{
									((List<object>)(object)list).AddWithResize((object)array[obj]);
									obj++;
									obj2 = obj;
								}
								else
								{
									int size = list._size + 1;
									list._size = size;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									obj++;
									obj2 = obj;
								}
								continue;
							}
						}
						goto IL_0265;
					}
				}
			}
			return list;
			IL_0265:
			return (List<string>)(object)new NullReferenceException();
		}
	}

	public unsafe static Dictionary<string, string> RoomKV
	{
		get
		{
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Expected I, but got Unknown
			string argument = GetArgument("--coherence-room-kv-json");
			if (argument == null || argument._stringLength <= 0)
			{
				return new Dictionary<string, string>();
			}
			char* inputPtr = (char*)(nint)(argument + 20);
			byte[] bytes = Convert.FromBase64CharPtr(inputPtr, argument._stringLength);
			Encoding uTF = Encoding.UTF8;
			if (uTF != null)
			{
				string value = uTF.GetString(bytes);
				return (Dictionary<string, string>)Coherence.Utils.CoherenceJson.DeserializeObject<object>(value);
			}
			return (Dictionary<string, string>)(object)new NullReferenceException();
		}
	}

	private static bool HasSimulatorCommandLineParameter
	{
		get
		{
			//IL_0082: Expected I4, but got O
			if (ArgumentsDict != null)
			{
				int num = ArgumentsDict.FindEntry("--coherence-simulation-server");
				if (num >= 0)
				{
					return true;
				}
				if (ArgumentsDict != null)
				{
					int num2 = ArgumentsDict.FindEntry("--coherence-simulator");
					int num3 = num2 >> 31;
					return (byte)(num3 ^ 1) != 0;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public static bool IsInvokedAsSimulator
	{
		get
		{
			//IL_008a: Expected I4, but got O
			if (!wantsToBehaveAsSimulator)
			{
				if (ArgumentsDict != null)
				{
					int num = ArgumentsDict.FindEntry("--coherence-simulation-server");
					if (num >= 0)
					{
						goto IL_0005;
					}
					if (ArgumentsDict != null)
					{
						int num2 = ArgumentsDict.FindEntry("--coherence-simulator");
						int num3 = num2 >> 31;
						return (byte)(num3 ^ 1) != 0;
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			goto IL_0005;
			IL_0005:
			return true;
		}
	}

	public static bool IsInvokedInCommandLine
	{
		get
		{
			//IL_000b: Expected O, but got I
			//IL_0019: Expected I, but got O
			object obj = 0;
			nint num = (nint)typeof(Application);
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v55 @ rax_v4 (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-28), the output could be wrong!");
			/*Error: End of method reached without returning.*/;
		}
	}

	public static bool IsSimulator
	{
		get
		{
			//IL_00d0: Expected I4, but got O
			if (wantsToBehaveAsSimulator)
			{
				goto IL_0028;
			}
			if (ArgumentsDict != null)
			{
				int num = ArgumentsDict.FindEntry("--coherence-simulation-server");
				if (num >= 0)
				{
					goto IL_0028;
				}
				if (ArgumentsDict != null)
				{
					int num2 = ArgumentsDict.FindEntry("--coherence-simulator");
					int num3 = num2 >> 31;
					return (byte)(num3 ^ 1) != 0;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_0028:
			return true;
		}
		set
		{
			wantsToBehaveAsSimulator = value;
		}
	}

	static SimulatorUtility()
	{
		//IL_01f4: Expected I, but got O
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0048: Expected O, but got I
		//IL_018f: Expected O, but got I4
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		nint num = (nint)typeof(SimulatorUtility);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		Coherence.Log.Logger logger = Coherence.Log.Log.GetLogger((System.Type)num);
		Logger = logger;
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		Args = commandLineArgs;
		Dictionary<string, string> argumentsDict = new Dictionary<string, string>();
		ArgumentsDict = argumentsDict;
		object obj3 = 0;
		while (true)
		{
			string[] args = Args;
			if ((nint)obj3 >= args.Length)
			{
				return;
			}
			if (args[obj3].StartsWith("--coherence"))
			{
				string[] args2 = Args;
				if (Args == null)
				{
					break;
				}
				object obj4 = obj3 + 1;
				string val;
				if (args2.Length > (nint)obj4)
				{
					string[] args3 = Args;
					object obj5 = obj3 + 1;
					val = args3[obj5];
				}
				else
				{
					val = null;
				}
				AddArgument(args[obj3], val);
			}
			obj3++;
		}
		throw new NullReferenceException();
	}

	public new unsafe static string ToString()
	{
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_0093: Expected I4, but got O
		//IL_00c1: Expected I, but got O
		//IL_0125: Expected I, but got O
		//IL_018e: Expected I, but got O
		//IL_027e: Expected O, but got I
		//IL_0290: Expected O, but got I4
		//IL_081a: Unknown result type (might be due to invalid IL or missing references)
		//IL_081f: Expected O, but got Unknown
		//IL_07e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ee: Expected O, but got Unknown
		//IL_029d: Expected I, but got O
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected Ref, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_022f: Expected O, but got I
		//IL_024f: Expected O, but got I
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ef: Expected Ref, but got Unknown
		//IL_0315: Expected O, but got I
		//IL_0873: Unknown result type (might be due to invalid IL or missing references)
		//IL_0878: Expected O, but got Unknown
		//IL_0330: Expected O, but got I8
		//IL_033d: Expected I, but got O
		//IL_0447: Expected O, but got I4
		//IL_092a: Unknown result type (might be due to invalid IL or missing references)
		//IL_092f: Expected O, but got Unknown
		//IL_08f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08fe: Expected O, but got Unknown
		//IL_0454: Expected I, but got O
		//IL_039b: Expected O, but got I
		//IL_03a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a9: Expected Ref, but got Unknown
		//IL_03bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c4: Expected O, but got Unknown
		//IL_03ee: Expected O, but got I
		//IL_040e: Expected O, but got I
		//IL_055e: Expected O, but got I4
		//IL_09e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e6: Expected O, but got Unknown
		//IL_09b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b5: Expected O, but got Unknown
		//IL_056b: Expected I, but got O
		//IL_04b2: Expected O, but got I
		//IL_04bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c0: Expected Ref, but got Unknown
		//IL_04d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04db: Expected O, but got Unknown
		//IL_0505: Expected O, but got I
		//IL_0525: Expected O, but got I
		//IL_0a4d: Expected O, but got I8
		//IL_0aa5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aaa: Expected O, but got Unknown
		//IL_06ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f4: Expected O, but got Unknown
		//IL_0708: Expected native int or pointer, but got O
		//IL_065f: Expected I, but got O
		//IL_0a74: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a79: Expected O, but got Unknown
		//IL_071b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0720: Expected O, but got Unknown
		//IL_06b5: Expected I, but got O
		//IL_05c9: Expected O, but got I
		//IL_05d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d7: Expected Ref, but got Unknown
		//IL_05ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f2: Expected O, but got Unknown
		//IL_0624: Expected O, but got I8
		//IL_064a: Expected O, but got I
		string argument = GetArgument("--coherence-auth-token");
		object obj;
		if (argument != null)
		{
			bool flag = argument._stringLength > 0;
			obj = "not null";
			if (flag)
			{
				goto IL_075c;
			}
		}
		obj = "null";
		goto IL_075c;
		IL_0811:
		object obj3 = default(object);
		object obj2 = obj3 + 40;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj4 = default(object);
		object[] array;
		if (obj4 != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			if (obj5 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		_ = 0;
		string argument2 = GetArgument("--coherence-room-id");
		bool flag2 = ushort.TryParse(argument2, out *(ushort*)(obj3 + 40));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+28]");
		object obj6 = 0;
		if (!flag2)
		{
			obj6 = 4294967295L;
		}
		object obj7 = obj3 + 40;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		NumberFormatInfo numberFormatInfo = default(NumberFormatInfo);
		if (numberFormatInfo != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj8 = default(object);
			if (obj8 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		_ = 0;
		string argument3 = GetArgument("--coherence-unique-room-id");
		bool flag3 = argument3 == null;
		ref int reference2;
		ref ulong reference = ref System.Runtime.CompilerServices.Unsafe.As<int, ulong>(ref reference2);
		NumberFormatInfo numberFormatInfo2 = numberFormatInfo;
		object obj10;
		ref ulong reference3;
		object obj12;
		NumberFormatInfo numberFormatInfo3;
		object obj11;
		if (!flag3)
		{
			object obj9 = argument3 + 20;
			_ = 0;
			_ = argument3._stringLength;
			NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-40]");
			obj10 = 0;
			reference = ref *(ulong*)(obj3 + 40);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-40]");
			_ = 0;
			ReadOnlySpan<char> value = (ReadOnlySpan<char>)(obj3 - 64);
			bool flag4 = System.Number.TryParseUInt64(value, NumberStyles.Integer, currentInfo, out reference);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+28]");
			obj11 = 0;
			numberFormatInfo2 = currentInfo;
			reference3 = ref reference;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-40]");
			obj12 = 0;
			numberFormatInfo3 = currentInfo;
			if (flag4)
			{
				goto IL_0921;
			}
		}
		reference3 = ref reference;
		obj12 = obj10;
		numberFormatInfo3 = numberFormatInfo2;
		obj11 = 0;
		goto IL_0921;
		IL_0921:
		object obj13 = obj3 + 40;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		NumberFormatInfo numberFormatInfo4 = default(NumberFormatInfo);
		if (numberFormatInfo4 != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj14 = default(object);
			if (obj14 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		_ = 0;
		string argument4 = GetArgument("--coherence-world-id");
		bool flag5 = argument4 == null;
		ref ulong reference4 = ref reference3;
		NumberFormatInfo numberFormatInfo5 = numberFormatInfo4;
		ref ulong reference5;
		NumberFormatInfo numberFormatInfo6;
		object obj16;
		object obj17;
		if (!flag5)
		{
			object obj15 = argument4 + 20;
			_ = 0;
			_ = argument4._stringLength;
			NumberFormatInfo currentInfo2 = NumberFormatInfo.CurrentInfo;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-40]");
			obj12 = 0;
			reference4 = ref *(ulong*)(obj3 + 40);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-40]");
			_ = 0;
			ReadOnlySpan<char> value2 = (ReadOnlySpan<char>)(obj3 - 64);
			bool flag6 = System.Number.TryParseUInt64(value2, NumberStyles.Integer, currentInfo2, out reference4);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+28]");
			obj16 = 0;
			numberFormatInfo5 = currentInfo2;
			reference5 = ref reference4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-40]");
			obj17 = 0;
			numberFormatInfo6 = currentInfo2;
			if (flag6)
			{
				goto IL_09d8;
			}
		}
		reference5 = ref reference4;
		obj17 = obj12;
		numberFormatInfo6 = numberFormatInfo5;
		obj16 = 0;
		goto IL_09d8;
		IL_075c:
		array = new object[9];
		Type simulatorType = SimulatorType;
		object obj18 = obj3 + 40;
		object obj19 = (Type)obj18;
		if (obj19 != null)
		{
			nint num4 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj20 = default(object);
			if (obj20 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		string region = Region;
		if (region != null)
		{
			nint num5 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj21 = default(object);
			if (obj21 == null)
			{
				ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
				throw ex5;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		string argument5 = GetArgument("--coherence-ip");
		if (argument5 != null)
		{
			nint num6 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj22 = default(object);
			if (obj22 == null)
			{
				ArrayTypeMismatchException ex6 = new ArrayTypeMismatchException();
				throw ex6;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		_ = 0;
		string argument6 = GetArgument("--coherence-port");
		bool flag7 = argument6 == null;
		NumberFormatInfo numberFormatInfo7 = (NumberFormatInfo)(object)argument5;
		ref int reference6 = default(ref int);
		NumberFormatInfo numberFormatInfo8;
		object obj24;
		if (!flag7)
		{
			object obj23 = argument6 + 20;
			_ = 0;
			_ = argument6._stringLength;
			NumberFormatInfo currentInfo3 = NumberFormatInfo.CurrentInfo;
			reference6 = ref *(int*)(obj3 + 40);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-40]");
			_ = 0;
			ReadOnlySpan<char> value3 = (ReadOnlySpan<char>)(obj3 - 64);
			bool flag8 = System.Number.TryParseInt32(value3, NumberStyles.Integer, currentInfo3, out reference6);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+28]");
			obj24 = 0;
			numberFormatInfo7 = currentInfo3;
			reference2 = ref reference6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-40]");
			obj10 = 0;
			numberFormatInfo8 = currentInfo3;
			if (flag8)
			{
				goto IL_0811;
			}
		}
		reference2 = ref reference6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-40]");
		obj10 = 0;
		numberFormatInfo8 = numberFormatInfo7;
		obj24 = 0;
		goto IL_0811;
		IL_09d8:
		object obj25 = obj3 + 40;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		NumberFormatInfo numberFormatInfo9 = default(NumberFormatInfo);
		if (numberFormatInfo9 != null)
		{
			nint num7 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj26 = default(object);
			if (obj26 == null)
			{
				ArrayTypeMismatchException ex7 = new ArrayTypeMismatchException();
				throw ex7;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		_ = 0;
		string argument7 = GetArgument("--coherence-http-server-port");
		bool flag9 = argument7 == null;
		object obj27 = 4294967295L;
		ref int reference7 = ref System.Runtime.CompilerServices.Unsafe.As<ulong, int>(ref reference5);
		NumberFormatInfo numberFormatInfo10 = numberFormatInfo9;
		if (!flag9)
		{
			object obj28 = argument7 + 20;
			_ = 0;
			_ = argument7._stringLength;
			NumberFormatInfo currentInfo4 = NumberFormatInfo.CurrentInfo;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-40]");
			obj17 = 0;
			reference7 = ref *(int*)(obj3 + 40);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-40]");
			_ = 0;
			ReadOnlySpan<char> value4 = (ReadOnlySpan<char>)(obj3 - 64);
			bool flag10 = System.Number.TryParseInt32(value4, NumberStyles.Integer, currentInfo4, out reference7);
			bool flag11 = !flag10;
			obj27 = 4294967295L;
			numberFormatInfo10 = currentInfo4;
			if (!flag11)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+28]");
				obj27 = 0;
				numberFormatInfo10 = currentInfo4;
			}
		}
		object obj29 = obj3 + 40;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj30 = default(object);
		if (obj30 != null)
		{
			nint num8 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj31 = default(object);
			if (obj31 == null)
			{
				ArrayTypeMismatchException ex8 = new ArrayTypeMismatchException();
				throw ex8;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if (obj != null)
		{
			nint num9 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj32 = default(object);
			if (obj32 == null)
			{
				ArrayTypeMismatchException ex9 = new ArrayTypeMismatchException();
				throw ex9;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		System.ParamsArray paramsArray = (System.ParamsArray)(obj3 - 64);
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray, new System.ParamsArray(array));
		System.ParamsArray args = (System.ParamsArray)(obj3 - 32);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-40]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-30]");
		_ = 0;
		return string.FormatHelper((IFormatProvider)null, "Type:{0} Region:{1} IP:{2} Port:{3} RoomId:{4} UniqueRoomId:{5} WorldId:{6} HttpsServerPort:{7} AuthToken:{8}", args);
	}

	internal unsafe static TransportType EnsureCorrectCloudSimulatorTransport(Coherence.Log.Logger logger, TransportType transportType)
	{
		//IL_000e: Expected I4, but got O
		//IL_0033: Expected O, but got Ref
		//IL_0098: Expected I4, but got O
		if (transportType != TransportType.UDPOnly)
		{
			object obj = default(object);
			object arg = (TransportType)(int)obj;
			System.ParamsArray paramsArray = new System.ParamsArray(arg);
			object obj2 = default(object);
			string text = string.FormatHelper((IFormatProvider)null, "Transport type was set to {0}, but cloud-hosted simulators support only UDP transport. ", (System.ParamsArray)(&obj2));
			string log = text + "Defaulting to UDP transport.";
			(string, object)[] args = Array.Empty<(string, object)>();
			if (logger == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (TransportType)(int)ex;
			}
			logger.Info(log, args);
		}
		return TransportType.UDPOnly;
	}

	public static void AddArgument(string arg, string val)
	{
		bool flag = ((Dictionary<object, object>)(object)ArgumentsDict).TryInsert((object)arg, (object)val, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
	}

	internal static void SetArgument(string keyword, string value)
	{
		bool flag = ((Dictionary<object, object>)(object)ArgumentsDict).TryInsert((object)keyword, (object)value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
	}

	internal static bool RemoveArgument(string keyword)
	{
		//IL_002a: Expected I4, but got O
		if (ArgumentsDict != null)
		{
			return ((Dictionary<object, object>)(object)ArgumentsDict).Remove((object)keyword);
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	internal static string GetArgument(string arg)
	{
		if (ArgumentsDict != null)
		{
			bool flag = ((Dictionary<object, object>)(object)ArgumentsDict).TryGetValue((object)arg, out object value);
			bool flag2 = !flag;
			object result = null;
			if (!flag2)
			{
				result = value;
			}
			return (string)result;
		}
		return (string)(object)new NullReferenceException();
	}
}
