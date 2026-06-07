using System;

namespace MiscUtil.Linq
{
	public class Future<T> : IFuture<T>
	{
		private T value;

		private bool valueSet;

		public T Value
		{
			get
			{
				if (!valueSet)
				{
					throw new InvalidOperationException("No value has been set yet");
				}
				return value;
			}
			set
			{
				if (valueSet)
				{
					throw new InvalidOperationException("Value has already been set");
				}
				valueSet = true;
				this.value = value;
			}
		}

		public override string ToString()
		{
			if (!valueSet)
			{
				return null;
			}
			return Convert.ToString(value);
		}
	}
}
