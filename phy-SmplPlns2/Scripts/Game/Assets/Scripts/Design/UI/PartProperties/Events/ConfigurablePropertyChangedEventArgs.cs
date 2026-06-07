using System;

namespace Assets.Scripts.Design.UI.PartProperties.Events
{
	public class ConfigurablePropertyChangedEventArgs : EventArgs
	{
		public string PropertyName { get; }

		public ConfigurablePropertyChangedEventArgs(string propertyName)
		{
			PropertyName = propertyName;
		}
	}
}
