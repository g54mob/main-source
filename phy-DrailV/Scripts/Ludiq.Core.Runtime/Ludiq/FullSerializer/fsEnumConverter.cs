using System;
using System.Collections.Generic;
using System.Text;
using Ludiq.FullSerializer.Internal;

namespace Ludiq.FullSerializer
{
	public class fsEnumConverter : fsConverter
	{
		public override bool CanProcess(Type type)
		{
			return type.Resolve().IsEnum;
		}

		public override bool RequestCycleSupport(Type storageType)
		{
			return false;
		}

		public override bool RequestInheritanceSupport(Type storageType)
		{
			return false;
		}

		public override object CreateInstance(fsData data, Type storageType)
		{
			return Enum.ToObject(storageType, (object)0);
		}

		public override fsResult TrySerialize(object instance, out fsData serialized, Type storageType)
		{
			if (Serializer.Config.SerializeEnumsAsInteger)
			{
				serialized = new fsData(Convert.ToInt64(instance));
			}
			else if (fsPortableReflection.GetAttribute<FlagsAttribute>(storageType) != null)
			{
				long num = Convert.ToInt64(instance);
				StringBuilder stringBuilder = new StringBuilder();
				bool flag = true;
				foreach (object value in Enum.GetValues(storageType))
				{
					long num2 = Convert.ToInt64(value);
					if (num2 != 0L && (num & num2) == num2)
					{
						if (!flag)
						{
							stringBuilder.Append(",");
						}
						flag = false;
						stringBuilder.Append(value.ToString());
					}
				}
				serialized = new fsData(stringBuilder.ToString());
			}
			else
			{
				serialized = new fsData(Enum.GetName(storageType, instance));
			}
			return fsResult.Success;
		}

		public override fsResult TryDeserialize(fsData data, ref object instance, Type storageType)
		{
			if (data.IsString)
			{
				string[] array = data.AsString.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				foreach (string text in array)
				{
					if (!ArrayContains(Enum.GetNames(storageType), text))
					{
						return fsResult.Fail("Cannot find enum name " + text + " on type " + storageType);
					}
				}
				Type underlyingType = Enum.GetUnderlyingType(storageType);
				if (underlyingType == typeof(ulong))
				{
					ulong num = 0uL;
					foreach (string value in array)
					{
						ulong num2 = (ulong)Convert.ChangeType(Enum.Parse(storageType, value), typeof(ulong));
						num |= num2;
					}
					instance = Enum.ToObject(storageType, (object)num);
				}
				else
				{
					long num3 = 0L;
					foreach (string value2 in array)
					{
						long num4 = (long)Convert.ChangeType(Enum.Parse(storageType, value2), typeof(long));
						num3 |= num4;
					}
					instance = Enum.ToObject(storageType, (object)num3);
				}
				return fsResult.Success;
			}
			if (data.IsInt64)
			{
				int num5 = (int)data.AsInt64;
				instance = Enum.ToObject(storageType, (object)num5);
				return fsResult.Success;
			}
			return fsResult.Fail($"EnumConverter encountered an unknown JSON data type for {storageType}: {data.Type}");
		}

		private static bool ArrayContains<T>(T[] values, T value)
		{
			for (int i = 0; i < values.Length; i++)
			{
				if (EqualityComparer<T>.Default.Equals(values[i], value))
				{
					return true;
				}
			}
			return false;
		}
	}
}
