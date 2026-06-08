using System.Collections.Generic;

namespace Stonescript
{
	public class NativeFunction : IFunction
	{
		public delegate object Callback(List<object> parameters, InvocationContext context);

		private string name;

		private StonescriptObject owner;

		private List<string> parameterNames;

		private Callback callback;

		public string Name => name;

		public StonescriptObject Owner
		{
			get
			{
				return owner;
			}
			set
			{
				owner = value;
			}
		}

		public List<string> ParameterNames => parameterNames;

		public NativeFunction(StonescriptObject owner, string name, Callback callback, List<string> parameterNames = null)
		{
			this.owner = owner;
			this.name = name;
			this.parameterNames = parameterNames;
			this.callback = callback;
		}

		public NativeFunction(StonescriptObject owner, Callback callback, List<string> parameterNames = null)
		{
			this.owner = owner;
			name = callback.Method.Name;
			this.parameterNames = parameterNames;
			this.callback = callback;
		}

		public object Invoke(List<object> parameters, InvocationContext context)
		{
			return callback(parameters, context);
		}

		public override string ToString()
		{
			return name;
		}
	}
}
