using System;

namespace Code.Utility
{
	public class CachedObject<T> where T : IEquatable<T>
	{
		public T CurrentValue;

		public Action<T> UpdateAction;

		public CachedObject(Action<T> action)
		{
			UpdateAction = action;
		}

		public virtual void Update(T new_value)
		{
			if (IsChanged(new_value))
			{
				CurrentValue = new_value;
				UpdateAction(CurrentValue);
			}
		}

		public virtual bool IsChanged(T new_value)
		{
			if (CurrentValue == null || new_value == null)
			{
				if (CurrentValue == null)
				{
					return new_value != null;
				}
				return true;
			}
			return !CurrentValue.Equals(new_value);
		}
	}
}
