using UnityEngine;

namespace MyBox
{
	public class DefinedValuesAttribute : PropertyAttribute
	{
		public readonly object[] ValuesArray;

		public readonly string[] LabelsArray;

		public readonly string UseMethod;

		public DefinedValuesAttribute(params object[] definedValues)
		{
			ValuesArray = definedValues;
		}

		public DefinedValuesAttribute(bool withLabels, params object[] definedValues)
		{
			int num = definedValues.Length / 2;
			ValuesArray = new object[num];
			LabelsArray = new string[num];
			int num2 = 0;
			int num3;
			for (num3 = 0; num3 < definedValues.Length; num3++)
			{
				ValuesArray[num2] = definedValues[num3];
				LabelsArray[num2] = definedValues[++num3].ToString();
				num2++;
			}
		}

		public DefinedValuesAttribute(string method)
		{
			UseMethod = method;
		}
	}
}
