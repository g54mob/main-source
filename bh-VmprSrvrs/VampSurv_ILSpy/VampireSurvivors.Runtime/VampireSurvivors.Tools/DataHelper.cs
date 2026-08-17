using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Newtonsoft.Json.Linq;
using UnityEngine;
using VampireSurvivors.Data.Weapons;

namespace VampireSurvivors.Tools;

public static class DataHelper
{
	public unsafe static JObject UpgradeJsonData(JObject baseData, JObject newData)
	{
		//IL_001c: Expected O, but got Ref
		//IL_0077: Expected I, but got O
		//IL_010a: Expected O, but got I4
		//IL_00af: Expected O, but got I
		//IL_00b8: Expected O, but got I4
		//IL_01fe: Expected O, but got I
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Expected O, but got Unknown
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_0149: Expected O, but got I
		//IL_015d: Expected O, but got I
		//IL_017b: Expected O, but got I
		//IL_0279: Expected I, but got O
		//IL_01c9: Expected O, but got I
		//IL_01c9: Expected O, but got I
		//IL_01ce: Expected I, but got O
		//IL_02ad: Expected I, but got O
		//IL_038e: Expected O, but got I
		//IL_02ef: Expected I, but got O
		//IL_03cb: Expected O, but got I
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Expected Ref, but got Unknown
		//IL_0341: Expected I8, but got I4
		//IL_035b: Expected I, but got O
		//IL_0363: Expected O, but got Ref
		//IL_0368: Expected I, but got O
		//IL_0370: Expected O, but got Ref
		//IL_0401: Expected O, but got I
		//IL_056e: Expected O, but got I
		//IL_0596: Expected O, but got I
		//IL_0432: Expected O, but got I
		//IL_05bb: Expected I4, but got O
		//IL_05ee: Expected O, but got I
		//IL_05f3: Expected I, but got O
		//IL_04f0: Expected O, but got I
		//IL_0518: Expected O, but got I
		//IL_04ca: Expected O, but got I
		if (newData != null)
		{
			IEnumerable<object> enumerable = Enumerable.Cast<object>(newData._properties);
			if (enumerable != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				JObject jObject = default(JObject);
				object obj = (object)(&jObject);
				JObject jObject2 = null;
				object obj2 = default(object);
				object obj11 = default(object);
				object obj12 = default(object);
				JObject jObject3 = default(JObject);
				float num5 = default(float);
				object obj16 = default(object);
				object obj17 = default(object);
				while (true)
				{
					object obj10;
					object obj3;
					if (jObject != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						if (obj2 != null)
						{
							bool flag = jObject == null;
							jObject2 = null;
							if (!flag)
							{
								nint num = (nint)jObject;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ r10_v12 (Il2CppClass<Newtonsoft.Json.Linq.JObject>)+12E]");
								if ((nint)0 >= (nint)0)
								{
									goto IL_00ef;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ r10_v12 (Il2CppClass<Newtonsoft.Json.Linq.JObject>)+B0]");
								obj3 = 0;
								object obj4 = 0;
								while (true)
								{
									object obj5 = obj4 + obj4;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v577 @ r8_v16+v738 @ rax_v67*8]");
									if (0 == (nint)typeof(IEnumerator<JProperty>))
									{
										break;
									}
									obj4++;
									object obj6 = obj4;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ r10_v12 (Il2CppClass<Newtonsoft.Json.Linq.JObject>)+12E]");
									if ((nint)obj6 < 0)
									{
										continue;
									}
									goto IL_00ef;
								}
								object obj7 = obj4 + obj4;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v577 @ r8_v16+8+v798 @ rcx_v47*8]");
								object obj8 = (nint)0 << 4;
								object obj9 = obj8 + 312;
								obj10 = obj9 + num;
								goto IL_0749;
							}
							throw new NullReferenceException();
						}
						if (obj != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
						}
						break;
					}
					throw new NullReferenceException();
					IL_00ef:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
					obj10 = obj11;
					obj3 = 0;
					goto IL_0749;
					IL_0749:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v803 @ rdx_v19] (should have been resolved before IL gen)");
					bool flag2 = obj12 == null;
					jObject2 = jObject;
					if (!flag2)
					{
						bool flag3 = jObject3 == null;
						jObject2 = jObject;
						if (!flag3)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rax_v35+60]");
							bool flag4 = jObject3.ContainsKey((string)0);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rax_v35+60]");
							string text = (string)0;
							if (!flag4)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rax_v35+58]");
								object obj13 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rax_v35+58]");
								bool flag5 = (nint)0 == 0;
								jObject2 = jObject3;
								if (!flag5)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rax_v35+60]");
									nint num2 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ r8_v27+10]");
									jObject3.Add((string)num2, (JToken)0);
									nint num3 = unchecked((nint)null);
									jObject2 = jObject3;
									continue;
								}
								throw new NullReferenceException();
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rax_v35+60]");
							bool flag6 = (nint)0 == 0;
							jObject2 = jObject3;
							if (!flag6)
							{
								object obj14 = "level";
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rax_v35+60]");
								bool flag7 = 0 == unchecked((nint)"level");
								nint num3 = (nint)typeof(IEnumerator<JProperty>);
								jObject2 = jObject3;
								if (flag7)
								{
									continue;
								}
								bool flag8 = "level" == null;
								nint num4 = (nint)typeof(IEnumerator<JProperty>);
								JObject jObject4 = jObject3;
								if (!flag8)
								{
									int stringLength = text._stringLength;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ rdx_v22+10]");
									bool flag9 = (nint)stringLength != 0;
									num4 = (nint)typeof(IEnumerator<JProperty>);
									jObject4 = jObject3;
									if (!flag9)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rax_v35+60]");
										ref byte reference = ref *(byte*)((nint)0 + (nint)20);
										ref byte second = ref *(byte*)("level" + 20);
										ulong length = (ulong)(text._stringLength + text._stringLength);
										bool flag10 = System.SpanHelpers.SequenceEqual(ref reference, ref second, length);
										num4 = unchecked((nint)null);
										jObject4 = (JObject)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference);
										num3 = unchecked((nint)null);
										jObject2 = (JObject)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference);
										if (flag10)
										{
											continue;
										}
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rax_v35+58]");
								object obj15 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rax_v35+58]");
								bool flag11 = (nint)0 == 0;
								jObject2 = jObject4;
								if (!flag11)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v293 @ rax_v38+10]");
									jObject2 = (JObject)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v293 @ rax_v38+10]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v293 @ rax_v38+10]");
										JTokenType type = ((JObject)0).Type;
										JToken value;
										if (type != JTokenType.Integer)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rax_v35+58]");
											jObject2 = (JObject)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rax_v35+58]");
											if ((nint)0 == 0)
											{
												throw new NullReferenceException();
											}
											jObject2 = (JObject)((JToken)jObject2)._parent;
											if (((JToken)jObject2)._parent == null)
											{
												throw new NullReferenceException();
											}
											JTokenType type2 = ((JObject)((JToken)jObject2)._parent).Type;
											if (type2 != JTokenType.Float)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rax_v35+60]");
												value = newData.get_Item((string)0);
												num5 = num5;
											}
											else
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rax_v35+60]");
												JToken jToken = newData.get_Item((string)0);
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAECF0");
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rax_v35+60]");
												JToken jToken2 = jObject3.get_Item((string)0);
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAECF0");
												float num6 = num5 + num5;
												value = num6;
												num5 = num6;
											}
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rax_v35+60]");
											JToken jToken3 = newData.get_Item((string)0);
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAEBA0");
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rax_v35+60]");
											JToken jToken4 = jObject3.get_Item((string)0);
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAEBA0");
											int num7 = (int)(obj16 + obj17);
											value = num7;
											num5 = num5;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rax_v35+60]");
										jObject3.set_Item((string)0, value);
										num3 = unchecked((nint)null);
										jObject2 = jObject3;
										continue;
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				return jObject3;
			}
		}
		throw new NullReferenceException();
	}

	public unsafe static JObject UpgradeStageJsonData(JObject baseData, JObject newData)
	{
		//IL_001c: Expected O, but got Ref
		//IL_0077: Expected I, but got O
		//IL_010a: Expected O, but got I4
		//IL_00af: Expected O, but got I
		//IL_00b8: Expected O, but got I4
		//IL_01da: Expected O, but got I
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Expected O, but got Unknown
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Expected O, but got Unknown
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_0141: Expected O, but got I
		//IL_020f: Expected O, but got I
		//IL_022c: Expected O, but got I
		//IL_023a: Expected O, but got I4
		//IL_0163: Expected O, but got I
		//IL_01a9: Expected O, but got I
		//IL_01a9: Expected O, but got I
		//IL_01b2: Expected O, but got I4
		if (newData != null)
		{
			IEnumerable<object> enumerable = Enumerable.Cast<object>(newData._properties);
			if (enumerable != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				JObject jObject = default(JObject);
				object obj = (object)(&jObject);
				JObject jObject2 = null;
				object obj2 = default(object);
				object obj11 = default(object);
				object obj12 = default(object);
				JObject jObject3 = default(JObject);
				while (true)
				{
					object obj10;
					object obj3;
					if (jObject != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						if (obj2 != null)
						{
							bool flag = jObject == null;
							jObject2 = null;
							if (!flag)
							{
								nint num = (nint)jObject;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ r10_v7 (Il2CppClass<Newtonsoft.Json.Linq.JObject>)+12E]");
								if ((nint)0 >= (nint)0)
								{
									goto IL_00ef;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ r10_v7 (Il2CppClass<Newtonsoft.Json.Linq.JObject>)+B0]");
								obj3 = 0;
								object obj4 = 0;
								while (true)
								{
									object obj5 = obj4 + obj4;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ r8_v11+v438 @ rax_v34*8]");
									if (0 == (nint)typeof(IEnumerator<JProperty>))
									{
										break;
									}
									obj4++;
									object obj6 = obj4;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ r10_v7 (Il2CppClass<Newtonsoft.Json.Linq.JObject>)+12E]");
									if ((nint)obj6 < 0)
									{
										continue;
									}
									goto IL_00ef;
								}
								object obj7 = obj4 + obj4;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ r8_v11+8+v494 @ rcx_v26*8]");
								object obj8 = (nint)0 << 4;
								object obj9 = obj8 + 312;
								obj10 = obj9 + num;
								goto IL_035c;
							}
							throw new NullReferenceException();
						}
						if (obj != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
						}
						break;
					}
					throw new NullReferenceException();
					IL_00ef:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
					obj10 = obj11;
					obj3 = 0;
					goto IL_035c;
					IL_035c:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v499 @ rdx_v14] (should have been resolved before IL gen)");
					if (obj12 != null)
					{
						if (jObject3 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v25+60]");
							if (!jObject3.ContainsKey((string)0))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v25+58]");
								object obj13 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v25+58]");
								if ((nint)0 == 0)
								{
									throw new NullReferenceException();
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v25+60]");
								nint num2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ r8_v15+10]");
								jObject3.Add((string)num2, (JToken)0);
								object obj14 = 0;
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v25+60]");
								JToken value = newData.get_Item((string)0);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v25+60]");
								jObject3.set_Item((string)0, value);
								object obj14 = 0;
							}
							continue;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				return jObject3;
			}
		}
		throw new NullReferenceException();
	}

	public unsafe static bool GetWeaponDataForLevel(JArray dataArray, int level, out WeaponData concreteData)
	{
		//IL_013c: Expected I4, but got O
		//IL_00e1: Expected I, but got O
		ref WeaponData reference = ref *(WeaponData*)null;
		if (dataArray != null)
		{
			IList<JToken> childrenTokens = dataArray.ChildrenTokens;
			if (childrenTokens != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				object obj = default(object);
				bool flag = level < (nint)obj;
				int index = level;
				if (!flag)
				{
					Debug.LogWarning("You have passed in a value greater than the available levels, returning data for highest level.");
					int count = dataArray.Count;
					index = count - 1;
				}
				JToken item = ((JContainer)dataArray).GetItem(index);
				if (item != null)
				{
					if (item.HasValues)
					{
						object obj2 = Extensions.Value<object>(item);
						if (obj2 != null)
						{
							nint num = (nint)item;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v328 @ rdx_v12 (Il2CppClass<System.Collections.Generic.IEnumerable`1<Newtonsoft.Json.Linq.JToken>>)+238] (should have been resolved before IL gen)");
							object obj3 = default(object);
							if (obj3 != null)
							{
								object obj4 = ((JToken)obj2).ToObject<object>();
								reference = ref *(WeaponData*)obj4;
								return true;
							}
						}
					}
					return false;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public unsafe static JToken GetMinuteDataFromStageDataList(int requiredMinute, JArray stageDataArray)
	{
		//IL_001a: Expected O, but got Ref
		//IL_00b3: Expected O, but got I
		//IL_00e6: Expected O, but got I
		IEnumerator<JToken> enumerator = stageDataArray.GetEnumerator();
		object obj2 = default(object);
		object obj = (object)(&obj2);
		object obj3 = default(object);
		JToken jToken = default(JToken);
		object obj4 = default(object);
		int num = default(int);
		while (true)
		{
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				if (obj3 != null)
				{
					bool flag = obj2 == null;
					JArray jArray = null;
					if (!flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804860B0");
						bool flag2 = jToken == null;
						jArray = null;
						if (flag2)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FD360");
						bool flag3 = obj4 == null;
						jArray = (JArray)0;
						if (flag3)
						{
							continue;
						}
						object obj5 = obj4 >> 32;
						bool flag4 = (nint)obj5 != num;
						jArray = (JArray)0;
						if (!flag4)
						{
							if (obj != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
							}
							return jToken;
						}
						continue;
					}
					throw new NullReferenceException();
				}
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				return null;
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}
}
