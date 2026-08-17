using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Cpp2ILInjected;
using Newtonsoft.Json.Linq;
using UnityEngine;
using VampireSurvivors.App.Data;
using VampireSurvivors.Data;
using VampireSurvivors.Data.PowerUp;
using VampireSurvivors.Framework;

namespace VampireSurvivors;

public static class SerializationUtils
{
	public unsafe static byte[] SerializeEnum<T>(List<T> enumList) where T : Enum
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		//IL_00ad: Expected O, but got I4
		//IL_0183: Expected O, but got Ref
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		//IL_019e: Expected O, but got Ref
		//IL_032c: Expected O, but got I
		//IL_033c: Expected O, but got I
		//IL_024b: Expected O, but got I
		//IL_0201: Expected O, but got I
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Expected O, but got Unknown
		//IL_0224: Expected O, but got I
		//IL_0236: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		bool flag = enumList == null;
		byte[] result = null;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type type = default(Type);
			Type enumType = type;
			SerializationType serializationTypeForEnum = EnumCache.GetSerializationTypeForEnum(enumType);
			bool flag2 = serializationTypeForEnum == SerializationType.Byte;
			int num;
			if (!flag2)
			{
				object obj3 = serializationTypeForEnum - 1;
				if (!flag2)
				{
					object obj4 = obj3 - 1;
					if (!flag2)
					{
						if ((nint)obj4 != 1)
						{
							ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
							throw ex;
						}
						num = enumList._size * 8;
					}
					else
					{
						num = enumList._size * 4;
					}
				}
				else
				{
					num = enumList._size + enumList._size;
				}
			}
			else
			{
				num = enumList._size;
			}
			byte[] array = new byte[num];
			bool writable = default(bool);
			bool publiclyVisible = default(bool);
			MemoryStream memoryStream = new MemoryStream(array, 0, array.Length, writable, publiclyVisible);
			Stream output = default(Stream);
			object obj5 = (object)(&output);
			BinaryWriter binaryWriter = new BinaryWriter(output);
			object obj7 = default(object);
			object obj6 = (object)(&obj7);
			object obj10 = default(object);
			object obj11 = default(object);
			object obj13 = default(object);
			object obj15 = default(object);
			BinaryWriter binaryWriter2;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ stack_10_v8+38]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v713 @ rax_v35+48]");
				object obj9 = 0;
				if (obj10 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ stack_-C8_v9+1C]");
					if (obj11 != null)
					{
						break;
					}
					object obj12 = obj13;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ stack_-C8_v9+18]");
					if ((nint)obj12 >= 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ stack_-C8_v9+10]");
					object obj14 = 0;
					obj13 = obj15 + 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ stack_10_v8+38]");
					object obj16 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183134A50");
					binaryWriter2 = (BinaryWriter)serializationTypeForEnum;
					continue;
				}
				throw new NullReferenceException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v714 @ r8_v11+20]");
			binaryWriter2 = (BinaryWriter)0;
			if (obj10 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ stack_-C8_v9+1C]");
				if (obj11 == null)
				{
					if (obj6 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
					}
					if (obj5 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
					}
					result = array;
					goto IL_03c8;
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
				binaryWriter2 = null;
			}
			throw new NullReferenceException();
		}
		goto IL_03c8;
		IL_03c8:
		return result;
	}

	public static List<T> DeserializeEnum<T>(byte[] buffer) where T : Enum
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		//IL_01bd: Expected I4, but got O
		//IL_011e: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		List<T> list = new List<T>();
		if (buffer != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type type = default(Type);
			Type enumType = type;
			SerializationType serializationTypeForEnum = EnumCache.GetSerializationTypeForEnum(enumType);
			bool writable = default(bool);
			bool publiclyVisible = default(bool);
			MemoryStream memoryStream = new MemoryStream(buffer, 0, buffer.Length, writable, publiclyVisible);
			Stream input = default(Stream);
			BinaryReader binaryReader = new BinaryReader(input);
			BinaryReader br = default(BinaryReader);
			while (true)
			{
				System.Int32Enum item = (System.Int32Enum)ReadEnumValue<T>(serializationTypeForEnum, br);
				if (list == null)
				{
					break;
				}
				int version = list._version + 1;
				list._version = version;
				SerializationType serializationType = (SerializationType)list._items;
				int size = list._size;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rcx_v16 (VampireSurvivors.SerializationType)+18]");
				if ((nint)size >= (nint)0)
				{
					((List<System.Int32Enum>)(object)list).AddWithResize(item);
					continue;
				}
				int size2 = list._size + 1;
				list._size = size2;
			}
			throw new NullReferenceException();
		}
		return list;
	}

	public unsafe static byte[] SerializeLimitBreaks(List<WeightedLimitBreak> limitBreaks)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_007e: Expected O, but got I4
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		//IL_00da: Expected O, but got Ref
		//IL_00f5: Expected O, but got Ref
		//IL_0103: Expected O, but got I4
		//IL_010b: Expected O, but got Ref
		bool flag = limitBreaks == null;
		byte[] result = null;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type type = default(Type);
			Type enumType = type;
			SerializationType serializationTypeForEnum = EnumCache.GetSerializationTypeForEnum(enumType);
			int sizeForSerializationType = GetSizeForSerializationType(serializationTypeForEnum);
			object obj3 = limitBreaks._size * sizeForSerializationType;
			object obj4 = obj3 + limitBreaks._size;
			byte[] array = new byte[obj4];
			bool writable = default(bool);
			bool publiclyVisible = default(bool);
			MemoryStream memoryStream = new MemoryStream(array, 0, array.Length, writable, publiclyVisible);
			int num = array.Length;
			Stream output = default(Stream);
			object obj5 = (object)(&output);
			BinaryWriter binaryWriter = new BinaryWriter(output);
			BinaryWriter binaryWriter2 = default(BinaryWriter);
			object obj6 = (object)(&binaryWriter2);
			List<WeightedLimitBreak>.Enumerator enumerator = default(List<WeightedLimitBreak>.Enumerator);
			if (enumerator.MoveNext())
			{
				object obj7 = 0;
				List<WeightedLimitBreak>.Enumerator enumerator2 = (List<WeightedLimitBreak>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			if (obj6 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
			}
			if (obj5 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
			}
			result = array;
		}
		return result;
	}

	public static List<WeightedLimitBreak> DeserializeLimitBreaks(byte[] buffer)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_0164: Expected I, but got O
		//IL_020b: Expected O, but got I4
		//IL_02d6: Expected I4, but got O
		//IL_029f: Expected I4, but got O
		List<WeightedLimitBreak> list = new List<WeightedLimitBreak>();
		if (buffer != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type type = default(Type);
			Type enumType = type;
			SerializationType serializationTypeForEnum = EnumCache.GetSerializationTypeForEnum(enumType);
			bool flag = default(bool);
			bool flag2 = default(bool);
			MemoryStream memoryStream = new MemoryStream(buffer, 0, buffer.Length, flag, flag2);
			int num = buffer.Length;
			Stream input = default(Stream);
			BinaryReader binaryReader = new BinaryReader(input);
			BinaryReader binaryReader2 = default(BinaryReader);
			object obj4 = default(object);
			IEnumerable<JToken> value = default(IEnumerable<JToken>);
			while (true)
			{
				WeaponType weaponType = ReadEnumValue<WeaponType>(serializationTypeForEnum, binaryReader2);
				if (binaryReader2 != null)
				{
					byte b = binaryReader2.ReadByte();
					GameManager core = GM.Core;
					if ((object)GM.Core != null)
					{
						DataManager dataManager = core._dataManager;
						if (core._dataManager != null)
						{
							if (dataManager._003CAllLimitBreakData_003Ek__BackingField != null)
							{
								object obj3 = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllLimitBreakData_003Ek__BackingField).get_Item((System.Int32Enum)weaponType);
								if (obj3 != null)
								{
									nint num2 = (nint)obj3;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v531 @ r8_v11 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
									if (obj4 == null)
									{
										continue;
									}
									object obj5 = obj4;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v548 @ r8_v13+208] (should have been resolved before IL gen)");
									object obj6 = Extensions.Value<object>(value);
									if (obj6 == null)
									{
										continue;
									}
									object obj7 = ((JToken)obj6).ToObject<object>();
									if (obj7 != null)
									{
										WeightedLimitBreak item = new WeightedLimitBreak(weaponType, 0, (LimitBreakData)obj7, flag ? 1u : 0u, (string)flag2);
										if (list == null)
										{
											break;
										}
										int version = list._version + 1;
										list._version = version;
										BinaryReader items = (BinaryReader)(object)list._items;
										if (list._size >= (nint)items.m_buffer)
										{
											((List<object>)(object)list).AddWithResize((object)item);
											num = (int)obj7;
											continue;
										}
										int size = list._size + 1;
										list._size = size;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										num = (int)obj7;
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
			throw new NullReferenceException();
		}
		return list;
	}

	public unsafe static byte[] SerializePowerUps(List<PowerUpLevel> powerUps)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_00a0: Expected O, but got I4
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		//IL_0114: Expected O, but got Ref
		//IL_012f: Expected O, but got Ref
		//IL_013d: Expected O, but got I4
		//IL_0145: Expected O, but got Ref
		if (powerUps != null && powerUps._size != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type type = default(Type);
			Type enumType = type;
			SerializationType serializationTypeForEnum = EnumCache.GetSerializationTypeForEnum(enumType);
			int sizeForSerializationType = GetSizeForSerializationType(serializationTypeForEnum);
			object obj3 = powerUps._size * sizeForSerializationType;
			object obj4 = obj3 + powerUps._size;
			byte[] array = new byte[obj4];
			if (array != null)
			{
				bool writable = default(bool);
				bool publiclyVisible = default(bool);
				MemoryStream memoryStream = new MemoryStream(array, 0, array.Length, writable, publiclyVisible);
				int num = array.Length;
				Stream output = default(Stream);
				object obj5 = (object)(&output);
				BinaryWriter binaryWriter = new BinaryWriter(output);
				BinaryWriter binaryWriter2 = default(BinaryWriter);
				object obj6 = (object)(&binaryWriter2);
				List<PowerUpLevel>.Enumerator enumerator = default(List<PowerUpLevel>.Enumerator);
				if (enumerator.MoveNext())
				{
					object obj7 = 0;
					List<PowerUpLevel>.Enumerator enumerator2 = (List<PowerUpLevel>.Enumerator)(&enumerator);
					throw new NullReferenceException();
				}
				if (obj6 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				if (obj5 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				return array;
			}
			return (byte[])(object)new NullReferenceException();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18047E1C0");
		byte[] result = default(byte[]);
		return result;
	}

	public static List<PowerUpLevel> DeserializePowerUps(byte[] buffer)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_00ff: Expected I4, but got O
		List<PowerUpLevel> list = new List<PowerUpLevel>();
		if (buffer != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type type = default(Type);
			Type enumType = type;
			SerializationType serializationTypeForEnum = EnumCache.GetSerializationTypeForEnum(enumType);
			bool writable = default(bool);
			bool publiclyVisible = default(bool);
			MemoryStream memoryStream = new MemoryStream(buffer, 0, buffer.Length, writable, publiclyVisible);
			Stream input = default(Stream);
			BinaryReader binaryReader = new BinaryReader(input);
			BinaryReader binaryReader2 = default(BinaryReader);
			while (true)
			{
				PowerUpType powerUp = ReadEnumValue<PowerUpType>(serializationTypeForEnum, binaryReader2);
				if (binaryReader2 == null)
				{
					break;
				}
				byte level = binaryReader2.ReadByte();
				PowerUpLevel powerUpLevel = new PowerUpLevel();
				powerUpLevel.PowerUp = powerUp;
				powerUpLevel.Level = level;
				int version = list._version + 1;
				list._version = version;
				int num = (int)list._items;
				int size = list._size;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ r9_v6 (System.Int32)+18]");
				if ((nint)size >= (nint)0)
				{
					((List<object>)(object)list).AddWithResize((object)powerUpLevel);
					continue;
				}
				int size2 = list._size + 1;
				list._size = size2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			throw new NullReferenceException();
		}
		return list;
	}

	public unsafe static byte[] SerializeTreasurePrizePairs(List<TreasurePrizeTypePair> prizePairs)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		//IL_0107: Expected O, but got I4
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Expected O, but got Unknown
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_0162: Expected I4, but got O
		//IL_019e: Expected O, but got Ref
		//IL_01b9: Expected O, but got Ref
		//IL_01cd: Expected O, but got I4
		//IL_0286: Expected I4, but got O
		//IL_02a3: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type type = default(Type);
		Type enumType = type;
		SerializationType serializationTypeForEnum = EnumCache.GetSerializationTypeForEnum(enumType);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type enumType2 = default(Type);
		SerializationType serializationTypeForEnum2 = EnumCache.GetSerializationTypeForEnum(enumType2);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type enumType3 = default(Type);
		SerializationType serializationTypeForEnum3 = EnumCache.GetSerializationTypeForEnum(enumType3);
		int sizeForSerializationType = GetSizeForSerializationType(serializationTypeForEnum);
		int sizeForSerializationType2 = GetSizeForSerializationType(serializationTypeForEnum2);
		int sizeForSerializationType3 = GetSizeForSerializationType(serializationTypeForEnum3);
		if (prizePairs != null)
		{
			object obj7 = sizeForSerializationType3 + sizeForSerializationType2;
			object obj8 = obj7 + sizeForSerializationType;
			object obj9 = obj8 * prizePairs._size;
			object obj10 = prizePairs._size + obj9;
			byte[] array = new byte[obj10];
			bool flag = array == null;
			SerializationType serializationType = (SerializationType)typeof(byte[]);
			if (!flag)
			{
				bool writable = default(bool);
				bool publiclyVisible = default(bool);
				MemoryStream memoryStream = new MemoryStream(array, 0, array.Length, writable, publiclyVisible);
				Stream output = default(Stream);
				object obj11 = (object)(&output);
				BinaryWriter binaryWriter = new BinaryWriter(output);
				BinaryWriter binaryWriter2 = default(BinaryWriter);
				object obj12 = (object)(&binaryWriter2);
				List<TreasurePrizeTypePair>.Enumerator enumerator = default(List<TreasurePrizeTypePair>.Enumerator);
				if (enumerator.MoveNext())
				{
					object obj13 = 0;
					serializationType = (SerializationType)(int)(&enumerator);
					throw new NullReferenceException();
				}
				if (obj12 != null)
				{
					WriteEnumValue(SerializationType.Byte, (BinaryWriter)(object)typeof(IDisposable), (WeaponType)obj12);
				}
				if (obj11 != null)
				{
					WriteEnumValue(SerializationType.Byte, (BinaryWriter)(object)typeof(IDisposable), (WeaponType)obj11);
				}
				return array;
			}
		}
		throw new NullReferenceException();
	}

	public static List<TreasurePrizeTypePair> DeserializeTreasurePrizePairs(byte[] buffer)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		//IL_01e4: Expected I4, but got O
		List<TreasurePrizeTypePair> list = new List<TreasurePrizeTypePair>();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type type = default(Type);
		Type enumType = type;
		SerializationType serializationTypeForEnum = EnumCache.GetSerializationTypeForEnum(enumType);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type enumType2 = default(Type);
		SerializationType serializationTypeForEnum2 = EnumCache.GetSerializationTypeForEnum(enumType2);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type enumType3 = default(Type);
		SerializationType serializationTypeForEnum3 = EnumCache.GetSerializationTypeForEnum(enumType3);
		bool writable = default(bool);
		bool publiclyVisible = default(bool);
		MemoryStream memoryStream = new MemoryStream(buffer, 0, buffer.Length, writable, publiclyVisible);
		Stream input = default(Stream);
		BinaryReader binaryReader = new BinaryReader(input);
		SerializationType serializationType = serializationTypeForEnum;
		BinaryReader binaryReader2 = default(BinaryReader);
		while (true)
		{
			ItemType prizeItem = ReadEnumValue<ItemType>(serializationType, binaryReader2);
			PrizeType prizeType = ReadEnumValue<PrizeType>(serializationTypeForEnum2, binaryReader2);
			WeaponType prizeWeapon = ReadEnumValue<WeaponType>(serializationTypeForEnum3, binaryReader2);
			if (binaryReader2 != null)
			{
				byte level = binaryReader2.ReadByte();
				TreasurePrizeTypePair treasurePrizeTypePair = new TreasurePrizeTypePair();
				if (treasurePrizeTypePair != null)
				{
					treasurePrizeTypePair.Level = level;
					treasurePrizeTypePair.prizeItem = prizeItem;
					treasurePrizeTypePair.prizeType = prizeType;
					treasurePrizeTypePair.prizeWeapon = prizeWeapon;
					if (list != null)
					{
						int version = list._version + 1;
						list._version = version;
						int num = (int)list._items;
						if (list._items == null)
						{
							break;
						}
						int size = list._size;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ r9_v7 (System.Int32)+18]");
						if ((nint)size >= (nint)0)
						{
							((List<object>)(object)list).AddWithResize((object)treasurePrizeTypePair);
							serializationType = serializationTypeForEnum;
							continue;
						}
						int size2 = list._size + 1;
						list._size = size2;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						serializationType = serializationTypeForEnum;
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

	public unsafe static byte[] SerializePickupCount(Dictionary<ItemType, int> pickupCount)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_00a1: Expected O, but got I
		//IL_00af: Expected O, but got I4
		//IL_00e6: Expected I4, but got O
		//IL_012c: Expected O, but got Ref
		//IL_0147: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type type = default(Type);
		Type enumType = type;
		SerializationType serializationTypeForEnum = EnumCache.GetSerializationTypeForEnum(enumType);
		int sizeForSerializationType = GetSizeForSerializationType(serializationTypeForEnum);
		if (pickupCount != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [pickupCount @ rcx (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.ItemType, System.Int32>)+20]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [pickupCount @ rcx (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.ItemType, System.Int32>)+28]");
			object obj3 = num - 0;
			object obj4 = sizeForSerializationType + 4;
			object obj5 = obj3 * obj4;
			byte[] array = new byte[obj5];
			bool flag = array == null;
			SerializationType serializationType = (SerializationType)typeof(byte[]);
			if (!flag)
			{
				bool writable = default(bool);
				bool publiclyVisible = default(bool);
				MemoryStream memoryStream = new MemoryStream(array, 0, array.Length, writable, publiclyVisible);
				int num2 = array.Length;
				Stream output = default(Stream);
				object obj6 = (object)(&output);
				BinaryWriter binaryWriter = new BinaryWriter(output);
				BinaryWriter binaryWriter2 = default(BinaryWriter);
				object obj7 = (object)(&binaryWriter2);
				Dictionary<ItemType, int>.Enumerator enumerator = default(Dictionary<ItemType, int>.Enumerator);
				while (enumerator.MoveNext())
				{
					WriteEnumValue(serializationTypeForEnum, binaryWriter2, ItemType.VOID);
					if (binaryWriter2 != null)
					{
						int value__ = ((SerializationType*)(&binaryWriter2))->value__;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v514 @ r8_v11 (System.Int32)+288] (should have been resolved before IL gen)");
						num2 = 0;
						continue;
					}
					throw new NullReferenceException();
				}
				if (obj7 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				if (obj6 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				return array;
			}
		}
		throw new NullReferenceException();
	}

	public static Dictionary<ItemType, int> DeserializePickupCount(byte[] buffer)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		Dictionary<ItemType, int> dictionary = new Dictionary<ItemType, int>();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type type = default(Type);
		Type enumType = type;
		SerializationType serializationTypeForEnum = EnumCache.GetSerializationTypeForEnum(enumType);
		bool writable = default(bool);
		bool publiclyVisible = default(bool);
		MemoryStream memoryStream = new MemoryStream(buffer, 0, buffer.Length, writable, publiclyVisible);
		Stream input = default(Stream);
		BinaryReader binaryReader = new BinaryReader(input);
		BinaryReader binaryReader2 = default(BinaryReader);
		while (true)
		{
			ItemType key = ReadEnumValue<ItemType>(serializationTypeForEnum, binaryReader2);
			if (binaryReader2 != null)
			{
				int value = binaryReader2.ReadInt32();
				if (dictionary == null)
				{
					break;
				}
				bool flag = ((Dictionary<System.Int32Enum, int>)(object)dictionary).TryInsert((System.Int32Enum)key, value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				continue;
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	public unsafe static byte[] SerializeSelectedSkins(Dictionary<CharacterType, SkinType> selectedSkins)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0254: Expected O, but got I4
		//IL_028b: Expected I4, but got O
		//IL_0116: Expected O, but got Ref
		//IL_0131: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type type = default(Type);
		Type enumType = type;
		SerializationType serializationTypeForEnum = EnumCache.GetSerializationTypeForEnum(enumType);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type enumType2 = default(Type);
		SerializationType serializationTypeForEnum2 = EnumCache.GetSerializationTypeForEnum(enumType2);
		int sizeForSerializationType = GetSizeForSerializationType(serializationTypeForEnum);
		int sizeForSerializationType2 = GetSizeForSerializationType(serializationTypeForEnum2);
		if (selectedSkins != null)
		{
			Type type2 = null;
			Dictionary<CharacterType, SkinType>.Enumerator enumerator = default(Dictionary<CharacterType, SkinType>.Enumerator);
			while (enumerator.MoveNext())
			{
			}
			object obj5 = sizeForSerializationType + sizeForSerializationType2;
			object obj6 = obj5 * (object)type2;
			byte[] array = new byte[obj6];
			bool flag = array == null;
			SerializationType serializationType = (SerializationType)typeof(byte[]);
			if (!flag)
			{
				bool writable = default(bool);
				bool publiclyVisible = default(bool);
				MemoryStream memoryStream = new MemoryStream(array, 0, array.Length, writable, publiclyVisible);
				int num = array.Length;
				Stream output = default(Stream);
				object obj7 = (object)(&output);
				BinaryWriter binaryWriter = new BinaryWriter(output);
				BinaryWriter binaryWriter2 = default(BinaryWriter);
				object obj8 = (object)(&binaryWriter2);
				Dictionary<CharacterType, SkinType>.Enumerator enumerator2 = default(Dictionary<CharacterType, SkinType>.Enumerator);
				while (enumerator2.MoveNext())
				{
				}
				if (obj8 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				if (obj7 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				return array;
			}
		}
		throw new NullReferenceException();
	}

	public unsafe static Dictionary<CharacterType, SkinType> DeserializeSelectedSkins(byte[] buffer)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0100: Expected O, but got Ref
		Dictionary<CharacterType, SkinType> dictionary = new Dictionary<CharacterType, SkinType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type type = default(Type);
		Type enumType = type;
		SerializationType serializationTypeForEnum = EnumCache.GetSerializationTypeForEnum(enumType);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type enumType2 = default(Type);
		SerializationType serializationTypeForEnum2 = EnumCache.GetSerializationTypeForEnum(enumType2);
		bool writable = default(bool);
		bool publiclyVisible = default(bool);
		MemoryStream memoryStream = new MemoryStream(buffer, 0, buffer.Length, writable, publiclyVisible);
		Stream input = default(Stream);
		BinaryReader binaryReader = new BinaryReader(input);
		BinaryReader br = default(BinaryReader);
		CharacterType characterType = default(CharacterType);
		SkinType skinType = default(SkinType);
		System.ParamsArray paramsArray2 = default(System.ParamsArray);
		while (true)
		{
			CharacterType key = ReadEnumValue<CharacterType>(serializationTypeForEnum, br);
			SkinType value = ReadEnumValue<SkinType>(serializationTypeForEnum2, br);
			object arg = characterType;
			object arg2 = skinType;
			System.ParamsArray paramsArray = new System.ParamsArray(arg, arg2);
			string message = string.FormatHelper((IFormatProvider)null, "Deserializing {0}: {1}", (System.ParamsArray)(&paramsArray2));
			Debug.Log(message);
			if (dictionary == null)
			{
				break;
			}
			bool flag = ((Dictionary<System.Int32Enum, System.Int32Enum>)(object)dictionary).TryInsert((System.Int32Enum)key, (System.Int32Enum)value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		}
		throw new NullReferenceException();
	}

	public unsafe static byte[] SerializeAscensionData(Dictionary<PowerUpType, int> ascensionData)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_00a1: Expected O, but got I
		//IL_00af: Expected O, but got I4
		//IL_00e6: Expected I4, but got O
		//IL_012c: Expected O, but got Ref
		//IL_0147: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type type = default(Type);
		Type enumType = type;
		SerializationType serializationTypeForEnum = EnumCache.GetSerializationTypeForEnum(enumType);
		int sizeForSerializationType = GetSizeForSerializationType(serializationTypeForEnum);
		if (ascensionData != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [ascensionData @ rcx (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.PowerUpType, System.Int32>)+20]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [ascensionData @ rcx (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.PowerUpType, System.Int32>)+28]");
			object obj3 = num - 0;
			object obj4 = sizeForSerializationType + 4;
			object obj5 = obj3 * obj4;
			byte[] array = new byte[obj5];
			bool flag = array == null;
			SerializationType serializationType = (SerializationType)typeof(byte[]);
			if (!flag)
			{
				bool writable = default(bool);
				bool publiclyVisible = default(bool);
				MemoryStream memoryStream = new MemoryStream(array, 0, array.Length, writable, publiclyVisible);
				int num2 = array.Length;
				Stream output = default(Stream);
				object obj6 = (object)(&output);
				BinaryWriter binaryWriter = new BinaryWriter(output);
				BinaryWriter binaryWriter2 = default(BinaryWriter);
				object obj7 = (object)(&binaryWriter2);
				Dictionary<PowerUpType, int>.Enumerator enumerator = default(Dictionary<PowerUpType, int>.Enumerator);
				while (enumerator.MoveNext())
				{
					WriteEnumValue(serializationTypeForEnum, binaryWriter2, PowerUpType.POWER);
					if (binaryWriter2 != null)
					{
						int value__ = ((SerializationType*)(&binaryWriter2))->value__;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v514 @ r8_v11 (System.Int32)+288] (should have been resolved before IL gen)");
						num2 = 0;
						continue;
					}
					throw new NullReferenceException();
				}
				if (obj7 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				if (obj6 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				return array;
			}
		}
		throw new NullReferenceException();
	}

	public static Dictionary<PowerUpType, int> DeserializeAscensionData(byte[] buffer)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		Dictionary<PowerUpType, int> dictionary = new Dictionary<PowerUpType, int>();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type type = default(Type);
		Type enumType = type;
		SerializationType serializationTypeForEnum = EnumCache.GetSerializationTypeForEnum(enumType);
		bool writable = default(bool);
		bool publiclyVisible = default(bool);
		MemoryStream memoryStream = new MemoryStream(buffer, 0, buffer.Length, writable, publiclyVisible);
		Stream input = default(Stream);
		BinaryReader binaryReader = new BinaryReader(input);
		BinaryReader binaryReader2 = default(BinaryReader);
		while (true)
		{
			PowerUpType key = ReadEnumValue<PowerUpType>(serializationTypeForEnum, binaryReader2);
			if (binaryReader2 != null)
			{
				int value = binaryReader2.ReadInt32();
				if (dictionary == null)
				{
					break;
				}
				bool flag = ((Dictionary<System.Int32Enum, int>)(object)dictionary).TryInsert((System.Int32Enum)key, value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				continue;
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	public unsafe static List<byte[]> SerializeUnlockedSkins(Dictionary<CharacterType, List<SkinType>> unlockedSkins)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		//IL_0305: Expected O, but got Unknown
		//IL_030d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0312: Expected O, but got Unknown
		//IL_0356: Expected I4, but got O
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		//IL_03e1: Expected O, but got I4
		//IL_03fb: Expected O, but got Ref
		//IL_0190: Expected O, but got I4
		//IL_0199: Expected O, but got I4
		//IL_0420: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type type = default(Type);
		Type enumType = type;
		SerializationType serializationTypeForEnum = EnumCache.GetSerializationTypeForEnum(enumType);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type enumType2 = default(Type);
		SerializationType serializationTypeForEnum2 = EnumCache.GetSerializationTypeForEnum(enumType2);
		int sizeForSerializationType = GetSizeForSerializationType(serializationTypeForEnum);
		int sizeForSerializationType2 = GetSizeForSerializationType(serializationTypeForEnum2);
		if (unlockedSkins != null)
		{
			Type type2 = null;
			Type type3 = null;
			Dictionary<CharacterType, List<SkinType>>.Enumerator enumerator = default(Dictionary<CharacterType, List<SkinType>>.Enumerator);
			object obj5 = default(object);
			while (enumerator.MoveNext())
			{
				if (obj5 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v462 @ stack_-C0+18]");
					if ((nint)0 != 0)
					{
						Type type4 = type3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v462 @ stack_-C0+18]");
						type3 = (Type)(type4 + 0);
						type2 = (Type)(type2 + 1);
					}
				}
			}
			object obj6 = type3 * sizeForSerializationType2;
			object obj7 = type2 * sizeForSerializationType;
			object obj8 = obj7 + obj6;
			object obj9 = obj8 + (object)type2;
			byte[] array = new byte[obj9];
			bool flag = array == null;
			SerializationType serializationType = (SerializationType)typeof(byte[]);
			if (!flag)
			{
				bool writable = default(bool);
				bool publiclyVisible = default(bool);
				MemoryStream memoryStream = new MemoryStream(array, 0, array.Length, writable, publiclyVisible);
				int num = array.Length;
				Stream output = default(Stream);
				BinaryWriter binaryWriter = new BinaryWriter(output);
				CharacterType characterType = CharacterType.VOID;
				List<SkinType>.Enumerator enumerator2 = (List<SkinType>.Enumerator)2;
				Dictionary<CharacterType, List<SkinType>>.Enumerator enumerator3 = default(Dictionary<CharacterType, List<SkinType>>.Enumerator);
				while (enumerator3.MoveNext())
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
					List<SkinType>.Enumerator enumerator4 = (List<SkinType>.Enumerator)0;
					enumerator2 = (List<SkinType>.Enumerator)0;
				}
				List<byte[]> result = SplitByteArray(array);
				BinaryWriter binaryWriter2 = default(BinaryWriter);
				object obj10 = (object)(&binaryWriter2);
				if (obj10 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				object obj11 = (object)(&output);
				if (obj11 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				return result;
			}
		}
		throw new NullReferenceException();
	}

	public static Dictionary<CharacterType, List<SkinType>> DeserializeUnlockedSkins(List<byte[]> chunks)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		//IL_00f8: Expected O, but got I4
		//IL_0157: Expected O, but got I
		//IL_0167: Expected O, but got I
		//IL_01f7: Expected O, but got I
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Expected O, but got Unknown
		byte[] array = JoinByteArrays(chunks);
		Dictionary<CharacterType, List<SkinType>> dictionary = new Dictionary<CharacterType, List<SkinType>>();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type type = default(Type);
		Type enumType = type;
		SerializationType serializationTypeForEnum = EnumCache.GetSerializationTypeForEnum(enumType);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type enumType2 = default(Type);
		SerializationType serializationTypeForEnum2 = EnumCache.GetSerializationTypeForEnum(enumType2);
		bool writable = default(bool);
		bool publiclyVisible = default(bool);
		MemoryStream memoryStream = new MemoryStream(array, 0, array.Length, writable, publiclyVisible);
		Stream input = default(Stream);
		BinaryReader binaryReader = new BinaryReader(input);
		BinaryReader binaryReader2 = default(BinaryReader);
		while (true)
		{
			CharacterType key = ReadEnumValue<CharacterType>(serializationTypeForEnum, binaryReader2);
			if (binaryReader2 == null)
			{
				break;
			}
			byte b = binaryReader2.ReadByte();
			List<SkinType> list = new List<SkinType>();
			object obj5 = 0;
			List<SkinType> list2 = list;
			while ((nint)obj5 < (int)b)
			{
				SkinType item = ReadEnumValue<SkinType>(serializationTypeForEnum2, binaryReader2);
				if (list != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.SkinType>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.SkinType>)+10]");
					list2 = (List<SkinType>)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.SkinType>)+18]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.SkinType>)+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.SkinType>)+18]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v428 @ rcx_v26 (System.Collections.Generic.List`1<VampireSurvivors.Data.SkinType>)+18]");
						if (num >= 0)
						{
							((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)item);
							obj5++;
							list2 = list;
							continue;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.SkinType>)+18]");
						object obj7 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.SkinType>)+18]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v428 @ rcx_v26 (System.Collections.Generic.List`1<VampireSurvivors.Data.SkinType>)+18]");
						if (num2 < 0)
						{
							obj5++;
							continue;
						}
						throw new IndexOutOfRangeException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			if (dictionary != null)
			{
				bool flag = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)key, (object)list, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				continue;
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	public unsafe static byte[] SerializeCustomMerchantData(CustomMerchantData adventureMerchantData)
	{
		//IL_0c9c: Expected I, but got O
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0047: Expected O, but got I
		//IL_0132: Expected O, but got I4
		//IL_00b6: Expected I, but got O
		//IL_00c6: Expected O, but got I
		//IL_00d6: Expected O, but got I
		//IL_01ea: Expected O, but got I4
		//IL_016e: Expected I, but got O
		//IL_017e: Expected O, but got I
		//IL_018e: Expected O, but got I
		//IL_02a2: Expected O, but got I4
		//IL_0226: Expected I, but got O
		//IL_0236: Expected O, but got I
		//IL_0246: Expected O, but got I
		//IL_035a: Expected O, but got I4
		//IL_02de: Expected I, but got O
		//IL_02ee: Expected O, but got I
		//IL_02fe: Expected O, but got I
		//IL_0412: Expected O, but got I4
		//IL_0396: Expected I, but got O
		//IL_03a6: Expected O, but got I
		//IL_03b6: Expected O, but got I
		//IL_048b: Expected I4, but got O
		//IL_04be: Expected O, but got I4
		//IL_04ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f2: Expected O, but got Unknown
		//IL_0508: Unknown result type (might be due to invalid IL or missing references)
		//IL_050d: Expected O, but got Unknown
		//IL_0b90: Expected I4, but got O
		//IL_0545: Unknown result type (might be due to invalid IL or missing references)
		//IL_054a: Expected O, but got Unknown
		//IL_057e: Expected O, but got I4
		//IL_05e0: Expected O, but got I
		//IL_05f0: Expected O, but got I
		//IL_0656: Expected O, but got I
		//IL_0666: Expected O, but got I
		//IL_06cc: Expected O, but got I
		//IL_06dc: Expected O, but got I
		//IL_0742: Expected O, but got I
		//IL_0752: Expected O, but got I
		//IL_07b8: Expected O, but got I
		//IL_07c8: Expected O, but got I
		//IL_09b6: Expected I4, but got O
		nint num = (nint)typeof(CharacterType);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		SerializationType serializationTypeForEnum = EnumCache.GetSerializationTypeForEnum((Type)num);
		int sizeForSerializationType = GetSizeForSerializationType(serializationTypeForEnum);
		if (adventureMerchantData != null)
		{
			byte[] array;
			if (adventureMerchantData._003CPortraitSprite_003Ek__BackingField != null)
			{
				Encoding uTF = Encoding.UTF8;
				bool flag = uTF == null;
				SerializationType serializationType = SerializationType.Byte;
				if (flag)
				{
					goto IL_09dd;
				}
				nint num2 = (nint)uTF;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v601 @ r8_v57 (Il2CppClass<System.Text.Encoding>)+268]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v601 @ r8_v57 (Il2CppClass<System.Text.Encoding>)+270]");
				object obj4 = 0;
				array = uTF.GetBytes(adventureMerchantData._003CPortraitSprite_003Ek__BackingField);
			}
			else
			{
				array = Array.Empty<byte>();
				SerializationType serializationType = SerializationType.Byte;
			}
			if (array != null)
			{
				object obj5 = array.Length + 1;
				byte[] array2;
				if (adventureMerchantData._003CPortraitSpriteTexture_003Ek__BackingField != null)
				{
					Encoding uTF2 = Encoding.UTF8;
					bool flag2 = uTF2 == null;
					SerializationType serializationType = SerializationType.Byte;
					if (flag2)
					{
						goto IL_09dd;
					}
					nint num3 = (nint)uTF2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v840 @ r8_v55 (Il2CppClass<System.Text.Encoding>)+268]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v840 @ r8_v55 (Il2CppClass<System.Text.Encoding>)+270]");
					object obj4 = 0;
					array2 = uTF2.GetBytes(adventureMerchantData._003CPortraitSpriteTexture_003Ek__BackingField);
				}
				else
				{
					array2 = Array.Empty<byte>();
					SerializationType serializationType = SerializationType.Byte;
				}
				if (array2 != null)
				{
					object obj6 = array2.Length + 1;
					byte[] array3;
					if (adventureMerchantData._003CStaticSprite_003Ek__BackingField != null)
					{
						Encoding uTF3 = Encoding.UTF8;
						bool flag3 = uTF3 == null;
						SerializationType serializationType = SerializationType.Byte;
						if (flag3)
						{
							goto IL_09dd;
						}
						nint num4 = (nint)uTF3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1082 @ r8_v53 (Il2CppClass<System.Text.Encoding>)+268]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1082 @ r8_v53 (Il2CppClass<System.Text.Encoding>)+270]");
						object obj4 = 0;
						array3 = uTF3.GetBytes(adventureMerchantData._003CStaticSprite_003Ek__BackingField);
					}
					else
					{
						array3 = Array.Empty<byte>();
						SerializationType serializationType = SerializationType.Byte;
					}
					if (array3 != null)
					{
						object obj7 = array3.Length + 1;
						byte[] array4;
						if (adventureMerchantData._003CStaticSpriteTexture_003Ek__BackingField != null)
						{
							Encoding uTF4 = Encoding.UTF8;
							bool flag4 = uTF4 == null;
							SerializationType serializationType = SerializationType.Byte;
							if (flag4)
							{
								goto IL_09dd;
							}
							nint num5 = (nint)uTF4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1178 @ r8_v51 (Il2CppClass<System.Text.Encoding>)+268]");
							object obj3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1178 @ r8_v51 (Il2CppClass<System.Text.Encoding>)+270]");
							object obj4 = 0;
							array4 = uTF4.GetBytes(adventureMerchantData._003CStaticSpriteTexture_003Ek__BackingField);
						}
						else
						{
							array4 = Array.Empty<byte>();
							SerializationType serializationType = SerializationType.Byte;
						}
						if (array4 != null)
						{
							object obj8 = array4.Length + 1;
							byte[] array5;
							if (adventureMerchantData._003CTextLocKey_003Ek__BackingField != null)
							{
								Encoding uTF5 = Encoding.UTF8;
								bool flag5 = uTF5 == null;
								SerializationType serializationType = SerializationType.Byte;
								if (flag5)
								{
									goto IL_09dd;
								}
								nint num6 = (nint)uTF5;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1280 @ r8_v49 (Il2CppClass<System.Text.Encoding>)+268]");
								object obj3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1280 @ r8_v49 (Il2CppClass<System.Text.Encoding>)+270]");
								object obj4 = 0;
								array5 = uTF5.GetBytes(adventureMerchantData._003CTextLocKey_003Ek__BackingField);
							}
							else
							{
								array5 = Array.Empty<byte>();
								SerializationType serializationType = SerializationType.Byte;
							}
							if (array5 != null)
							{
								object obj9 = array5.Length + 1;
								byte[] array6 = SerializeEnum(adventureMerchantData._003CMerchantInventory_003Ek__BackingField);
								bool flag6 = array6 != null;
								byte[] array7 = array6;
								if (!flag6)
								{
									byte[] array8 = new byte[0];
									array7 = array8;
								}
								byte[] array9 = SerializeEnum(adventureMerchantData._003CMerchantInventoryItems_003Ek__BackingField);
								bool flag7 = array9 != null;
								byte[] array10 = array9;
								if (!flag7)
								{
									byte[] array11 = new byte[0];
									array10 = array11;
									SerializationType serializationType = (SerializationType)typeof(byte[]);
								}
								if (array7 != null && array10 != null)
								{
									object obj10 = array10.Length + array7.Length;
									object obj11 = obj10 + obj9;
									object obj12 = obj11 + obj8;
									object obj13 = obj12 + obj7;
									object obj14 = obj6 + sizeForSerializationType;
									object obj15 = obj13 + obj14;
									object obj16 = obj5 + 10;
									object obj17 = obj15 + obj16;
									if ((object)adventureMerchantData._003CCustomCooldown_003Ek__BackingField != null)
									{
										obj17 += 4;
									}
									byte[] array12 = new byte[obj17];
									bool flag8 = array12 == null;
									SerializationType serializationType = (SerializationType)typeof(byte[]);
									if (!flag8)
									{
										bool writable = default(bool);
										bool publiclyVisible = default(bool);
										MemoryStream memoryStream = new MemoryStream(array12, 0, array12.Length, writable, publiclyVisible);
										CharacterType characterType = default(CharacterType);
										BinaryWriter binaryWriter = new BinaryWriter((Stream)characterType);
										BinaryWriter binaryWriter2 = default(BinaryWriter);
										WriteEnumValue(serializationTypeForEnum, binaryWriter2, adventureMerchantData._003CMerchantCharacter_003Ek__BackingField);
										string text = adventureMerchantData._003CPortraitSprite_003Ek__BackingField;
										if (adventureMerchantData._003CPortraitSprite_003Ek__BackingField == null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
											object obj18 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1378 @ rax_v102+B8]");
											object obj19 = 0;
											text = (string)obj19;
										}
										if (binaryWriter2 != null)
										{
											int value__ = ((SerializationType*)(&binaryWriter2))->value__;
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1383 @ r8_v22 (System.Int32)+2D8] (should have been resolved before IL gen)");
											string text2 = adventureMerchantData._003CPortraitSpriteTexture_003Ek__BackingField;
											if (adventureMerchantData._003CPortraitSpriteTexture_003Ek__BackingField == null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
												object obj20 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1397 @ rax_v101+B8]");
												object obj21 = 0;
												text2 = (string)obj21;
											}
											if (binaryWriter2 != null)
											{
												int value__2 = ((SerializationType*)(&binaryWriter2))->value__;
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1401 @ r8_v24 (System.Int32)+2D8] (should have been resolved before IL gen)");
												string text3 = adventureMerchantData._003CStaticSprite_003Ek__BackingField;
												if (adventureMerchantData._003CStaticSprite_003Ek__BackingField == null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
													object obj22 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1415 @ rax_v100+B8]");
													object obj23 = 0;
													text3 = (string)obj23;
												}
												if (binaryWriter2 != null)
												{
													int value__3 = ((SerializationType*)(&binaryWriter2))->value__;
													Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1419 @ r8_v26 (System.Int32)+2D8] (should have been resolved before IL gen)");
													string text4 = adventureMerchantData._003CStaticSpriteTexture_003Ek__BackingField;
													if (adventureMerchantData._003CStaticSpriteTexture_003Ek__BackingField == null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
														object obj24 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1433 @ rax_v99+B8]");
														object obj25 = 0;
														text4 = (string)obj25;
													}
													if (binaryWriter2 != null)
													{
														int value__4 = ((SerializationType*)(&binaryWriter2))->value__;
														Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1437 @ r8_v28 (System.Int32)+2D8] (should have been resolved before IL gen)");
														string text5 = adventureMerchantData._003CTextLocKey_003Ek__BackingField;
														if (adventureMerchantData._003CTextLocKey_003Ek__BackingField == null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
															object obj26 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1451 @ rax_v98+B8]");
															object obj27 = 0;
															text5 = (string)obj27;
														}
														if (binaryWriter2 != null)
														{
															int value__5 = ((SerializationType*)(&binaryWriter2))->value__;
															Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1455 @ r8_v30 (System.Int32)+2D8] (should have been resolved before IL gen)");
															if (binaryWriter2 != null)
															{
																int value__6 = ((SerializationType*)(&binaryWriter2))->value__;
																Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1457 @ r8_v32 (System.Int32)+1E8] (should have been resolved before IL gen)");
																bool flag9 = (object)adventureMerchantData._003CCustomCooldown_003Ek__BackingField == null;
																bool flag10 = !flag9;
																if (binaryWriter2 != null)
																{
																	int value__7 = ((SerializationType*)(&binaryWriter2))->value__;
																	Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1470 @ r8_v34 (System.Int32)+1E8] (should have been resolved before IL gen)");
																	if ((object)adventureMerchantData._003CCustomCooldown_003Ek__BackingField != null)
																	{
																		if (binaryWriter2 == null)
																		{
																			throw new NullReferenceException();
																		}
																		int value__8 = ((SerializationType*)(&binaryWriter2))->value__;
																		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1497 @ r8_v47 (System.Int32)+2C8] (should have been resolved before IL gen)");
																	}
																	if (binaryWriter2 != null)
																	{
																		int value__9 = ((SerializationType*)(&binaryWriter2))->value__;
																		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1500 @ r8_v37 (System.Int32)+288] (should have been resolved before IL gen)");
																		if (binaryWriter2 != null)
																		{
																			int value__10 = ((SerializationType*)(&binaryWriter2))->value__;
																			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1502 @ r8_v39 (System.Int32)+218] (should have been resolved before IL gen)");
																			if (binaryWriter2 != null)
																			{
																				int value__11 = ((SerializationType*)(&binaryWriter2))->value__;
																				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1504 @ r8_v41 (System.Int32)+288] (should have been resolved before IL gen)");
																				if (binaryWriter2 != null)
																				{
																					int value__12 = ((SerializationType*)(&binaryWriter2))->value__;
																					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1506 @ r8_v43 (System.Int32)+218] (should have been resolved before IL gen)");
																					if (binaryWriter2 != null)
																					{
																						WriteEnumValue(SerializationType.Byte, (BinaryWriter)(object)typeof(IDisposable), (CharacterType)binaryWriter2);
																					}
																					if (characterType != CharacterType.VOID)
																					{
																						WriteEnumValue(SerializationType.Byte, (BinaryWriter)(object)typeof(IDisposable), characterType);
																					}
																					return array12;
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
										throw new NullReferenceException();
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_09dd;
		IL_09dd:
		throw new NullReferenceException();
	}

	public static CustomMerchantData DeserializeCustomMerchantData(byte[] buffer)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_01de: Expected O, but got I4
		//IL_021f: Expected O, but got I4
		//IL_02bb: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type type = default(Type);
		Type enumType = type;
		SerializationType serializationTypeForEnum = EnumCache.GetSerializationTypeForEnum(enumType);
		bool writable = default(bool);
		bool publiclyVisible = default(bool);
		MemoryStream memoryStream = new MemoryStream(buffer, 0, buffer.Length, writable, publiclyVisible);
		Stream stream = default(Stream);
		BinaryReader binaryReader = new BinaryReader(stream);
		BinaryReader binaryReader2 = default(BinaryReader);
		CharacterType characterType = ReadEnumValue<CharacterType>(serializationTypeForEnum, binaryReader2);
		if (binaryReader2 != null)
		{
			string text = binaryReader2.ReadString();
			if (binaryReader2 != null)
			{
				string text2 = binaryReader2.ReadString();
				if (binaryReader2 != null)
				{
					string text3 = binaryReader2.ReadString();
					if (binaryReader2 != null)
					{
						string text4 = binaryReader2.ReadString();
						if (binaryReader2 != null)
						{
							string text5 = binaryReader2.ReadString();
							if (binaryReader2 != null)
							{
								bool flag = binaryReader2.ReadBoolean();
								if (binaryReader2 != null)
								{
									bool flag2 = binaryReader2.ReadBoolean();
									bool flag3 = !flag2;
									float? num = (float?)(object)0;
									if (!flag3)
									{
										if (binaryReader2 == null)
										{
											throw new NullReferenceException();
										}
										float num2 = binaryReader2.ReadSingle();
										num = (float?)(object)1;
									}
									if (binaryReader2 != null)
									{
										int count = binaryReader2.ReadInt32();
										if (binaryReader2 != null)
										{
											byte[] buffer2 = binaryReader2.ReadBytes(count);
											List<WeaponType> list = DeserializeEnum<WeaponType>(buffer2);
											if (binaryReader2 != null)
											{
												int count2 = binaryReader2.ReadInt32();
												if (binaryReader2 != null)
												{
													nint num3 = (nint)binaryReader2;
													byte[] buffer3 = binaryReader2.ReadBytes(count2);
													List<ItemType> list2 = DeserializeEnum<ItemType>(buffer3);
													CustomMerchantData customMerchantData = new CustomMerchantData();
													bool flag4 = customMerchantData == null;
													BinaryReader typeFromHandle = (BinaryReader)(object)typeof(CustomMerchantData);
													if (!flag4)
													{
														customMerchantData._003CMerchantCharacter_003Ek__BackingField = characterType;
														customMerchantData._003CPortraitSprite_003Ek__BackingField = text;
														customMerchantData._003CPortraitSpriteTexture_003Ek__BackingField = text2;
														customMerchantData._003CStaticSprite_003Ek__BackingField = text3;
														customMerchantData._003CStaticSpriteTexture_003Ek__BackingField = text4;
														customMerchantData._003CIsAnimated_003Ek__BackingField = flag;
														customMerchantData._003CTextLocKey_003Ek__BackingField = text5;
														customMerchantData._003CMerchantInventory_003Ek__BackingField = list;
														customMerchantData._003CMerchantInventoryItems_003Ek__BackingField = list2;
														customMerchantData._003CCustomCooldown_003Ek__BackingField = num;
														if (binaryReader2 != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
														}
														if (stream != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
														}
														return customMerchantData;
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
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	private static byte GetStringLength(string s)
	{
		//IL_0090: Expected I4, but got O
		byte[] bytes = default(byte[]);
		if (s != null)
		{
			Encoding uTF = Encoding.UTF8;
			if (uTF == null)
			{
				goto IL_0082;
			}
			bytes = uTF.GetBytes(s);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18047E1C0");
		}
		if (bytes != null)
		{
			return (byte)(bytes.Length + 1);
		}
		goto IL_0082;
		IL_0082:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex;
	}

	private static int GetSizeForSerializationType(SerializationType serializationType)
	{
		//IL_002b: Expected O, but got I4
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		bool flag = serializationType == SerializationType.Byte;
		if (!flag)
		{
			object obj = serializationType - 1;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					if ((nint)obj2 == 1)
					{
						return 8;
					}
					ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
					throw ex;
				}
				return 4;
			}
			return 2;
		}
		return 1;
	}

	private static void WriteEnumValue<T>(SerializationType serializationType, BinaryWriter bw, T value) where T : Enum
	{
		//IL_014d: Expected I, but got O
		//IL_0058: Expected O, but got I4
		//IL_0117: Expected I, but got O
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_00e1: Expected I, but got O
		//IL_00ab: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ r9 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		bool flag = serializationType == SerializationType.Byte;
		object obj3 = default(object);
		if (!flag)
		{
			object obj = serializationType - 1;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					if ((nint)obj2 != 1)
					{
						ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
						throw ex;
					}
					object value2 = (IntPtr)obj3;
					long value3 = Convert.ToInt64(value2);
					bw.Write(value3);
				}
				else
				{
					object value4 = (IntPtr)obj3;
					int value5 = Convert.ToInt32(value4);
					bw.Write(value5);
				}
			}
			else
			{
				object value6 = (IntPtr)obj3;
				short value7 = Convert.ToInt16(value6);
				bw.Write(value7);
			}
		}
		else
		{
			object value8 = (IntPtr)obj3;
			byte value9 = Convert.ToByte(value8);
			bw.Write(value9);
		}
	}

	private static T ReadEnumValue<T>(SerializationType serializationType, BinaryReader br) where T : Enum
	{
		//IL_0030: Expected O, but got I4
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_0208: Expected O, but got I
		//IL_022f: Expected O, but got I
		//IL_023f: Expected O, but got I
		//IL_024f: Expected O, but got I
		//IL_0182: Expected O, but got I
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		//IL_00af: Expected O, but got I4
		//IL_01a9: Expected O, but got I
		//IL_01b9: Expected O, but got I
		//IL_01c9: Expected O, but got I
		//IL_00fc: Expected O, but got I
		//IL_0123: Expected O, but got I
		//IL_0133: Expected O, but got I
		//IL_0143: Expected O, but got I
		bool flag = serializationType == SerializationType.Byte;
		if (!flag)
		{
			object obj = serializationType - 1;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					if ((nint)obj2 != 1)
					{
						ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
						throw ex;
					}
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rax_v50 (Il2CppClass<VampireSurvivors.EnumCaster`1<T>>)+135]");
					object obj3 = 0 & obj2;
					bool flag2 = obj3 == null;
					object obj4 = !flag2;
					if (obj4 == null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0570");
					}
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v385 @ rax_v55 (Il2CppClass<VampireSurvivors.EnumCaster`1<T>>)+B8]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v290 @ rax_v56 (Il2CppStaticFields<VampireSurvivors.EnumCaster`1<T>>)+18]");
					object obj5 = 0;
					long num4 = br.ReadInt64();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ rbx_v13+18]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ rbx_v13+28]");
					object obj7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ rbx_v13+40]");
					object obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v402 @ r9_v4 (should have been resolved before IL gen)");
				}
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rax_v42 (Il2CppClass<VampireSurvivors.EnumCaster`1<T>>)+B8]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rax_v43 (Il2CppStaticFields<VampireSurvivors.EnumCaster`1<T>>)+10]");
				object obj9 = 0;
				int num7 = br.ReadInt32();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ rbx_v11+18]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ rbx_v11+28]");
				object obj11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ rbx_v11+40]");
				object obj12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v403 @ r9_v3 (should have been resolved before IL gen)");
			}
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ rax_v29 (Il2CppClass<VampireSurvivors.EnumCaster`1<T>>)+B8]");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rax_v30 (Il2CppStaticFields<VampireSurvivors.EnumCaster`1<T>>)+8]");
			object obj13 = 0;
			short num10 = br.ReadInt16();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rbx_v8+18]");
			object obj14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rbx_v8+28]");
			object obj15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rbx_v8+40]");
			object obj16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v391 @ r9_v2 (should have been resolved before IL gen)");
		}
		Func<byte, T> fromByte = EnumCaster<T>.FromByte;
		byte b = br.ReadByte();
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v212 @ rbx_v5 (System.Func`2<System.Byte, T>)+18] (should have been resolved before IL gen)");
		T result = default(T);
		return result;
	}

	public static List<byte[]> SplitByteArray(byte[] buffer)
	{
		//IL_001c: Expected O, but got I
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Expected I4, but got Unknown
		List<byte[]> list = new List<byte[]>();
		object obj4;
		object obj6;
		int length = default(int);
		if (buffer != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r12d\"");
			object obj = (nint)buffer.Length + (nint)0;
			object obj2 = obj >> 8;
			object obj3 = obj2 >> 31;
			obj4 = obj2 + obj3;
			object obj5 = obj4 * 511;
			obj6 = buffer.Length - obj5;
			if ((nint)obj4 <= 0)
			{
				goto IL_018a;
			}
			int num = 0;
			int num2 = 0;
			while (true)
			{
				byte[] array = new byte[511];
				Array.Copy(buffer, num, array, 0, length);
				if (list == null)
				{
					break;
				}
				int version = list._version + 1;
				list._version = version;
				byte[][] items = list._items;
				if (list._items == null)
				{
					break;
				}
				if (list._size >= items.Length)
				{
					((List<object>)(object)list).AddWithResize((object)array);
				}
				else
				{
					int size = list._size + 1;
					list._size = size;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				num2++;
				num += 511;
				if (num2 < (nint)obj4)
				{
					continue;
				}
				goto IL_018a;
			}
		}
		goto IL_0215;
		IL_018a:
		if ((nint)obj6 > 0)
		{
			byte[] destinationArray = new byte[obj6];
			int sourceIndex = obj4 * 511;
			Array.Copy(buffer, sourceIndex, destinationArray, 0, length);
			if (list == null)
			{
				goto IL_0215;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B5C40");
		}
		return list;
		IL_0215:
		return (List<byte[]>)(object)new NullReferenceException();
	}

	public unsafe static byte[] JoinByteArrays(List<byte[]> chunks)
	{
		//IL_0021: Expected O, but got I4
		//IL_0029: Expected O, but got Ref
		//IL_0068: Expected O, but got Ref
		int num = 0;
		List<byte[]>.Enumerator enumerator = default(List<byte[]>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<byte[]>.Enumerator enumerator2 = (List<byte[]>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		byte[] result = new byte[num];
		int num2 = 0;
		List<byte[]>.Enumerator enumerator3 = default(List<byte[]>.Enumerator);
		if (enumerator3.MoveNext())
		{
			Array array = null;
			Array array2 = (Array)(&enumerator3);
			throw new NullReferenceException();
		}
		return result;
	}
}
