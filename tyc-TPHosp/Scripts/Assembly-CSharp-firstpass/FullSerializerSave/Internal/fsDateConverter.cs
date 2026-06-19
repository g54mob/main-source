using System;
using System.Globalization;

namespace FullSerializerSave.Internal
{
	public class fsDateConverter : fsConverter
	{
		private const string DefaultDateTimeFormatString = "o";

		private const string DateTimeOffsetFormatString = "o";

		private string DateTimeFormatString => Serializer.Config.CustomDateTimeFormatString ?? "o";

		public override bool CanProcess(Type type)
		{
			if (!(type == typeof(DateTime)) && !(type == typeof(DateTimeOffset)))
			{
				return type == typeof(TimeSpan);
			}
			return true;
		}

		public override fsResult TrySerialize(object instance, out fsData serialized, Type storageType)
		{
			if (instance is DateTime dateTime)
			{
				if (Serializer.Config.SerializeDateTimeAsInteger)
				{
					serialized = new fsData(dateTime.Ticks);
					return fsResult.Success;
				}
				serialized = new fsData(dateTime.ToString(DateTimeFormatString));
				return fsResult.Success;
			}
			if (instance is DateTimeOffset dateTimeOffset)
			{
				serialized = new fsData(dateTimeOffset.Ticks);
				return fsResult.Success;
			}
			if (instance is TimeSpan timeSpan)
			{
				if (Serializer.Config.SerializeDateTimeAsInteger)
				{
					serialized = new fsData(timeSpan.Ticks);
				}
				else
				{
					serialized = new fsData(timeSpan.ToString());
				}
				return fsResult.Success;
			}
			throw new InvalidOperationException("FullSerializerSave Internal Error -- Unexpected serialization type");
		}

		public override fsResult TryDeserialize(fsData data, ref object instance, Type storageType)
		{
			if (!data.IsString && (!data.IsInt64 || !Serializer.Config.SerializeDateTimeAsInteger || instance is DateTimeOffset))
			{
				return fsResult.Fail("Date deserialization requires a string or int, not " + data.Type);
			}
			if (storageType == typeof(DateTime))
			{
				if (Serializer.Config.SerializeDateTimeAsInteger && data.IsInt64)
				{
					instance = new DateTime(data.AsInt64);
					return fsResult.Success;
				}
				if (DateTime.TryParse(data.AsString, null, DateTimeStyles.RoundtripKind, out var result))
				{
					instance = result;
					return fsResult.Success;
				}
				if (fsGlobalConfig.AllowInternalExceptions)
				{
					try
					{
						instance = Convert.ToDateTime(data.AsString);
						return fsResult.Success;
					}
					catch (Exception ex)
					{
						return fsResult.Fail("Unable to parse " + data.AsString + " into a DateTime; got exception " + ex);
					}
				}
				return fsResult.Fail("Unable to parse " + data.AsString + " into a DateTime");
			}
			if (storageType == typeof(DateTimeOffset))
			{
				if (DateTimeOffset.TryParse(data.AsString, null, DateTimeStyles.RoundtripKind, out var result2))
				{
					instance = result2;
					return fsResult.Success;
				}
				return fsResult.Fail("Unable to parse " + data.AsString + " into a DateTimeOffset");
			}
			if (storageType == typeof(TimeSpan))
			{
				if (Serializer.Config.SerializeDateTimeAsInteger && data.IsInt64)
				{
					instance = new TimeSpan(data.AsInt64);
					return fsResult.Success;
				}
				if (TimeSpan.TryParse(data.AsString, out var result3))
				{
					instance = result3;
					return fsResult.Success;
				}
				return fsResult.Fail("Unable to parse " + data.AsString + " into a TimeSpan");
			}
			throw new InvalidOperationException("FullSerializerSave Internal Error -- Unexpected deserialization type");
		}
	}
}
