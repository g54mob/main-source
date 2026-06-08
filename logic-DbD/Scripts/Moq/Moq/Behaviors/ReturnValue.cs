namespace Moq.Behaviors
{
	internal sealed class ReturnValue : Behavior
	{
		private readonly object value;

		public object Value => value;

		public ReturnValue(object value)
		{
			this.value = value;
		}

		public override void Execute(Invocation invocation)
		{
			invocation.ReturnValue = value;
		}
	}
}
