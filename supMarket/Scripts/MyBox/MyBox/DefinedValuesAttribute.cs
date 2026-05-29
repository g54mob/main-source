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
		}

		public DefinedValuesAttribute(bool withLabels, params object[] definedValues)
		{
		}

		public DefinedValuesAttribute(string method)
		{
		}
	}
}
