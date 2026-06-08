using System.ComponentModel;

namespace Castle.Components.DictionaryAdapter
{
	public class PropertyChangedEventArgsEx : PropertyChangedEventArgs
	{
		private readonly object oldValue;

		private readonly object newValue;

		public object OldValue => oldValue;

		public object NewValue => newValue;

		public PropertyChangedEventArgsEx(string propertyName, object oldValue, object newValue)
			: base(propertyName)
		{
			this.oldValue = oldValue;
			this.newValue = newValue;
		}
	}
}
