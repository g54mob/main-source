using System;

namespace SharpConfig
{
	public sealed class Setting : ConfigurationElement
	{
		private string mRawValue = string.Empty;

		private int mCachedArraySize;

		private bool mShouldCalculateArraySize;

		private char mCachedArrayElementSeparator;

		public string StringValue
		{
			get
			{
				return GetValue<string>();
			}
			set
			{
				SetValue(value);
			}
		}

		public string[] StringValueArray
		{
			get
			{
				return GetValueArray<string>();
			}
			set
			{
				SetValue(value);
			}
		}

		public int IntValue
		{
			get
			{
				return GetValue<int>();
			}
			set
			{
				SetValue(value);
			}
		}

		public int[] IntValueArray
		{
			get
			{
				return GetValueArray<int>();
			}
			set
			{
				SetValue(value);
			}
		}

		public float FloatValue
		{
			get
			{
				return GetValue<float>();
			}
			set
			{
				SetValue(value);
			}
		}

		public float[] FloatValueArray
		{
			get
			{
				return GetValueArray<float>();
			}
			set
			{
				SetValue(value);
			}
		}

		public double DoubleValue
		{
			get
			{
				return GetValue<double>();
			}
			set
			{
				SetValue(value);
			}
		}

		public double[] DoubleValueArray
		{
			get
			{
				return GetValueArray<double>();
			}
			set
			{
				SetValue(value);
			}
		}

		public bool BoolValue
		{
			get
			{
				return GetValue<bool>();
			}
			set
			{
				SetValue(value);
			}
		}

		public bool[] BoolValueArray
		{
			get
			{
				return GetValueArray<bool>();
			}
			set
			{
				SetValue(value);
			}
		}

		public DateTime DateTimeValue
		{
			get
			{
				return GetValue<DateTime>();
			}
			set
			{
				SetValue(value);
			}
		}

		public DateTime[] DateTimeValueArray
		{
			get
			{
				return GetValueArray<DateTime>();
			}
			set
			{
				SetValue(value);
			}
		}

		public bool IsArray => ArraySize >= 0;

		public int ArraySize
		{
			get
			{
				if (mCachedArrayElementSeparator != Configuration.ArrayElementSeparator)
				{
					mCachedArrayElementSeparator = Configuration.ArrayElementSeparator;
					mShouldCalculateArraySize = true;
				}
				if (mShouldCalculateArraySize)
				{
					mCachedArraySize = CalculateArraySize();
					mShouldCalculateArraySize = false;
				}
				return mCachedArraySize;
			}
		}

		public Setting(string name)
			: this(name, string.Empty)
		{
		}

		public Setting(string name, object value)
			: base(name)
		{
			SetValue(value);
			mCachedArrayElementSeparator = Configuration.ArrayElementSeparator;
		}

		private int CalculateArraySize()
		{
			int num = 0;
			SettingArrayEnumerator settingArrayEnumerator = new SettingArrayEnumerator(mRawValue, shouldCalcElemString: false);
			while (settingArrayEnumerator.Next())
			{
				num++;
			}
			if (!settingArrayEnumerator.IsValid)
			{
				return -1;
			}
			return num;
		}

		public object GetValue(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (type.IsArray)
			{
				throw new InvalidOperationException("To obtain an array value, use GetValueArray() instead of GetValue().");
			}
			if (IsArray)
			{
				throw new InvalidOperationException("The setting represents an array. Use GetValueArray() to obtain its value.");
			}
			return CreateObjectFromString(mRawValue, type);
		}

		public object[] GetValueArray(Type elementType)
		{
			if (elementType.IsArray)
			{
				throw CreateJaggedArraysNotSupportedEx(elementType);
			}
			int arraySize = ArraySize;
			if (ArraySize < 0)
			{
				return null;
			}
			object[] array = new object[arraySize];
			if (arraySize > 0)
			{
				SettingArrayEnumerator settingArrayEnumerator = new SettingArrayEnumerator(mRawValue, shouldCalcElemString: true);
				int num = 0;
				while (settingArrayEnumerator.Next())
				{
					array[num] = CreateObjectFromString(settingArrayEnumerator.Current, elementType);
					num++;
				}
			}
			return array;
		}

		public T GetValue<T>()
		{
			Type typeFromHandle = typeof(T);
			if (typeFromHandle.IsArray)
			{
				throw new InvalidOperationException("To obtain an array value, use GetValueArray() instead of GetValue().");
			}
			if (IsArray)
			{
				throw new InvalidOperationException("The setting represents an array. Use GetValueArray() to obtain its value.");
			}
			return (T)CreateObjectFromString(mRawValue, typeFromHandle);
		}

		public T[] GetValueArray<T>()
		{
			Type typeFromHandle = typeof(T);
			if (typeFromHandle.IsArray)
			{
				throw CreateJaggedArraysNotSupportedEx(typeFromHandle);
			}
			int arraySize = ArraySize;
			if (arraySize < 0)
			{
				return null;
			}
			T[] array = new T[arraySize];
			if (arraySize > 0)
			{
				SettingArrayEnumerator settingArrayEnumerator = new SettingArrayEnumerator(mRawValue, shouldCalcElemString: true);
				int num = 0;
				while (settingArrayEnumerator.Next())
				{
					array[num] = (T)CreateObjectFromString(settingArrayEnumerator.Current, typeFromHandle);
					num++;
				}
			}
			return array;
		}

		private static object CreateObjectFromString(string value, Type dstType)
		{
			Type underlyingType = Nullable.GetUnderlyingType(dstType);
			if (underlyingType != null)
			{
				if (string.IsNullOrEmpty(value))
				{
					return null;
				}
				dstType = underlyingType;
			}
			ITypeStringConverter typeStringConverter = Configuration.FindTypeStringConverter(dstType);
			if (typeStringConverter == Configuration.FallbackConverter)
			{
				throw SettingValueCastException.CreateBecauseConverterMissing(value, dstType);
			}
			try
			{
				return typeStringConverter.ConvertFromString(value, dstType);
			}
			catch (Exception innerException)
			{
				throw SettingValueCastException.Create(value, dstType, innerException);
			}
		}

		public void SetValue(object value)
		{
			if (value == null)
			{
				SetEmptyValue();
				return;
			}
			Type type = value.GetType();
			if (type.IsArray)
			{
				if (type.GetElementType().IsArray)
				{
					throw CreateJaggedArraysNotSupportedEx(type.GetElementType());
				}
				Array array = value as Array;
				string[] array2 = new string[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					object value2 = array.GetValue(i);
					ITypeStringConverter typeStringConverter = Configuration.FindTypeStringConverter(value2.GetType());
					array2[i] = typeStringConverter.ConvertToString(value2);
				}
				mRawValue = $"{{{string.Join(Configuration.ArrayElementSeparator.ToString(), array2)}}}";
				mCachedArraySize = array.Length;
				mShouldCalculateArraySize = false;
			}
			else
			{
				ITypeStringConverter typeStringConverter2 = Configuration.FindTypeStringConverter(type);
				mRawValue = typeStringConverter2.ConvertToString(value);
				mShouldCalculateArraySize = true;
			}
		}

		private void SetEmptyValue()
		{
			mRawValue = string.Empty;
			mCachedArraySize = 0;
			mShouldCalculateArraySize = false;
		}

		protected override string GetStringExpression()
		{
			return $"{base.Name} = {mRawValue}";
		}

		private static ArgumentException CreateJaggedArraysNotSupportedEx(Type type)
		{
			Type elementType = type.GetElementType();
			while (elementType.IsArray)
			{
				elementType = elementType.GetElementType();
			}
			throw new ArgumentException($"Jagged arrays are not supported. The type you have specified is '{type.Name}', but '{elementType.Name}' was expected.");
		}
	}
}
