using System.ComponentModel;

namespace Castle.Components.DictionaryAdapter
{
	public class PropertyChangingEventArgsEx : PropertyChangingEventArgs
	{
		private readonly object oldValue;

		private readonly object newValue;

		private bool cancel;

		public object OldValue => oldValue;

		public object NewValue => newValue;

		public bool Cancel
		{
			get
			{
				return cancel;
			}
			set
			{
				cancel = value;
			}
		}

		public PropertyChangingEventArgsEx(string propertyName, object oldValue, object newValue)
			: base(propertyName)
		{
			this.oldValue = oldValue;
			this.newValue = newValue;
		}
	}
}
