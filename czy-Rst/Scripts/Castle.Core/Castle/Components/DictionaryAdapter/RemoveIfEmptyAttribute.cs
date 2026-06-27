using System;
using System.Collections;

namespace Castle.Components.DictionaryAdapter
{
	public class RemoveIfEmptyAttribute : RemoveIfAttribute
	{
		private class RemoveIfEmptyCondition : ICondition
		{
			public static readonly RemoveIfEmptyCondition Instance = new RemoveIfEmptyCondition();

			public bool SatisfiedBy(object value)
			{
				if (value != null && !IsEmptyString(value) && !IsEmptyGuid(value))
				{
					return IsEmptyCollection(value);
				}
				return true;
			}

			private static bool IsEmptyString(object value)
			{
				if (value is string)
				{
					return ((string)value).Length == 0;
				}
				return false;
			}

			private static bool IsEmptyGuid(object value)
			{
				if (value is Guid)
				{
					return (Guid)value == Guid.Empty;
				}
				return false;
			}

			private static bool IsEmptyCollection(object value)
			{
				if (value is IEnumerable)
				{
					return !((IEnumerable)value).GetEnumerator().MoveNext();
				}
				return false;
			}
		}

		private new Type Condition { get; set; }

		public RemoveIfEmptyAttribute()
			: base(RemoveIfEmptyCondition.Instance)
		{
		}
	}
}
