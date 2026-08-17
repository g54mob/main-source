using System;
using System.Collections;
using System.Collections.Generic;
using Actors.Enemies;
using Assets.Scripts.Saves___Serialization.Progression;
using Assets.Scripts.Saves___Serialization.Progression.Stats;
using Cpp2ILInjected;

namespace Assets.Scripts.Saves___Serialization.SaveFiles;

[Serializable]
public class StatsSaveFile
{
	public Dictionary<string, MyStat> stats;

	public Dictionary<EEnemy, EnemyLog> enemyLogs;

	public Dictionary<ESpeedrunTime, float> times;

	public unsafe void Init()
	{
		//IL_0044: Expected O, but got Ref
		//IL_06fa: Expected I, but got O
		//IL_0061: Expected I4, but got O
		//IL_02ed: Expected O, but got Ref
		//IL_0300: Expected I4, but got O
		//IL_030c: Expected O, but got I4
		//IL_0095: Expected I, but got O
		//IL_00b0: Expected I, but got O
		//IL_013d: Expected I4, but got O
		//IL_0378: Expected O, but got Ref
		//IL_0380: Expected O, but got Ref
		//IL_00f1: Expected F4, but got I4
		//IL_018f: Expected I, but got O
		//IL_0197: Expected I, but got O
		//IL_01c6: Expected I, but got O
		//IL_0395: Expected I, but got O
		//IL_0116: Invalid comparison between F4 and I
		//IL_0422: Expected O, but got I4
		//IL_01ef: Expected O, but got Ref
		//IL_03cd: Expected O, but got I
		//IL_03d6: Expected F4, but got I4
		//IL_0217: Expected I, but got O
		//IL_021f: Expected O, but got Ref
		//IL_024e: Expected I, but got O
		//IL_03fb: Invalid comparison between F4 and I
		//IL_026f: Expected O, but got Ref
		//IL_027c: Expected O, but got Ref
		//IL_028d: Expected F4, but got I
		//IL_04b7: Expected I, but got O
		//IL_04bf: Expected I, but got O
		//IL_04ee: Expected I, but got O
		//IL_052d: Expected I, but got O
		//IL_0554: Expected I4, but got O
		//IL_05b3: Expected I4, but got O
		Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(EMyStat));
		Array values = Enum.GetValues(typeFromHandle);
		IEnumerator enumerator = values.GetEnumerator();
		float num = default(float);
		object obj = (object)(&num);
		Array array = values;
		IEnumerator enumerator2 = default(IEnumerator);
		IntPtr intPtr = default(IntPtr);
		IntPtr intPtr2 = default(IntPtr);
		IntPtr intPtr3 = default(IntPtr);
		while (true)
		{
			bool flag = enumerator2 == null;
			nint num2 = (nint)enumerator2;
			if (!flag)
			{
				if (((Dictionary<ESpeedrunTime, float>)null).ContainsKey((ESpeedrunTime)typeof(IEnumerator)))
				{
					bool flag2 = enumerator2 == null;
					num2 = (nint)enumerator2;
					array = null;
					if (!flag2)
					{
						nint num3 = (nint)enumerator2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ r10_v14 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
						if ((nint)0 >= (nint)0)
						{
							goto IL_012a;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ r10_v14 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
						num2 = 0;
						float num4 = 0f;
						while (true)
						{
							float num5 = num4 + num4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v644 @ r8_v8 (Il2CppMethodInfo)+v598 @ rax_v94 (System.Single)*8]");
							if (0 != (nint)typeof(IEnumerator))
							{
								num4++;
								float num6 = num4;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ r10_v14 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
								if (num6 < 0f)
								{
									continue;
								}
								goto IL_012a;
							}
							break;
						}
						goto IL_014f;
					}
					throw new NullReferenceException();
				}
				object obj2 = (object)(&enumerator2);
				bool flag3 = ((Dictionary<ESpeedrunTime, float>)obj2).ContainsKey((ESpeedrunTime)typeof(IDisposable));
				obj = flag3;
				if (flag3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
				}
				Type typeFromHandle2 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(ESpeedrunTime));
				Array values2 = Enum.GetValues(typeFromHandle2);
				IEnumerator enumerator3 = values2.GetEnumerator();
				object obj3 = (object)(&enumerator2);
				object obj4 = (object)(&num);
				Dictionary<System.Int32Enum, float> dictionary = (Dictionary<System.Int32Enum, float>)(object)values2;
				break;
			}
			throw new NullReferenceException();
			IL_014f:
			object current = enumerator2.Current;
			bool flag4 = current == null;
			array = (Array)enumerator2;
			if (!flag4)
			{
				nint num7 = (nint)typeof(EMyStat);
				nint num8 = (nint)current;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v802 @ rdx_v41 (Il2CppClass<System.Object>)+40]");
				nint num9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v801 @ r8_v29 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Stats.EMyStat>)+40]");
				bool flag5 = num9 != 0;
				nint num10 = (nint)typeof(EMyStat);
				array = (Array)current;
				if (!flag5)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
					string key = ((Enum)(&intPtr)).ToString();
					bool flag6 = stats == null;
					num10 = (nint)typeof(EMyStat);
					array = (Array)(&intPtr);
					if (!flag6)
					{
						bool flag7 = stats.ContainsKey(key);
						nint num11 = (nint)typeof(IEnumerator);
						array = (Array)(object)stats;
						if (!flag7)
						{
							string key2 = ((Enum)(&intPtr2)).ToString();
							string name = ((Enum)(&intPtr3)).ToString();
							MyStat myStat = new MyStat(null, 0f);
							myStat.name = name;
							myStat.value = 0f;
							((Dictionary<object, object>)(object)stats).Add((object)key2, (object)myStat);
							num11 = 0;
							array = (Array)(object)stats;
						}
						continue;
					}
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num2 = num10;
			}
			throw new NullReferenceException();
			IL_012a:
			bool flag8 = ((Dictionary<ESpeedrunTime, float>)enumerator2).ContainsKey((ESpeedrunTime)typeof(IEnumerator));
			num2 = 1;
			goto IL_014f;
		}
		object obj6 = default(object);
		object obj7 = default(object);
		while (true)
		{
			object obj5;
			if (enumerator2 != null)
			{
				nint num12 = (nint)enumerator2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ r10_v11 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
				if ((nint)0 >= (nint)0)
				{
					goto IL_040f;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ r10_v11 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
				obj5 = 0;
				float num13 = 0f;
				while (true)
				{
					float num14 = num13 + num13;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v858 @ r8_v13+v1028 @ rax_v60 (System.Single)*8]");
					if (0 != (nint)typeof(IEnumerator))
					{
						num13++;
						float num15 = num13;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ r10_v11 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
						if (num15 < 0f)
						{
							continue;
						}
						goto IL_040f;
					}
					break;
				}
				goto IL_0427;
			}
			throw new NullReferenceException();
			IL_040f:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18026F510");
			obj5 = 0;
			goto IL_0427;
			IL_0427:
			if (enumerator2.MoveNext())
			{
				bool flag9 = enumerator2 == null;
				Dictionary<System.Int32Enum, float> dictionary = (Dictionary<System.Int32Enum, float>)enumerator2;
				if (!flag9)
				{
					object current2 = enumerator2.Current;
					bool flag10 = current2 == null;
					dictionary = (Dictionary<System.Int32Enum, float>)enumerator2;
					if (!flag10)
					{
						nint num16 = (nint)typeof(ESpeedrunTime);
						nint num17 = (nint)current2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v566 @ rdx_v30 (Il2CppClass<System.Object>)+40]");
						nint num18 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v556 @ r8_v17 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Stats.ESpeedrunTime>)+40]");
						bool flag11 = num18 != 0;
						nint num2 = (nint)typeof(ESpeedrunTime);
						dictionary = (Dictionary<System.Int32Enum, float>)current2;
						if (!flag11)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
							bool flag12 = times == null;
							num2 = (nint)typeof(ESpeedrunTime);
							dictionary = (Dictionary<System.Int32Enum, float>)(object)times;
							if (!flag12)
							{
								bool flag13 = times.ContainsKey((ESpeedrunTime)obj6);
								dictionary = (Dictionary<System.Int32Enum, float>)(object)times;
								if (!flag13)
								{
									dictionary = (Dictionary<System.Int32Enum, float>)(object)times;
									bool flag14 = times == null;
									num2 = 0;
									if (flag14)
									{
										break;
									}
									((Dictionary<System.Int32Enum, float>)(object)times).Add((System.Int32Enum)obj6, 0f);
								}
								continue;
							}
							throw new NullReferenceException();
						}
						bool flag15 = ((Dictionary<ESpeedrunTime, float>)(object)dictionary).ContainsKey((ESpeedrunTime)num2);
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj4 = obj7;
			if (obj7 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
			}
			return;
		}
		throw new NullReferenceException();
	}

	public StatsSaveFile()
	{
		Dictionary<string, MyStat> dictionary = new Dictionary<string, MyStat>();
		stats = dictionary;
		Dictionary<EEnemy, EnemyLog> dictionary2 = new Dictionary<EEnemy, EnemyLog>();
		enemyLogs = dictionary2;
		Dictionary<ESpeedrunTime, float> dictionary3 = new Dictionary<ESpeedrunTime, float>();
		times = dictionary3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
	}
}
