using System;
using System.Globalization;
using FullSerializerSave;

namespace TH20
{
	public class Bool2DArrayConverter : fsDirectConverter
	{
		public override Type ModelType => typeof(BoolArray2D);

		public override fsResult TrySerialize(object instance, out fsData serialized, Type storageType)
		{
			bool[,] values = ((BoolArray2D)instance).Values;
			if (values == null)
			{
				serialized = fsData.Null;
			}
			else
			{
				char[] array = new char[values.Length];
				int length = values.GetLength(1);
				int length2 = values.GetLength(0);
				for (int i = 0; i < length2; i++)
				{
					for (int j = 0; j < length; j++)
					{
						array[i * length + j] = (values[i, j] ? '1' : '0');
					}
				}
				serialized = new fsData(values.GetLength(0).ToString("x8") + values.GetLength(1).ToString("x8") + new string(array));
			}
			return fsResult.Success;
		}

		public override fsResult TryDeserialize(fsData data, ref object instance, Type storageType)
		{
			if (data.IsNull)
			{
				instance = default(BoolArray2D);
				return fsResult.Success;
			}
			if (!data.IsString)
			{
				return fsResult.Fail("Data should be string.");
			}
			string asString = data.AsString;
			if (!int.TryParse(asString.Substring(0, 8), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var result))
			{
				return fsResult.Fail("Failed to parse rows as integer");
			}
			if (!int.TryParse(asString.Substring(8, 8), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var result2))
			{
				return fsResult.Fail("Failed to parse rows as integer");
			}
			string text = asString.Substring(16);
			BoolArray2D boolArray2D = new BoolArray2D
			{
				Values = new bool[result, result2]
			};
			for (int i = 0; i < result2; i++)
			{
				for (int j = 0; j < result; j++)
				{
					boolArray2D.Values[j, i] = text[j * result2 + i] != '0';
				}
			}
			instance = boolArray2D;
			return fsResult.Success;
		}
	}
}
