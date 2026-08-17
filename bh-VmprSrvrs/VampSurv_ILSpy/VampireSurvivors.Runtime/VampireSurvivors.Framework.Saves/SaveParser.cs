using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Newtonsoft.Json;
using UnityEngine;
using VampireSurvivors.App.Scripts.Framework.Platforms;
using VampireSurvivors.Data;
using VampireSurvivors.Data.PowerUp;
using VampireSurvivors.Data.Props;
using VampireSurvivors.UI;

namespace VampireSurvivors.Framework.Saves;

public class SaveParser
{
	private sealed class _003C_003Ec__DisplayClass95_0
	{
		public PowerUpType powerUp;

		internal bool _003CBoughtPowerups_003Eb__0(PowerUpType c)
		{
			//IL_000f: Expected O, but got I4
			object obj = c - powerUp;
			return obj == null;
		}
	}

	private JsonTextReader _reader;

	private PlayerOptionsData _pod;

	public static PlayerOptionsData Parse(string data)
	{
		SaveParser saveParser = new SaveParser();
		if (saveParser != null)
		{
			return saveParser.ParsePod(data);
		}
		return (PlayerOptionsData)(object)new NullReferenceException();
	}

	public static PlayerOptionsData ParseAdventureData(JsonTextReader reader)
	{
		SaveParser saveParser = new SaveParser();
		if (saveParser != null)
		{
			return saveParser.ParseAdventurePod(reader);
		}
		return (PlayerOptionsData)(object)new NullReferenceException();
	}

	public PlayerOptionsData ParsePod(string data)
	{
		//IL_0306: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A28CB]");
		bool flag = (nint)0 != 0;
		PlayerOptionsData pod = new PlayerOptionsData();
		_pod = pod;
		StringReader reader = new StringReader(data);
		JsonTextReader reader2 = new JsonTextReader(reader);
		_reader = reader2;
		JsonTextReader reader3 = _reader;
		if (_reader != null)
		{
			do
			{
				bool flag2 = reader3.Read();
				JsonTextReader reader4 = _reader;
				if (flag2)
				{
					if (_reader == null)
					{
						break;
					}
					object value = _reader.Value;
					if (value != null)
					{
						if (_reader == null)
						{
							break;
						}
						JsonToken tokenType = _reader.TokenType;
						if (tokenType == JsonToken.PropertyName)
						{
							if (_reader == null)
							{
								break;
							}
							object value2 = _reader.Value;
							bool flag3 = value2 == null;
							string text = null;
							if (!flag3)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
								bool flag4 = value2 != null;
								text = null;
								if (!flag4)
								{
									text = (string)value2;
								}
								if (text == null)
								{
									goto IL_0355;
								}
							}
							nint num = (nint)typeof(SaveUtils);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v614 @ rcx_v27 (Il2CppClass<VampireSurvivors.Framework.Saves.SaveUtils>)+E4]");
							flag = (nint)0 != 0;
							MethodInfo parser = SaveUtils.GetParser(text);
							if ((object)parser != null)
							{
								if (_reader == null)
								{
									break;
								}
								bool flag5 = _reader.Read();
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18099C850");
							}
						}
					}
					reader3 = _reader;
					continue;
				}
				if (_reader == null)
				{
					break;
				}
				((JsonReader)reader4)._003CCloseInput_003Ek__BackingField = true;
				if (_reader == null)
				{
					break;
				}
				_reader.Close();
				_reader = null;
				PostParseFixes();
				return _pod;
			}
			while (_reader != null);
		}
		NullReferenceException ex = new NullReferenceException();
		goto IL_0355;
		IL_0355:
		return (PlayerOptionsData)(object)new InvalidCastException();
	}

	public PlayerOptionsData ParseAdventurePod(JsonTextReader reader)
	{
		PlayerOptionsData pod = new PlayerOptionsData(addDefaults: false);
		_pod = pod;
		_reader = reader;
		if (reader != null)
		{
			int depth = reader.Depth;
			JsonTextReader reader2 = _reader;
			if (_reader != null)
			{
				while (true)
				{
					if (reader2.Read())
					{
						if (_reader == null)
						{
							break;
						}
						int depth2 = _reader.Depth;
						if (depth == depth2)
						{
							if (_reader == null)
							{
								break;
							}
							JsonToken tokenType = _reader.TokenType;
							if (tokenType == JsonToken.EndObject)
							{
								goto IL_0275;
							}
						}
						if (_reader == null)
						{
							break;
						}
						object value = _reader.Value;
						if (value != null)
						{
							if (_reader == null)
							{
								break;
							}
							JsonToken tokenType2 = _reader.TokenType;
							if (tokenType2 == JsonToken.PropertyName)
							{
								if (_reader == null)
								{
									break;
								}
								string value2 = (string)_reader.Value;
								if (value2 == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
								bool flag = value2 != null;
								string text = null;
								if (!flag)
								{
									text = value2;
								}
								if (text == null)
								{
									goto IL_032a;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
								bool flag2 = value2 != null;
								string text2 = null;
								if (!flag2)
								{
									text2 = value2;
								}
								string propName = text2.Replace("ADV_", "");
								ParseProp(propName);
							}
						}
						reader2 = _reader;
						if (_reader == null)
						{
							break;
						}
						continue;
					}
					goto IL_0275;
					IL_0275:
					PostParseFixes();
					return _pod;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		goto IL_032a;
		IL_032a:
		return (PlayerOptionsData)(object)new InvalidCastException();
	}

	private unsafe void PostParseFixes()
	{
		//IL_0bd4: Expected O, but got I4
		//IL_0073: Expected O, but got I4
		//IL_009b: Expected O, but got Ref
		//IL_0424: Expected O, but got Ref
		//IL_099c: Expected O, but got Ref
		//IL_087b: Expected O, but got I
		//IL_046f: Expected O, but got Ref
		//IL_01d3: Expected O, but got Ref
		//IL_08cd: Expected O, but got I
		//IL_08d1: Expected O, but got I4
		//IL_04c1: Expected O, but got I4
		//IL_05fa: Expected O, but got Ref
		//IL_075d: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A28CD]");
		bool flag = (nint)0 != 0;
		PlayerOptionsData pod = _pod;
		List<CharacterStageData>.Enumerator enumerator;
		nint num2 = default(nint);
		List<StageType> list2 = default(List<StageType>);
		if (pod._003CStageCompletionLog_003Ek__BackingField != null && pod._003CCharacterStageData_003Ek__BackingField != null)
		{
			enumerator = (List<CharacterStageData>.Enumerator)0;
			Dictionary<CharacterType, List<CharacterStageData>>.Enumerator enumerator2 = default(Dictionary<CharacterType, List<CharacterStageData>>.Enumerator);
			CharacterStageData characterStageData = default(CharacterStageData);
			List<CharacterStageData>.Enumerator enumerator4 = default(List<CharacterStageData>.Enumerator);
			while (enumerator2.MoveNext())
			{
				PlayerOptionsData pod2 = _pod;
				bool flag2 = _pod == null;
				Dictionary<CharacterType, List<CharacterStageData>>.Enumerator enumerator3 = (Dictionary<CharacterType, List<CharacterStageData>>.Enumerator)(&enumerator2);
				if (!flag2)
				{
					bool flag3 = pod2._003CStageCompletionLog_003Ek__BackingField == null;
					enumerator3 = (Dictionary<CharacterType, List<CharacterStageData>>.Enumerator)pod2._003CStageCompletionLog_003Ek__BackingField;
					if (!flag3)
					{
						int num = ((Dictionary<System.Int32Enum, object>)(object)pod2._003CStageCompletionLog_003Ek__BackingField).FindEntry((System.Int32Enum)0);
						flag = !flag3;
						Dictionary<System.Int32Enum, object> dictionary = (Dictionary<System.Int32Enum, object>)(object)pod2._003CStageCompletionLog_003Ek__BackingField;
						if (!flag)
						{
							PlayerOptionsData pod3 = _pod;
							if (_pod == null)
							{
								Dictionary<System.Int32Enum, object> dictionary2 = (Dictionary<System.Int32Enum, object>)(object)pod2._003CStageCompletionLog_003Ek__BackingField;
								throw new NullReferenceException();
							}
							List<StageType> list = new List<StageType>();
							bool flag4 = ((Dictionary<System.Int32Enum, object>)(object)pod3._003CStageCompletionLog_003Ek__BackingField).TryInsert((System.Int32Enum)0, (object)list, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
							num2 = 0;
							list2 = list;
							dictionary = (Dictionary<System.Int32Enum, object>)(object)pod3._003CStageCompletionLog_003Ek__BackingField;
						}
						bool flag5 = characterStageData == null;
						enumerator3 = (Dictionary<CharacterType, List<CharacterStageData>>.Enumerator)dictionary;
						if (!flag5)
						{
							CharacterStageData characterStageData2 = characterStageData;
							if (enumerator.MoveNext())
							{
								System.Int32Enum int32Enum = (System.Int32Enum)0;
								enumerator3 = (Dictionary<CharacterType, List<CharacterStageData>>.Enumerator)(&enumerator);
								throw new NullReferenceException();
							}
							enumerator = enumerator4;
							continue;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
		}
		else
		{
			enumerator = (List<CharacterStageData>.Enumerator)0;
		}
		PlayerOptionsData pod4 = _pod;
		if (pod4._003CStageCompletionLog_003Ek__BackingField != null && pod4._003CCharacterStageData_003Ek__BackingField != null)
		{
			Dictionary<CharacterType, List<StageType>>.Enumerator enumerator5 = default(Dictionary<CharacterType, List<StageType>>.Enumerator);
			System.Collections.Generic.InsertionBehavior insertionBehavior = default(System.Collections.Generic.InsertionBehavior);
			List<StageType>.Enumerator enumerator7 = default(List<StageType>.Enumerator);
			List<CharacterStageData>.Enumerator enumerator8 = default(List<CharacterStageData>.Enumerator);
			while (enumerator5.MoveNext())
			{
				bool flag6 = insertionBehavior == System.Collections.Generic.InsertionBehavior.None;
				Dictionary<CharacterType, List<StageType>>.Enumerator enumerator6 = (Dictionary<CharacterType, List<StageType>>.Enumerator)(&enumerator5);
				if (!flag6)
				{
					nint num3 = num2;
					List<CharacterStageData> list3 = (List<CharacterStageData>)(object)list2;
					while (enumerator7.MoveNext())
					{
						PlayerOptionsData pod5 = _pod;
						bool flag7 = _pod == null;
						enumerator6 = (Dictionary<CharacterType, List<StageType>>.Enumerator)(&enumerator7);
						if (!flag7)
						{
							bool flag8 = pod5._003CCharacterStageData_003Ek__BackingField == null;
							if (!flag8)
							{
								int num4 = ((Dictionary<System.Int32Enum, object>)(object)pod5._003CCharacterStageData_003Ek__BackingField).FindEntry((System.Int32Enum)0);
								object obj = !flag8;
								if (obj == null)
								{
									PlayerOptionsData pod6 = _pod;
									if (_pod == null)
									{
										throw new NullReferenceException();
									}
									List<CharacterStageData> list4 = new List<CharacterStageData>();
									if (pod6._003CCharacterStageData_003Ek__BackingField == null)
									{
										throw new NullReferenceException();
									}
									bool flag9 = ((Dictionary<System.Int32Enum, object>)(object)pod6._003CCharacterStageData_003Ek__BackingField).TryInsert((System.Int32Enum)0, (object)list4, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
									num3 = 0;
									list3 = list4;
								}
								PlayerOptionsData pod7 = _pod;
								if (_pod != null)
								{
									if (pod7._003CCharacterStageData_003Ek__BackingField != null)
									{
										object obj2 = ((Dictionary<System.Int32Enum, object>)(object)pod7._003CCharacterStageData_003Ek__BackingField).get_Item((System.Int32Enum)0);
										if (obj2 != null)
										{
											CharacterStageData characterStageData2 = null;
											if (enumerator8.MoveNext())
											{
												System.Int32Enum int32Enum2 = (System.Int32Enum)0;
												List<CharacterStageData>.Enumerator enumerator9 = (List<CharacterStageData>.Enumerator)(&enumerator8);
												throw new NullReferenceException();
											}
											if (characterStageData2 == null)
											{
												CharacterStageData characterStageData3 = new CharacterStageData();
												bool flag10 = characterStageData3 == null;
												List<CharacterStageData>.Enumerator enumerator9 = (List<CharacterStageData>.Enumerator)typeof(CharacterStageData);
												if (flag10)
												{
													throw new NullReferenceException();
												}
												characterStageData3._003Ccomplete_003Ek__BackingField = 1;
												characterStageData3._003Ctype_003Ek__BackingField = StageType.FOREST;
												PlayerOptionsData pod8 = _pod;
												bool flag11 = _pod == null;
												enumerator9 = (List<CharacterStageData>.Enumerator)typeof(CharacterStageData);
												if (flag11)
												{
													throw new NullReferenceException();
												}
												if (pod8._003CCharacterStageData_003Ek__BackingField == null)
												{
													throw new NullReferenceException();
												}
												object obj3 = ((Dictionary<System.Int32Enum, object>)(object)pod8._003CCharacterStageData_003Ek__BackingField).get_Item((System.Int32Enum)0);
												if (obj3 == null)
												{
													throw new NullReferenceException();
												}
												List<CharacterStageData> list5 = ((Dictionary<CharacterType, List<CharacterStageData>>)obj3).get_Item((CharacterType)characterStageData3);
												characterStageData2 = characterStageData3;
											}
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
					num2 = num3;
					list2 = (List<StageType>)(object)list3;
					continue;
				}
				throw new NullReferenceException();
			}
		}
		PlayerOptionsData pod9 = _pod;
		if (pod9._003CBoughtPowerups_003Ek__BackingField != null)
		{
			List<PowerUpLevel> list6 = pod9._003CBoughtPowerups_003Ek__BackingField;
			nint num5 = list6._size - 1;
			if (num5 > 0)
			{
				while (true)
				{
					PlayerOptionsData pod10 = _pod;
					List<PowerUpLevel> list7 = pod10._003CBoughtPowerups_003Ek__BackingField;
					if (num5 >= list7._size)
					{
						break;
					}
					PowerUpLevel[] items = list7._items;
					if (items[num5] != null)
					{
						PlayerOptionsData pod11 = _pod;
						bool flag12 = pod11._003CBoughtPowerups_003Ek__BackingField.Remove((PowerUpLevel)num5);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v47 (System.Boolean)+10]");
						if ((nint)0 == 16)
						{
							PlayerOptionsData pod12 = _pod;
							object item = pod12._003CBoughtPowerups_003Ek__BackingField.Remove((PowerUpLevel)num5);
							bool flag13 = ((List<object>)(object)pod12._003CBoughtPowerups_003Ek__BackingField).Remove(item);
						}
					}
					num5--;
					if (num5 > 0)
					{
						continue;
					}
					goto IL_0918;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				Dictionary<System.Int32Enum, object> dictionary3 = null;
				goto IL_0d70;
			}
		}
		goto IL_0918;
		IL_0918:
		PlayerOptionsData pod13 = _pod;
		if (pod13._003CCharacterEggCount_003Ek__BackingField == null)
		{
			return;
		}
		Dictionary<CharacterType, float>.Enumerator enumerator10 = default(Dictionary<CharacterType, float>.Enumerator);
		object obj4 = default(object);
		while (true)
		{
			if (!enumerator10.MoveNext())
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B2CED0h\"");
			if (obj4 != null)
			{
				continue;
			}
			PlayerOptionsData pod14 = _pod;
			bool flag14 = _pod == null;
			Dictionary<System.Int32Enum, object> dictionary3 = (Dictionary<System.Int32Enum, object>)(&enumerator10);
			if (!flag14)
			{
				bool flag15 = pod14._003CCharacterEggInfo_003Ek__BackingField == null;
				dictionary3 = (Dictionary<System.Int32Enum, object>)(object)pod14._003CCharacterEggInfo_003Ek__BackingField;
				if (!flag15)
				{
					int num6 = ((Dictionary<System.Int32Enum, object>)(object)pod14._003CCharacterEggInfo_003Ek__BackingField).FindEntry((System.Int32Enum)0);
					if (!flag15)
					{
						PlayerOptionsData pod15 = _pod;
						bool flag16 = _pod == null;
						dictionary3 = (Dictionary<System.Int32Enum, object>)(object)pod14._003CCharacterEggInfo_003Ek__BackingField;
						if (flag16)
						{
							throw new NullReferenceException();
						}
						dictionary3 = (Dictionary<System.Int32Enum, object>)(object)pod15._003CCharacterEggInfo_003Ek__BackingField;
						if (pod15._003CCharacterEggInfo_003Ek__BackingField == null)
						{
							break;
						}
						bool flag17 = ((Dictionary<System.Int32Enum, object>)(object)pod15._003CCharacterEggInfo_003Ek__BackingField).Remove((System.Int32Enum)0);
					}
					continue;
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		goto IL_0d70;
		IL_0d70:
		throw new NullReferenceException();
	}

	private void ParseProp(string propName)
	{
		MethodInfo parser = SaveUtils.GetParser(propName);
		if ((object)parser != null)
		{
			bool flag = _reader.Read();
			object obj = parser.Invoke(this, BindingFlags.Default, null, null, null);
		}
	}

	private T ParseEnum<T>(object value)
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_0118: Expected O, but got I
		//IL_023d: Expected I, but got O
		//IL_027c: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ r8 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type type2 = default(Type);
		Type type = type2;
		if (value != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AED8]");
			bool flag = value != null;
			object obj3 = null;
			if (!flag)
			{
				obj3 = value;
			}
			if (obj3 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEB8]");
				bool flag2 = value != null;
				object obj4 = null;
				if (!flag2)
				{
					obj4 = value;
				}
				if (obj4 == null)
				{
					goto IL_012b;
				}
			}
			int num = Convert.ToInt32(value);
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value2 = default(object);
			return ((SaveParser)0).ParseIntToEnum<T>(value2);
		}
		goto IL_012b;
		IL_038a:
		throw new InvalidCastException();
		IL_012b:
		bool flag3 = value == null;
		object obj5 = null;
		if (!flag3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
			bool flag4 = value != null;
			obj5 = null;
			if (!flag4)
			{
				obj5 = value;
			}
			if (obj5 == null)
			{
				InvalidCastException ex = new InvalidCastException();
				goto IL_038a;
			}
		}
		if ((object)type != null)
		{
			if (!type.IsEnumDefined(obj5))
			{
				return (T)null;
			}
			bool flag5 = value == null;
			string value3 = null;
			if (!flag5)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
				bool flag6 = value != null;
				object obj6 = null;
				if (!flag6)
				{
					obj6 = value;
				}
				bool flag7 = obj6 == null;
				value3 = (string)obj6;
				if (flag7)
				{
					throw new InvalidCastException();
				}
			}
			object obj7 = Enum.Parse(type, value3, ignoreCase: false);
			nint num2 = 0;
			nint num3 = (nint)obj7;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ rdx_v13 (Il2CppClass<System.Object>)+40]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v444 @ rax_v26 (Il2CppClass<T>)+40]");
			if (num4 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v586 @ rax_v24 (System.Object)+10]");
				return (T)0;
			}
			goto IL_038a;
		}
		ArgumentNullException ex2 = new ArgumentNullException("enumType");
		ex2._002Ector("enumType");
		throw ex2;
	}

	private T ParseIntToEnum<T>(object value)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_0078: Expected O, but got I
		//IL_00d4: Expected I, but got O
		//IL_0110: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		if (num != 0)
		{
			object obj3 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v131 @ r8_v4+238] (should have been resolved before IL gen)");
			object obj4 = default(object);
			if (obj4 == null)
			{
				return (T)null;
			}
			nint num2 = 0;
			if (value != null)
			{
				nint num3 = (nint)value;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rdx_v8 (Il2CppClass<System.Object>)+40]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rax_v20 (Il2CppClass<T>)+40]");
				if (num4 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [value @ rdx (System.Object)+10]");
					return (T)0;
				}
				throw new InvalidCastException();
			}
			return (T)new NullReferenceException();
		}
		ArgumentNullException ex = new ArgumentNullException("enumType");
		throw ex;
	}

	private bool ParseBool(object value)
	{
		//IL_00ac: Expected I4, but got O
		if (value == null)
		{
			return false;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18000BDF0");
				bool result = default(bool);
				return result;
			}
			InvalidCastException ex = new InvalidCastException();
			return (byte)(int)ex != 0;
		}
		throw new InvalidCastException();
	}

	private int ParseInt(object value)
	{
		return Convert.ToInt32(value, CultureInfo.invariant_culture_info);
	}

	private uint ParseUInt(object value)
	{
		return Convert.ToUInt32(value, CultureInfo.invariant_culture_info);
	}

	private unsafe float ParseFloat(object value)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0596: Unknown result type (might be due to invalid IL or missing references)
		//IL_059b: Expected O, but got Unknown
		//IL_020d: Expected I, but got O
		//IL_05c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ca: Expected O, but got Unknown
		//IL_0251: Expected I, but got O
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected Ref, but got Unknown
		//IL_00e4: Expected I8, but got I
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected Ref, but got Unknown
		//IL_02ad: Expected O, but got Ref
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected Ref, but got Unknown
		//IL_01b4: Expected I8, but got I
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected Ref, but got Unknown
		//IL_02fb: Invalid comparison between I4 and F4
		//IL_030d: Expected F4, but got I4
		//IL_0350: Expected O, but got Ref
		//IL_0358: Expected native int or pointer, but got O
		//IL_036b: Expected O, but got Ref
		//IL_0386: Expected O, but got Ref
		//IL_03de: Expected O, but got Ref
		//IL_03f9: Expected O, but got Ref
		//IL_0434: Expected O, but got Ref
		//IL_044c: Expected O, but got Ref
		//IL_04af: Expected O, but got Ref
		//IL_04e8: Expected O, but got Ref
		//IL_051c: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (value != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
			bool flag = value != null;
			object obj3 = null;
			if (!flag)
			{
				obj3 = value;
			}
			if (obj3 != null)
			{
				object obj4 = "infinity";
				if (obj3 != "infinity")
				{
					if ("infinity" != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rbx_v7 (System.Object)+10]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rdx_v31+10]");
						if (num == 0)
						{
							ref byte first = ref *(byte*)(obj3 + 20);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rbx_v7 (System.Object)+10]");
							nint num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rbx_v7 (System.Object)+10]");
							ulong length = (ulong)(num2 + 0);
							if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("infinity" + 20), length))
							{
								goto IL_01f1;
							}
						}
					}
					object obj5 = "undefined";
					if (obj3 != "undefined")
					{
						if ("undefined" != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rbx_v7 (System.Object)+10]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdx_v33+10]");
							if (num3 == 0)
							{
								ref byte first2 = ref *(byte*)(obj3 + 20);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rbx_v7 (System.Object)+10]");
								nint num4 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rbx_v7 (System.Object)+10]");
								ulong length2 = (ulong)(num4 + 0);
								if (System.SpanHelpers.SequenceEqual(ref first2, ref *(byte*)("undefined" + 20), length2))
								{
									goto IL_01f1;
								}
							}
						}
						goto IL_01ff;
					}
				}
				goto IL_01f1;
			}
			goto IL_01ff;
		}
		goto IL_056a;
		IL_01f1:
		float num5 = 3.4028235E+38f;
		goto IL_0665;
		IL_01ff:
		nint num6 = (nint)typeof(BigInteger);
		bool flag2 = (object)value.GetType() != typeof(BigInteger);
		object obj6 = null;
		if (!flag2)
		{
			obj6 = value;
		}
		if (obj6 != null)
		{
			nint num7 = (nint)value;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rcx_v10 (Il2CppClass<System.Object>)+40]");
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v6 (Il2CppClass<System.Numerics.BigInteger>)+40]");
			if (num8 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [value @ rdx (System.Object)+10]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [value @ rdx (System.Object)+10]");
				_ = 0;
				BigInteger bigInteger = (BigInteger)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
				double num9 = (double)bigInteger;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm6,xmm0\"");
				float num10;
				if (0 <= 2139095040)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B2D728h\"");
					bool flag3 = 0f != -1f / 0f;
					num10 = 0f;
					if (!flag3)
					{
						num10 = -3.4028235E+38f;
					}
				}
				else
				{
					num10 = 3.4028235E+38f;
				}
				_ = 0;
				BigInteger bigInteger2 = (BigInteger)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
				System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)bigInteger2, new BigInteger((double)num10));
				BigInteger bigInteger3 = (BigInteger)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
				_ = 0;
				BigInteger bigInteger4 = (BigInteger)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [value @ rdx (System.Object)+10]");
				_ = 0;
				BigInteger bigInteger5 = bigInteger4 - bigInteger3;
				_ = 0;
				_ = bigInteger5._sign;
				_ = 100;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm7,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-25]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
				_ = 0;
				BigInteger bigInteger6 = (BigInteger)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
				_ = 0;
				BigInteger bigInteger7 = (BigInteger)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
				_ = bigInteger5._sign;
				BigInteger bigInteger8 = bigInteger7 * bigInteger6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [value @ rdx (System.Object)+10]");
				_ = 0;
				BigInteger bigInteger9 = (BigInteger)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
				_ = bigInteger8._sign;
				BigInteger bigInteger10 = (BigInteger)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
				_ = (bigInteger10 / bigInteger9)._sign;
				string[] array = new string[6];
				if (array != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					BigInteger bigInteger11 = (BigInteger)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
					string text = ((BigInteger*)bigInteger11)->ToString();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					BigInteger bigInteger12 = (BigInteger)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
					string text2 = ((BigInteger*)bigInteger12)->ToString();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					BigInteger bigInteger13 = (BigInteger)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
					string text3 = ((BigInteger*)bigInteger13)->ToString();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					string message = string.Concat(array);
					Debug.Log(message);
					num5 = num10;
					goto IL_0665;
				}
				throw new NullReferenceException();
			}
			throw new InvalidCastException();
		}
		goto IL_056a;
		IL_056a:
		CultureInfo invariantCulture = CultureInfo.InvariantCulture;
		num5 = Convert.ToSingle(value, invariantCulture);
		object obj7 = num5 & -2147483649L;
		if ((nint)obj7 != 2139095040)
		{
			object obj8 = num5 & -2147483649L;
			if ((nint)obj8 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000186B2DA00h\"");
				if (num5 == -1f / 0f)
				{
					num5 = -3.4028235E+38f;
				}
				goto IL_0665;
			}
		}
		goto IL_01f1;
		IL_0665:
		return num5;
	}

	private double ParseDouble(object value)
	{
		return Convert.ToDouble(value);
	}

	private string ParseString(object value)
	{
		return Convert.ToString(value, null);
	}

	private void ParseEnumArray<T>(List<T> target, bool allowDuplicate = false)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ r9 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		bool flag = allowDuplicate;
		object obj = default(object);
		while (true)
		{
			bool flag2 = _reader.Read();
			JsonToken tokenType = _reader.TokenType;
			if (tokenType != JsonToken.String)
			{
				JsonToken tokenType2 = _reader.TokenType;
				if (tokenType2 != JsonToken.Integer)
				{
					JsonToken tokenType3 = _reader.TokenType;
					if (tokenType3 == JsonToken.EndArray)
					{
						break;
					}
					continue;
				}
				object value = _reader.Value;
				int num = Convert.ToInt32(value);
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FD6F0");
				int num2 = num;
			}
			else
			{
				object value2 = _reader.Value;
				T val = ParseEnum<T>(value2);
			}
			if (!allowDuplicate)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FD860");
				bool flag3 = obj != null;
				flag = false;
				if (flag3)
				{
					continue;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FD8C0");
			flag = false;
		}
	}

	private void ParseUIntArray(List<uint> target)
	{
		while (true)
		{
			bool flag = _reader.Read();
			JsonToken tokenType = _reader.TokenType;
			if (tokenType != JsonToken.Integer)
			{
				JsonToken tokenType2 = _reader.TokenType;
				if (tokenType2 == JsonToken.EndArray)
				{
					break;
				}
			}
			else
			{
				object value = _reader.Value;
				uint item = ParseUInt(value);
				target.Add(item);
			}
		}
	}

	private void ParseObjectEnumInt<T>(Dictionary<T, int> target)
	{
		//IL_0092: Expected I4, but got O
		while (true)
		{
			bool flag = _reader.Read();
			JsonToken tokenType = _reader.TokenType;
			if (tokenType != JsonToken.PropertyName)
			{
				JsonToken tokenType2 = _reader.TokenType;
				if (tokenType2 == JsonToken.EndObject)
				{
					break;
				}
			}
			else
			{
				object value = _reader.Value;
				System.Int32Enum key = (System.Int32Enum)ParseEnum<T>(value);
				bool flag2 = _reader.Read();
				object value2 = _reader.Value;
				int value3 = ParseInt(value2);
				bool flag3 = ((Dictionary<System.Int32Enum, int>)(object)target).TryInsert(key, value3, System.Collections.Generic.InsertionBehavior.None);
			}
		}
	}

	private void ParseObjectEnumEnum<T1, T2>(Dictionary<T1, T2> target)
	{
		//IL_0092: Expected I4, but got O
		//IL_00c8: Expected I4, but got O
		while (true)
		{
			bool flag = _reader.Read();
			JsonToken tokenType = _reader.TokenType;
			if (tokenType != JsonToken.PropertyName)
			{
				JsonToken tokenType2 = _reader.TokenType;
				if (tokenType2 == JsonToken.EndObject)
				{
					break;
				}
			}
			else
			{
				object value = _reader.Value;
				System.Int32Enum key = (System.Int32Enum)ParseEnum<T1>(value);
				bool flag2 = _reader.Read();
				object value2 = _reader.Value;
				System.Int32Enum value3 = (System.Int32Enum)ParseEnum<T2>(value2);
				bool flag3 = ((Dictionary<System.Int32Enum, System.Int32Enum>)(object)target).TryInsert(key, value3, System.Collections.Generic.InsertionBehavior.None);
			}
		}
	}

	private unsafe void ParseObjectEnumEnumArray<T1, T2>(Dictionary<T1, List<T2>> target, bool allowDuplicate = false)
	{
		//IL_0092: Expected I4, but got O
		//IL_00ce: Expected O, but got Ref
		//IL_0151: Expected I4, but got O
		//IL_0167: Expected I4, but got O
		object obj3 = default(object);
		while (true)
		{
			bool flag = _reader.Read();
			JsonToken tokenType = _reader.TokenType;
			if (tokenType != JsonToken.PropertyName)
			{
				JsonToken tokenType2 = _reader.TokenType;
				if (tokenType2 == JsonToken.EndObject)
				{
					break;
				}
				continue;
			}
			object value = _reader.Value;
			System.Int32Enum key = (System.Int32Enum)ParseEnum<T1>(value);
			bool flag2 = _reader.Read();
			bool flag3 = ((Dictionary<System.Int32Enum, object>)(object)target).TryGetValue(key, out object value2);
			nint num = 0;
			object obj = (object)(&value2);
			if (!flag3)
			{
				object obj2 = new List<T2>();
				bool flag4 = ((Dictionary<System.Int32Enum, object>)(object)target).TryInsert(key, obj2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				num = 2;
				obj = obj2;
				value2 = obj2;
			}
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rdi_v4 (Il2CppMethodInfo)+38]");
			bool flag5 = (nint)0 != 0;
			bool flag6 = (byte)(int)obj != 0;
			if (!flag5)
			{
				flag6 = (byte)(int)obj != 0;
			}
			while (true)
			{
				bool flag7 = _reader.Read();
				JsonToken tokenType3 = _reader.TokenType;
				if (tokenType3 != JsonToken.String)
				{
					JsonToken tokenType4 = _reader.TokenType;
					if (tokenType4 != JsonToken.Integer)
					{
						JsonToken tokenType5 = _reader.TokenType;
						if (tokenType5 == JsonToken.EndArray)
						{
							break;
						}
						continue;
					}
					object value3 = _reader.Value;
					int num3 = Convert.ToInt32(value3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FD6F0");
					int num4 = num3;
				}
				else
				{
					object value4 = _reader.Value;
					T2 val = ParseEnum<T2>(value4);
				}
				if (!allowDuplicate)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FD860");
					bool flag8 = obj3 != null;
					flag6 = false;
					if (flag8)
					{
						continue;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FD8C0");
				flag6 = false;
			}
		}
	}

	private unsafe void ParseCharacterEggData()
	{
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected Ref, but got Unknown
		//IL_01fa: Expected I8, but got I4
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Expected Ref, but got Unknown
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Expected Ref, but got Unknown
		//IL_031b: Expected I8, but got I4
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Expected Ref, but got Unknown
		//IL_0403: Unknown result type (might be due to invalid IL or missing references)
		//IL_0408: Expected Ref, but got Unknown
		//IL_041f: Expected I8, but got I4
		//IL_0429: Unknown result type (might be due to invalid IL or missing references)
		//IL_042e: Expected Ref, but got Unknown
		//IL_051f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0524: Expected Ref, but got Unknown
		//IL_053b: Expected I8, but got I4
		//IL_0545: Unknown result type (might be due to invalid IL or missing references)
		//IL_054a: Expected Ref, but got Unknown
		object value = _reader.Value;
		CharacterType key = ParseEnum<CharacterType>(value);
		PlayerOptionsData pod = _pod;
		bool flag = ((Dictionary<System.Int32Enum, object>)(object)pod._003CCharacterEggInfo_003Ek__BackingField).TryGetValue((System.Int32Enum)key, out object _);
		bool flag2 = flag;
		Dictionary<string, float> dictionary = default(Dictionary<string, float>);
		if (!flag)
		{
			dictionary = new Dictionary<string, float>();
			PlayerOptionsData pod2 = _pod;
			bool flag3 = ((Dictionary<System.Int32Enum, object>)(object)pod2._003CCharacterEggInfo_003Ek__BackingField).TryInsert((System.Int32Enum)key, (object)dictionary, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			flag2 = flag;
		}
		while (true)
		{
			bool flag4 = _reader.Read();
			JsonToken tokenType = _reader.TokenType;
			if (tokenType != JsonToken.PropertyName)
			{
				JsonToken tokenType2 = _reader.TokenType;
				flag2 = tokenType2 != JsonToken.EndObject;
				if (!flag2)
				{
					break;
				}
				continue;
			}
			object value3 = _reader.Value;
			string text = ParseString(value3);
			object obj = "total";
			bool flag6;
			bool flag10;
			bool flag14;
			string key2;
			if ((object)text != "total")
			{
				bool flag5 = text == null;
				flag6 = flag2;
				if (!flag5)
				{
					bool flag7 = "total" == null;
					flag6 = flag2;
					if (!flag7)
					{
						int stringLength = text._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v455 @ rdx_v13+10]");
						flag6 = (nint)stringLength != 0;
						if (!flag6)
						{
							ref byte first = ref *(byte*)(text + 20);
							ulong length = (ulong)(text._stringLength + text._stringLength);
							bool flag8 = System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("total" + 20), length);
							flag6 = flag8;
							flag2 = flag8;
							if (flag8)
							{
								goto IL_061f;
							}
						}
					}
				}
				object value4 = _reader.Value;
				string text2 = ParseString(value4);
				object obj2 = "skip";
				if ((object)text2 == "skip")
				{
					goto IL_05b4;
				}
				bool flag9 = text2 == null;
				flag10 = flag6;
				if (!flag9)
				{
					bool flag11 = "skip" == null;
					flag10 = flag6;
					if (!flag11)
					{
						int stringLength2 = text2._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v551 @ rdx_v26+10]");
						flag10 = (nint)stringLength2 != 0;
						if (!flag10)
						{
							ref byte first2 = ref *(byte*)(text2 + 20);
							ulong length2 = (ulong)(text2._stringLength + text2._stringLength);
							bool flag12 = System.SpanHelpers.SequenceEqual(ref first2, ref *(byte*)("skip" + 20), length2);
							flag10 = flag12;
							flag6 = flag12;
							if (flag12)
							{
								goto IL_05b4;
							}
						}
					}
				}
				object obj3 = "reroll";
				if ((object)text2 == "reroll")
				{
					goto IL_059e;
				}
				bool flag13 = text2 == null;
				flag14 = flag10;
				if (!flag13)
				{
					bool flag15 = "reroll" == null;
					flag14 = flag10;
					if (!flag15)
					{
						int stringLength3 = text2._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v647 @ rdx_v37+10]");
						flag14 = (nint)stringLength3 != 0;
						if (!flag14)
						{
							ref byte first3 = ref *(byte*)(text2 + 20);
							ulong length3 = (ulong)(text2._stringLength + text2._stringLength);
							bool flag16 = System.SpanHelpers.SequenceEqual(ref first3, ref *(byte*)("reroll" + 20), length3);
							flag14 = flag16;
							flag10 = flag16;
							if (flag16)
							{
								goto IL_059e;
							}
						}
					}
				}
				object obj4 = "revival";
				if ((object)text2 == "revival")
				{
					goto IL_0588;
				}
				bool flag17 = text2 == null;
				key2 = text2;
				flag6 = flag14;
				if (!flag17)
				{
					bool flag18 = "revival" == null;
					key2 = text2;
					flag6 = flag14;
					if (!flag18)
					{
						int stringLength4 = text2._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ rdx_v40+10]");
						flag6 = (nint)stringLength4 != 0;
						key2 = text2;
						if (!flag6)
						{
							ref byte first4 = ref *(byte*)(text2 + 20);
							ulong length4 = (ulong)(text2._stringLength + text2._stringLength);
							bool flag19 = System.SpanHelpers.SequenceEqual(ref first4, ref *(byte*)("revival" + 20), length4);
							bool flag20 = !flag19;
							flag14 = flag6;
							key2 = text2;
							if (!flag20)
							{
								goto IL_0588;
							}
						}
					}
				}
				goto IL_05c2;
			}
			goto IL_061f;
			IL_05c2:
			bool flag21 = _reader.Read();
			object value5 = _reader.Value;
			float value6 = ParseFloat(value5);
			bool flag22 = ((Dictionary<object, float>)(object)dictionary).TryInsert((object)key2, value6, System.Collections.Generic.InsertionBehavior.None);
			flag2 = flag6;
			continue;
			IL_061f:
			bool flag23 = _reader.Read();
			PlayerOptionsData pod3 = _pod;
			object value7 = _reader.Value;
			float value8 = ParseFloat(value7);
			bool flag24 = ((Dictionary<System.Int32Enum, float>)(object)pod3._003CCharacterEggCount_003Ek__BackingField).TryInsert((System.Int32Enum)key, value8, System.Collections.Generic.InsertionBehavior.None);
			continue;
			IL_059e:
			key2 = "rerolls";
			flag6 = flag10;
			goto IL_05c2;
			IL_0588:
			key2 = "revivals";
			flag6 = flag14;
			goto IL_05c2;
			IL_05b4:
			key2 = "skips";
			goto IL_05c2;
		}
	}

	private unsafe void ParseCharacterStageData()
	{
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Expected Ref, but got Unknown
		//IL_02cd: Expected I8, but got I4
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Expected Ref, but got Unknown
		//IL_0437: Unknown result type (might be due to invalid IL or missing references)
		//IL_043c: Expected Ref, but got Unknown
		//IL_0453: Expected I8, but got I4
		//IL_045d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0462: Expected Ref, but got Unknown
		//IL_05bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c2: Expected Ref, but got Unknown
		//IL_05d9: Expected I8, but got I4
		//IL_05e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e8: Expected Ref, but got Unknown
		//IL_0743: Unknown result type (might be due to invalid IL or missing references)
		//IL_0748: Expected Ref, but got Unknown
		//IL_075f: Expected I8, but got I4
		//IL_0769: Unknown result type (might be due to invalid IL or missing references)
		//IL_076e: Expected Ref, but got Unknown
		//IL_08c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ce: Expected Ref, but got Unknown
		//IL_08e5: Expected I8, but got I4
		//IL_08ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f4: Expected Ref, but got Unknown
		//IL_0a4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a54: Expected Ref, but got Unknown
		//IL_0a6b: Expected I8, but got I4
		//IL_0a75: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a7a: Expected Ref, but got Unknown
		//IL_0bd5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bda: Expected Ref, but got Unknown
		//IL_0bf1: Expected I8, but got I4
		//IL_0bfb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c00: Expected Ref, but got Unknown
		object value = _reader.Value;
		CharacterType key = ParseEnum<CharacterType>(value);
		PlayerOptionsData pod = _pod;
		bool flag = ((Dictionary<System.Int32Enum, object>)(object)pod._003CCharacterStageData_003Ek__BackingField).TryGetValue((System.Int32Enum)key, out object _);
		System.Collections.Generic.InsertionBehavior insertionBehavior = System.Collections.Generic.InsertionBehavior.None;
		List<CharacterStageData> value3 = default(List<CharacterStageData>);
		if (!flag)
		{
			value3 = new List<CharacterStageData>();
			PlayerOptionsData pod2 = _pod;
			bool flag2 = ((Dictionary<System.Int32Enum, object>)(object)pod2._003CCharacterStageData_003Ek__BackingField).TryInsert((System.Int32Enum)key, (object)value3, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			insertionBehavior = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
		}
		CharacterStageData characterStageData = new CharacterStageData();
		CharacterStageData characterStageData2 = characterStageData;
		while (true)
		{
			JsonTextReader reader = _reader;
			bool flag3 = _reader.Read();
			JsonToken tokenType = _reader.TokenType;
			if (tokenType == JsonToken.StartObject)
			{
				CharacterStageData characterStageData3 = new CharacterStageData();
				characterStageData2 = characterStageData3;
			}
			JsonToken tokenType2 = _reader.TokenType;
			if (tokenType2 != JsonToken.PropertyName)
			{
				JsonToken tokenType3 = _reader.TokenType;
				if (tokenType3 == JsonToken.EndObject)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97B10");
					characterStageData2 = null;
				}
				JsonToken tokenType4 = _reader.TokenType;
				if (tokenType4 == JsonToken.EndArray)
				{
					break;
				}
				continue;
			}
			object value4 = _reader.Value;
			string text = ParseString(value4);
			object obj = "complete";
			if ((object)text == "complete")
			{
				goto IL_031c;
			}
			bool flag4 = text == null;
			System.Collections.Generic.InsertionBehavior insertionBehavior2 = insertionBehavior;
			if (!flag4)
			{
				bool flag5 = "complete" == null;
				insertionBehavior2 = insertionBehavior;
				if (!flag5)
				{
					int stringLength = text._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v902 @ rdx_v16+10]");
					bool flag6 = (nint)stringLength != 0;
					insertionBehavior2 = insertionBehavior;
					if (!flag6)
					{
						ref byte first = ref *(byte*)(text + 20);
						ulong length = (ulong)(text._stringLength + text._stringLength);
						bool flag7 = System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("complete" + 20), length);
						bool flag8 = !flag7;
						insertionBehavior = System.Collections.Generic.InsertionBehavior.None;
						insertionBehavior2 = System.Collections.Generic.InsertionBehavior.None;
						if (!flag8)
						{
							goto IL_031c;
						}
					}
				}
			}
			goto IL_036c;
			IL_0678:
			object value5 = _reader.Value;
			string text2 = ParseString(value5);
			object obj2 = "inverse";
			if ((object)text2 == "inverse")
			{
				goto IL_07ae;
			}
			bool flag9 = text2 == null;
			System.Collections.Generic.InsertionBehavior insertionBehavior4;
			System.Collections.Generic.InsertionBehavior insertionBehavior3 = insertionBehavior4;
			if (!flag9)
			{
				bool flag10 = "inverse" == null;
				insertionBehavior3 = insertionBehavior4;
				if (!flag10)
				{
					int stringLength2 = text2._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1190 @ rdx_v31+10]");
					bool flag11 = (nint)stringLength2 != 0;
					insertionBehavior3 = insertionBehavior4;
					if (!flag11)
					{
						ref byte first2 = ref *(byte*)(text2 + 20);
						ulong length2 = (ulong)(text2._stringLength + text2._stringLength);
						bool flag12 = System.SpanHelpers.SequenceEqual(ref first2, ref *(byte*)("inverse" + 20), length2);
						bool flag13 = !flag12;
						insertionBehavior4 = System.Collections.Generic.InsertionBehavior.None;
						insertionBehavior3 = System.Collections.Generic.InsertionBehavior.None;
						if (!flag13)
						{
							goto IL_07ae;
						}
					}
				}
			}
			goto IL_07fe;
			IL_0628:
			bool flag14 = _reader.Read();
			object value6 = _reader.Value;
			bool flag15 = ParseBool(value6);
			characterStageData2._003Churry_003Ek__BackingField = flag15;
			System.Collections.Generic.InsertionBehavior insertionBehavior5;
			insertionBehavior4 = insertionBehavior5;
			goto IL_0678;
			IL_0934:
			bool flag16 = _reader.Read();
			object value7 = _reader.Value;
			int num = ParseInt(value7);
			characterStageData2._003CsurvivedMinutes_003Ek__BackingField = num;
			System.Collections.Generic.InsertionBehavior insertionBehavior6 = insertionBehavior3;
			goto IL_0984;
			IL_04f2:
			object value8 = _reader.Value;
			string text3 = ParseString(value8);
			object obj3 = "hurry";
			if ((object)text3 == "hurry")
			{
				goto IL_0628;
			}
			bool flag17 = text3 == null;
			insertionBehavior4 = insertionBehavior5;
			if (!flag17)
			{
				bool flag18 = "hurry" == null;
				insertionBehavior4 = insertionBehavior5;
				if (!flag18)
				{
					int stringLength3 = text3._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1096 @ rdx_v26+10]");
					bool flag19 = (nint)stringLength3 != 0;
					insertionBehavior4 = insertionBehavior5;
					if (!flag19)
					{
						ref byte first3 = ref *(byte*)(text3 + 20);
						ulong length3 = (ulong)(text3._stringLength + text3._stringLength);
						bool flag20 = System.SpanHelpers.SequenceEqual(ref first3, ref *(byte*)("hurry" + 20), length3);
						bool flag21 = !flag20;
						insertionBehavior5 = System.Collections.Generic.InsertionBehavior.None;
						insertionBehavior4 = System.Collections.Generic.InsertionBehavior.None;
						if (!flag21)
						{
							goto IL_0628;
						}
					}
				}
			}
			goto IL_0678;
			IL_04a2:
			bool flag22 = _reader.Read();
			object value9 = _reader.Value;
			bool flag23 = ParseBool(value9);
			characterStageData2._003Chyper_003Ek__BackingField = flag23;
			insertionBehavior5 = insertionBehavior2;
			goto IL_04f2;
			IL_0984:
			object value10 = _reader.Value;
			string text4 = ParseString(value10);
			object obj4 = "startedRun";
			if ((object)text4 == "startedRun")
			{
				goto IL_0aba;
			}
			bool flag24 = text4 == null;
			System.Collections.Generic.InsertionBehavior insertionBehavior7 = insertionBehavior6;
			if (!flag24)
			{
				bool flag25 = "startedRun" == null;
				insertionBehavior7 = insertionBehavior6;
				if (!flag25)
				{
					int stringLength4 = text4._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1378 @ rdx_v41+10]");
					bool flag26 = (nint)stringLength4 != 0;
					insertionBehavior7 = insertionBehavior6;
					if (!flag26)
					{
						ref byte first4 = ref *(byte*)(text4 + 20);
						ulong length4 = (ulong)(text4._stringLength + text4._stringLength);
						bool flag27 = System.SpanHelpers.SequenceEqual(ref first4, ref *(byte*)("startedRun" + 20), length4);
						bool flag28 = !flag27;
						insertionBehavior6 = System.Collections.Generic.InsertionBehavior.None;
						insertionBehavior7 = System.Collections.Generic.InsertionBehavior.None;
						if (!flag28)
						{
							goto IL_0aba;
						}
					}
				}
			}
			goto IL_0b0a;
			IL_0aba:
			bool flag29 = _reader.Read();
			object value11 = _reader.Value;
			int num2 = ParseInt(value11);
			characterStageData2._003CstartedRun_003Ek__BackingField = num2;
			insertionBehavior7 = insertionBehavior6;
			goto IL_0b0a;
			IL_0b0a:
			object value12 = _reader.Value;
			string text5 = ParseString(value12);
			object obj5 = "type";
			if ((object)text5 != "type")
			{
				bool flag30 = text5 == null;
				insertionBehavior = insertionBehavior7;
				if (flag30)
				{
					continue;
				}
				bool flag31 = "type" == null;
				insertionBehavior = insertionBehavior7;
				if (flag31)
				{
					continue;
				}
				int stringLength5 = text5._stringLength;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v746 @ rdx_v46+10]");
				bool flag32 = (nint)stringLength5 != 0;
				insertionBehavior = insertionBehavior7;
				if (flag32)
				{
					continue;
				}
				ref byte first5 = ref *(byte*)(text5 + 20);
				ulong length5 = (ulong)(text5._stringLength + text5._stringLength);
				bool flag33 = System.SpanHelpers.SequenceEqual(ref first5, ref *(byte*)("type" + 20), length5);
				bool flag34 = !flag33;
				insertionBehavior7 = System.Collections.Generic.InsertionBehavior.None;
				insertionBehavior = System.Collections.Generic.InsertionBehavior.None;
				if (flag34)
				{
					continue;
				}
			}
			bool flag35 = _reader.Read();
			object value13 = _reader.Value;
			StageType stageType = ParseEnum<StageType>(value13);
			characterStageData2._003Ctype_003Ek__BackingField = stageType;
			insertionBehavior = insertionBehavior7;
			continue;
			IL_07ae:
			bool flag36 = _reader.Read();
			object value14 = _reader.Value;
			bool flag37 = ParseBool(value14);
			characterStageData2._003Cinverse_003Ek__BackingField = flag37;
			insertionBehavior3 = insertionBehavior4;
			goto IL_07fe;
			IL_07fe:
			object value15 = _reader.Value;
			string text6 = ParseString(value15);
			object obj6 = "survivedMinutes";
			if ((object)text6 == "survivedMinutes")
			{
				goto IL_0934;
			}
			bool flag38 = text6 == null;
			insertionBehavior6 = insertionBehavior3;
			if (!flag38)
			{
				bool flag39 = "survivedMinutes" == null;
				insertionBehavior6 = insertionBehavior3;
				if (!flag39)
				{
					int stringLength6 = text6._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1284 @ rdx_v36+10]");
					bool flag40 = (nint)stringLength6 != 0;
					insertionBehavior6 = insertionBehavior3;
					if (!flag40)
					{
						ref byte first6 = ref *(byte*)(text6 + 20);
						ulong length6 = (ulong)(text6._stringLength + text6._stringLength);
						bool flag41 = System.SpanHelpers.SequenceEqual(ref first6, ref *(byte*)("survivedMinutes" + 20), length6);
						bool flag42 = !flag41;
						insertionBehavior3 = System.Collections.Generic.InsertionBehavior.None;
						insertionBehavior6 = System.Collections.Generic.InsertionBehavior.None;
						if (!flag42)
						{
							goto IL_0934;
						}
					}
				}
			}
			goto IL_0984;
			IL_031c:
			bool flag43 = _reader.Read();
			object value16 = _reader.Value;
			int num3 = ParseInt(value16);
			characterStageData2._003Ccomplete_003Ek__BackingField = num3;
			insertionBehavior2 = insertionBehavior;
			goto IL_036c;
			IL_036c:
			object value17 = _reader.Value;
			string text7 = ParseString(value17);
			object obj7 = "hyper";
			if ((object)text7 == "hyper")
			{
				goto IL_04a2;
			}
			bool flag44 = text7 == null;
			insertionBehavior5 = insertionBehavior2;
			if (!flag44)
			{
				bool flag45 = "hyper" == null;
				insertionBehavior5 = insertionBehavior2;
				if (!flag45)
				{
					int stringLength7 = text7._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1002 @ rdx_v21+10]");
					bool flag46 = (nint)stringLength7 != 0;
					insertionBehavior5 = insertionBehavior2;
					if (!flag46)
					{
						ref byte first7 = ref *(byte*)(text7 + 20);
						ulong length7 = (ulong)(text7._stringLength + text7._stringLength);
						bool flag47 = System.SpanHelpers.SequenceEqual(ref first7, ref *(byte*)("hyper" + 20), length7);
						bool flag48 = !flag47;
						insertionBehavior2 = System.Collections.Generic.InsertionBehavior.None;
						insertionBehavior5 = System.Collections.Generic.InsertionBehavior.None;
						if (!flag48)
						{
							goto IL_04a2;
						}
					}
				}
			}
			goto IL_04f2;
		}
		PlayerOptionsData pod3 = _pod;
		bool flag49 = ((Dictionary<System.Int32Enum, object>)(object)pod3._003CCharacterStageData_003Ek__BackingField).TryInsert((System.Int32Enum)key, (object)value3, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
	}

	private void saveDate()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		string text = ParseString(value);
		pod._003CsaveDate_003Ek__BackingField = text;
	}

	private void Platform()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		string text = ParseString(value);
		pod._003CPlatform_003Ek__BackingField = text;
	}

	private void SaveSyncPlatformAchievements()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CSaveSyncPlatformAchievements_003Ek__BackingField = flag;
	}

	private void SaveOriginalPlatform()
	{
		//IL_0035: Expected O, but got I4
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		SystemPlatformTypes systemPlatformTypes = ParseEnum<SystemPlatformTypes>(value);
		pod._003CSaveOriginalPlatform_003Ek__BackingField = (SystemPlatformTypes?)(object)1;
	}

	private void SaveTouchedPlatforms()
	{
		PlayerOptionsData pod = _pod;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97B70");
	}

	private void itemInCollection()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		int num = ParseInt(value);
		pod._003CitemInCollection_003Ek__BackingField = num;
	}

	private void itemInUnlocks()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		int num = ParseInt(value);
		pod._003CitemInUnlocks_003Ek__BackingField = num;
	}

	private void itemInSecrets()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		int num = ParseInt(value);
		pod._003CitemInSecrets_003Ek__BackingField = num;
	}

	private void SelectedCharacter()
	{
		object value = _reader.Value;
		CharacterType selectedCharacter = ParseEnum<CharacterType>(value);
		_pod.SelectedCharacter = selectedCharacter;
	}

	private void SelectedStage()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		StageType stageType = ParseEnum<StageType>(value);
		pod._003CSelectedStage_003Ek__BackingField = stageType;
	}

	private void SelectedHyper()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CSelectedHyper_003Ek__BackingField = flag;
	}

	private void SelectedHurry()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CSelectedHurry_003Ek__BackingField = flag;
	}

	private void AcceptedEULA()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CAcceptedEULA_003Ek__BackingField = flag;
	}

	private void SelectedMazzo()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CSelectedMazzo_003Ek__BackingField = flag;
	}

	private void SelectedLimitBreak()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CSelectedLimitBreak_003Ek__BackingField = flag;
	}

	private void SelectedInverse()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CSelectedInverse_003Ek__BackingField = flag;
	}

	private void SelectedReapers()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CSelectedReapers_003Ek__BackingField = flag;
	}

	private void SelectedGoldenEggs()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CSelectedGoldenEggs_003Ek__BackingField = flag;
	}

	private void SelectedSharePassives()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CSelectedSharePassives_003Ek__BackingField = flag;
	}

	private void SelectedArcana()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		int num = ParseInt(value);
		pod._003CSelectedArcana_003Ek__BackingField = num;
	}

	private void SelectedRandomEvents()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CSelectedRandomEvents_003Ek__BackingField = flag;
	}

	private void SelectedRandomLevels()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CSelectedRandomLevels_003Ek__BackingField = flag;
	}

	private void SelectedBGMSave()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CSelectedBGMSave_003Ek__BackingField = flag;
	}

	private void SelectedBGM()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		BgmType bgmType = ParseEnum<BgmType>(value);
		pod._003CSelectedBGM_003Ek__BackingField = bgmType;
	}

	private void SelectedBGMMod()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		BgmModType bgmModType = ParseEnum<BgmModType>(value);
		pod._003CSelectedBGMMod_003Ek__BackingField = bgmModType;
	}

	private void SelectedMaxWeapons()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		int num = ParseInt(value);
		pod._003CSelectedMaxWeapons_003Ek__BackingField = num;
	}

	private void Fullscreen()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CFullscreen_003Ek__BackingField = flag;
	}

	private void Version()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		int num = ParseInt(value);
		pod._003CVersion_003Ek__BackingField = num;
	}

	private void Coins()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		float num = ParseFloat(value);
		pod._003CCoins_003Ek__BackingField = num;
	}

	private void LifetimeCoins()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		float num = ParseFloat(value);
		pod._003CLifetimeCoins_003Ek__BackingField = num;
	}

	private void TotalCoins()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		float num = ParseFloat(value);
		pod._003CTotalCoins_003Ek__BackingField = num;
	}

	private void BeginnersLuck()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		int num = ParseInt(value);
		pod._003CBeginnersLuck_003Ek__BackingField = num;
	}

	private void RunFever()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		float num = ParseFloat(value);
		pod._003CRunFever_003Ek__BackingField = num;
	}

	private void LifetimeSurvived()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		float num = ParseFloat(value);
		pod._003CLifetimeSurvived_003Ek__BackingField = num;
	}

	private void LifetimeHeal()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		float num = ParseFloat(value);
		pod._003CLifetimeHeal_003Ek__BackingField = num;
	}

	private void TrainHazardEnemiesHit()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		float num = ParseFloat(value);
		pod._003CTrainHazardEnemiesHit_003Ek__BackingField = num;
	}

	private void TopLapsCarlo()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		int num = ParseInt(value);
		pod._003CTopLapsCarlo_003Ek__BackingField = num;
	}

	private void TotalLapsCarlo()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		int num = ParseInt(value);
		pod._003CTotalLapsCarlo_003Ek__BackingField = num;
	}

	private void TopLapsHighway()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		int num = ParseInt(value);
		pod._003CTopLapsHighway_003Ek__BackingField = num;
	}

	private void TotalLapsHighway()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		int num = ParseInt(value);
		pod._003CTotalLapsHighway_003Ek__BackingField = num;
	}

	private void OwO()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		float num = ParseFloat(value);
		pod._003COwO_003Ek__BackingField = num;
	}

	private void CompletedHurries()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		int num = ParseInt(value);
		pod._003CCompletedHurries_003Ek__BackingField = num;
	}

	private void ReducePhysics()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CReducePhysics_003Ek__BackingField = flag;
	}

	private void ClassicMusic()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CClassicMusic_003Ek__BackingField = flag;
	}

	private void VisuallyInvertStages()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CVisuallyInvertStages_003Ek__BackingField = flag;
	}

	private void HideProgress()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CHideProgress_003Ek__BackingField = flag;
	}

	private void SoundsEnabled()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CSoundsEnabled_003Ek__BackingField = flag;
	}

	private void MusicEnabled()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CMusicEnabled_003Ek__BackingField = flag;
	}

	private void SoundsVolume()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		float num = ParseFloat(value);
		pod._003CSoundsVolume_003Ek__BackingField = num;
	}

	private void MusicVolume()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		float num = ParseFloat(value);
		pod._003CMusicVolume_003Ek__BackingField = num;
	}

	private void FlashingVFXEnabled()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CFlashingVFXEnabled_003Ek__BackingField = flag;
	}

	private void JoystickVisible()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CJoystickVisible_003Ek__BackingField = flag;
	}

	private void SelectedJoystickType()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		VisibleJoystickType visibleJoystickType = ParseEnum<VisibleJoystickType>(value);
		pod._003CSelectedJoystickType_003Ek__BackingField = visibleJoystickType;
	}

	private void DamageNumbersEnabled()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CDamageNumbersEnabled_003Ek__BackingField = flag;
	}

	private void GlimmerCarouselEnabled()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CGlimmerCarouselEnabled_003Ek__BackingField = flag;
	}

	private void StreamSafeEnabled()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CStreamSafeEnabled_003Ek__BackingField = flag;
	}

	private void hideXPBar()
	{
		PlayerOptionsData pod = _pod;
		pod._003ChideXPBar_003Ek__BackingField = false;
	}

	private void CheatCodeUsed()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CCheatCodeUsed_003Ek__BackingField = flag;
	}

	private void HasKilledTheFinalBoss()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CHasKilledTheFinalBoss_003Ek__BackingField = flag;
	}

	private void HasSeenFinalFireworks()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CHasSeenFinalFireworks_003Ek__BackingField = flag;
	}

	private void Language()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		string text = ParseString(value);
		pod._003CLanguage_003Ek__BackingField = text;
	}

	private void ShowQuitDescription()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CShowQuitDescription_003Ek__BackingField = flag;
	}

	private void HideCompletedAchievements()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CHideCompletedAchievements_003Ek__BackingField = flag;
	}

	private void PlayedRNJ()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		int num = ParseInt(value);
		pod._003CPlayedRNJ_003Ek__BackingField = num;
	}

	private void ShowPickups()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CShowPickups_003Ek__BackingField = flag;
	}

	private void ShowSmallMapIcons()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CShowSmallMapIcons_003Ek__BackingField = flag;
	}

	private void LongestFever()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		float num = ParseFloat(value);
		pod._003CLongestFever_003Ek__BackingField = num;
	}

	private void HighestFever()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		float num = ParseFloat(value);
		pod._003CHighestFever_003Ek__BackingField = num;
	}

	private void HasUsedMirror()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CHasUsedMirror_003Ek__BackingField = flag;
	}

	private void HasUsedTrumpet()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CHasUsedTrumpet_003Ek__BackingField = flag;
	}

	private void BoughtCharacters()
	{
		PlayerOptionsData pod = _pod;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97D40");
	}

	private void BoughtPowerups()
	{
		//IL_02cc: Expected O, but got I
		//IL_008a: Expected O, but got I
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		//IL_0110: Expected O, but got I
		//IL_0137: Expected I, but got O
		//IL_0147: Expected O, but got I
		//IL_01f7: Expected O, but got I4
		List<PowerUpType> list = new List<PowerUpType>();
		List<PowerUpType> list2 = new List<PowerUpType>();
		list2._002Ector();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97F10");
		IEnumerable<PowerUpType> enumerable = null;
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		object obj8 = default(object);
		nint num2 = default(nint);
		object obj9 = default(object);
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ stack_-48_v3+1C]");
				if (obj2 != null)
				{
					break;
				}
				object obj3 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ stack_-48_v3+18]");
				if ((nint)obj3 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ stack_-48_v3+10]");
				object obj5 = 0;
				object obj6 = obj4 + 1;
				_003C_003Ec__DisplayClass95_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass95_0();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v456 @ rax_v28+20+v252 @ stack_-40_v2*4]");
				CS_0024_003C_003E8__locals3.powerUp = PowerUpType.POWER;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUpType>)+18]");
				bool flag = (nint)0 == 0;
				object obj7 = obj8;
				nint num = num2;
				nint num3 = 0;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUpType>)+18]");
					obj7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
					bool flag2 = (nint)obj9 != -1;
					num = 0;
					num3 = unchecked((nint)null);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUpType>)+18]");
					obj8 = 0;
					num2 = 0;
					obj4 = obj6;
					if (flag2)
					{
						continue;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A98130");
				PlayerOptionsData pod = _pod;
				PowerUpLevel powerUpLevel = new PowerUpLevel();
				powerUpLevel.PowerUp = CS_0024_003C_003E8__locals3.powerUp;
				Func<PowerUpType, bool> predicate = delegate(PowerUpType c)
				{
					//IL_000f: Expected O, but got I4
					object obj10 = c - CS_0024_003C_003E8__locals3.powerUp;
					return obj10 == null;
				};
				int level = Enumerable.Count((IEnumerable<System.Int32Enum>)list2, (Func<System.Int32Enum, bool>)(object)predicate);
				powerUpLevel.Level = level;
				int num4 = Enumerable.Count((IEnumerable<PowerUpType>)pod._003CBoughtPowerups_003Ek__BackingField, (Func<PowerUpType, bool>)(object)powerUpLevel);
				obj8 = 0;
				num2 = num;
				obj4 = obj6;
				enumerable = (IEnumerable<PowerUpType>)pod._003CBoughtPowerups_003Ek__BackingField;
				continue;
			}
			throw new NullReferenceException();
		}
		bool flag3 = obj == null;
		enumerable = (IEnumerable<PowerUpType>)0;
		if (!flag3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ stack_-48_v3+1C]");
			if (obj2 == null)
			{
				return;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			enumerable = null;
		}
		throw new NullReferenceException();
	}

	private void CollectedWeapons()
	{
		PlayerOptionsData pod = _pod;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A981F0");
	}

	private void UnlockedWeapons()
	{
		PlayerOptionsData pod = _pod;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A981F0");
	}

	private void UnlockedCharacters()
	{
		PlayerOptionsData pod = _pod;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97D40");
	}

	private void OpenedCoffins()
	{
		PlayerOptionsData pod = _pod;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97D40");
	}

	private void CollectedItems()
	{
		PlayerOptionsData pod = _pod;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A983C0");
	}

	private void Achievements()
	{
		PlayerOptionsData pod = _pod;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A98590");
	}

	private void Secrets()
	{
		PlayerOptionsData pod = _pod;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A98760");
	}

	private void UnlockedStages()
	{
		PlayerOptionsData pod = _pod;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A98930");
	}

	private void UnlockedHypers()
	{
		PlayerOptionsData pod = _pod;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A98930");
	}

	private void UnlockedPowerUpRanks()
	{
		PlayerOptionsData pod = _pod;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97F10");
	}

	private void DisabledPowerups()
	{
		//IL_0072: Expected O, but got I
		//IL_00cc: Expected O, but got I
		//IL_051c: Expected O, but got I
		//IL_0136: Expected O, but got I
		//IL_0550: Expected O, but got I
		//IL_01a0: Expected O, but got I
		//IL_0578: Expected O, but got I
		//IL_020a: Expected O, but got I
		//IL_05a0: Expected O, but got I
		//IL_0274: Expected O, but got I
		//IL_05c8: Expected O, but got I
		//IL_02de: Expected O, but got I
		//IL_05f0: Expected O, but got I
		//IL_0348: Expected O, but got I
		//IL_03bb: Expected O, but got I
		//IL_04bd: Expected O, but got I4
		//IL_03c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ce: Expected O, but got Unknown
		PlayerOptionsData pod = _pod;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97F10");
		PlayerOptionsData pod2 = _pod;
		if (pod2._003CDisabledPowerups_003Ek__BackingField == null)
		{
			return;
		}
		List<PowerUpType> list = new List<PowerUpType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUpType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUpType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUpType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rcx_v7+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)20);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUpType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 20;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUpType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUpType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUpType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rcx_v10+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)21);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUpType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 21;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUpType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUpType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUpType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rcx_v12+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)22);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUpType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 22;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUpType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUpType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUpType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rcx_v14+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)24);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUpType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 24;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUpType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUpType>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUpType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rcx_v16+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)26);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUpType>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 26;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUpType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUpType>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUpType>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v18+18]");
		if (num6 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)28);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUpType>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 28;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUpType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUpType>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUpType>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rcx_v20+18]");
		if (num7 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)29);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUpType>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 29;
		}
		object obj16 = default(object);
		object obj17 = default(object);
		object obj18 = default(object);
		object obj22 = default(object);
		while (true)
		{
			object obj15 = obj16;
			while (true)
			{
				if (obj17 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ stack_-28_v5+1C]");
					if (obj18 == null)
					{
						object obj19 = obj15;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ stack_-28_v5+18]");
						if ((nint)obj19 < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ stack_-28_v5+10]");
							object obj20 = 0;
							obj15++;
							PlayerOptionsData pod3 = _pod;
							List<PowerUpType> list2 = pod3._003CDisabledPowerups_003Ek__BackingField;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v772 @ r10_v15 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUpType>)+18]");
							if ((nint)0 != 0)
							{
								break;
							}
							continue;
						}
					}
					if (obj17 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ stack_-28_v5+1C]");
						if (obj18 == null)
						{
							return;
						}
						System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
						object obj21 = 0;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			bool flag = (nint)obj22 == -1;
			obj16 = obj15;
			if (!flag)
			{
				PlayerOptionsData pod4 = _pod;
				List<PowerUpType> list3 = pod4._003CDisabledPowerups_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v40+20+v339 @ rdx_v24*4]");
				bool flag2 = ((List<System.Int32Enum>)(object)list3).Remove((System.Int32Enum)0);
				obj16 = obj15;
			}
		}
	}

	private void UnlockedArcanas()
	{
		while (true)
		{
			bool flag = _reader.Read();
			JsonToken tokenType = _reader.TokenType;
			if (tokenType != JsonToken.Integer)
			{
				JsonToken tokenType2 = _reader.TokenType;
				if (tokenType2 == JsonToken.EndArray)
				{
					break;
				}
			}
			else
			{
				object value = _reader.Value;
				int num = Convert.ToInt32(value);
				PlayerOptionsData pod = _pod;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97710");
			}
		}
		PlayerOptionsData pod2 = _pod;
		IEnumerable<ArcanaType> enumerable = Enumerable.Distinct(pod2._003CUnlockedArcanas_003Ek__BackingField);
		if (enumerable != null)
		{
			List<System.Int32Enum> list = new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)enumerable);
			pod2._003CUnlockedArcanas_003Ek__BackingField = (List<ArcanaType>)(object)list;
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	private void KillCount()
	{
		PlayerOptionsData pod = _pod;
		ParseObjectEnumInt(pod._003CKillCount_003Ek__BackingField);
	}

	private void PickupCount()
	{
		PlayerOptionsData pod = _pod;
		ParseObjectEnumInt(pod._003CPickupCount_003Ek__BackingField);
	}

	private void DestroyedCount()
	{
		PlayerOptionsData pod = _pod;
		ParseObjectEnumInt(pod._003CDestroyedCount_003Ek__BackingField);
	}

	private void StageCompletionLog()
	{
		PlayerOptionsData pod = _pod;
		ParseObjectEnumEnumArray(pod._003CStageCompletionLog_003Ek__BackingField);
	}

	private void CharacterStageData()
	{
		while (true)
		{
			bool flag = _reader.Read();
			JsonToken tokenType = _reader.TokenType;
			if (tokenType != JsonToken.PropertyName)
			{
				JsonToken tokenType2 = _reader.TokenType;
				if (tokenType2 == JsonToken.EndObject)
				{
					return;
				}
				continue;
			}
			Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(CharacterType));
			object value = _reader.Value;
			string value2 = ParseString(value);
			if ((object)typeFromHandle == null)
			{
				break;
			}
			if (typeFromHandle.IsEnumDefined(value2))
			{
				ParseCharacterStageData();
			}
		}
		ArgumentNullException ex = new ArgumentNullException("enumType");
		ex._002Ector("enumType");
		throw ex;
	}

	private void CharacterEnemiesKilled()
	{
		PlayerOptionsData pod = _pod;
		ParseObjectEnumInt(pod._003CCharacterEnemiesKilled_003Ek__BackingField);
	}

	private void CharacterSurvivedMinutes()
	{
		PlayerOptionsData pod = _pod;
		ParseObjectEnumInt(pod._003CCharacterSurvivedMinutes_003Ek__BackingField);
	}

	private void MusicSelectionPerStage()
	{
	}

	private void checksum()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		string text = ParseString(value);
		pod._003Cchecksum_003Ek__BackingField = text;
	}

	private unsafe void EggData()
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Expected Ref, but got Unknown
		//IL_019a: Expected I8, but got I4
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Expected Ref, but got Unknown
		//IL_01c7: Expected O, but got I4
		//IL_01d8: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A28F4]");
		bool flag = (nint)0 != 0;
		if (!flag)
		{
			_ = 1;
		}
		object obj3 = default(object);
		while (true)
		{
			bool flag2 = _reader.Read();
			JsonToken tokenType = _reader.TokenType;
			if (tokenType != JsonToken.PropertyName)
			{
				JsonToken tokenType2 = _reader.TokenType;
				flag = tokenType2 != JsonToken.EndObject;
				if (!flag)
				{
					break;
				}
				continue;
			}
			object value = _reader.Value;
			string text = ParseString(value);
			object obj = "total";
			if ((object)text != "total")
			{
				bool flag3 = text == null;
				object obj2 = obj3;
				bool flag4 = flag;
				if (!flag3)
				{
					bool flag5 = "total" == null;
					obj2 = obj3;
					flag4 = flag;
					if (!flag5)
					{
						int stringLength = text._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rdx_v9+10]");
						flag4 = (nint)stringLength != 0;
						obj2 = obj3;
						if (!flag4)
						{
							ref byte first = ref *(byte*)(text + 20);
							ulong length = (ulong)(text._stringLength + text._stringLength);
							bool flag6 = System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("total" + 20), length);
							obj2 = 0;
							flag4 = flag6;
							obj3 = 0;
							flag = flag6;
							if (flag6)
							{
								goto IL_0209;
							}
						}
					}
				}
				ParseCharacterEggData();
				obj3 = obj2;
				flag = flag4;
				continue;
			}
			goto IL_0209;
			IL_0209:
			bool flag7 = _reader.Read();
			PlayerOptionsData pod = _pod;
			object value2 = _reader.Value;
			float num = ParseFloat(value2);
			pod._003CTotalEggCount_003Ek__BackingField = num;
		}
	}

	private void Didit()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CDidit_003Ek__BackingField = flag;
	}

	private void Seals()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		int num = ParseInt(value);
		pod._003CSeals_003Ek__BackingField = num;
	}

	private void SealedItems()
	{
		PlayerOptionsData pod = _pod;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A983C0");
	}

	private void SealedWeapons()
	{
		PlayerOptionsData pod = _pod;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A981F0");
	}

	private void UnlockedSkins()
	{
		PlayerOptionsData pod = _pod;
		ParseObjectEnumEnumArray(pod._003CUnlockedSkins_003Ek__BackingField);
	}

	private void UnlockedSkinsV2()
	{
		PlayerOptionsData pod = _pod;
		ParseObjectEnumEnumArray(pod._003CUnlockedSkinsV2_003Ek__BackingField);
	}

	private void SelectedSkins()
	{
		PlayerOptionsData pod = _pod;
		ParseObjectEnumInt(pod._003CSelectedSkins_003Ek__BackingField);
	}

	private void SelectedSkinsV2()
	{
		PlayerOptionsData pod = _pod;
		ParseObjectEnumEnum(pod._003CSelectedSkinsV2_003Ek__BackingField);
	}

	private void HideAdsButtons()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CEnableBonusAdsMechanics_003Ek__BackingField = flag;
	}

	private void ScreenShakeEnabled()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CScreenShakeEnabled_003Ek__BackingField = flag;
	}

	private void ControllerVibrationEnabled()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CControllerVibrationEnabled_003Ek__BackingField = flag;
	}

	private void AssignControllerToPlayer1()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CAssignControllerToPlayer1_003Ek__BackingField = flag;
	}

	private void ShowPlayerIndicators()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CShowPlayerIndicators_003Ek__BackingField = flag;
	}

	private void PermanentCoopOutlines()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CPermanentCoopOutlines_003Ek__BackingField = flag;
	}

	private void TintUISelection()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CTintUISelection_003Ek__BackingField = flag;
	}

	private void PlayerColours()
	{
		List<uint> list = new List<uint>();
		while (true)
		{
			bool flag = _reader.Read();
			JsonToken tokenType = _reader.TokenType;
			if (tokenType != JsonToken.Integer)
			{
				JsonToken tokenType2 = _reader.TokenType;
				if (tokenType2 == JsonToken.EndArray)
				{
					break;
				}
			}
			else
			{
				object value = _reader.Value;
				uint item = ParseUInt(value);
				list.Add(item);
			}
		}
		if (list != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			if ((nint)0 == 4)
			{
				PlayerOptionsData pod = _pod;
				uint[] array = list.ToArray();
				pod._003CPlayerColours_003Ek__BackingField = array;
			}
		}
	}

	private void SequentialChestMode()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CSequentialChestMode_003Ek__BackingField = flag;
	}

	private void DisableMovingBackground()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CDisableMovingBackground_003Ek__BackingField = flag;
	}

	private void DisableBlood()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CDisableBlood_003Ek__BackingField = flag;
	}

	private void BorderType()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		BorderType borderType = ParseEnum<BorderType>(value);
		pod._003CBorderType_003Ek__BackingField = borderType;
	}

	private void PixelFont()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CPixelFont_003Ek__BackingField = flag;
	}

	private void DisplayDefangedEnemies()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CDisplayDefangedEnemies_003Ek__BackingField = flag;
	}

	private void StageLighting()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CStageLighting_003Ek__BackingField = flag;
	}

	private void SelectedAdventureType()
	{
		//IL_0035: Expected O, but got I4
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		AdventureType adventureType = ParseEnum<AdventureType>(value);
		pod._003CSelectedAdventureType_003Ek__BackingField = (AdventureType?)(object)1;
	}

	private void AdventureProgress()
	{
		PlayerOptionsData pod = _pod;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A98B00");
	}

	private void AdventuresSaveData()
	{
		while (true)
		{
			bool flag = _reader.Read();
			JsonToken tokenType = _reader.TokenType;
			if (tokenType != JsonToken.PropertyName)
			{
				JsonToken tokenType2 = _reader.TokenType;
				if (tokenType2 == JsonToken.EndObject)
				{
					break;
				}
				continue;
			}
			object value = _reader.Value;
			AdventureType key = ParseEnum<AdventureType>(value);
			PlayerOptionsData pod = _pod;
			int num = ((Dictionary<System.Int32Enum, object>)(object)pod._003CAdventuresSaveData_003Ek__BackingField).FindEntry((System.Int32Enum)key);
			if (num < 0)
			{
				PlayerOptionsData pod2 = _pod;
				PlayerOptionsData value2 = new PlayerOptionsData();
				bool flag2 = ((Dictionary<System.Int32Enum, object>)(object)pod2._003CAdventuresSaveData_003Ek__BackingField).TryInsert((System.Int32Enum)key, (object)value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			}
			PlayerOptionsData value3 = ParseAdventureData(_reader);
			PlayerOptionsData pod3 = _pod;
			bool flag3 = ((Dictionary<System.Int32Enum, object>)(object)pod3._003CAdventuresSaveData_003Ek__BackingField).TryInsert((System.Int32Enum)key, (object)value3, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
		}
	}

	private void HasSeenAdventureReveal()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CHasSeenAdventureReveal_003Ek__BackingField = flag;
	}

	private void AdventureCompletionCount()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		int num = ParseInt(value);
		pod._003CAdventureCompletionCount_003Ek__BackingField = num;
	}

	private void CollectionFilterMode()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		CollectionsPage.FilterType collectionFilterMode = ParseEnum<CollectionsPage.FilterType>(value);
		pod.CollectionFilterMode = collectionFilterMode;
	}

	private void HideUnavailableAdventures()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CHideUnavailableAdventures_003Ek__BackingField = flag;
	}

	private void TotalAdventurePlaytime()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		float num = ParseFloat(value);
		pod._003CTotalAdventurePlaytime_003Ek__BackingField = num;
	}

	private void AllTimeAdventurePlaytime()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		float num = ParseFloat(value);
		pod._003CAllTimeAdventurePlaytime_003Ek__BackingField = num;
	}

	private void AscensionPointsAllocation()
	{
		PlayerOptionsData pod = _pod;
		ParseObjectEnumInt(pod._003CAscensionPointsAllocation_003Ek__BackingField);
	}

	private void HasSeenAdventuresIntroTutorial()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CHasSeenAdventuresIntroTutorial_003Ek__BackingField = flag;
	}

	private void AdventureStars()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		float num = ParseFloat(value);
		pod._003CAdventureStars_003Ek__BackingField = num;
	}

	private void HasPlayedStage3()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CHasPlayedStage3_003Ek__BackingField = flag;
	}

	private void CompletedAdventures()
	{
		PlayerOptionsData pod = _pod;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A98CD0");
	}

	private void HasSeenMerchantTutorial()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CHasSeenMerchantTutorial_003Ek__BackingField = flag;
	}

	private void SeenAscensionPopups()
	{
		PlayerOptionsData pod = _pod;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A98CD0");
	}

	private void HasSeenDarkanaTransition()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CHasSeenDarkanaTransition_003Ek__BackingField = flag;
	}

	private void HasFixedSkinIds()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CHasFixedSkinIds_003Ek__BackingField = flag;
	}

	private void BoughtSkins()
	{
		PlayerOptionsData pod = _pod;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A98EA0");
	}

	private void BanishedContentGroups()
	{
		PlayerOptionsData pod = _pod;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99070");
	}

	private void ContentGroupSealedItems()
	{
		PlayerOptionsData pod = _pod;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A983C0");
	}

	private void ContentGroupSealedWeapons()
	{
		PlayerOptionsData pod = _pod;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A981F0");
	}

	private void SelectedBGMPlayback()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		BgmPlaybackType bgmPlaybackType = ParseEnum<BgmPlaybackType>(value);
		pod._003CSelectedBGMPlayback_003Ek__BackingField = bgmPlaybackType;
	}

	private void PlayBGMOnlyDuringRun()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		bool flag = ParseBool(value);
		pod._003CPlayBGMOnlyDuringRun_003Ek__BackingField = flag;
	}

	private void TP_FrozenShadesCount()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		int tP_FrozenShadesCount = ParseInt(value);
		pod.TP_FrozenShadesCount = tP_FrozenShadesCount;
	}

	private void TP_AxeArmorCount()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		int tP_AxeArmorCount = ParseInt(value);
		pod.TP_AxeArmorCount = tP_AxeArmorCount;
	}

	private void TP_SniperCount()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		int tP_SniperCount = ParseInt(value);
		pod.TP_SniperCount = tP_SniperCount;
	}

	private void TP_PortraitsCount()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		int tP_PortraitsCount = ParseInt(value);
		pod.TP_PortraitsCount = tP_PortraitsCount;
	}

	private void LibraryMerchantGoldSpent()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		int num = ParseInt(value);
		pod._003CLibraryMerchantGoldSpent_003Ek__BackingField = num;
	}

	private void EME_NextBossBiome()
	{
		PlayerOptionsData pod = _pod;
		object value = _reader.Value;
		int num = ParseInt(value);
		pod._003CEME_NextBossBiome_003Ek__BackingField = num;
	}

	private void WW_ZoneProgress()
	{
		PlayerOptionsData pod = _pod;
		if (_reader != null)
		{
			object value = _reader.Value;
			int num = ParseInt(value);
			if (_pod != null)
			{
				pod._003CWW_ZoneProgress_003Ek__BackingField = num;
				return;
			}
		}
		throw new NullReferenceException();
	}
}
