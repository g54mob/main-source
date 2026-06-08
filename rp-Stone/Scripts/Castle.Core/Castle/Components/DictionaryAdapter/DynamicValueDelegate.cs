using System;

namespace Castle.Components.DictionaryAdapter
{
	public class DynamicValueDelegate<T> : DynamicValue<T>
	{
		private readonly Func<T> dynamicDelegate;

		public override T Value => dynamicDelegate();

		public DynamicValueDelegate(Func<T> dynamicDelegate)
		{
			this.dynamicDelegate = dynamicDelegate;
		}
	}
}
