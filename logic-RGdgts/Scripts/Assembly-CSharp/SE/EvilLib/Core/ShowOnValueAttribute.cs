using UnityEngine;

namespace SE.EvilLib.Core
{
	public class ShowOnValueAttribute : PropertyAttribute
	{
		public readonly string paramToLook;

		public readonly bool showOnBoolValue;

		public readonly int[] showOnIntValues;

		public string customLabel;

		public ShowOnValueAttribute(string _paramToLook, bool _showOnBoolValue, string _customLabel = "")
		{
		}

		public ShowOnValueAttribute(string _paramToLook, int _showOnIntValue, string _customLabel = "")
		{
		}

		public ShowOnValueAttribute(string _paramToLook, string _customLabel = "", params int[] _showOnIntValue)
		{
		}
	}
}
