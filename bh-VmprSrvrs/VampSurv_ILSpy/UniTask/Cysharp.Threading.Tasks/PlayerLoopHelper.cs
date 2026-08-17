using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using Cpp2ILInjected;
using Cysharp.Threading.Tasks.Internal;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.PlayerLoop;

namespace Cysharp.Threading.Tasks;

public static class PlayerLoopHelper
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<PlayerLoopSystem, bool> _003C_003E9__21_0;

		public static Predicate<PlayerLoopSystem> _003C_003E9__21_1;

		public static Predicate<PlayerLoopSystem> _003C_003E9__21_2;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CInsertUniTaskSynchronizationContext_003Eb__21_0(PlayerLoopSystem ls)
		{
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Expected O, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			object obj4 = default(object);
			object obj3 = (object)ls.type - obj4;
			bool flag = obj3 == null;
			return !flag;
		}

		internal unsafe bool _003CInsertUniTaskSynchronizationContext_003Eb__21_1(PlayerLoopSystem x)
		{
			//IL_013a: Expected I4, but got O
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Expected Ref, but got Unknown
			//IL_00f7: Expected I8, but got I4
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Expected Ref, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189992DE5]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if ((object)x.type != null)
			{
				string name = x.type.Name;
				object obj = "ScriptRunDelayedTasks";
				if ((object)name != "ScriptRunDelayedTasks")
				{
					if (name != null && "ScriptRunDelayedTasks" != null)
					{
						int stringLength = name._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rdx_v3+10]");
						if ((nint)stringLength == 0)
						{
							ref byte first = ref *(byte*)(name + 20);
							ulong length = (ulong)(name._stringLength + name._stringLength);
							return System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("ScriptRunDelayedTasks" + 20), length);
						}
					}
					return false;
				}
				return true;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal unsafe bool _003CInsertUniTaskSynchronizationContext_003Eb__21_2(PlayerLoopSystem x)
		{
			//IL_013a: Expected I4, but got O
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Expected Ref, but got Unknown
			//IL_00f7: Expected I8, but got I4
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Expected Ref, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189992DE6]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if ((object)x.type != null)
			{
				string name = x.type.Name;
				object obj = "UniTaskLoopRunnerUpdate";
				if ((object)name != "UniTaskLoopRunnerUpdate")
				{
					if (name != null && "UniTaskLoopRunnerUpdate" != null)
					{
						int stringLength = name._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rdx_v3+10]");
						if ((nint)stringLength == 0)
						{
							ref byte first = ref *(byte*)(name + 20);
							ulong length = (ulong)(name._stringLength + name._stringLength);
							return System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("UniTaskLoopRunnerUpdate" + 20), length);
						}
					}
					return false;
				}
				return true;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass20_0
	{
		public Type loopRunnerYieldType;

		public Type loopRunnerType;

		internal bool _003CRemoveRunner_003Eb__0(PlayerLoopSystem ls)
		{
			if ((object)ls.type == loopRunnerYieldType)
			{
				return false;
			}
			object obj = (object)ls.type - (object)loopRunnerType;
			bool flag = obj == null;
			return !flag;
		}
	}

	private static readonly ContinuationQueue ThrowMarkerContinuationQueue;

	private static readonly PlayerLoopRunner ThrowMarkerPlayerLoopRunner;

	private static int mainThreadId;

	private static string applicationDataPath;

	private static SynchronizationContext unitySynchronizationContext;

	private static ContinuationQueue[] yielders;

	private static PlayerLoopRunner[] runners;

	private static bool _003CIsEditorApplicationQuitting_003Ek__BackingField;

	public static SynchronizationContext UnitySynchronizationContext => unitySynchronizationContext;

	public static int MainThreadId => mainThreadId;

	internal static string ApplicationDataPath => applicationDataPath;

	public static bool IsMainThread
	{
		get
		{
			//IL_0080: Expected I4, but got O
			//IL_00e8: Expected O, but got I4
			Thread currentThread = Thread.CurrentThread;
			if (currentThread != null)
			{
				if (currentThread.internal_thread == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B455E8");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B1F7E0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC8810");
					System.Threading.InternalThread internal_thread = currentThread.internal_thread;
					internal_thread.state = ThreadState.Unstarted;
				}
				System.Threading.InternalThread internal_thread2 = currentThread.internal_thread;
				if (currentThread.internal_thread != null)
				{
					object obj = internal_thread2.managed_id - mainThreadId;
					return obj == null;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	internal static bool IsEditorApplicationQuitting
	{
		get
		{
			return _003CIsEditorApplicationQuitting_003Ek__BackingField;
		}
		private set
		{
			_003CIsEditorApplicationQuitting_003Ek__BackingField = value;
		}
	}

	private unsafe static PlayerLoopSystem[] InsertRunner(PlayerLoopSystem loopSystem, bool injectOnFirst, Type loopRunnerYieldType, ContinuationQueue cq, Type loopRunnerType, PlayerLoopRunner runner)
	{
		//IL_0084: Expected O, but got Ref
		//IL_009d: Expected O, but got I4
		//IL_00f4: Expected O, but got I4
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_01ea: Expected O, but got I4
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Expected O, but got Unknown
		PlayerLoopSystem.UpdateFunction updateFunction = cq.Run;
		object obj = default(object);
		PlayerLoopSystem.UpdateFunction updateFunction2 = ((PlayerLoopRunner)obj).Run;
		object obj2 = default(object);
		Type loopRunnerType2 = default(Type);
		PlayerLoopSystem[] array = RemoveRunner((PlayerLoopSystem)(&obj2), loopRunnerYieldType, loopRunnerType2);
		object obj3 = array.Length + 2;
		PlayerLoopSystem[] array2 = new PlayerLoopSystem[obj3];
		int destinationIndex = (injectOnFirst ? 1 : 0) + (injectOnFirst ? 1 : 0);
		int length = default(int);
		Array.Copy(array, 0, array2, destinationIndex, length);
		if (!injectOnFirst)
		{
			object obj4 = array2.Length - 2;
			if ((nint)obj4 < array2.Length)
			{
				object obj5 = obj4 * 4;
				object obj6 = obj4 + obj5;
				object obj7 = array2.Length - 1;
				if ((nint)obj7 < array2.Length)
				{
					object obj8 = obj7 * 4;
					object obj9 = obj7 + obj8;
					goto IL_01bd;
				}
			}
		}
		else if (array2.Length > 0 && array2.Length > 1)
		{
			goto IL_01bd;
		}
		return (PlayerLoopSystem[])(object)new IndexOutOfRangeException();
		IL_01bd:
		return array2;
	}

	private static PlayerLoopSystem[] RemoveRunner(PlayerLoopSystem loopSystem, Type loopRunnerYieldType, Type loopRunnerType)
	{
		_003C_003Ec__DisplayClass20_0 obj = new _003C_003Ec__DisplayClass20_0();
		obj.loopRunnerYieldType = loopRunnerYieldType;
		obj.loopRunnerType = loopRunnerType;
		Func<PlayerLoopSystem, bool> func = null;
		bool flag = ((_003C_003Ec__DisplayClass20_0)(object)func)._003CRemoveRunner_003Eb__0((PlayerLoopSystem)obj);
		IEnumerable<PlayerLoopSystem> enumerable = Enumerable.Where(loopSystem.subSystemList, func);
		if (enumerable != null)
		{
			System.Linq.Buffer<PlayerLoopSystem> buffer = new System.Linq.Buffer<PlayerLoopSystem>(enumerable);
			System.Linq.Buffer<PlayerLoopSystem> buffer2 = default(System.Linq.Buffer<PlayerLoopSystem>);
			return buffer2.ToArray();
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	private unsafe static PlayerLoopSystem[] InsertUniTaskSynchronizationContext(PlayerLoopSystem loopSystem)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Expected I4, but got Unknown
		//IL_0176: Expected O, but got Ref
		//IL_0187: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		PlayerLoopSystem.UpdateFunction updateFunction = UniTaskSynchronizationContext.Run;
		Func<PlayerLoopSystem, bool> predicate = _003C_003Ec._003C_003E9__21_0;
		if (_003C_003Ec._003C_003E9__21_0 == null)
		{
			Func<PlayerLoopSystem, bool> func = null;
			bool flag = ((_003C_003Ec)(object)func)._003CInsertUniTaskSynchronizationContext_003Eb__21_0((PlayerLoopSystem)_003C_003Ec._003C_003E9);
			_003C_003Ec._003C_003E9__21_0 = func;
			predicate = func;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
		IEnumerable<PlayerLoopSystem> enumerable = Enumerable.Where((IEnumerable<PlayerLoopSystem>)loopSystem.type, predicate);
		if (enumerable != null)
		{
			System.Linq.Buffer<PlayerLoopSystem> buffer = new System.Linq.Buffer<PlayerLoopSystem>(enumerable);
			System.Linq.Buffer<PlayerLoopSystem> buffer2 = default(System.Linq.Buffer<PlayerLoopSystem>);
			PlayerLoopSystem[] collection = buffer2.ToArray();
			List<PlayerLoopSystem> list = new List<PlayerLoopSystem>(collection);
			Predicate<PlayerLoopSystem> predicate2 = _003C_003Ec._003C_003E9__21_1;
			if (_003C_003Ec._003C_003E9__21_1 == null)
			{
				Predicate<PlayerLoopSystem> predicate3 = null;
				bool flag2 = ((_003C_003Ec)(object)predicate3)._003CInsertUniTaskSynchronizationContext_003Eb__21_1((PlayerLoopSystem)_003C_003Ec._003C_003E9);
				_003C_003Ec._003C_003E9__21_1 = predicate3;
				predicate2 = predicate3;
			}
			if (list != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805C1690");
				object obj3 = default(object);
				if ((nint)obj3 == -1)
				{
					Predicate<PlayerLoopSystem> predicate4 = _003C_003Ec._003C_003E9__21_2;
					if (_003C_003Ec._003C_003E9__21_2 == null)
					{
						Predicate<PlayerLoopSystem> predicate5 = null;
						bool flag3 = ((_003C_003Ec)(object)predicate5)._003CInsertUniTaskSynchronizationContext_003Eb__21_2((PlayerLoopSystem)_003C_003Ec._003C_003E9);
						_003C_003Ec._003C_003E9__21_2 = predicate5;
						predicate4 = predicate5;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805C1690");
				}
				int index = obj3 + 1;
				object obj4 = default(object);
				list.Insert(index, (PlayerLoopSystem)(&obj4));
				list.Insert(index, (PlayerLoopSystem)(&obj4));
				PlayerLoopSystem[] result = default(PlayerLoopSystem[]);
				return result;
			}
			return (PlayerLoopSystem[])(object)new NullReferenceException();
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	private static void Init()
	{
		//IL_0107: Expected I, but got O
		//IL_011d: Expected O, but got I
		SynchronizationContext current = SynchronizationContext.Current;
		unitySynchronizationContext = current;
		nint num = (nint)typeof(PlayerLoopHelper);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rax_v4 (Il2CppClass<Cysharp.Threading.Tasks.PlayerLoopHelper>)+B8]");
		object obj = (nint)0 + (nint)32;
		Thread currentThread = Thread.CurrentThread;
		if (currentThread.internal_thread == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B455E8");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B1F7E0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC8810");
			System.Threading.InternalThread internal_thread = currentThread.internal_thread;
			internal_thread.state = ThreadState.Unstarted;
		}
		System.Threading.InternalThread internal_thread2 = currentThread.internal_thread;
		mainThreadId = internal_thread2.managed_id;
		string dataPath = Application.dataPath;
		applicationDataPath = dataPath;
		if (runners == null)
		{
			UnityEngine.LowLevel.PlayerLoopSystemInternal[] currentPlayerLoopInternal = PlayerLoop.GetCurrentPlayerLoopInternal();
			int offset = default(int);
			PlayerLoopSystem playerLoopSystem = PlayerLoop.InternalToPlayerLoopSystem(currentPlayerLoopInternal, ref offset);
			PlayerLoopSystem playerLoop = default(PlayerLoopSystem);
			Initialize(ref playerLoop);
		}
	}

	private static int FindLoopSystemIndex(PlayerLoopSystem[] playerLoopList, Type systemType)
	{
		//IL_0025: Expected O, but got I4
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		int num = 0;
		int num2 = 0;
		while (num < playerLoopList.Length)
		{
			object obj = num2 * 4;
			object obj2 = num2 + obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [playerLoopList @ rcx (UnityEngine.LowLevel.PlayerLoopSystem[])+20+v122 @ rcx_v13*8]");
			if (0 != (nint)systemType)
			{
				num2++;
				num = num2;
				continue;
			}
			return num2;
		}
		throw new NullReferenceException();
	}

	private unsafe static void InsertLoop(PlayerLoopSystem[] copyList, InjectPlayerLoopTimings injectTimings, Type loopType, InjectPlayerLoopTimings targetTimings, int index, bool injectOnFirst, Type loopRunnerYieldType, Type loopRunnerType, PlayerLoopTiming playerLoopTiming)
	{
		//IL_0023: Expected O, but got I4
		//IL_013e: Expected O, but got Ref
		//IL_0052: Expected O, but got I4
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_00e7: Expected O, but got Ref
		//IL_00fe: Expected O, but got I4
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		int num = FindLoopSystemIndex(copyList, loopType);
		object obj = injectTimings & targetTimings;
		object obj2 = default(object);
		Type loopRunnerYieldType2 = default(Type);
		if ((nint)obj != (nint)targetTimings)
		{
			Type loopRunnerType2 = default(Type);
			PlayerLoopSystem[] array = RemoveRunner((PlayerLoopSystem)(&obj2), loopRunnerYieldType2, loopRunnerType2);
			object obj3 = num + 1;
			object obj4 = obj3 * 4;
			object obj5 = obj3 + obj4;
			return;
		}
		ContinuationQueue[] array2 = yielders;
		IntPtr intPtr = default(IntPtr);
		PlayerLoopTiming timing = default(PlayerLoopTiming);
		ContinuationQueue cq = (array2[(nint)intPtr] = new ContinuationQueue(timing));
		PlayerLoopRunner[] array3 = runners;
		PlayerLoopRunner playerLoopRunner = new PlayerLoopRunner(timing);
		array3[(nint)intPtr] = playerLoopRunner;
		bool injectOnFirst2 = default(bool);
		Type loopRunnerType3 = default(Type);
		PlayerLoopRunner runner = default(PlayerLoopRunner);
		PlayerLoopSystem[] array4 = InsertRunner((PlayerLoopSystem)(&obj2), injectOnFirst2, loopRunnerYieldType2, cq, loopRunnerType3, runner);
		object obj6 = num + 1;
		object obj7 = obj6 * 4;
		object obj8 = obj6 + obj7;
	}

	public unsafe static void Initialize(ref PlayerLoopSystem playerLoop, InjectPlayerLoopTimings injectTimings = InjectPlayerLoopTimings.All)
	{
		//IL_0060: Expected O, but got I
		//IL_0090: Expected O, but got I4
		//IL_008b: Expected native int or pointer, but got O
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00dd: Expected O, but got I4
		//IL_00d8: Expected native int or pointer, but got O
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		//IL_0118: Expected O, but got I4
		//IL_0113: Expected native int or pointer, but got O
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Expected O, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Expected O, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Expected O, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_0c64: Expected O, but got I4
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Expected O, but got Unknown
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Expected O, but got Unknown
		//IL_0c9e: Expected O, but got I4
		//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Expected O, but got Unknown
		//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Expected O, but got Unknown
		//IL_031c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Expected O, but got Unknown
		//IL_0cd8: Expected O, but got I4
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0352: Expected O, but got Unknown
		//IL_0394: Unknown result type (might be due to invalid IL or missing references)
		//IL_0399: Expected O, but got Unknown
		//IL_03c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ca: Expected O, but got Unknown
		//IL_0d12: Expected O, but got I4
		//IL_03f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fb: Expected O, but got Unknown
		//IL_043d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0442: Expected O, but got Unknown
		//IL_046e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0473: Expected O, but got Unknown
		//IL_0d4c: Expected O, but got I4
		//IL_049f: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a4: Expected O, but got Unknown
		//IL_04e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04eb: Expected O, but got Unknown
		//IL_0517: Unknown result type (might be due to invalid IL or missing references)
		//IL_051c: Expected O, but got Unknown
		//IL_0d86: Expected O, but got I4
		//IL_0548: Unknown result type (might be due to invalid IL or missing references)
		//IL_054d: Expected O, but got Unknown
		//IL_058f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0594: Expected O, but got Unknown
		//IL_05c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c5: Expected O, but got Unknown
		//IL_0dc0: Expected O, but got I4
		//IL_05f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f6: Expected O, but got Unknown
		//IL_0638: Unknown result type (might be due to invalid IL or missing references)
		//IL_063d: Expected O, but got Unknown
		//IL_0669: Unknown result type (might be due to invalid IL or missing references)
		//IL_066e: Expected O, but got Unknown
		//IL_0dfa: Expected O, but got I4
		//IL_069a: Unknown result type (might be due to invalid IL or missing references)
		//IL_069f: Expected O, but got Unknown
		//IL_06e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e6: Expected O, but got Unknown
		//IL_0712: Unknown result type (might be due to invalid IL or missing references)
		//IL_0717: Expected O, but got Unknown
		//IL_0e34: Expected O, but got I4
		//IL_0743: Unknown result type (might be due to invalid IL or missing references)
		//IL_0748: Expected O, but got Unknown
		//IL_078a: Unknown result type (might be due to invalid IL or missing references)
		//IL_078f: Expected O, but got Unknown
		//IL_07bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c0: Expected O, but got Unknown
		//IL_0e6e: Expected O, but got I4
		//IL_07ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f1: Expected O, but got Unknown
		//IL_0833: Unknown result type (might be due to invalid IL or missing references)
		//IL_0838: Expected O, but got Unknown
		//IL_0864: Unknown result type (might be due to invalid IL or missing references)
		//IL_0869: Expected O, but got Unknown
		//IL_0ea8: Expected O, but got I4
		//IL_0895: Unknown result type (might be due to invalid IL or missing references)
		//IL_089a: Expected O, but got Unknown
		//IL_08dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e1: Expected O, but got Unknown
		//IL_090d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0912: Expected O, but got Unknown
		//IL_0ee2: Expected O, but got I4
		//IL_093e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0943: Expected O, but got Unknown
		//IL_0985: Unknown result type (might be due to invalid IL or missing references)
		//IL_098a: Expected O, but got Unknown
		//IL_09b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_09bb: Expected O, but got Unknown
		//IL_0f1c: Expected O, but got I4
		//IL_09e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ec: Expected O, but got Unknown
		//IL_0a2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a33: Expected O, but got Unknown
		//IL_0a5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a64: Expected O, but got Unknown
		//IL_0f56: Expected O, but got I4
		//IL_0a90: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a95: Expected O, but got Unknown
		//IL_0ad7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0adc: Expected O, but got Unknown
		//IL_0b08: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b0d: Expected O, but got Unknown
		//IL_0f90: Expected O, but got I4
		//IL_0b39: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3e: Expected O, but got Unknown
		//IL_0fab: Expected O, but got I4
		//IL_0b66: Expected O, but got Ref
		//IL_0b7d: Expected O, but got I4
		//IL_0b86: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b8b: Expected O, but got Unknown
		//IL_0bb0: Expected O, but got Ref
		ContinuationQueue[] array = new ContinuationQueue[16];
		yielders = array;
		PlayerLoopRunner[] array2 = new PlayerLoopRunner[16];
		runners = array2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [playerLoop @ rcx (UnityEngine.LowLevel.PlayerLoopSystem&)+8]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [playerLoop @ rcx (UnityEngine.LowLevel.PlayerLoopSystem&)+8]");
			System.Linq.Buffer<PlayerLoopSystem> buffer = new System.Linq.Buffer<PlayerLoopSystem>((IEnumerable<PlayerLoopSystem>)0);
			System.Linq.Buffer<PlayerLoopSystem> buffer2 = default(System.Linq.Buffer<PlayerLoopSystem>);
			PlayerLoopSystem[] array3 = buffer2.ToArray();
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)typeof(Initialization), new System.Linq.Buffer<PlayerLoopSystem>((IEnumerable<PlayerLoopSystem>)1));
			System.Linq.Buffer<PlayerLoopSystem> buffer3 = default(System.Linq.Buffer<PlayerLoopSystem>);
			object obj = buffer3 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type type = default(Type);
			Type loopType = type;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)typeof(UniTaskLoopRunners.UniTaskLoopRunnerYieldInitialization), new System.Linq.Buffer<PlayerLoopSystem>((IEnumerable<PlayerLoopSystem>)1));
			System.Linq.Buffer<PlayerLoopSystem> buffer4 = default(System.Linq.Buffer<PlayerLoopSystem>);
			object obj2 = buffer4 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)typeof(UniTaskLoopRunners.UniTaskLoopRunnerInitialization), new System.Linq.Buffer<PlayerLoopSystem>((IEnumerable<PlayerLoopSystem>)1));
			System.Linq.Buffer<PlayerLoopSystem> buffer5 = default(System.Linq.Buffer<PlayerLoopSystem>);
			object obj3 = buffer5 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			int index = default(int);
			bool injectOnFirst = default(bool);
			Type loopRunnerYieldType = default(Type);
			Type loopRunnerType = default(Type);
			InsertLoop(array3, injectTimings, loopType, InjectPlayerLoopTimings.Initialization, index, injectOnFirst, loopRunnerYieldType, loopRunnerType, PlayerLoopTiming.Initialization);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj5 = default(object);
			object obj4 = obj5 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			PlayerLoopTiming playerLoopTiming2 = default(PlayerLoopTiming);
			PlayerLoopTiming playerLoopTiming = playerLoopTiming2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj7 = default(object);
			object obj6 = obj7 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj9 = default(object);
			object obj8 = obj9 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			InsertLoop(array3, injectTimings, (Type)playerLoopTiming, InjectPlayerLoopTimings.LastInitialization, index, injectOnFirst, loopRunnerYieldType, loopRunnerType, PlayerLoopTiming.LastInitialization);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj11 = default(object);
			object obj10 = obj11 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			PlayerLoopTiming playerLoopTiming4 = default(PlayerLoopTiming);
			PlayerLoopTiming playerLoopTiming3 = playerLoopTiming4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj13 = default(object);
			object obj12 = obj13 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj15 = default(object);
			object obj14 = obj15 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			InsertLoop(array3, injectTimings, (Type)playerLoopTiming3, InjectPlayerLoopTimings.EarlyUpdate, index, injectOnFirst, loopRunnerYieldType, loopRunnerType, PlayerLoopTiming.EarlyUpdate);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj17 = default(object);
			object obj16 = obj17 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			PlayerLoopTiming playerLoopTiming6 = default(PlayerLoopTiming);
			PlayerLoopTiming playerLoopTiming5 = playerLoopTiming6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj19 = default(object);
			object obj18 = obj19 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj21 = default(object);
			object obj20 = obj21 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			InsertLoop(array3, injectTimings, (Type)playerLoopTiming5, InjectPlayerLoopTimings.LastEarlyUpdate, index, injectOnFirst, loopRunnerYieldType, loopRunnerType, PlayerLoopTiming.LastEarlyUpdate);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj23 = default(object);
			object obj22 = obj23 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			PlayerLoopTiming playerLoopTiming8 = default(PlayerLoopTiming);
			PlayerLoopTiming playerLoopTiming7 = playerLoopTiming8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj25 = default(object);
			object obj24 = obj25 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj27 = default(object);
			object obj26 = obj27 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			InsertLoop(array3, injectTimings, (Type)playerLoopTiming7, InjectPlayerLoopTimings.FixedUpdate, index, injectOnFirst, loopRunnerYieldType, loopRunnerType, PlayerLoopTiming.FixedUpdate);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj29 = default(object);
			object obj28 = obj29 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			PlayerLoopTiming playerLoopTiming10 = default(PlayerLoopTiming);
			PlayerLoopTiming playerLoopTiming9 = playerLoopTiming10;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj31 = default(object);
			object obj30 = obj31 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj33 = default(object);
			object obj32 = obj33 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			InsertLoop(array3, injectTimings, (Type)playerLoopTiming9, InjectPlayerLoopTimings.LastFixedUpdate, index, injectOnFirst, loopRunnerYieldType, loopRunnerType, PlayerLoopTiming.LastFixedUpdate);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj35 = default(object);
			object obj34 = obj35 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			PlayerLoopTiming playerLoopTiming12 = default(PlayerLoopTiming);
			PlayerLoopTiming playerLoopTiming11 = playerLoopTiming12;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj37 = default(object);
			object obj36 = obj37 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj39 = default(object);
			object obj38 = obj39 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			InsertLoop(array3, injectTimings, (Type)playerLoopTiming11, InjectPlayerLoopTimings.PreUpdate, index, injectOnFirst, loopRunnerYieldType, loopRunnerType, PlayerLoopTiming.PreUpdate);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj41 = default(object);
			object obj40 = obj41 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			PlayerLoopTiming playerLoopTiming14 = default(PlayerLoopTiming);
			PlayerLoopTiming playerLoopTiming13 = playerLoopTiming14;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj43 = default(object);
			object obj42 = obj43 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj45 = default(object);
			object obj44 = obj45 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			InsertLoop(array3, injectTimings, (Type)playerLoopTiming13, InjectPlayerLoopTimings.LastPreUpdate, index, injectOnFirst, loopRunnerYieldType, loopRunnerType, PlayerLoopTiming.LastPreUpdate);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj47 = default(object);
			object obj46 = obj47 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			PlayerLoopTiming playerLoopTiming16 = default(PlayerLoopTiming);
			PlayerLoopTiming playerLoopTiming15 = playerLoopTiming16;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj49 = default(object);
			object obj48 = obj49 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj51 = default(object);
			object obj50 = obj51 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			InsertLoop(array3, injectTimings, (Type)playerLoopTiming15, InjectPlayerLoopTimings.Update, index, injectOnFirst, loopRunnerYieldType, loopRunnerType, PlayerLoopTiming.Update);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj53 = default(object);
			object obj52 = obj53 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			PlayerLoopTiming playerLoopTiming18 = default(PlayerLoopTiming);
			PlayerLoopTiming playerLoopTiming17 = playerLoopTiming18;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj55 = default(object);
			object obj54 = obj55 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj57 = default(object);
			object obj56 = obj57 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			InsertLoop(array3, injectTimings, (Type)playerLoopTiming17, InjectPlayerLoopTimings.LastUpdate, index, injectOnFirst, loopRunnerYieldType, loopRunnerType, PlayerLoopTiming.LastUpdate);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj59 = default(object);
			object obj58 = obj59 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			PlayerLoopTiming playerLoopTiming20 = default(PlayerLoopTiming);
			PlayerLoopTiming playerLoopTiming19 = playerLoopTiming20;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj61 = default(object);
			object obj60 = obj61 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj63 = default(object);
			object obj62 = obj63 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			InsertLoop(array3, injectTimings, (Type)playerLoopTiming19, InjectPlayerLoopTimings.PreLateUpdate, index, injectOnFirst, loopRunnerYieldType, loopRunnerType, PlayerLoopTiming.PreLateUpdate);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj65 = default(object);
			object obj64 = obj65 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			PlayerLoopTiming playerLoopTiming22 = default(PlayerLoopTiming);
			PlayerLoopTiming playerLoopTiming21 = playerLoopTiming22;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj67 = default(object);
			object obj66 = obj67 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj69 = default(object);
			object obj68 = obj69 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			InsertLoop(array3, injectTimings, (Type)playerLoopTiming21, InjectPlayerLoopTimings.LastPreLateUpdate, index, injectOnFirst, loopRunnerYieldType, loopRunnerType, PlayerLoopTiming.LastPreLateUpdate);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj71 = default(object);
			object obj70 = obj71 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			PlayerLoopTiming playerLoopTiming24 = default(PlayerLoopTiming);
			PlayerLoopTiming playerLoopTiming23 = playerLoopTiming24;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj73 = default(object);
			object obj72 = obj73 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj75 = default(object);
			object obj74 = obj75 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			InsertLoop(array3, injectTimings, (Type)playerLoopTiming23, InjectPlayerLoopTimings.PostLateUpdate, index, injectOnFirst, loopRunnerYieldType, loopRunnerType, PlayerLoopTiming.PostLateUpdate);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj77 = default(object);
			object obj76 = obj77 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			PlayerLoopTiming playerLoopTiming26 = default(PlayerLoopTiming);
			PlayerLoopTiming playerLoopTiming25 = playerLoopTiming26;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj79 = default(object);
			object obj78 = obj79 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj81 = default(object);
			object obj80 = obj81 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			InsertLoop(array3, injectTimings, (Type)playerLoopTiming25, InjectPlayerLoopTimings.LastPostLateUpdate, index, injectOnFirst, loopRunnerYieldType, loopRunnerType, PlayerLoopTiming.LastPostLateUpdate);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj83 = default(object);
			object obj82 = obj83 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			PlayerLoopTiming playerLoopTiming28 = default(PlayerLoopTiming);
			PlayerLoopTiming playerLoopTiming27 = playerLoopTiming28;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj85 = default(object);
			object obj84 = obj85 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj87 = default(object);
			object obj86 = obj87 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			InsertLoop(array3, injectTimings, (Type)playerLoopTiming27, InjectPlayerLoopTimings.TimeUpdate, index, injectOnFirst, loopRunnerYieldType, loopRunnerType, PlayerLoopTiming.TimeUpdate);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj89 = default(object);
			object obj88 = obj89 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			PlayerLoopTiming playerLoopTiming30 = default(PlayerLoopTiming);
			PlayerLoopTiming playerLoopTiming29 = playerLoopTiming30;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj91 = default(object);
			object obj90 = obj91 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj93 = default(object);
			object obj92 = obj93 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			InsertLoop(array3, injectTimings, (Type)playerLoopTiming29, InjectPlayerLoopTimings.LastTimeUpdate, index, injectOnFirst, loopRunnerYieldType, loopRunnerType, PlayerLoopTiming.LastTimeUpdate);
			PlayerLoopTiming playerLoopTiming31 = PlayerLoopTiming.Initialization;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj95 = default(object);
			object obj94 = obj95 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			PlayerLoopTiming playerLoopTiming32 = default(PlayerLoopTiming);
			playerLoopTiming31 = playerLoopTiming32;
			int num = FindLoopSystemIndex(array3, (Type)playerLoopTiming31);
			PlayerLoopSystem playerLoopSystem = default(PlayerLoopSystem);
			PlayerLoopSystem[] array4 = InsertUniTaskSynchronizationContext((PlayerLoopSystem)(&playerLoopSystem));
			object obj96 = num + 1;
			object obj97 = obj96 * 4;
			object obj98 = obj96 + obj97;
			PlayerLoop.SetPlayerLoop((PlayerLoopSystem)(&playerLoopSystem));
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	public static void AddAction(PlayerLoopTiming timing, IPlayerLoopItem action)
	{
		PlayerLoopRunner[] array = runners;
		if (array[(int)timing] != null)
		{
			array[(int)timing].AddAction(action);
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002BB0");
		ThrowInvalidLoopTiming(timing);
	}

	private unsafe static void ThrowInvalidLoopTiming(PlayerLoopTiming playerLoopTiming)
	{
		//IL_0018: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180006D90");
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		string text2 = "Target playerLoopTiming is not injected. Please check PlayerLoopHelper.Initialize. PlayerLoopTiming:" + text;
		object obj2 = new InvalidOperationException();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E209C0");
		throw obj2;
	}

	public static void AddContinuation(PlayerLoopTiming timing, Action continuation)
	{
		ContinuationQueue[] array = yielders;
		if (array[(int)timing] != null)
		{
			array[(int)timing].Enqueue(continuation);
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002BB0");
		ThrowInvalidLoopTiming(timing);
	}

	public unsafe static void DumpCurrentPlayerLoop()
	{
		//IL_0052: Expected O, but got I4
		//IL_0064: Expected O, but got I4
		//IL_0080: Expected O, but got I4
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_00ad: Expected O, but got I
		//IL_00e4: Expected O, but got Ref
		//IL_02da: Expected O, but got I4
		//IL_02e3: Expected O, but got I4
		//IL_0143: Expected O, but got Ref
		//IL_0155: Expected O, but got I4
		//IL_02ff: Expected O, but got I4
		//IL_0308: Expected O, but got I4
		//IL_0168: Expected O, but got I4
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_0185: Expected O, but got I
		//IL_0195: Expected O, but got I
		//IL_020b: Expected O, but got I4
		//IL_0280: Expected O, but got I4
		//IL_0264: Expected O, but got I4
		UnityEngine.LowLevel.PlayerLoopSystemInternal[] currentPlayerLoopInternal = PlayerLoop.GetCurrentPlayerLoopInternal();
		int offset = default(int);
		Type type = PlayerLoop.InternalToPlayerLoopSystem(currentPlayerLoopInternal, ref offset).type;
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = stringBuilder.Append("PlayerLoop List");
		string newLine = Environment.NewLine;
		StringBuilder stringBuilder3 = stringBuilder.Append(newLine);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
		offset = 0;
		System.ParamsArray paramsArray = (System.ParamsArray)0;
		int num = 0;
		object obj = 0;
		int num2 = 0;
		object arg = default(object);
		System.ParamsArray paramsArray3 = default(System.ParamsArray);
		object arg2 = default(object);
		object arg3 = default(object);
		while (true)
		{
			int num3 = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ xmm0_v1 (System.Type)+18]");
			if ((nint)num3 >= (nint)0)
			{
				break;
			}
			object obj2 = num * 4;
			object obj3 = num + obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ xmm0_v1 (System.Type)+20+v511 @ rcx_v14*8]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ xmm0_v1 (System.Type)+20+v511 @ rcx_v14*8]");
			object obj4 = 0;
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v517 @ rdx_v10+1B8] (should have been resolved before IL gen)");
			System.ParamsArray paramsArray2 = new System.ParamsArray(arg);
			StringBuilder stringBuilder4 = stringBuilder.AppendFormatHelper((IFormatProvider)null, "------{0}------", (System.ParamsArray)(&paramsArray3));
			string newLine2 = Environment.NewLine;
			StringBuilder stringBuilder5 = stringBuilder.Append(newLine2);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ xmm0_v1 (System.Type)+20+v511 @ rcx_v14*8]");
			if ((nint)0 != 0)
			{
				paramsArray = (System.ParamsArray)(&paramsArray3);
				int num5 = 0;
				obj = 0;
				while (true)
				{
					int num6 = num5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v512 @ xmm0_v6 (System.IntPtr)+18]");
					if ((nint)num6 >= (nint)0)
					{
						break;
					}
					object obj6 = num5 * 4;
					object obj7 = num5 + obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v512 @ xmm0_v6 (System.IntPtr)+20+v593 @ rcx_v26*8]");
					Type type2 = (Type)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v512 @ xmm0_v6 (System.IntPtr)+20+v593 @ rcx_v26*8]");
					object obj8 = 0;
					object obj9 = obj8;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v597 @ rdx_v21+1B8] (should have been resolved before IL gen)");
					StringBuilder stringBuilder6 = stringBuilder.AppendFormat("{0}", arg2);
					string newLine3 = Environment.NewLine;
					StringBuilder stringBuilder7 = stringBuilder.Append(newLine3);
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v512 @ xmm0_v6 (System.IntPtr)+20+v593 @ rcx_v26*8]");
					bool flag = (nint)0 == 0;
					obj = 0;
					if (!flag)
					{
						string text = offset.ToString();
						string message = "More Subsystem:" + text;
						Debug.LogWarning(message);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v594 @ xmm0_v13 (System.Type)+18]");
						offset = 0;
						obj = 0;
					}
					num5++;
					paramsArray = (System.ParamsArray)0;
				}
			}
			else
			{
				void* value = ((IntPtr*)num4)->m_value;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v577 @ rdx_v16 (System.Void*)+1B8] (should have been resolved before IL gen)");
				StringBuilder stringBuilder8 = stringBuilder.AppendFormat("{0} has no subsystems!", arg3);
				string newLine4 = Environment.NewLine;
				StringBuilder stringBuilder9 = stringBuilder.Append(newLine4);
				paramsArray = (System.ParamsArray)0;
				obj = 0;
			}
			num++;
			paramsArray3 = (System.ParamsArray)0;
			paramsArray2 = (System.ParamsArray)0;
			num2 = num;
		}
		string message2 = stringBuilder.ToString();
		Debug.Log(message2);
	}

	public static bool IsInjectedUniTaskPlayerLoop()
	{
		//IL_01d0: Expected O, but got I4
		//IL_01d9: Expected O, but got I4
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Expected O, but got Unknown
		//IL_0071: Expected O, but got I4
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		//IL_0149->IL016a: Incompatible stack heights: 1 vs 0
		//IL_0157->IL0191: Incompatible stack heights: 2 vs 0
		//IL_012e->IL0077: Incompatible stack heights: 2 vs 1
		UnityEngine.LowLevel.PlayerLoopSystemInternal[] currentPlayerLoopInternal = PlayerLoop.GetCurrentPlayerLoopInternal();
		int offset = default(int);
		Type type = PlayerLoop.InternalToPlayerLoopSystem(currentPlayerLoopInternal, ref offset).type;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			object obj3 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ xmm2_v1 (System.Type)+18]");
			if ((nint)obj3 >= 0)
			{
				break;
			}
			object obj4 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ xmm2_v1 (System.Type)+18]");
			bool flag = (nint)obj4 >= 0;
			object obj5 = obj * 4;
			object obj6 = obj + obj5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ xmm2_v1 (System.Type)+28+v248 @ rcx_v6*8]");
			if ((nint)0 != 0)
			{
				object obj7 = 0;
				while (true)
				{
					object obj8 = obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ stack_-60+18]");
					if ((nint)obj8 >= 0)
					{
						break;
					}
					object obj9 = obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ stack_-60+18]");
					bool flag2 = (nint)obj9 >= 0;
					object obj10 = obj7 * 4;
					object obj11 = obj7 + obj10;
					Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(UniTaskLoopRunners.UniTaskLoopRunnerInitialization));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ stack_-60+20+v394 @ rcx_v9*8]");
					if (0 != (nint)typeFromHandle)
					{
						obj7++;
						continue;
					}
					return true;
				}
			}
			obj++;
			obj2 = obj;
		}
		return false;
	}

	static PlayerLoopHelper()
	{
		ContinuationQueue throwMarkerContinuationQueue = new ContinuationQueue(PlayerLoopTiming.Initialization);
		ThrowMarkerContinuationQueue = throwMarkerContinuationQueue;
		PlayerLoopRunner throwMarkerPlayerLoopRunner = new PlayerLoopRunner(PlayerLoopTiming.Initialization);
		ThrowMarkerPlayerLoopRunner = throwMarkerPlayerLoopRunner;
	}
}
