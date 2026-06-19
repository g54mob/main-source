using System;

namespace Loxodon.Framework.Binding.Parameters
{
	public class ConstantCommandParameter : ICommandParameter
	{
		private object parameter;

		public ConstantCommandParameter(object parameter)
		{
			this.parameter = parameter;
		}

		public object GetValue()
		{
			return parameter;
		}

		public Type GetValueType()
		{
			if (parameter == null)
			{
				return typeof(object);
			}
			return parameter.GetType();
		}
	}
	public class ConstantCommandParameter<T> : ICommandParameter<T>, ICommandParameter
	{
		private T parameter;

		public ConstantCommandParameter(T parameter)
		{
			this.parameter = parameter;
		}

		public T GetValue()
		{
			return parameter;
		}

		public Type GetValueType()
		{
			return typeof(T);
		}

		object ICommandParameter.GetValue()
		{
			return GetValue();
		}
	}
}
