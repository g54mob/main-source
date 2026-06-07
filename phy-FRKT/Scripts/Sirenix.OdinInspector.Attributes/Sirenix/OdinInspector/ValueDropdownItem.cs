namespace Sirenix.OdinInspector
{
	public struct ValueDropdownItem : IValueDropdownItem
	{
		public string Text;

		public object Value;

		public ValueDropdownItem(string text, object value)
		{
			Text = null;
			Value = null;
		}

		public override string ToString()
		{
			return null;
		}

		string IValueDropdownItem.GetText()
		{
			return null;
		}

		object IValueDropdownItem.GetValue()
		{
			return null;
		}
	}
	public struct ValueDropdownItem<T> : IValueDropdownItem
	{
		public string Text;

		public T Value;

		public ValueDropdownItem(string text, T value)
		{
			Text = null;
			Value = default(T);
		}

		string IValueDropdownItem.GetText()
		{
			return null;
		}

		object IValueDropdownItem.GetValue()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
