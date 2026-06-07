using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;

public class LuaTableContent
{
	public struct Key
	{
		public object value;

		public Key(double key)
		{
			value = null;
		}

		public Key(string key)
		{
			value = null;
		}

		public static implicit operator Key(double key)
		{
			return default(Key);
		}

		public static implicit operator Key(string key)
		{
			return default(Key);
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct Null
	{
	}

	public enum FieldType
	{
		Null = 0,
		Number = 1,
		String = 2,
		Boolean = 3,
		Vector = 4,
		Table = 5,
		InputName = 6
	}

	public abstract class GenericField
	{
		protected FieldType fieldType;

		public FieldType GetFieldType()
		{
			return default(FieldType);
		}

		public abstract void Write(BinaryWriter writer);

		public bool TryGetValue<T>(out T value)
		{
			value = default(T);
			return false;
		}
	}

	public class Field<T> : GenericField
	{
		public object value;

		public Field(T value)
		{
		}

		public override void Write(BinaryWriter writer)
		{
		}
	}

	public static Dictionary<Type, FieldType> fieldTypes;

	public Dictionary<double, GenericField> numberKeyFields;

	public Dictionary<string, GenericField> stringKeyFields;

	public int FieldCount => 0;

	public LuaTableContent()
	{
	}

	public LuaTableContent(byte[] data)
	{
	}

	private void SetField<T>(Key key, T value)
	{
	}

	public void SetFieldNull(Key key)
	{
	}

	public void SetFieldNumber(Key key, double value)
	{
	}

	public void SetFieldString(Key key, string value)
	{
	}

	public void SetFieldDataString(Key key, byte[] value)
	{
	}

	public void SetFieldBoolean(Key key, bool value)
	{
	}

	public void SetFieldVector(Key key, Vector4 value)
	{
	}

	public void SetFieldTable(Key key, LuaTableContent value)
	{
	}

	public void SetFieldInputName(Key key, InputName value)
	{
	}

	private void Write(BinaryWriter writer)
	{
	}

	private void WriteValue(BinaryWriter writer)
	{
	}

	public LuaTable ToLuaTable()
	{
		return null;
	}

	public bool Read(BinaryReader reader)
	{
		return false;
	}

	public void Set<T>(T data)
	{
	}

	public void SetArray(IEnumerable<string> stringArray)
	{
	}

	public Dictionary<string, string> ToDictionaryString()
	{
		return null;
	}
}
