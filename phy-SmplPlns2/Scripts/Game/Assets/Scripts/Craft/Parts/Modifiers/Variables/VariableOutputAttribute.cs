using System;

namespace Assets.Scripts.Craft.Parts.Modifiers.Variables
{
	[AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = true)]
	public class VariableOutputAttribute : Attribute
	{
		private readonly string _defaultOutput;

		private readonly int _defaultPriority;

		private readonly string _displayName;

		public int DefaultOutputPriority => _defaultPriority;

		public string DefaultOutputVariable => _defaultOutput;

		public string DisplayName => _displayName;

		public VariableOutputAttribute(string displayName)
		{
			_displayName = displayName;
			_defaultOutput = null;
			_defaultPriority = 0;
		}

		public VariableOutputAttribute(string displayName, string defaultOutput, int defaultPriority)
		{
			_displayName = displayName;
			_defaultOutput = defaultOutput;
			_defaultPriority = defaultPriority;
		}
	}
}
