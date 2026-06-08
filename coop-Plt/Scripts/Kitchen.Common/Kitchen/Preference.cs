using System;

namespace Kitchen
{
	public abstract class Preference<T> : IPreference
	{
		protected T Default;

		public Action<T> ApplyAction;

		private T _Value;

		public Pref Key { get; protected set; }

		public T Value
		{
			get
			{
				return _Value;
			}
			set
			{
				_Value = value;
				Apply();
			}
		}

		public abstract void Save();

		public abstract void Load();

		public abstract string SaveAsString();

		public abstract void LoadFromString(string value);

		public virtual void Apply()
		{
			if (ApplyAction != null)
			{
				ApplyAction(_Value);
			}
		}

		public Preference(Pref key, T default_value, Action<T> action = null)
		{
			Key = key;
			Default = default_value;
			_Value = Default;
			ApplyAction = action;
		}
	}
}
